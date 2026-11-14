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

			//	How far: the nearest cells of the two tokens
			var gap = TableCombat.Gap(map.GridType, attacker.X, attacker.Y, attacker.Size, target.X, target.Y, target.Size);
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
			if (fight is not null && attackerCombatant is not null && SpendForAttack(fight, attackerCombatant, runs, italian, dto.ActionAttacks, target.Id) is { } refused)
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
				(attacker.X, attacker.Y, attacker.Size), (target.X, target.Y, target.Size));
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
