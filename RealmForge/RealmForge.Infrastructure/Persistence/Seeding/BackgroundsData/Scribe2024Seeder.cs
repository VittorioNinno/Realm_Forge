using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Scribe (2024 ruleset). Not part of SRD 5.2: English and Italian texts are written for RealmForge, keeping the
///	official game terms and mechanics. Grants the Skilled origin feat.
///	</summary>
public static class Scribe2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "scribe");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Intelligence, AbilityScore.Wisdom },
			SkillProficiencies = new List<Skill> { Skill.Investigation, Skill.Perception },
			OriginFeatId = Skilled2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "scribe", "en"),
					Language = LanguageCode.En,
					Name = "Scribe",
					Description = "You spent your formative years in a scriptorium, in a monastery devoted to preserving knowledge, or in a government office, where you learned to write in a clear hand and to produce elegant texts. You may have drafted official documents or copied works of literature, and you might have a talent for poetry, storytelling, or scholarly writing. Above all, you pay close attention to detail, which keeps errors out of the documents you copy and compose.",
					ToolProficiencies = "Calligrapher's Supplies",
					Equipment = "Calligrapher's Supplies\nFine Clothes\nLamp\nOil (3 flasks)\nParchment (12 sheets)\n23 GP"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "scribe", "it"),
					Language = LanguageCode.It,
					Name = "Scriba",
					Description = "Il personaggio ha trascorso gli anni della sua formazione in uno scriptorium, in un monastero dedito alla conservazione del sapere o in un ufficio governativo, dove ha imparato a scrivere con grafia chiara e a produrre testi eleganti. Forse ha redatto documenti ufficiali o copiato opere letterarie, e potrebbe avere un certo talento per la poesia, la narrativa o la scrittura erudita. Soprattutto, presta grande attenzione ai dettagli, il che tiene lontani gli errori dai documenti che copia e compone.",
					ToolProficiencies = "Scorte da calligrafo",
					Equipment = "Scorte da calligrafo\nAbiti eleganti\nLampada\nOlio (3 ampolle)\nPergamena (12 fogli)\n23 mo"
				}
			}
		};
	}
}
