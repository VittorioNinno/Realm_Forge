using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Gem of Seeing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class GemOfSeeing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("gem-of-seeing", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Gemma della visione", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Questa gemma possiede 3 cariche. Con un'azione, il personaggio può pronunciare la sua parola d'ordine e consumare 1 carica. Per i 10 minuti successivi, guardando attraverso la gemma il personaggio ottiene vista pura entro un raggio di 36 metri.\n\nLa gemma recupera 1d3 cariche consumate all'alba di ogni giorno.", null),
			("Gem of Seeing", "Wondrous item, rare (requires attunement)",
			"This gem has 3 charges. As an action, you can speak the gem's command word and expend 1 charge. For the next 10 minutes, you have truesight out to 120 feet when you peer through the gem.\n\nThe gem regains 1d3 expended charges daily at dawn.", null));
	}
}
