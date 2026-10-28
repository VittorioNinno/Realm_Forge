using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Dragon Slayer (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DragonSlayer2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("dragon-slayer", null, 0, MagicItemType.Weapon, ItemRarity.Rare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 1)),
			("Ammazzadraghi", "Arma (qualsiasi spada), rara",
			"Il personaggio ottiene un bonus di +1 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica.\n\nQuando il personaggio colpisce un drago con quest'arma, il drago subisce 3d6 danni extra del tipo inflitto dall'arma. Ai fini di quest'arma, per \"drago\" si intende qualsiasi creatura del tipo drago, incluse le testuggini dragone e le Ammazzagigantiiverne."),
			("Dragon Slayer", "Weapon (any sword), rare",
			"You gain a +1 bonus to attack and damage rolls made with this magic weapon.\n\nWhen you hit a dragon with this weapon, the dragon takes an extra 3d6 damage of the weapon's type. For the purpose of this weapon, \"dragon\" refers to any creature with the dragon type, including dragon turtles and wyverns.", null));
	}
}
