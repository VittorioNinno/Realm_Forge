using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Commune (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Commune2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "commune");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "commune", "en"),
					Language = LanguageCode.En,
					Name = "Commune",
					CastingTime = "1 minute",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = "incense and a vial of holy or unholy water",
					Description = "You contact your deity or a divine proxy and ask up to three questions that can be answered with a yes or no. You must ask your questions before the spell ends. You receive a correct answer for each question.\n\nDivine beings aren't necessarily omniscient, so you might receive \"unclear\" as an answer if a question pertains to information that lies beyond the deity's knowledge. In a case where a one-word answer could be misleading or contrary to the deity's interests, the GM might offer a short phrase as an answer instead.\n\nIf you cast the spell two or more times before finishing your next long rest, there is a cumulative 25 percent chance for each casting after the first that you get no answer. The GM makes this roll in secret.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "commune", "it"),
					Language = LanguageCode.It,
					Name = "Comunione",
					CastingTime = "1 minuto",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = "incenso e una fiala di acqua santa o sacrilega",
					Description = "L'incantatore entra in contatto con la propria divinità o con un suo emissario divino e pone fino a tre domande a cui si può rispondere con un sì o con un no. Deve porre le domande prima che l'incantesimo termini. Riceve una risposta corretta per ogni domanda.\n\nGli esseri divini non sono necessariamente onniscienti, quindi l'incantatore potrebbe ricevere come risposta \"incerto\" se una domanda riguarda informazioni che vanno oltre la conoscenza della divinità. Nei casi in cui una risposta di una sola parola potrebbe essere fuorviante o contraria agli interessi della divinità, il DM può invece fornire come risposta una breve frase.\n\nSe l'incantatore lancia l'incantesimo due o più volte prima di terminare il suo riposo lungo successivo, c'è una probabilità cumulativa del 25 per cento per ogni lancio dopo il primo di non ricevere alcuna risposta. Il DM effettua questo tiro in segreto.",
					HigherLevels = null
				}
			}
		};
	}
}
