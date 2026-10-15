using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Blind Fighting feat (2024 ruleset).
///	</summary>
public static class BlindFighting2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555598");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551481");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551482");

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
			Category = FeatCategory.FightingStyle,
			PrerequisiteFeature = FeatFeatureRequirement.FightingStyle,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Blind Fighting",
					Description = "You have Blindsight with a range of 10 feet."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattere alla Cieca",
					Description = "Il personaggio ottiene Vista Cieca con un raggio di 3 metri."
				}
			}
		};
	}
}