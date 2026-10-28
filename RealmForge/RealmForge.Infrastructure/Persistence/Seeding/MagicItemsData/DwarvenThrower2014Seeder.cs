using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Dwarven Thrower (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DwarvenThrower2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("dwarven-thrower", null, 0, MagicItemType.Weapon, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 3)),
			("Martello nanico da lancio", "Arma (martello da guerra), molto rara (richiede sintonia con un nano)",
			"Il personaggio ottiene un bonus di +3 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica. L'arma possiede la proprietà da lancio con una gittata normale di 6 metri e una gittata lunga di 18 metri. Quando il personaggio colpisce un bersaglio con un attacco a distanza con quest'arma, infligge 1d8 danni extra o 2d8 danni, se il bersaglio è un gigante. Subito dopo l'attacco, quest'arma torna in volo in mano al personaggio."),
			("Dwarven Thrower", "Weapon (warhammer), very rare (requires attunement by a dwarf)",
			"You gain a +3 bonus to attack and damage rolls made with this magic weapon. It has the thrown property with a normal range of 20 feet and a long range of 60 feet. When you hit with a ranged attack using this weapon, it deals an extra 1d8 damage or, if the target is a giant, 2d8 damage. Immediately after the attack, the weapon flies back to your hand.", null));
	}
}
