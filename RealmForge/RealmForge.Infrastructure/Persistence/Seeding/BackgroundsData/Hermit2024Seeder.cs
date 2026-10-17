using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Hermit (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping the
///	official game terms and mechanics. Grants the Healer origin feat.
///	</summary>
public static class Hermit2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "hermit");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Constitution, AbilityScore.Wisdom, AbilityScore.Charisma },
			SkillProficiencies = new List<Skill> { Skill.Medicine, Skill.Religion },
			OriginFeatId = Healer2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "hermit", "en"),
					Language = LanguageCode.En,
					Name = "Hermit",
					Description = "You spent your early years in seclusion, in a hut or a monastery far beyond the edge of the nearest settlement. Back then your only company was the creatures of the forest and the occasional visitor who brought supplies and news of the world outside. Solitude gave you long hours to reflect on the mysteries of creation.",
					ToolProficiencies = "Herbalism Kit",
					Equipment = "Quarterstaff\nHerbalism Kit\nBedroll\nBook (philosophy)\nLamp\nOil (3 flasks)\nTraveler's Clothes\n16 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "hermit", "it"),
					Language = LanguageCode.It,
					Name = "Eremita",
					Description = "Il personaggio ha trascorso i suoi primi anni in isolamento, in una capanna o in un monastero ben oltre i confini dell'insediamento più vicino. A quel tempo la sua sola compagnia erano le creature della foresta e qualche raro visitatore che gli portava provviste e notizie dal mondo esterno. La solitudine gli ha concesso lunghe ore per riflettere sui misteri della creazione.",
					ToolProficiencies = "Borsa da erborista",
					Equipment = "Bastone ferrato\nBorsa da erborista\nGiaciglio\nLibro (filosofia)\nLampada\nOlio (3 ampolle)\nAbiti da viaggiatore\n16 mo"
				}
			}
		};
	}
}
