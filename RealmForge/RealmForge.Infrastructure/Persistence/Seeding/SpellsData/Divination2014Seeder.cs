using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Divination (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Divination2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "divination");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "divination", "en"),
					Language = LanguageCode.En,
					Name = "Divination",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "incense and a sacrificial offering appropriate to your religion, together worth at least 25 gp, which the spell consumes",
					Description = "Your magic and an offering put you in contact with a god or a god's servants. You ask a single question concerning a specific goal, event, or activity to occur within 7 days. The GM offers a truthful reply. The reply might be a short phrase, a cryptic rhyme, or an omen.\n\nThe spell doesn't take into account any possible circumstances that might change the outcome, such as the casting of additional spells or the loss or gain of a companion.\n\nIf you cast the spell two or more times before finishing your next long rest, there is a cumulative 25 percent chance for each casting after the first that you get a random reading. The GM makes this roll in secret.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "divination", "it"),
					Language = LanguageCode.It,
					Name = "Divinazione",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "incenso e un'offerta sacrificale adatta alla religione dell'incantatore, per un valore complessivo di almeno 25 mo, che l'incantesimo consuma",
					Description = "La magia dell'incantatore e un'offerta lo mettono in contatto con una divinità o con i suoi servitori. L'incantatore pone una sola domanda riguardante uno specifico obiettivo, evento o attività che avrà luogo entro 7 giorni. Il DM fornisce una risposta veritiera, che può essere una breve frase, una rima enigmatica o un presagio.\n\nL'incantesimo non tiene conto di eventuali circostanze che potrebbero cambiare il risultato, come il lancio di altri incantesimi o la perdita o l'arrivo di un compagno.\n\nSe l'incantatore lancia l'incantesimo due o più volte prima di terminare il suo riposo lungo successivo, c'è una probabilità cumulativa del 25 per cento per ogni lancio dopo il primo di ottenere un responso casuale. Il DM effettua questo tiro in segreto.",
					HigherLevels = null
				}
			}
		};
	}
}
