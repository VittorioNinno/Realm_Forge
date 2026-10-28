using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Three Wishes (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfThreeWishes2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-three-wishes", null, 0, MagicItemType.Ring, ItemRarity.Legendary, false, ContentSource.Srd51,
			Charges(3, ItemRecharge.None, null),
			("Anello dei tre desideri", "Anello, leggendario",
			"Finché il personaggio indossa questo anello, può usare un'azione per consumare 1 delle sue 3 cariche e lanciare con esso l'incantesimo *desiderio.* L'anello smette di essere magico quando esaurisce le cariche.", null),
			("Ring of Three Wishes", "Ring, legendary",
			"While wearing this ring, you can use an action to expend 1 of its 3 charges to cast the wish spell from it. The ring becomes nonmagical when you use the last charge.", null));
	}
}
