using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Lucky feat (2014 ruleset).
///	</summary>
public static class Lucky2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555521");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555711");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555712");

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
					Name = "Lucky",
					Description = "Fortune has a habit of smiling on you.\n- **Luck Points.** You have 3 luck points, and you regain all of them when you finish a long rest.\n- **Push Your Luck.** When you make an attack roll, ability check, or saving throw, you can spend 1 luck point to roll an extra d20, even after rolling but before the outcome is revealed, and then choose which d20 to use.\n- **Turn the Odds.** When a creature makes an attack roll against you, you can spend 1 luck point to roll a d20 and decide whether the attack uses the attacker's roll or yours.\n- **Cancelling Out.** If several creatures spend luck points on the same roll, the points cancel out and no extra dice are rolled."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Fortunato",
					Description = "La fortuna ha l'abitudine di sorridere al personaggio.\n- **Punti fortuna.** Ha 3 punti fortuna e li recupera tutti quando termina un riposo lungo.\n- **Tentare la sorte.** Quando effettua un tiro per colpire, una prova di caratteristica o un tiro salvezza, può spendere 1 punto fortuna per tirare un d20 aggiuntivo, anche dopo il tiro ma prima di conoscerne l'esito, e poi scegliere quale d20 usare.\n- **Ribaltare le probabilità.** Quando una creatura effettua un tiro per colpire contro di lui, può spendere 1 punto fortuna per tirare un d20 e decidere se l'attacco usa il tiro dell'attaccante o il suo.\n- **Annullamento.** Se più creature spendono punti fortuna sullo stesso tiro, i punti si annullano a vicenda e non si tirano dadi aggiuntivi."
				}
			}
		};
	}
}