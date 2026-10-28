using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Sentinel Shield (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class SentinelShield2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("sentinel-shield", null, 0, MagicItemType.Armor, ItemRarity.Uncommon, false, ContentSource.RealmForge,
			null,
			("Scudo sentinella", "Armatura (scudo), non comune",
			"Mentre impugna questo scudo, decorato con il simbolo di un occhio, il personaggio dispone di vantaggio ai tiri di iniziativa e alle prove di Saggezza (Percezione).", null),
			("Sentinel Shield", "Armor (shield), uncommon",
			"While holding this shield, which bears the symbol of an eye, you have advantage on initiative rolls and Wisdom (Perception) checks.", null));
	}
}
