using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Rules;

namespace RealmForge.Tests;

public class CharacterMathTests
{
	private static readonly IReadOnlyList<CharacterClass> Classes = ClassSeeder.GetClassDefinitions();

	private static string? Table(string key, RulesetVersion ruleset, LanguageCode lang = LanguageCode.En) =>
		Classes.Single(c => c.Ruleset == ruleset && BaseClassKeys.Of(c.Id, ruleset) == key)
			.Translations.Single(t => t.Language == lang).ProgressionTable;

	[Theory]
	[InlineData(8, -1)]
	[InlineData(10, 0)]
	[InlineData(11, 0)]
	[InlineData(15, 2)]
	[InlineData(20, 5)]
	[InlineData(3, -4)]
	public void Modifier_follows_the_ability_table(int score, int modifier) => Assert.Equal(modifier, CharacterMath.Modifier(score));

	[Fact]
	public void Modifiers_and_proficiency_are_formatted_and_scaled()
	{
		Assert.Equal("+2", CharacterMath.FormatModifier(2));
		Assert.Equal("+0", CharacterMath.FormatModifier(0));
		Assert.Equal("−1", CharacterMath.FormatModifier(-1));
		Assert.Equal(2, CharacterMath.ProficiencyBonus(1));
		Assert.Equal(3, CharacterMath.ProficiencyBonus(5));
		Assert.Equal(6, CharacterMath.ProficiencyBonus(20));
	}

	[Fact]
	public void Base_scores_must_match_the_method()
	{
		Assert.True(CharacterMath.AreValidBaseScores(AbilityMethod.StandardArray, new[] { 8, 10, 12, 13, 14, 15 }));
		Assert.False(CharacterMath.AreValidBaseScores(AbilityMethod.StandardArray, new[] { 15, 15, 13, 12, 10, 8 }));

		//	27 points: 15 (9) + 15 (9) + 15 (9) = 27, the rest at 8
		Assert.True(CharacterMath.AreValidBaseScores(AbilityMethod.PointBuy, new[] { 15, 15, 15, 8, 8, 8 }));
		Assert.False(CharacterMath.AreValidBaseScores(AbilityMethod.PointBuy, new[] { 15, 15, 15, 9, 8, 8 }));
		Assert.False(CharacterMath.AreValidBaseScores(AbilityMethod.PointBuy, new[] { 16, 8, 8, 8, 8, 8 }));

		Assert.True(CharacterMath.AreValidBaseScores(AbilityMethod.Roll, new[] { 3, 18, 12, 9, 14, 10 }));
		Assert.False(CharacterMath.AreValidBaseScores(AbilityMethod.Roll, new[] { 19, 10, 10, 10, 10, 10 }));
		Assert.False(CharacterMath.AreValidBaseScores(AbilityMethod.Roll, new[] { 10, 10, 10 }));
	}

	[Fact]
	public void Origin_increases_follow_the_background_in_2024_and_are_free_in_2014()
	{
		var options = new[] { AbilityScore.Intelligence, AbilityScore.Wisdom, AbilityScore.Charisma };
		Assert.True(CharacterMath.AreValidBonuses(AbilityBonusMode.TwoAndOne, new[] { 0, 0, 0, 2, 1, 0 }, options));
		Assert.True(CharacterMath.AreValidBonuses(AbilityBonusMode.ThreeOnes, new[] { 0, 0, 0, 1, 1, 1 }, options));
		Assert.False(CharacterMath.AreValidBonuses(AbilityBonusMode.TwoAndOne, new[] { 2, 0, 0, 1, 0, 0 }, options));
		Assert.False(CharacterMath.AreValidBonuses(AbilityBonusMode.TwoAndOne, new[] { 0, 0, 0, 2, 2, 0 }, options));

		Assert.True(CharacterMath.AreValidBonuses(AbilityBonusMode.TwoAndOne, new[] { 2, 0, 1, 0, 0, 0 }, Array.Empty<AbilityScore>()));
		Assert.True(CharacterMath.AreValidBonuses(AbilityBonusMode.AllOnes, new[] { 1, 1, 1, 1, 1, 1 }, Array.Empty<AbilityScore>()));
		Assert.False(CharacterMath.AreValidBonuses(AbilityBonusMode.AllOnes, new[] { 1, 1, 1, 1, 1, 0 }, Array.Empty<AbilityScore>()));
	}

	[Fact]
	public void Final_scores_are_capped_at_20()
	{
		Assert.Equal(new[] { 17, 14, 14, 12, 10, 8 }, CharacterMath.FinalScores(new[] { 15, 14, 13, 12, 10, 8 }, new[] { 2, 0, 1, 0, 0, 0 }));
		Assert.Equal(20, CharacterMath.FinalScores(new[] { 19, 10, 10, 10, 10, 10 }, new[] { 2, 0, 0, 0, 0, 0 })[0]);
	}

