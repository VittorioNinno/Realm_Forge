using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

public class AutomationRulesTests
{
	[Theory]
	[InlineData("1d8+MOD", 3, 2, 5, "1d8+3")]
	[InlineData("1d8 + MOD", -1, 2, 5, "1d8-1")]
	[InlineData("PBd4", 0, 3, 5, "3d4")]
	[InlineData("1d10+LV", 0, 2, 7, "1d10+7")]
	[InlineData("2d6", 4, 2, 5, "2d6")]
	public void The_words_of_a_roll_become_the_numbers_of_the_character(string roll, int modifier, int proficiency, int level, string expected) =>
		Assert.Equal(expected, AutomationRules.Resolve(roll, modifier, proficiency, level));

	[Theory]
	[InlineData("2d6+MOD", true)]
	[InlineData("PBd6", true)]
	[InlineData("fire", false)]
	[InlineData("", false)]
	[InlineData(null, false)]
	public void A_roll_must_read_as_dice(string? roll, bool valid) => Assert.Equal(valid, AutomationRules.Valid(roll));

	[Fact]
	public void An_automation_needs_a_name_dice_and_a_resource_of_its_own_list()
	{
		var resource = new RuleEffect { Kind = RuleEffectKind.Resource, NameEn = "Embers", NameIt = "Braci", Value = 3 };
		var strike = new RuleEffect { Kind = RuleEffectKind.OnHitDamage, NameIt = "Colpo ardente", Roll = "1d6", DamageType = DamageType.Fire, Resource = "Embers" };
		Assert.Null(RuleEffectRules.Validate(new[] { resource, strike }));

		Assert.Equal("Resource", RuleEffectRules.Validate(new[] { strike }));
		Assert.Equal("Roll", RuleEffectRules.Validate(new[] { new RuleEffect { Kind = RuleEffectKind.OnHitDamage, NameIt = "Nulla", Roll = "molto" } }));
		Assert.Equal("Name", RuleEffectRules.Validate(new[] { new RuleEffect { Kind = RuleEffectKind.Ability, Roll = "1d8" } }));
		Assert.Equal("Invalid", RuleEffectRules.Validate(new[] { new RuleEffect { Kind = RuleEffectKind.Ability, NameEn = "Glow", Outcome = "explode" } }));
		Assert.Null(RuleEffectRules.Validate(new[] { new RuleEffect { Kind = RuleEffectKind.Ability, NameEn = "Glow", Slot = FeatureSlot.Bonus, Roll = "1d8+MOD", Outcome = "heal" } }));
	}
}
