using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Transport via Plants (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TransportViaPlants2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "transport-via-plants");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "transport-via-plants", "en"),
					Language = LanguageCode.En,
					Name = "Transport via Plants",
					CastingTime = "1 action",
					Range = "10 feet",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "This spell creates a magical link between a Large or larger inanimate plant within range and another plant, at any distance, on the same plane of existence. You must have seen or touched the destination plant at least once before. For the duration, any creature can step into the target plant and exit from the destination plant by using 5 feet of movement.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "transport-via-plants", "it"),
					Language = LanguageCode.It,
					Name = "Trasporto Vegetale",
					CastingTime = "1 azione",
					Range = "3 metri",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "Questo incantesimo crea un collegamento magico tra un vegetale inanimato di taglia Grande o superiore entro gittata e un altro vegetale, a qualsiasi distanza, situato sullo stesso piano di esistenza. L'incantatore deve aver visto o toccato il vegetale di destinazione almeno una volta in precedenza. Per la durata, qualsiasi creatura può entrare nel vegetale bersaglio e uscire dal vegetale di destinazione usando 1,5 metri di movimento.",
					HigherLevels = null
				}
			}
		};
	}
}
