using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Polearm Master feat (2014 ruleset).
///	</summary>
public static class PolearmMaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555530");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555801");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555802");

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
					Name = "Polearm Master",
					Description = "Reach weapons let you control the space around you.\n- **Butt Strike.** When you take the Attack action and attack only with a glaive, halberd, or quarterstaff, you can use a bonus action to make a melee attack with the other end of the weapon. This attack uses a d4 as its damage die and deals bludgeoning damage.\n- **Guarded Reach.** While you wield a glaive, halberd, pike, or quarterstaff, creatures provoke an opportunity attack from you when they enter your reach."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro delle Armi su Asta",
					Description = "Le armi con portata permettono al personaggio di controllare lo spazio intorno a sé.\n- **Colpo d'impugnatura.** Quando usa l'azione Attacco e attacca solo con un falcione, un'alabarda o un bastone ferrato, può usare un'azione bonus per effettuare un attacco in mischia con l'altra estremità dell'arma. Questo attacco usa un d4 come dado di danno e infligge danni contundenti.\n- **Portata sorvegliata.** Mentre impugna un falcione, un'alabarda, una picca o un bastone ferrato, le creature che entrano nella sua portata provocano un attacco di opportunità da parte sua."
				}
			}
		};
	}
}