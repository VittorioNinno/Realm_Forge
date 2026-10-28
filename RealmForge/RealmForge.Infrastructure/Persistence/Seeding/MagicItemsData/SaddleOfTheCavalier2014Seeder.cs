using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Saddle of the Cavalier (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class SaddleOfTheCavalier2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("saddle-of-the-cavalier", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.RealmForge,
			null,
			("Sella del cavaliere", "Oggetto meraviglioso, non comune",
			"Mentre il personaggio è in sella a una cavalcatura con questa sella, non può essere disarcionato contro la sua volontà finché è cosciente, e i tiri per colpire contro la cavalcatura subiscono svantaggio."),
			("Saddle of the Cavalier", "Wondrous item, uncommon",
			"While you ride a mount in this saddle, you can't be dismounted against your will as long as you are conscious, and attack rolls against the mount have disadvantage.", null));
	}
}
