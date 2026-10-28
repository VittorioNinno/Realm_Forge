using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Cloak of Invisibility (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class CloakOfInvisibility2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("cloak-of-invisibility", null, 0, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.RealmForge,
			null,
			("Mantello dell'invisibilità", "Oggetto meraviglioso, leggendario (richiede sintonia)",
			"Mentre indossa questo mantello, il personaggio può tirarsi il cappuccio sulla testa per diventare invisibile, insieme a tutto ciò che indossa e trasporta. Torna visibile quando abbassa il cappuccio. Alzare o abbassare il cappuccio richiede un'azione.\n\nIl mantello funziona per un massimo di 2 ore: il tempo passato invisibili si sottrae da questa riserva a intervalli di 1 minuto. Esaurite le 2 ore, il mantello smette di funzionare; recupera 1 ora per ogni periodo di 12 ore consecutive in cui non viene usato.", null),
			("Cloak of Invisibility", "Wondrous item, legendary (requires attunement)",
			"While wearing this cloak, you can pull its hood over your head to become invisible, along with everything you wear and carry. You become visible again when you lower the hood. Raising or lowering the hood takes an action.\n\nThe cloak works for up to 2 hours in total: the time you spend invisible is subtracted from that pool in 1-minute increments. Once the 2 hours are used up, the cloak stops working; it regains 1 hour for every 12 uninterrupted hours it goes unused.", null));
	}
}
