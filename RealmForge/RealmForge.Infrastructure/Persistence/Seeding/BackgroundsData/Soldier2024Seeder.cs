using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Soldier (2024 ruleset), from the System Reference Document 5.2 (CC BY 4.0). Grants the Savage Attacker origin
///	feat.
///	</summary>
public static class Soldier2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "soldier");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity, AbilityScore.Constitution },
			SkillProficiencies = new List<Skill> { Skill.Athletics, Skill.Intimidation },
			OriginFeatId = SavageAttacker2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "soldier", "en"),
					Language = LanguageCode.En,
					Name = "Soldier",
					Description = "You began training for war as soon as you reached adulthood and carry precious few memories of life before you took up arms. Battle is in your blood. Sometimes you catch yourself reflexively performing the basic fighting exercises you learned first. Eventually, you put that training to use on the battlefield, protecting the realm by waging war.",
					ToolProficiencies = "One kind of Gaming Set of your choice",
					Equipment = "Spear\nShortbow\n20 Arrows\nGaming Set (the one chosen above)\nHealer's Kit\nQuiver\nTraveler's Clothes\n14 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "soldier", "it"),
					Language = LanguageCode.It,
					Name = "Soldato",
					Description = "Il personaggio ha iniziato il suo addestramento nell'arte della guerra non appena è diventato adulto e gli sono rimasti ben pochi ricordi della vita prima di impugnare le armi. Ha la battaglia nel sangue. A volte si ritrova a eseguire d'istinto gli esercizi di combattimento basilari che ha imparato per primi. Alla fine ha messo a frutto quell'addestramento sul campo di battaglia, proteggendo il regno combattendo le sue guerre.",
					ToolProficiencies = "Un tipo di set da gioco a scelta",
					Equipment = "Lancia\nArco corto\n20 frecce\nSet da gioco (lo stesso scelto sopra)\nBorsa del guaritore\nFaretra\nAbiti da viaggiatore\n14 mo"
				}
			}
		};
	}
}
