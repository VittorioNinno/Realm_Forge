using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Water Breathing (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WaterBreathing2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "water-breathing");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "water-breathing", "en"),
					Language = LanguageCode.En,
					Name = "Water Breathing",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "24 hours",
					MaterialComponent = "a short reed",
					Description = "This spell grants up to ten willing creatures of your choice within range the ability to breathe underwater until the spell ends. Affected creatures also retain their normal mode of respiration.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "water-breathing", "it"),
					Language = LanguageCode.It,
					Name = "Respirare sott'Acqua",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "24 ore",
					MaterialComponent = "una canna corta",
					Description = "Questo incantesimo conferisce a un massimo di dieci creature consenzienti a scelta dell'incantatore entro gittata la capacità di respirare sott'acqua finché l'incantesimo non termina. Le creature influenzate mantengono anche la loro normale modalità di respirazione.",
					HigherLevels = null
				}
			}
		};
	}
}
