using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

/// <summary>
/// Provides deterministic database seeding for the Defensive Duelist feat (2024 ruleset).
/// </summary>
public static class DefensiveDuelist2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555561");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551111");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551112");

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
					Name = "Defensive Duelist",
					Description = "Your light blade turns aside the blows aimed at you.\n- **Dexterity +1.** Increase your Dexterity score by 1, to a maximum of 20.\n- **Parry.** While holding a Finesse weapon, when another creature hits you with a melee attack you can use your Reaction to add your Proficiency Bonus to your AC, possibly turning the hit into a miss. The bonus lasts against melee attacks until the start of your next turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Duellante Difensivo",
					Description = "La lama leggera del personaggio devia i colpi diretti contro di lui.\n- **Destrezza +1.** Il punteggio di Destrezza aumenta di 1, fino a un massimo di 20.\n- **Parata.** Mentre impugna un'arma accurata, quando un'altra creatura lo colpisce con un attacco in mischia può usare la Reazione per aggiungere il suo bonus di competenza alla CA, che potrebbe così far mancare il colpo. Il bonus resta valido contro gli attacchi in mischia fino all'inizio del suo turno successivo."
				}
			}
		};
	}
}