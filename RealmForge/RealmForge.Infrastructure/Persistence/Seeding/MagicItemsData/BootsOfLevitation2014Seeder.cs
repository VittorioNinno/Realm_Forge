using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Boots of Levitation (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BootsOfLevitation2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("boots-of-levitation", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Stivali della levitazione", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Il personaggio che indossa questi stivali può usare un'azione per lanciare l'incantesimo *levitazione* su se stesso a volontà.", null),
			("Boots of Levitation", "Wondrous item, rare (requires attunement)",
			"While you wear these boots, you can use an action to cast the levitate spell on yourself at will.", null));
	}
}
