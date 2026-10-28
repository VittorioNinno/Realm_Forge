using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Robe of Scintillating Colors (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RobeOfScintillatingColors2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("robe-of-scintillating-colors", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Tunica dei colori scintillanti", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"Questa tunica possiede 3 cariche e recupera 1d3 cariche consumate all'alba di ogni giorno. Finché il personaggio la indossa, può usare un'azione e consumare 1 carica per fare comparire sull'indumento un motivo rotante dai colori sgargianti, che permane fino alla fine del suo turno successivo. Durante questo periodo, la tunica emana luce intensa in un raggio di 9 metri e luce fioca per altri 9 metri. Le creature che possono vedere il personaggio subiscono svantaggio ai tiri per colpire effettuati contro di lui. Inoltre, ogni creatura che si trova dentro la luce intensa e che può vedere il personaggio quando la proprietà della tunica viene attivata deve superare un tiro salvezza su Saggezza con CD 15, altrimenti diventa stordita finché l'effetto non termina."),
			("Robe of Scintillating Colors", "Wondrous item, very rare (requires attunement)",
			"This robe has 3 charges, and it regains 1d3 expended charges daily at dawn. While you wear it, you can use an action and expend 1 charge to cause the garment to display a shifting pattern of dazzling hues until the end of your next turn. During this time, the robe sheds bright light in a 30-foot radius and dim light for an additional 30 feet. Creatures that can see you have disadvantage on attack rolls against you. In addition, any creature in the bright light that can see you when the robe's power is activated must succeed on a DC 15 Wisdom saving throw or become stunned until the effect ends.", null));
	}
}
