using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Weapon, +1, +2, or +3 (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class Weapon2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("weapon", null, 0, MagicItemType.Weapon, null, false, ContentSource.Srd51,
			null,
			("Arma +1, +2 o +3", "Arma (qualsiasi), non comune (+1), rara (+2) o molto",
			"*rara (+3)* Il personaggio ottiene un bonus di ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica. Il bonus è determinato dalla rarità dell'arma.", null),
			("Weapon, +1, +2, or +3", "Weapon (any), uncommon (+1), rare (+2), or very rare (+3)",
			"You have a bonus to attack and damage rolls made with this magic weapon. The bonus is determined by the weapon's rarity.", null));
		yield return Item("weapon-1", "weapon", 1, MagicItemType.Weapon, ItemRarity.Uncommon, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 1)),
			("Arma +1", "Arma (qualsiasi), non comune",
			"", null),
			("Weapon, +1", "Weapon (any), uncommon",
			"", null));
		yield return Item("weapon-2", "weapon", 2, MagicItemType.Weapon, ItemRarity.Rare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 2)),
			("Arma +2", "Arma (qualsiasi), rara",
			"", null),
			("Weapon, +2", "Weapon (any), rare",
			"", null));
		yield return Item("weapon-3", "weapon", 3, MagicItemType.Weapon, ItemRarity.VeryRare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 3)),
			("Arma +3", "Arma (qualsiasi), molto rara",
			"", null),
			("Weapon, +3", "Weapon (any), very rare",
			"", null));
	}
}
