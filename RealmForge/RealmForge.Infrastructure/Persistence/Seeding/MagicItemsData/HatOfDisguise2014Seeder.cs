using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Hat of Disguise (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class HatOfDisguise2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("hat-of-disguise", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Cappello del camuffamento", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Finché indossa questo cappello, il personaggio può usare un'azione per lanciare con esso l'incantesimo *camuffare se stesso* a volontà. L'incantesimo termina se il cappello viene rimosso."),
			("Hat of Disguise", "Wondrous item, uncommon (requires attunement)",
			"While wearing this hat, you can use an action to cast the disguise self spell from it at will. The spell ends if the hat is removed.", null));
	}
}
