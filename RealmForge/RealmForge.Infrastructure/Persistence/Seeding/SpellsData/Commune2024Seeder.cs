using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Commune (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Commune2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "commune");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "commune", "en"),
					Language = LanguageCode.En,
					Name = "Commune",
					CastingTime = "1 minute",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = "incense",
					Description = "You contact a deity or a divine proxy and ask up to three questions that can be answered with yes or no. You must ask your questions before the spell ends. You receive a correct answer for each question.\n\nDivine beings aren't necessarily omniscient, so you might receive \"unclear\" as an answer if a question pertains to information that lies beyond the deity's knowledge. In a case where a one-word answer could be misleading or contrary to the deity's interests, the GM might offer a short phrase as an answer instead.\n\nIf you cast the spell more than once before finishing a Long Rest, there is a cumulative 25 percent chance for each casting after the first that you get no answer.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "commune", "it"),
					Language = LanguageCode.It,
					Name = "Comunione",
					CastingTime = "1 minuto",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = "incenso",
					Description = "L'incantatore contatta una divinità o un suo emissario divino e pone fino a tre domande a cui si può rispondere con un sì o con un no. Deve porre le sue domande prima che l'incantesimo termini. Riceve una risposta corretta a ogni domanda.\n\nGli esseri divini non sono necessariamente onniscienti, quindi l'incantatore potrebbe ricevere \"incerto\" come risposta, se una domanda riguarda informazioni che vanno oltre la conoscenza della divinità. Nel caso in cui una risposta di una sola parola possa risultare fuorviante o contraria agli interessi della divinità, il DM potrebbe invece fornire come risposta una breve frase.\n\nSe l'incantatore lancia l'incantesimo più di una volta prima di aver terminato un riposo lungo, c'è una probabilità cumulativa del 25 per cento per ogni lancio successivo al primo di non ricevere alcuna risposta.",
					HigherLevels = null
				}
			}
		};
	}
}
