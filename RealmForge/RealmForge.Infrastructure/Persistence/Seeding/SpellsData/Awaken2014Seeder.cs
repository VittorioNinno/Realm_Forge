using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Awaken (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Awaken2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "awaken");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "awaken", "en"),
					Language = LanguageCode.En,
					Name = "Awaken",
					CastingTime = "8 hours",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "an agate worth at least 1,000 gp, which the spell consumes",
					Description = "After spending the casting time tracing magical pathways within a precious gemstone, you touch a Huge or smaller beast or plant. The target must have either no Intelligence score or an Intelligence of 3 or less. The target gains an Intelligence of 10. The target also gains the ability to speak one language you know. If the target is a plant, it gains the ability to move its limbs, roots, vines, creepers, and so forth, and it gains senses similar to a human's. Your GM chooses statistics appropriate for the awakened plant, such as the statistics for the awakened shrub or the awakened tree.\n\nThe awakened beast or plant is charmed by you for 30 days or until you or your companions do anything harmful to it. When the charmed condition ends, the awakened creature chooses whether to remain friendly to you, based on how you treated it while it was charmed.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "awaken", "it"),
					Language = LanguageCode.It,
					Name = "Risveglio",
					CastingTime = "8 ore",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "un'agata del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "Dopo aver trascorso il tempo di lancio a tracciare percorsi magici all'interno di una gemma preziosa, l'incantatore tocca una bestia o un vegetale di taglia Enorme o inferiore. Il bersaglio deve essere privo di punteggio di Intelligenza o avere Intelligenza pari o inferiore a 3. Il bersaglio ottiene Intelligenza 10, oltre alla capacità di parlare un linguaggio conosciuto dall'incantatore. Se il bersaglio è un vegetale, ottiene la capacità di muovere rami, radici, viticci, rampicanti e così via, e acquisisce sensi simili a quelli di un umano. Il DM sceglie le statistiche appropriate per il vegetale risvegliato, come quelle dell'arbusto risvegliato o dell'albero risvegliato.\n\nLa bestia o il vegetale risvegliato è affascinato dall'incantatore per 30 giorni o finché l'incantatore o i suoi compagni non compiono qualcosa di dannoso nei suoi confronti. Quando la condizione di affascinato termina, la creatura risvegliata sceglie se restare amichevole nei confronti dell'incantatore, in base a come è stata trattata mentre era affascinata.",
					HigherLevels = null
				}
			}
		};
	}
}
