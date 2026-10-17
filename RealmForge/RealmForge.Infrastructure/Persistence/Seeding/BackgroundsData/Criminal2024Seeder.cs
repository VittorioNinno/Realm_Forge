using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Criminal (2024 ruleset), from the System Reference Document 5.2 (CC BY 4.0). Grants the Alert origin feat.
///	</summary>
public static class Criminal2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "criminal");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Constitution, AbilityScore.Intelligence },
			SkillProficiencies = new List<Skill> { Skill.SleightOfHand, Skill.Stealth },
			OriginFeatId = Alert2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "criminal", "en"),
					Language = LanguageCode.En,
					Name = "Criminal",
					Description = "You eked out a living in dark alleyways, cutting purses or burgling shops. Perhaps you were part of a small gang of like-minded wrongdoers who looked out for each other. Or maybe you were a lone wolf, fending for yourself against the local thieves' guild and more fearsome lawbreakers.",
					ToolProficiencies = "Thieves' Tools",
					Equipment = "2 Daggers\nThieves' Tools\nCrowbar\n2 Pouches\nTraveler's Clothes\n16 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "criminal", "it"),
					Language = LanguageCode.It,
					Name = "Criminale",
					Description = "Il personaggio è riuscito a sopravvivere nei vicoli più bui borseggiando i passanti e rapinando i negozi. Magari faceva parte di una piccola banda di malviventi dalla mentalità affine, pervasa da un certo senso di fratellanza. Oppure era un lupo solitario impegnato a guardarsi le spalle dalla gilda dei ladri locale e da altri temibili manigoldi.",
					ToolProficiencies = "Arnesi da scasso",
					Equipment = "2 pugnali\nArnesi da scasso\nPiede di porco\n2 borse\nAbiti da viaggiatore\n16 mo"
				}
			}
		};
	}
}
