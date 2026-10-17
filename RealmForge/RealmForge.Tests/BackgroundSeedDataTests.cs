using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

public class BackgroundSeedDataTests
{
	private static readonly IReadOnlyList<Background> Backgrounds = BackgroundSeeder.GetDefinitions();

	[Fact]
	public void SRD_backgrounds_are_labelled_and_the_others_are_RealmForge_text()
	{
		//	SRD 5.1 contains a single background (Acolyte); every other 2014 background is text written for RealmForge
		var srd51 = Assert.Single(Backgrounds, b => b.Source == ContentSource.Srd51);
		Assert.Equal(Acolyte2014Seeder.BackgroundId, srd51.Id);
		Assert.All(Backgrounds.Where(b => b.Ruleset == RulesetVersion.Dnd5e_2014 && b.Id != srd51.Id),
			b => Assert.Equal(ContentSource.RealmForge, b.Source));
	}

	[Fact]
	public void Charlatan_has_its_proficiencies_and_tables()
	{
		var charlatan = Assert.Single(Backgrounds, b => b.Id == Charlatan2014Seeder.BackgroundId);
		Assert.Equal(new[] { Skill.Deception, Skill.SleightOfHand }, charlatan.SkillProficiencies);

		foreach (var tr in charlatan.Translations)
		{
			Assert.Equal((8, 6, 6, 6), (tr.PersonalityTraits.Count, tr.Ideals.Count, tr.Bonds.Count, tr.Flaws.Count));
			Assert.False(string.IsNullOrWhiteSpace(tr.ToolProficiencies));
			Assert.Contains("| 6 |", tr.Description);
		}
	}

	[Fact]
	public void Criminal_has_its_proficiencies_tables_and_spy_variant()
	{
		var criminal = Assert.Single(Backgrounds, b => b.Id == Criminal2014Seeder.BackgroundId);
		Assert.Equal(new[] { Skill.Deception, Skill.Stealth }, criminal.SkillProficiencies);
		Assert.Equal(ContentSource.RealmForge, criminal.Source);

		foreach (var tr in criminal.Translations)
		{
			Assert.Equal((8, 6, 6, 6), (tr.PersonalityTraits.Count, tr.Ideals.Count, tr.Bonds.Count, tr.Flaws.Count));
			Assert.Contains("| 8 |", tr.Description);
			Assert.Equal(3, tr.Equipment!.Split('\n').Length);
		}

		Assert.Contains("Variant: Spy", criminal.Translations.Single(t => t.Language == LanguageCode.En).Description);
		Assert.Contains("Variante: Spia", criminal.Translations.Single(t => t.Language == LanguageCode.It).Description);
	}

	[Fact]
	public void Entertainer_has_its_proficiencies_tables_and_gladiator_variant()
	{
		var entertainer = Assert.Single(Backgrounds, b => b.Id == Entertainer2014Seeder.BackgroundId);
		Assert.Equal(new[] { Skill.Acrobatics, Skill.Performance }, entertainer.SkillProficiencies);
		Assert.Equal(ContentSource.RealmForge, entertainer.Source);

		foreach (var tr in entertainer.Translations)
		{
			Assert.Equal((8, 6, 6, 6), (tr.PersonalityTraits.Count, tr.Ideals.Count, tr.Bonds.Count, tr.Flaws.Count));
			Assert.Contains("| 10 |", tr.Description);
			Assert.Equal(4, tr.Equipment!.Split('\n').Length);
		}

		Assert.Contains("Variant: Gladiator", entertainer.Translations.Single(t => t.Language == LanguageCode.En).Description);
		Assert.Contains("Variante: Gladiatore", entertainer.Translations.Single(t => t.Language == LanguageCode.It).Description);
	}

