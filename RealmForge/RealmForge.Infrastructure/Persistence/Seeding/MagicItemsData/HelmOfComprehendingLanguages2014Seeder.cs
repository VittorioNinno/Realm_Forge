using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Helm of Comprehending Languages (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class HelmOfComprehendingLanguages2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("helm-of-comprehending-languages", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Elmo della comprensione dei linguaggi", "Oggetto meraviglioso, non comune",
			"Finché il personaggio indossa questo elmo, può usare un'azione per lanciare con esso l'incantesimo *comprensione dei linguaggi* a volontà.", null),
			("Helm of Comprehending Languages", "Wondrous item, uncommon",
			"While wearing this helm, you can use an action to cast the comprehend languages spell from it at will.", null));
	}
}
