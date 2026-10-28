using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Vorpal Sword (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class VorpalSword2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("vorpal-sword", null, 0, MagicItemType.Weapon, ItemRarity.Legendary, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 3)),
			("Spada vorpal", "Arma (qualsiasi spada che infligga danni taglienti), leggendaria (richiede sintonia)",
			"Il personaggio ottiene un bonus di +3 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica. Inoltre, l'arma ignora la resistenza ai danni taglienti.\n\nQuando il personaggio attacca con quest'arma una creatura che possiede almeno una testa e ottiene un risultato di 20 al tiro per colpire, riesce a tagliare una testa della creatura. La creatura muore se non riesce a sopravvivere senza testa. Una creatura è immune a questo effetto se è immune ai danni taglienti, non possiede o non ha bisogno di una testa, ha azioni leggendarie, oppure se il GM decide che la creatura è troppo grande perché la sua testa possa essere tagliata con quest'arma. Tale creatura subisce invece 6d8 danni taglienti extra dal colpo."),
			("Vorpal Sword", "Weapon (any sword that deals slashing damage), legendary (requires attunement)",
			"You gain a +3 bonus to attack and damage rolls made with this magic weapon. In addition, the weapon ignores resistance to slashing damage.\n\nWhen you attack a creature that has at least one head with this weapon and roll a 20 on the attack roll, you cut off one of the creature's heads. The creature dies if it can't survive without the lost head. A creature is immune to this effect if it is immune to slashing damage, doesn't have or need a head, has legendary actions, or the GM decides that the creature is too big for its head to be cut off with this weapon. Such a creature instead takes an extra 6d8 slashing damage from the hit.", null));
	}
}
