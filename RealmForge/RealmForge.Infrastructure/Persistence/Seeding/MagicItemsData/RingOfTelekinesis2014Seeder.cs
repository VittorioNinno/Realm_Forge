using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Telekinesis (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfTelekinesis2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-telekinesis", null, 0, MagicItemType.Ring, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Anello di telecinesi", "Anello, molto raro (richiede sintonia)",
			"Finché il personaggio indossa questo anello, può lanciare l'incantesimo *telecinesi* a volontà, ma il bersaglio dell'incantesimo può essere solo un oggetto che non è indossato o trasportato."),
			("Ring of Telekinesis", "Ring, very rare (requires attunement)",
			"While wearing this ring, you can cast the telekinesis spell at will, but you can target only objects that aren't being worn or carried.", null));
	}
}
