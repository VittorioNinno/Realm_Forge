using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Hammer of Thunderbolts (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class HammerOfThunderbolts2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("hammer-of-thunderbolts", null, 0, MagicItemType.Weapon, ItemRarity.Legendary, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 1)),
			("Martello dei fulmini", "Arma (maglio), leggendaria",
			"Il personaggio ottiene un bonus di +1 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica.\n\n***Anatema dei giganti (richiede sintonia).*** Per entrare in sintonia con quest'arma, il personaggio deve indossare una *cintura della forza dei giganti* (di qualunque tipo) e dei *guanti del potere orchesco.* La sintonia termina se il personaggio rimuove uno qualsiasi di questi oggetti. Finché il personaggio è in sintonia con l'arma e la impugna, il suo punteggio di Forza aumenta di 4 e può superare 20, ma non 30. Quando il personaggio ottiene un 20 ai tiri per colpire effettuati con quest'arma contro un gigante, quest'ultimo deve superare un tiro salvezza su Costituzione con CD 17, altrimenti muore.\n\nIl martello, inoltre, possiede 5 cariche. Finché il personaggio è in sintonia con esso, può consumare 1 carica e usarlo per effettuare un attacco con arma a distanza, come se avesse la proprietà da lancio con una gittata normale di 6 metri e una gittata lunga di 18 metri. Se l'attacco va a segno, il martello genera un rombo di tuono udibile fino a 90 metri di distanza. Il bersaglio e ogni creatura entro 9 metri dal martello devono superare un tiro salvezza su Costituzione con CD 17, altrimenti diventano stordite fino alla fine del turno successivo del personaggio. Il martello recupera 1d4 + 1 cariche consumate all'alba di ogni giorno.", null),
			("Hammer of Thunderbolts", "Weapon (maul), legendary",
			"You gain a +1 bonus to attack and damage rolls made with this magic weapon.\n\nGiant's Bane (Requires attunement). You must be wearing a belt of giant strength (any variety) and gauntlets of ogre power to attune to this weapon. The attunement ends if you take off either of those items. While you are attuned to this weapon and holding it, your Strength score increases by 4 and can exceed 20, but not 30. When you roll a 20 on an attack roll made with this weapon against a giant, the giant must succeed on a DC 17 Constitution saving throw or die.\n\nThe hammer also has 5 charges. While attuned to it, you can expend 1 charge and make a ranged weapon attack with the hammer, hurling it as if it had the thrown property with a normal range of 20 feet and a long range of 60 feet. If the attack hits, the hammer unleashes a thunderclap audible out to 300 feet. The target and every creature within 30 feet of it must succeed on a DC 17 Constitution saving throw or be stunned until the end of your next turn. The hammer regains 1d4 + 1 expended charges daily at dawn.", null));
	}
}
