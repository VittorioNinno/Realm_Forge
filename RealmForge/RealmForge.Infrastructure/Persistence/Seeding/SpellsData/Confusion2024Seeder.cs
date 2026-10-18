using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Confusion (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Confusion2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "confusion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "confusion", "en"),
					Language = LanguageCode.En,
					Name = "Confusion",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "three nut shells",
					Description = "Each creature in a 10-foot-radius Sphere centered on a point you choose within range must succeed on a Wisdom saving throw, or that target can't take Bonus Actions or Reactions and must roll 1d10 at the start of each of its turns to determine its behavior for that turn, consulting the table below.\n\n| 1d10 | Behavior for the Turn |\n|---|---|\n| 1 | The target doesn't take an action, and it uses all its movement to move. Roll 1d4 for the direction: 1, north; 2, east; 3, south; or 4, west. |\n| 2–6 | The target doesn't move or take actions. |\n| 7–8 | The target doesn't move, and it takes the Attack action to make one melee attack against a random creature within reach. If none are within reach, the target takes no action. |\n| 9–10 | The target chooses its behavior. |\n\nAt the end of each of its turns, an affected target repeats the save, ending the spell on itself on a success.",
					HigherLevels = "The Sphere's radius increases by 5 feet for each spell slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "confusion", "it"),
					Language = LanguageCode.It,
					Name = "Confusione",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "tre gusci di noce",
					Description = "Ogni creatura in una sfera del raggio di 3 metri centrata su un punto entro gittata a scelta dell'incantatore deve superare un tiro salvezza su Saggezza, altrimenti non può effettuare azioni bonus né reazioni e deve tirare 1d10 all'inizio di ogni suo turno per determinare il proprio comportamento in quel turno, consultando la tabella seguente.\n\n| 1d10 | Comportamento nel turno |\n|---|---|\n| 1 | Il bersaglio non effettua alcuna azione e usa tutto il suo movimento per muoversi. Tira 1d4 per determinare la direzione: 1, nord; 2, est; 3, sud; 4, ovest. |\n| 2–6 | Il bersaglio non si muove e non effettua azioni. |\n| 7–8 | Il bersaglio non si muove ed effettua l'azione di Attacco per compiere un attacco in mischia contro una creatura casuale entro portata. Se non ci sono creature entro portata, il bersaglio non effettua alcuna azione. |\n| 9–10 | Il bersaglio sceglie il proprio comportamento. |\n\nAlla fine di ogni suo turno, un bersaglio influenzato ripete il tiro salvezza e, se lo supera, l'incantesimo termina su di lui.",
					HigherLevels = "Il raggio della sfera aumenta di 1,5 metri per ogni livello dello slot incantesimo superiore al 4°."
				}
			}
		};
	}
}
