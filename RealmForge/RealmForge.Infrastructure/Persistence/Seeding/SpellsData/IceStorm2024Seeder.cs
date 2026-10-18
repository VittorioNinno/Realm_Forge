using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Ice Storm (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class IceStorm2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ice-storm");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ice-storm", "en"),
					Language = LanguageCode.En,
					Name = "Ice Storm",
					CastingTime = "Action",
					Range = "300 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a mitten",
					Description = "Hail falls in a 20-foot-radius, 40-foot-high Cylinder centered on a point within range. Each creature in the Cylinder makes a Dexterity saving throw. A creature takes 2d10 Bludgeoning damage and 4d6 Cold damage on a failed save or half as much damage on a successful one.\n\nHailstones turn ground in the Cylinder into Difficult Terrain until the end of your next turn.",
					HigherLevels = "The Bludgeoning damage increases by 1d10 for each spell slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ice-storm", "it"),
					Language = LanguageCode.It,
					Name = "Tempesta di Ghiaccio",
					CastingTime = "Azione",
					Range = "90 metri",
					Duration = "Istantanea",
					MaterialComponent = "una manopola",
					Description = "Una grandinata cade in un cilindro del raggio di 6 metri e alto 12 metri, centrato su un punto entro gittata. Ogni creatura nel cilindro effettua un tiro salvezza su Destrezza. Una creatura subisce 2d10 danni contundenti e 4d6 danni da freddo se lo fallisce, o la metà di quei danni se lo supera.\n\nI chicchi di grandine trasformano il terreno nel cilindro in terreno difficile fino alla fine del turno successivo dell'incantatore.",
					HigherLevels = "I danni contundenti aumentano di 1d10 per ogni livello dello slot incantesimo superiore al 4°."
				}
			}
		};
	}
}
