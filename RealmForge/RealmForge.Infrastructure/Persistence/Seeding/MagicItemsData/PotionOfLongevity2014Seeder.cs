using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Longevity (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class PotionOfLongevity2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-longevity", null, 0, MagicItemType.Potion, ItemRarity.VeryRare, false, ContentSource.RealmForge,
			null,
			("Pozione di longevità", "Pozione, molto rara",
			"Chi beve questa pozione ringiovanisce fisicamente di 1d6 + 6 anni, fino a un minimo di 13 anni. Ogni volta che in seguito beve un'altra pozione di longevità, c'è una probabilità cumulativa del 10 percento che invece invecchi di 1d6 + 6 anni. Nel liquido ambrato galleggiano una coda di scorpione, una zanna di vipera, un ragno morto e un minuscolo cuore che, contro ogni logica, batte ancora; tutto scompare quando la pozione viene aperta.", null),
			("Potion of Longevity", "Potion, very rare",
			"Drinking this potion makes you physically younger by 1d6 + 6 years, to a minimum of 13 years. Each time you later drink another potion of longevity, there is a cumulative 10 percent chance that you age by 1d6 + 6 years instead. A scorpion's tail, an adder's fang, a dead spider and a tiny heart that somehow still beats float in the amber liquid; they vanish when the potion is opened.", null));
	}
}
