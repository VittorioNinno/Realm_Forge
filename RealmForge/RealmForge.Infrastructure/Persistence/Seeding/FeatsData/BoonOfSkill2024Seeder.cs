using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Skill feat (2024 ruleset).
///	</summary>
public static class BoonOfSkill2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555614");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551641");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551642");

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
			Category = FeatCategory.EpicBoon,
			PrerequisiteMinimumLevel = 19,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Boon of Skill",
					Description = "There is almost nothing you can't turn your hand to.\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **All-Around Adept.** You gain proficiency in every skill.\n- **Expertise.** Choose one skill in which you don't have Expertise: you gain Expertise in it."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono dell'Abilità",
					Description = "Non c'è quasi nulla in cui il personaggio non sappia cimentarsi.\n- **Incremento dei Punteggi di Caratteristica.** Un punteggio di caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Adepto Eclettico.** Ottiene competenza in tutte le abilità.\n- **Maestria.** Sceglie un'abilità in cui non ha Maestria: ottiene Maestria in quell'abilità."
				}
			}
		};
	}
}