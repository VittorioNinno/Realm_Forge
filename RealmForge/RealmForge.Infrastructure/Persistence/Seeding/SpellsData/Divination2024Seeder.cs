using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Divination (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Divination2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divination");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divination", "en"),
					Language = LanguageCode.En,
					Name = "Divination",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "incense worth 25+ GP, which the spell consumes",
					Description = "This spell puts you in contact with a god or a god's servants. You ask one question about a specific goal, event, or activity to occur within 7 days. The GM offers a truthful reply, which might be a short phrase or cryptic rhyme. The spell doesn't account for circumstances that might change the answer, such as the casting of other spells.\n\nIf you cast the spell more than once before finishing a Long Rest, there is a cumulative 25 percent chance for each casting after the first that you get no answer.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "divination", "it"),
					Language = LanguageCode.It,
					Name = "Divinazione",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "incenso del valore di almeno 25 mo, che l'incantesimo consuma",
					Description = "Questo incantesimo mette l'incantatore in contatto con un dio o con i servitori di un dio. L'incantatore pone una domanda su un obiettivo, un evento o un'attività specifici che si verificheranno entro 7 giorni. Il DM fornisce una risposta veritiera, che potrebbe consistere in una breve frase o in una rima criptica. L'incantesimo non tiene conto delle circostanze che potrebbero cambiare la risposta, come il lancio di altri incantesimi.\n\nSe l'incantatore lancia l'incantesimo più di una volta prima di aver terminato un riposo lungo, c'è una probabilità cumulativa del 25 per cento per ogni lancio successivo al primo di non ricevere alcuna risposta.",
					HigherLevels = null
				}
			}
		};
	}
}
