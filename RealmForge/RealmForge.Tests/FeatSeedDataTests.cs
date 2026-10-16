using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

public class FeatSeedDataTests
{
	private static readonly IReadOnlyList<RealmForge.Domain.Entities.Feat> Feats = FeatSeeder.GetDefinitions();

	[Fact]
	public void All_seeder_files_are_discovered()
	{
		//	117 feat seeders at the time of writing: 42 for 2014 and 75 for 2024
		Assert.Equal(117, Feats.Count);
		Assert.Equal(42, Feats.Count(f => f.Ruleset == RulesetVersion.Dnd5e_2014));
		Assert.Equal(75, Feats.Count(f => f.Ruleset == RulesetVersion.Dnd5e_2024));
	}

	[Fact]
	public void Ids_are_unique()
	{
		//	Throws when a feat or translation id is duplicated
		FeatSeeder.EnsureUniqueIds(Feats);
	}

	[Fact]
	public void Every_feat_is_official_and_has_both_languages()
	{
		foreach (var feat in Feats)
		{
			Assert.True(feat.IsOfficialSRD, $"{feat.Id} is not marked as SRD");

			foreach (var lang in new[] { LanguageCode.It, LanguageCode.En })
			{
				var tr = Assert.Single(feat.Translations, t => t.Language == lang);
				Assert.False(string.IsNullOrWhiteSpace(tr.Name), $"{feat.Id} has no {lang} name");
				Assert.False(string.IsNullOrWhiteSpace(tr.Description), $"{feat.Id} has no {lang} description");
			}
		}
	}

	//	Feats whose text comes from the System Reference Documents (CC BY 4.0)
	private static readonly string[] Srd51Feats = { "Grappler" };
	private static readonly string[] Srd52Feats =
	{
		"Alert", "Magic Initiate", "Savage Attacker", "Skilled", "Ability Score Improvement", "Grappler",
		"Archery", "Defense", "Great Weapon Fighting", "Two-Weapon Fighting",
		"Boon of Combat Prowess", "Boon of Dimensional Travel", "Boon of Fate", "Boon of Irresistible Offense",
		"Boon of Spell Recall", "Boon of the Night Spirit", "Boon of Truesight"
	};

	[Fact]
	public void SRD_feats_are_labelled_with_their_SRD_version()
	{
		foreach (var feat in Feats)
		{
			var name = feat.Translations.Single(t => t.Language == LanguageCode.En).Name;
			var expected = feat.Ruleset == RulesetVersion.Dnd5e_2014
				? (Srd51Feats.Contains(name) ? ContentSource.Srd51 : ContentSource.RealmForge)
				: (Srd52Feats.Contains(name) ? ContentSource.Srd52 : ContentSource.RealmForge);

			Assert.True(expected == feat.Source, $"{name} ({feat.Ruleset}) is {feat.Source}, expected {expected}");
		}

		Assert.Equal(1, Feats.Count(f => f.Source == ContentSource.Srd51));
		Assert.Equal(17, Feats.Count(f => f.Source == ContentSource.Srd52));
	}

	[Fact]
	public void Ability_prerequisites_always_have_a_minimum_score()
	{
		foreach (var feat in Feats.Where(f => f.PrerequisiteAbilities.Count > 0))
		{
			Assert.NotNull(feat.PrerequisiteMinimumScore);
		}
	}
}
