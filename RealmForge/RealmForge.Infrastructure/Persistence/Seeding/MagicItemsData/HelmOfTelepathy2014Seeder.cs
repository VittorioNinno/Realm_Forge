using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Helm of Telepathy (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class HelmOfTelepathy2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("helm-of-telepathy", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Elmo della telepatia", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Mentre il personaggio indossa questo elmo, può usare un'azione per lanciare l'incantesimo *individuazione dei pensieri* (CD del tiro salvezza 13). Finché mantiene la concentrazione sull'incantesimo, può usare un'azione bonus per inviare un messaggio telepatico a una creatura su cui è concentrato e quest'ultima può usare un'azione bonus per rispondere.\n\nFintantoché il personaggio mantiene la concentrazione su una creatura tramite *individuazione dei pensieri,* può usare un'azione per lanciare l'incantesimo *suggestione* (CD del tiro salvezza 13) su di essa. Una volta usata, la proprietà di *suggestione* non è riutilizzabile fino all'alba successiva.", null),
			("Helm of Telepathy", "Wondrous item, uncommon (requires attunement)",
			"While wearing this helm, you can use an action to cast the detect thoughts spell (save DC 13) from it. As long as you maintain concentration on the spell, you can use a bonus action to send a telepathic message to a creature you are focused on. It can reply-using a bonus action to do so-while your focus on it continues.\n\nWhile focusing on a creature with detect thoughts, you can use an action to cast the suggestion spell (save DC 13) from the helm on that creature. Once used, the suggestion property can't be used again until the next dawn.", null));
	}
}
