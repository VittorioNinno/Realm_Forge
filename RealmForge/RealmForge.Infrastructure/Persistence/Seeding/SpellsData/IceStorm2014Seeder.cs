using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Ice Storm (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class IceStorm2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "ice-storm");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "ice-storm", "en"),
					Language = LanguageCode.En,
					Name = "Ice Storm",
					CastingTime = "1 action",
					Range = "300 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a pinch of dust and a few drops of water",
					Description = "A hail of rock-hard ice pounds to the ground in a 20-foot-radius, 40-foot-high cylinder centered on a point within range. Each creature in the cylinder must make a Dexterity saving throw. A creature takes 2d8 bludgeoning damage and 4d6 cold damage on a failed save, or half as much damage on a successful one.\n\nHailstones turn the storm's area of effect into difficult terrain until the end of your next turn.",
					HigherLevels = "When you cast this spell using a spell slot of 5th level or higher, the bludgeoning damage increases by 1d8 for each slot level above 4th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "ice-storm", "it"),
					Language = LanguageCode.It,
					Name = "Tempesta di Ghiaccio",
					CastingTime = "1 azione",
					Range = "90 metri",
					Duration = "Istantanea",
					MaterialComponent = "un pizzico di polvere e qualche goccia d'acqua",
					Description = "Una grandinata di ghiaccio duro come la roccia si abbatte al suolo in un cilindro del raggio di 6 metri e alto 12 metri, centrato su un punto entro gittata. Ogni creatura nel cilindro deve effettuare un tiro salvezza su Destrezza. Una creatura subisce 2d8 danni contundenti e 4d6 danni da freddo se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\nI chicchi di grandine trasformano l'area d'effetto della tempesta in terreno difficile fino alla fine del turno successivo dell'incantatore.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 5° livello o superiore, i danni contundenti aumentano di 1d8 per ogni livello dello slot superiore al 4°."
				}
			}
		};
	}
}
