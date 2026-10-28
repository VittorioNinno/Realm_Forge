using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Mind Reading (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfMindReading2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-mind-reading", null, 0, MagicItemType.Potion, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pozione di lettura della mente", "Pozione, rara",
			"Quando il personaggio beve questa pozione, ottiene l'effetto dell'incantesimo *individuazione dei pensieri* (CD del tiro salvezza 13). Nel denso liquido violaceo della pozione fluttua una nuvola ovoidale di colore rosa.", null),
			("Potion of Mind Reading", "Potion, rare",
			"When you drink this potion, you gain the effect of the detect thoughts spell (save DC 13). The potion's dense, purple liquid has an ovoid cloud of pink floating in it.", null));
	}
}
