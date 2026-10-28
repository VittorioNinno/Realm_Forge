using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Helm of Teleportation (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class HelmOfTeleportation2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("helm-of-teleportation", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Elmo del teletrasporto", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Questo elmo possiede 3 cariche. Finché il personaggio lo indossa, può usare un'azione e consumare 1 carica per lanciare l'incantesimo *teletrasporto.* L'elmo recupera 1d3 cariche consumate all'alba di ogni giorno."),
			("Helm of Teleportation", "Wondrous item, rare (requires attunement)",
			"This helm has 3 charges. While wearing it, you can use an action and expend 1 charge to cast the teleport spell from it. The helm regains 1d3\n\nexpended charges daily at dawn.", null));
	}
}
