using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Circle of Death (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CircleOfDeath2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "circle-of-death");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "circle-of-death", "en"),
					Language = LanguageCode.En,
					Name = "Circle of Death",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "the powder of a crushed black pearl worth at least 500 gp",
					Description = "A sphere of negative energy ripples out in a 60-foot radius sphere from a point within range. Each creature in that area must make a Constitution saving throw. A target takes 8d6 necrotic damage on a failed save, or half as much damage on a successful one.",
					HigherLevels = "When you cast this spell using a spell slot of 7th level or higher, the damage increases by 2d6 for each slot level above 6th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "circle-of-death", "it"),
					Language = LanguageCode.It,
					Name = "Cerchio di Morte",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "la polvere di una perla nera frantumata del valore di almeno 500 mo",
					Description = "Una sfera di energia negativa si propaga in una sfera del raggio di 18 metri a partire da un punto entro gittata. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione. Un bersaglio subisce 8d6 danni necrotici se fallisce il tiro salvezza, o la metà di quei danni se lo supera.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 7° livello o superiore, i danni aumentano di 2d6 per ogni livello dello slot superiore al 6°."
				}
			}
		};
	}
}
