using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Foresight (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Foresight2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "foresight");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 9,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "foresight", "en"),
					Language = LanguageCode.En,
					Name = "Foresight",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = "a hummingbird feather",
					Description = "You touch a willing creature and bestow a limited ability to see into the immediate future. For the duration, the target has Advantage on D20 Tests, and other creatures have Disadvantage on attack rolls against it. The spell ends early if you cast it again.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "foresight", "it"),
					Language = LanguageCode.It,
					Name = "Previsione",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = "una piuma di colibrì",
					Description = "L'incantatore tocca una creatura consenziente e le conferisce una capacità limitata di vedere nell'immediato futuro. Per la durata, il bersaglio dispone di vantaggio alle prove con d20, e le altre creature subiscono svantaggio ai tiri per colpire contro di esso. L'incantesimo termina prima del tempo se l'incantatore lo lancia di nuovo.",
					HigherLevels = null
				}
			}
		};
	}
}
