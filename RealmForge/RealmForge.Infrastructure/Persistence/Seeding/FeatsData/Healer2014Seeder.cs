using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Healer feat (2014 ruleset).
///	</summary>
public static class Healer2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555514");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555641");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555642");

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
					Name = "Healer",
					Description = "Your field medicine keeps your companions on their feet.\n- **Stabilize and Revive.** When you stabilize a dying creature with a healer's kit, it also regains 1 hit point.\n- **Field Treatment.** As an action, you can expend one use of a healer's kit to treat a creature, which regains 1d6 + 4 hit points plus as many hit points as its maximum number of Hit Dice. A creature can benefit from this treatment again only after finishing a short or long rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Guaritore",
					Description = "Le cure da campo del personaggio tengono in piedi i suoi compagni.\n- **Stabilizzare e rianimare.** Quando stabilizza una creatura morente con una borsa del guaritore, quella creatura recupera anche 1 punto ferita.\n- **Cure sul campo.** Come azione, può spendere un utilizzo di una borsa del guaritore per curare una creatura, che recupera 1d6 + 4 punti ferita più tanti punti ferita quanto il suo numero massimo di Dadi Vita. La stessa creatura può beneficiare di nuovo di queste cure solo dopo aver terminato un riposo breve o lungo."
				}
			}
		};
	}
}