using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Keen Mind feat (2024 ruleset).
///	</summary>
public static class KeenMind2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555571");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551211");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551212");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Intelligence },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Keen Mind",
					Description = "You absorb knowledge quickly and retain it well.\n- **Ability Score Increase.** Increase your Intelligence score by 1, to a maximum of 20.\n- **Lore Knowledge.** Pick Arcana, History, Investigation, Nature, or Religion. You gain proficiency in that skill or, if you already have it, Expertise.\n- **Quick Study.** You can take the Study action as a Bonus Action."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Mente Acuta",
					Description = "Il personaggio assimila il sapere in fretta e lo conserva con cura.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Intelligenza aumenta di 1, fino a un massimo di 20.\n- **Conoscenza Profonda.** Sceglie Arcano, Storia, Indagare, Natura o Religione. Ottiene competenza in quell'abilità oppure, se l'ha già, Maestria.\n- **Studio Celere.** Può effettuare l'azione Studiare come Azione Bonus."
				}
			}
		};
	}
}