	[Fact]
	public void Hit_points_take_the_full_die_then_the_fixed_value()
	{
		Assert.Equal(12, CharacterMath.MaxHitPoints(10, 1, 2));
		//	Fighter level 3 with Con +2: 10 + 2, then (6 + 2) twice
		Assert.Equal(28, CharacterMath.MaxHitPoints(10, 3, 2));
		//	At least 1 per level
		Assert.Equal(3, CharacterMath.MaxHitPoints(6, 3, -5));
	}

	[Fact]
	public void Armor_class_uses_armor_shield_and_unarmored_defense()
	{
		var leather = new WornArmor(ArmorCategory.Light, 11, true, null);
		var scale = new WornArmor(ArmorCategory.Medium, 14, true, 2);
		var chain = new WornArmor(ArmorCategory.Heavy, 16, false, null);
		var shield = new WornArmor(ArmorCategory.Shield, 2, false, null);

		Assert.Equal(14, CharacterMath.ArmorClass(new[] { leather }, 16, 10, 10, null));
		Assert.Equal(16, CharacterMath.ArmorClass(new[] { scale }, 18, 10, 10, null));
		Assert.Equal(18, CharacterMath.ArmorClass(new[] { chain, shield }, 18, 10, 10, null));
		Assert.Equal(12, CharacterMath.ArmorClass(Array.Empty<WornArmor>(), 14, 10, 10, null));
		Assert.Equal(15, CharacterMath.ArmorClass(Array.Empty<WornArmor>(), 14, 16, 10, "barbarian"));
		Assert.Equal(17, CharacterMath.ArmorClass(new[] { shield }, 14, 16, 10, "barbarian"));
		Assert.Equal(15, CharacterMath.ArmorClass(Array.Empty<WornArmor>(), 14, 10, 16, "monk"));
		Assert.Equal(14, CharacterMath.ArmorClass(new[] { shield }, 14, 10, 16, "monk"));
	}

	[Fact]
	public void Spells_are_read_from_the_progression_tables_in_both_languages()
	{
		Assert.Equal(new SpellAllowance(3, 4, 1), CharacterMath.Spells(Table("wizard", RulesetVersion.Dnd5e_2024), 1, 3, false));
		Assert.Equal(new SpellAllowance(3, 4, 1), CharacterMath.Spells(Table("wizard", RulesetVersion.Dnd5e_2024, LanguageCode.It), 1, 3, false));
		Assert.Equal(new SpellAllowance(4, 9, 3), CharacterMath.Spells(Table("wizard", RulesetVersion.Dnd5e_2024), 5, 3, false));

		//	2014 wizard: no prepared column, so modifier + level
		Assert.Equal(new SpellAllowance(3, 4, 1), CharacterMath.Spells(Table("wizard", RulesetVersion.Dnd5e_2014), 1, 3, false));

		//	Warlock: slot level column
		var warlock = CharacterMath.Spells(Table("warlock", RulesetVersion.Dnd5e_2014), 5, 3, false);
		Assert.Equal(3, warlock.MaxSpellLevel);
		Assert.Equal(CharacterMath.Spells(Table("warlock", RulesetVersion.Dnd5e_2014, LanguageCode.It), 5, 3, false), warlock);
		Assert.Equal(2, CharacterMath.Spells(Table("warlock", RulesetVersion.Dnd5e_2024), 3, 3, false).MaxSpellLevel);

		//	2014 paladin: no spells at level 1, then modifier + half the level
		Assert.True(CharacterMath.Spells(Table("paladin", RulesetVersion.Dnd5e_2014), 1, 3, true).IsNone);
		Assert.Equal(new SpellAllowance(0, 4, 1), CharacterMath.Spells(Table("paladin", RulesetVersion.Dnd5e_2014), 2, 3, true));

		//	2014 ranger: spells known column
		Assert.Equal(new SpellAllowance(0, 2, 1), CharacterMath.Spells(Table("ranger", RulesetVersion.Dnd5e_2014), 2, 2, false));
		Assert.Equal(new SpellAllowance(0, 2, 1), CharacterMath.Spells(Table("ranger", RulesetVersion.Dnd5e_2024), 1, 2, false));

		//	No spellcasting
		Assert.True(CharacterMath.Spells(Table("fighter", RulesetVersion.Dnd5e_2024), 5, 0, false).IsNone);
		Assert.True(CharacterMath.Spells(null, 1, 0, false).IsNone);
	}
}
