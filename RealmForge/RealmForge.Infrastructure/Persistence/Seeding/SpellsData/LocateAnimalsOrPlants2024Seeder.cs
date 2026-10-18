using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Locate Animals or Plants (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LocateAnimalsOrPlants2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "locate-animals-or-plants");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "locate-animals-or-plants", "en"),
					Language = LanguageCode.En,
					Name = "Locate Animals or Plants",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "fur from a bloodhound",
					Description = "Describe or name a specific kind of Beast, Plant creature, or nonmagical plant. You learn the direction and distance to the closest creature or plant of that kind within 5 miles, if any are present.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "locate-animals-or-plants", "it"),
					Language = LanguageCode.It,
					Name = "Localizza Animali o Vegetali",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "pelo di un segugio",
					Description = "L'incantatore descrive o nomina un tipo specifico di bestia, di creatura vegetale o di pianta non magica. Apprende la direzione e la distanza della creatura o della pianta di quel tipo più vicina entro 7,5 km, se ce n'è una.",
					HigherLevels = null
				}
			}
		};
	}
}
