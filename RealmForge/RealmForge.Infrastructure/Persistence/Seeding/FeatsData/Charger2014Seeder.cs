using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Charger feat (2014 ruleset).
///	</summary>
public static class Charger2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555505");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555551");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555552");

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
					Name = "Charger",
					Description = "You turn a sprint into a weapon.\n- When you take the Dash action, you can use a bonus action to make one melee weapon attack or to shove a creature.\n- If you moved at least 10 feet in a straight line right before that bonus action, a hit with the melee attack deals 5 extra damage, or a successful shove pushes the target up to 10 feet away from you."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Carica",
					Description = "Il personaggio trasforma lo slancio in un'arma.\n- Quando usa l'azione Scatto, può usare un'azione bonus per effettuare un attacco con un'arma da mischia o per spingere una creatura.\n- Se subito prima di quell'azione bonus si è mosso di almeno 3 metri in linea retta, l'attacco da mischia, se colpisce, infligge 5 danni aggiuntivi, oppure la spinta, se riesce, allontana il bersaglio fino a 3 metri da lui."
				}
			}
		};
	}
}