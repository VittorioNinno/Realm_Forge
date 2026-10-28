using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Dimensional Shackles (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class DimensionalShackles2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("dimensional-shackles", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Manette dimensionali", "Oggetto meraviglioso, raro",
			"Il personaggio può usare un'azione per mettere queste manette a una creatura incapacitata. Le manette si adattano alle creature di taglia Piccola, Media o Grande. Oltre a funzionare come manette comuni, impediscono alla creatura ammanettata di usare qualsiasi metodo di movimento extradimensionale, inclusi il teletrasporto e il viaggio su un diverso piano di esistenza. Non le impediscono però di attraversare un portale interdimensionale.\n\nIl personaggio e qualsiasi creatura da lui designata al momento della chiusura delle manette possono usare un'azione per rimuoverle. Una volta ogni 30 giorni, la creatura ammanettata può effettuare una prova di Forza (Atletica) con CD 30. In caso di successo, la creatura si libera e distrugge le manette."),
			("Dimensional Shackles", "Wondrous item, rare",
			"You can use an action to place these shackles on an incapacitated creature. The shackles adjust to fit a creature of Small to Large size. In addition to serving as mundane manacles, the shackles prevent a creature bound by them from using any method of extradimensional movement, including teleportation or travel to a different plane of existence. They don't prevent the creature from passing through an interdimensional portal.\n\nYou and any creature you designate when you use the shackles can use an action to remove them. Once every 30 days, the bound creature can make a DC 30 Strength (Athletics) check. On a success, the creature breaks free and destroys the shackles.", null));
	}
}
