using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Jumping (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfJumping2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-jumping", null, 0, MagicItemType.Ring, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Anello del saltare", "Anello, non comune (richiede sintonia)",
			"Mentre il personaggio indossa questo anello, può lanciare con esso l'incantesimo *saltare* a volontà come azione bonus, ma può bersagliare solo se stesso.", null),
			("Ring of Jumping", "Ring, uncommon (requires attunement)",
			"While wearing this ring, you can cast the jump spell from it as a bonus action at will, but can target only yourself when you do so.", null));
	}
}
