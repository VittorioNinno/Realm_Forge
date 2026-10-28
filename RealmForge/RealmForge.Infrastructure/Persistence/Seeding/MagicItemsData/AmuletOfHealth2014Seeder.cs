using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Amulet of Health (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class AmuletOfHealth2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("amulet-of-health", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.SetAbilityScore, 19, AbilityScore.Constitution)),
			("Amuleto della salute", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Il punteggio di Costituzione di chi indossa questo amuleto è pari a 19. Se il suo punteggio di Costituzione è già pari o superiore a 19, l'amuleto non ha alcun effetto.", null),
			("Amulet of Health", "Wondrous item, rare (requires attunement)",
			"Your Constitution score is 19 while you wear this amulet. It has no effect on you if your Constitution is already 19 or higher", null));
	}
}
