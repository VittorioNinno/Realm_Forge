using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Iron Bands of Binding (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class IronBandsOfBinding2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("iron-bands-of-binding", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Fasce metalliche del legame", "Oggetto meraviglioso, raro",
			"Questa sfera di metallo arrugginito ha un diametro di 7,5 cm e pesa 0,5 kg. Il personaggio può usare un'azione per pronunciare la parola d'ordine della sfera e lanciarla contro una creatura di taglia Enorme o inferiore che è in grado di vedere situata entro 18 metri da lui. Mentre sfreccia in aria, la sfera si apre rivelando un groviglio di fasce metalliche.\n\nIl personaggio effettua un tiro per colpire a distanza con un bonus di attacco pari al suo modificatore di Destrezza più il suo bonus di competenza. Se il colpo va a segno, il bersaglio è trattenuto finché il personaggio non usa un'azione bonus per pronunciare di nuovo la parola d'ordine e liberarlo. Se lo fa, o se l'attacco manca il bersaglio, le fasce si ritraggono e tornano a formare la sfera originale.\n\nUna creatura, anche quella trattenuta, può usare un'azione per effettuare una prova di Forza con CD 20 per spezzare le fasce metalliche. In caso di successo, l'oggetto è distrutto e la creatura trattenuta viene liberata. Se la prova fallisce, ogni ulteriore tentativo effettuato dalla stessa creatura fallisce automaticamente finché non sono trascorse 24 ore.\n\nUna volta usate, le fasce non possono essere riutilizzate fino all'alba successiva.", "Fasce metalliche di Bilarro"),
			("Iron Bands of Binding", "Wondrous item, rare",
			"This rusty iron sphere measures 3 inches in diameter and weighs 1 pound. You can use an action to speak the command word and throw the sphere at a Huge or smaller creature you can see within 60 feet of you. As the sphere moves through the air, it opens into a tangle of metal bands.\n\nMake a ranged attack roll with an attack bonus equal to your Dexterity modifier plus your proficiency bonus. On a hit, the target is restrained until you take a bonus action to speak the command word again to release it. Doing so, or missing with the attack, causes the bands to contract and become a sphere once more.\n\nA creature, including the one restrained, can use an action to make a DC 20 Strength check to break the iron bands. On a success, the item is destroyed, and the restrained creature is freed. If the check fails, any further attempts made by that creature automatically fail until 24 hours have elapsed.\n\nOnce the bands are used, they can't be used again until the next dawn.", "Iron Bands of Bilarro"));
	}
}
