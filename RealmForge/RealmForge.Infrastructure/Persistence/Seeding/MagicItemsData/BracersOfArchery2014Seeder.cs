using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Bracers of Archery (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BracersOfArchery2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("bracers-of-archery", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Bracciali dell'arciere", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Quando il personaggio indossa questi bracciali, possiede competenza nell'arco lungo e nell'arco corto e ottiene un bonus di +2 ai tiri per i danni inflitti da attacchi a distanza effettuati con tali armi."),
			("Bracers of Archery", "Wondrous item, uncommon (requires attunement)",
			"While wearing these bracers, you have proficiency with the longbow and shortbow, and you gain a +2 bonus to damage rolls on ranged attacks made with such weapons.", null));
	}
}
