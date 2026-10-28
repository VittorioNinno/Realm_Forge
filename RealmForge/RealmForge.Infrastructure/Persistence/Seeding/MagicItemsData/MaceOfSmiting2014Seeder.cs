using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Mace of Smiting (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class MaceOfSmiting2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("mace-of-smiting", null, 0, MagicItemType.Weapon, ItemRarity.Rare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 1)),
			("Mazza della punizione", "Arma (mazza), rara",
			"Il personaggio ottiene un bonus di +1 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica. Quando la usa per attaccare un costrutto, questo bonus sale a +3.\n\nQuando il personaggio ottiene un 20 a un tiro per colpire con quest'arma, il bersaglio subisce 2d6 danni contundenti extra o 4d6 danni contundenti se si tratta di un costrutto. Se dopo aver subito tali danni un costrutto scende a 25 punti ferita o meno, viene distrutto.", null),
			("Mace of Smiting", "Weapon (mace), rare",
			"You gain a +1 bonus to attack and damage rolls made with this magic weapon. The bonus increases to +3 when you use the mace to attack a construct.\n\nWhen you roll a 20 on an attack roll made with this weapon, the target takes an extra 2d6 bludgeoning damage, or 4d6 bludgeoning damage if it's a construct. If a construct has 25 hit points or fewer after taking this damage, it is destroyed.", null));
	}
}
