using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Winged Boots (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WingedBoots2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("winged-boots", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Stivali alati", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Quando il personaggio indossa questi stivali, ottiene una velocità di volare pari alla sua velocità base sul terreno. Può usare gli stivali per volare fino a un massimo di 4 ore consecutive o suddivise in voli più brevi della durata minima di 1 minuto. Se il personaggio è in volo quando la durata si esaurisce, scende a una velocità di 9 metri per round finché non atterra.\n\nGli stivali recuperano 2 ore di autonomia di volo per ogni 12 ore in cui non vengono utilizzati.", null),
			("Winged Boots", "Wondrous item, uncommon (requires attunement)",
			"While you wear these boots, you have a flying speed equal to your walking speed. You can use the boots to fly for up to 4 hours, all at once or in several shorter flights, each one using a minimum of 1 minute from the duration. If you are flying when the duration expires, you descend at a rate of 30 feet per round until you land.\n\nThe boots regain 2 hours of flying capability for every 12 hours they aren't in use.", null));
	}
}
