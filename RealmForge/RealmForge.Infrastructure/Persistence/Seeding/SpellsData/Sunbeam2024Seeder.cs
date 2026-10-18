using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sunbeam (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Sunbeam2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sunbeam");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sunbeam", "en"),
					Language = LanguageCode.En,
					Name = "Sunbeam",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a magnifying glass",
					Description = "You launch a sunbeam in a 5-foot-wide, 60-foot-long Line. Each creature in the Line makes a Constitution saving throw. On a failed save, a creature takes 6d8 Radiant damage and has the Blinded condition until the start of your next turn. On a successful save, it takes half as much damage only.\n\nUntil the spell ends, you can take a Magic action to create a new Line of radiance.\n\nFor the duration, a mote of brilliant radiance shines above you. It sheds Bright Light in a 30-foot radius and Dim Light for an additional 30 feet. This light is sunlight.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sunbeam", "it"),
					Language = LanguageCode.It,
					Name = "Bagliore Solare",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una lente d'ingrandimento",
					Description = "L'incantatore scaglia un raggio di sole in una linea larga 1,5 metri e lunga 18 metri. Ogni creatura nella linea effettua un tiro salvezza su Costituzione. Se lo fallisce, una creatura subisce 6d8 danni radiosi ed è accecata fino all'inizio del turno successivo dell'incantatore. Se lo supera, subisce soltanto la metà dei danni.\n\nFinché l'incantesimo non termina, l'incantatore può effettuare un'azione di Magia per creare una nuova linea di radiosità.\n\nPer la durata, un granello di splendente radiosità brilla sopra l'incantatore. Proietta luce intensa in un raggio di 9 metri e luce fioca per altri 9 metri. Questa luce è luce solare.",
					HigherLevels = null
				}
			}
		};
	}
}
