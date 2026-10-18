using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Locate Animals or Plants (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LocateAnimalsOrPlants2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "locate-animals-or-plants");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "locate-animals-or-plants", "en"),
					Language = LanguageCode.En,
					Name = "Locate Animals or Plants",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "a bit of fur from a bloodhound",
					Description = "Describe or name a specific kind of beast or plant. Concentrating on the voice of nature in your surroundings, you learn the direction and distance to the closest creature or plant of that kind within 5 miles, if any are present.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "locate-animals-or-plants", "it"),
					Language = LanguageCode.It,
					Name = "Localizza Animali o Vegetali",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "un po' di pelo di segugio",
					Description = "L'incantatore descrive o nomina un tipo specifico di bestia o di vegetale. Concentrandosi sulla voce della natura che lo circonda, apprende la direzione e la distanza della creatura o del vegetale di quel tipo più vicino entro 7,5 km, se ce ne sono.",
					HigherLevels = null
				}
			}
		};
	}
}
