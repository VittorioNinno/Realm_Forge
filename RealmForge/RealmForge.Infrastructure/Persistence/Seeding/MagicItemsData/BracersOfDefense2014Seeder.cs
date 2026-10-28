using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Bracers of Defense (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BracersOfDefense2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("bracers-of-defense", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.UnarmoredArmorClass, 2)),
			("Bracciali della difesa", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Il personaggio che indossa questi bracciali ottiene un bonus di +2 alla CA se non veste alcuna armatura e non usa uno scudo.", null),
			("Bracers of Defense", "Wondous item, rare (requires attunement)",
			"While wearing these bracers, you gain a +2 bonus to AC if you are wearing no armor and using no shield.", null));
	}
}
