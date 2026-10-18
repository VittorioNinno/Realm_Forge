using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Water Breathing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WaterBreathing2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "water-breathing");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "water-breathing", "en"),
					Language = LanguageCode.En,
					Name = "Water Breathing",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "24 hours",
					MaterialComponent = "a short piece of reed or straw",
					Description = "This spell grants up to ten willing creatures you can see within range the ability to breathe underwater until the spell ends. Affected creatures also retain their normal mode of respiration.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "water-breathing", "it"),
					Language = LanguageCode.It,
					Name = "Respirare sott'Acqua",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "24 ore",
					MaterialComponent = "un corto pezzo di canna o di paglia",
					Description = "Questo incantesimo conferisce a un massimo di dieci creature consenzienti entro gittata, che l'incantatore sia in grado di vedere, la capacità di respirare sott'acqua finché l'incantesimo non termina. Le creature influenzate conservano anche la loro normale modalità di respirazione.",
					HigherLevels = null
				}
			}
		};
	}
}
