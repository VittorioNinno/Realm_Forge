using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Swimming (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfSwimming2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-swimming", null, 0, MagicItemType.Ring, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Anello del nuotare", "Anello, non comune",
			"Finché il personaggio indossa questo anello, la sua velocità di nuotare è pari a 12 metri.", null),
			("Ring of Swimming", "Ring, uncommon",
			"You have a swimming speed of 40 feet while wearing this ring.", null));
	}
}
