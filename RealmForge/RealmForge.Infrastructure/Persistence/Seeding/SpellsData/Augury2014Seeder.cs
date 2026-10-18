using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Augury (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Augury2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "augury");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "augury", "en"),
					Language = LanguageCode.En,
					Name = "Augury",
					CastingTime = "1 minute",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "specially marked sticks, bones, or similar tokens worth at least 25 gp",
					Description = "By casting gem-inlaid sticks, rolling dragon bones, laying out ornate cards, or employing some other divining tool, you receive an omen from an otherworldly entity about the results of a specific course of action that you plan to take within the next 30 minutes. The GM chooses from the following possible omens:\n\n- Weal, for good results\n\n- Woe, for bad results\n\n- Weal and woe, for both good and bad results\n\n- Nothing, for results that aren't especially good or bad\n\nThe spell doesn't take into account any possible circumstances that might change the outcome, such as the casting of additional spells or the loss or gain of a companion.\n\nIf you cast the spell two or more times before completing your next long rest, there is a cumulative 25 percent chance for each casting after the first that you get a random reading. The GM makes this roll in secret.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "augury", "it"),
					Language = LanguageCode.It,
					Name = "Presagio",
					CastingTime = "1 minuto",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "bastoncini, ossa o gettoni simili appositamente marcati, del valore di almeno 25 mo",
					Description = "Lanciando bastoncini intarsiati di gemme, tirando ossa di drago, disponendo carte decorate o impiegando qualche altro strumento divinatorio, l'incantatore riceve da un'entità ultraterrena un presagio sui risultati di una specifica linea d'azione che intende intraprendere nei 30 minuti successivi. Il DM sceglie tra i presagi possibili seguenti:\n\n- Fortuna, per risultati favorevoli\n\n- Sventura, per risultati sfavorevoli\n\n- Fortuna e sventura, per risultati sia favorevoli sia sfavorevoli\n\n- Nulla, per risultati né particolarmente favorevoli né sfavorevoli\n\nL'incantesimo non tiene conto di eventuali circostanze che potrebbero cambiare il risultato, come il lancio di altri incantesimi o la perdita o l'arrivo di un compagno.\n\nSe l'incantatore lancia l'incantesimo due o più volte prima di completare il suo riposo lungo successivo, c'è una probabilità cumulativa del 25 per cento per ogni lancio dopo il primo di ottenere un responso casuale. Il DM effettua questo tiro in segreto.",
					HigherLevels = null
				}
			}
		};
	}
}
