using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Dust of Sneezing and Choking (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DustOfSneezingAndChoking2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("dust-of-sneezing-and-choking", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Polvere dello starnuto e del soffocamento", "Oggetto meraviglioso, non comune",
			"Questa polvere sembra sabbia molto sottile ed è contenuta in un piccolo contenitore. Ha lo stesso aspetto della *polvere della sparizione* e un incantesimo *identificare* la indica come tale. Nel contenitore si trova polvere a sufficienza per un singolo uso.\n\nQuando il personaggio usa un'azione per gettare in aria una manciata di polvere, lui e ogni creatura che necessita di respirare situata entro 9 metri da lui devono superare un tiro salvezza su Costituzione con CD 15, altrimenti entrambi non riescono più a respirare e iniziano a starnutire in modo incontrollato. Le creature influenzate in questo modo diventano incapacitate e soffocano. Finché una creatura resta cosciente, può ripetere il tiro salvezza alla fine di ogni suo turno, ponendo fine all'effetto su di lei in caso di successo. Tale effetto può terminare anche grazie all'incantesimo *ristorare inferiore.*", null),
			("Dust of Sneezing and Choking", "Wondrous item, uncommon",
			"Found in a small container, this powder resembles very fine sand. It appears to be dust of disappearance, and an identify spell reveals it to be such. There is enough of it for one use.\n\nWhen you use an action to throw a handful of the dust into the air, you and each creature that needs to breathe within 30 feet of you must succeed on a DC 15 Constitution saving throw or become unable to breathe, while sneezing uncontrollably. A creature affected in this way is incapacitated and suffocating. As long as it is conscious, a creature can repeat the saving throw at the end of each of its turns, ending the effect on it on a success. The lesser restoration spell can also end the effect on a creature.", null));
	}
}
