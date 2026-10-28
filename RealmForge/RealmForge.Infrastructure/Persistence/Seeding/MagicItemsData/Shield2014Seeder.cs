using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Shield, +1, +2, or +3 (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class Shield2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("shield", null, 0, MagicItemType.Armor, null, false, ContentSource.Srd51,
			null,
			("Scudo +1, +2 o +3", "Armatura (scudo), non comune (+1), rara (+2)",
			"*o molto rara (+3)* Mentre il personaggio impugna questo scudo, ottiene un bonus alla CA determinato dalla rarità dello scudo. Questo bonus è cumulativo al normale bonus alla CA dello scudo."),
			("Shield, +1, +2, or +3", "Armor (shield), uncommon (+1), rare (+2), or very rare (+3)",
			"While holding this shield, you have a bonus to AC determined by the shield's rarity. This bonus is in addition to the shield's normal bonus to AC.", null));
		yield return Item("shield-1", "shield", 1, MagicItemType.Armor, ItemRarity.Uncommon, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1)),
			("Scudo +1", "Armatura (scudo), non comune",
			""),
			("Shield, +1", "Armor (shield), uncommon",
			"", null));
		yield return Item("shield-2", "shield", 2, MagicItemType.Armor, ItemRarity.Rare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 2)),
			("Scudo +2", "Armatura (scudo), rara",
			""),
			("Shield, +2", "Armor (shield), rare",
			"", null));
		yield return Item("shield-3", "shield", 3, MagicItemType.Armor, ItemRarity.VeryRare, false, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 3)),
			("Scudo +3", "Armatura (scudo), molto rara",
			""),
			("Shield, +3", "Armor (shield), very rare",
			"", null));
	}
}
