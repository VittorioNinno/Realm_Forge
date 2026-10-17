using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Wayfarer (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping
///	the official game terms and mechanics. Grants the Lucky origin feat.
///	</summary>
public static class Wayfarer2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "wayfarer");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Wisdom, AbilityScore.Charisma },
			SkillProficiencies = new List<Skill> { Skill.Insight, Skill.Stealth },
			OriginFeatId = Lucky2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "wayfarer", "en"),
					Language = LanguageCode.En,
					Name = "Wayfarer",
					Description = "You grew up on the streets among other castoffs as unlucky as you, some of them friends and some of them rivals. You slept wherever you could and took odd jobs for a meal. When hunger grew too much to bear, you sometimes turned to stealing. Even so, you never lost your pride or gave up hope. Fate is not done with you yet.",
					ToolProficiencies = "Thieves' Tools",
					Equipment = "2 Daggers\nThieves' Tools\nGaming Set (any)\nBedroll\n2 Pouches\nTraveler's Clothes\n16 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "wayfarer", "it"),
					Language = LanguageCode.It,
					Name = "Viandante",
					Description = "Il personaggio è cresciuto per strada tra altri reietti sfortunati quanto lui, alcuni amici e altri rivali. Dormiva dove capitava e si arrangiava con lavoretti in cambio di un pasto. Quando la fame diventava insopportabile, a volte finiva per rubare. Eppure non ha mai perso l'orgoglio né la speranza. Il destino non ha ancora finito con lui.",
					ToolProficiencies = "Arnesi da scasso",
					Equipment = "2 pugnali\nArnesi da scasso\nSet da gioco (qualsiasi)\nGiaciglio\n2 borse\nAbiti da viaggiatore\n16 mo"
				}
			}
		};
	}
}
