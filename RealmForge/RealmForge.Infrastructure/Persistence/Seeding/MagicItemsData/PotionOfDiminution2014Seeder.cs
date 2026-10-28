using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Diminution (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PotionOfDiminution2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-diminution", null, 0, MagicItemType.Potion, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Pozione di diminuzione", "Pozione, rara",
			"Quando il personaggio beve questa pozione, ottiene l'effetto \"ridurre\" dell'incantesimo *ingrandire/ridurre,* per 1d4 ore (non è richiesta la concentrazione). All'interno della pozione è visibile un nucleo rosso che si contrae progressivamente fino a diventare un granello minuscolo per poi esplodere e tingere tutto il liquido trasparente intorno a esso. Agitare la bottiglia non interrompe il processo."),
			("Potion of Diminution", "Potion, rare",
			"When you drink this potion, you gain the \"reduce\" effect of the enlarge/reduce spell for 1d4 hours (no concentration required). The red in the potion's liquid continuously contracts to a tiny bead and then expands to color the clear liquid around it. Shaking the bottle fails to interrupt this process.", null));
	}
}
