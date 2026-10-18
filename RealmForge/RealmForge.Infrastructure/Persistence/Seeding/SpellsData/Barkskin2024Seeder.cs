using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Barkskin (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Barkskin2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "barkskin");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "barkskin", "en"),
					Language = LanguageCode.En,
					Name = "Barkskin",
					CastingTime = "Bonus Action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a handful of bark",
					Description = "You touch a willing creature. Until the spell ends, the target's skin assumes a bark-like appearance, and the target has an Armor Class of 17 if its AC is lower than that.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "barkskin", "it"),
					Language = LanguageCode.It,
					Name = "Pelle Coriacea",
					CastingTime = "Azione bonus",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "una manciata di corteccia",
					Description = "L'incantatore tocca una creatura consenziente. Finché l'incantesimo non termina, la pelle del bersaglio assume l'aspetto della corteccia e il bersaglio ha una Classe Armatura di 17, se la sua CA è inferiore.",
					HigherLevels = null
				}
			}
		};
	}
}
