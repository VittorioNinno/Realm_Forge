using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Farmer (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping the
///	official game terms and mechanics. Grants the Tough origin feat.
///	</summary>
public static class Farmer2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "farmer");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Constitution, AbilityScore.Wisdom },
			SkillProficiencies = new List<Skill> { Skill.AnimalHandling, Skill.Nature },
			OriginFeatId = Tough2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "farmer", "en"),
					Language = LanguageCode.En,
					Name = "Farmer",
					Description = "You grew up working the land. Years spent caring for animals and tilling the soil gave you patience and a sturdy constitution. You deeply value what nature provides, and you hold a healthy respect for its fury.",
					ToolProficiencies = "Carpenter's Tools",
					Equipment = "Sickle\nCarpenter's Tools\nHealer's Kit\nIron Pot\nShovel\nTraveler's Clothes\n30 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "farmer", "it"),
					Language = LanguageCode.It,
					Name = "Contadino",
					Description = "Il personaggio è cresciuto lavorando la terra. Gli anni passati ad accudire gli animali e a coltivare i campi gli hanno dato pazienza e una salute di ferro. Apprezza profondamente ciò che la natura offre e nutre un sano rispetto per la sua furia.",
					ToolProficiencies = "Strumenti da falegname",
					Equipment = "Falcetto\nStrumenti da falegname\nBorsa del guaritore\nPentola di ferro\nPala\nAbiti da viaggiatore\n30 mo"
				}
			}
		};
	}
}
