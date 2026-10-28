using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Feather Token (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class FeatherToken2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("feather-token", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Piuma magica", "Oggetto meraviglioso, raro",
			"Questo minuscolo oggetto ha l'aspetto di una piuma. Esistono vari tipi di piume, ognuna con un effetto monouso diverso. Il GM può scegliere il tipo di piuma o determinarlo casualmente.\n\n| d100 | Piuma | d100 | Piuma |\n|---|---|---|---|\n| 01–25 | Albero | 61–70 | Frusta |\n| 26–45 | Ancora | 71–85 | Uccello |\n| 46–60 | Barca cigno | 86–100 | Ventaglio |\n\n***Albero.*** Il personaggio deve trovarsi all'esterno per usare questa piuma. Può usare un'azione per toccare con la piuma uno spazio libero sul terreno. Al posto della piuma compare una quercia non magica. L'albero è alto 18 metri, ha un tronco del diametro di 1,5 metri e i rami sulla cima si estendono in un raggio di 6 metri.\n\n***Ancora.*** Il personaggio può usare un'azione per toccare con la piuma una barca o una nave. Per le 24 ore successive, il vascello non può essere spostato in alcun modo. Toccando nuovamente il vascello con la piuma, l'effetto termina. Quando l'effetto termina, la piuma scompare.\n\n***Barca cigno.*** Il personaggio può usare un'azione per toccare con la piuma uno specchio d'acqua del diametro di almeno 18 metri. Al posto della piuma compare una barca a forma di cigno, lunga 15 metri e larga 6 metri, che si muove da sola sull'acqua a una velocità di 9 km orari. Finché si trova a bordo della barca, il personaggio può usare un'azione per ordinarle di avanzare o virare di un massimo di 90 gradi. La barca può trasportare fino a trentadue creature di taglia Media o inferiore. Una creatura Grande conta come quattro creature Medie e una creatura Enorme conta come nove creature Medie. La barca permane per 24 ore e poi scompare. Il personaggio può congedare la barca con un'azione.\n\n***Frusta.*** Il personaggio può usare un'azione per lanciare la piuma in un punto entro 3 metri da lui. Al posto della piuma compare una frusta che fluttua nell'aria. Il personaggio può allora usare un'azione bonus per effettuare un attacco in mischia con incantesimo contro una creatura situata entro 3 metri dalla frusta, con un bonus di attacco di +9. Se il colpo va a segno, il bersaglio subisce 1d6 + 5 danni da forza.\n\nCome azione bonus nel suo turno, il personaggio può dirigere la frusta in volo per una distanza massima di 6 metri e ripetere l'attacco contro un bersaglio situato entro 3 metri da essa. La frusta scompare dopo 1 ora, quando il personaggio usa un'azione per congedarla o quando questi è incapacitato o muore.\n\n***Uccello.*** Il personaggio può usare un'azione per lanciare la piuma in aria per 1,5 metri. Al posto della piuma compare un enorme uccello dal piumaggio sgargiante. L'uccello ha le statistiche di un roc, ma obbedisce ai semplici comandi del personaggio e non può attaccare. Può trasportare fino a 250 kg di peso alla sua velocità massima (24 km orari fino a un massimo di 216 km al giorno, con un'ora di riposo ogni 3 ore di viaggio) o 500 kg a velocità dimezzata. L'uccello scompare dopo aver percorso in volo la sua distanza massima per un giorno di viaggio o se scende a 0 punti ferita. Il personaggio può congedare l'uccello con un'azione.\n\n***Ventaglio.*** Se il personaggio si trova su una barca o una nave, può usare un'azione per lanciare la piuma in aria per 3 metri. Al posto della piuma compare un gigantesco ventaglio che si agita da solo. Il ventaglio fluttua in aria e crea un vento abbastanza forte da gonfiare le vele di una nave, aumentandone la velocità di 7,5 km orari per un periodo di 8 ore. Il personaggio può congedare il ventaglio con un'azione.", "Piuma di Quaal"),
			("Feather Token", "Wondrous item, rare",
			"This tiny object looks like a feather. Different types of feather tokens exist, each with a different single use effect. The GM chooses the kind of token or determines it randomly.\n\n| d100 | Feather Token |\n|---|---|\n| 01-20 | Anchor |\n| 21-35 | Bird |\n| 36-50 | Fan |\n| 51-65 | Swan boat |\n| 66-90 | Tree |\n| 91-100 | Whip |\n\n***Anchor.*** You can use an action to touch the token to a boat or ship. For the next 24 hours, the vessel can't be moved by any means. Touching the token to the vessel again ends the effect. When the effect ends, the token disappears.\n\n***Bird.*** You can use an action to toss the token 5 feet into the air. The token disappears and an enormous, multicolored bird takes its place. The bird has the statistics of a roc, but it obeys your simple commands and can't attack. It can carry up to 500 pounds while flying at its maximum speed (16 miles an hour for a maximum of 144 miles per day, with a one-hour rest for every 3 hours of flying), or 1,000 pounds at half that speed. The bird disappears after flying its maximum distance for a day or if it drops to 0 hit points. You can dismiss the bird as an action.\n\n***Fan.*** If you are on a boat or ship, you can use an action to toss the token up to 10 feet in the air. The token disappears, and a giant flapping fan takes its place. The fan floats and creates a wind strong enough to fill the sails of one ship, increasing its speed by 5 miles per hour for 8 hours. You can dismiss the fan as an action.\n\n***Swan Boat.*** You can use an action to touch the token to a body of water at least 60 feet in diameter. The token disappears, and a 50-foot-long, 20-foot wide boat shaped like a swan takes its place. The boat is self-propelled and moves across water at a speed of 6 miles per hour. You can use an action while on the boat to command it to move or to turn up to 90 degrees. The boat can carry up to thirty-two Medium or smaller creatures. A Large creature counts as four Medium creatures, while a Huge creature counts as nine. The boat remains for 24 hours and then disappears. You can dismiss the boat as an action.\n\n***Tree.*** You must be outdoors to use this token. You can use an action to touch it to an unoccupied space on the ground. The token disappears, and in its place a nonmagical oak tree springs into existence. The tree is 60 feet tall and has a 5-foot-diameter trunk, and its branches at the top spread out in a 20-foot radius.\n\n***Whip.*** You can use an action to throw the token to a point within 10 feet of you. The token disappears, and a floating whip takes its place. You can then use a bonus action to make a melee spell attack against a creature within 10 feet of the whip, with an attack bonus of +9. On a hit, the target takes 1d6 + 5 force damage.\n\nAs a bonus action on your turn, you can direct the whip to fly up to 20 feet and repeat the attack against a creature within 10 feet of it. The whip disappears after 1 hour, when you use an action to dismiss it, or when you are incapacitated or die.", "Quaal's Feather Token"));
		yield return Item("feather-token-anchor", "feather-token", 1, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Piuma magica (ancora)", "Oggetto meraviglioso, raro",
			"", null),
			("Anchor Feather Token", "Wondrous item, rare",
			"", null));
		yield return Item("feather-token-bird", "feather-token", 2, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Piuma magica (uccello)", "Oggetto meraviglioso, raro",
			"", null),
			("Bird Feather Token", "Wondrous item, rare",
			"", null));
		yield return Item("feather-token-fan", "feather-token", 3, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Piuma magica (ventaglio)", "Oggetto meraviglioso, raro",
			"", null),
			("Fan Feather Token", "Wondrous item, rare",
			"", null));
		yield return Item("feather-token-swan-boat", "feather-token", 4, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Piuma magica (barca cigno)", "Oggetto meraviglioso, raro",
			"", null),
			("Swan Boat Feather Token", "Wondrous item, rare",
			"", null));
		yield return Item("feather-token-tree", "feather-token", 5, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Piuma magica (albero)", "Oggetto meraviglioso, raro",
			"", null),
			("Tree Feather Token", "Wondrous item, rare",
			"", null));
		yield return Item("feather-token-whip", "feather-token", 6, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Piuma magica (frusta)", "Oggetto meraviglioso, raro",
			"", null),
			("Whip Feather Token", "Wondrous item, rare",
			"", null));
	}
}
