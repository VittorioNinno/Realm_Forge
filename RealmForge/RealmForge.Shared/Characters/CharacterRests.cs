using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	Short and long rests on the play state of a sheet, the same from the character sheet and from the virtual tabletop.
///	The dice (hit dice, recharges of magic items) are rolled by the caller, who shows them.
///	</summary>
public static class CharacterRests
{
	public static int HitDiceSpent(CharacterSheetState sheet, int die) => sheet.HitDiceSpent.GetValueOrDefault(die);

	//	Short rest: a hit die spent heals die + Constitution modifier (at least 0); null when none of that size is left
	public static (int Roll, int Healed)? SpendHitDie(CharacterSheetState sheet, ComputedCharacter computed, int die, Func<int, int> roll)
	{
		var available = computed.HitDice.Where(h => h.Die == die).Sum(h => h.Count);
		if (HitDiceSpent(sheet, die) >= available)
		{
			return null;
		}
		var rolled = roll(die);
		var healed = Math.Max(0, rolled + computed.Modifier(AbilityScore.Constitution));
		var max = Math.Max(1, computed.MaxHitPoints);
		sheet.HitDiceSpent[die] = HitDiceSpent(sheet, die) + 1;
		sheet.CurrentHitPoints = Math.Min(max, Math.Clamp(sheet.CurrentHitPoints ?? max, 0, max) + healed);
		return (rolled, healed);
	}

	//	The end of a short rest: pact slots, the class features and the counters that come back with it
	public static void FinishShortRest(CharacterSheetState sheet, IEnumerable<ClassResource> classResources)
	{
		sheet.SpentPactSlots = 0;
		foreach (var resource in classResources)
		{
			var spent = Math.Clamp(sheet.ResourceUses.GetValueOrDefault(resource.Key), 0, resource.Maximum);
			sheet.ResourceUses[resource.Key] = CharacterResources.SpentAfterRest(resource, spent, longRest: false);
		}
		foreach (var resource in sheet.Resources.Where(r => r.ShortRest))
		{
			resource.Used = 0;
		}
	}

	//	Long rest: all hit points and slots; hit dice: half the total (2014) or all (2024); exhaustion -1; the spell
	//	changes the classes allow after it
	public static void LongRest(CharacterSheetState sheet, ComputedCharacter? computed, RulesetVersion ruleset)
	{
		sheet.CurrentHitPoints = null;
		sheet.TemporaryHitPoints = 0;
		sheet.DeathSaveSuccesses = 0;
		sheet.DeathSaveFailures = 0;
		sheet.SpentSlots.Clear();
		sheet.SpentPactSlots = 0;
		sheet.ResourceUses.Clear();
		GrantLongRestChanges(sheet, computed, ruleset);
		foreach (var resource in sheet.Resources)
		{
			resource.Used = 0;
		}
		if (ruleset == RulesetVersion.Dnd5e_2024)
		{
			sheet.HitDiceSpent.Clear();
		}
		else if (computed is not null)
		{
			var recover = Math.Max(1, computed.Level / 2);
			foreach (var (die, _) in computed.HitDice)
			{
				var back = Math.Min(recover, HitDiceSpent(sheet, die));
				sheet.HitDiceSpent[die] = HitDiceSpent(sheet, die) - back;
				recover -= back;
			}
		}
		sheet.Exhaustion = Math.Max(0, sheet.Exhaustion - 1);
	}

	//	After a long rest: the changes of each class replace the ones of the previous rest
	public static void GrantLongRestChanges(CharacterSheetState sheet, ComputedCharacter? computed, RulesetVersion ruleset)
	{
		if (computed is null)
		{
			return;
		}
		sheet.SpellChanges.RemoveAll(g => g.FromLongRest);
		foreach (var source in computed.Spellcasting.Where(s => s.Class is not null && s.Source == "class"))
		{
			var rule = SpellChangeRules.For(ruleset, source.Class!);
			if (rule.LongRest is { } kind)
			{
				sheet.SpellChanges.Add(new SpellChangeGrant { ClassId = source.Class!.Class.Id, Kind = kind, Remaining = 1, FromLongRest = true });
			}
			if (rule.LongRestCantrip)
			{
				sheet.SpellChanges.Add(new SpellChangeGrant { ClassId = source.Class!.Class.Id, Kind = SpellChangeKind.Cantrip, Remaining = 1, FromLongRest = true });
			}
		}
	}

	//	Charges back with a rest: the dice of the item ("1d6+1" each dawn, rolled by the caller) or all of them
	public static void RechargeItems(CharacterSheetState sheet, bool longRest, Func<InventoryItem, string, int?> roll)
	{
		foreach (var item in sheet.Inventory.Where(i => i.Magic is { Charges: > 0, ChargesUsed: > 0 }))
		{
			var magic = item.Magic!;
			if (magic.Recharge == ItemRecharge.None || (!longRest && magic.Recharge != ItemRecharge.ShortRest))
			{
				continue;
			}
			magic.ChargesUsed = magic.RechargeDice is { } dice && roll(item, dice) is { } total
				? Math.Max(0, magic.ChargesUsed - total)
				: 0;
		}
	}
}
