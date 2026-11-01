using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

///	<summary>
///	Homebrew rule modules: an extra ability (Fortuna) inside the ability method and the improvements, a resource
///	with uses from it, numbers, training and defences; the modules apply when chosen or when the campaign has them.
///	</summary>
public class RuleModulesTests
{
	private static readonly Guid FortunaId = Guid.Parse("00000000-0000-0000-0000-00000000f001");

	private static ContextModule Fortuna(int arrayValue = 10, int points = 0) => new(FortunaId, "Fortuna", new List<RuleEffect>
	{
		new() { Kind = RuleEffectKind.ExtraAbility, Key = "luck", NameIt = "Fortuna", NameEn = "Luck", ShortIt = "FOR", ShortEn = "LCK", Value = arrayValue, Points = points, Save = true },
		new() { Kind = RuleEffectKind.Resource, NameIt = "Punti fortuna", NameEn = "Luck points", Uses = ResourceUses.AbilityModifier, AbilityKey = "luck", Reset = ResourceReset.LongRest },
		new() { Kind = RuleEffectKind.ArmorClass, Value = 1 },
		new() { Kind = RuleEffectKind.SkillProficiency, Skill = Skill.Stealth },
		new() { Kind = RuleEffectKind.Resistance, DamageType = DamageType.Fire },
		new() { Kind = RuleEffectKind.Initiative, Value = 2, Level = 5 }
	});

