using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Growth (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfGrowth2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-growth", null, 0, MagicItemType.Potion, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Pozione di crescita", "Pozione, non comune",
			"Quando il personaggio beve questa pozione, ottiene l'effetto \"ingrandire\" dell'incantesimo *ingrandire/ridurre,* per 1d4 ore (non è richiesta la concentrazione). All'interno della pozione è visibile un piccolo nucleo rosso che si espande progressivamente fino a tingere tutto il liquido trasparente intorno a esso per poi contrarsi fino a diventare un granello minuscolo. Agitare la bottiglia non interrompe il processo."),
			("Potion of Growth", "Potion, uncommon",
			"When you drink this potion, you gain the \"enlarge\" effect of the enlarge/reduce spell for 1d4 hours (no concentration required). The red in the potion's liquid continuously expands from a tiny bead to color the clear liquid around it and then contracts. Shaking the bottle fails to interrupt this process.", null));
	}
}
