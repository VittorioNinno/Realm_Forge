using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Invisibility (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfInvisibility2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-invisibility", null, 0, MagicItemType.Ring, ItemRarity.Legendary, true, ContentSource.Srd51,
			null,
			("Anello di invisibilità", "Anello, leggendario (richiede sintonia)",
			"Mentre il personaggio indossa questo anello, può usare un'azione per diventare invisibile insieme a tutto ciò che indossa o trasporta. Rimane invisibile finché l'anello non è rimosso, finché non attacca o lancia un incantesimo o finché non usa un'azione bonus per diventare di nuovo visibile."),
			("Ring of Invisibility", "Ring, legendary (requires attunement)",
			"While wearing this ring, you can turn invisible as an action. Anything you are wearing or carrying is invisible with you. You remain invisible until the ring is removed, until you attack or cast a spell, or until you use a bonus action to become visible again.", null));
	}
}
