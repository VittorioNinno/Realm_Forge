using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Amulet of Proof against Detection and Location (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class AmuletOfProofAgainstDetectionAndLocation2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("amulet-of-proof-against-detection-and-location", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Amuleto anti-individuazione e localizzazione", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Il personaggio che indossa questo amuleto è invisibile a qualsiasi forma di divinazione magica. Non può essere indicato come bersaglio di tali magie, né percepito da sensori di scrutamento magici.", null),
			("Amulet of Proof against Detection and Location", "Wondrous item, uncommon (requires attunement)",
			"While wearing this amulet, you are hidden from divination magic. You can't be targeted by such magic or perceived through magical scrying sensors.", null));
	}
}
