using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Defense feat (2024 ruleset).
///	</summary>
public static class Defense2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555599");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551491");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551492");

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
			Source = ContentSource.Srd52,
			Category = FeatCategory.FightingStyle,
			PrerequisiteFeature = FeatFeatureRequirement.FightingStyle,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Defense",
					Description = "While you're wearing Light, Medium, or Heavy armor, you gain a +1 bonus to Armor Class."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Difesa",
					Description = "Finché il personaggio indossa un'armatura Leggera, Media o Pesante, ottiene un bonus di +1 alla Classe Armatura."
				}
			}
		};
	}
}