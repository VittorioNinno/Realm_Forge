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
					Description = "You fight by sound and instinct as much as by sight.\n- **Blindsight.** You have Blindsight out to 10 feet."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattere alla Cieca",
					Description = "Il personaggio combatte affidandosi all'udito e all'istinto quanto alla vista.\n- **Vista cieca.** Ha vista cieca entro 3 metri."
				}
			}
		};
	}
}