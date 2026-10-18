using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Purify Food and Drink (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PurifyFoodAndDrink2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "purify-food-and-drink");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "purify-food-and-drink", "en"),
					Language = LanguageCode.En,
					Name = "Purify Food and Drink",
					CastingTime = "1 action",
					Range = "10 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "All nonmagical food and drink within a 5-foot radius sphere centered on a point of your choice within range is purified and rendered free of poison and disease.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "purify-food-and-drink", "it"),
					Language = LanguageCode.It,
					Name = "Purificare Cibo e Bevande",
					CastingTime = "1 azione",
					Range = "3 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Tutto il cibo e le bevande non magici all'interno di una sfera del raggio di 1,5 metri, centrata su un punto entro gittata a scelta dell'incantatore, vengono purificati e liberati da veleni e malattie.",
					HigherLevels = null
				}
			}
		};
	}
}
