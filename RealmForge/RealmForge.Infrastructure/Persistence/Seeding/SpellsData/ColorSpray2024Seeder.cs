using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Color Spray (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ColorSpray2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "color-spray");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "color-spray", "en"),
					Language = LanguageCode.En,
					Name = "Color Spray",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "a pinch of colorful sand",
					Description = "You launch a dazzling array of flashing, colorful light. Each creature in a 15-foot Cone originating from you must succeed on a Constitution saving throw or have the Blinded condition until the end of your next turn.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "color-spray", "it"),
					Language = LanguageCode.It,
					Name = "Spruzzo Colorato",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "un pizzico di sabbia colorata",
					Description = "L'incantatore scatena un abbagliante insieme di luci colorate e lampeggianti. Ogni creatura in un cono di 4,5 metri che ha origine dall'incantatore deve superare un tiro salvezza su Costituzione, altrimenti è accecata fino alla fine del turno successivo dell'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
