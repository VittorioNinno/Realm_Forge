using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Elemental Gem (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ElementalGem2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("elemental-gem", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Gemma elementale", "Oggetto meraviglioso, non comune",
			"Questa gemma contiene un frammento di energia elementale. Quando il personaggio usa un'azione per romperla, evoca un elementale come se avesse lanciato l'incantesimo *evoca elementale* e la gemma perde la sua magia. Il tipo di gemma determina il tipo di elementale evocato.\n\n| Gemma | Elementale evocato |\n|---|---|\n| Smeraldo | Elementale dell'acqua |\n| Zaffiro blu | Elementale dell'aria |\n| Corindone rosso | Elementale del fuoco |\n| Diamante giallo | Elementale della terra |"),
			("Elemental Gem", "Wondrous item, uncommon",
			"This gem contains a mote of elemental energy. When you use an action to break the gem, an elemental is summoned as if you had cast the conjure elemental spell, and the gem's magic is lost. The type of gem determines the elemental summoned by the spell.\n\n| Gem | Summoned Elemental |\n|---|---|\n| Blue sapphire | Air elemental |\n| Yellow diamond | Earth elemental |\n| Red corundum | Fire elemental |\n| Emerald | Water elemental |", null));
		yield return Item("elemental-gem-air", "elemental-gem", 1, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Gemma elementale (zaffiro blu)", "Oggetto meraviglioso, non comune",
			""),
			("Air Elemental Gem", "Wondrous item, uncommon",
			"", null));
		yield return Item("elemental-gem-earth", "elemental-gem", 2, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Gemma elementale (diamante giallo)", "Oggetto meraviglioso, non comune",
			""),
			("Earth Elemental Gem", "Wondrous item, uncommon",
			"", null));
		yield return Item("elemental-gem-fire", "elemental-gem", 3, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Gemma elementale (corindone rosso)", "Oggetto meraviglioso, non comune",
			""),
			("Fire Elemental Gem", "Wondrous item, uncommon",
			"", null));
		yield return Item("elemental-gem-water", "elemental-gem", 4, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Gemma elementale (smeraldo)", "Oggetto meraviglioso, non comune",
			""),
			("Water Elemental Gem", "Wondrous item, uncommon",
			"", null));
	}
}
