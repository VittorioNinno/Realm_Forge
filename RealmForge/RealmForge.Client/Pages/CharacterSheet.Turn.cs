using RealmForge.Client.Components;
using RealmForge.Client.Localization;
using RealmForge.Client.Services;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using Microsoft.AspNetCore.Components;
using RealmForge.Shared.Rules;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	Play helpers of the sheet: the dice tray, death saving throws rolled for real, the summary of the turn and
	///	spells cast from the spell itself (slot level, free use, ritual, concentration).
	///	</summary>
	public partial class CharacterSheet
	{
		[Inject] private SpellDataService SpellService { get; set; } = default!;

		private DiceTray? diceTray;
		private List<RuleEntryResponseDto> ruleEntries = new();
		private readonly Dictionary<Guid, string> castingTimes = new();
		private ContextSpell? castSpell;
		private SpellcastingInfo? castSource;
		private string? lastCast;

		private void ShowRoll(DiceRollResult roll)
		{
			lastRoll = roll.Text;
			_ = diceTray?.ShowAsync(roll);
		}

		// ===== Death saving throws =====

		private bool Stable => Sheet.DeathSaveSuccesses >= 3;

		private bool Dead => Sheet.DeathSaveFailures >= 3;

		private bool deathRolling;
		private readonly List<string> shortRestLog = new();

		private void OpenShortRest()
		{
			shortRestLog.Clear();
			shortRestOpen = true;
		}

		//	What a short rest gives back besides the hit dice spent
		private IEnumerable<string> ShortRestRecoveries
		{
			get
			{
				if (computed?.PactSlots > 0)
				{
					yield return UiText.SheetPactSlots(computed.PactSlotLevel, Lang);
				}
				foreach (var resource in ClassResources.Where(r => r.Reset != ResourceReset.LongRest))
				{
					yield return resource.Reset == ResourceReset.OneOnShortRest ? $"{resource.Name} (1)" : resource.Name;
				}
				foreach (var resource in Sheet.Resources.Where(r => r.ShortRest))
				{
					yield return resource.Name;
				}
				foreach (var item in Sheet.Inventory.Where(i => i.Magic is { Charges: > 0, Recharge: ItemRecharge.ShortRest }))
				{
					yield return ItemName(item);
				}
			}
		}

		private void DamageCritical()
		{
			criticalHit = true;
			Damage();
		}
		private bool criticalHit;
		private string? deathNote;
		private int? concentrationDc;

		//	Constitution saving throw after damage while concentrating: the concentration ends on a failure
		private async Task RollConcentrationAsync()
		{
			if (computed is null || concentrationDc is not { } dc)
			{
				return;
			}
			var (die, dice) = RollD20();
			var bonus = computed.SaveBonus(AbilityScore.Constitution);
			var kept = die + bonus >= dc;
			var roll = new DiceRollResult(UiText.ConcentrationSave(dc, Lang), dice, bonus, die + bonus,
				kept ? UiText.ConcentrationKept(Lang) : UiText.ConcentrationLost(Lang));
			concentrationDc = null;
			lastRoll = roll.Text;
			if (diceTray is not null)
			{
				await diceTray.ShowAsync(roll);
			}
			if (!kept)
			{
				Sheet.Concentration = null;
				Changed();
			}
		}

		//	10 or more is a success, 1 counts as two failures, 20 brings the character back with 1 hit point;
		//	the sheet changes only once the dice have landed, so the tray tells the result first
		private async Task RollDeathSaveAsync()
		{
			if (Stable || Dead || deathRolling)
			{
				return;
			}
			var (die, dice) = RollD20();
			var successes = Sheet.DeathSaveSuccesses;
			var failures = Sheet.DeathSaveFailures;
			string note;
			if (die == 20)
			{
				note = UiText.DeathSaveTwenty(Lang);
			}
			else if (die == 1)
			{
				failures = Math.Min(3, failures + 2);
				note = UiText.DeathSaveOne(Lang);
			}
			else if (die >= 10)
			{
				successes = Math.Min(3, successes + 1);
				note = UiText.DeathSaveSuccess(Lang);
			}
			else
			{
				failures = Math.Min(3, failures + 1);
				note = UiText.DeathSaveFailure(Lang);
			}
			if (die != 20 && successes >= 3)
			{
				note += " · " + UiText.DeathSaveStable(Lang);
			}
			else if (die != 20 && failures >= 3)
			{
				note += " · " + UiText.DeathSaveDead(Lang);
			}

			deathRolling = true;
			var roll = new DiceRollResult(UiText.SheetDeathSaves(Lang), dice, 0, die, note);
			lastRoll = roll.Text;
			if (diceTray is not null)
			{
				await diceTray.ShowAsync(roll);
			}
			deathRolling = false;

			if (die == 20)
			{
				Sheet.CurrentHitPoints = 1;
				Sheet.DeathSaveSuccesses = 0;
				Sheet.DeathSaveFailures = 0;
			}
			else
			{
				Sheet.DeathSaveSuccesses = successes;
				Sheet.DeathSaveFailures = failures;
			}
			Changed();
		}

		// ===== Turn summary =====

		private IEnumerable<RuleEntryResponseDto> StandardActions => TurnActions.StandardActionKeys(Ruleset)
			.Select(k => ruleEntries.FirstOrDefault(e => e.Category == RuleCategory.Action && e.Key == k))
			.Where(e => e is not null)
			.Select(e => e!);

		private RuleEntryResponseDto? RuleEntry(string key) => ruleEntries.FirstOrDefault(e => e.Key == key);

		//	Chosen spells with the part of the turn they use (bonus action, reaction)
		private IEnumerable<(ContextSpell Spell, SpellcastingInfo Source)> SpellsFor(TurnSlot slot)
		{
			if (computed is null || context is null)
			{
				yield break;
			}
			foreach (var source in computed.Spellcasting)
			{
				foreach (var id in source.ChosenCantrips.Concat(source.ChosenSpells))
				{
					if (castingTimes.TryGetValue(id, out var time) && TurnActions.SlotOfCastingTime(time) == slot
						&& context.Spells.FirstOrDefault(s => s.Id == id) is { } spell)
					{
						yield return (spell, source);
					}
				}
			}
		}

		//	The casting times are in the spell details: loaded once, in parallel, for the turn summary
		private async Task LoadCastingTimesAsync(LanguageCode lang)
		{
			if (computed is null)
			{
				return;
			}
			var ids = computed.Spellcasting.SelectMany(s => s.ChosenCantrips.Concat(s.ChosenSpells)).Distinct().Where(id => !castingTimes.ContainsKey(id)).ToList();
			var details = await Task.WhenAll(ids.Select(id => SpellService.GetSpellDetailAsync(id, lang)));
			foreach (var detail in details.Where(d => d is not null))
			{
				castingTimes[detail!.Id] = detail.CastingTime;
			}
			await InvokeAsync(StateHasChanged);
		}

		//	Spells that can be cast right now: cantrips, or a slot / pact slot / free use still available (rituals take
		//	ten minutes, so they are not a turn option)
		private bool CanCastNow(ContextSpell spell, SpellcastingInfo source)
		{
			if (computed is null || CannotAct)
			{
				return false;
			}
			if (spell.Level == 0)
			{
				return true;
			}
			for (var level = spell.Level; level <= 9; level++)
			{
				if (computed.SpellSlots[level - 1] - SpentSlots(level) > 0)
				{
					return true;
				}
			}
			return (computed.PactSlots > Sheet.SpentPactSlots && computed.PactSlotLevel >= spell.Level)
				|| (HasFreeUse(source, spell) && FreeUseLeft(spell));
		}

		//	Uses left of the class resource a feature spends (null: it spends nothing)
		private int? FeatureUsesLeft(TurnFeature feature) =>
			feature.ResourceKey is { } key && ClassResources.FirstOrDefault(r => r.Key == key) is { } resource ? ResourceLeft(resource) : null;

		//	Unarmed Strike: Strength (Monk: the better of Strength and Dexterity with the Martial Arts die), always proficient
		private (int Bonus, string Damage) UnarmedStrike(ComputedCharacter c)
		{
			var str = c.Modifier(AbilityScore.Strength);
			var monk = c.ClassLevel("monk");
			if (monk > 0)
			{
				var mod = Math.Max(str, c.Modifier(AbilityScore.Dexterity));
				var die = Ruleset == RulesetVersion.Dnd5e_2024
					? (monk >= 17 ? 12 : monk >= 11 ? 10 : monk >= 5 ? 8 : 6)
					: (monk >= 17 ? 10 : monk >= 11 ? 8 : monk >= 5 ? 6 : 4);
				return (mod + c.ProficiencyBonus, $"1d{die}{(mod == 0 ? string.Empty : CharacterMath.FormatModifier(mod))}");
			}
			return (str + c.ProficiencyBonus, $"{Math.Max(0, 1 + str)}");
		}

		//	Two light weapons in hand: one more attack as a bonus action, without the positive ability modifier to damage
		private List<AttackInfo> OffHandAttacks(ComputedCharacter c)
		{
			var light = c.Attacks.Where(a => a.Item.WeaponProperties.Contains(WeaponProperty.Light) && a.Item.WeaponRange != WeaponRange.Ranged).ToList();
			return light.Count >= 2 ? light : new List<AttackInfo>();
		}

		private static string OffHandDamage(AttackInfo attack)
		{
			var dice = attack.Item.DamageDice ?? attack.Damage;
			var mod = attack.Damage.Length > dice.Length ? attack.Damage[dice.Length..] : string.Empty;
			return mod.StartsWith('−') || mod.StartsWith('-') ? dice + mod : dice;
		}

		// ===== Casting a spell =====

		private void OpenSpell(ContextSpell spell, SpellcastingInfo source)
		{
			castSpell = spell;
			castSource = source;
			spellDetailId = spell.Id;
		}

		private void CloseSpell()
		{
			spellDetailId = null;
			castSpell = null;
			castSource = null;
		}

		private bool CannotAct => Sheet.Conditions.Contains("incapacitated") || IsImplied("incapacitated") || CurrentHp == 0;

		private static string FreeKey(Guid id) => $"free:{id:N}";

		//	Spells from a species or a feat: once per long rest without a slot
		private bool HasFreeUse(SpellcastingInfo source, ContextSpell spell) => source.Class is null && spell.Level > 0;

		private bool FreeUseLeft(ContextSpell spell) => Sheet.ResourceUses.GetValueOrDefault(FreeKey(spell.Id)) == 0;

		//	2024: any prepared ritual; 2014: only the classes with Ritual Casting
		private bool CanCastAsRitual(SpellcastingInfo source, ContextSpell spell) => spell.Ritual && source.Class is { } cls
			&& (Ruleset == RulesetVersion.Dnd5e_2024 || cls.Class.Key is "bard" or "cleric" or "druid" or "wizard");

		private ContextSpell? ConcentrationSpell => Sheet.Concentration is { } id ? context?.Spells.FirstOrDefault(s => s.Id == id) : null;

		private void Cast(ContextSpell spell, string how)
		{
			if (spell.Concentration)
			{
				Sheet.Concentration = spell.Id;
			}
			lastCast = $"{spell.Name} · {how}";
			CloseSpell();
			Changed();
		}

		private void CastWithSlot(ContextSpell spell, int level)
		{
			if (computed is null || SpentSlots(level) >= computed.SpellSlots[level - 1])
			{
				return;
			}
			ToggleSlot(level, SpentSlots(level));
			Cast(spell, UiText.CastSlot(level, Lang));
		}

		private void CastWithPact(ContextSpell spell)
		{
			if (computed is null || Sheet.SpentPactSlots >= computed.PactSlots)
			{
				return;
			}
			Sheet.SpentPactSlots++;
			Cast(spell, UiText.CastPact(computed.PactSlotLevel, Lang));
		}

		private void CastFree(ContextSpell spell)
		{
			Sheet.ResourceUses[FreeKey(spell.Id)] = 1;
			Cast(spell, UiText.CastFree(Lang));
		}

		private void EndConcentration()
		{
			Sheet.Concentration = null;
			concentrationDc = null;
			Changed();
		}
	}
}
