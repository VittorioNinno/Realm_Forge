using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ring of Mind Shielding (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RingOfMindShielding2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ring-of-mind-shielding", null, 0, MagicItemType.Ring, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Anello di scudo mentale", "Anello, non comune (richiede sintonia)",
			"Mentre il personaggio indossa questo anello, è immune alla magia che permette alle altre creature di leggere i suoi pensieri, scoprire se sta mentendo, conoscere il suo allineamento o determinare il suo tipo di creatura. Le creature possono comunicare telepaticamente con il personaggio solamente se egli lo consente.\n\nIl personaggio può usare un'azione per fare in modo che l'anello diventi invisibile finché non usa un'altra azione per farlo tornare visibile o finché non muore.\n\nSe il personaggio muore mentre indossa l'anello, la sua anima entra dentro quest'ultimo, a meno che esso non ospiti già un'altra anima. Il personaggio può rimanere nell'anello o raggiungere l'aldilà. Finché l'anima del personaggio si trova nell'anello, può comunicare telepaticamente con qualsiasi creatura che lo indossi. La creatura che indossa l'anello non può impedire questa comunicazione telepatica."),
			("Ring of Mind Shielding", "Ring, uncommon (requires attunement)",
			"While wearing this ring, you are immune to magic that allows other creatures to read your thoughts, determine whether you are lying, know your alignment, or know your creature type. Creatures can telepathically communicate with you only if you allow it.\n\nYou can use an action to cause the ring to become invisible until you use another action to make it visible, until you remove the ring, or until you die.\n\nIf you die while wearing the ring, your soul enters it, unless it already houses a soul. You can remain in the ring or depart for the afterlife. As long as your soul is in the ring, you can telepathically communicate with any creature wearing it. A wearer can't prevent this telepathic communication.", null));
	}
}
