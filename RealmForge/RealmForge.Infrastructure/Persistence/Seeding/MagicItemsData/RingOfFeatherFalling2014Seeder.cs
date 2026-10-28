using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Feather Falling (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfFeatherFalling2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-feather-falling", null, 0, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Anello della caduta morbida", "Anello, raro (richiede sintonia)",
			"Quando il personaggio cade indossando questo anello, scende di 18 metri per round e non subisce danni dalla caduta.", null),
			("Ring of Feather Falling", "Ring, rare (requires attunement)",
			"When you fall while wearing this ring, you descend 60 feet per round and take no damage from falling.", null));
	}
}
