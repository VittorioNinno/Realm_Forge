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
					Description = "When you use your action to Dash, you can use a bonus action to make one melee weapon attack or to shove a creature.\nIf you move at least 10 feet in a straight line immediately before taking this bonus action, you either gain a +5 bonus to the attack's damage roll (if you chose to make a melee attack and hit) or push the target up to 10 feet away from you (if you chose to shove and you succeed)."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Carica",
					Description = "Quando il personaggio usa la sua azione di Scatto, può usare un'azione bonus per effettuare un attacco con un'arma da mischia o per spingere una creatura.\nSe si muove di almeno 3 metri in linea retta subito prima di effettuare questa azione bonus, sceglie se ottenere un bonus di +5 al tiro per i danni dell'attacco (se ha scelto di effettuare un attacco in mischia e ha colpito) o di spingere il bersaglio fino a un massimo di 3 metri allontanandolo da sé (se ha scelto di spingere e ha avuto successo)."
				}
			}
		};
	}
}