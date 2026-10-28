using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Sword of Life Stealing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class SwordOfLifeStealing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("sword-of-life-stealing", null, 0, MagicItemType.Weapon, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Spada del furto vitale", "Arma (qualsiasi spada), rara (richiede sintonia)",
			"Quando il personaggio attacca una creatura con quest'arma magica e ottiene 20 al tiro per colpire, il bersaglio subisce 3d6 danni necrotici extra se non è un costrutto o un non morto. Il personaggio riceve inoltre punti ferita temporanei pari ai danni extra inflitti."),
			("Sword of Life Stealing", "Weapon (any sword), rare (requires attunement)",
			"When you attack a creature with this magic weapon and roll a 20 on the attack roll, that target takes an extra 3d6 necrotic damage, provided that the target isn't a construct or an undead. You gain temporary hit points equal to the extra damage dealt.", null));
	}
}
