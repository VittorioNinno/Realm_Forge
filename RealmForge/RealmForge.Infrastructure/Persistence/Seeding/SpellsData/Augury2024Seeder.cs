using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Augury (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Augury2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "augury");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "augury", "en"),
					Language = LanguageCode.En,
					Name = "Augury",
					CastingTime = "1 minute",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "specially marked sticks, bones, cards, or other divinatory tokens worth 25+ GP",
					Description = "You receive an omen from an otherworldly entity about the results of a course of action that you plan to take within the next 30 minutes. The GM chooses the omen from the Omens table.\n\n**Omens**\n\n| Omen | For Results That Will Be … |\n|---|---|\n| Weal | Good |\n| Woe | Bad |\n| Weal and woe | Good and bad |\n| Indifference | Neither good nor bad |\n\nThe spell doesn't account for circumstances, such as other spells, that might change the results.\n\nIf you cast the spell more than once before finishing a Long Rest, there is a cumulative 25 percent chance for each casting after the first that you get no answer.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "augury", "it"),
					Language = LanguageCode.It,
					Name = "Presagio",
					CastingTime = "1 minuto",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "bastoncini, ossa, carte o altri strumenti divinatori marcati in modo speciale, del valore di almeno 25 mo",
					Description = "L'incantatore riceve da un'entità ultraterrena un presagio sui risultati di una linea d'azione che intende intraprendere entro i 30 minuti successivi. Il DM sceglie il presagio dalla tabella dei Presagi.\n\n**Presagi**\n\n| Presagio | Per risultati che saranno… |\n|---|---|\n| Fortuna | Positivi |\n| Sventura | Negativi |\n| Fortuna e sventura | Positivi e negativi |\n| Indifferenza | Né positivi né negativi |\n\nL'incantesimo non tiene conto delle circostanze, come altri incantesimi, che potrebbero cambiare i risultati.\n\nSe l'incantatore lancia l'incantesimo più di una volta prima di aver terminato un riposo lungo, c'è una probabilità cumulativa del 25 per cento per ogni lancio successivo al primo di non ricevere alcuna risposta.",
					HigherLevels = null
				}
			}
		};
	}
}
