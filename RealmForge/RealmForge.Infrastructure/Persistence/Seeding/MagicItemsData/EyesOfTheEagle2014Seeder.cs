using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Eyes of the Eagle (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class EyesOfTheEagle2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("eyes-of-the-eagle", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Lenti dell'aquila", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Queste lenti di cristallo si adattano agli occhi di chi le indossa. Quando il personaggio le indossa, dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista. In condizioni di visibilità ottimale, può discernere i dettagli di creature e oggetti di almeno 60 cm di diametro anche da lunghissime distanze."),
			("Eyes of the Eagle", "Wondrous item, uncommon (requires attunement)",
			"These crystal lenses fit over the eyes. While wearing them, you have advantage on Wisdom (Perception) checks that rely on sight. In conditions of clear visibility, you can make out details of even extremely distant creatures and objects as small as 2 feet across.", null));
	}
}
