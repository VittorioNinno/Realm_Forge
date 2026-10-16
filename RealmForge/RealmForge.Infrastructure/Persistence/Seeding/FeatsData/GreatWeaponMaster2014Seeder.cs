using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Great Weapon Master feat (2014 ruleset).
///	</summary>
public static class GreatWeaponMaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555513");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555631");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555632");

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
					Name = "Great Weapon Master",
					Description = "Heavy weapons become an extension of your strength.\n- **Follow-Through.** On your turn, when a melee weapon attack of yours scores a critical hit or drops a creature to 0 hit points, you can make one melee weapon attack as a bonus action.\n- **All-Out Swing.** Before attacking with a heavy melee weapon you are proficient with, you can accept a -5 penalty to the attack roll; if the attack hits, it deals 10 extra damage."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro d'Armi Possenti",
					Description = "Le armi pesanti diventano un prolungamento della forza del personaggio.\n- **Colpo successivo.** Durante il suo turno, quando un suo attacco con un'arma da mischia mette a segno un colpo critico o porta una creatura a 0 punti ferita, può effettuare un attacco con un'arma da mischia come azione bonus.\n- **Colpo a tutta forza.** Prima di attaccare con un'arma da mischia pesante in cui ha competenza, può accettare una penalità di -5 al tiro per colpire; se l'attacco colpisce, infligge 10 danni aggiuntivi."
				}
			}
		};
	}
}