using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Observant feat (2024 ruleset).
///	</summary>
public static class Observant2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555578");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551281");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551282");

	///	<summary>
	///	Builds the canonical SRD definition of this feat. Persistence is handled by FeatSeeder.
	///	</summary>
	public static Feat Build()
	{
		return new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			PrerequisiteMinimumLevel = 4,
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Intelligence, AbilityScore.Wisdom },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Observant",
					Description = "Little escapes your notice.\n- **Ability Score Increase.** Increase your Intelligence or Wisdom score by 1, to a maximum of 20.\n- **Keen Observer.** Pick Insight, Investigation, or Perception. You gain proficiency in that skill or, if you already have it, Expertise.\n- **Quick Search.** You can take the Search action as a Bonus Action."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Osservatore",
					Description = "Poco sfugge all'attenzione del personaggio.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Intelligenza o Saggezza aumenta di 1, fino a un massimo di 20.\n- **Osservatore Attento.** Sceglie Intuizione, Indagare o Percezione. Ottiene competenza in quell'abilità oppure, se l'ha già, Maestria.\n- **Ricerca Rapida.** Può effettuare l'azione Cercare come Azione Bonus."
				}
			}
		};
	}
}