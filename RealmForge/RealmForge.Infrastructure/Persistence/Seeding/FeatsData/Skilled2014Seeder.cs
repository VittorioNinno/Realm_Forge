using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Skilled feat (2014 ruleset).
///	</summary>
public static class Skilled2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555537");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555871");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555872");

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
					Name = "Skilled",
					Description = "You gain proficiency in any combination of three skills or tools of your choice."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Abile",
					Description = "Il personaggio ottiene competenza in una qualsiasi combinazione di tre abilità o strumenti a sua scelta."
				}
			}
		};
	}
}