using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Localization;

namespace RealmForge.Tests;

public class FeatPrerequisiteFormatterTests
{
	[Fact]
	public void Empty_prerequisites_produce_null()
	{
		Assert.Null(FeatPrerequisiteFormatter.Format(new FeatPrerequisiteDto(), null, RulesetVersion.Dnd5e_2024, LanguageCode.En));
	}

	[Theory]
	[InlineData(LanguageCode.En, "Level 4+, Strength or Dexterity 13+")]
	[InlineData(LanguageCode.It, "Livello 4+, Forza o Destrezza 13+")]
	public void Level_and_two_abilities(LanguageCode lang, string expected)
	{
		var p = new FeatPrerequisiteDto
		{
			MinimumLevel = 4,
			Abilities = new() { AbilityScore.Strength, AbilityScore.Dexterity },
			MinimumScore = 13
		};

		Assert.Equal(expected, FeatPrerequisiteFormatter.Format(p, null, RulesetVersion.Dnd5e_2024, lang));
	}

	[Theory]
	[InlineData(LanguageCode.En, "Level 4+; Intelligence, Wisdom, or Charisma 13+")]
	[InlineData(LanguageCode.It, "Livello 4+; Intelligenza, Saggezza o Carisma 13+")]
	public void Three_abilities_use_semicolon(LanguageCode lang, string expected)
	{
		var p = new FeatPrerequisiteDto
		{
			MinimumLevel = 4,
			Abilities = new() { AbilityScore.Intelligence, AbilityScore.Wisdom, AbilityScore.Charisma },
			MinimumScore = 13
		};

		Assert.Equal(expected, FeatPrerequisiteFormatter.Format(p, null, RulesetVersion.Dnd5e_2024, lang));
	}

	[Theory]
	[InlineData(RulesetVersion.Dnd5e_2014, "Proficiency with medium armor")]
	[InlineData(RulesetVersion.Dnd5e_2024, "Medium Armor Training")]
	public void Feature_wording_depends_on_ruleset(RulesetVersion ruleset, string expected)
	{
		var p = new FeatPrerequisiteDto { Feature = FeatFeatureRequirement.MediumArmor };

		Assert.Equal(expected, FeatPrerequisiteFormatter.Format(p, null, ruleset, LanguageCode.En));
	}

	[Fact]
	public void Free_text_note_is_appended()
	{
		var p = new FeatPrerequisiteDto { MinimumLevel = 4 };

		Assert.Equal("Livello 4+, Elfo o Mezzelfo", FeatPrerequisiteFormatter.Format(p, "Elfo o Mezzelfo", RulesetVersion.Dnd5e_2024, LanguageCode.It));
	}
}
