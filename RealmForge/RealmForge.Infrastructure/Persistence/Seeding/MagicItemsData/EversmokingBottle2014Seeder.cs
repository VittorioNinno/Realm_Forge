using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Eversmoking Bottle (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class EversmokingBottle2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("eversmoking-bottle", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Bottiglia del fumo perenne", "Oggetto meraviglioso, non comune",
			"Da questa bottiglia di ottone del peso di 0,5 kg e chiusa da un tappo di piombo si levano dei sottili fili di fumo. Quando il personaggio usa un'azione per rimuovere il tappo, si sprigiona una fitta nube di fumo che si diffonde in un raggio di 18 metri dalla bottiglia. L'area coperta dal fumo è pesantemente oscurata. Per ogni minuto in cui la bottiglia resta aperta e all'interno della nube, il raggio aumenta di 3 metri finché non arriva a un raggio massimo di 36 metri.\n\nLa nube permane finché la bottiglia resta aperta. Per chiudere la bottiglia il personaggio deve usare un'azione per pronunciare la sua parola d'ordine. Una volta chiusa, il fumo si disperde dopo 10 minuti. Un vento moderato (da 15 a 30 km orari) disperde il fumo nel giro di 1 minuto, mentre un vento forte (oltre 30 km orari) lo disperde in 1 round."),
			("Eversmoking Bottle", "Wondrous item, uncommon",
			"Smoke leaks from the lead-stoppered mouth of this brass bottle, which weighs 1 pound. When you use an action to remove the stopper, a cloud of thick smoke pours out in a 60-foot radius from the bottle. The cloud's area is heavily obscured. Each minute the bottle remains open and within the cloud, the radius increases by 10 feet until it reaches its maximum radius of 120 feet.\n\nThe cloud persists as long as the bottle is open. Closing the bottle requires you to speak its command word as an action. Once the bottle is closed, the cloud disperses after 10 minutes. A moderate wind (11 to 20 miles per hour) can also disperse the smoke after 1 minute, and a strong wind (21 or more miles per hour) can do so after 1 round.", null));
	}
}
