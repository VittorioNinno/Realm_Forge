using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Musician feat (2024 ruleset).
///	</summary>
public static class Musician2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555549");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555991");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555992");

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
					Name = "Musician",
					Description = "Your music lifts the spirits of those who hear it.\n- **Instrument Training.** You gain proficiency with three Musical Instruments of your choice.\n- **Encouraging Song.** When you finish a Short or Long Rest, you can play a song on an instrument you are proficient with. Allies who hear it gain Heroic Inspiration, up to a number of allies equal to your Proficiency Bonus."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Musicista",
					Description = "La musica del personaggio solleva il morale di chi la ascolta.\n- **Formazione Musicale.** Ottiene competenza in tre strumenti musicali a sua scelta.\n- **Canzone Incoraggiante.** Quando termina un Riposo Breve o Lungo, può suonare una canzone con uno strumento in cui ha competenza. Gli alleati che la ascoltano ottengono Ispirazione Eroica, fino a un numero di alleati pari al suo Bonus di Competenza."
				}
			}
		};
	}
}