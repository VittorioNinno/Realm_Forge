using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Detect Poison and Disease (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DetectPoisonAndDisease2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "detect-poison-and-disease");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Ranger },
			Ritual = true,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "detect-poison-and-disease", "en"),
					Language = LanguageCode.En,
					Name = "Detect Poison and Disease",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a yew leaf",
					Description = "For the duration, you sense the location of poisons, poisonous or venomous creatures, and magical contagions within 30 feet of yourself. You sense the kind of poison, creature, or contagion in each case.\n\nThe spell is blocked by 1 foot of stone, dirt, or wood; 1 inch of metal; or a thin sheet of lead.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "detect-poison-and-disease", "it"),
					Language = LanguageCode.It,
					Name = "Individuazione delle Malattie e dei Veleni",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una foglia di tasso",
					Description = "Per la durata, l'incantatore percepisce la posizione dei veleni, delle creature velenose e dei contagi magici entro 9 metri da sé. In ogni caso, percepisce il tipo di veleno, di creatura o di contagio.\n\nL'incantesimo è bloccato da 30 centimetri di pietra, terra o legno, da 2,5 centimetri di metallo o da una sottile lamina di piombo.",
					HigherLevels = null
				}
			}
		};
	}
}
