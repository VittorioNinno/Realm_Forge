using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Amulet of the Planes (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class AmuletOfThePlanes2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("amulet-of-the-planes", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Amuleto dei piani", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"Il personaggio che indossa questo amuleto può usare un'azione per nominare un luogo che conosce su un altro piano di esistenza, poi effettua una prova di Intelligenza con CD 15. Se la prova viene superata, lancia l'incantesimo *spostamento planare.* Se fallisce, il personaggio e tutte le creature e gli oggetti entro un raggio di 4,5 metri vengono trasportati in una destinazione casuale. Il personaggio tira un d100: con un risultato di 1–60, la destinazione è un luogo casuale sul piano di esistenza scelto dal personaggio. Con un risultato di 61–100, la destinazione è un piano di esistenza determinato casualmente."),
			("Amulet of the Planes", "Wondrous item, very rare (requires attunement)",
			"While wearing this amulet, you can use an action to name a location that you are familiar with on another plane of existence. Then make a DC 15 Intelligence check. On a successful check, you cast the plane shift spell. On a failure, you and each creature and object within 15 feet of you travel to a random destination. Roll a d100. On a 1-60, you travel to a random location on the plane you named. On a 61-100, you travel to a randomly determined plane of existence.", null));
	}
}
