using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Gauntlets of Ogre Power (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class GauntletsOfOgrePower2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("gauntlets-of-ogre-power", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.SetAbilityScore, 19, AbilityScore.Strength)),
			("Guanti del potere orchesco", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Finché il personaggio indossa questi guanti, il suo punteggio di Forza è pari a 19. Non hanno alcun effetto se il suo punteggio di Forza è già pari o superiore a 19."),
			("Gauntlets of Ogre Power", "Wondrous item, uncommon (requires attunement)",
			"Your Strength score is 19 while you wear these gauntlets. They have no effect on you if your Strength is already 19 or higher.", null));
	}
}
