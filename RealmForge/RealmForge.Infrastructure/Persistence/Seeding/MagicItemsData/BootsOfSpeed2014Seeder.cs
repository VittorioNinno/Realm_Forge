using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Boots of Speed (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BootsOfSpeed2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("boots-of-speed", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Stivali della velocità", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Il personaggio che indossa questi stivali può usare un'azione bonus per battere i tacchi. Fatto questo, gli stivali raddoppiano la sua velocità base sul terreno e le creature che effettuano un attacco di opportunità contro di lui subiscono svantaggio ai tiri per colpire. Se il personaggio batte di nuovo i tacchi, pone fine all'effetto.\n\nDopo avere usato la proprietà degli stivali per un totale di 10 minuti, la magia smette di funzionare finché il personaggio non completa un riposo lungo."),
			("Boots of Speed", "Wondrous item, rare (requires attunement)",
			"While you wear these boots, you can use a bonus action and click the boots' heels together. If you do, the boots double your walking speed, and any creature that makes an opportunity attack against you has disadvantage on the attack roll. If you click your heels together again, you end the effect.\n\nWhen the boots' property has been used for a total of 10 minutes, the magic ceases to function until you finish a long rest.", null));
	}
}
