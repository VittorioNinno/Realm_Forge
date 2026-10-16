using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Skill Expert feat (2024 ruleset).
///	</summary>
public static class SkillExpert2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555588");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551381");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551382");

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
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Skill Expert",
					Description = "You have honed your talents to a remarkable degree.\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 20.\n- **Skill Proficiency.** You gain proficiency in one skill of your choice.\n- **Expertise.** Choose one skill you are proficient in but lack Expertise in: you gain Expertise in it."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Abilità Impeccabile",
					Description = "Il personaggio ha affinato i suoi talenti a un livello notevole.\n- **Incremento dei Punteggi di Caratteristica.** Un punteggio di caratteristica a scelta aumenta di 1, fino a un massimo di 20.\n- **Competenza nelle Abilità.** Ottiene competenza in un'abilità a sua scelta.\n- **Maestria.** Sceglie un'abilità in cui ha competenza ma non Maestria: ottiene Maestria in quell'abilità."
				}
			}
		};
	}
}