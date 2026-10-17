using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Dueling feat (2024 ruleset).
///	</summary>
public static class Dueling2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555600");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551501");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551502");

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
					Name = "Dueling",
					Description = "You favor a single blade and an open hand.\n\nWhile you hold a Melee weapon in one hand and no other weapons, you gain a +2 bonus to damage rolls with that weapon."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Duellare",
					Description = "Il personaggio predilige un'unica lama e la mano libera.\n\nMentre impugna un'arma da mischia in una mano e nessun'altra arma, ottiene un bonus di +2 ai tiri per i danni con quell'arma."
				}
			}
		};
	}
}