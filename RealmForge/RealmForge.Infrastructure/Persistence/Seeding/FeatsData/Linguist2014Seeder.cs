using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Linguist feat (2014 ruleset).
///	</summary>
public static class Linguist2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555520");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555701");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555702");

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
					Name = "Linguist",
					Description = "You have a gift for languages and secret writing.\n- **Intelligence +1.** Increase your Intelligence score by 1, to a maximum of 20.\n- **New Languages.** You learn three languages of your choice.\n- **Ciphers.** You can write codes that nobody else can read unless you teach them the key, they use magic, or they succeed on an Intelligence check with a DC equal to your Intelligence score + your proficiency bonus."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Linguista",
					Description = "Il personaggio ha un talento per i linguaggi e la scrittura segreta.\n- **Intelligenza +1.** Il punteggio di Intelligenza aumenta di 1, fino a un massimo di 20.\n- **Nuovi linguaggi.** Impara tre linguaggi a sua scelta.\n- **Cifrari.** Sa scrivere codici che nessun altro può leggere, a meno che non sia lui a insegnarne la chiave, che si usi la magia o che si superi una prova di Intelligenza con CD pari al suo punteggio di Intelligenza + il suo bonus di competenza."
				}
			}
		};
	}
}