using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fireball (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Fireball2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fireball");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Evocation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fireball", "en"),
					Language = LanguageCode.En,
					Name = "Fireball",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a tiny ball of bat guano and sulfur",
					Description = "A bright streak flashes from your pointing finger to a point you choose within range and then blossoms with a low roar into an explosion of flame. Each creature in a 20-foot-radius sphere centered on that point must make a Dexterity saving throw. A target takes 8d6 fire damage on a failed save, or half as much damage on a successful one.\n\nThe fire spreads around corners. It ignites flammable objects in the area that aren't being worn or carried.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fireball", "it"),
					Language = LanguageCode.It,
					Name = "Palla di Fuoco",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "una minuscola pallina di guano di pipistrello e zolfo",
					Description = "Una scia luminosa sfreccia dal dito puntato dell'incantatore verso un punto entro gittata da lui scelto, per poi sbocciare con un rombo sordo in un'esplosione di fiamme. Ogni creatura in una sfera del raggio di 6 metri centrata su quel punto deve effettuare un tiro salvezza su Destrezza. Un bersaglio subisce 8d6 danni da fuoco se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\nIl fuoco si propaga dietro gli angoli e incendia gli oggetti infiammabili nell'area che non sono indossati o trasportati.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, i danni aumentano di 1d6 per ogni livello dello slot superiore al 3°."
				}
			}
		};
	}
}
