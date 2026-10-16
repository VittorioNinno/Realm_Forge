using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Sharpshooter feat (2014 ruleset).
///	</summary>
public static class Sharpshooter2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555535");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555851");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555852");

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
					Name = "Sharpshooter",
					Description = "Your shots find their mark where others would miss.\n- **Long Shots.** Attacking at long range doesn't give you disadvantage on ranged weapon attack rolls.\n- **Around Cover.** Your ranged weapon attacks ignore half cover and three-quarters cover.\n- **Power Shot.** Before attacking with a ranged weapon you are proficient with, you can accept a -5 penalty to the attack roll; if the attack hits, it deals 10 extra damage."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Tiratore Scelto",
					Description = "I tiri del personaggio vanno a segno dove altri mancherebbero.\n- **Tiri lunghi.** Attaccare a gittata lunga non gli impone svantaggio ai tiri per colpire con armi a distanza.\n- **Oltre la copertura.** I suoi attacchi con armi a distanza ignorano la mezza copertura e la copertura tre quarti.\n- **Tiro potente.** Prima di attaccare con un'arma a distanza in cui ha competenza, può accettare una penalità di -5 al tiro per colpire; se l'attacco colpisce, infligge 10 danni aggiuntivi."
				}
			}
		};
	}
}