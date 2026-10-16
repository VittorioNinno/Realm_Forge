using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Sharpshooter feat (2024 ruleset).
///	</summary>
public static class Sharpshooter2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555586");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551361");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551362");

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
			PrerequisiteAbilities = new List<AbilityScore> { AbilityScore.Dexterity },
			PrerequisiteMinimumScore = 13,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Sharpshooter",
					Description = "Your shots find their mark where others would miss.\n- **Dexterity +1.** Increase your Dexterity score by 1, to a maximum of 20.\n- **Around Cover.** Your ranged weapon attacks ignore Half Cover and Three-Quarters Cover.\n- **Point-Blank Shooting.** Having an enemy within 5 feet of you doesn't give you Disadvantage on attack rolls with Ranged weapons.\n- **Long Shots.** Attacking at long range doesn't give you Disadvantage on attack rolls with Ranged weapons."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Tiratore Scelto",
					Description = "I tiri del personaggio vanno a segno dove altri mancherebbero.\n- **Destrezza +1.** Il punteggio di Destrezza aumenta di 1, fino a un massimo di 20.\n- **Oltre la copertura.** I suoi attacchi con armi a distanza ignorano la mezza copertura e la copertura tre quarti.\n- **Tiro ravvicinato.** Avere un nemico entro 1,5 metri non gli impone Svantaggio ai tiri per colpire con armi a distanza.\n- **Tiri lunghi.** Attaccare a gittata lunga non gli impone Svantaggio ai tiri per colpire con armi a distanza."
				}
			}
		};
	}
}