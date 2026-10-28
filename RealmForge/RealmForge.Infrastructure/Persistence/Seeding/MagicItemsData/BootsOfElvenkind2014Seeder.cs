using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Boots of Elvenkind (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BootsOfElvenkind2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("boots-of-elvenkind", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Stivali elfici", "Oggetto meraviglioso, non comune",
			"Indossando questi stivali, il personaggio non fa alcun rumore quando cammina, a prescindere dalla superficie su cui si muove. Dispone inoltre di vantaggio alle prove di Destrezza (Furtività) effettuate per muoversi silenziosamente."),
			("Boots of Elvenkind", "Wondrous item, uncommon",
			"While you wear these boots, your steps make no sound, regardless of the surface you are moving across. You also have advantage on Dexterity (Stealth) checks that rely on moving silently.", null));
	}
}
