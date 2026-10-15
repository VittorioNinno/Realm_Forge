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
					Description = "Your Hit Point maximum increases by an amount equal to twice your character level when you gain this feat. Whenever you gain a character level thereafter, your Hit Point maximum increases by an additional 2 Hit Points."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Robusto",
					Description = "I punti ferita massimi del personaggio aumentano di un valore pari al doppio del livello del personaggio al momento dell'acquisizione del talento. Dopodiché, ogni volta che il personaggio ottiene un livello, i suoi punti ferita massimi aumentano di 2."
				}
			}
		};
	}
}