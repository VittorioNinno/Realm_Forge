using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Sailor (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping the
///	official game terms and mechanics. Grants the Tavern Brawler origin feat.
///	</summary>
public static class Sailor2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "sailor");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity, AbilityScore.Wisdom },
			SkillProficiencies = new List<Skill> { Skill.Acrobatics, Skill.Perception },
			OriginFeatId = TavernBrawler2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "sailor", "en"),
					Language = LanguageCode.En,
					Name = "Sailor",
					Description = "You lived the life of a seafarer, with the wind at your back and a rolling deck under your feet. You have propped yourself on tavern stools in more ports than you can count, weathered fierce storms, and traded tales with the folk who dwell beneath the waves.",
					ToolProficiencies = "Navigator's Tools",
					Equipment = "Dagger\nNavigator's Tools\nRope\nTraveler's Clothes\n20 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "sailor", "it"),
					Language = LanguageCode.It,
					Name = "Marinaio",
					Description = "Il personaggio ha vissuto da uomo di mare, con il vento alle spalle e il ponte che rollava sotto i piedi. Si è seduto al bancone delle taverne in più porti di quanti ne ricordi, ha affrontato tempeste furiose e si è scambiato racconti con le genti che vivono sotto le onde.",
					ToolProficiencies = "Strumenti da navigatore",
					Equipment = "Pugnale\nStrumenti da navigatore\nCorda\nAbiti da viaggiatore\n20 mo"
				}
			}
		};
	}
}
