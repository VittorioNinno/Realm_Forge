using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Moderately Armored feat (2024 ruleset).
///	</summary>
public static class ModeratelyArmored2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555576");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551261");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551262");

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
			PrerequisiteFeature = FeatFeatureRequirement.LightArmor,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Moderately Armored",
					Description = "You have learned to fight protected by medium armor.\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Armor Training.** You gain training with Medium armor."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Corazze Medie",
					Description = "Il personaggio ha imparato a combattere protetto da un'armatura media.\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Competenza nelle Armature.** Ottiene l'addestramento nelle armature medie."
				}
			}
		};
	}
}