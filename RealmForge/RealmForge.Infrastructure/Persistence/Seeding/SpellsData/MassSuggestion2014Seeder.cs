using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mass Suggestion (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MassSuggestion2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mass-suggestion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mass-suggestion", "en"),
					Language = LanguageCode.En,
					Name = "Mass Suggestion",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "24 hours",
					MaterialComponent = "a snake's tongue and either a bit of honeycomb or a drop of sweet oil",
					Description = "You suggest a course of activity (limited to a sentence or two) and magically influence up to twelve creatures of your choice that you can see within range and that can hear and understand you. Creatures that can't be charmed are immune to this effect. The suggestion must be worded in such a manner as to make the course of action sound reasonable. Asking the creature to stab itself, throw itself onto a spear, immolate itself, or do some other obviously harmful act automatically negates the effect of the spell.\n\nEach target must make a Wisdom saving throw. On a failed save, it pursues the course of action you described to the best of its ability. The suggested course of action can continue for the entire duration. If the suggested activity can be completed in a shorter time, the spell ends when the subject finishes what it was asked to do.\n\nYou can also specify conditions that will trigger a special activity during the duration. For example, you might suggest that a group of soldiers give all their money to the first beggar they meet. If the condition isn't met before the spell ends, the activity isn't performed.\n\nIf you or any of your companions damage a creature affected by this spell, the spell ends for that creature.",
					HigherLevels = "When you cast this spell using a 7th-level spell slot, the duration is 10 days. When you use an 8th-level spell slot, the duration is 30 days. When you use a 9th-level spell slot, the duration is a year and a day."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mass-suggestion", "it"),
					Language = LanguageCode.It,
					Name = "Suggestione di Massa",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "24 ore",
					MaterialComponent = "la lingua di un serpente e un pezzetto di favo oppure una goccia di olio dolce",
					Description = "L'incantatore suggerisce una linea d'azione (limitata a una o due frasi) e influenza magicamente fino a dodici creature a sua scelta entro gittata, che egli sia in grado di vedere e che possano sentirlo e comprenderlo. Le creature che non possono essere affascinate sono immuni a questo effetto. La suggestione deve essere formulata in modo da far sembrare ragionevole la linea d'azione. Chiedere alla creatura di pugnalarsi, gettarsi su una lancia, darsi fuoco o compiere qualche altro atto palesemente dannoso annulla automaticamente l'effetto dell'incantesimo.\n\nOgni bersaglio deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, persegue al meglio delle sue capacità la linea d'azione descritta dall'incantatore. La linea d'azione suggerita può proseguire per l'intera durata. Se l'attività suggerita può essere portata a termine in un tempo più breve, l'incantesimo termina quando il soggetto finisce ciò che gli è stato chiesto di fare.\n\nL'incantatore può anche specificare delle condizioni che innescheranno un'attività particolare durante la durata. Per esempio, potrebbe suggerire a un gruppo di soldati di dare tutto il loro denaro al primo mendicante che incontrano. Se la condizione non si verifica prima che l'incantesimo termini, l'attività non viene svolta.\n\nSe l'incantatore o uno dei suoi compagni infligge danni a una creatura influenzata da questo incantesimo, l'incantesimo termina per quella creatura.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 7° livello, la durata è di 10 giorni. Quando usa uno slot incantesimo di 8° livello, la durata è di 30 giorni. Quando usa uno slot incantesimo di 9° livello, la durata è di un anno e un giorno."
				}
			}
		};
	}
}
