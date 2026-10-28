using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Well of Many Worlds (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WellOfManyWorlds2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("well-of-many-worlds", null, 0, MagicItemType.WondrousItem, ItemRarity.Legendary, false, ContentSource.Srd51,
			null,
			("Pozzo dei mondi", "Oggetto meraviglioso, leggendario",
			"Quando è piegato, questo panno di elegante tessuto nero morbido come la seta ha le dimensioni di un fazzoletto. Una volta spiegato, copre una superficie circolare di 1,8 metri di diametro.\n\nIl personaggio può usare un'azione per stendere e posizionare il *pozzo dei mondi* su una superficie solida, creando un portale a doppio senso verso un altro mondo o piano di esistenza. Ogni volta che l'oggetto apre un portale, il GM decide dove porterà. Il personaggio può usare un'azione per chiudere un portale aperto afferrandone i lembi e ripiegandoli. Una volta che ha aperto un portale, il *pozzo dei mondi* non può essere riutilizzato per 1d8 ore."),
			("Well of Many Worlds", "Wondrous item, legendary",
			"This fine black cloth, soft as silk, is folded up to the dimensions of a handkerchief. It unfolds into a circular sheet 6 feet in diameter.\n\nYou can use an action to unfold and place the well of many worlds on a solid surface, whereupon it creates a two-way portal to another world or plane of existence. Each time the item opens a portal, the GM decides where it leads. You can use an action to close an open portal by taking hold of the edges of the cloth and folding it up. Once well of many worlds has opened a portal, it can't do so again for 1d8 hours.", null));
	}
}
