using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Sentinel feat (2024 ruleset).
///	</summary>
public static class Sentinel2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555584");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551341");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551342");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Sentinel",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Guardian.** Immediately after a creature within 5 feet of you takes the Disengage action or hits a target other than you with an attack, you can make an Opportunity Attack against that creature.\n- **Halt.** When you hit a creature with an Opportunity Attack, the creature's Speed becomes 0 for the rest of the current turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Sentinella",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Guardiano.** Subito dopo che una creatura entro 1,5 metri dal personaggio effettua un'azione di Disimpegno o colpisce un bersaglio diverso dal personaggio con un attacco, quest'ultimo può eseguire un Attacco di Opportunità contro la creatura.\n- **Fermo.** Quando il personaggio colpisce una creatura con un Attacco di Opportunità, la velocità della creatura scende a 0 per il resto del turno in corso."
				}
			}
		};
	}
}