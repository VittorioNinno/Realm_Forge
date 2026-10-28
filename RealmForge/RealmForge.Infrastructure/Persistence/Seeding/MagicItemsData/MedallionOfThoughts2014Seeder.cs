using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Medallion of Thoughts (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class MedallionOfThoughts2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("medallion-of-thoughts", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			Charges(3, ItemRecharge.LongRest, "1d3"),
			("Medaglione dei pensieri", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Questo medaglione possiede 3 cariche. Finché il personaggio lo indossa, può usare un'azione e consumare 1 carica per lanciare l'incantesimo *individuazione dei pensieri* (CD del tiro salvezza 13). Il medaglione recupera 1d3 cariche consumate all'alba di ogni giorno."),
			("Medallion of Thoughts", "Wondrous item, uncommon (requires attunement)",
			"The medallion has 3 charges. While wearing it, you can use an action and expend 1 charge to cast the detect thoughts spell (save DC 13) from it. The medallion regains 1d3 expended charges daily at dawn.", null));
	}
}
