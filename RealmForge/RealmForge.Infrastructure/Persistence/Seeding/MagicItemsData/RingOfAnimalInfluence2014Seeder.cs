using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Animal Influence (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfAnimalInfluence2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-animal-influence", null, 0, MagicItemType.Ring, ItemRarity.Rare, false, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Anello di influenza sugli animali", "Anello, raro",
			"Questo anello possiede 3 cariche e recupera 1d3 cariche consumate all'alba di ogni giorno. Mentre il personaggio lo indossa, può usare un'azione per consumare 1 carica e lanciare uno dei seguenti incantesimi:\n\n- *Amicizia con gli animali* (CD del tiro salvezza 13)\n\n- *Parlare con gli animali*\n\n- *Paura* (CD del tiro salvezza 13), bersagliando solo bestie con Intelligenza pari o inferiore a 3", null),
			("Ring of Animal Influence", "Ring, rare",
			"This ring has 3 charges, and it regains 1d3 expended charges daily at dawn. While wearing the ring, you can use an action to expend 1 of its charges to cast one of the following spells:\n\nAnimal friendship (save DC 13)\n\nFear (save DC 13), targeting only beasts that have an Intelligence of 3 or lower\n\nSpeak with animals", null));
	}
}
