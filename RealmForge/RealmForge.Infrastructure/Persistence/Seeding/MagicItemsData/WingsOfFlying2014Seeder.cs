using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Wings of Flying (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WingsOfFlying2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("wings-of-flying", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Ali del volo", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Mentre il personaggio indossa questo mantello, può usare un'azione per pronunciarne la parola d'ordine. Quando lo fa, il mantello si trasforma in un paio di ali da pipistrello o da uccello che spuntano dalla sua schiena per 1 ora o finché il personaggio non usa un'azione per ripetere la parola d'ordine. Le ali gli forniscono una velocità di volare di 18 metri. Quando scompaiono, il personaggio non può riutilizzarle per 1d12 ore."),
			("Wings of Flying", "Wondrous item, rare (requires attunement)",
			"While wearing this cloak, you can use an action to speak its command word. This turns the cloak into a pair of bat wings or bird wings on your back for 1 hour or until you repeat the command word as an action. The wings give you a flying speed of 60 feet. When they disappear, you can't use them again for 1d12 hours.", null));
	}
}
