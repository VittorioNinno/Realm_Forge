using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Heavily Armored feat (2014 ruleset).
///	</summary>
public static class HeavilyArmored2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555515");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555651");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555652");

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
			PrerequisiteFeature = FeatFeatureRequirement.MediumArmor,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Heavily Armored",
					Description = "You have learned to move and fight under the heaviest protection.\n- **Strength +1.** Increase your Strength score by 1, to a maximum of 20.\n- **Heavy Armor Training.** You gain proficiency with heavy armor."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Corazze Pesanti",
					Description = "Il personaggio ha imparato a muoversi e combattere sotto le protezioni più pesanti.\n- **Forza +1.** Il punteggio di Forza aumenta di 1, fino a un massimo di 20.\n- **Addestramento nelle armature pesanti.** Ottiene competenza nelle armature pesanti."
				}
			}
		};
	}
}