using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Wind Fan (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WindFan2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("wind-fan", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Ventaglio", "Oggetto meraviglioso, non comune",
			"Mentre il personaggio impugna il ventaglio, può usare un'azione per lanciare con esso l'incantesimo *folata di vento* (CD del tiro salvezza 13). Una volta usato, il ventaglio non deve essere riutilizzato fino all'alba successiva. Ogni volta che viene riutilizzato prima di allora, c'è una probabilità cumulativa del 20 percento che l'oggetto non funzioni e si riduca in inutili brandelli di tessuto non magici.", null),
			("Wind Fan", "Wondrous item, uncommon",
			"While holding this fan, you can use an action to cast the gust of wind spell (save DC 13) from it. Once used, the fan shouldn't be used again until the next dawn. Each time it is used again before then, it has a cumulative 20 percent chance of not working and tearing into useless, nonmagical tatters.", null));
	}
}
