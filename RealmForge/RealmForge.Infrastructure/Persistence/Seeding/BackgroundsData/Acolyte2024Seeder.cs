using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Acolyte (2024 ruleset), from the System Reference Document 5.2 (CC BY 4.0). Grants the Magic Initiate origin
///	feat with the Cleric spell list.
///	</summary>
public static class Acolyte2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "acolyte");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Intelligence, AbilityScore.Wisdom, AbilityScore.Charisma },
			SkillProficiencies = new List<Skill> { Skill.Insight, Skill.Religion },
			OriginFeatId = MagicInitiate2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "acolyte", "en"),
					Language = LanguageCode.En,
					Name = "Acolyte",
					Description = "You devoted yourself to service in a temple, either nestled in a town or secluded in a sacred grove. There you performed rites in honor of a god or pantheon. You served under a priest and studied religion. Thanks to your priest's instruction and your own devotion, you also learned how to channel a modicum of divine power in service to your place of worship and the people who prayed there.",
					ToolProficiencies = "Calligrapher's Supplies",
					Equipment = "Calligrapher's Supplies\nBook (prayers)\nHoly Symbol\nParchment (10 sheets)\nRobe\n8 GP",
					OriginFeatNote = "Cleric"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "acolyte", "it"),
					Language = LanguageCode.It,
					Name = "Accolito",
					Description = "Il personaggio ha trascorso la sua vita in un tempio situato in una zona appartata di una cittadina o nascosto in un bosco sacro. Lì celebrava dei riti in onore degli dei o di un pantheon ed era al servizio di un sacerdote, mentre si dedicava allo studio delle religioni. Grazie a questo mentore e alla propria devozione, ha imparato come incanalare una certa quantità di potere divino per servire il suo luogo di culto e i fedeli.",
					ToolProficiencies = "Scorte da calligrafo",
					Equipment = "Scorte da calligrafo\nLibro (preghiere)\nSimbolo sacro\nPergamena (10 fogli)\nTunica\n8 mo",
					OriginFeatNote = "Chierico"
				}
			}
		};
	}
}
