using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Eyes of Minute Seeing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class EyesOfMinuteSeeing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("eyes-of-minute-seeing", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Lenti della visione dettagliata", "Oggetto meraviglioso, non comune",
			"Queste lenti di cristallo si adattano agli occhi di chi le indossa. Quando un personaggio lo fa, può vedere molto meglio del normale fino a una distanza di 30 cm. Dispone inoltre di vantaggio alle prove di Intelligenza (Indagare) basate sulla vista quando esamina un'area o studia un oggetto entro quella distanza."),
			("Eyes of Minute Seeing", "Wondrous item, uncommon",
			"These crystal lenses fit over the eyes. While wearing them, you can see much better than normal out to a range of 1 foot. You have advantage on Intelligence (Investigation) checks that rely on sight while searching an area or studying an object within that range.", null));
	}
}
