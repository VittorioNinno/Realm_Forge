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
					Description = "You pick up new abilities quickly.\n- Choose any three skills or tools, in any combination, and gain proficiency with them."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Abile",
					Description = "Il personaggio impara in fretta.\n- Sceglie tre abilità o strumenti, in qualsiasi combinazione, e ne ottiene la competenza."
				}
			}
		};
	}
}