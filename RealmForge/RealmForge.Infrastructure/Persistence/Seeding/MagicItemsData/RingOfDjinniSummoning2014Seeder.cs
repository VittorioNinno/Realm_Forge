using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Djinni Summoning (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfDjinniSummoning2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-djinni-summoning", null, 0, MagicItemType.Ring, ItemRarity.Legendary, true, ContentSource.Srd51,
			null,
			("Anello di evocazione del djinni", "Anello, leggendario (richiede sintonia)",
			"Mentre il personaggio indossa questo anello, può usare un'azione per pronunciarne la parola d'ordine ed evocare un particolare djinni dal Piano Elementale dell'Aria. Il djinni compare in uno spazio libero a scelta del personaggio entro 36 metri da lui e permane finché il personaggio mantiene la concentrazione (come se si concentrasse su un incantesimo), fino a un massimo di 1 ora o finché il djinni non scende a 0 punti ferita; dopodiché ritorna al suo piano di origine.\n\nDurante l'evocazione il djinni è amichevole nei confronti del personaggio e dei suoi compagni. Obbedisce a ogni comando impartito dal personaggio, a prescindere dal linguaggio che quest'ultimo usa. Se il personaggio non gli dà comandi, il djinni si difende dagli aggressori, ma non esegue altre azioni.\n\nDopo che il djinni ha fatto ritorno al suo piano d'origine, non può essere evocato di nuovo per 24 ore e, se muore, l'anello diventa non magico."),
			("Ring of Djinni Summoning", "Ring, legendary (requires attunement)",
			"While wearing this ring, you can speak its command word as an action to summon a particular djinni from the Elemental Plane of Air. The djinni appears in an unoccupied space you choose within 120 feet of you. It remains as long as you concentrate (as if concentrating on a spell), to a maximum of 1 hour, or until it drops to 0 hit points. It then returns to its home plane.\n\nWhile summoned, the djinni is friendly to you and your companions. It obeys any commands you give it, no matter what language you use. If you fail to command it, the djinni defends itself against attackers but takes no other actions.\n\nAfter the djinni departs, it can't be summoned again for 24 hours, and the ring becomes nonmagical if the djinni dies.", null));
	}
}
