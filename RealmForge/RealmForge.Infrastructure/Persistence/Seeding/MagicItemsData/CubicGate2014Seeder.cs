using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Cubic Gate (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CubicGate2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("cubic-gate", null, 0, MagicItemType.WondrousItem, ItemRarity.Legendary, false, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Cubo dei portali", "Oggetto meraviglioso, leggendario",
			"Questo cubo ha uno spigolo di 7,5 cm e irradia un'energia magica quasi palpabile. Ognuna delle sei facce è collegata a un piano di esistenza diverso, uno dei quali è il Piano Materiale. I piani a cui sono collegate le altre facce sono determinati dal GM.\n\nIl personaggio può usare un'azione per premere una delle facce del cubo e lanciare l'incantesimo *portale,* che si apre sul piano di esistenza collegato alla faccia premuta. In alternativa, se usa un'azione per premere una faccia due volte, può usare il cubo per lanciare l'incantesimo *spostamento planare* (CD del tiro salvezza 17) e trasportare i bersagli sul piano di esistenza collegato a tale faccia.\n\nIl cubo ha 3 cariche. Ogni uso del cubo consuma 1 carica. Il cubo recupera 1d3 cariche consumate all'alba di ogni giorno."),
			("Cubic Gate", "Wondrous item, legendary",
			"This cube is 3 inches across and radiates palpable magical energy. The six sides of the cube are each keyed to a different plane of existence, one of which is the Material Plane. The other sides are linked to planes determined by the GM.\n\nYou can use an action to press one side of the cube to cast the gate spell with it, opening a portal to the plane keyed to that side. Alternatively, if you use an action to press one side twice, you can cast the plane shift spell (save DC 17) with the cube and transport the targets to the plane keyed to that side.\n\nThe cube has 3 charges. Each use of the cube expends 1 charge. The cube regains 1d3 expended charges daily at dawn.", null));
	}
}
