using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Weapon Master feat (2014 ruleset).
///	</summary>
public static class WeaponMaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555543");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555931");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555932");

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
					Name = "Weapon Master",
					Description = "You have practiced with many kinds of weapons.\n- Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- You gain proficiency with four weapons of your choice."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro d'Armi",
					Description = "Il personaggio si è esercitato con molti tipi di armi.\n- Il punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- Ottiene competenza in quattro armi a sua scelta."
				}
			}
		};
	}
}