using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Dungeon Delver feat (2014 ruleset).
///	</summary>
public static class DungeonDelver2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555509");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555591");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555592");

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
					Name = "Dungeon Delver",
					Description = "Years underground have taught you where danger hides.\n- **Hidden Passages.** You have advantage on Wisdom (Perception) and Intelligence (Investigation) checks to find secret doors.\n- **Trap Sense.** You have advantage on saving throws to avoid or resist traps, and resistance to damage dealt by traps.\n- **Watchful Travel.** You can look for traps while traveling at a normal pace, not only at a slow pace."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Esperto di Dungeon",
					Description = "Anni passati sottoterra hanno insegnato al personaggio dove si nasconde il pericolo.\n- **Passaggi nascosti.** Ha vantaggio alle prove di Saggezza (Percezione) e Intelligenza (Indagare) per trovare porte segrete.\n- **Senso delle trappole.** Ha vantaggio ai tiri salvezza per evitare o resistere alle trappole e resistenza ai danni inflitti dalle trappole.\n- **Viaggio vigile.** Può cercare trappole anche mentre viaggia a passo normale, non solo a passo lento."
				}
			}
		};
	}
}