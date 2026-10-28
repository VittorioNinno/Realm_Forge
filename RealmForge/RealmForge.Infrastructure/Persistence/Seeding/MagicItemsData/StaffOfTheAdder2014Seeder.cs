using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Staff of the Adder (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class StaffOfTheAdder2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("staff-of-the-adder", null, 0, MagicItemType.Staff, ItemRarity.Uncommon, true, ContentSource.RealmForge,
			null,
			("Bastone della vipera", "Bastone, non comune (richiede sintonia con un chierico, un druido o un warlock)",
			"Con un'azione bonus, il personaggio può pronunciare la parola di comando del bastone per trasformarne la punta nella testa di un serpente velenoso vivo per 1 minuto; un'altra azione bonus con la stessa parola lo fa tornare inerte.\n\nIl personaggio può effettuare un attacco in mischia con la testa di serpente, che ha una portata di 1,5 metri; al tiro per colpire si applica il suo bonus di competenza. Se colpisce, il bersaglio subisce 1d6 danni perforanti e deve superare un tiro salvezza su Costituzione con CD 15, altrimenti subisce 3d6 danni da veleno.\n\nLa testa di serpente può essere attaccata mentre è animata: ha CA 15 e 20 punti ferita. Se scende a 0 punti ferita, il bastone viene distrutto. Finché non è distrutto, recupera tutti i punti ferita quando torna inerte."),
			("Staff of the Adder", "Staff, uncommon (requires attunement by a cleric, druid, or warlock)",
			"As a bonus action, you can speak the staff's command word to turn its head into that of a living poisonous snake for 1 minute; another bonus action with the same word turns it back.\n\nYou can make a melee attack with the snake head, which has a reach of 5 feet; your proficiency bonus applies to the attack roll. On a hit, the target takes 1d6 piercing damage and must succeed on a DC 15 Constitution saving throw or take 3d6 poison damage.\n\nThe snake head can be attacked while it is animate: it has AC 15 and 20 hit points. If it drops to 0 hit points, the staff is destroyed. As long as it isn't destroyed, it regains all its hit points when it turns back.", null));
	}
}
