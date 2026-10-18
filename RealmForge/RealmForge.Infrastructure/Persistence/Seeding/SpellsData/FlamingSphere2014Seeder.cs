using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Flaming Sphere (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FlamingSphere2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flaming-sphere");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flaming-sphere", "en"),
					Language = LanguageCode.En,
					Name = "Flaming Sphere",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a bit of tallow, a pinch of brimstone, and a dusting of powdered iron",
					Description = "A 5-foot-diameter sphere of fire appears in an unoccupied space of your choice within range and lasts for the duration. Any creature that ends its turn within 5 feet of the sphere must make a Dexterity saving throw. The creature takes 2d6 fire damage on a failed save, or half as much damage on a successful one.\n\nAs a bonus action, you can move the sphere up to 30 feet. If you ram the sphere into a creature, that creature must make the saving throw against the sphere's damage, and the sphere stops moving this turn.\n\nWhen you move the sphere, you can direct it over barriers up to 5 feet tall and jump it across pits up to 10 feet wide. The sphere ignites flammable objects not being worn or carried, and it sheds bright light in a 20-foot radius and dim light for an additional 20 feet.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, the damage increases by 1d6 for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flaming-sphere", "it"),
					Language = LanguageCode.It,
					Name = "Sfera Infuocata",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un po' di sego, un pizzico di zolfo e una spolverata di ferro in polvere",
					Description = "Una sfera di fuoco del diametro di 1,5 metri compare in uno spazio libero entro gittata a scelta dell'incantatore e dura per la durata. Ogni creatura che termina il proprio turno entro 1,5 metri dalla sfera deve effettuare un tiro salvezza su Destrezza. La creatura subisce 2d6 danni da fuoco se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\nCome azione bonus, l'incantatore può spostare la sfera di un massimo di 9 metri. Se la scaglia contro una creatura, quella creatura deve effettuare il tiro salvezza contro i danni della sfera, e la sfera smette di muoversi per quel turno.\n\nQuando sposta la sfera, l'incantatore può dirigerla sopra barriere alte fino a 1,5 metri e farle superare con un balzo fosse larghe fino a 3 metri. La sfera incendia gli oggetti infiammabili che non sono indossati o trasportati ed emette luce intensa in un raggio di 6 metri e luce fioca per ulteriori 6 metri.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, i danni aumentano di 1d6 per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
