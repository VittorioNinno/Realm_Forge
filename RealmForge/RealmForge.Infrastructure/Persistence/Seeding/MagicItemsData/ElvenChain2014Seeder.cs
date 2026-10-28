using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Elven Chain (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ElvenChain2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("elven-chain", null, 0, MagicItemType.Armor, ItemRarity.Rare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1)),
			("Giaco di maglia elfico", "Armatura (giaco di maglia), rara",
			"Quando il personaggio indossa quest'armatura, ottiene un bonus di +1 alla CA ed è considerato competente nell'uso di quest'armatura anche se è privo di competenza nell'uso delle armature medie.", null),
			("Elven Chain", "Armor (chain shirt), rare",
			"You gain a +1 bonus to AC while you wear this armor. You are considered proficient with this armor even if you lack proficiency with medium armor.", null));
	}
}
