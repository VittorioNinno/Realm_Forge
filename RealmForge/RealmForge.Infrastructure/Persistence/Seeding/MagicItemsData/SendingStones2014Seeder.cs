using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Sending Stones (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class SendingStones2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("sending-stones", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.RealmForge,
			null,
			("Pietre dei messaggi", "Oggetto meraviglioso, non comune",
			"Queste pietre levigate si trovano sempre in coppia, intagliate in modo che sia facile riconoscerne la gemella. Toccando una pietra, il personaggio può usare un'azione per lanciare con essa l'incantesimo *inviare*, che ha come bersaglio chi porta l'altra pietra; se nessuno la porta, il personaggio lo sa non appena usa la pietra e l'incantesimo non viene lanciato. Dopo che *inviare* è stato lanciato con le pietre, non possono essere usate di nuovo fino all'alba successiva. Se una delle due pietre viene distrutta, l'altra perde la sua magia."),
			("Sending Stones", "Wondrous item, uncommon",
			"These smooth stones always come in pairs, carved so that each one's twin is easy to recognize. While touching one stone, you can use an action to cast the *sending* spell from it, targeting whoever carries the other stone; if nobody carries it, you know as soon as you use the stone and the spell isn't cast. Once *sending* has been cast through the stones, they can't be used again until the next dawn. If one of the pair is destroyed, the other loses its magic.", null));
	}
}
