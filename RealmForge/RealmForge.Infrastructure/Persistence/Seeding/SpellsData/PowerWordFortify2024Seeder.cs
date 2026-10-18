using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Power Word Fortify (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class PowerWordFortify2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "power-word-fortify");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 7,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "power-word-fortify", "en"),
					Language = LanguageCode.En,
					Name = "Power Word Fortify",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You speak a word of power that steels up to six creatures you can see within range. You grant a total of 120 Temporary Hit Points, divided among those creatures as you choose.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "power-word-fortify", "it"),
					Language = LanguageCode.It,
					Name = "Parola del Potere Fortificare",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore pronuncia una parola del potere che tempra fino a sei creature entro gittata che è in grado di vedere. Conferisce un totale di 120 punti ferita temporanei, suddivisi tra quelle creature come preferisce.",
					HigherLevels = null
				}
			}
		};
	}
}
