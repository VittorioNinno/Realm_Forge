using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Color Spray (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ColorSpray2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "color-spray");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "color-spray", "en"),
					Language = LanguageCode.En,
					Name = "Color Spray",
					CastingTime = "1 action",
					Range = "Self (15-foot cone)",
					Duration = "1 round",
					MaterialComponent = "a pinch of powder or sand that is colored red, yellow, and blue",
					Description = "A dazzling array of flashing, colored light springs from your hand. Roll 6d10; the total is how many hit points of creatures this spell can affect. Creatures in a 15-foot cone originating from you are affected in ascending order of their current hit points (ignoring unconscious creatures and creatures that can't see).\n\nStarting with the creature that has the lowest current hit points, each creature affected by this spell is blinded until the spell ends. Subtract each creature's hit points from the total before moving on to the creature with the next lowest hit points. A creature's hit points must be equal to or less than the remaining total for that creature to be affected.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, roll an additional 2d10 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "color-spray", "it"),
					Language = LanguageCode.It,
					Name = "Spruzzo Colorato",
					CastingTime = "1 azione",
					Range = "Incantatore (cono di 4,5 metri)",
					Duration = "1 round",
					MaterialComponent = "un pizzico di polvere o di sabbia colorata di rosso, giallo e blu",
					Description = "Una sfolgorante serie di lampi di luce colorata scaturisce dalla mano dell'incantatore. L'incantatore tira 6d10: il totale indica quanti punti ferita di creature l'incantesimo può influenzare. Le creature in un cono di 4,5 metri che parte dall'incantatore sono influenzate in ordine crescente di punti ferita attuali (ignorando le creature prive di sensi e quelle che non possono vedere).\n\nA partire dalla creatura con il minor numero di punti ferita attuali, ogni creatura influenzata da questo incantesimo è accecata finché l'incantesimo non termina. Prima di passare alla creatura con il numero di punti ferita immediatamente superiore, si sottraggono dal totale i punti ferita di ogni creatura influenzata. Perché una creatura sia influenzata, i suoi punti ferita devono essere pari o inferiori al totale rimanente.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, tira 2d10 aggiuntivi per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
