using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	When a class can change its spells (System Reference Document 5.1 and 5.2):
///	2014: clerics, druids, paladins and wizards change the prepared list after a long rest; bards, rangers,
///	sorcerers, warlocks and the third casters replace one known spell per level; cantrips never change.
///	2024: clerics, druids and wizards change the whole list after a long rest, paladins and rangers one spell;
///	bards, sorcerers, warlocks and the third casters replace one spell per level; one cantrip can be replaced per
///	level (wizards: after each long rest instead).
///	</summary>
public sealed record SpellChangeRule(SpellChangeKind? LongRest, bool LevelUpSpell, bool LevelUpCantrip, bool LongRestCantrip, bool Spellbook);

public static class SpellChangeRules
{
	public static SpellChangeRule For(RulesetVersion ruleset, string? classKey, bool thirdCaster)
	{
		var is2024 = ruleset == RulesetVersion.Dnd5e_2024;
		if (thirdCaster)
		{
			return new SpellChangeRule(null, true, is2024, false, false);
		}
		return (classKey, is2024) switch
		{
			("wizard", false) => new SpellChangeRule(SpellChangeKind.All, false, false, false, true),
			("wizard", true) => new SpellChangeRule(SpellChangeKind.All, false, false, true, true),
			("cleric" or "druid", false) => new SpellChangeRule(SpellChangeKind.All, false, false, false, false),
			("cleric" or "druid", true) => new SpellChangeRule(SpellChangeKind.All, false, true, false, false),
			("paladin", false) => new SpellChangeRule(SpellChangeKind.All, false, false, false, false),
			("paladin" or "ranger", true) => new SpellChangeRule(SpellChangeKind.Spell, false, false, false, false),
			("bard" or "ranger" or "sorcerer" or "warlock", false) => new SpellChangeRule(null, true, false, false, false),
			("bard" or "sorcerer" or "warlock", true) => new SpellChangeRule(null, true, true, false, false),

			//	Homebrew classes: prepared after a long rest, like the most common casters
			_ => new SpellChangeRule(SpellChangeKind.All, false, false, false, false)
		};
	}

	public static SpellChangeRule For(RulesetVersion ruleset, ClassLevelInfo info) =>
		For(ruleset, info.Class.Key, info.Class.CasterProgression == CasterProgression.None && info.Subclass?.CasterProgression == CasterProgression.Third);

	//	Wizard spellbook: six spells at level 1 and two more for free at every wizard level
	public static int FreeSpellbookSpells(int wizardLevel) => wizardLevel <= 0 ? 0 : 6 + 2 * (wizardLevel - 1);

	//	Copying a spell into the spellbook: 50 gp and 2 hours per spell level (both editions)
	public static int CopyCostGold(int spellLevel) => 50 * Math.Max(1, spellLevel);
}
