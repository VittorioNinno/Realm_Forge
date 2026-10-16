using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Martial Weapon Training feat (2024 ruleset).
///	</summary>
public static class MartialWeaponTraining2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555574");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551241");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551242");

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
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Martial Weapon Training",
					Description = "You have trained with the weapons of professional soldiers.\n- **Strength or Dexterity +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Martial Weapons.** You gain proficiency with Martial weapons."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Competenza nelle Armi da Guerra",
					Description = "Il personaggio si è addestrato con le armi dei soldati di professione.\n- **Forza o Destrezza +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Armi da guerra.** Ottiene competenza nelle armi da guerra."
				}
			}
		};
	}
}