using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Lantern of Revealing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class LanternOfRevealing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("lantern-of-revealing", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Lanterna della rivelazione", "Oggetto meraviglioso, non comune",
			"Quando è accesa, questa lanterna schermabile arde per 6 ore con 0,5 litri d'olio, proiettando luce intensa in un raggio di 9 metri e luce fioca per altri 9 metri. Quando si trovano nell'area di luce intensa della lanterna, le creature e gli oggetti invisibili tornano visibili. Con un'azione, un personaggio può schermare la lanterna, riducendo la luce proiettata a luce fioca in un raggio di 1,5 metri."),
			("Lantern of Revealing", "Wondrous item, uncommon",
			"While lit, this hooded lantern burns for 6 hours on 1 pint of oil, shedding bright light in a 30-foot radius and dim light for an additional 30 feet. Invisible creatures and objects are visible as long as they are in the lantern's bright light. You can use an action to lower the hood, reducing the light to dim light in a 5 foot radius.", null));
	}
}
