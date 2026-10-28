using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Necklace of Prayer Beads (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class NecklaceOfPrayerBeads2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("necklace-of-prayer-beads", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Collana di grani di preghiera", "Oggetto meraviglioso, raro (richiede sintonia con un chierico, druido o paladino)",
			"Questa collana ha 1d4 + 2 perle magiche fatte di acquamarina, perla nera o topazio, oltre a molte perle non magiche fatte di ambra, diaspro, citrino, corallo, giada, perla o quarzo. Se una perla magica viene rimossa dalla collana, perde la sua magia.\n\nEsistono sei tipi di perline magiche. Il GM decide il tipo di ogni perla sulla collana o lo determina casualmente. La collana può includere più perle dello stesso tipo. Per usarne una, il personaggio deve usare la collana. Ogni perla contiene un incantesimo che il personaggio può lanciare come azione bonus (usando la sua CD del tiro salvezza sull'incantesimo, quando è richiesto un tiro salvezza). Una volta lanciato l'incantesimo di una perla magica, quella perla non può più essere usata fino all'alba successiva.\n\n| d20 | Perla... | Incantesimo |\n|---|---|---|\n| 01 | del camminare nel vento | Camminare nel vento |\n| 02–05 | del favore | Ristorare superiore |\n| 06 | dell'evocazione | Alleato planare |\n| 07–12 | della benedizione | Benedizione |\n| 13–18 | della guarigione | Cura ferite (2° livello) o ristorare inferiore |\n| 19–20 | della punizione | Punizione marchiante |", "Collana del rosario"),
			("Necklace of Prayer Beads", "Wondrous item, rare (requires attunement by a cleric, druid, or paladin)",
			"This necklace has 1d4 + 2 magic beads made from aquamarine, black pearl, or topaz. It also has many nonmagical beads made from stones such as amber, bloodstone, citrine, coral, jade, pearl, or quartz. If a magic bead is removed from the necklace, that bead loses its magic.\n\nSix types of magic beads exist. The GM decides the type of each bead on the necklace or determines it randomly. A necklace can have more than one bead of the same type. To use one, you must be wearing the necklace. Each bead contains a spell that you can cast from it as a bonus action (using your spell save DC if a save is necessary). Once a magic bead's spell is cast, that bead can't be used again until the next dawn.\n\n| d20 | Bead of... | Spell |\n|---|---|---|\n| 1-6 | Blessing | Bless |\n| 7-12 | Curing | Cure wounds (2nd level) or lesser restoration |\n| 13-16 | Favor | Greater restoration |\n| 17-18 | Smiting | Branding smite |\n| 19 | Summons | Planar ally |\n| 20 | Wind walking | Wind walk |", null));
	}
}
