using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Darkvision (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Darkvision2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "darkvision");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "darkvision", "en"),
					Language = LanguageCode.En,
					Name = "Darkvision",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = "a dried carrot",
					Description = "For the duration, a willing creature you touch has Darkvision with a range of 150 feet.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "darkvision", "it"),
					Language = LanguageCode.It,
					Name = "Scurovisione",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = "una carota essiccata",
					Description = "Per la durata, una creatura consenziente toccata dall'incantatore dispone di scurovisione con un raggio di 45 metri.",
					HigherLevels = null
				}
			}
		};
	}
}
