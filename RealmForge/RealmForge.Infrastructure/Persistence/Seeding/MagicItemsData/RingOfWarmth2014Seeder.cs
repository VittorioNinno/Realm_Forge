using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Warmth (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfWarmth2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-warmth", null, 0, MagicItemType.Ring, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Anello del calore", "Anello, non comune (richiede sintonia)",
			"Finché il personaggio indossa questo anello, ottiene resistenza ai danni da freddo. Inoltre, il personaggio e tutto ciò che indossa e trasporta non subiscono effetti nocivi dalle basse temperature fino a – 45° C."),
			("Ring of Warmth", "Ring, uncommon (requires attunement)",
			"While wearing this ring, you have resistance to cold damage. In addition, you and everything you wear and carry are unharmed by temperatures as low as -50 degrees Fahrenheit.", null));
	}
}
