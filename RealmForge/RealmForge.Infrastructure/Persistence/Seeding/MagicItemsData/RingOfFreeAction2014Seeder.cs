using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Free Action (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfFreeAction2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-free-action", null, 0, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Anello della libertà di azione", "Anello, raro (richiede sintonia)",
			"Mentre il personaggio indossa questo anello, il terreno difficile non gli costa movimento extra. Inoltre, la magia non può né ridurre la sua velocità né renderlo paralizzato o trattenuto."),
			("Ring of Free Action", "Ring, rare (requires attunement)",
			"While you wear this ring, difficult terrain doesn't cost you extra movement. In addition, magic can neither reduce your speed nor cause you to be paralyzed or restrained.", null));
	}
}
