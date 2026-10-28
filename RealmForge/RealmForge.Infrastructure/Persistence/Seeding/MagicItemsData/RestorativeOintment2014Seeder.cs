using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Restorative Ointment (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RestorativeOintment2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("restorative-ointment", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Unguento rigenerativo", "Oggetto meraviglioso, non comune",
			"Questo barattolo di vetro del diametro di 7,5 cm contiene 1d4 + 1 dosi di una densa mistura dal vago odore di aloe. Il barattolo e il suo contenuto pesano 250 grammi.\n\nCon un'azione è possibile inghiottire una dose di unguento o spalmarsela sulla pelle. La creatura che la riceve recupera 2d8 + 2 punti ferita, cessa di essere avvelenata ed è curata da ogni malattia.", "Unguento di Keoghtom"),
			("Restorative Ointment", "Wondrous item, uncommon",
			"This glass jar, 3 inches in diameter, contains 1d4 + 1 doses of a thick mixture that smells faintly of aloe. The jar and its contents weigh 1/2 pound.\n\nAs an action, one dose of the ointment can be swallowed or applied to the skin. The creature that receives it regains 2d8 + 2 hit points, ceases to be poisoned, and is cured of any disease.", "Keoghtom's Ointment"));
	}
}
