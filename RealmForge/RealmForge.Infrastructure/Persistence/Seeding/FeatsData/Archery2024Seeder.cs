using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Archery feat (2024 ruleset).
///	</summary>
public static class Archery2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555597");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551471");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551472");

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
					Name = "Archery",
					Description = "You gain a +2 bonus to attack rolls you make with Ranged weapons."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Tiro",
					Description = "Il personaggio ottiene un bonus di +2 ai tiri per colpire che effettua con le armi a distanza."
				}
			}
		};
	}
}