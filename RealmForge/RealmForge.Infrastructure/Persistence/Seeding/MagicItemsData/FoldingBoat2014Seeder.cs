using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Folding Boat (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class FoldingBoat2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("folding-boat", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Barca pieghevole", "Oggetto meraviglioso, raro",
			"Quest'oggetto si presenta come una scatola di legno lunga 30 cm, larga e profonda 15 cm. Pesa 2 kg e galleggia. Può essere aperta per custodire degli oggetti all'interno. Possiede tre parole d'ordine, per pronunciare ognuna delle quali è richiesta un'azione.\n\nUna delle parole d'ordine fa sì che la scatola si apra e si trasformi in una barca di 3 metri di lunghezza per 1,2 metri di larghezza e 60 cm di profondità, provvista di un paio di remi, un'ancora, un albero e una vela. La barca può trasportare comodamente fino a quattro creature di taglia Media.\n\nLa seconda parola d'ordine fa trasformare la scatola in una nave lunga 7,2 metri, larga 2,4 metri e profonda 1,8 metri, con un ponte, postazioni per i rematori, cinque paia di remi, un timone, un'ancora, una cabina sul ponte e un albero con una vela quadrata. La nave può trasportare comodamente quindici creature di taglia Media.\n\nQuando la scatola si trasforma in vascello, il suo peso diventa quello di un normale vascello di quella taglia; tutto ciò che era custodito all'interno della scatola rimane a bordo.\n\nLa terza parola d'ordine fa tornare la barca pieghevole alla forma di scatola, purché non vi siano creature a bordo. Gli oggetti a bordo del vascello troppo grandi per essere contenuti nella scatola restano all'esterno. Gli oggetti che possono entrare nella scatola rimangono al suo interno.", null),
			("Folding Boat", "Wondrous item, rare",
			"This object appears as a wooden box that measures 12 inches long, 6 inches wide, and 6 inches deep. It weighs 4 pounds and floats. It can be opened to store items inside. This item also has three command words, each requiring you to use an action to speak it.\n\nOne command word causes the box to unfold into a boat 10 feet long, 4 feet wide, and 2 feet deep. The boat has one pair of oars, an anchor, a mast, and a lateen sail. The boat can hold up to four Medium creatures comfortably.\n\nThe second command word causes the box to unfold into a ship 24 feet long, 8 feet wide, and 6 feet deep. The ship has a deck, rowing seats, five sets of oars, a steering oar, an anchor, a deck cabin, and a mast with a square sail. The ship can hold fifteen Medium creatures comfortably.\n\nWhen the box becomes a vessel, its weight becomes that of a normal vessel its size, and anything that was stored in the box remains in the boat.\n\nThe third command word causes the folding boat to fold back into a box, provided that no creatures are aboard. Any objects in the vessel that can't fit inside the box remain outside the box as it folds. Any objects in the vessel that can fit inside the box do so.", null));
	}
}
