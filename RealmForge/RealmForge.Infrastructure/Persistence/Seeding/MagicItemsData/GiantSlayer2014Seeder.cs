using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Giant Slayer (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class GiantSlayer2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("giant-slayer", null, 0, MagicItemType.Weapon, ItemRarity.Rare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 1)),
			("Ammazzagiganti", "Arma (qualsiasi ascia o spada), rara",
			"Il personaggio ottiene un bonus di +1 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica.\n\nQuando il personaggio colpisce un gigante con quest'arma, il gigante subisce 2d6 danni extra del tipo inflitto dall'arma e deve superare un tiro salvezza su Forza con CD 15, altrimenti cade a terra prono. Ai fini di quest'arma, \"gigante\" si riferisce a qualsiasi creatura del tipo gigante, inclusi gli ettin e i troll."),
			("Giant Slayer", "Weapon (any axe or sword), rare",
			"You gain a +1 bonus to attack and damage rolls made with this magic weapon.\n\nWhen you hit a giant with it, the giant takes an extra 2d6 damage of the weapon's type and must succeed on a DC 15 Strength saving throw or fall prone. For the purpose of this weapon, \"giant\" refers to any creature with the giant type, including ettins and trolls.", null));
	}
}
