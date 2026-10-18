using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	False Life (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FalseLife2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "false-life");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "false-life", "en"),
					Language = LanguageCode.En,
					Name = "False Life",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "1 hour",
					MaterialComponent = "a small amount of alcohol or distilled spirits",
					Description = "Bolstering yourself with a necromantic facsimile of life, you gain 1d4 + 4 temporary hit points for the duration.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, you gain 5 additional temporary hit points for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "false-life", "it"),
					Language = LanguageCode.It,
					Name = "Vita Falsata",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "1 ora",
					MaterialComponent = "una piccola quantità di alcol o di distillato",
					Description = "Rafforzandosi con un simulacro necromantico di vita, l'incantatore ottiene 1d4 + 4 punti ferita temporanei per la durata.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, ottiene 5 punti ferita temporanei aggiuntivi per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
