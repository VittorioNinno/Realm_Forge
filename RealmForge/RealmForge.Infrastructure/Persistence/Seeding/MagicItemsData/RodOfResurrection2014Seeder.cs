using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Rod of Resurrection (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class RodOfResurrection2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("rod-of-resurrection", null, 0, MagicItemType.Rod, ItemRarity.Legendary, true, ContentSource.RealmForge,
			Charges(5, ItemRecharge.LongRest, "1d1"),
			("Verga della resurrezione", "Verga, leggendaria (richiede sintonia con un chierico, un druido o un paladino)",
			"La verga ha 5 cariche. Mentre la impugna, il personaggio può usare un'azione per lanciare con essa *guarigione* (1 carica) o *resurrezione* (5 cariche). All'alba di ogni giorno la verga recupera 1 carica consumata. Se arriva a 0 cariche, il personaggio tira un d20: con un 1 la verga svanisce in un lampo di luce radiosa.", null),
			("Rod of Resurrection", "Rod, legendary (requires attunement by a cleric, druid, or paladin)",
			"The rod has 5 charges. While holding it, you can use an action to cast *heal* (1 charge) or *resurrection* (5 charges) from it. It regains 1 expended charge daily at dawn. If it drops to 0 charges, roll a d20: on a 1, the rod vanishes in a flash of radiant light.", null));
	}
}
