using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Gloves of Thievery (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class GlovesOfThievery2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("gloves-of-thievery", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.RealmForge,
			null,
			("Guanti ladreschi", "Oggetto meraviglioso, non comune",
			"Questi guanti diventano invisibili quando vengono indossati. Mentre li indossa, il personaggio ottiene un bonus di +5 alle prove di Destrezza (Rapidità di Mano) e alle prove di Destrezza per scassinare serrature.", null),
			("Gloves of Thievery", "Wondrous item, uncommon",
			"These gloves turn invisible while worn. While wearing them, you gain a +5 bonus to Dexterity (Sleight of Hand) checks and to Dexterity checks made to pick locks.", null));
	}
}
