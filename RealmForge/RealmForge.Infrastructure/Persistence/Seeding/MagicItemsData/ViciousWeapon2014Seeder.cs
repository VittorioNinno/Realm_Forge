using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Vicious Weapon (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ViciousWeapon2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("vicious-weapon", null, 0, MagicItemType.Weapon, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Arma spietata", "Arma (qualsiasi), rara",
			"Quando il personaggio ottiene un risultato di 20 al tiro per colpire con quest'arma magica, il colpo critico infligge 2d6 danni extra del tipo inflitto dall'arma."),
			("Vicious Weapon", "Weapon (any), rare",
			"When you roll a 20 on your attack roll with this magic weapon, your critical hit deals an extra 2d6 damage of the weapon's type.", null));
	}
}
