using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Darkvision (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Darkvision2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "darkvision");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "darkvision", "en"),
					Language = LanguageCode.En,
					Name = "Darkvision",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = "either a pinch of dried carrot or an agate",
					Description = "You touch a willing creature to grant it the ability to see in the dark. For the duration, that creature has darkvision out to a range of 60 feet.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "darkvision", "it"),
					Language = LanguageCode.It,
					Name = "Scurovisione",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = "un pizzico di carota essiccata o un'agata",
					Description = "L'incantatore tocca una creatura consenziente per conferirle la capacità di vedere al buio. Per la durata, quella creatura ha scurovisione entro un raggio di 18 metri.",
					HigherLevels = null
				}
			}
		};
	}
}
