using RealmForge.Client.Components;
using RealmForge.Client.Localization;
using RealmForge.Client.Services;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using Microsoft.AspNetCore.Components;

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

		//	10 or more is a success, 1 counts as two failures, 20 brings the character back with 1 hit point
		private void RollDeathSave()
		{
			if (Stable || Dead)
			{
				return;
			}
			var (die, dice) = RollD20();
			string note;
			if (die == 20)
			{
				Sheet.CurrentHitPoints = 1;
				Sheet.DeathSaveSuccesses = 0;
				Sheet.DeathSaveFailures = 0;
				note = UiText.DeathSaveTwenty(Lang);
			}
			else if (die == 1)
			{
				Sheet.DeathSaveFailures = Math.Min(3, Sheet.DeathSaveFailures + 2);
				note = UiText.DeathSaveOne(Lang);
			}
			else if (die >= 10)
			{
				Sheet.DeathSaveSuccesses = Math.Min(3, Sheet.DeathSaveSuccesses + 1);
				note = UiText.DeathSaveSuccess(Lang);
			}
			else
			{
				Sheet.DeathSaveFailures = Math.Min(3, Sheet.DeathSaveFailures + 1);
				note = UiText.DeathSaveFailure(Lang);
			}
			if (Stable)
			{
				note += " · " + UiText.DeathSaveStable(Lang);
			}
			else if (Dead)
			{
				note += " · " + UiText.DeathSaveDead(Lang);
			}
			ShowRoll(new DiceRollResult(UiText.SheetDeathSaves(Lang), dice, 0, die, note));
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
			Changed();
		}
	}
}
