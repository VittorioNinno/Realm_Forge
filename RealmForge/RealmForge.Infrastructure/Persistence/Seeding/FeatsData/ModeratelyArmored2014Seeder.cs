using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Moderately Armored feat (2014 ruleset).
///	</summary>
public static class ModeratelyArmored2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555527");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555771");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555772");

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
			PrerequisiteFeature = FeatFeatureRequirement.LightArmor,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Moderately Armored",
					Description = "You have learned to fight behind medium armor and a shield.\n- **Strength or Dexterity +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Armor Training.** You gain proficiency with medium armor and shields."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Corazze Medie",
					Description = "Il personaggio ha imparato a combattere protetto da un'armatura media e da uno scudo.\n- **Forza o Destrezza +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Addestramento.** Ottiene competenza nelle armature medie e negli scudi."
				}
			}
		};
	}
}