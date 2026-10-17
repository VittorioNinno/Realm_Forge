using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Artisan (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping
///	the official game terms and mechanics. Grants the Crafter origin feat.
///	</summary>
public static class Artisan2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "artisan");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity, AbilityScore.Intelligence },
			SkillProficiencies = new List<Skill> { Skill.Investigation, Skill.Persuasion },
			OriginFeatId = Crafter2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "artisan", "en"),
					Language = LanguageCode.En,
					Name = "Artisan",
					Description = "As soon as you could lift a bucket, you were earning a few coppers a day sweeping floors and scrubbing workbenches in an artisan's workshop. Once you were old enough to become an apprentice, you learned to make simple goods of your own, and how to charm even the fussiest customer. Your craft has also trained your eye to catch every detail.",
					ToolProficiencies = "One kind of Artisan's Tools of your choice",
					Equipment = "Artisan's Tools (the kind chosen above)\n2 Pouches\nTraveler's Clothes\n32 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "artisan", "it"),
					Language = LanguageCode.It,
					Name = "Artigiano",
					Description = "Da quando è stato abbastanza forte da sollevare un secchio, il personaggio ha guadagnato qualche moneta di rame al giorno spazzando pavimenti e strofinando banchi da lavoro nella bottega di un artigiano. Appena ha avuto l'età per fare l'apprendista, ha imparato a realizzare oggetti semplici tutti suoi, e a conquistare anche il cliente più esigente. Il mestiere gli ha anche allenato l'occhio a cogliere ogni dettaglio.",
					ToolProficiencies = "Un tipo di strumenti da artigiano a scelta",
					Equipment = "Strumenti da artigiano (dello stesso tipo scelto sopra)\n2 borse\nAbiti da viaggiatore\n32 mo"
				}
			}
		};
	}
}
