using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Spare the Dying (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpareTheDying2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spare-the-dying");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spare-the-dying", "en"),
					Language = LanguageCode.En,
					Name = "Spare the Dying",
					CastingTime = "Action",
					Range = "15 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Choose a creature within range that has 0 Hit Points and isn't dead. The creature becomes Stable.",
					HigherLevels = "The range doubles when you reach levels 5 (30 feet), 11 (60 feet), and 17 (120 feet)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spare-the-dying", "it"),
					Language = LanguageCode.It,
					Name = "Salvare i Morenti",
					CastingTime = "Azione",
					Range = "4,5 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore sceglie una creatura entro gittata che ha 0 punti ferita e non è morta. La creatura diventa stabile.",
					HigherLevels = "La gittata raddoppia quando l'incantatore raggiunge il 5° livello (9 metri), l'11° livello (18 metri) e il 17° livello (36 metri)."
				}
			}
		};
	}
}
