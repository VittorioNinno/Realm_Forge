using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Rules;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Fighting on the map: an attack at a token resolved here against its armour class (which the players never see),
	///	with its damage and condition applied; weapons dropped on the ground as tokens and picked up again; the loot of
	///	a creature, taken once it is down. In a fight, attacking spends the action of the attacker's turn (a reaction
	///	outside it), picking something up the action.
	///	</summary>
	public partial class MapsController
	{
		private static readonly JsonSerializerOptions GearJson = new(JsonSerializerDefaults.Web);

		public static TokenGear ReadGear(string? json)
		{
			try
			{
				return string.IsNullOrWhiteSpace(json) ? new TokenGear() : JsonSerializer.Deserialize<TokenGear>(json, GearJson) ?? new TokenGear();
			}
			catch (JsonException)
			{
				return new TokenGear();
			}
		}

		private static void WriteGear(CampaignToken token, TokenGear gear) => token.Gear = JsonSerializer.Serialize(gear, GearJson);

		private static string T(bool italian, string it, string en) => italian ? it : en;

		// ===== Attacks =====

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/attack — a token attacks another: whoever controls the attacker
		//	(a master any token), a player only in a fight
		[HttpPost("{mapId:guid}/attack")]
		public async Task<ActionResult<MapAttackResultDto>> Attack(Guid campaignId, Guid mapId, [FromBody] MapAttackDto dto, [FromQuery] LanguageCode? lang)
		{
			var italian = lang != LanguageCode.En;
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var attacker = map?.Tokens.FirstOrDefault(t => t.Id == dto.AttackerId);
			var target = map?.Tokens.FirstOrDefault(t => t.Id == dto.TargetId);
			if (map is null || role is null || attacker is null || target is null || attacker.Id == target.Id)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role.Value);
			if (!runs && (!await ControlsAsync(attacker) || target.Hidden))
			{
				return Forbid();
			}
			if (target.Kind == TokenKind.Prop)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Objects are not attacked here.");
			}
			var name = (dto.Name ?? string.Empty).Trim();
			var damageText = string.IsNullOrWhiteSpace(dto.Damage) ? null : dto.Damage.Replace(" ", string.Empty).Replace('−', '-');
			DiceNotation.Parsed? damageDice = null;
			var flatDamage = 0;
			if (name.Length is 0 or > 60 || dto.Bonus is < -20 or > 40 || dto.Reach is < 0 or > 20 || dto.Range is < 0 or > 1000 || dto.LongRange is < 0 or > 1000
				|| dto.Mode is < -1 or > 1 || (dto.DamageType?.Length ?? 0) > 40
				|| (damageText is not null && !TryDamage(damageText, out damageDice, out flatDamage))
				|| (dto.Condition is { } key && !EncounterRules.Conditions.Contains(key)))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid attack.");
			}

			var fight = await FightAsync(map, track: true);
			var attackerCombatant = attacker.CombatantId is { } aid ? fight?.Combatants.FirstOrDefault(c => c.Id == aid) : null;
			var targetCombatant = target.CombatantId is { } tid ? fight?.Combatants.FirstOrDefault(c => c.Id == tid) : null;
			if (!runs && attackerCombatant is null)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Si attacca un bersaglio solo durante un combattimento.", "Targets are attacked only during a fight."));
			}

			//	An attack of opportunity is made where the target was when it left the reach (the start of its move)
			var opportunity = attackerCombatant is { OpportunityOn: { } on, OpportunityX: { } ox, OpportunityY: { } oy } && on == target.Id
				&& fight!.Encounter.CurrentId != attackerCombatant.Id ? (X: ox, Y: oy) : ((int X, int Y)?)null;
			var (targetX, targetY) = opportunity ?? (target.X, target.Y);

			//	How far: the nearest cells of the two tokens
			var gap = TableCombat.Gap(map.GridType, attacker.X, attacker.Y, attacker.Size, targetX, targetY, target.Size);
			var (can, far) = new AttackReach(dto.Reach, dto.Range, Math.Max(dto.Range, dto.LongRange)).At(gap);
			if (!can)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Il bersaglio è fuori portata.", "The target is out of reach."));
			}

			//	The turn: the action on its own turn, the reaction outside it
			//	A character with a weapon of the other kind in hand changes it with the free interaction of the turn
			var ranged = dto.Range > 0 && dto.Reach <= 0;
			if (!dto.Spell && attackerCombatant is { Kind: CombatantKind.Character, Wield: { } inHand } && fight?.Encounter.CurrentId == attackerCombatant.Id
				&& inHand != (ranged ? "ranged" : "melee"))
			{
				if (attackerCombatant.Interacted && !runs)
				{
					return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Prima cambia arma: l'interazione gratuita del turno è già usata.", "Change weapon first: the free interaction of the turn is used."));
				}
				attackerCombatant.Interacted = true;
				attackerCombatant.Wield = ranged ? "ranged" : "melee";
			}
			if (fight is not null && attackerCombatant is not null && !(dto.Reroll && dto.Spell) && SpendForAttack(fight, attackerCombatant, runs, italian, dto.ActionAttacks, target.Id) is { } refused)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: refused);
			}

			//	The sheets of the characters involved (conditions, armour class, hit points)
			var characterIds = new[] { attacker.CharacterId, target.CharacterId, target.SheetCharacterId }.OfType<Guid>().Distinct().ToList();
			var characters = await _context.Characters.Where(c => characterIds.Contains(c.Id)).ToListAsync();
			var attackerConditions = ConditionsOf(attacker, attackerCombatant, characters);
			var targetConditions = ConditionsOf(target, targetCombatant, characters);
			if (targetCombatant?.Dodging == true)
			{
				targetConditions = targetConditions.Append("dodging").ToList();
			}
			var effect = TableCombat.Effect(attackerConditions, targetConditions, gap, far, dto.Mode);

			var armorClass = await ArmorClassOfAsync(target, targetCombatant, characters);

			//	Cover from the terrain between the two: a wall or a closed door in the way stops the attack, a low wall adds 2 to
			//	the armour class, an arrow slit 5
			var closedDoors = map.Tokens.Where(t => t.Kind == TokenKind.Prop && t.PropType is { } door && MapTerrain.Closes(door, t.PropState))
				.SelectMany(t => MapTerrain.Footprint(map.GridType, t.X, t.Y, t.Size)).ToHashSet();
			var cover = MapTerrain.Cover(map.GridType, map.GridSize, map.GridOffsetX, map.GridOffsetY, MapTerrain.Read(map.Terrain), closedDoors,
				(attacker.X, attacker.Y, attacker.Size), (targetX, targetY, target.Size));
			if (cover >= MapTerrain.TotalCover)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Il bersaglio è dietro un muro: copertura totale.", "The target is behind a wall: total cover."));
			}
			var first = RandomNumberGenerator.GetInt32(1, 21);
			var second = effect.Mode != 0 ? RandomNumberGenerator.GetInt32(1, 21) : 0;
			var keepFirst = effect.Mode == 0 || (effect.Mode > 0 ? first >= second : first <= second);
			var die = keepFirst ? first : second;
			var dice = new List<RollDieDto> { new(20, first, !keepFirst) };
			if (effect.Mode != 0)
			{
				dice.Add(new RollDieDto(20, second, keepFirst));
			}
			var total = die + dto.Bonus;
			armorClass += cover;
			var hit = die == 20 || (die != 1 && total >= armorClass);
			var critical = hit && (die == 20 || effect.AutoCritical);

			int? damage = null;
			var damageRolled = new List<RollDieDto>();
			var notes = new List<string>();
			if (cover > 0)
			{
				notes.Add(cover >= 5 ? T(italian, "copertura tre quarti (+5 CA)", "three-quarters cover (+5 AC)") : T(italian, "mezza copertura (+2 CA)", "half cover (+2 AC)"));
			}
			if (hit && damageText is not null)
			{
				if (damageDice is not null)
				{
					var expression = critical ? TableCombat.Critical(damageDice.Text) : damageDice.Text;
					DiceNotation.TryParse(expression, out var parsed);
					var (rolled, sum) = DiceNotation.Roll(parsed, sides => RandomNumberGenerator.GetInt32(1, sides + 1));
					damageRolled = rolled.Select(d => new RollDieDto(d.Sides, d.Value, d.Dropped)).ToList();
					damage = Math.Max(0, sum);
				}
				else
				{
					damage = Math.Max(0, flatDamage);
				}
			}

			//	Damage and conditions go on the target by themselves only from the enemies, the tokens no player controls; a
			//	character's attack is rolled and told, the master applies what it does
			var applies = attacker.CharacterId is null && attacker.ControlledBy.Count == 0;
			var down = false;
			//	The target's defenses against the damage type (a spell is magical)
			if (hit && damage is { } rawDamage && rawDamage > 0 && DamageDefenses.TypeOf(dto.DamageType) is { } damageType)
			{
				var (adjusted, why) = (await DefensesOfAsync(target, targetCombatant, characters)).Apply(rawDamage, damageType, dto.Spell);
				if (DefenseNote(why, italian) is { } defenseNote)
				{
					damage = adjusted;
					notes.Add(defenseNote);
				}
			}
			if (hit && applies)
			{
				down = ApplyDamage(target, targetCombatant, characters, damage ?? 0, critical, dto.Condition, out var concentration);
				if (concentration is { } dc)
				{
					notes.Add(T(italian, $"TS Costituzione CD {dc} per la concentrazione", $"Constitution save DC {dc} to keep concentration"));
				}
				if (target.MonsterId is { } monsterId && target.CharacterId is null && targetCombatant is null && target.MaxHp is null)
				{
					//	A monster outside a fight hurt for the first time: its hit points from the statblock
					var hp = await _context.Monsters.AsNoTracking().Where(m => m.Id == monsterId).Select(m => m.HitPoints).FirstOrDefaultAsync();
					if (hp > 0)
					{
						target.MaxHp = hp;
						target.Hp = Math.Max(0, hp - (damage ?? 0));
						down = target.Hp == 0;
					}
				}
			}

			//	Dropped by an attack of opportunity: it never left, it lies where its move started
			if (down && opportunity is { } start && OnMap(map, start.X, start.Y, target.Size))
			{
				target.X = start.X;
				target.Y = start.Y;
			}

			var text = !hit
				? T(italian, die == 1 ? "Mancato (1 naturale)" : "Mancato", die == 1 ? "Miss (natural 1)" : "Miss")
				: (critical ? T(italian, "Colpo critico", "Critical hit") : T(italian, "Colpito", "Hit"))
					+ (damage is { } dealt ? T(italian, $" · {dealt} danni{(dto.DamageType is { Length: > 0 } dt ? " " + dt : string.Empty)}", $" · {dealt}{(dto.DamageType is { Length: > 0 } dt2 ? " " + dt2 : string.Empty)} damage") : string.Empty)
					+ (applies && dto.Condition is { } imposed ? $" · {TableCombat.ConditionName(imposed, italian)}" : string.Empty)
					+ (down ? T(italian, " · a terra", " · down") : string.Empty);
			if (effect.Mode != 0)
			{
				notes.Insert(0, effect.Mode > 0 ? T(italian, "vantaggio", "advantage") : T(italian, "svantaggio", "disadvantage"));
			}
			var note = string.Join(" · ", new[] { text }.Concat(notes));

			//	The log: what the table sees of it (never the armour class)
			var colors = await CampaignAccess.EnsureColorsAsync(_context, campaignId);
			var roller = attacker.CharacterId is not null ? characters.FirstOrDefault(c => c.Id == attacker.CharacterId)?.Name ?? attacker.Label
				: runs ? (role == CampaignRole.Master ? "Master" : "Co-master") : attacker.Label;
			var log = new CampaignRoll
			{
				CampaignId = campaignId,
				UserId = UserId,
				CharacterId = attacker.CharacterId,
				CharacterName = attacker.CharacterId is not null ? Cut(roller, 100) : null,
				Roller = Cut(roller, 100),
				Color = colors.GetValueOrDefault(UserId, PlayerColors.Master),
				Label = Cut($"{attacker.Label} → {target.Label}: {name}", 120),
				Expression = dto.Bonus == 0 ? "1d20" : $"1d20{(dto.Bonus > 0 ? "+" : string.Empty)}{dto.Bonus}",
				Dice = JsonSerializer.Serialize(dice, GearJson),
				Modifier = dto.Bonus,
				Total = total,
				Note = Cut(note, 200),
				Hidden = runs && attacker.Hidden
			};
			_context.CampaignRolls.Add(log);
			if (fight is not null)
			{
				//	A creature dropped lets go of what it grapples
				await ReleaseGrapplesAsync(map, fight);
				Save(fight, fight.Combatants);
			}
			target.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			//	Every screen shows the hit or the miss on the target
			map.StrikeTokenId = target.Id;
			map.StrikeKind = !hit ? 0 : critical ? 2 : 1;
			map.StrikeDamage = hit ? damage : null;
			map.StrikeAt = map.UpdatedAt;
			await _context.SaveChangesAsync();
			return Ok(new MapAttackResultDto(hit, critical, dice, dto.Bonus, total, damage, damageRolled, note, runs ? armorClass : null));
		}

		//	Damage as dice ("1d8+3") or a flat number ("2")
		private static bool TryDamage(string text, out DiceNotation.Parsed? dice, out int flat)
		{
			dice = null;
			flat = 0;
			if (DiceNotation.TryParse(text, out var parsed))
			{
				dice = parsed;
				return true;
			}
			return int.TryParse(text, out flat) && flat is >= 0 and <= 1000;
		}

		private static string Cut(string text, int length) => text.Length > length ? text[..length] : text;

		//	The action of the turn (more attacks of the same action are fine), or the reaction outside the turn; a master
		//	is never stopped, the turn is only marked
		//	On its own turn an attack is part of the Attack action (a character: as many attacks as its Extra Attack allows);
		//	outside its turn it takes the reaction (an attack of opportunity offered on the target is taken)
		private static string? SpendForAttack(Fight fight, EncounterCombatant combatant, bool runs, bool italian, int? actionAttacks, Guid targetId)
		{
			if (fight.Encounter.CurrentId == combatant.Id)
			{
				if (combatant.ActionSpent == TableCombat.SpentOther && !runs)
				{
					return T(italian, "L'azione di questo turno è già stata usata.", "The action of this turn was already used.");
				}
				if (combatant.Kind == CombatantKind.Character && actionAttacks is { } most && combatant.AttacksMade >= Math.Clamp(most, 1, 4) && !runs)
				{
					return T(italian, "Gli attacchi dell'azione di Attacco sono finiti per questo turno.", "The attacks of the Attack action are over for this turn.");
				}
				combatant.ActionSpent ??= TableCombat.SpentAttack;
				combatant.AttacksMade++;
				return null;
			}
			if (combatant.ReactionUsed && !runs)
			{
				return T(italian, "Non è il tuo turno e la reazione è già stata usata.", "It is not your turn and the reaction was already used.");
			}
			combatant.ReactionUsed = true;
			if (combatant.OpportunityOn == targetId)
			{
				combatant.OpportunityOn = null;
				combatant.OpportunityX = combatant.OpportunityY = null;
			}
			return null;
		}

		private static List<string> ConditionsOf(CampaignToken token, EncounterCombatant? combatant, List<Character> characters) =>
			token.CharacterId is { } id && characters.FirstOrDefault(c => c.Id == id) is { } character
				? EncounterSheetSync.ConditionsOf(CharactersController.ReadSheet(character.Sheet))
				: combatant?.Conditions ?? token.Conditions;

		//	The armour class set at the table, else the fight's, the sheet's (a character or the sheet a copy uses), the
		//	statblock's
		private async Task<int> ArmorClassOfAsync(CampaignToken token, EncounterCombatant? combatant, List<Character> characters)
		{
			if (token.ArmorClass is { } set and > 0)
			{
				return set;
			}
			if (combatant is { ArmorClass: > 0 } && combatant.Kind != CombatantKind.Character)
			{
				return combatant.ArmorClass;
			}
			if ((token.CharacterId ?? token.SheetCharacterId) is { } id && characters.FirstOrDefault(c => c.Id == id) is { ArmorClass: > 0 } character)
			{
				return character.ArmorClass;
			}
			if (token.MonsterId is { } monsterId)
			{
				var armor = await _context.Monsters.AsNoTracking().Where(m => m.Id == monsterId).Select(m => m.ArmorClass).FirstOrDefaultAsync();
				if (armor > 0)
				{
					return armor;
				}
			}
			return 10;
		}

		//	Damage on the temporary hit points first, then on the hit points (a character's on its sheet), and the
		//	condition of the hit; true when the target drops to 0. Concentration: the save to keep it
		private static bool ApplyDamage(CampaignToken target, EncounterCombatant? combatant, List<Character> characters, int damage, bool critical, string? condition, out int? concentration)
		{
			concentration = null;
			if (target.CharacterId is { } characterId)
			{
				var character = characters.FirstOrDefault(c => c.Id == characterId);
				if (character is null)
				{
					return false;
				}
				var sheet = CharactersController.ReadSheet(character.Sheet);
				var max = Math.Max(0, character.MaxHitPoints);
				//	As on the sheet: down at 0 (unconscious and prone), a hit while down a failed death save
				var outcome = CharacterVitals.Damage(sheet, max, damage, critical, character.Ruleset);
				concentration = outcome.ConcentrationDc;
				if (condition is not null && condition != EncounterRules.Concentrating)
				{
					if (condition == EncounterRules.Exhaustion)
					{
						sheet.Exhaustion = Math.Min(6, sheet.Exhaustion + 1);
					}
					else if (!sheet.Conditions.Contains(condition))
					{
						sheet.Conditions.Add(condition);
					}
				}
				sheet.VitalsStamp++;
				character.Sheet = JsonSerializer.Serialize(sheet, CharactersController.Json);
				character.UpdatedAt = DateTimeOffset.UtcNow;
				return outcome.Dropped;
			}
			if (combatant is not null)
			{
				var absorbed = Math.Min(combatant.TempHp, damage);
				combatant.TempHp -= absorbed;
				combatant.Hp = Math.Max(0, combatant.Hp - (damage - absorbed));
				if (condition is not null && !combatant.Conditions.Contains(condition))
				{
					combatant.Conditions.Add(condition);
				}
				if (damage > 0 && combatant.Conditions.Contains(EncounterRules.Concentrating))
				{
					concentration = Math.Max(10, damage / 2);
				}
				return damage > 0 && combatant.MaxHp > 0 && combatant.Hp == 0;
			}
			var temp = target.TempHp ?? 0;
			var fromTemp = Math.Min(temp, damage);
			target.TempHp = temp - fromTemp > 0 ? temp - fromTemp : null;
			if (target.MaxHp is { } tokenMax)
			{
				target.Hp = Math.Max(0, (target.Hp ?? tokenMax) - (damage - fromTemp));
			}
			if (condition is not null && !target.Conditions.Contains(condition))
			{
				target.Conditions = target.Conditions.Append(condition).ToList();
			}
			return damage > 0 && target.MaxHp is > 0 && target.Hp == 0;
		}

		// ===== Auras that move with a token =====

		//	PUT: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}/aura — an aura set on a token (a radius of 0 takes it
		//	away): whoever controls it, a master any
		[HttpPut("{mapId:guid}/tokens/{tokenId:guid}/aura")]
		public async Task<IActionResult> SaveAura(Guid campaignId, Guid mapId, Guid tokenId, [FromBody] SaveAuraDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			if (map is null || role is null || token is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value) && !await ControlsAsync(token))
			{
				return Forbid();
			}
			var name = (dto.Name ?? string.Empty).Trim();
			var damage = string.IsNullOrWhiteSpace(dto.Damage) ? null : dto.Damage.Replace(" ", string.Empty);
			if (dto.Radius is < 0 or > TokenAura.MaxRadius || name.Length > 60 || dto.Ability is < 0 or > 6 || dto.Dc is < 0 or > 40 || (dto.DamageType?.Length ?? 0) > 40
				|| (dto.Color is { } color && !System.Text.RegularExpressions.Regex.IsMatch(color, "^#[0-9a-fA-F]{6}$"))
				|| (damage is not null && !TryDamage(damage, out _, out _)) || (dto.Radius > 0 && name.Length == 0))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid aura.");
			}
			var gear = ReadGear(token.Gear);
			gear.Aura = dto.Radius == 0 ? null : new TokenAura
			{
				Name = name,
				Radius = dto.Radius,
				Color = dto.Color ?? "#a78bfa",
				Enemies = dto.Enemies,
				Ability = dto.Ability,
				Dc = dto.Ability > 0 ? Math.Max(1, dto.Dc) : 0,
				Damage = damage,
				DamageType = string.IsNullOrWhiteSpace(dto.DamageType) ? null : dto.DamageType.Trim(),
				Half = dto.Half
			};
			WriteGear(token, gear);
			token.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		private static bool PartyOf(CampaignToken t) => t.CharacterId is not null || t.ControlledBy.Count > 0;

		//	A creature touched by the auras of the others (it entered one, or starts its turn in one; from is where it came
		//	from, null at the start of a turn), and, when it has an aura, the creatures its aura reaches as it moves: once a
		//	turn each. A save asked of the creature (the damage rolled once), or the table told
		private async Task TouchAurasAsync(CampaignMap map, Fight fight, CampaignToken creature, (int X, int Y)? from)
		{
			if (creature.Kind == TokenKind.Prop || creature.CombatantId is null || fight.Encounter.Round <= 0)
			{
				return;
			}
			var stamp = $"{fight.Encounter.Round}:{fight.Encounter.CurrentId}";
			int GapAt(CampaignToken a, (int X, int Y) at, CampaignToken b) => TableCombat.Gap(map.GridType, at.X, at.Y, a.Size, b.X, b.Y, b.Size);
			var touches = new List<(CampaignToken Owner, TokenAura Aura, TokenGear Gear, CampaignToken Target)>();
			foreach (var owner in map.Tokens.Where(t => t.Id != creature.Id && t.Kind != TokenKind.Prop))
			{
				var gear = ReadGear(owner.Gear);
				if (gear.Aura is not { } aura || (aura.Enemies && PartyOf(owner) == PartyOf(creature)))
				{
					continue;
				}
				var inside = TableCombat.Gap(map.GridType, owner.X, owner.Y, owner.Size, creature.X, creature.Y, creature.Size) <= aura.Radius;
				var before = from is { } came && GapAt(creature, came, owner) <= aura.Radius;
				if (inside && !before)
				{
					touches.Add((owner, aura, gear, creature));
				}
			}
			//	Its own aura reaching the others as it moves
			if (from is { } moved && ReadGear(creature.Gear) is { Aura: { } own } ownGear)
			{
				foreach (var other in map.Tokens.Where(t => t.Id != creature.Id && t.Kind != TokenKind.Prop && t.CombatantId is not null))
				{
					if (own.Enemies && PartyOf(other) == PartyOf(creature))
					{
						continue;
					}
					var now = TableCombat.Gap(map.GridType, creature.X, creature.Y, creature.Size, other.X, other.Y, other.Size) <= own.Radius;
					var was = TableCombat.Gap(map.GridType, moved.X, moved.Y, creature.Size, other.X, other.Y, other.Size) <= own.Radius;
					if (now && !was)
					{
						touches.Add((creature, own, ownGear, other));
					}
				}
			}
			if (touches.Count == 0)
			{
				return;
			}
			var calls = ReadSaves(map.SaveCalls);
			foreach (var (owner, aura, gear, target) in touches)
			{
				var key = $"{target.Id}:{stamp}";
				if (aura.Touched.Contains(key))
				{
					continue;
				}
				aura.Touched = aura.Touched.Append(key).TakeLast(60).ToList();
				WriteGear(owner, gear);
				int? damage = null;
				var rolled = new List<RollDieDto>();
				if (aura.Damage is { } text && TryDamage(text, out var dice, out var flat))
				{
					if (dice is not null)
					{
						var (faces, sum) = DiceNotation.Roll(dice, sides => RandomNumberGenerator.GetInt32(1, sides + 1));
						rolled = faces.Select(d => new RollDieDto(d.Sides, d.Value, d.Dropped)).ToList();
						damage = Math.Max(0, sum);
					}
					else
					{
						damage = Math.Max(0, flat);
					}
				}
				if (aura.Ability is >= 1 and <= 6)
				{
					calls.Add(new MapSaveCall
					{
						CasterTokenId = owner.Id,
						Caster = Cut(owner.Label, 60),
						Spell = Cut(aura.Name, 60),
						Ability = aura.Ability,
						Dc = Math.Max(1, aura.Dc),
						Damage = damage,
						DamageType = aura.DamageType,
						Half = aura.Half,
						CasterHidden = owner.Hidden,
						Targets = new() { new MapSaveTarget { TokenId = target.Id, Label = Cut(target.Label, 60) } }
					});
				}
				_context.CampaignRolls.Add(new CampaignRoll
				{
					CampaignId = map.CampaignId,
					UserId = UserId,
					Roller = Cut(owner.Label, 100),
					Color = owner.Color,
					Label = Cut($"{owner.Label}: {aura.Name} → {target.Label}", 120),
					Expression = aura.Damage ?? string.Empty,
					Dice = JsonSerializer.Serialize(rolled, GearJson),
					Total = damage ?? 0,
					Note = Cut(aura.Ability is >= 1 and <= 6
						? $"TS {AbilityName(aura.Ability, true)} CD {aura.Dc}{(damage is { } d ? $" · {d}" : string.Empty)}"
						: "aura", 200),
					Hidden = owner.Hidden || target.Hidden
				});
			}
			WriteSaves(map, calls);
		}

		// ===== Grapples and shoves =====

		//	A condition put on or taken off a token: a character's on its sheet, a fight's creature on its combatant
		private static void SetCondition(CampaignToken token, EncounterCombatant? combatant, List<Character> characters, string key, bool on)
		{
			if (token.CharacterId is { } characterId && characters.FirstOrDefault(c => c.Id == characterId) is { } character)
			{
				var sheet = CharactersController.ReadSheet(character.Sheet);
				var has = sheet.Conditions.Contains(key);
				if (on && !has)
				{
					sheet.Conditions.Add(key);
				}
				else if (!on && has)
				{
					sheet.Conditions.Remove(key);
				}
				sheet.VitalsStamp++;
				character.Sheet = JsonSerializer.Serialize(sheet, CharactersController.Json);
				character.UpdatedAt = DateTimeOffset.UtcNow;
			}
			if (combatant is not null)
			{
				if (on && !combatant.Conditions.Contains(key))
				{
					combatant.Conditions.Add(key);
				}
				else if (!on)
				{
					combatant.Conditions.Remove(key);
				}
			}
			else if (on && !token.Conditions.Contains(key))
			{
				token.Conditions = token.Conditions.Append(key).ToList();
			}
			else if (!on && token.Conditions.Contains(key))
			{
				token.Conditions = token.Conditions.Where(k => k != key).ToList();
			}
		}

		//	The grapples that end: the one holding is incapacitated (or down), gone, or no longer next to it; true when any did
		private async Task<bool> ReleaseGrapplesAsync(CampaignMap map, Fight fight)
		{
			var ended = new List<(CampaignToken Token, EncounterCombatant Combatant)>();
			foreach (var held in fight.Combatants.Where(c => c.GrappledBy is not null))
			{
				var holder = fight.Combatants.FirstOrDefault(c => c.Id == held.GrappledBy);
				var holderToken = map.Tokens.FirstOrDefault(t => t.CombatantId == held.GrappledBy);
				var heldToken = map.Tokens.FirstOrDefault(t => t.CombatantId == held.Id);
				var apart = holderToken is null || heldToken is null
					|| TableCombat.Gap(map.GridType, holderToken.X, holderToken.Y, holderToken.Size, heldToken.X, heldToken.Y, heldToken.Size) > 1;
				var down = holder is null || holder.Conditions.Any(EncounterRules.Incapacitating.Contains)
					|| (holder.Kind != CombatantKind.Character && holder.MaxHp > 0 && holder.Hp <= 0);
				if (apart || down)
				{
					held.GrappledBy = null;
					if (heldToken is not null)
					{
						ended.Add((heldToken, held));
					}
				}
			}
			if (ended.Count == 0)
			{
				return false;
			}
			var ids = ended.Select(e => e.Token.CharacterId).OfType<Guid>().ToList();
			var characters = ids.Count == 0 ? new List<Character>() : await _context.Characters.Where(c => ids.Contains(c.Id)).ToListAsync();
			foreach (var (token, combatant) in ended)
			{
				SetCondition(token, combatant, characters, "grappled", false);
			}
			return true;
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}/grapple — in a fight: a grapple or a shove (one of
		//	the attacks of the Attack action, at a creature next to it), an escape (the action), a grapple let go (free)
		[HttpPost("{mapId:guid}/tokens/{tokenId:guid}/grapple")]
		public async Task<ActionResult<MapAttackResultDto>> Grapple(Guid campaignId, Guid mapId, Guid tokenId, [FromBody] GrappleDto dto, [FromQuery] LanguageCode? lang)
		{
			var italian = lang != LanguageCode.En;
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var actor = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			var target = map?.Tokens.FirstOrDefault(t => t.Id == dto.TargetId);
			if (map is null || role is null || actor is null || target is null || actor.Id == target.Id)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role.Value);
			if (!runs && !await ControlsAsync(actor))
			{
				return Forbid();
			}
			var kind = (dto.Kind ?? string.Empty).Trim().ToLowerInvariant();
			if (kind is not ("grapple" or "push" or "prone" or "escape" or "release") || dto.ActorBonus is < -10 or > 30 || dto.OtherBonus is < -10 or > 30 || dto.Dc is < 1 or > 40)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid grapple.");
			}
			var fight = await FightAsync(map, track: true);
			var actorCombatant = actor.CombatantId is { } aid ? fight?.Combatants.FirstOrDefault(c => c.Id == aid) : null;
			var targetCombatant = target.CombatantId is { } tid ? fight?.Combatants.FirstOrDefault(c => c.Id == tid) : null;
			if (fight is null || actorCombatant is null || targetCombatant is null)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Lotta e spinta si fanno durante un combattimento.", "Grapples and shoves are made during a fight."));
			}
			var characterIds = new[] { actor.CharacterId, target.CharacterId }.OfType<Guid>().ToList();
			var characters = await _context.Characters.Where(c => characterIds.Contains(c.Id)).ToListAsync();

			//	Let go: free, at any time
			if (kind == "release")
			{
				if (targetCombatant.GrappledBy != actorCombatant.Id)
				{
					return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Non lo stai afferrando.", "It is not grappled by it."));
				}
				targetCombatant.GrappledBy = null;
				SetCondition(target, targetCombatant, characters, "grappled", false);
				Save(fight, fight.Combatants);
				map.UpdatedAt = DateTimeOffset.UtcNow;
				await _context.SaveChangesAsync();
				return Ok(new MapAttackResultDto(true, false, new List<RollDieDto>(), 0, 0, null, new List<RollDieDto>(), T(italian, "Presa lasciata", "Let go")));
			}
			if (kind == "escape" && actorCombatant.GrappledBy != targetCombatant.Id)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Non è afferrato da quella creatura.", "It is not grappled by that creature."));
			}
			if (TableCombat.Gap(map.GridType, actor.X, actor.Y, actor.Size, target.X, target.Y, target.Size) > 1)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Il bersaglio deve essere a portata (1,5 m).", "The target must be within reach (5 feet)."));
			}

			//	The turn: an escape is the action; a grapple or a shove one of the attacks of the Attack action
			if (kind == "escape")
			{
				if (fight.Encounter.CurrentId != actorCombatant.Id && !runs)
				{
					return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Non è il tuo turno.", "It is not your turn."));
				}
				if (actorCombatant.ActionSpent is not null && !runs)
				{
					return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "L'azione di questo turno è già stata usata.", "The action of this turn was already used."));
				}
				actorCombatant.ActionSpent = TableCombat.SpentOther;
			}
			else if (SpendForAttack(fight, actorCombatant, runs, italian, dto.ActionAttacks, target.Id) is { } refused)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: refused);
			}

			//	The rolls: against a DC (the other side's save, or the escape's check), or a contest the actor wins only above
			var actorDie = RandomNumberGenerator.GetInt32(1, 21);
			var otherDie = RandomNumberGenerator.GetInt32(1, 21);
			bool success;
			int total;
			var dice = new List<RollDieDto>();
			if (dto.Dc is { } dc)
			{
				if (kind == "escape")
				{
					total = actorDie + dto.ActorBonus;
					success = total >= dc;
					dice.Add(new RollDieDto(20, actorDie, false));
				}
				else
				{
					total = otherDie + dto.OtherBonus;
					success = total < dc;
					dice.Add(new RollDieDto(20, otherDie, false));
				}
			}
			else
			{
				total = actorDie + dto.ActorBonus;
				success = total > otherDie + dto.OtherBonus;
				dice.Add(new RollDieDto(20, actorDie, false));
				dice.Add(new RollDieDto(20, otherDie, true));
			}

			string outcome;
			if (!success)
			{
				outcome = kind == "escape" ? T(italian, "Non si libera", "Fails to escape") : T(italian, "Resiste", "Resists");
			}
			else
			{
				switch (kind)
				{
					case "grapple":
						targetCombatant.GrappledBy = actorCombatant.Id;
						SetCondition(target, targetCombatant, characters, "grappled", true);
						outcome = T(italian, "Afferrato", "Grappled");
						break;
					case "prone":
						SetCondition(target, targetCombatant, characters, "prone", true);
						outcome = T(italian, "Prono", "Prone");
						break;
					case "push":
						//	One cell straight away from the actor, when it is free and on the map
						var (dx, dy) = (Math.Sign(target.X - actor.X), Math.Sign(target.Y - actor.Y));
						var (nx, ny) = (target.X + dx, target.Y + dy);
						var blocked = MapTerrain.Read(map.Terrain).GetValueOrDefault((nx, ny)) is TerrainKind.Wall or TerrainKind.ThreeQuarterCover
							|| map.Tokens.Any(t => t.Id != target.Id && t.Kind != TokenKind.Prop && t.X == nx && t.Y == ny);
						if ((dx != 0 || dy != 0) && OnMap(map, nx, ny, target.Size) && !blocked)
						{
							target.X = nx;
							target.Y = ny;
							target.UpdatedAt = DateTimeOffset.UtcNow;
							outcome = T(italian, "Spinto via di 1,5 m", "Pushed 5 feet away");
						}
						else
						{
							outcome = T(italian, "Non c'è spazio per spingerlo", "No room to push it");
						}
						break;
					default:
						actorCombatant.GrappledBy = null;
						SetCondition(actor, actorCombatant, characters, "grappled", false);
						outcome = T(italian, "Si libera", "Escapes");
						break;
				}
			}
			await ReleaseGrapplesAsync(map, fight);

			var name = kind switch
			{
				"grapple" => T(italian, "Lotta", "Grapple"),
				"escape" => T(italian, "Liberarsi", "Escape"),
				_ => T(italian, "Spinta", "Shove")
			};
			var colors = await CampaignAccess.EnsureColorsAsync(_context, campaignId);
			var characterName = characters.FirstOrDefault(c => c.Id == actor.CharacterId)?.Name;
			_context.CampaignRolls.Add(new CampaignRoll
			{
				CampaignId = campaignId,
				UserId = UserId,
				CharacterId = actor.CharacterId,
				CharacterName = characterName is null ? null : Cut(characterName, 100),
				Roller = Cut(characterName ?? (runs ? (role == CampaignRole.Master ? "Master" : "Co-master") : actor.Label), 100),
				Color = colors.GetValueOrDefault(UserId, PlayerColors.Master),
				Label = Cut($"{actor.Label} → {target.Label}: {name}", 120),
				Expression = dto.Dc is { } shown ? T(italian, $"CD {shown}", $"DC {shown}") : "1d20",
				Dice = JsonSerializer.Serialize(dice, GearJson),
				Modifier = dto.Dc is null || kind == "escape" ? dto.ActorBonus : dto.OtherBonus,
				Total = total,
				Note = Cut(outcome, 200),
				Hidden = runs && actor.Hidden
			});
			Save(fight, fight.Combatants);
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return Ok(new MapAttackResultDto(success, false, dice, dto.Dc is null || kind == "escape" ? dto.ActorBonus : dto.OtherBonus, total, null, new List<RollDieDto>(), outcome));
		}

		// ===== Resistances, immunities, vulnerabilities =====

		//	A target's defenses: a character's kept with its sheet, a monster's from its statblock (the English texts, whose
		//	wording is the steadiest)
		private async Task<DamageDefenses> DefensesOfAsync(CampaignToken target, EncounterCombatant? combatant, List<Character> characters)
		{
			if ((target.CharacterId ?? target.SheetCharacterId) is { } characterId)
			{
				var defenses = characters.FirstOrDefault(c => c.Id == characterId)?.Defenses
					?? await _context.Characters.AsNoTracking().Where(c => c.Id == characterId).Select(c => c.Defenses).FirstOrDefaultAsync();
				return DamageDefenses.Read(defenses);
			}
			if ((target.MonsterId ?? combatant?.MonsterId) is { } monsterId)
			{
				var lines = await _context.Set<MonsterTranslation>().AsNoTracking()
					.Where(t => t.MonsterId == monsterId)
					.OrderBy(t => t.Language == LanguageCode.En ? 0 : 1)
					.Select(t => new { t.DamageVulnerabilities, t.DamageResistances, t.DamageImmunities })
					.FirstOrDefaultAsync();
				return lines is null ? DamageDefenses.None : DamageDefenses.FromStatblock(lines.DamageVulnerabilities, lines.DamageResistances, lines.DamageImmunities);
			}
			return DamageDefenses.None;
		}

		private static string? DefenseNote(string? why, bool italian) => why switch
		{
			"immune" => T(italian, "immune", "immune"),
			"resist" => T(italian, "resistenza: dimezzati", "resistance: halved"),
			"vulnerable" => T(italian, "vulnerabilità: raddoppiati", "vulnerability: doubled"),
			_ => null
		};

		// ===== Saving throws asked by a spell =====

		public static List<MapSaveCall> ReadSaves(string? json)
		{
			try
			{
				return string.IsNullOrWhiteSpace(json) ? new() : JsonSerializer.Deserialize<List<MapSaveCall>>(json, GearJson) ?? new();
			}
			catch (JsonException)
			{
				return new();
			}
		}

		private static void WriteSaves(CampaignMap map, List<MapSaveCall> calls) =>
			map.SaveCalls = calls.Count == 0 ? null : JsonSerializer.Serialize(calls.TakeLast(MapSaveRules.MaxCalls).ToList(), GearJson);

		private static string AbilityName(int ability, bool italian) => ability switch
		{
			1 => T(italian, "Forza", "Strength"),
			2 => T(italian, "Destrezza", "Dexterity"),
			3 => T(italian, "Costituzione", "Constitution"),
			4 => T(italian, "Intelligenza", "Intelligence"),
			5 => T(italian, "Saggezza", "Wisdom"),
			_ => T(italian, "Carisma", "Charisma")
		};

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/saves — a spell cast at the table that forces saves: whoever
		//	controls the caster (a master any token). The damage is rolled once for every target and goes to the log with
		//	the save to make; the targets wait for their rolls on every screen of the table
		[HttpPost("{mapId:guid}/saves")]
		public async Task<ActionResult<MapSaveCallDto>> CallSaves(Guid campaignId, Guid mapId, [FromBody] CallSavesDto dto, [FromQuery] LanguageCode? lang)
		{
			var italian = lang != LanguageCode.En;
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var caster = map?.Tokens.FirstOrDefault(t => t.Id == dto.CasterId);
			if (map is null || role is null || caster is null)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role.Value);
			if (!runs && !await ControlsAsync(caster))
			{
				return Forbid();
			}
			var spell = (dto.Spell ?? string.Empty).Trim();
			var damageText = string.IsNullOrWhiteSpace(dto.Damage) ? null : dto.Damage.Replace(" ", string.Empty).Replace('−', '-');
			DiceNotation.Parsed? damageDice = null;
			var flat = 0;
			var targets = dto.TargetIds.Distinct().Select(id => map.Tokens.FirstOrDefault(t => t.Id == id)).ToList();
			if (spell.Length is 0 or > 60 || dto.Ability is < 1 or > 6 || dto.Dc is < 1 or > 40 || (dto.DamageType?.Length ?? 0) > 40 || dto.Empowered is < 0 or > 10
				|| targets.Count is 0 or > MapSaveRules.MaxTargets || targets.Any(t => t is null || t.Kind == TokenKind.Prop || (!runs && t.Hidden))
				|| (damageText is not null && !TryDamage(damageText, out damageDice, out flat)))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid saving throws.");
			}

			//	The damage, once for every target; Empowered Spell rolls the lowest dice again
			int? damage = null;
			var rolled = new List<RollDieDto>();
			if (damageText is not null)
			{
				if (damageDice is not null)
				{
					var (dice, sum) = DiceNotation.Roll(damageDice, sides => RandomNumberGenerator.GetInt32(1, sides + 1));
					var kept = dice.Select(d => (d.Sides, d.Value, d.Dropped)).ToList();
					foreach (var i in kept.Select((d, i) => (d, i)).Where(x => !x.d.Dropped).OrderBy(x => x.d.Value).Take(dto.Empowered).Select(x => x.i).ToList())
					{
						var again = RandomNumberGenerator.GetInt32(1, kept[i].Sides + 1);
						sum += again - kept[i].Value;
						kept[i] = (kept[i].Sides, again, false);
					}
					rolled = kept.Select(d => new RollDieDto(d.Sides, d.Value, d.Dropped)).ToList();
					damage = Math.Max(0, sum);
				}
				else
				{
					damage = Math.Max(0, flat);
				}
			}

			var call = new MapSaveCall
			{
				CasterTokenId = caster.Id,
				Caster = Cut(caster.Label, 60),
				Spell = Cut(spell, 60),
				Ability = dto.Ability,
				Dc = dto.Dc,
				Damage = damage,
				DamageType = string.IsNullOrWhiteSpace(dto.DamageType) ? null : Cut(dto.DamageType.Trim(), 40),
				Half = dto.Half,
				CasterHidden = runs && caster.Hidden,
				Targets = targets.Select(t => new MapSaveTarget
				{
					TokenId = t!.Id,
					Label = Cut(t.Label, 60),
					Careful = dto.Careful.Contains(t.Id),
					Disadvantage = dto.Heightened == t.Id
				}).ToList()
			};
			var calls = ReadSaves(map.SaveCalls);
			calls.Add(call);
			WriteSaves(map, calls);

			//	The log: the damage rolled and the save the targets make (the hidden ones named only to the masters)
			var save = T(italian, $"TS {AbilityName(dto.Ability, true)} CD {dto.Dc}", $"{AbilityName(dto.Ability, false)} save DC {dto.Dc}");
			var named = string.Join(", ", targets.Where(t => !t!.Hidden).Select(t => t!.Label));
			var colors = await CampaignAccess.EnsureColorsAsync(_context, campaignId);
			var characterName = caster.CharacterId is { } casterCharacter
				? await _context.Characters.AsNoTracking().Where(c => c.Id == casterCharacter).Select(c => c.Name).FirstOrDefaultAsync() : null;
			var roller = characterName ?? (runs ? (role == CampaignRole.Master ? "Master" : "Co-master") : caster.Label);
			_context.CampaignRolls.Add(new CampaignRoll
			{
				CampaignId = campaignId,
				UserId = UserId,
				CharacterId = caster.CharacterId,
				CharacterName = characterName is null ? null : Cut(characterName, 100),
				Roller = Cut(roller, 100),
				Color = colors.GetValueOrDefault(UserId, PlayerColors.Master),
				Label = Cut($"{caster.Label}: {spell} · {save}", 120),
				Expression = damageText ?? string.Empty,
				Dice = JsonSerializer.Serialize(rolled, GearJson),
				Modifier = damageDice?.Modifier ?? 0,
				Total = damage ?? 0,
				Note = Cut(T(italian,
					$"{(damage is { } d ? $"{d} danni{(call.DamageType is { } dt ? " " + dt : string.Empty)}{(dto.Half ? ", metà se superato" : string.Empty)} · " : string.Empty)}{(named.Length > 0 ? named : "bersagli nascosti")}",
					$"{(damage is { } d2 ? $"{d2}{(call.DamageType is { } dt2 ? " " + dt2 : string.Empty)} damage{(dto.Half ? ", half on a success" : string.Empty)} · " : string.Empty)}{(named.Length > 0 ? named : "hidden targets")}"), 200),
				Hidden = runs && caster.Hidden
			});
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return Ok(SavesOf(map, true).First(c => c.Id == call.Id));
		}

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/saves/{callId}/targets/{tokenId} — a target's save: rolled here
		//	with its bonus (by a master, or by whoever controls the target), or told as made or failed by a master; the
		//	damage goes on the target (half or none on a success)
		[HttpPost("{mapId:guid}/saves/{callId:guid}/targets/{tokenId:guid}")]
		public async Task<ActionResult<MapSaveCallDto>> ResolveSave(Guid campaignId, Guid mapId, Guid callId, Guid tokenId, [FromBody] ResolveSaveDto dto, [FromQuery] LanguageCode? lang)
		{
			var italian = lang != LanguageCode.En;
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			var calls = ReadSaves(map?.SaveCalls);
			var call = calls.FirstOrDefault(c => c.Id == callId);
			var target = call?.Targets.FirstOrDefault(t => t.TokenId == tokenId);
			if (map is null || role is null || token is null || call is null || target is null)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role.Value);
			if (!runs && (dto.Saved is not null || !await ControlsAsync(token)))
			{
				return Forbid();
			}
			if (target.Saved is not null)
			{
				return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Questo tiro salvezza è già stato fatto.", "This save was already made."));
			}
			if (dto.Bonus is < -10 or > 30)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid bonus.");
			}

			//	The roll: a d20 (two with disadvantage, the lower kept) and the bonus; a careful target succeeds by itself
			var dice = new List<RollDieDto>();
			int total;
			bool saved;
			if (target.Careful)
			{
				saved = true;
				total = 0;
			}
			else if (dto.Saved is { } told)
			{
				saved = told;
				total = 0;
			}
			else
			{
				var first = RandomNumberGenerator.GetInt32(1, 21);
				var second = target.Disadvantage ? RandomNumberGenerator.GetInt32(1, 21) : 0;
				var keepFirst = !target.Disadvantage || first <= second;
				dice.Add(new RollDieDto(20, first, !keepFirst));
				if (target.Disadvantage)
				{
					dice.Add(new RollDieDto(20, second, keepFirst));
				}
				total = (keepFirst ? first : second) + dto.Bonus;
				saved = total >= call.Dc;
				target.Roll = total;
			}
			target.Saved = saved;
			target.Dealt = MapSaveRules.Dealt(call.Damage, saved, call.Half, target.Careful);

			//	The damage on the target, as an attack's, after its defenses (a spell is magical)
			var fight = await FightAsync(map, track: true);
			var combatant = token.CombatantId is { } cid ? fight?.Combatants.FirstOrDefault(c => c.Id == cid) : null;
			var characterIds = new[] { token.CharacterId, token.SheetCharacterId }.OfType<Guid>().ToList();
			var characters = await _context.Characters.Where(c => characterIds.Contains(c.Id)).ToListAsync();
			string? defense = null;
			if (target.Dealt is { } before && before > 0 && DamageDefenses.TypeOf(call.DamageType) is { } savedType)
			{
				var (after, why) = (await DefensesOfAsync(token, combatant, characters)).Apply(before, savedType, magical: true);
				target.Dealt = after;
				defense = DefenseNote(why, italian);
			}
			var down = false;
			int? concentration = null;
			if (target.Dealt is { } dealt && dealt > 0)
			{
				if (token.MonsterId is { } monsterId && token.CharacterId is null && combatant is null && token.MaxHp is null)
				{
					var hp = await _context.Monsters.AsNoTracking().Where(m => m.Id == monsterId).Select(m => m.HitPoints).FirstOrDefaultAsync();
					if (hp > 0)
					{
						token.MaxHp = hp;
					}
				}
				down = ApplyDamage(token, combatant, characters, dealt, false, null, out concentration);
			}
			var outcome = (saved ? T(italian, "superato", "made") : T(italian, "fallito", "failed"))
				+ (target.Careful ? T(italian, " (protetto)", " (protected)") : string.Empty)
				+ (defense is null ? string.Empty : $" · {defense}")
				+ (target.Dealt is { } hurt ? T(italian, $" · {hurt} danni{(call.DamageType is { } dt ? " " + dt : string.Empty)}", $" · {hurt}{(call.DamageType is { } dt2 ? " " + dt2 : string.Empty)} damage") : string.Empty)
				+ (down ? T(italian, " · a terra", " · down") : string.Empty)
				+ (concentration is { } cdc ? T(italian, $" · TS Costituzione CD {cdc} per la concentrazione", $" · Constitution save DC {cdc} to keep concentration") : string.Empty);

			var colors = await CampaignAccess.EnsureColorsAsync(_context, campaignId);
			var characterName = characters.FirstOrDefault(c => c.Id == token.CharacterId)?.Name;
			_context.CampaignRolls.Add(new CampaignRoll
			{
				CampaignId = campaignId,
				UserId = UserId,
				CharacterId = token.CharacterId,
				CharacterName = characterName is null ? null : Cut(characterName, 100),
				Roller = Cut(characterName ?? (runs ? (role == CampaignRole.Master ? "Master" : "Co-master") : token.Label), 100),
				Color = colors.GetValueOrDefault(UserId, PlayerColors.Master),
				Label = Cut($"{token.Label}: {T(italian, $"TS {AbilityName(call.Ability, true)} CD {call.Dc}", $"{AbilityName(call.Ability, false)} save DC {call.Dc}")} · {call.Spell}", 120),
				Expression = dice.Count == 0 ? string.Empty : dto.Bonus == 0 ? "1d20" : $"1d20{(dto.Bonus > 0 ? "+" : string.Empty)}{dto.Bonus}",
				Dice = JsonSerializer.Serialize(dice, GearJson),
				Modifier = dice.Count == 0 ? 0 : dto.Bonus,
				Total = total,
				Note = Cut(outcome, 200),
				Hidden = runs && token.Hidden
			});

			//	Done for every target: the call goes
			if (call.Targets.All(t => t.Saved is not null))
			{
				calls.Remove(call);
			}
			WriteSaves(map, calls);
			if (fight is not null)
			{
				await ReleaseGrapplesAsync(map, fight);
				Save(fight, fight.Combatants);
			}
			token.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			map.StrikeTokenId = token.Id;
			map.StrikeKind = target.Dealt is > 0 ? 1 : 0;
			map.StrikeDamage = target.Dealt is > 0 ? target.Dealt : null;
			map.StrikeAt = map.UpdatedAt;
			await _context.SaveChangesAsync();
			return Ok(new MapSaveCallDto(call.Id, call.CasterTokenId, call.Caster, call.Spell, call.Ability, call.Dc, call.Damage, call.DamageType, call.Half, call.At,
				call.Targets.Select(t => new MapSaveTargetDto(t.TokenId, t.Label, t.Careful, t.Disadvantage, t.Roll, t.Saved, t.Dealt)).ToList()));
		}

		//	DELETE: api/campaigns/{campaignId}/maps/{mapId}/saves/{callId} — a master lets the saves still waiting go
		[HttpDelete("{mapId:guid}/saves/{callId:guid}")]
		public async Task<IActionResult> DismissSaves(Guid campaignId, Guid mapId, Guid callId)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: false);
			if (map is null || role is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			var calls = ReadSaves(map.SaveCalls);
			if (calls.RemoveAll(c => c.Id == callId) == 0)
			{
				return NotFound();
			}
			WriteSaves(map, calls);
			map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		// ===== Dropped weapons =====

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}/drop — a weapon falls to the ground (a disarm, or
		//	let go): out of a character's inventory, or a statblock attack lost; a token of it lies next to its owner
		[HttpPost("{mapId:guid}/tokens/{tokenId:guid}/drop")]
		public async Task<ActionResult<MapTokenDto>> DropItem(Guid campaignId, Guid mapId, Guid tokenId, [FromBody] DropItemDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			if (map is null || role is null || token is null)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role.Value);
			if (!runs && !await ControlsAsync(token))
			{
				return Forbid();
			}
			if (map.Tokens.Count >= MapRules.MaxTokens)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MapRules.MaxTokens} tokens per map.");
			}
			var label = (dto.Name ?? string.Empty).Trim();
			TokenItem item;
			if (token.CharacterId is { } characterId)
			{
				var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == characterId);
				var sheet = character is null ? null : CharactersController.ReadSheet(character.Sheet);
				var entry = sheet?.Inventory.FirstOrDefault(i => i.Id == dto.InventoryId);
				if (character is null || sheet is null || entry is null)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The item is not in the inventory.");
				}
				var dropped = JsonSerializer.Deserialize<InventoryItem>(JsonSerializer.Serialize(entry, CharactersController.Json), CharactersController.Json)!;
				dropped.Quantity = 1;
				dropped.Equipped = false;
				dropped.Attuned = false;
				if (entry.Quantity > 1)
				{
					entry.Quantity--;
				}
				else
				{
					sheet.Inventory.Remove(entry);
				}
				character.Sheet = JsonSerializer.Serialize(sheet, CharactersController.Json);
				character.UpdatedAt = DateTimeOffset.UtcNow;
				character.UpdatedById = UserId;
				if (label.Length == 0)
				{
					label = entry.Name ?? "?";
				}
				item = new TokenItem { Name = Cut(label, 100), EquipmentId = entry.EquipmentId, Entry = JsonSerializer.Serialize(dropped, CharactersController.Json) };
			}
			else
			{
				var attack = (dto.Attack ?? string.Empty).Trim();
				if (attack.Length is 0 or > 100)
				{
					return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Which attack's weapon?");
				}
				var gear = ReadGear(token.Gear);
				if (!gear.Disarmed.Contains(attack))
				{
					gear.Disarmed.Add(attack);
				}
				WriteGear(token, gear);
				item = new TokenItem { Name = Cut(label.Length > 0 ? label : attack, 100), Attack = attack };
			}

			//	Next to its owner, on a cell where nothing else lies
			var (x, y) = NextTo(map, token);
			var lying = new CampaignToken
			{
				MapId = map.Id,
				Kind = TokenKind.Prop,
				PropType = PropType.Item,
				Label = item.Name,
				Color = "#9ca3af",
				X = x,
				Y = y,
				Size = 1,
				Layer = TokenLayer.Below,
				Hidden = token.Hidden,
				PlayersInteract = true
			};
			WriteGear(lying, new TokenGear { Items = new() { item } });
			_context.CampaignTokens.Add(lying);
			token.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return Ok(ToDto(lying, runs));
		}

		private static (int X, int Y) NextTo(CampaignMap map, CampaignToken token)
		{
			//	Free: no other token on it (an item on the ground is seen and clicked only there)
			var taken = map.Tokens.Where(t => t.Id != token.Id)
				.SelectMany(t => Enumerable.Range(0, map.GridType == GridType.Square ? t.Size : 1)
					.SelectMany(dx => Enumerable.Range(0, map.GridType == GridType.Square ? t.Size : 1).Select(dy => (t.X + dx, t.Y + dy))))
				.ToHashSet();
			for (var ring = 1; ring <= 3; ring++)
			{
				for (var dy = -ring; dy <= ring + token.Size - 1; dy++)
				{
					for (var dx = -ring; dx <= ring + token.Size - 1; dx++)
					{
						var (x, y) = (token.X + dx, token.Y + dy);
						if (TableCombat.Gap(map.GridType, token.X, token.Y, token.Size, x, y, 1) != ring || taken.Contains((x, y))
							|| !MapGeometry.Inside(map.GridType, map.GridSize, map.GridOffsetX, map.GridOffsetY, x, y, 1, map.Width, map.Height))
						{
							continue;
						}
						return (x, y);
					}
				}
			}
			return (token.X, token.Y);
		}

		// ===== Taking things: from the ground, from a beaten creature =====

		//	POST: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}/take — a token next to it takes an item (or the
		//	coins) of a dropped-item token or of a creature that is down; in a fight, on its turn, for its action
		[HttpPost("{mapId:guid}/tokens/{tokenId:guid}/take")]
		public async Task<IActionResult> TakeItem(Guid campaignId, Guid mapId, Guid tokenId, [FromBody] TakeItemDto dto, [FromQuery] LanguageCode? lang)
		{
			var italian = lang != LanguageCode.En;
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var source = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			var taker = map?.Tokens.FirstOrDefault(t => t.Id == dto.ByTokenId);
			if (map is null || role is null || source is null || taker is null || source.Id == taker.Id)
			{
				return NotFound();
			}
			var runs = CampaignRules.RunsTheTable(role.Value);
			if (!runs && (!await ControlsAsync(taker) || source.Hidden))
			{
				return Forbid();
			}
			var fight = await FightAsync(map, track: true);
			var sourceCombatant = source.CombatantId is { } sid ? fight?.Combatants.FirstOrDefault(c => c.Id == sid) : null;
			var gear = ReadGear(source.Gear);
			var lying = source.PropType == PropType.Item;
			if (!runs)
			{
				var down = sourceCombatant is not null ? sourceCombatant.MaxHp > 0 && sourceCombatant.Hp <= 0 : source.MaxHp is > 0 && source.Hp is <= 0;
				if (!lying && (source.CharacterId is not null || !down))
				{
					return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Si prende il bottino solo da una creatura a terra.", "Loot is taken only from a creature that is down."));
				}
				if (TableCombat.Gap(map.GridType, taker.X, taker.Y, taker.Size, source.X, source.Y, source.Size) > 1)
				{
					return Problem(statusCode: StatusCodes.Status409Conflict, title: T(italian, "Bisogna essere accanto per prenderlo.", "It must be next to you to take it."));
				}
			}
			if ((dto.Index < 0 && gear.Coins <= 0) || dto.Index >= gear.Items.Count || dto.Index < -1)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Nothing there.");
			}

			//	The action of the turn
			var takerCombatant = taker.CombatantId is { } cid ? fight?.Combatants.FirstOrDefault(c => c.Id == cid) : null;
			if (fight is not null && takerCombatant is not null)
			{
				var current = fight.Encounter.CurrentId == takerCombatant.Id;
				if (!runs && (!current || takerCombatant.ActionSpent is not null))
				{
					return Problem(statusCode: StatusCodes.Status409Conflict, title: current
						? T(italian, "L'azione di questo turno è già stata usata.", "The action of this turn was already used.")
						: T(italian, "Si raccoglie solo nel proprio turno.", "Things are picked up only on one's own turn."));
				}
				if (current)
				{
					takerCombatant.ActionSpent = TableCombat.SpentOther;
					Save(fight, fight.Combatants);
				}
			}

			var coins = dto.Index < 0 ? gear.Coins : 0;
			var item = dto.Index >= 0 ? gear.Items[dto.Index] : null;
			if (taker.CharacterId is { } characterId)
			{
				var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == characterId);
				if (character is null)
				{
					return NotFound();
				}
				var sheet = CharactersController.ReadSheet(character.Sheet);
				if (coins > 0)
				{
					sheet.Coins.Gp += coins;
				}
				if (item is not null)
				{
					GiveTo(sheet, item, dto.Equip);
				}
				character.Sheet = JsonSerializer.Serialize(sheet, CharactersController.Json);
				character.UpdatedAt = DateTimeOffset.UtcNow;
				character.UpdatedById = UserId;
			}
			else
			{
				var mine = ReadGear(taker.Gear);
				mine.Coins += coins;
				if (item is not null)
				{
					if (dto.Equip && item.Attack is { } attack && mine.Disarmed.Remove(attack))
					{
						//	Its own weapon back in hand: the attack again
					}
					else if (mine.Items.Count < TokenGear.MaxItems)
					{
						mine.Items.Add(item);
					}
				}
				WriteGear(taker, mine);
			}
			if (item is not null)
			{
				gear.Items.Remove(item);
			}
			else
			{
				gear.Coins = 0;
			}
			if (lying && gear.Items.Count == 0 && gear.Coins == 0)
			{
				_context.CampaignTokens.Remove(source);
			}
			else
			{
				WriteGear(source, gear);
			}
			taker.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	Into a character's inventory: the entry as it was dropped, or one more of the same compendium item
		private static void GiveTo(CharacterSheetState sheet, TokenItem item, bool equip)
		{
			InventoryItem? entry = null;
			if (item.Entry is { } json)
			{
				try
				{
					entry = JsonSerializer.Deserialize<InventoryItem>(json, CharactersController.Json);
				}
				catch (JsonException)
				{
					entry = null;
				}
			}
			if (entry is not null)
			{
				entry.Id = Guid.NewGuid();
				entry.Equipped = equip;
				entry.Attuned = false;
				var same = !equip && entry.Magic is null && entry.EquipmentId is { } eid ? sheet.Inventory.FirstOrDefault(i => i.EquipmentId == eid && i.Magic is null && !i.Equipped) : null;
				if (same is not null)
				{
					same.Quantity += Math.Max(1, entry.Quantity);
				}
				else
				{
					sheet.Inventory.Add(entry);
				}
				return;
			}
			var existing = !equip && item.EquipmentId is { } id ? sheet.Inventory.FirstOrDefault(i => i.EquipmentId == id && i.Magic is null && !i.Equipped) : null;
			if (existing is not null)
			{
				existing.Quantity += Math.Max(1, item.Quantity);
			}
			else
			{
				sheet.Inventory.Add(new InventoryItem
				{
					EquipmentId = item.EquipmentId,
					Name = item.EquipmentId is null ? item.Name : null,
					Quantity = Math.Max(1, item.Quantity),
					Equipped = equip
				});
			}
		}

		//	PUT: api/campaigns/{campaignId}/maps/{mapId}/tokens/{tokenId}/loot — the masters fill what a creature carries
		[HttpPut("{mapId:guid}/tokens/{tokenId:guid}/loot")]
		public async Task<IActionResult> SaveLoot(Guid campaignId, Guid mapId, Guid tokenId, [FromBody] SaveLootDto dto)
		{
			var (map, role) = await LoadAsync(campaignId, mapId, withTokens: true);
			var token = map?.Tokens.FirstOrDefault(t => t.Id == tokenId);
			if (map is null || role is null || token is null)
			{
				return NotFound();
			}
			if (!CampaignRules.RunsTheTable(role.Value))
			{
				return Forbid();
			}
			if (token.CharacterId is not null || dto.Items.Count > TokenGear.MaxItems || dto.Coins is < 0 or > 1_000_000
				|| dto.Items.Any(i => string.IsNullOrWhiteSpace(i.Name) || i.Name.Trim().Length > 100 || i.Quantity is < 1 or > 999))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid loot.");
			}
			var gear = ReadGear(token.Gear);
			var before = gear.Items;
			gear.Items = dto.Items.Select((i, index) =>
			{
				var name = i.Name.Trim();
				//	The same item as before keeps what it was (an inventory entry, the attack it belongs to)
				var kept = index < before.Count && before[index].Name == name ? before[index] : null;
				return new TokenItem { Name = name, Quantity = i.Quantity, EquipmentId = i.EquipmentId ?? kept?.EquipmentId, Entry = kept?.Entry, Attack = kept?.Attack };
			}).ToList();
			gear.Coins = dto.Coins;
			WriteGear(token, gear);
			token.UpdatedAt = map.UpdatedAt = DateTimeOffset.UtcNow;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		//	What the account sees of what a token carries: an item on the ground everyone; a creature's loot the masters
		//	and whoever controls it, the others once it is down; the attacks it lost whoever knows its numbers
		private static TokenGearDto? GearOf(CampaignToken t, bool runs, bool controls, bool down)
		{
			var gear = ReadGear(t.Gear);
			if (gear.IsEmpty)
			{
				return null;
			}
			var seesItems = t.PropType == PropType.Item || runs || controls || down;
			return new TokenGearDto(
				seesItems ? gear.Items.Select((i, index) => new TokenItemDto(index, i.Name, i.Quantity, i.EquipmentId)).ToList() : new List<TokenItemDto>(),
				seesItems ? gear.Coins : 0,
				runs || controls ? gear.Disarmed.ToList() : new List<string>());
		}
	}
}
