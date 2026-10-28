using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Arrow-Catching Shield (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ArrowCatchingShield2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("arrow-catching-shield", null, 0, MagicItemType.Armor, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Scudo catturafrecce", "Armatura (scudo), rara (richiede sintonia)",
			"Il personaggio che impugna questo scudo riceve un bonus di +2 alla CA contro gli attacchi a distanza. Questo bonus è cumulativo al normale bonus alla CA dello scudo. Inoltre, ogni volta che un avversario effettua un attacco a distanza contro un bersaglio entro 1,5 metri dal possessore dello scudo, quest'ultimo può usare la sua reazione per diventare il bersaglio dell'attacco al posto di quello inteso.", null),
			("Arrow-Catching Shield", "Armor (shield), rare (requires attunement)",
			"You gain a +2 bonus to AC against ranged attacks while you wield this shield. This bonus is in addition to the shield's normal bonus to AC. In addition, whenever an attacker makes a ranged attack against a target within 5 feet of you, you can use your reaction to become the target of the attack instead.", null));
	}
}
