using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Detect Poison and Disease (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DetectPoisonAndDisease2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "detect-poison-and-disease");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "detect-poison-and-disease", "en"),
					Language = LanguageCode.En,
					Name = "Detect Poison and Disease",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a yew leaf",
					Description = "For the duration, you can sense the presence and location of poisons, poisonous creatures, and diseases within 30 feet of you. You also identify the kind of poison, poisonous creature, or disease in each case.\n\nThe spell can penetrate most barriers, but it is blocked by 1 foot of stone, 1 inch of common metal, a thin sheet of lead, or 3 feet of wood or dirt.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "detect-poison-and-disease", "it"),
					Language = LanguageCode.It,
					Name = "Individuazione delle Malattie e dei Veleni",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una foglia di tasso",
					Description = "Per la durata, l'incantatore percepisce la presenza e la posizione di veleni, creature velenose e malattie entro 9 metri da lui. In ogni caso, identifica anche il tipo di veleno, di creatura velenosa o di malattia.\n\nL'incantesimo può penetrare la maggior parte delle barriere, ma è bloccato da 30 cm di pietra, 2,5 cm di metallo comune, una sottile lamina di piombo o 90 cm di legno o terra.",
					HigherLevels = null
				}
			}
		};
	}
}
