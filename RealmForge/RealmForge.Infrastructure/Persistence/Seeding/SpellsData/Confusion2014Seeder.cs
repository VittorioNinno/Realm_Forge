using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Confusion (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Confusion2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "confusion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "confusion", "en"),
					Language = LanguageCode.En,
					Name = "Confusion",
					CastingTime = "1 action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "three walnut shells",
					Description = "This spell assaults and twists creatures' minds, spawning delusions and provoking uncontrolled action. Each creature in a 10-foot-radius sphere centered on a point you choose within range must succeed on a Wisdom saving throw when you cast this spell or be affected by it.\n\nAn affected target can't take reactions and must roll a d10 at the start of each of its turns to determine its behavior for that turn.\n\n| d10 | Behavior |\n|---|---|\n| 1 | The creature uses all its movement to move in a random direction. To determine the direction, roll a d8 and assign a direction to each die face. The creature doesn't take an action this turn. |\n| 2-6 | The creature doesn't move or take actions this turn. |\n| 7-8 | The creature uses its action to make a melee attack against a randomly determined creature within its reach. If there is no creature within its reach, the creature does nothing this turn. |\n| 9-10 | The creature can act and move normally. |\n\nAt the end of each of its turns, an affected target can make a Wisdom saving throw. If it succeeds, this effect ends for that target.",
					HigherLevels = "When you cast this spell using a spell slot of 5th level or higher, the radius of the sphere increases by 5 feet for each slot level above 4th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "confusion", "it"),
					Language = LanguageCode.It,
					Name = "Confusione",
					CastingTime = "1 azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "tre gusci di noce",
					Description = "Questo incantesimo aggredisce e distorce la mente delle creature, generando deliri e provocando azioni incontrollate. Ogni creatura in una sfera del raggio di 3 metri centrata su un punto entro gittata scelto dall'incantatore deve superare un tiro salvezza su Saggezza quando l'incantatore lancia questo incantesimo, altrimenti ne è influenzata.\n\nUn bersaglio influenzato non può effettuare reazioni e deve tirare un d10 all'inizio di ogni suo turno per determinare il proprio comportamento in quel turno.\n\n| d10 | Comportamento |\n|---|---|\n| 1 | La creatura usa tutto il suo movimento per spostarsi in una direzione casuale. Per determinare la direzione, si tira un d8 e si assegna una direzione a ogni faccia del dado. In questo turno la creatura non compie azioni. |\n| 2-6 | In questo turno la creatura non si muove e non compie azioni. |\n| 7-8 | La creatura usa la sua azione per effettuare un attacco in mischia contro una creatura determinata casualmente entro la sua portata. Se non ci sono creature entro la sua portata, in questo turno la creatura non fa nulla. |\n| 9-10 | La creatura può agire e muoversi normalmente. |\n\nAlla fine di ogni suo turno, un bersaglio influenzato può effettuare un tiro salvezza su Saggezza. Se lo supera, l'effetto termina per quel bersaglio.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 5° livello o superiore, il raggio della sfera aumenta di 1,5 metri per ogni livello dello slot superiore al 4°."
				}
			}
		};
	}
}
