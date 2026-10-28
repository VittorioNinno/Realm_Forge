using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Gloves of Swimming and Climbing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class GlovesOfSwimmingAndClimbing2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("gloves-of-swimming-and-climbing", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Guanti del nuotare e scalare", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Finché il personaggio indossa questi guanti, scalare e nuotare non gli costano alcun movimento extra; inoltre, ottiene un bonus di +5 alle prove di Forza (Atletica) effettuate per scalare o nuotare.", null),
			("Gloves of Swimming and Climbing", "Wondrous item, uncommon (requires attunement)",
			"While wearing these gloves, climbing and swimming don't cost you extra movement, and you gain a +5 bonus to Strength (Athletics) checks made to climb or swim.", null));
	}
}
