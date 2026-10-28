using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Rope of Entanglement (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RopeOfEntanglement2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("rope-of-entanglement", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Corda intralciante", "Oggetto meraviglioso, raro",
			"Questa corda è lunga 9 metri e pesa 1,5 kg. Se il personaggio ne impugna un'estremità e usa un'azione per pronunciare la parola d'ordine, l'altra estremità guizza in avanti per intralciare una creatura che il personaggio è in grado di vedere situata entro 6 metri da lui. Il bersaglio deve superare un tiro salvezza su Destrezza con CD 15, altrimenti viene trattenuto.\n\nIl personaggio può liberare la creatura usando un'azione bonus per pronunciare una seconda parola d'ordine. Un bersaglio trattenuto dalla corda può usare un'azione per effettuare una prova di Forza o di Destrezza (a sua scelta) con CD 15. In caso di successo, la creatura non è più trattenuta dalla corda.\n\nLa corda possiede CA 20 e 20 punti ferita. Recupera 1 punto ferita ogni 5 minuti, purché le rimanga almeno 1 punto ferita. Se la corda scende a 0 punti ferita, viene distrutta."),
			("Rope of Entanglement", "Wondrous item, rare",
			"This rope is 30 feet long and weighs 3 pounds. If you hold one end of the rope and use an action to speak its command word, the other end darts forward to entangle a creature you can see within 20 feet of you. The target must succeed on a DC 15 Dexterity saving throw or become restrained.\n\nYou can release the creature by using a bonus action to speak a second command word. A target restrained by the rope can use an action to make a DC 15 Strength or Dexterity check (target's choice). On a success, the creature is no longer restrained by the rope.\n\nThe rope has AC 20 and 20 hit points. It regains 1 hit point every 5 minutes as long as it has at least 1 hit point. If the rope drops to 0 hit points, it is destroyed.", null));
	}
}
