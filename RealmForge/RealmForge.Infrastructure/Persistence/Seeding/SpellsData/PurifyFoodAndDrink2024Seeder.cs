using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Purify Food and Drink (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PurifyFoodAndDrink2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "purify-food-and-drink");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "purify-food-and-drink", "en"),
					Language = LanguageCode.En,
					Name = "Purify Food and Drink",
					CastingTime = "Action",
					Range = "10 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You remove poison and rot from nonmagical food and drink in a 5-foot-radius Sphere centered on a point within range.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "purify-food-and-drink", "it"),
					Language = LanguageCode.It,
					Name = "Purificare Cibo e Bevande",
					CastingTime = "Azione",
					Range = "3 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore rimuove il veleno e la putrefazione dal cibo e dalle bevande non magici in una sfera del raggio di 1,5 metri centrata su un punto entro gittata.",
					HigherLevels = null
				}
			}
		};
	}
}
