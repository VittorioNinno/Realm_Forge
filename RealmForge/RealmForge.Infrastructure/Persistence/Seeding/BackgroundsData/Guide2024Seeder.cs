using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Guide (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping the
///	official game terms and mechanics. Grants the Magic Initiate origin feat with the Druid spell list.
///	</summary>
public static class Guide2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "guide");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Constitution, AbilityScore.Wisdom },
			SkillProficiencies = new List<Skill> { Skill.Stealth, Skill.Survival },
			OriginFeatId = MagicInitiate2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "guide", "en"),
					Language = LanguageCode.En,
					Name = "Guide",
					Description = "You grew up in the open air, far from any settlement, and home was wherever you decided to unroll your bedroll. The wilderness is full of wonders: strange monsters, untouched forests and streams, the overgrown ruins of great halls where giants once walked. Exploring them taught you to look after yourself. Now and then you led friendly nature priests through the wilds, and they taught you the basics of channeling the magic of the natural world.",
					ToolProficiencies = "Cartographer's Tools",
					Equipment = "Shortbow\n20 Arrows\nCartographer's Tools\nBedroll\nQuiver\nTent\nTraveler's Clothes\n3 GP",
					OriginFeatNote = "Druid"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "guide", "it"),
					Language = LanguageCode.It,
					Name = "Guida",
					Description = "Il personaggio è cresciuto all'aria aperta, lontano da ogni insediamento, e la sua casa era ovunque decidesse di stendere il giaciglio. Le terre selvagge sono piene di meraviglie: strani mostri, foreste e torrenti incontaminati, le rovine invase dalla vegetazione di grandi sale un tempo percorse dai giganti. Esplorandole ha imparato a cavarsela da solo. Di tanto in tanto ha fatto da guida a sacerdoti della natura ben disposti, che gli hanno insegnato le basi per incanalare la magia del mondo naturale.",
					ToolProficiencies = "Strumenti da cartografo",
					Equipment = "Arco corto\n20 frecce\nStrumenti da cartografo\nGiaciglio\nFaretra\nTenda\nAbiti da viaggiatore\n3 mo",
					OriginFeatNote = "Druido"
				}
			}
		};
	}
}
