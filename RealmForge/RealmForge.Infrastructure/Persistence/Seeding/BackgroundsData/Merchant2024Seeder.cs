using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Merchant (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping
///	the official game terms and mechanics. Grants the Lucky origin feat.
///	</summary>
public static class Merchant2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "merchant");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Constitution, AbilityScore.Intelligence, AbilityScore.Charisma },
			SkillProficiencies = new List<Skill> { Skill.AnimalHandling, Skill.Persuasion },
			OriginFeatId = Lucky2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "merchant", "en"),
					Language = LanguageCode.En,
					Name = "Merchant",
					Description = "You learned the basics of trade as the apprentice of a dealer, a caravan master, or a shopkeeper. You traveled far and wide, making your living by buying and selling the raw materials that artisans need for their work, or the finished goods they produce. Perhaps you carried wares from place to place by ship, wagon, or caravan, or bought them from traveling traders to resell in a shop of your own.",
					ToolProficiencies = "Navigator's Tools",
					Equipment = "Navigator's Tools\n2 Pouches\nTraveler's Clothes\n22 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "merchant", "it"),
					Language = LanguageCode.It,
					Name = "Mercante",
					Description = "Il personaggio ha imparato le basi del commercio come apprendista di un mercante, di un mastro carovaniere o di un bottegaio. Ha viaggiato in lungo e in largo, guadagnandosi da vivere comprando e vendendo le materie prime che servono agli artigiani per il loro lavoro, o i prodotti finiti che ne ricavano. Forse trasportava merci da un luogo all'altro per nave, su carro o in carovana, oppure le comprava da mercanti itineranti per rivenderle in una bottega tutta sua.",
					ToolProficiencies = "Strumenti da navigatore",
					Equipment = "Strumenti da navigatore\n2 borse\nAbiti da viaggiatore\n22 mo"
				}
			}
		};
	}
}
