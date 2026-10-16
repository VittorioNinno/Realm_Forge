using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Durable feat (2024 ruleset).
///	</summary>
public static class Durable2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555563");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551131");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551132");

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
					Name = "Durable",
					Description = "Your body resists hardship and recovers quickly.\n- **Ability Score Increase.** Increase your Constitution score by 1, to a maximum of 20.\n- **Defy Death.** You have Advantage on Death Saving Throws.\n- **Speedy Recovery.** As a Bonus Action, you can spend one Hit Point Die, roll it, and regain Hit Points equal to the result."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Tenace",
					Description = "Il corpo del personaggio resiste alle avversità e si riprende in fretta.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Costituzione aumenta di 1, fino a un massimo di 20.\n- **Sfuggire alla Morte.** Ha Vantaggio ai Tiri Salvezza contro la Morte.\n- **Recupero Rapido.** Come Azione Bonus, può spendere un Dado Vita, tirarlo e recuperare Punti Ferita pari al risultato."
				}
			}
		};
	}
}