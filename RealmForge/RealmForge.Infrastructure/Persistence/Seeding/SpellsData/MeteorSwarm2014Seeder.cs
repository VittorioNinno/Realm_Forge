using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Meteor Swarm (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MeteorSwarm2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "meteor-swarm");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "meteor-swarm", "en"),
					Language = LanguageCode.En,
					Name = "Meteor Swarm",
					CastingTime = "1 action",
					Range = "1 mile",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Blazing orbs of fire plummet to the ground at four different points you can see within range. Each creature in a 40-foot-radius sphere centered on each point you choose must make a Dexterity saving throw. The sphere spreads around corners. A creature takes 20d6 fire damage and 20d6 bludgeoning damage on a failed save, or half as much damage on a successful one. A creature in the area of more than one fiery burst is affected only once.\n\nThe spell damages objects in the area and ignites flammable objects that aren't being worn or carried.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "meteor-swarm", "it"),
					Language = LanguageCode.It,
					Name = "Sciame di Meteore",
					CastingTime = "1 azione",
					Range = "1,5 km",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Globi di fuoco ardenti precipitano al suolo in quattro punti diversi entro gittata che l'incantatore sia in grado di vedere. Ogni creatura in una sfera del raggio di 12 metri centrata su ciascun punto scelto deve effettuare un tiro salvezza su Destrezza. La sfera si propaga dietro gli angoli. Una creatura subisce 20d6 danni da fuoco e 20d6 danni contundenti se fallisce il tiro salvezza, o la metà di quei danni se lo supera. Una creatura che si trova nell'area di più di un'esplosione infuocata è influenzata una sola volta.\n\nL'incantesimo danneggia gli oggetti nell'area e incendia gli oggetti infiammabili che non sono indossati o trasportati.",
					HigherLevels = null
				}
			}
		};
	}
}
