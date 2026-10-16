using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Lightly Armored feat (2014 ruleset).
///	</summary>
public static class LightlyArmored2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555519");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555691");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555692");

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
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Lightly Armored",
					Description = "You have learned to fight unhindered in light protection.\n- **Strength or Dexterity +1.** Increase one of the two scores by 1, to a maximum of 20.\n- **Light Armor Training.** You gain proficiency with light armor."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Corazze Leggere",
					Description = "Il personaggio ha imparato a combattere senza impacci con protezioni leggere.\n- **Forza o Destrezza +1.** Uno dei due punteggi aumenta di 1, fino a un massimo di 20.\n- **Addestramento nelle armature leggere.** Ottiene competenza nelle armature leggere."
				}
			}
		};
	}
}