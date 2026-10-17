using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Skulker feat (2024 ruleset).
///	</summary>
public static class Skulker2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555589");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551391");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551392");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Dexterity },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Skulker",
					Description = "Shadows and confusion are your allies.\n- **Ability Score Increase.** Increase your Dexterity score by 1, to a maximum of 20.\n- **Blindsight.** You have Blindsight out to 10 feet.\n- **Fog of War.** In combat, you have Advantage on Dexterity (Stealth) checks you make as part of the Hide action.\n- **Sniper.** If you miss with an attack roll while hidden, the attack doesn't reveal where you are."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Appostato",
					Description = "L'ombra e la confusione sono alleate del personaggio.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Destrezza aumenta di 1, fino a un massimo di 20.\n- **Vista Cieca.** Ha Vista Cieca entro 3 metri.\n- **Nebbia della Guerra.** In combattimento ha Vantaggio alle prove di Destrezza (Furtività) effettuate come parte dell'azione Nascondersi.\n- **Cecchino.** Se manca un tiro per colpire mentre è nascosto, l'attacco non rivela dove si trova."
				}
			}
		};
	}
}