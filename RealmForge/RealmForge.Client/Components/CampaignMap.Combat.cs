using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RealmForge.Client.Localization;
using RealmForge.Client.Services;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	Fighting on the map: an attack aimed at a token in reach (the server rolls it against the armour class and applies
	///	the damage), a spell cast from the quick sheet that spends its slot and then places its area within range, weapons
	///	dropped on the ground and picked up, the loot of a creature filled by the masters and taken once it is down.
	///	</summary>
	public partial class CampaignMap
	{
		[Inject] private SpellDataService SpellService { get; set; } = default!;

		// ===== Aiming an attack =====

		//	What is aimed: an attack (a weapon, a spell attack) or a spell with a saving throw (its ability and DC)
		private sealed record Aim(Guid AttackerId, SheetLine Attack, string? Save = null, int Dc = 0, bool Half = false, SpellInfo? Info = null, string? Maneuver = null);

		private Aim? aim;
		private int aimMode;
		private string? aimCondition;

		//	Where a token stands against the attack being aimed: in reach, in reach with disadvantage, out of it
		private string? AimClass(MapTokenDto t)
		{
			if (aim is null || tokens.FirstOrDefault(k => k.Id == aim.AttackerId) is not { } attacker)
			{
				return null;
			}
			if (t.Id == attacker.Id)
			{
				return "aim-self";
			}
			if (!IsTarget(t))
			{
				return "aim-none";
			}
			var (can, far) = (aim.Attack.Reach ?? AttackReach.Melee).At(GapOf(attacker, t));
			return !can ? "aim-out" : far ? "aim-far" : "aim-in";
		}

		private static bool IsTarget(MapTokenDto t) => t.Kind is TokenKind.Character or TokenKind.Npc or TokenKind.Monster or TokenKind.Marker && !t.Hidden;

		private int GapOf(MapTokenDto a, MapTokenDto b) => TableCombat.Gap(gridType, a.X, a.Y, a.Size, b.X, b.Y, b.Size);

		//	A target can be aimed at: by a master always, by a player in a fight
		private bool CanAim(MapTokenDto t) => Table && map is not null && tokens.Any(k => k.Id == t.Id) && CanRoll(t) && (RunsTheTable || combat is not null) && !KnockedOut(t);

		//	An enemy: a token no player controls, whose hits put damage and conditions on the target by themselves (a
		//	character's attack is only rolled and told)
		private bool Hurts(MapTokenDto t) => RunsTheTable && t.CharacterId is null && (t.ControlledBy?.Count ?? 0) == 0;

		private bool AimHurts => aim is { } a && tokens.FirstOrDefault(t => t.Id == a.AttackerId) is { } attacker && Hurts(attacker);

		private async Task StartAimAsync(MapTokenDto t, SheetLine attack, string? save = null, int dc = 0, bool half = false, SpellInfo? info = null)
		{
			CancelCast();
			aim = new Aim(t.Id, attack, save, dc, half, info);
			aimMode = 0;
			//	The condition its text gives on a hit, ready to apply (the master can take it away); only an enemy's
			aimCondition = Hurts(t) ? attack.Condition : null;
			aimNote = null;
			CloseToolbar();
			await SetToolAsync("select");
		}

		private void CancelAim()
		{
			aim = null;
			aimNote = null;
		}

		//	The reach in the language of the map: "1,5 m", "24/96 m"
		private string ReachText(AttackReach reach)
		{
			var per = UiText.VttPerCell(Lang);
			string Of(int cells) => (cells * per).ToString("0.#", System.Globalization.CultureInfo.GetCultureInfo(Lang == LanguageCode.It ? "it-IT" : "en-GB"));
			var parts = new List<string>();
			if (reach.Reach > 0)
			{
				parts.Add($"{Of(reach.Reach)} {UiText.VttUnit(Lang)}");
			}
			if (reach.Range > 0)
			{
				parts.Add(reach.LongRange > reach.Range ? $"{Of(reach.Range)}/{Of(reach.LongRange)} {UiText.VttUnit(Lang)}" : $"{Of(reach.Range)} {UiText.VttUnit(Lang)}");
			}
			return string.Join(" · ", parts);
		}

		//	What the last attack did (or why it could not be made), shown in the aiming bar
		private string? aimNote;

		//	A click on a token while aiming: the attack, if it is in reach
		private async Task<bool> AimAtAsync(Guid targetId)
		{
			if (aim is not { } current || map is null)
			{
				return false;
			}
			var attacker = tokens.FirstOrDefault(k => k.Id == current.AttackerId);
			var target = tokens.FirstOrDefault(k => k.Id == targetId);
			if (attacker is null || target is null || target.Id == attacker.Id)
			{
				return true;
			}
			//	An attack of opportunity reaches the token where it was (the server measures from there)
			var opportunity = attacker.Turn?.OpportunityOn == target.Id;
			if (!IsTarget(target) || (!opportunity && !(current.Attack.Reach ?? AttackReach.Melee).At(GapOf(attacker, target)).Can))
			{
				aimNote = UiText.VttAimOut(Lang);
				return true;
			}
			if (current.Maneuver is { } maneuver)
			{
				await ManeuverAsync(attacker, target, maneuver == "grapple" ? "grapple" : aimShove);
				return true;
			}
			if (current.Save is { } ability)
			{
				return AimSave(current, attacker, target, ability);
			}
			//	A character's attack waits for its confirmation, with the options it may take (Metamagic on a spell)
			if (attacker.CharacterId is not null)
			{
				pending = new Pending
				{
					Kind = "attack",
					CasterId = attacker.Id,
					Name = current.Attack.Name,
					Aim = current,
					Mode = aimMode,
					Condition = aimCondition,
					Targets = new() { target.Id },
					Damage = current.Attack.DamageDice,
					DamageType = current.Attack.DamageType,
					Info = current.Info
				};
				aim = null;
				aimNote = null;
				StateHasChanged();
				return true;
			}
			return await StrikeAsync(current, attacker, target, aimMode, aimCondition, null);
		}

		//	The attack made: rolled by the server against the armour class, its damage on the target from an enemy
		private async Task<bool> StrikeAsync(Aim current, MapTokenDto attacker, MapTokenDto target, int mode, string? condition, Pending? plan)
		{
			if (map is null)
			{
				return false;
			}
			busy = true;
			//	A shot spends its ammunition first (none left: no shot)
			if (current.Attack.InventoryId is { } weaponId && attacker.CharacterId is not null)
			{
				string? ammoProblem = null;
				var spent = false;
				await ChangeCharacterAsync(attacker, (sheet, computed) =>
				{
					var weapon = computed.Attacks.FirstOrDefault(a => a.InventoryId == weaponId)?.Item;
					if (InventoryRules.AmmunitionOf(weapon) is null)
					{
						return;
					}
					var context = contexts.GetValueOrDefault(attacker.CharacterId!.Value);
					ContextItem? Lookup(InventoryItem item) => item.EquipmentId is { } id ? context?.Items.FirstOrDefault(x => x.Id == id) : null;
					if (InventoryRules.AmmunitionFor(weapon, sheet.Inventory, Lookup) is not { Quantity: > 0 } ammo)
					{
						ammoProblem = UiText.AmmoNone(weapon!.Name, Lang);
						return;
					}
					var left = InventoryRules.Spend(ammo, sheet.Inventory);
					spent = true;
					var name = ammo.EquipmentId is { } aid && context?.Items.FirstOrDefault(x => x.Id == aid) is { } item ? item.Name : ammo.Name ?? string.Empty;
					ammoProblem = left == 0 ? UiText.AmmoLast(name, Lang) : left <= InventoryRules.LowAmmunition ? UiText.AmmoLow(name, left, Lang) : null;
				});
				if (!spent && ammoProblem is not null)
				{
					busy = false;
					aimNote = ammoProblem;
					return true;
				}
				aimNote = ammoProblem;
			}
			var reach = current.Attack.Reach ?? AttackReach.Melee;
			var attack = new MapAttackDto
			{
				AttackerId = attacker.Id,
				TargetId = target.Id,
				Name = current.Attack.Name.Length > 60 ? current.Attack.Name[..60] : current.Attack.Name,
				Bonus = current.Attack.Bonus,
				Damage = plan?.Damage ?? current.Attack.DamageDice,
				DamageType = plan?.Transmute ?? current.Attack.DamageType,
				Reach = reach.Reach,
				Range = reach.Range,
				LongRange = reach.LongRange,
				Mode = mode,
				Condition = condition,
				Spell = current.Attack.Spell,
				//	A spell attack is the whole action; a weapon's, one of the attacks of the Attack action
				ActionAttacks = attacker.CharacterId is null ? null : current.Attack.InventoryId is null && current.Attack.Spell ? 1 : StatsOf(attacker)?.ActionAttacks
			};
			var (result, error) = await Campaigns.AttackAsync(CampaignId, map.Id, attack, Lang);
			//	Seeking Spell: a spell attack that missed rolls its d20 again
			if (result is { Hit: false } && plan?.Meta.Contains("seeking") == true)
			{
				attack.Reroll = true;
				var (again, _) = await Campaigns.AttackAsync(CampaignId, map.Id, attack, Lang);
				if (again is not null)
				{
					result = again with { Text = $"{again.Text} · {UiText.VttMetamagicName("seeking", Lang)}" };
				}
			}
			busy = false;
			if (result is null)
			{
				aimNote = string.IsNullOrEmpty(error) ? UiText.MapSaveFailed(Lang) : error;
				return true;
			}
			var label = $"{current.Attack.Name} → {target.Label}";
			var note = string.Join(" · ", new[] { result.Text, result.ArmorClass is { } ac ? UiText.VttAimArmor(ac, Lang) : null, aimNote }.Where(x => !string.IsNullOrEmpty(x)));
			aim = null;
			aimNote = null;
			message = null;
			if (tray is not null)
			{
				await tray.ShowAsync(new DiceRollResult(label, result.Dice.Select(d => new DieFace(d.Sides, d.Value, d.Dropped)).ToList(), result.Bonus, result.Total, note));
				if (result.Damage is { } dealt && result.DamageDice.Count > 0)
				{
					await tray.ShowAsync(new DiceRollResult(UiText.RollDamage(current.Attack.Name, Lang), result.DamageDice.Select(d => new DieFace(d.Sides, d.Value, d.Dropped)).ToList(),
						dealt - result.DamageDice.Where(d => !d.Dropped).Sum(d => d.Value), dealt, result.Critical ? UiText.RollCritical(Lang) : null));
				}
			}
			if (attacker.CharacterId is { } ownerId)
			{
				InvalidateStats($"c:{ownerId}");
				_ = LoadStatsAsync(attacker);
			}
			if (target.CharacterId is { } targetCharacter)
			{
				charVitals.Remove(targetCharacter);
				hpAfterRest.Remove(targetCharacter);
			}
			await RefreshAsync();
			return true;
		}

		//	A spell with a saving throw at a target: not behind a wall; the caster confirms (with its options), then the
		//	table is asked for the save
		private bool AimSave(Aim current, MapTokenDto caster, MapTokenDto target, string ability)
		{
			if (MapTerrain.Cover(gridType, grid, offsetX, offsetY, terrainCells, ClosedDoors().ToHashSet(),
				(caster.X, caster.Y, caster.Size), (target.X, target.Y, target.Size)) >= MapTerrain.TotalCover)
			{
				aimNote = UiText.VttAimWall(Lang);
				return true;
			}
			pending = new Pending
			{
				Kind = "save",
				CasterId = caster.Id,
				Name = current.Attack.Name,
				Targets = new() { target.Id },
				Ability = MapSaveRules.AbilityOf(ability),
				Dc = current.Dc,
				Damage = current.Attack.DamageDice,
				DamageType = current.Attack.DamageType,
				Half = current.Half,
				Info = current.Info
			};
			aim = null;
			aimNote = null;
			StateHasChanged();
			return true;
		}

		//	The cells a token covers
		private IEnumerable<(int Col, int Row)> Covered(MapTokenDto t)
		{
			if (gridType != GridType.Square)
			{
				yield return (t.X, t.Y);
				yield break;
			}
			for (var dx = 0; dx < t.Size; dx++)
			{
				for (var dy = 0; dy < t.Size; dy++)
				{
					yield return (t.X + dx, t.Y + dy);
				}
			}
		}

		// ===== Weapons on the ground, loot =====

		//	The weapons a token can drop: a character's in hand (from its sheet), a statblock's attacks not yet lost
		private List<(string Name, Guid? InventoryId, string? Attack)> Droppable(MapTokenDto t)
		{
			var sheet = StatsOf(t)?.Sheet;
			if (sheet is null)
			{
				return new();
			}
			if (t.CharacterId is not null)
			{
				return sheet.Attacks.Where(a => a.InventoryId is not null).DistinctBy(a => a.InventoryId).Select(a => (a.Name, a.InventoryId, (string?)null)).ToList();
			}
			var lost = t.Gear?.Disarmed ?? new List<string>();
			return sheet.Attacks.Where(a => !lost.Contains(a.Name)).Select(a => (a.Name, (Guid?)null, (string?)a.Name)).ToList();
		}

		private bool CanDrop(MapTokenDto t) => (RunsTheTable || t.Controlled || CharacterOf(t)?.IsMine == true) && t.PropType is null && (t.CharacterId is not null || t.MonsterId is not null || t.SheetCharacterId is not null);

		private string? gearNote;

		private async Task DropAsync(MapTokenDto t, (string Name, Guid? InventoryId, string? Attack) weapon)
		{
			if (map is null)
			{
				return;
			}
			busy = true;
			var (dropped, error) = await Campaigns.DropItemAsync(CampaignId, map.Id, t.Id, new DropItemDto { InventoryId = weapon.InventoryId, Attack = weapon.Attack, Name = weapon.Name });
			busy = false;
			gearNote = dropped is null ? (string.IsNullOrEmpty(error) ? UiText.MapSaveFailed(Lang) : error) : UiText.VttDropped(weapon.Name, Lang);
			if (dropped is not null && t.CharacterId is { } id)
			{
				InvalidateStats($"c:{id}");
				_ = LoadStatsAsync(t);
			}
			await RefreshAsync();
		}

		//	Who can take something from a token: my tokens next to it (a master's: any creature next to it)
		private List<MapTokenDto> Takers(MapTokenDto source) => tokens
			.Where(k => k.Id != source.Id && k.PropType is null && k.Kind != TokenKind.Marker)
			.Where(k => RunsTheTable ? k.Kind != TokenKind.Prop : k.Controlled || CharacterOf(k)?.IsMine == true)
			.Where(k => GapOf(k, source) <= 1)
			.OrderBy(k => k.CharacterId is null)
			.ToList();

		//	Something to take: an item on the ground, or the loot of a creature that is down (the masters: always)
		private bool HasLoot(MapTokenDto t) => t.Gear is { } gear && (gear.Items.Count > 0 || gear.Coins > 0)
			&& (t.PropType == PropType.Item || RunsTheTable || IsDown(t));

		private static bool IsDown(MapTokenDto t) => t.Health == CombatantHealth.Down || (t.Hp is <= 0 && t.MaxHp is > 0);

		private async Task TakeAsync(MapTokenDto source, MapTokenDto by, int index, bool equip = false)
		{
			if (map is null)
			{
				return;
			}
			busy = true;
			var error = await Campaigns.TakeItemAsync(CampaignId, map.Id, source.Id, by.Id, index, Lang, equip);
			busy = false;
			gearNote = error is null ? (equip ? UiText.VttTakenInHand(by.Label, Lang) : UiText.VttTaken(by.Label, Lang)) : error.Length == 0 ? UiText.MapSaveFailed(Lang) : error;
			if (error is null && source.PropType == PropType.Item && source.Gear?.Items.Count <= 1)
			{
				CloseToolbar();
			}
			if (error is null && by.CharacterId is { } id)
			{
				InvalidateStats($"c:{id}");
				_ = LoadStatsAsync(by);
			}
			await RefreshAsync();
		}

		// ----- An item on the ground: what it is (from the compendium), who is next to it -----

		[Inject] private EquipmentDataService EquipmentService { get; set; } = default!;

		private EquipmentDetailResponseDto? groundInfo;

		//	By compendium id, or by name for a statblock's weapon ("Scimitarra")
		private EquipmentDetailResponseDto? GroundItemOf(TokenItemDto item) =>
			groundItems.TryGetValue(GroundKey(item), out var found) ? found : null;

		private static string GroundKey(TokenItemDto item) => item.EquipmentId is { } id ? id.ToString() : item.Name.Trim().ToLowerInvariant();

		private readonly Dictionary<string, EquipmentDetailResponseDto?> groundItems = new();
		private List<EquipmentResponseDto>? equipmentIndex;

		private async Task LoadGroundItemAsync(MapTokenDto t)
		{
			if (t.Gear?.Items.FirstOrDefault() is not { } item || groundItems.ContainsKey(GroundKey(item)))
			{
				return;
			}
			var key = GroundKey(item);
			groundItems[key] = null;
			try
			{
				var id = item.EquipmentId;
				if (id is null)
				{
					equipmentIndex ??= await EquipmentService.GetEquipmentAsync(Lang);
					id = equipmentIndex.Where(e => string.Equals(e.Name.Trim(), item.Name.Trim(), StringComparison.OrdinalIgnoreCase))
						.OrderByDescending(e => e.Ruleset).Select(e => (Guid?)e.Id).FirstOrDefault();
				}
				if (id is { } found)
				{
					groundItems[key] = await EquipmentService.GetItemAsync(found, Lang);
				}
			}
			catch (Exception)
			{
				//	Its name only
			}
			await InvokeAsync(StateHasChanged);
		}

		//	The nearest of my tokens and how far it is, in the units of the map
		private (MapTokenDto? Token, string Distance) NearestMine(MapTokenDto source)
		{
			var mine = tokens.Where(k => k.Id != source.Id && k.PropType is null && k.Kind != TokenKind.Marker)
				.Where(k => RunsTheTable ? k.Kind != TokenKind.Prop : k.Controlled || CharacterOf(k)?.IsMine == true)
				.Select(k => (Token: k, Gap: GapOf(k, source)))
				.OrderBy(x => x.Gap)
				.FirstOrDefault();
			var culture = System.Globalization.CultureInfo.GetCultureInfo(Lang == LanguageCode.It ? "it-IT" : "en-GB");
			return mine.Token is null ? (null, string.Empty) : (mine.Token, $"{(mine.Gap * UiText.VttPerCell(Lang)).ToString("0.#", culture)} {UiText.VttUnit(Lang)}");
		}

		// ----- The masters fill the loot -----

		private sealed class LootDraft
		{
			public Guid TokenId { get; init; }
			public List<LootEntryDto> Items { get; init; } = new();
			public int Coins { get; set; }
			public string NewName { get; set; } = string.Empty;
			public int NewQuantity { get; set; } = 1;
		}

		private LootDraft? loot;

		private LootDraft LootOf(MapTokenDto t)
		{
			if (loot?.TokenId != t.Id)
			{
				loot = new LootDraft
				{
					TokenId = t.Id,
					Items = (t.Gear?.Items ?? new()).Select(i => new LootEntryDto { Name = i.Name, Quantity = i.Quantity }).ToList(),
					Coins = t.Gear?.Coins ?? 0
				};
			}
			return loot;
		}

		private void AddLoot(LootDraft draft)
		{
			var name = draft.NewName.Trim();
			if (name.Length == 0 || draft.Items.Count >= TokenGear.MaxItems)
			{
				return;
			}
			draft.Items.Add(new LootEntryDto { Name = name.Length > 100 ? name[..100] : name, Quantity = Math.Clamp(draft.NewQuantity, 1, 999) });
			draft.NewName = string.Empty;
			draft.NewQuantity = 1;
		}

		private async Task SaveLootAsync(MapTokenDto t, LootDraft draft)
		{
			if (map is null)
			{
				return;
			}
			AddLoot(draft);
			busy = true;
			var ok = (await Campaigns.SaveLootAsync(CampaignId, map.Id, t.Id, new SaveLootDto { Items = draft.Items, Coins = Math.Clamp(draft.Coins, 0, 1_000_000) })).Ok;
			busy = false;
			gearNote = ok ? UiText.VttLootSaved(Lang) : UiText.MapSaveFailed(Lang);
			loot = null;
			await RefreshAsync();
		}
	}
}
