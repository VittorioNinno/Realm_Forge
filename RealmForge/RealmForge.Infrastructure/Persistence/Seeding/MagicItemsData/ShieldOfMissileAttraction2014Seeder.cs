using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Shield of Missile Attraction (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class ShieldOfMissileAttraction2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("shield-of-missile-attraction", null, 0, MagicItemType.Armor, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Scudo attiraproiettili", "Armatura (scudo), rara (richiede sintonia)",
			"Mentre il personaggio impugna questo scudo, ottiene resistenza ai danni inflitti dagli attacchi con armi a distanza.\n\n***Maledizione.*** Questo scudo è maledetto. Entrando in sintonia con lo scudo, il personaggio diventa soggetto alla maledizione finché su di lui non viene lanciato l'incantesimo *rimuovi maledizione* o un'altra magia simile. Rimuovendo lo scudo, la maledizione non svanisce. Ogni volta che qualcuno effettua un attacco con arma a distanza il cui bersaglio si trova entro 3 metri dal personaggio, quest'ultimo diventa il bersaglio dell'attacco a causa della maledizione."),
			("Shield of Missile Attraction", "Armor (shield), rare (requires attunement)",
			"While holding this shield, you have resistance to damage from ranged weapon attacks.\n\n***Curse.*** This shield is cursed. Attuning to it curses you until you are targeted by the remove curse spell or similar magic. Removing the shield fails to end the curse on you. Whenever a ranged weapon attack is made against a target within 10 feet of you, the curse causes you to become the target instead.", null));
	}
}
