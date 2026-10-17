using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Sage (2024 ruleset), from the System Reference Document 5.2 (CC BY 4.0). Grants the Magic Initiate origin feat
///	with the Wizard spell list.
///	</summary>
public static class Sage2024Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "sage");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			AbilityOptions = new List<AbilityScore> { AbilityScore.Constitution, AbilityScore.Intelligence, AbilityScore.Wisdom },
			SkillProficiencies = new List<Skill> { Skill.Arcana, Skill.History },
			OriginFeatId = MagicInitiate2024Seeder.FeatId,
			EquipmentGoldAlternative = 50,
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "sage", "en"),
					Language = LanguageCode.En,
					Name = "Sage",
					Description = "You spent your formative years traveling between manors and monasteries, performing various odd jobs and services in exchange for access to their libraries. You whiled away many a long evening studying books and scrolls, learning the lore of the multiverse—even the rudiments of magic—and your mind yearns for more.",
					ToolProficiencies = "Calligrapher's Supplies",
					Equipment = "Quarterstaff\nCalligrapher's Supplies\nBook (history)\nParchment (8 sheets)\nRobe\n8 GP",
					OriginFeatNote = "Wizard"
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "background", "sage", "it"),
					Language = LanguageCode.It,
					Name = "Sapiente",
					Description = "Il personaggio ha trascorso la sua gioventù tra ville e monasteri, svolgendo svariate mansioni in cambio dell'accesso alle biblioteche di quei luoghi. Sono molte le notti che ha passato studiando libri e pergamene per scoprire di più sul multiverso, e perfino i rudimenti della magia, ma la sua mente non ne ha mai abbastanza.",
					ToolProficiencies = "Scorte da calligrafo",
					Equipment = "Bastone ferrato\nScorte da calligrafo\nLibro (storia)\nPergamena (8 fogli)\nTunica\n8 mo",
					OriginFeatNote = "Mago"
				}
			}
		};
	}
}
