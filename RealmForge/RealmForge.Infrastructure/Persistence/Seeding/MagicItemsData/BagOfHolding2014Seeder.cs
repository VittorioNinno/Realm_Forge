using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Bag of Holding (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BagOfHolding2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("bag-of-holding", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Borsa conservante", "Oggetto meraviglioso, non comune",
			"Lo spazio interno di questa borsa è molto più grande delle sue dimensioni esterne, pari a circa 60 cm di diametro all'apertura e 120 cm di profondità. La borsa può contenere fino a 250 kg di materiale, per un volume massimo di 64 cubi con spigolo di 30 cm. La borsa pesa 7,5 kg a prescindere dal suo contenuto. Recuperare un oggetto dall'interno della borsa richiede un'azione.\n\nSe la borsa viene caricata con un peso eccessivo, bucata o strappata, si rompe ed è distrutta, e il suo contenuto viene sparpagliato sul Piano Astrale. Se la borsa viene rivoltata, il suo contenuto si riversa all'esterno, integro. Tuttavia, per essere riutilizzata, la borsa deve essere rivoltata di nuovo. Le creature che necessitano di respirare situate all'interno della borsa possono sopravvivere per un numero di minuti pari a 10 diviso il numero di creature (fino a un minimo di 1 minuto); trascorso questo periodo di tempo, le creature cominciano a soffocare.\n\nCollocare una *borsa conservante* all'interno di uno spazio extradimensionale, come quello creato da uno *zainetto pratico,* da un *buco portatile* o da altri oggetti simili, distrugge istantaneamente entrambi gli oggetti e apre un portale sul Piano Astrale. Il portale ha origine nel punto in cui uno dei due oggetti è stato inserito nell'altro. Tutte le creature entro 3 metri dal portale vengono attirate al suo interno e trasportate in un luogo casuale del Piano Astrale, dopodiché il portale si chiude. Il portale è a senso unico e non può essere riaperto.", null),
			("Bag of Holding", "Wondrous item, uncommon",
			"This bag has an interior space considerably larger than its outside dimensions, roughly 2 feet in diameter at the mouth and 4 feet deep. The bag can hold up to 500 pounds, not exceeding a volume of 64 cubic feet. The bag weighs 15 pounds, regardless of its contents. Retrieving an item from the bag requires an action.\n\nIf the bag is overloaded, pierced, or torn, it ruptures and is destroyed, and its contents are scattered in the Astral Plane. If the bag is turned inside out, its contents spill forth, unharmed, but the bag must be put right before it can be used again. Breathing creatures inside the bag can survive up to a number of minutes equal to 10 divided by the number of creatures (minimum 1 minute), after which time they begin to suffocate.\n\nPlacing a bag of holding inside an extradimensional space created by a Handy Haversack, Portable Hole, or similar item instantly destroys both items and opens a gate to the Astral Plane. The gate originates where the one item was placed inside the other. Any creature within 10 feet of the gate is sucked through it to a random location on the Astral Plane. The gate then closes. The gate is one-way only and can't be reopened.", null));
	}
}
