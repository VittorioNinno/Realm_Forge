using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Defender (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class Defender2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("defender", null, 0, MagicItemType.Weapon, ItemRarity.Legendary, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 3)),
			("Difensiva", "Arma (qualsiasi spada), leggendaria (richiede sintonia)",
			"Il personaggio ottiene un bonus di +3 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica.\n\nLa prima volta in ogni suo turno in cui attacca con quest'arma, il personaggio può trasferire tutto il bonus dell'arma o parte di esso alla propria Classe Armatura, anziché usarlo negli attacchi effettuati in quel turno. Potrebbe, per esempio, ridurre il bonus ai tiri per colpire e a quelli per i danni a +1 e ottenere un bonus di +2 alla CA. I bonus modificati restano in vigore fino all'inizio del turno successivo del personaggio, che deve però impugnare l'arma per ottenere il bonus alla CA.", null),
			("Defender", "Weapon (any sword), legendary (requires attunement)",
			"You gain a +3 bonus to attack and damage rolls made with this magic weapon.\n\nThe first time you attack with the sword on each of your turns, you can transfer some or all of the sword's bonus to your Armor Class, instead of using the bonus on any attacks that turn. For example, you could reduce the bonus to your attack and damage rolls to +1 and gain a +2 bonus to AC. The adjusted bonuses remain in effect until the start of your next turn, although you must hold the sword to gain a bonus to AC from it.", null));
	}
}
