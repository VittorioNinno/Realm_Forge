using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Awaken (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Awaken2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "awaken");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "awaken", "en"),
					Language = LanguageCode.En,
					Name = "Awaken",
					CastingTime = "8 hours",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "an agate worth 1,000+ GP, which the spell consumes",
					Description = "You spend the casting time tracing magical pathways within a precious gemstone, and then touch the target. The target must be either a Beast or Plant creature with an Intelligence of 3 or less or a natural plant that isn't a creature. The target gains an Intelligence of 10 and the ability to speak one language you know. If the target is a natural plant, it becomes a Plant creature and gains the ability to move its limbs, roots, vines, creepers, and so forth, and it gains senses similar to a human's. The GM chooses statistics appropriate for the awakened Plant, such as the statistics for the **Awakened Shrub** or **Awakened Tree** in \"Monsters.\"\n\nThe awakened target has the Charmed condition for 30 days or until you or your allies deal damage to it. When that condition ends, the awakened creature chooses its attitude toward you.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "awaken", "it"),
					Language = LanguageCode.It,
					Name = "Risveglio",
					CastingTime = "8 ore",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "un'agata del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore trascorre il tempo di lancio tracciando sentieri magici all'interno di una gemma preziosa, poi tocca il bersaglio. Il bersaglio deve essere una creatura bestia o vegetale con Intelligenza pari o inferiore a 3, oppure una pianta naturale che non sia una creatura. Il bersaglio ottiene un punteggio di Intelligenza di 10 e la capacità di parlare un linguaggio conosciuto dall'incantatore. Se il bersaglio è una pianta naturale, diventa una creatura vegetale e ottiene la capacità di muovere rami, radici, viticci, rampicanti e così via, oltre a sensi simili a quelli di un umano. Il DM sceglie statistiche appropriate per il vegetale risvegliato, come quelle dell'**arbusto risvegliato** o dell'**albero risvegliato** del capitolo \"Mostri\" dell'SRD.\n\nIl bersaglio risvegliato è affascinato per 30 giorni o finché l'incantatore o i suoi alleati non gli infliggono danni. Quando quella condizione termina, la creatura risvegliata sceglie quale atteggiamento assumere nei confronti dell'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
