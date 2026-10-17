using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Charlatan (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping
///	the official game terms and mechanics. Grants the Skilled origin feat.
///	</summary>
public static class Charlatan2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "charlatan");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Constitution, AbilityScore.Charisma },
			SkillProficiencies = new List<Skill> { Skill.Deception, Skill.SleightOfHand },
			OriginFeatId = Skilled2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "charlatan", "en"),
					Language = LanguageCode.En,
					Name = "Charlatan",
					Description = "As soon as you were old enough to order an ale, you claimed a favorite stool in every tavern within ten miles of your birthplace. Making the rounds from one inn to the next, you learned to prey on the unlucky souls who were looking for a comforting lie or two, such as a fake potion or a forged family tree.",
					ToolProficiencies = "Forgery Kit",
					Equipment = "Forgery Kit\nCostume\nFine Clothes\n15 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "charlatan", "it"),
					Language = LanguageCode.It,
					Name = "Ciarlatano",
					Description = "Appena ha avuto l'età per ordinare una birra, il personaggio si è conquistato uno sgabello preferito in ogni taverna nel raggio di 15 chilometri dal suo luogo di nascita. Passando da una locanda all'altra, ha imparato ad approfittarsi degli sfortunati in cerca di qualche bugia consolante, come una pozione fasulla o un albero genealogico contraffatto.",
					ToolProficiencies = "Arnesi da falsario",
					Equipment = "Arnesi da falsario\nCostume\nAbiti eleganti\n15 mo"
				}
			}
		};
	}
}
