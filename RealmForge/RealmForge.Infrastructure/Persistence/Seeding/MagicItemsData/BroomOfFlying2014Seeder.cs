using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Broom of Flying (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BroomOfFlying2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("broom-of-flying", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Scopa volante", "Oggetto meraviglioso, non comune",
			"Questa scopa di legno, del peso di 1,5 kg, funziona in modo normale finché il personaggio non ci monta a cavallo e pronuncia la sua parola d'ordine. A questo punto la scopa si solleva in aria e può essere cavalcata in volo. Ha una velocità di volare pari a 15 metri e può trasportare fino a 200 kg di peso, ma con un carico superiore a 100 kg la sua velocità di volare scende a 9 metri. Quando il personaggio atterra, la scopa smette di fluttuare.\n\nIl personaggio può inviare la scopa in volo da sola fino a una destinazione entro 1,5 km da lui, pronunciando la parola d'ordine e nominando il luogo in questione, purché abbia familiarità con esso. Il personaggio può far tornare indietro la scopa pronunciando un'altra parola d'ordine, purché essa si trovi ancora entro 1,5 km da lui.", null),
			("Broom of Flying", "Wondrous item, uncommon",
			"This wooden broom, which weighs 3 pounds, functions like a mundane broom until you stand astride it and speak its command word. It then hovers beneath you and can be ridden in the air. It has a flying speed of 50 feet. It can carry up to 400 pounds, but its flying speed becomes 30 feet while carrying over 200 pounds. The broom stops hovering when you land.\n\nYou can send the broom to travel alone to a destination within 1 mile of you if you speak the command word, name the location, and are familiar with that place. The broom comes back to you when you speak another command word, provided that the broom is still within 1 mile of you.", null));
	}
}
