using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Brooch of Shielding (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BroochOfShielding2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("brooch-of-shielding", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			Magic(Resist(DamageType.Force)),
			("Fermaglio dello scudo", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Quando indossa questo fermaglio, il personaggio possiede resistenza ai danni da forza ed è immune ai danni inflitti dall'incantesimo *dardo incantato.*", null),
			("Brooch of Shielding", "Wondrous item, uncommon (requires attunement)",
			"While wearing this brooch, you have resistance to force damage, and you have immunity to damage from the magic missile spell.", null));
	}
}
