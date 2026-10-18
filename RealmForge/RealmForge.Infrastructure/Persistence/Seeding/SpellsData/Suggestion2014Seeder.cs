using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Suggestion (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Suggestion2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "suggestion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "suggestion", "en"),
					Language = LanguageCode.En,
					Name = "Suggestion",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 8 hours",
					MaterialComponent = "a snake's tongue and either a bit of honeycomb or a drop of sweet oil",
					Description = "You suggest a course of activity (limited to a sentence or two) and magically influence a creature you can see within range that can hear and understand you. Creatures that can't be charmed are immune to this effect. The suggestion must be worded in such a manner as to make the course of action sound reasonable. Asking the creature to stab itself, throw itself onto a spear, immolate itself, or do some other obviously harmful act ends the spell.\n\nThe target must make a Wisdom saving throw. On a failed save, it pursues the course of action you described to the best of its ability. The suggested course of action can continue for the entire duration. If the suggested activity can be completed in a shorter time, the spell ends when the subject finishes what it was asked to do.\n\nYou can also specify conditions that will trigger a special activity during the duration. For example, you might suggest that a knight give her warhorse to the first beggar she meets. If the condition isn't met before the spell expires, the activity isn't performed.\n\nIf you or any of your companions damage the target, the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "suggestion", "it"),
					Language = LanguageCode.It,
					Name = "Suggestione",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 8 ore",
					MaterialComponent = "la lingua di un serpente e un pezzetto di favo oppure una goccia di olio dolce",
					Description = "L'incantatore suggerisce una linea d'azione (limitata a una o due frasi) e influenza magicamente una creatura entro gittata, che egli sia in grado di vedere e che possa sentirlo e comprenderlo. Le creature che non possono essere affascinate sono immuni a questo effetto. La suggestione deve essere formulata in modo da far sembrare ragionevole la linea d'azione. Chiedere alla creatura di pugnalarsi, gettarsi su una lancia, darsi fuoco o compiere qualche altro atto palesemente dannoso pone fine all'incantesimo.\n\nIl bersaglio deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, persegue al meglio delle sue capacità la linea d'azione descritta dall'incantatore. La linea d'azione suggerita può proseguire per l'intera durata. Se l'attività suggerita può essere portata a termine in un tempo più breve, l'incantesimo termina quando il soggetto finisce ciò che gli è stato chiesto di fare.\n\nL'incantatore può anche specificare delle condizioni che innescheranno un'attività particolare durante la durata. Per esempio, potrebbe suggerire a una cavaliera di dare il suo cavallo da guerra al primo mendicante che incontra. Se la condizione non si verifica prima che l'incantesimo termini, l'attività non viene svolta.\n\nSe l'incantatore o uno dei suoi compagni infligge danni al bersaglio, l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
