using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Scroll of Protection (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class ScrollOfProtection2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("scroll-of-protection", null, 0, MagicItemType.Scroll, ItemRarity.Rare, false, ContentSource.RealmForge,
			null,
			("Pergamena di protezione", "Pergamena, rara",
			"Ogni pergamena di protezione è efficace contro un tipo di creatura scelto dal GM o determinato con la tabella.\n\nLeggendo la pergamena con un'azione, il personaggio viene circondato da una barriera invisibile a forma di cilindro, con raggio di 1,5 metri e altezza di 3 metri. Per 5 minuti la barriera impedisce alle creature del tipo indicato di entrare nel cilindro o di influenzare qualsiasi cosa al suo interno. Il cilindro si sposta con il personaggio restando centrato su di lui, ma se il personaggio si muove in modo che una di quelle creature si ritrovi all'interno, l'effetto termina.\n\nUna creatura può usare un'azione per effettuare una prova di Carisma con CD 15: se la supera, la barriera non ha più effetto su di essa.\n\n| d100 | Tipo di creatura |\n|---|---|\n| 01–10 | Aberrazioni |\n| 11–20 | Bestie |\n| 21–30 | Celestiali |\n| 31–40 | Elementali |\n| 41–50 | Folletti |\n| 51–75 | Immondi |\n| 76–80 | Vegetali |\n| 81–00 | Non morti |", null),
			("Scroll of Protection", "Scroll, rare",
			"Each scroll of protection works against one type of creature, chosen by the DM or rolled on the table.\n\nReading the scroll as an action surrounds you with an invisible cylinder-shaped barrier, 5 feet in radius and 10 feet high. For 5 minutes it keeps creatures of that type from entering the cylinder or affecting anything inside it. The cylinder moves with you, centered on you, but if you move so that one of those creatures ends up inside it, the effect ends.\n\nA creature can use an action to make a DC 15 Charisma check; on a success, the barrier no longer affects it.\n\n| d100 | Creature type |\n|---|---|\n| 01–10 | Aberrations |\n| 11–20 | Beasts |\n| 21–30 | Celestials |\n| 31–40 | Elementals |\n| 41–50 | Fey |\n| 51–75 | Fiends |\n| 76–80 | Plants |\n| 81–00 | Undead |", null));
	}
}
