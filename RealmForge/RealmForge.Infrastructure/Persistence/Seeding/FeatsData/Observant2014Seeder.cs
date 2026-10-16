using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Observant feat (2014 ruleset).
///	</summary>
public static class Observant2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555529");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555791");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555792");

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
					Name = "Observant",
					Description = "Little escapes your notice.\n- Increase your Intelligence or Wisdom score by 1, to a maximum of 20.\n- If you can see the mouth of a creature speaking a language you understand, you can tell what it says by reading its lips.\n- You gain a +5 bonus to your passive Wisdom (Perception) and passive Intelligence (Investigation) scores."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Osservatore",
					Description = "Poco sfugge all'attenzione del personaggio.\n- Il punteggio di Intelligenza o Saggezza aumenta di 1, fino a un massimo di 20.\n- Se può vedere la bocca di una creatura che parla un linguaggio che comprende, capisce cosa dice leggendone le labbra.\n- Ottiene un bonus di +5 ai punteggi passivi di Saggezza (Percezione) e di Intelligenza (Indagare)."
				}
			}
		};
	}
}