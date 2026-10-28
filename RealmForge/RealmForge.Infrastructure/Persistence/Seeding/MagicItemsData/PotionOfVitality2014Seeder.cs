using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Potion of Vitality (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class PotionOfVitality2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("potion-of-vitality", null, 0, MagicItemType.Potion, ItemRarity.VeryRare, false, ContentSource.RealmForge,
			null,
			("Pozione di vitalità", "Pozione, molto rara",
			"Chi beve questa pozione si libera di qualsiasi livello di indebolimento e guarisce da qualsiasi malattia o veleno. Per le 24 ore successive, ogni Dado Vita che spende gli fa recuperare il massimo dei punti ferita possibili. Il liquido cremisi pulsa di una luce fioca, come un battito cardiaco.", null),
			("Potion of Vitality", "Potion, very rare",
			"Drinking this potion removes all your exhaustion and cures any disease or poison affecting you. For the next 24 hours, every Hit Die you spend restores the maximum number of hit points. The crimson liquid pulses with a dim light, like a heartbeat.", null));
	}
}
