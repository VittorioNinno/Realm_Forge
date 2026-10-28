using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Scimitar of Speed (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ScimitarOfSpeed2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("scimitar-of-speed", null, 0, MagicItemType.Weapon, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 2)),
			("Scimitarra della velocità", "Arma (scimitarra), molto rara (richiede sintonia)",
			"Il personaggio ottiene un bonus di +2 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica. Può inoltre effettuare un attacco con quest'arma come azione bonus a ogni suo turno."),
			("Scimitar of Speed", "Weapon (scimitar), very rare (requires attunement)",
			"You gain a +2 bonus to attack and damage rolls made with this magic weapon. In addition, you can make one attack with it as a bonus action on each of your turns.", null));
	}
}
