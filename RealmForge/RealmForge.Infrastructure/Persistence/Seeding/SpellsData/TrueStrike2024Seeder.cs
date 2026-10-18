using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	True Strike (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TrueStrike2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "true-strike");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = false,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "true-strike", "en"),
					Language = LanguageCode.En,
					Name = "True Strike",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "a weapon with which you have proficiency and that is worth 1+ CP",
					Description = "Guided by a flash of magical insight, you make one attack with the weapon used in the spell's casting. The attack uses your spellcasting ability for the attack and damage rolls instead of using Strength or Dexterity. If the attack deals damage, it can be Radiant damage or the weapon's normal damage type (your choice).",
					HigherLevels = "Whether you deal Radiant damage or the weapon's normal damage type, the attack deals extra Radiant damage when you reach levels 5 (1d6), 11 (2d6), and 17 (3d6)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "true-strike", "it"),
					Language = LanguageCode.It,
					Name = "Colpo Accurato",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "un'arma con cui l'incantatore ha competenza e che vale almeno 1 mr",
					Description = "Guidato da un lampo di intuizione magica, l'incantatore effettua un attacco con l'arma usata per lanciare l'incantesimo. L'attacco usa la caratteristica da incantatore dell'incantatore per i tiri per colpire e per i danni, invece della Forza o della Destrezza. Se l'attacco infligge danni, questi possono essere danni radiosi o del normale tipo di danni dell'arma (a scelta dell'incantatore).",
					HigherLevels = "Che infligga danni radiosi o del normale tipo di danni dell'arma, l'attacco infligge danni radiosi extra quando l'incantatore raggiunge il 5° livello (1d6), l'11° livello (2d6) e il 17° livello (3d6)."
				}
			}
		};
	}
}
