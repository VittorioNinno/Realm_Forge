using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	False Life (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FalseLife2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "false-life");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "false-life", "en"),
					Language = LanguageCode.En,
					Name = "False Life",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "a drop of alcohol",
					Description = "You gain 2d4 + 4 Temporary Hit Points.",
					HigherLevels = "You gain 5 additional Temporary Hit Points for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "false-life", "it"),
					Language = LanguageCode.It,
					Name = "Vita Falsata",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "una goccia di alcol",
					Description = "L'incantatore ottiene 2d4 + 4 punti ferita temporanei.",
					HigherLevels = "L'incantatore ottiene 5 punti ferita temporanei aggiuntivi per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
