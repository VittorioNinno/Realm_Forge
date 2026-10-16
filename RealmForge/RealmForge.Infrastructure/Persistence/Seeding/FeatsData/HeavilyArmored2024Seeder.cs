using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Heavily Armored feat (2024 ruleset).
///	</summary>
public static class HeavilyArmored2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555568");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551181");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551182");

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
			Category = FeatCategory.General,
			PrerequisiteMinimumLevel = 4,
			PrerequisiteFeature = FeatFeatureRequirement.MediumArmor,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Heavily Armored",
					Description = "You have learned to fight under the heaviest protection.\n- **Constitution or Strength +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Heavy Armor Training.** You gain training with Heavy armor."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Corazze Pesanti",
					Description = "Il personaggio ha imparato a combattere sotto le protezioni più pesanti.\n- **Costituzione o Forza +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Addestramento nelle armature pesanti.** Ottiene l'addestramento nelle armature pesanti."
				}
			}
		};
	}
}