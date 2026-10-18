using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Foresight (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Foresight2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "foresight");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "foresight", "en"),
					Language = LanguageCode.En,
					Name = "Foresight",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = "a hummingbird feather",
					Description = "You touch a willing creature and bestow a limited ability to see into the immediate future. For the duration, the target can't be surprised and has advantage on attack rolls, ability checks, and saving throws. Additionally, other creatures have disadvantage on attack rolls against the target for the duration.\n\nThis spell immediately ends if you cast it again before its duration ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "foresight", "it"),
					Language = LanguageCode.It,
					Name = "Previsione",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = "una piuma di colibrì",
					Description = "L'incantatore tocca una creatura consenziente e le conferisce una limitata capacità di vedere nell'immediato futuro. Per la durata, il bersaglio non può essere sorpreso e dispone di vantaggio ai tiri per colpire, alle prove di caratteristica e ai tiri salvezza. Inoltre, per la durata, le altre creature subiscono svantaggio ai tiri per colpire contro il bersaglio.\n\nQuesto incantesimo termina immediatamente se l'incantatore lo lancia di nuovo prima che la sua durata sia terminata.",
					HigherLevels = null
				}
			}
		};
	}
}
