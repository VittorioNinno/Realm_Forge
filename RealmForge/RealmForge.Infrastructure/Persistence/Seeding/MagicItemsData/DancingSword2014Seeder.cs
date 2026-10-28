using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Dancing Sword (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DancingSword2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("dancing-sword", null, 0, MagicItemType.Weapon, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Spada danzante", "Arma (qualsiasi spada), molto rara (richiede sintonia)",
			"Il personaggio può usare un'azione bonus per lanciare in aria questa spada magica e pronunciare la sua parola d'ordine. Quando lo fa, la spada inizia a fluttuare, vola fino a una distanza di 9 metri e attacca una creatura a scelta del personaggio situata entro 1,5 metri da sé. La spada usa il tiro per colpire e il modificatore al punteggio di caratteristica del personaggio per i tiri per i danni.\n\nFinché la spada fluttua, il personaggio può usare un'azione bonus per farla volare in un altro punto entro 9 metri da lui. Come parte della stessa azione bonus, il personaggio può far sì che la spada attacchi una creatura entro 1,5 metri da essa.\n\nDopo avere effettuato il quarto attacco, la spada fluttuante si muove in volo fino a 9 metri e cerca di tornare in mano al personaggio. Se quest'ultimo non ha mani libere, la spada cade a terra ai suoi piedi. Se non esiste un percorso sgombro fino al personaggio, la spada si avvicina a lui quanto più possibile e poi cade a terra. Smette di fluttuare anche se il personaggio la prende in mano o se si allontana più di 9 metri da essa.", null),
			("Dancing Sword", "Weapon (any sword), very rare (requires attunement)",
			"You can use a bonus action to toss this magic sword into the air and speak the command word. When you do so, the sword begins to hover, flies up to 30 feet, and attacks one creature of your choice within 5 feet of it. The sword uses your attack roll and ability score modifier to damage rolls.\n\nWhile the sword hovers, you can use a bonus action to cause it to fly up to 30 feet to another spot within 30 feet of you. As part of the same bonus action, you can cause the sword to attack one creature within 5 feet of it.\n\nAfter the hovering sword attacks for the fourth time, it flies up to 30 feet and tries to return to your hand. If you have no hand free, it falls to the ground at your feet. If the sword has no unobstructed path to you, it moves as close to you as it can and then falls to the ground. It also ceases to hover if you grasp it or move more than 30 feet away from it.", null));
	}
}
