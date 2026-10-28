using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Nine Lives Stealer (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class NineLivesStealer2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("nine-lives-stealer", null, 0, MagicItemType.Weapon, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 2)),
			("Spada Ruba nove vite", "Arma (qualsiasi spada), molto rara (richiede sintonia)",
			"Il personaggio ottiene un bonus di +2 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica.\n\nLa spada possiede 1d8 + 1 cariche. Quando il personaggio mette a segno un colpo critico contro una creatura con meno di 100 punti ferita, quest'ultima deve superare un tiro salvezza su Costituzione con CD 15, altrimenti muore all'istante poiché la spada risucchia l'energia vitale dal suo corpo (i costrutti e i non morti sono immuni a questo effetto). La spada perde 1 carica per ogni creatura uccisa in questo modo. Quando termina le cariche, la spada perde questa proprietà."),
			("Nine Lives Stealer", "Weapon (any sword), very rare (requires attunement)",
			"You gain a +2 bonus to attack and damage rolls made with this magic weapon.\n\nThe sword has 1d8 + 1 charges. If you score a critical hit against a creature that has fewer than 100 hit points, it must succeed on a DC 15 Constitution saving throw or be slain instantly as the sword tears its life force from its body (a construct or an undead is immune). The sword loses 1 charge if the creature is slain. When the sword has no charges remaining, it loses this property.", null));
	}
}
