using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ammunition, +1, +2, or +3 (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class Ammunition2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ammunition", null, 0, MagicItemType.Weapon, null, false, ContentSource.Srd51,
			null,
			("Munizione +1, +2 o +3", "Arma (qualsiasi munizione), non comune (+1), rara (+2) o molto rara (+3)",
			"Il personaggio ottiene un bonus ai tiri per colpire e ai tiri per i danni effettuati con questa munizione magica. Il bonus è determinato dalla rarità della munizione. Una volta colpito il bersaglio, la munizione non è più magica.", null),
			("Ammunition, +1, +2, or +3", "Weapon (any ammunition), uncommon (+1), rare (+2), or very rare (+3)",
			"You have a bonus to attack and damage rolls made with this piece of magic ammunition. The bonus is determined by the rarity of the ammunition. Once it hits a target, the ammunition is no longer magical.", null));
		yield return Item("ammunition-1", "ammunition", 1, MagicItemType.Weapon, ItemRarity.Uncommon, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 1)),
			("Munizione +1", "Arma (qualsiasi munizione), non comune",
			"", null),
			("Ammunition, +1", "Weapon (any ammunition), uncommon",
			"", null));
		yield return Item("ammunition-2", "ammunition", 2, MagicItemType.Weapon, ItemRarity.Rare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 2)),
			("Munizione +2", "Arma (qualsiasi munizione), rara",
			"", null),
			("Ammunition, +2", "Weapon (any ammunition), rare",
			"", null));
		yield return Item("ammunition-3", "ammunition", 3, MagicItemType.Weapon, ItemRarity.VeryRare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 3)),
			("Munizione +3", "Arma (qualsiasi munizione), molto rara",
			"", null),
			("Ammunition, +3", "Weapon (any ammunition), very rare",
			"", null));
	}
}
