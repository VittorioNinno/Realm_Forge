using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

public class SpeciesSeedDataTests
{
	private static readonly IReadOnlyList<Species> Species = SpeciesSeeder.GetDefinitions();

	[Fact]
	public void All_seeder_files_are_discovered()
	{
		Assert.Equal(19, Species.Count);
		Assert.Equal(9, Species.Count(s => s.Ruleset == RulesetVersion.Dnd5e_2014));
		Assert.Equal(10, Species.Count(s => s.Ruleset == RulesetVersion.Dnd5e_2024));
	}

	[Fact]
	public void Ids_are_unique()
	{
		SpeciesSeeder.EnsureUniqueIds(Species);
	}

	[Fact]
	public void Ids_are_identical_on_every_build()
	{
		//	Without stable ids the startup sync would delete and recreate every trait on each restart
		Assert.Equal(AllIds(Species), AllIds(SpeciesSeeder.GetDefinitions()));
	}

	[Fact]
	public void Every_row_is_official_and_has_both_languages()
	{
		foreach (var species in Species)
		{
			AssertOfficialAndBilingual(species.IsOfficialSRD, species.Translations.Select(t => (t.Language, t.Name)), $"species {species.Id}");

			foreach (var trait in species.Traits)
			{
				AssertOfficialAndBilingual(trait.IsOfficialSRD, trait.Translations.Select(t => (t.Language, t.Name)), $"trait {trait.Id}");
			}

			foreach (var sub in species.Subspecies)
			{
				AssertOfficialAndBilingual(sub.IsOfficialSRD, sub.Translations.Select(t => (t.Language, t.Name)), $"subspecies {sub.Id}");

				foreach (var trait in sub.Traits)
				{
					AssertOfficialAndBilingual(trait.IsOfficialSRD, trait.Translations.Select(t => (t.Language, t.Name)), $"trait {trait.Id}");
				}
			}
		}
	}

	private static void AssertOfficialAndBilingual(bool isOfficial, IEnumerable<(LanguageCode Language, string Name)> translations, string what)
	{
		Assert.True(isOfficial, $"{what} is not marked as SRD");
		var list = translations.ToList();

		foreach (var lang in new[] { LanguageCode.It, LanguageCode.En })
		{
			var tr = Assert.Single(list, t => t.Language == lang);
			Assert.False(string.IsNullOrWhiteSpace(tr.Name), $"{what} has no {lang} name");
		}
	}

	private static List<Guid> AllIds(IEnumerable<Species> species) =>
		species.SelectMany(s =>
			new[] { s.Id }
				.Concat(s.Translations.Select(t => t.Id))
				.Concat(s.Traits.SelectMany(t => t.Translations.Select(x => x.Id).Prepend(t.Id)))
				.Concat(s.Subspecies.SelectMany(sub =>
					sub.Translations.Select(t => t.Id)
						.Prepend(sub.Id)
						.Concat(sub.Traits.SelectMany(t => t.Translations.Select(x => x.Id).Prepend(t.Id))))))
		.ToList();
}
