using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Dust of Disappearance (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DustOfDisappearance2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("dust-of-disappearance", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Polvere dell'invisibilità", "Oggetto meraviglioso, non comune",
			"Questa polvere sembra sabbia molto sottile ed è contenuta in un piccolo sacchetto. Ce n'è abbastanza per un singolo uso da parte di un personaggio: quando usa un'azione per lanciare la polvere in aria, il personaggio e ogni creatura e oggetto nel raggio di 3 metri da lui diventano invisibili per 2d4 minuti. La durata è la stessa per tutte le creature e gli oggetti influenzati e la polvere viene consumata quando la magia ha effetto. Se una creatura influenzata dalla polvere attacca o lancia un incantesimo, smette di essere invisibile.", "Polvere della sparizione"),
			("Dust of Disappearance", "Wondrous item, uncommon",
			"Found in a small packet, this powder resembles very fine sand. There is enough of it for one use. When you use an action to throw the dust into the air, you and each creature and object within 10 feet of you become invisible for 2d4 minutes. The duration is the same for all subjects, and the dust is consumed when its magic takes effect. If a creature affected by the dust attacks or casts a spell, the invisibility ends for that creature.", null));
	}
}
