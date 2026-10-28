using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Boots of Striding and Springing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BootsOfStridingAndSpringing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("boots-of-striding-and-springing", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Stivali molleggiati", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Fintantoché il personaggio indossa questi stivali, ha una velocità base sul terreno pari a 9 metri (a meno che la sua velocità normale non sia superiore), che non viene ridotta se è ingombrato o se indossa un'armatura pesante. Inoltre, il personaggio può saltare di una distanza tripla rispetto al normale, anche se non può superare la distanza concessa dal proprio movimento rimanente."),
			("Boots of Striding and Springing", "Wondrous item, uncommon (requires attunement)",
			"While you wear these boots, your walking speed becomes 30 feet, unless your walking speed is higher, and your speed isn't reduced if you are encumbered or wearing heavy armor. In addition, you can jump three times the normal distance, though you can't jump farther than your remaining movement would allow.", null));
	}
}
