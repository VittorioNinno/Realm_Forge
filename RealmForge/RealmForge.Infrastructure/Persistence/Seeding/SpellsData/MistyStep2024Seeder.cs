using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Misty Step (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MistyStep2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "misty-step");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "misty-step", "en"),
					Language = LanguageCode.En,
					Name = "Misty Step",
					CastingTime = "Bonus Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Briefly surrounded by silvery mist, you teleport up to 30 feet to an unoccupied space you can see.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "misty-step", "it"),
					Language = LanguageCode.It,
					Name = "Passo Velato",
					CastingTime = "Azione bonus",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Avvolto per un istante da una nebbia argentea, l'incantatore si teletrasporta fino a 9 metri in uno spazio libero che è in grado di vedere.",
					HigherLevels = null
				}
			}
		};
	}
}
