using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Armor, +1, +2, or +3 (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class Armor2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("armor", null, 0, MagicItemType.Armor, null, false, ContentSource.Srd51,
			null,
			("Armatura +1, +2 o +3", "Armatura (leggera, media o pesante), rara (+1), molto rara (+2) o leggendaria (+3)",
			"Il personaggio che indossa quest'armatura ottiene un bonus alla CA determinato dalla sua rarità.", null),
			("Armor, +1, +2, or +3", "Armor (light, medium, or heavy), rare (+1), very rare (+2), or legendary (+3)",
			"You have a bonus to AC while wearing this armor. The bonus is determined by its rarity.", null));
		yield return Item("armor-1", "armor", 1, MagicItemType.Armor, ItemRarity.Rare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1)),
			("Armatura +1", "Armatura (leggera, rara",
			"", null),
			("Armor, +1", "Armor (light, medium, or heavy), rare",
			"", null));
		yield return Item("armor-2", "armor", 2, MagicItemType.Armor, ItemRarity.VeryRare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 2)),
			("Armatura +2", "Armatura (leggera, molto rara",
			"", null),
			("Armor, +2", "Armor (light, medium, or heavy), very rare",
			"", null));
		yield return Item("armor-3", "armor", 3, MagicItemType.Armor, ItemRarity.Legendary, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 3)),
			("Armatura +3", "Armatura (leggera, leggendaria",
			"", null),
			("Armor, +3", "Armor (light, medium, or heavy), legendary",
			"", null));
	}
}
