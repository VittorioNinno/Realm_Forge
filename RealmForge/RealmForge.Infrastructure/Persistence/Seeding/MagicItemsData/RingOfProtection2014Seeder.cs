using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Protection (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfProtection2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-protection", null, 0, MagicItemType.Ring, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Effect(MagicEffectKind.SavingThrows, 1)),
			("Anello di protezione", "Anello, raro (richiede sintonia)",
			"Il personaggio ottiene un bonus di +1 alla CA e ai tiri salvezza finché indossa questo anello."),
			("Ring of Protection", "Ring, rare (requires attunement)",
			"You gain a +1 bonus to AC and saving throws while wearing this ring.", null));
	}
}
