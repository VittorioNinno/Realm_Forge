using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Goggles of Night (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class GogglesOfNight2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("goggles-of-night", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Occhiali della Notte", "Oggetto meraviglioso, non comune",
			"Finché il personaggio indossa queste lenti scure, ottiene scurovisione entro un raggio di 18 metri. Se possiede già la scurovisione, gli occhiali ne aumentano il raggio di 18 metri.", null),
			("Goggles of Night", "Wondrous item, uncommon",
			"While wearing these dark lenses, you have darkvision out to a range of 60 feet. If you already have darkvision, wearing the goggles increases its range by 60 feet.", null));
	}
}