	private static ContextClass Fighter() => new(Guid.Parse("00000000-0000-0000-0000-0000000000c1"), "fighter", "fighter", 10, new List<AbilityScore> { AbilityScore.Strength },
		new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Constitution }, 2, Enum.GetValues<Skill>().ToList(), CasterProgression.None, null, null, 4, null,
		new List<ContextSubclass>(), ContextLoadout.Empty);

	private static CharacterContextDto Context(RulesetVersion ruleset, ContextClass fighter, params ContextModule[] modules) => new(
		ruleset,
		new List<ContextClass> { fighter },
		new List<ContextSpecies> { new(Guid.Parse("00000000-0000-0000-0000-0000000000a1"), "Human", null, new List<CreatureSize> { CreatureSize.Medium }, 30, new List<ContextSubspecies>()) },
		new List<ContextBackground> { new(Guid.Parse("00000000-0000-0000-0000-0000000000b1"), "Sage", "sage", new List<AbilityScore> { AbilityScore.Constitution, AbilityScore.Intelligence, AbilityScore.Wisdom }, new List<Skill> { Skill.Arcana, Skill.History }, null, 0, ContextLoadout.Empty) },
		new List<ContextFeat>(),
		new List<ContextSpell>(),
		new List<ContextItem>(),
		modules.ToList());

	private static CharacterInput Input(RulesetVersion ruleset, CharacterContextDto context, int levels, bool chooseModule = true)
	{
		var input = new CharacterInput
		{
			Name = "Test",
			Ruleset = ruleset,
			SpeciesId = context.Species[0].Id,
			BackgroundId = context.Backgrounds[0].Id,
			Build = new CharacterBuild
			{
				BaseScores = new List<int> { 10, 14, 13, 12, 10, 8 },
				ExtraScores = new Dictionary<string, int> { ["luck"] = 15 },
				BonusMode = AbilityBonusMode.TwoAndOne,
				BonusChoices = ruleset == RulesetVersion.Dnd5e_2024 ? new List<AbilityScore> { AbilityScore.Intelligence, AbilityScore.Constitution } : new List<AbilityScore>()
			}
		};
		if (chooseModule)
		{
			input.Build.ModuleIds.Add(FortunaId);
		}
		input.Build.Classes.Add(new CharacterClassBuild { ClassId = context.Classes[0].Id });
		for (var i = 0; i < levels; i++)
		{
			input.Build.Levels.Add(new CharacterLevelBuild { ClassId = context.Classes[0].Id });
		}
		return input;
	}

	[Fact]
	public void Fortuna_enters_the_standard_array_and_gives_its_resource()
	{
		var fighter = Fighter();
		var context = Context(RulesetVersion.Dnd5e_2024, fighter, Fortuna());
		var computed = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2024, context, 1), context);

		Assert.DoesNotContain(computed.Issues, i => i.Code == IssueCodes.BaseScores);
		var luck = Assert.Single(computed.ExtraAbilities);
		Assert.Equal(15, luck.Score);
		Assert.Equal(2, luck.Modifier);
		Assert.Equal("Fortuna", luck.Definition.Name(LanguageCode.It));
		Assert.Equal(2, luck.SaveBonus);
		var resource = Assert.Single(CharacterResources.For(computed, LanguageCode.It), r => r.Key.StartsWith("module:"));
		Assert.Equal(("Punti fortuna", 2, ResourceReset.LongRest), (resource.Name, resource.Maximum, resource.Reset));
		Assert.Contains(Skill.Stealth, computed.SkillProficiencies);
		Assert.Contains(DamageType.Fire, computed.Resistances);
	}

	[Fact]
	public void A_module_applies_when_chosen_or_when_the_campaign_has_it()
	{
		var fighter = Fighter();
		var context = Context(RulesetVersion.Dnd5e_2024, fighter, Fortuna());
		var with = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2024, context, 1), context);

		var without = Input(RulesetVersion.Dnd5e_2024, context, 1, chooseModule: false);
		without.Build.ExtraScores.Clear();
		without.Build.BaseScores = new List<int> { 15, 14, 13, 12, 10, 8 };
		var plain = CharacterCalculator.Compute(without, context);
		Assert.Empty(plain.ExtraAbilities);
		Assert.DoesNotContain(plain.Issues, i => i.Code == IssueCodes.BaseScores);

		//	Same scores but the module of the campaign: Fortuna is back and the armor class has its +1
		var campaign = Input(RulesetVersion.Dnd5e_2024, context, 1, chooseModule: false);
		campaign.CampaignModuleIds.Add(FortunaId);
		var fromCampaign = CharacterCalculator.Compute(campaign, context);
		Assert.Single(fromCampaign.ExtraAbilities);
		Assert.Equal(with.ArmorClass, fromCampaign.ArmorClass);
		Assert.Equal(plain.ArmorClass + 1, fromCampaign.ArmorClass);
	}

	[Fact]
	public void Effects_unlock_at_their_level()
	{
		var fighter = Fighter();
		var context = Context(RulesetVersion.Dnd5e_2014, fighter, Fortuna());
		var low = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2014, context, 4), context);
		var high = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2014, context, 5), context);
		Assert.Equal(2, high.Initiative - low.Initiative);
	}

	[Fact]
	public void The_2014_improvement_can_raise_the_added_ability()
	{
		var fighter = Fighter();
		var context = Context(RulesetVersion.Dnd5e_2014, fighter, Fortuna());
		var input = Input(RulesetVersion.Dnd5e_2014, context, 4);
		input.Build.Levels[3].ExtraIncreases = new List<string> { "luck", "luck" };
		var computed = CharacterCalculator.Compute(input, context);
		Assert.DoesNotContain(computed.Issues, i => i.Code is IssueCodes.Improvement or IssueCodes.ImprovementMissing);
		Assert.Equal(17, computed.ExtraAbilities[0].Score);

		input.Build.Levels[3].ExtraIncreases = new List<string> { "luck" };
		Assert.Contains(CharacterCalculator.Compute(input, context).Issues, i => i.Code == IssueCodes.Improvement);
	}

	[Fact]
	public void Point_buy_counts_the_added_ability_and_the_module_points()
	{
		var fighter = Fighter();
		var context = Context(RulesetVersion.Dnd5e_2024, fighter, Fortuna(points: 3));
		var input = Input(RulesetVersion.Dnd5e_2024, context, 1);
		input.Build.AbilityMethod = AbilityMethod.PointBuy;
		//	27 points on the six, 3 more for Fortuna 11
		input.Build.BaseScores = new List<int> { 15, 15, 15, 8, 8, 8 };
		input.Build.ExtraScores["luck"] = 11;
		Assert.DoesNotContain(CharacterCalculator.Compute(input, context).Issues, i => i.Code == IssueCodes.BaseScores);
		input.Build.ExtraScores["luck"] = 12;
		Assert.Contains(CharacterCalculator.Compute(input, context).Issues, i => i.Code == IssueCodes.BaseScores);
	}

	[Fact]
	public void Invalid_effects_are_refused()
	{
		Assert.Null(RuleEffectRules.Validate(Fortuna().Effects));
		Assert.Equal("Skill", RuleEffectRules.Validate(new[] { new RuleEffect { Kind = RuleEffectKind.SkillProficiency } }));
		Assert.Equal("ExtraAbility", RuleEffectRules.Validate(new[]
		{
			new RuleEffect { Kind = RuleEffectKind.ExtraAbility, Key = "luck", NameIt = "Fortuna" },
			new RuleEffect { Kind = RuleEffectKind.ExtraAbility, Key = "LUCK", NameIt = "Fortuna 2" }
		}));
		Assert.Equal("Text", RuleEffectRules.Validate(new[] { new RuleEffect { Kind = RuleEffectKind.ArmorTraining, Text = "mithral" } }));
	}

	[Fact]
	public void Homebrew_species_and_class_features_apply_their_effects_from_their_level()
	{
		var fighter = Fighter() with
		{
			Effects = new List<RuleEffect>
			{
				new() { Kind = RuleEffectKind.ArmorClass, Value = 1, Level = 1 },
				new() { Kind = RuleEffectKind.Initiative, Value = 3, Level = 3 }
			}
		};
		var context = Context(RulesetVersion.Dnd5e_2024, fighter, Fortuna());
		context = context with
		{
			Species = new List<ContextSpecies> { context.Species[0] with { Effects = new List<RuleEffect> { new() { Kind = RuleEffectKind.Darkvision, Value = 60 } } } }
		};

		var first = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2024, context, 1, chooseModule: false), context);
		var third = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2024, context, 3, chooseModule: false), context);
		var plain = Context(RulesetVersion.Dnd5e_2024, Fighter(), Fortuna());
		var baseline = CharacterCalculator.Compute(Input(RulesetVersion.Dnd5e_2024, plain, 3, chooseModule: false), plain);

		Assert.Equal(60, first.Darkvision);
		Assert.Equal(baseline.ArmorClass + 1, third.ArmorClass);
		Assert.Equal(first.Initiative, baseline.Initiative);
		Assert.Equal(baseline.Initiative + 3, third.Initiative);
	}
}
