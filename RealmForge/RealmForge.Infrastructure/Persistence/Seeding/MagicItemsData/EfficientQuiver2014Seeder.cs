using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Efficient Quiver (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class EfficientQuiver2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("efficient-quiver", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Faretra efficiente", "Oggetto meraviglioso, non comune",
			"Ognuno dei tre scomparti di questa faretra è collegato a uno spazio extradimensionale che le consente di contenere numerosi oggetti senza mai pesare più di 1 kg. Lo scomparto più corto può contenere fino a sessanta frecce, quadrelli o oggetti simili. Lo scomparto medio può contenere fino a diciotto giavellotti o oggetti simili. Lo scomparto più lungo contiene fino a sei oggetti lunghi come archi, bastoni ferrati o lance.\n\nIl personaggio può estrarre un qualsiasi oggetto qui contenuto come se fosse una normale faretra o fodero.", "Faretra di Ehlonna"),
			("Efficient Quiver", "Wondrous item, uncommon",
			"Each of the quiver's three compartments connects to an extradimensional space that allows the quiver to hold numerous items while never weighing more than 2 pounds. The shortest compartment can hold up to sixty arrows, bolts, or similar objects. The midsize compartment holds up to eighteen javelins or similar objects. The longest compartment holds up to six long objects, such as bows, quarterstaffs, or spears.\n\nYou can draw any item the quiver contains as if doing so from a regular quiver or scabbard.", "Quiver of Ehlonna"));
	}
}
