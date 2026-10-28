using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Dust of Dryness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DustOfDryness2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("dust-of-dryness", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Polvere prosciugante", "Oggetto meraviglioso, non comune",
			"Questo pacchetto contiene 1d6 + 4 pizzichi di polvere. Con un'azione, il personaggio può spargere un pizzico di polvere sull'acqua. La polvere trasforma un cubo d'acqua con spigolo di 4,5 metri in una sfera delle dimensioni di una biglia, che fluttua o resta vicino al luogo in cui è caduta la polvere. Il peso della biglia è trascurabile.\n\nChiunque può usare un'azione per schiantare la biglia contro una superficie rigida, rompendola e liberando l'acqua che era stata assorbita. Quando questo accade, la magia della biglia termina.\n\nUn elementale composto per la maggior parte d'acqua che si trovi esposto a un pizzico di questa polvere deve effettuare un tiro salvezza su Costituzione con CD 13; in caso di fallimento, subisce 10d6 danni necrotici, o la metà dei danni in caso di successo."),
			("Dust of Dryness", "Wondrous item, uncommon",
			"This small packet contains 1d6 + 4 pinches of dust. You can use an action to sprinkle a pinch of it over water. The dust turns a cube of water 15 feet on a side into one marble-sized pellet, which floats or rests near where the dust was sprinkled. The pellet's weight is negligible.\n\nSomeone can use an action to smash the pellet against a hard surface, causing the pellet to shatter and release the water the dust absorbed. Doing so ends that pellet's magic.\n\nAn elemental composed mostly of water that is exposed to a pinch of the dust must make a DC 13 Constitution saving throw, taking 10d6 necrotic damage on a failed save, or half as much damage on a successful one.", null));
	}
}
