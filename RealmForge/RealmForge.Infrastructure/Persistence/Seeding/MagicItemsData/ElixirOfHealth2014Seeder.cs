using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Elixir of Health (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class ElixirOfHealth2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("elixir-of-health", null, 0, MagicItemType.Potion, ItemRarity.Rare, false, ContentSource.RealmForge,
			null,
			("Elisir della salute", "Pozione, rara",
			"Chi beve questa pozione guarisce da qualsiasi malattia e si libera delle condizioni accecato, assordato, avvelenato e paralizzato. Il liquido, rosso e trasparente, è attraversato da minuscole bolle di luce."),
			("Elixir of Health", "Potion, rare",
			"Drinking this potion cures any disease affecting you and ends the blinded, deafened, paralyzed and poisoned conditions on you. The clear red liquid holds tiny bubbles of light.", null));
	}
}
