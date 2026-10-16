using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Tough feat (2014 ruleset).
///	</summary>
public static class Tough2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555541");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555911");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555912");

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
					Name = "Tough",
					Description = "You can take more punishment than most.\n- **Extra Hit Points.** When you take this feat, your hit point maximum increases by twice your level. Each time you gain a level afterward, it increases by a further 2."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Robusto",
					Description = "Il personaggio sopporta più colpi della maggior parte delle persone.\n- **Punti ferita aggiuntivi.** Quando ottiene questo talento, il suo massimo dei punti ferita aumenta di un ammontare pari al doppio del suo livello. Ogni volta che sale di livello in seguito, aumenta di altri 2."
				}
			}
		};
	}
}