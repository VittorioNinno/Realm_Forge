using System.Text.RegularExpressions;
using Microsoft.JSInterop;
using RealmForge.Client.Localization;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Components
{
	///	<summary>
	///	Spells at the table: cast from the quick sheet with the part of the turn they take (an action, a bonus action, a
	///	reaction: the server keeps the rules of spells in a turn), the slot spent, Metamagic paid with Sorcery Points; an
	///	area placed on the map or a target aimed at; a character's spell or attack confirmed before it is made; the saving
	///	throws a spell asks for waiting on every screen until each target has rolled.
	///	</summary>
	public partial class CampaignMap
	{
		// ===== Choosing and casting =====

		private sealed record CastChoice(Guid TokenId, SheetSpell Spell, bool UsesSlots);

		//	What a spell is, for what changes it (Potent Cantrip, Empowered Evocation, Agonizing Blast)
		private sealed record SpellInfo(int Level, bool Evocation, string? Key);

		//	What an area spell asks of the creatures in it: the save, the damage, half on a success
		private sealed record SpellEffect(int Ability, int Dc, string? Damage, string? DamageType, bool Half);

		//	The area being placed: the caster, the spell, its shape, what it asks of those in it
		private sealed record Placing(Guid CasterId, string Spell, SpellArea Area, SpellEffect? Effect = null, SpellInfo? Info = null);

		private CastChoice? castChoice;
		private Placing? placing;
		private string? castNote;

		//	Metamagic chosen before casting (it changes the casting: Quickened, Distant), "ready" to ready it instead
		private readonly HashSet<string> preMeta = new();
		private string readyTrigger = string.Empty;

		private void ChooseCast(MapTokenDto t, SheetSpell spell, bool usesSlots)
		{
			castChoice = castChoice?.Spell.Id == spell.Id && castChoice.TokenId == t.Id ? null : new CastChoice(t.Id, spell, usesSlots);
			castNote = null;
			preMeta.Clear();
		}

		private void TogglePreMeta(string option)
		{
			if (!preMeta.Remove(option))
			{
				preMeta.Add(option);
			}
		}

		//	The slots that can cast it: its level or higher with one left, the pact slots of a high enough level
		private List<(int Level, int Left, bool Pact)> CastSlots(MapTokenDto t, SheetSpell spell)
		{
			var list = new List<(int, int, bool)>();
			if (StatsOf(t)?.Slots is not { } slots)
			{
				return list;
			}
			for (var level = Math.Max(1, spell.Level); level <= 9; level++)
			{
				if (slots.Left[level - 1] > 0)
				{
					list.Add((level, slots.Left[level - 1], false));
				}
			}
			if (slots.PactLeft > 0 && slots.PactLevel >= spell.Level)
			{
				list.Add((slots.PactLevel, slots.PactLeft, true));
			}
			return list;
		}

		// ----- Sorcery Points and the options of a caster -----

		private CastingOptions OptionsOf(MapTokenDto t) => StatsOf(t)?.Casting ?? CastingOptions.None;

		private int PointsLeft(MapTokenDto t)
		{
			var stats = StatsOf(t);
			if (OptionsOf(t).PointsKey is not { } key || stats?.Resources?.FirstOrDefault(r => r.Key == key) is not { } resource)
			{
				return 0;
			}
			return Math.Max(0, resource.Maximum - (stats.Spent?.GetValueOrDefault(key) ?? 0));
		}

		//	Sorcery Points spent on the sheet; false when there are not enough
		private async Task<bool> SpendPointsAsync(MapTokenDto t, int cost)
		{
			if (cost <= 0)
			{
				return true;
			}
			if (OptionsOf(t).PointsKey is not { } key || PointsLeft(t) < cost)
			{
				castNote = UiText.VttMetamagicNoPoints(Lang);
				return false;
			}
			var ok = false;
			await ChangeCharacterAsync(t, (sheet, _) =>
			{
				var max = StatsOf(t)?.Resources?.FirstOrDefault(r => r.Key == key)?.Maximum ?? 0;
				var used = sheet.ResourceUses.GetValueOrDefault(key);
				if (max - used >= cost)
				{
					sheet.ResourceUses[key] = used + cost;
					ok = true;
				}
			});
			if (!ok)
			{
				castNote = UiText.VttMetamagicNoPoints(Lang);
			}
			return ok;
		}

		//	The part of the turn a spell takes, from its casting time ("1 azione bonus", "1 bonus action", "1 reazione")
		private static string PartOf(string? castingTime)
		{
			var text = (castingTime ?? string.Empty).ToLowerInvariant();
			return text.Contains("bonus") ? "bonus" : text.Contains("reaz") || text.Contains("reaction") ? "reaction"
				: text.Contains("azion") || text.Contains("action") ? "action" : "other";
		}

		//	Whether a success on the save halves the damage ("half as much damage", "la metà di quei danni")
		private static bool HalfOnSave(string? description) =>
			Regex.IsMatch(description ?? string.Empty, @"half\s+as\s+much|metà\s+(?:di\s+quei\s+|dei\s+)?danni|dimezza", RegexOptions.IgnoreCase);

		//	The damage with what the caster adds to it: Empowered Evocation (an evocation of a wizard), Agonizing Blast
		private static string? DamageWith(string? damage, CastingOptions options, SpellInfo? info)
		{
			if (string.IsNullOrEmpty(damage) || info is null)
			{
				return damage;
			}
			var extra = (info.Evocation && options.EmpoweredEvocation > 0 ? options.EmpoweredEvocation : 0)
				+ (info.Key == "eldritch-blast" ? options.AgonizingBlast : 0);
			return extra > 0 ? $"{damage}+{extra}" : damage;
		}

		//	Cast: the part of the turn it takes is checked and marked (in a fight, on its own turn), the slot and the
		//	Metamagic chosen spent, then its area is placed or its target aimed at
		private async Task CastAsync(MapTokenDto t, SheetSpell spell, int level, bool pact)
		{
			//	Readied (in a fight, on its own turn): the slot spent now, the effect when the trigger comes
			var ready = preMeta.Contains("ready") && TurnOf(t) is not null && IsTurnOf(t);
			var trigger = readyTrigger.Trim();
			if (ready && trigger.Length == 0)
			{
				castNote = UiText.VttReadyNeedsTrigger(Lang);
				return;
			}
			castChoice = null;
			CancelAim();
			var detail = await SpellService.GetSpellDetailAsync(spell.Id, Lang);
			var options = OptionsOf(t);
			var meta = preMeta.Where(options.Has).ToHashSet();
			preMeta.Clear();
			var part = PartOf(detail?.CastingTime);
			if (meta.Contains("quickened") && part == "action")
			{
				part = "bonus";
			}
			else
			{
				meta.Remove("quickened");
			}
			var cost = meta.Sum(o => CastingOptions.CostOf(o));
			if (cost > PointsLeft(t))
			{
				castNote = UiText.VttMetamagicNoPoints(Lang);
				return;
			}

			//	In a fight: the action, bonus action or reaction it takes (refused when already used, or when the spells of
			//	the turn do not allow it)
			if (TurnOf(t) is not null && (part != "other" || ready) && map is not null)
			{
				busy = true;
				localEdits++;
				var turnAction = ready
					? new TurnActionDto { Kind = "ready", Trigger = trigger.Length > 120 ? trigger[..120] : trigger, What = spell.Name.Length > 60 ? spell.Name[..60] : spell.Name, SpellId = spell.Id, Level = Math.Max(level, spell.Level) }
					: new TurnActionDto { Kind = "cast", Wield = part, Level = spell.Level };
				var (_, refused) = await Campaigns.TurnActionAsync(CampaignId, map.Id, t.Id, turnAction, Lang);
				busy = false;
				if (refused is not null)
				{
					castNote = refused.Length > 0 ? refused : UiText.MapSaveFailed(Lang);
					return;
				}
			}

			if (spell.Level > 0 && level > 0)
			{
				var ok = true;
				await ChangeCharacterAsync(t, (sheet, computed) =>
				{
					if (pact)
					{
						if (sheet.SpentPactSlots >= computed.PactSlots)
						{
							ok = false;
							return;
						}
						sheet.SpentPactSlots++;
					}
					else
					{
						while (sheet.SpentSlots.Count < 9)
						{
							sheet.SpentSlots.Add(0);
						}
						if (sheet.SpentSlots[level - 1] >= computed.SpellSlots[level - 1])
						{
							ok = false;
							return;
						}
						sheet.SpentSlots[level - 1]++;
					}
					//	A readied spell is held with concentration until it is let go
					if (spell.Concentration || ready)
					{
						sheet.Concentration = spell.Id;
					}
				});
				if (!ok)
				{
					castNote = UiText.VttCastNoSlot(Lang);
					return;
				}
			}
			else if ((spell.Concentration || ready) && t.CharacterId is not null)
			{
				await ChangeCharacterAsync(t, (sheet, _) => sheet.Concentration = spell.Id);
			}
			if (cost > 0 && !await SpendPointsAsync(t, cost))
			{
				return;
			}
			var used = meta.Count > 0 ? string.Join(", ", meta.Select(m => UiText.VttMetamagicName(m, Lang))) : null;
			castNote = UiText.VttCastDone(spell.Name, level > 0 ? pact ? UiText.CastPact(level, Lang) : UiText.CastSlot(level, Lang) : null, Lang)
				+ (used is null ? string.Empty : $" · {used}");
			InvalidateStats(StatsKey(t));
			_ = LoadStatsAsync(t);
			if (ready)
			{
				readyTrigger = string.Empty;
				castNote = UiText.VttReadied(spell.Name, trigger, Lang);
				await RefreshAsync();
				return;
			}
			await CastEffectAsync(t, spell, level, detail, meta, options);
		}

		//	What a spell does once cast (or let go when readied): its area placed, or its target aimed at
		private async Task CastEffectAsync(MapTokenDto t, SheetSpell spell, int level, SpellDetailResponseDto? detail, HashSet<string> meta, CastingOptions options)
		{
			//	Its area, read from the range and the description; without one, the target of a spell attack or a save
			if (detail is null || !Table || map is null || !tokens.Any(k => k.Id == t.Id))
			{
				StateHasChanged();
				return;
			}
			var info = new SpellInfo(spell.Level, spell.School == SpellSchool.Evocation, spell.Key);
			var slotLevel = Math.Max(level, spell.Level);
			var area = TableCombat.AreaOf(detail.Range, detail.Description);
			var target = TableCombat.TargetOf(detail.Range, detail.Description, detail.HigherLevels, spell.Level, slotLevel, spell.CasterLevel);
			//	Distant Spell: twice the range (a touch becomes 9 metres)
			var distant = meta.Contains("distant");
			if (area is null && target is null)
			{
				StateHasChanged();
				return;
			}
			if (PlayersStopped)
			{
				castNote = UiText.VttCastLocked(spell.Name, Lang);
				StateHasChanged();
				return;
			}
			var half = HalfOnSave(detail.Description) || (spell.Level == 0 && options.PotentCantrip);
			//	A lasting emanation around the caster (Spirit Guardians and the like): an aura that moves with it, asking its
			//	save of the creatures that enter it or start their turn in it
			if (area is { FromCaster: true, Kind: ShapeKind.Sphere } && spell.Concentration)
			{
				await SaveAuraAsync(t, new SaveAuraDto
				{
					Name = spell.Name.Length > 60 ? spell.Name[..60] : spell.Name,
					Radius = Math.Clamp(area.Size, 1, TokenAura.MaxRadius),
					Enemies = true,
					Ability = target?.SaveAbility is { } auraAbility ? MapSaveRules.AbilityOf(auraAbility) : 0,
					Dc = spell.SaveDc,
					Damage = DamageWith(target?.Damage, options, new SpellInfo(spell.Level, spell.School == SpellSchool.Evocation, spell.Key)),
					DamageType = target?.DamageType,
					Half = half
				});
				return;
			}
			if (area is not null)
			{
				if (distant && !area.FromCaster)
				{
					area = area with { Range = area.Range >= TableCombat.Unlimited ? area.Range : area.Range <= 1 ? 6 : area.Range * 2 };
				}
				var effect = target is { SaveAbility: { } ability } ? new SpellEffect(MapSaveRules.AbilityOf(ability), spell.SaveDc, target.Damage, target.DamageType, half) : null;
				await StartPlacingAsync(t, spell.Name, area, effect, info);
				return;
			}
			var range = distant ? (target!.Range <= 1 ? 6 : target.Range * 2) : target!.Range;
			var reach = target.Melee && !distant ? new AttackReach(range, 0, 0) : new AttackReach(0, range, range);
			var line = new SheetLine(spell.Name, string.Empty, null, null, spell.AttackBonus, target.Damage, target.DamageType, reach, Spell: true);
			if (target.Attack)
			{
				await StartAimAsync(t, line, info: info);
			}
			else
			{
				await StartAimAsync(t, line, target.SaveAbility ?? "?", spell.SaveDc, half, info);
			}
		}

		private async Task StartPlacingAsync(MapTokenDto caster, string spell, SpellArea area, SpellEffect? effect = null, SpellInfo? info = null)
		{
			placing = new Placing(caster.Id, spell, area, effect, info);
			CloseToolbar();
			var (cx, cy) = MapGeometry.Center(gridType, grid, offsetX, offsetY, caster.X, caster.Y, caster.Size);
			tool = "cast";
			if (!string.IsNullOrEmpty(stageElement.Id))
			{
				await JS.InvokeVoidAsync("rfVtt.tool", stageElement, "cast", new
				{
					color = drawColor,
					cast = new
					{
						kind = area.Kind.ToString().ToLowerInvariant(),
						size = area.Size,
						range = area.Range,
						fromCaster = area.FromCaster,
						x = cx,
						y = cy,
						col = caster.X,
						row = caster.Y,
						casterSize = caster.Size
					}
				});
			}
			StateHasChanged();
		}

		private void CancelCast()
		{
			castChoice = null;
			if (placing is not null)
			{
				placing = null;
				_ = SetToolAsync("select");
			}
		}

		//	The area placed: drawn for the table, the tokens in it named; when it asks for saves, the caster confirms the
		//	targets (and its options) and the table is asked for the saves
		[Microsoft.JSInterop.JSInvokable]
		public async Task CastPlaced(string kind, double ox, double oy, double tx, double ty, int size)
		{
			var cast = placing;
			var spell = cast?.Spell;
			placing = null;
			await SetToolAsync("select");
			if (!Enum.TryParse<ShapeKind>(kind, true, out var k) || !MapRules.IsArea(k) || map is null)
			{
				StateHasChanged();
				return;
			}
			await AddShapeAsync(new SaveShapeDto { Kind = k, Points = new() { ox, oy, tx, ty }, Size = size, Color = drawColorChoice });
			//	The cells the area reaches: not those behind a wall or a closed door, seen from where it spreads
			var spread = k == ShapeKind.Cube ? (ox + size * grid / 2.0, oy) : (ox, oy);
			var closed = ClosedDoors().ToHashSet();
			var cells = MapAreas.Cells(gridType, grid, offsetX, offsetY, k, ox, oy, tx, ty, size, map.Width, map.Height)
				.Where(c => MapTerrain.Visible(gridType, grid, offsetX, offsetY, terrainCells, closed, spread, c)).ToHashSet();
			var inside = tokens.Where(IsTarget).Where(t => Covered(t).Any(cells.Contains)).ToList();
			if (cast?.Effect is { } effect && inside.Count > 0)
			{
				pending = new Pending
				{
					Kind = "save",
					CasterId = cast.CasterId,
					Name = cast.Spell,
					Targets = inside.Select(t => t.Id).ToList(),
					Ability = effect.Ability,
					Dc = effect.Dc,
					Damage = effect.Damage,
					DamageType = effect.DamageType,
					Half = effect.Half,
					Info = cast.Info,
					Area = true
				};
				castNote = null;
				StateHasChanged();
				return;
			}
			var names = inside.Select(t => t.Label).ToList();
			castNote = names.Count > 0 ? UiText.VttCastInside(spell ?? string.Empty, string.Join(", ", names), Lang) : UiText.VttCastNobody(spell ?? string.Empty, Lang);
			StateHasChanged();
		}

		// ===== The confirmation of a character's attack or spell =====

		private sealed class Pending
		{
			public required string Kind { get; init; }
			public required Guid CasterId { get; init; }
			public required string Name { get; init; }
			public Aim? Aim { get; init; }
			public int Mode { get; set; }
			public string? Condition { get; init; }
			public List<Guid> Targets { get; init; } = new();
			public int Ability { get; init; }
			public int Dc { get; init; }
			public string? Damage { get; set; }
			public string? DamageType { get; init; }
			public bool Half { get; init; }
			public bool Area { get; init; }
			public SpellInfo? Info { get; init; }

			//	The Metamagic chosen, the targets protected (Careful Spell, Sculpt Spells), the one with disadvantage, the
			//	new damage type
			public HashSet<string> Meta { get; } = new();
			public HashSet<Guid> Careful { get; } = new();
			public Guid? Heightened { get; set; }
			public string? Transmute { get; set; }
			public bool Sculpt { get; set; }
		}

		private Pending? pending;

		private void CancelPending()
		{
			pending = null;
		}

		//	The options a confirmation offers: the Metamagic the caster knows that fits it
		private IEnumerable<string> MetaFor(Pending p, MapTokenDto caster)
		{
			var options = OptionsOf(caster);
			if (p.Info is null)
			{
				yield break;
			}
			foreach (var key in options.Metamagic)
			{
				var fits = key switch
				{
					"careful" => p.Kind == "save",
					"heightened" => p.Kind == "save",
					"empowered" => !string.IsNullOrEmpty(p.Damage),
					"transmuted" => TransmutedTypes(Lang).Any(type => string.Equals(type, p.DamageType, StringComparison.OrdinalIgnoreCase)),
					"seeking" => p.Kind == "attack",
					_ => false
				};
				if (fits)
				{
					yield return key;
				}
			}
		}

		//	The damage types Transmuted Spell changes between
		private static string[] TransmutedTypes(LanguageCode lang) => lang == LanguageCode.En
			? new[] { "acid", "cold", "fire", "lightning", "poison", "thunder" }
			: new[] { "acido", "freddo", "fuoco", "fulmine", "veleno", "tuono" };

		private void TogglePendingMeta(string option)
		{
			if (pending is null)
			{
				return;
			}
			if (!pending.Meta.Remove(option))
			{
				pending.Meta.Add(option);
			}
			if (option == "careful" && !pending.Meta.Contains("careful") && !pending.Sculpt)
			{
				pending.Careful.Clear();
			}
			if (option == "heightened" && !pending.Meta.Contains("heightened"))
			{
				pending.Heightened = null;
			}
		}

		private void ToggleSculpt()
		{
			if (pending is null)
			{
				return;
			}
			pending.Sculpt = !pending.Sculpt;
			if (!pending.Sculpt && !pending.Meta.Contains("careful"))
			{
				pending.Careful.Clear();
			}
		}

		//	How many targets can be protected: Careful Spell the Charisma modifier (at least one), Sculpt Spells one plus
		//	the spell's level
		private int ProtectMost(Pending p, MapTokenDto caster) =>
			(p.Meta.Contains("careful") ? Math.Max(1, OptionsOf(caster).Charisma) : 0) + (p.Sculpt ? 1 + (p.Info?.Level ?? 0) : 0);

		private void ToggleCareful(Guid id)
		{
			if (pending is null || tokens.FirstOrDefault(t => t.Id == pending.CasterId) is not { } caster)
			{
				return;
			}
			if (!pending.Careful.Remove(id) && pending.Careful.Count < ProtectMost(pending, caster))
			{
				pending.Careful.Add(id);
			}
		}

		private int PendingCost(Pending p) => p.Meta.Sum(o => CastingOptions.CostOf(o));

		private async Task ConfirmPendingAsync()
		{
			if (pending is not { } p || map is null || tokens.FirstOrDefault(t => t.Id == p.CasterId) is not { } caster)
			{
				pending = null;
				return;
			}
			if (PendingCost(p) > PointsLeft(caster))
			{
				castNote = UiText.VttMetamagicNoPoints(Lang);
				return;
			}
			pending = null;
			if (!await SpendPointsAsync(caster, PendingCost(p)))
			{
				return;
			}
			var damage = DamageWith(p.Damage, OptionsOf(caster), p.Info);
			if (p.Kind == "attack" && p.Aim is { } current && tokens.FirstOrDefault(t => t.Id == p.Targets.FirstOrDefault()) is { } target)
			{
				p.Damage = damage;
				await StrikeAsync(current, caster, target, p.Mode, p.Condition, p);
				return;
			}
			busy = true;
			localEdits++;
			var (call, error) = await Campaigns.CallSavesAsync(CampaignId, map.Id, new CallSavesDto
			{
				CasterId = caster.Id,
				Spell = p.Name.Length > 60 ? p.Name[..60] : p.Name,
				Ability = Math.Clamp(p.Ability, 1, 6),
				Dc = Math.Clamp(p.Dc, 1, 40),
				Damage = damage,
				DamageType = p.Transmute ?? p.DamageType,
				Half = p.Half,
				TargetIds = p.Targets,
				Careful = p.Careful.ToList(),
				Heightened = p.Heightened,
				Empowered = p.Meta.Contains("empowered") ? Math.Max(1, OptionsOf(caster).Charisma) : 0
			}, Lang);
			busy = false;
			castNote = call is null
				? (string.IsNullOrEmpty(error) ? UiText.MapSaveFailed(Lang) : error)
				: UiText.VttSavesAsked(p.Name, UiText.VttSaveDc(UiText.AbilityShort((AbilityScore)call.Ability, Lang), call.Dc, Lang), call.Damage, Lang);
			await RefreshAsync();
		}

		// ===== Saving throws waiting at the table =====

		private List<MapSaveCallDto> saveCalls = new();
		private string? saveNote;

		//	Who rolls a target's save on this screen: a master any, a player the own characters and creatures
		private bool CanSave(MapSaveTargetDto target) => tokens.FirstOrDefault(t => t.Id == target.TokenId) is { } t
			&& (RunsTheTable || t.Controlled || CharacterOf(t)?.IsMine == true);

		//	The calls this screen has something to do with: all of them for a master, those with my targets for a player
		private List<MapSaveCallDto> MySaveCalls => saveCalls
			.Where(c => RunsTheTable || c.Targets.Any(t => t.Saved is null && CanSave(t)) || tokens.Any(t => t.Id == c.CasterTokenId && (t.Controlled || CharacterOf(t)?.IsMine == true)))
			.ToList();

		private int SaveBonusOf(MapTokenDto t, int ability) =>
			ability is >= 1 and <= 6 && StatsOf(t)?.SaveBonuses is { Length: 6 } bonuses ? bonuses[ability - 1] : 0;

		private async Task RollSaveAsync(MapSaveCallDto call, MapSaveTargetDto target, bool? saved = null)
		{
			if (map is null || tokens.FirstOrDefault(t => t.Id == target.TokenId) is not { } t)
			{
				return;
			}
			await LoadStatsAsync(t);
			busy = true;
			saveNote = null;
			localEdits++;
			var (_, error) = await Campaigns.ResolveSaveAsync(CampaignId, map.Id, call.Id, t.Id, new ResolveSaveDto { Bonus = SaveBonusOf(t, call.Ability), Saved = saved }, Lang);
			busy = false;
			if (error is not null)
			{
				saveNote = error.Length > 0 ? error : UiText.MapSaveFailed(Lang);
			}
			if (t.CharacterId is { } id)
			{
				InvalidateStats($"c:{id}");
				charVitals.Remove(id);
				hpAfterRest.Remove(id);
				_ = LoadStatsAsync(t);
			}
			await RefreshAsync();
		}

		//	A master rolls the saves of every creature it runs in one go (the players roll their characters')
		private async Task RollMySavesAsync(MapSaveCallDto call)
		{
			foreach (var target in call.Targets.Where(t => t.Saved is null && CanSave(t)).ToList())
			{
				if (RunsTheTable && tokens.FirstOrDefault(t => t.Id == target.TokenId) is { CharacterId: not null } character && CharacterOf(character)?.IsMine != true)
				{
					continue;
				}
				await RollSaveAsync(call, target);
			}
		}

		private async Task DismissSavesAsync(MapSaveCallDto call)
		{
			if (map is null)
			{
				return;
			}
			localEdits++;
			await Campaigns.DismissSavesAsync(CampaignId, map.Id, call.Id);
			saveCalls.RemoveAll(c => c.Id == call.Id);
			await RefreshAsync();
		}

		//	A monster's saves from its statblock line ("Des +5, Sag +3", "Dex +5, Wis +3"), the others its modifiers
		private static int[] MonsterSaves(string? line, IReadOnlyList<int> scores)
		{
			var saves = Enumerable.Range(0, 6).Select(i => (int)Math.Floor(((i < scores.Count ? scores[i] : 10) - 10) / 2.0)).ToArray();
			foreach (Match m in Regex.Matches(line ?? string.Empty, @"([A-Za-zÀ-ÿ]{3})[A-Za-zÀ-ÿ]*\.?\s*([+−-])\s*(\d+)"))
			{
				var ability = MapSaveRules.AbilityOf(m.Groups[1].Value);
				if (ability > 0 && int.TryParse(m.Groups[3].Value, out var value))
				{
					saves[ability - 1] = m.Groups[2].Value == "+" ? value : -value;
				}
			}
			return saves;
		}
	}
}
