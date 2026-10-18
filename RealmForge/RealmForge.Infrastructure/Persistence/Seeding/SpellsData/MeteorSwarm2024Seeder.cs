using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Meteor Swarm (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MeteorSwarm2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "meteor-swarm");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 9,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "meteor-swarm", "en"),
					Language = LanguageCode.En,
					Name = "Meteor Swarm",
					CastingTime = "Action",
					Range = "1 mile",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Blazing orbs of fire plummet to the ground at four different points you can see within range. Each creature in a 40-foot-radius Sphere centered on each of those points makes a Dexterity saving throw. A creature takes 20d6 Fire damage and 20d6 Bludgeoning damage on a failed save or half as much damage on a successful one. A creature in the area of more than one fiery Sphere is affected only once.\n\nA nonmagical object that isn't being worn or carried also takes the damage if it's in the spell's area, and the object starts burning if it's flammable.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "meteor-swarm", "it"),
					Language = LanguageCode.It,
					Name = "Sciame di Meteore",
					CastingTime = "Azione",
					Range = "1,5 km",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Globi di fuoco ardente precipitano al suolo in quattro punti diversi entro gittata che l'incantatore è in grado di vedere. Ogni creatura in una sfera del raggio di 12 metri centrata su ciascuno di quei punti effettua un tiro salvezza su Destrezza. Una creatura subisce 20d6 danni da fuoco e 20d6 danni contundenti se lo fallisce, o la metà di quei danni se lo supera. Una creatura che si trova nell'area di più di una sfera infuocata viene influenzata una volta sola.\n\nAnche un oggetto non magico che non sia indossato o trasportato subisce i danni se si trova nell'area dell'incantesimo, e prende fuoco se è infiammabile.",
					HigherLevels = null
				}
			}
		};
	}
}
