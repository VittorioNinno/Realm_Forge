using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Tough feat (2024 ruleset).
///	</summary>
public static class Tough2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555553");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551031");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551032");

	///	<summary>
	///	Builds the canonical SRD definition of this feat. Persistence is handled by FeatSeeder.
	///	</summary>
	public static Feat Build()
	{
		return new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Category = FeatCategory.Origin,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Tough",
					Description = "You can take more punishment than most.\n\nWhen you take this feat, your Hit Point maximum increases by twice your character level. Each time you gain a character level afterward, it increases by a further 2."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Robusto",
					Description = "Il personaggio sopporta più colpi della maggior parte delle persone.\n\nQuando ottiene questo talento, il suo massimo dei Punti Ferita aumenta di un ammontare pari al doppio del suo livello del personaggio. Ogni volta che sale di livello in seguito, aumenta di altri 2."
				}
			}
		};
	}
}