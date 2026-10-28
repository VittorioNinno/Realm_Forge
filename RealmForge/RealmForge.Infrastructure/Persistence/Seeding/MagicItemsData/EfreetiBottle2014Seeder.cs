using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Efreeti Bottle (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class EfreetiBottle2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("efreeti-bottle", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Bottiglia dell'efreeti", "Oggetto meraviglioso, molto raro",
			"Questa bottiglia di ottone dipinto pesa 0,5 kg. Quando il personaggio usa un'azione per rimuovere il tappo, dalla bottiglia si sprigiona una nube di fumo denso. Alla fine del turno del personaggio, il fumo scompare con un lampo di fuoco innocuo e in uno spazio libero entro 9 metri da lui compare un efreeti.\n\nLa prima volta che la bottiglia viene aperta, il GM tira per determinare cosa accade.\n\n| d100 | Effetto |\n|---|---|\n| 01–10 | L'efreeti attacca il personaggio. Dopo avere combattuto per 5 round, l'efreeti scompare e la bottiglia perde la sua magia. |\n| 11–90 | L'efreeti serve il personaggio per 1 ora e obbedisce ai suoi comandi, poi torna nella bottiglia, che viene chiusa da un nuovo tappo che non può essere rimosso per 24 ore. Le due volte successive in cui la bottiglia viene aperta, si ottiene lo stesso effetto. Se la bottiglia viene aperta una quarta volta, l'efreeti fugge scomparendo e la bottiglia perde la sua magia. |\n| 91–00 | L'efreeti può lanciare tre volte l'incantesimo desiderio a beneficio del personaggio, poi scompare dopo aver concesso l'ultimo desiderio o dopo 1 ora, e la bottiglia perde la sua magia. |", null),
			("Efreeti Bottle", "Wondrous item, very rare",
			"This painted brass bottle weighs 1 pound. When you use an action to remove the stopper, a cloud of thick smoke flows out of the bottle. At the end of your turn, the smoke disappears with a flash of harmless fire, and an efreeti appears in an unoccupied space within 30 feet of you.\n\nThe first time the bottle is opened, the GM rolls to determine what happens.\n\n| d100 | Effect |\n|---|---|\n| 01-10 | The efreeti attacks you. After fighting for 5 rounds, the efreeti disappears, and the bottle loses its magic. |\n| 11-90 | The efreeti serves you for 1 hour, doing as you command. Then the efreeti returns to the bottle, and a new stopper contains it. The stopper can't be removed for 24 hours. The next two times the bottle is opened, the same effect occurs. If the bottle is opened a fourth time, the efreeti escapes and disappears, and the bottle loses its magic. |\n| 91-100 | The efreeti can cast the wish spell three times for you. It disappears when it grants the final wish or after 1 hour, and the bottle loses its magic. |", null));
	}
}
