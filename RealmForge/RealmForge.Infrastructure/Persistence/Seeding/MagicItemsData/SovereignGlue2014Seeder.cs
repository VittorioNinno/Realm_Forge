using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Sovereign Glue (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class SovereignGlue2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("sovereign-glue", null, 0, MagicItemType.WondrousItem, ItemRarity.Legendary, false, ContentSource.Srd51,
			null,
			("Colla meravigliosa", "Oggetto meraviglioso, leggendario",
			"Questa sostanza viscosa e lattiginosa può creare un legame adesivo permanente tra due oggetti qualsiasi. Deve essere custodita in un barattolo o in un'ampolla al cui interno sia stato spalmato dell'olio *della scivolosità.* Quando viene trovato, il contenitore contiene (1d6 + 1) × 30 grammi.\n\nUna quantità di colla pari a 30 grammi può coprire una superficie quadrata con lato di 30 cm. La colla impiega 1 minuto a fare effetto. Il legame così creatosi può essere spezzato solamente con un'applicazione di *solvente universale* o di *olio della forma eterea,* o tramite un incantesimo *desiderio.*", null),
			("Sovereign Glue", "Wondrous item, legendary",
			"This viscous, milky-white substance can form a permanent adhesive bond between any two objects. It must be stored in a jar or flask that has been coated inside with oil of slipperiness. When found, a container contains 1d6 + 1 ounces.\n\nOne ounce of the glue can cover a 1-foot square surface. The glue takes 1 minute to set. Once it has done so, the bond it creates can be broken only by the application of universal solvent or oil of etherealness, or with a wish spell.", null));
	}
}
