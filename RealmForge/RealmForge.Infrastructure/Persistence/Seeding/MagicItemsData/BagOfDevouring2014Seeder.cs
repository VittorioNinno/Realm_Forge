using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Bag of Devouring (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BagOfDevouring2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("bag-of-devouring", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Borsa divorante", "Oggetto meraviglioso, molto raro",
			"A una prima occhiata questa borsa sembra una *borsa conservante,* ma in realtà si tratta di un orifizio attraverso cui si nutre una gigantesca creatura extradimensionale. Rivoltando la borsa da dentro a fuori si chiude l'orifizio.\n\nLa creatura extradimensionale collegata alla borsa può percepire tutto ciò che viene posto al suo interno. Ogni materiale animale o vegetale inserito completamente all'interno della borsa viene divorato e perduto per sempre. Quando una parte di una creatura vivente entra nella borsa, per esempio quando qualcuno vi infila una mano, c'è una probabilità del 50 percento che tutta la creatura venga risucchiata all'interno. Una creatura all'interno della borsa può usare la sua azione per tentare di sfuggire superando una prova di Forza con CD 15. Un'altra creatura può usare la propria azione per infilare le mani nella borsa e tirare fuori la creatura imprigionata effettuando con successo una prova di Forza con CD 20 (sempre che non venga prima trascinata all'interno a sua volta). Ogni creatura che inizia il proprio turno all'interno della borsa viene divorata e il suo corpo viene distrutto.\n\nNella borsa è possibile conservare oggetti inanimati fino a un volume pari a un cubo con spigolo di 30 cm. Tuttavia, una volta al giorno la borsa inghiotte tutti gli oggetti al suo interno e li sputa fuori su un altro piano di esistenza. Il GM determina il momento in cui questo accade e il piano dove finiscono gli oggetti.\n\nSe la borsa viene bucata o strappata, è considerata distrutta e tutto ciò che conteneva viene trasportato in un luogo casuale sul Piano Astrale.", null),
			("Bag of Devouring", "Wondrous item, very rare",
			"This bag superficially resembles a bag of holding but is a feeding orifice for a gigantic extradimensional creature. Turning the bag inside out closes the orifice.\n\nThe extradimensional creature attached to the bag can sense whatever is placed inside the bag. Animal or vegetable matter placed wholly in the bag is devoured and lost forever. When part of a living creature is placed in the bag, as happens when someone reaches inside it, there is a 50 percent chance that the creature is pulled inside the bag. A creature inside the bag can use its action to try to escape with a successful DC 15 Strength check. Another creature can use its action to reach into the bag to pull a creature out, doing so with a successful DC 20 Strength check (provided it isn't pulled inside the bag first). Any creature that starts its turn inside the bag is devoured, its body destroyed.\n\nInanimate objects can be stored in the bag, which can hold a cubic foot of such material. However, once each day, the bag swallows any objects inside it and spits them out into another plane of existence. The GM determines the time and plane.\n\nIf the bag is pierced or torn, it is destroyed, and anything contained within it is transported to a random location on the Astral Plane.", null));
	}
}
