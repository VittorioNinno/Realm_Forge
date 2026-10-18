using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Transport via Plants (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TransportViaPlants2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "transport-via-plants");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "transport-via-plants", "en"),
					Language = LanguageCode.En,
					Name = "Transport via Plants",
					CastingTime = "Action",
					Range = "10 feet",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "This spell creates a magical link between a Large or larger inanimate plant within range and another plant, at any distance, on the same plane of existence. You must have seen or touched the destination plant at least once before. For the duration, any creature can step into the target plant and exit from the destination plant by using 5 feet of movement.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "transport-via-plants", "it"),
					Language = LanguageCode.It,
					Name = "Trasporto Vegetale",
					CastingTime = "Azione",
					Range = "3 metri",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Questo incantesimo crea un collegamento magico tra una pianta inanimata di taglia Grande o superiore entro gittata e un'altra pianta, a qualsiasi distanza, sullo stesso piano di esistenza. L'incantatore deve aver visto o toccato la pianta di destinazione almeno una volta. Per la durata, qualsiasi creatura può entrare nella pianta bersaglio e uscire dalla pianta di destinazione usando 1,5 metri di movimento.",
					HigherLevels = null
				}
			}
		};
	}
}
