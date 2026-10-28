using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Gem of Brightness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class GemOfBrightness2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("gem-of-brightness", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			Charges(50, ItemRecharge.None, null),
			("Gemma della luminosità", "Oggetto meraviglioso, non comune",
			"Questo prisma possiede 50 cariche. Quando il personaggio lo tiene in mano, può usare un'azione per pronunciare una delle sue tre parole d'ordine per generare uno degli effetti seguenti:\n\n- La prima parola d'ordine fa sì che la gemma proietti luce intensa in un raggio di 9 metri e luce fioca per altri 9 metri. Questo effetto non fa consumare cariche e dura finché il personaggio non usa un'azione bonus per ripetere la parola d'ordine o finché non usa un'altra funzione della gemma.\n\n- La seconda parola d'ordine consuma 1 carica della gemma e fa sì che quest'ultima proietti un raggio di luce scintillante contro una creatura situata entro 18 metri dal personaggio e che egli è in grado di vedere. La creatura deve superare un tiro salvezza su Costituzione con CD 15, altrimenti è accecata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto per lei svanisce.\n\n- La terza parola d'ordine consuma 5 cariche e fa sì che si sprigioni una luce accecante in un cono di 9 metri originato dalla gemma. Ogni creatura situata nel cono deve effettuare un tiro salvezza come se fosse stata colpita dal raggio di luce creato dalla seconda parola d'ordine.\n\nQuando tutte le cariche sono state utilizzate, la gemma diventa un gioiello non magico del valore di 50 mo."),
			("Gem of Brightness", "Wondrous item, uncommon",
			"This prism has 50 charges. While you are holding it, you can use an action to speak one of three command words to cause one of the following effects:\n\nThe first command word causes the gem to shed bright light in a 30-foot radius and dim light for an additional 30 feet. This effect doesn't expend a charge. It lasts until you use a bonus action to repeat the command word or until you use another function of the gem.\n\nThe second command word expends 1 charge and causes the gem to fire a brilliant beam of light at one creature you can see within 60 feet of you. The creature must succeed on a DC 15 Constitution saving throw or become blinded for 1 minute. The creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.\n\nThe third command word expends 5 charges and causes the gem to flare with blinding light in a 30 foot cone originating from it. Each creature in the cone must make a saving throw as if struck by the beam created with the second command word.\n\nWhen all of the gem's charges are expended, the gem becomes a nonmagical jewel worth 50 gp.", null));
	}
}
