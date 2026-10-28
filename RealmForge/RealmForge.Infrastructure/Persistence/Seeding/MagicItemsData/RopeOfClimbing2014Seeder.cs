using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Rope of Climbing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RopeOfClimbing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("rope-of-climbing", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Corda per scalare", "Oggetto meraviglioso, non comune",
			"Questa corda di seta è lunga 18 metri, pesa 1,5 kg e può reggere fino a 1.500 kg di carico. Se il personaggio ne impugna un'estremità e usa un'azione per pronunciare la parola d'ordine, la corda si anima. Come azione bonus, il personaggio può ordinare all'altra estremità di muoversi verso una destinazione da lui indicata. L'estremità si muove di 3 metri durante il turno in cui il personaggio impartisce l'ordine e di 3 metri a ogni turno successivo del personaggio, finché non raggiunge la destinazione, non arriva alla sua lunghezza massima o finché il personaggio non le ordina di fermarsi. Il personaggio può anche ordinare alla corda di legarsi saldamente a un oggetto o di sciogliersi, annodarsi o sciogliere i nodi, oppure di arrotolarsi per essere trasportata.\n\nSe il personaggio le ordina di annodarsi, lungo la corda compare una serie di grandi nodi a distanza di 30 cm l'uno dall'altro. Quando è annodata, la corda si accorcia fino a una lunghezza di 15 metri e conferisce vantaggio alle prove effettuate per scalarla.\n\nLa corda possiede CA 20 e 20 punti ferita. Recupera 1 punto ferita ogni 5 minuti, purché le rimanga almeno 1 punto ferita. Se la corda scende a 0 punti ferita, viene distrutta.", null),
			("Rope of Climbing", "Wondrous item, uncommon",
			"This 60-foot length of silk rope weighs 3 pounds and can hold up to 3,000 pounds. If you hold one end of the rope and use an action to speak the command word, the rope animates. As a bonus action, you can command the other end to move toward a destination you choose. That end moves 10 feet on your turn when you first command it and 10 feet on each of your turns until reaching its destination, up to its maximum length away, or until you tell it to stop. You can also tell the rope to fasten itself securely to an object or to unfasten itself, to knot or unknot itself, or to coil itself for carrying.\n\nIf you tell the rope to knot, large knots appear at 1 foot intervals along the rope. While knotted, the rope shortens to a 50-foot length and grants advantage on checks made to climb it.\n\nThe rope has AC 20 and 20 hit points. It regains 1 hit point every 5 minutes as long as it has at least 1 hit point. If the rope drops to 0 hit points, it is destroyed.", null));
	}
}
