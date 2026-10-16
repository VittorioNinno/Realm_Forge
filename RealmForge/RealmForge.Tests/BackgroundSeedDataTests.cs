using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

public class BackgroundSeedDataTests
{
	private static readonly IReadOnlyList<Background> Backgrounds = BackgroundSeeder.GetDefinitions();

	[Fact]
	public void Only_SRD_backgrounds_are_seeded()
	{
		//	SRD 5.1 contains a single background (Acolyte); SRD 5.2 adds Criminal, Sage and Soldier
		var acolyte = Assert.Single(Backgrounds, b => b.Ruleset == RulesetVersion.Dnd5e_2014);
		Assert.Equal(ContentSource.Srd51, acolyte.Source);
		Assert.True(Backgrounds.Count(b => b.Ruleset == RulesetVersion.Dnd5e_2024) <= 4);
	}

	[Fact]
	public void Ids_are_unique_and_identical_on_every_build()
	{
		BackgroundSeeder.EnsureUniqueIds(Backgrounds);

		var first = Backgrounds.SelectMany(b => b.Translations.Select(t => t.Id).Prepend(b.Id)).ToList();
		var second = BackgroundSeeder.GetDefinitions().SelectMany(b => b.Translations.Select(t => t.Id).Prepend(b.Id)).ToList();
		Assert.Equal(first, second);
	}

	[Fact]
	public void Every_background_is_official_and_has_both_languages()
	{
		foreach (var background in Backgrounds)
		{
			Assert.True(background.IsOfficialSRD, $"{background.Id} is not marked as SRD");

			foreach (var lang in new[] { LanguageCode.It, LanguageCode.En })
			{
				var tr = Assert.Single(background.Translations, t => t.Language == lang);
				Assert.False(string.IsNullOrWhiteSpace(tr.Name), $"{background.Id} has no {lang} name");
				Assert.False(string.IsNullOrWhiteSpace(tr.Description), $"{background.Id} has no {lang} description");
			}
		}
	}

	[Fact]
	public void Characteristic_tables_have_the_same_size_in_both_languages()
	{
		foreach (var background in Backgrounds)
		{
			var it = background.Translations.Single(t => t.Language == LanguageCode.It);
			var en = background.Translations.Single(t => t.Language == LanguageCode.En);

			Assert.Equal(en.PersonalityTraits.Count, it.PersonalityTraits.Count);
			Assert.Equal(en.Ideals.Count, it.Ideals.Count);
			Assert.Equal(en.Bonds.Count, it.Bonds.Count);
			Assert.Equal(en.Flaws.Count, it.Flaws.Count);
		}
	}

	[Fact]
	public void Origin_feats_exist_in_the_feat_seed_data()
	{
		var featIds = FeatSeeder.GetDefinitions().Select(f => f.Id).ToHashSet();

		foreach (var background in Backgrounds.Where(b => b.OriginFeatId.HasValue))
		{
			Assert.Contains(background.OriginFeatId!.Value, featIds);
		}
	}

	[Fact]
	public void Backgrounds_2024_have_three_abilities_and_an_origin_feat()
	{
		foreach (var background in Backgrounds.Where(b => b.Ruleset == RulesetVersion.Dnd5e_2024))
		{
			Assert.Equal(3, background.AbilityOptions.Distinct().Count());
			Assert.NotNull(background.OriginFeatId);
		}
	}
}
