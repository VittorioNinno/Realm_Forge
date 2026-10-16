using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Interception feat (2024 ruleset).
///	</summary>
public static class Interception2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555602");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551521");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551522");

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
					Name = "Interception",
					Description = "You step in to soften blows meant for your allies.\n- **Intercept.** When a creature you can see hits another creature within 5 feet of you with an attack roll, you can use your Reaction to reduce the damage the target takes by 1d10 + your Proficiency Bonus. You must be holding a Shield or a Simple or Martial weapon to do this."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Intercettazione",
					Description = "Il personaggio si frappone per attutire i colpi diretti ai suoi alleati.\n- **Intercettare.** Quando una creatura che può vedere colpisce con un tiro per colpire un'altra creatura entro 1,5 metri da lui, può usare la Reazione per ridurre i danni subiti dal bersaglio di 1d10 + il suo bonus di competenza. Per farlo deve impugnare uno scudo o un'arma semplice o da guerra."
				}
			}
		};
	}
}