using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Horseshoes of Speed (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class HorseshoesOfSpeed2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("horseshoes-of-speed", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Ferri della velocità", "Oggetto meraviglioso, raro",
			"Questi ferri da cavallo sono creati a gruppi di quattro. Quando vengono applicati tutti e quattro agli zoccoli di un cavallo o di una creatura simile, aumentano di 9 metri la sua velocità base sul terreno."),
			("Horseshoes of Speed", "Wondrous item, rare",
			"These iron horseshoes come in a set of four. While all four shoes are affixed to the hooves of a horse or similar creature, they increase the creature's walking speed by 30 feet.", null));
	}
}
