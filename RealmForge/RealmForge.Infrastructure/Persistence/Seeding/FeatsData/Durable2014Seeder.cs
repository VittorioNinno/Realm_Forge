using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Durable feat (2014 ruleset).
///	</summary>
public static class Durable2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555510");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555601");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555602");

	///	<summary>
	///	Builds the canonical SRD definition of this feat. Persistence is handled by FeatSeeder.
	///	</summary>
	public static Feat Build()
	{
		return new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Durable",
					Description = "Your body bounces back faster than most.\n- Increase your Constitution score by 1, to a maximum of 20.\n- When you roll a Hit Die to regain hit points, that die restores at least twice your Constitution modifier (never fewer than 2)."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Tenace",
					Description = "Il corpo del personaggio si riprende più in fretta di quello degli altri.\n- Il punteggio di Costituzione aumenta di 1, fino a un massimo di 20.\n- Quando tira un Dado Vita per recuperare punti ferita, quel dado gli restituisce almeno il doppio del suo modificatore di Costituzione (mai meno di 2)."
				}
			}
		};
	}
}