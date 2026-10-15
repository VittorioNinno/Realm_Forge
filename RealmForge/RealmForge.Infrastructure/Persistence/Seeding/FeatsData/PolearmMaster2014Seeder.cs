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
					Description = "You can keep your enemies at bay with reach weapons. You gain the following benefits:\n- When you take the Attack action and attack with only a glaive, halberd, or quarterstaff, you can use a bonus action to make a melee attack with the opposite end of the weapon. The weapon's damage die for this attack is a d4, and the attack deals bludgeoning damage.\n- While you are wielding a glaive, halberd, pike, or quarterstaff, other creatures provoke an opportunity attack from you when they enter your reach."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro delle Armi su Asta",
					Description = "Il personaggio ottiene i benefici seguenti:\n- Quando effettua l'azione di Attacco e attacca soltanto con un'alabarda, un bastone ferrato o un falcione, può usare un'azione bonus per effettuare un attacco in mischia con l'estremità opposta dell'arma. Questo attacco usa lo stesso modificatore di caratteristica dell'attacco primario. Il dado dei danni dell'arma per questo attacco è un d4 e l'arma infligge danni contundenti.\n- Mentre impugna un'alabarda, un bastone ferrato, un falcione o una picca, le altre creature provocano un attacco di opportunità da parte sua quando entrano nella portata che egli possiede con quell'arma."
				}
			}
		};
	}
}