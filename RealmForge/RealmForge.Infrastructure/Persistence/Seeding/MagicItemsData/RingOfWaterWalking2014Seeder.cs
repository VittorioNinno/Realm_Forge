using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Water Walking (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfWaterWalking2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-water-walking", null, 0, MagicItemType.Ring, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Anello del camminare sull'acqua", "Anello, non comune",
			"Finché il personaggio indossa questo anello, può stare in piedi e camminare su qualsiasi superficie liquida come se fosse terreno solido.", null),
			("Ring of Water Walking", "Ring, uncommon",
			"While wearing this ring, you can stand on and move across any liquid surface as if it were solid ground.", null));
	}
}
