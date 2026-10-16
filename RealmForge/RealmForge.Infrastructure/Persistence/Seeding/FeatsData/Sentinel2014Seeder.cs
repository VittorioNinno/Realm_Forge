using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Sentinel feat (2014 ruleset).
///	</summary>
public static class Sentinel2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555534");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555841");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555842");

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
					Name = "Sentinel",
					Description = "Enemies near you can neither slip away nor ignore you.\n- **Stop in Their Tracks.** A creature you hit with an opportunity attack has its speed reduced to 0 for the rest of the turn.\n- **No Easy Exit.** Creatures within 5 feet of you provoke opportunity attacks from you even if they take the Disengage action before leaving your reach.\n- **Protector.** When a creature within 5 feet of you attacks a target other than you, and that target doesn't have this feat, you can use your reaction to make a melee weapon attack against the attacker."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Sentinella",
					Description = "I nemici vicini al personaggio non possono né sgusciare via né ignorarlo.\n- **Fermarli sul posto.** Una creatura colpita da un suo attacco di opportunità ha velocità 0 per il resto del turno.\n- **Nessuna via di fuga.** Le creature entro 1,5 metri da lui provocano attacchi di opportunità anche se usano l'azione Disimpegno prima di uscire dalla sua portata.\n- **Protettore.** Quando una creatura entro 1,5 metri da lui attacca un bersaglio diverso da lui, e quel bersaglio non possiede questo talento, può usare la reazione per effettuare un attacco con un'arma da mischia contro l'attaccante."
				}
			}
		};
	}
}