	[Fact]
	public void Folk_hero_has_its_proficiencies_and_tables()
	{
		var folkHero = Assert.Single(Backgrounds, b => b.Id == FolkHero2014Seeder.BackgroundId);
		Assert.Equal(new[] { Skill.AnimalHandling, Skill.Survival }, folkHero.SkillProficiencies);
		Assert.Equal(ContentSource.RealmForge, folkHero.Source);

		foreach (var tr in folkHero.Translations)
		{
			Assert.Equal((8, 6, 6, 6), (tr.PersonalityTraits.Count, tr.Ideals.Count, tr.Bonds.Count, tr.Flaws.Count));
			Assert.Contains("| 10 |", tr.Description);
			Assert.Equal(5, tr.Equipment!.Split('\n').Length);
		}
	}

	[Fact]
	public void Guild_artisan_has_its_proficiencies_and_tables()
	{
		var artisan = Assert.Single(Backgrounds, b => b.Id == GuildArtisan2014Seeder.BackgroundId);
		Assert.Equal(new[] { Skill.Insight, Skill.Persuasion }, artisan.SkillProficiencies);
		Assert.Equal(ContentSource.RealmForge, artisan.Source);

		foreach (var tr in artisan.Translations)
		{
			Assert.Equal((8, 6, 6, 6), (tr.PersonalityTraits.Count, tr.Ideals.Count, tr.Bonds.Count, tr.Flaws.Count));
			Assert.Contains("| 20 |", tr.Description);
			Assert.False(string.IsNullOrWhiteSpace(tr.Languages));
			Assert.Equal(4, tr.Equipment!.Split('\n').Length);
		}
	}

	[Fact]
	public void Hermit_has_its_proficiencies_and_tables()
	{
		var hermit = Assert.Single(Backgrounds, b => b.Id == Hermit2014Seeder.BackgroundId);
		Assert.Equal(new[] { Skill.Medicine, Skill.Religion }, hermit.SkillProficiencies);
		Assert.Equal(ContentSource.RealmForge, hermit.Source);

		foreach (var tr in hermit.Translations)
		{
			Assert.Equal((8, 6, 6, 6), (tr.PersonalityTraits.Count, tr.Ideals.Count, tr.Bonds.Count, tr.Flaws.Count));
			Assert.Contains("| 8 |", tr.Description);
			Assert.False(string.IsNullOrWhiteSpace(tr.Languages));
			Assert.Equal(5, tr.Equipment!.Split('\n').Length);
		}
	}

	[Fact]
	public void Noble_has_its_proficiencies_and_variants()
	{
		var noble = Assert.Single(Backgrounds, b => b.Id == Noble2014Seeder.BackgroundId);
		Assert.Equal(new[] { Skill.History, Skill.Persuasion }, noble.SkillProficiencies);
		Assert.Equal(ContentSource.RealmForge, noble.Source);

		foreach (var tr in noble.Translations)
		{
			Assert.Equal((8, 6, 6, 6), (tr.PersonalityTraits.Count, tr.Ideals.Count, tr.Bonds.Count, tr.Flaws.Count));
			Assert.Equal(3, tr.Description.Split("\n### ").Length - 1);
			Assert.False(string.IsNullOrWhiteSpace(tr.Languages));
			Assert.Equal(4, tr.Equipment!.Split('\n').Length);
		}
	}

	[Fact]
	public void Outlander_has_its_proficiencies_and_tables()
	{
		var outlander = Assert.Single(Backgrounds, b => b.Id == Outlander2014Seeder.BackgroundId);
		Assert.Equal(new[] { Skill.Athletics, Skill.Survival }, outlander.SkillProficiencies);
		Assert.Equal(ContentSource.RealmForge, outlander.Source);

		foreach (var tr in outlander.Translations)
		{
			Assert.Equal((8, 6, 6, 6), (tr.PersonalityTraits.Count, tr.Ideals.Count, tr.Bonds.Count, tr.Flaws.Count));
			Assert.Contains("| 10 |", tr.Description);
			Assert.False(string.IsNullOrWhiteSpace(tr.Languages));
			Assert.Equal(5, tr.Equipment!.Split('\n').Length);
		}
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
