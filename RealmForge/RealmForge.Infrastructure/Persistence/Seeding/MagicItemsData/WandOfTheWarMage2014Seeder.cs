using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Wand of the War Mage, +1, +2, or +3 (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class WandOfTheWarMage2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("wand-of-the-war-mage", null, 0, MagicItemType.Wand, null, true, ContentSource.Srd51,
			null,
			("Bacchetta del mago da guerra +1, +2 o +3", "Bacchetta, non comune (+1), rara (+2) o molto rara (+3) (richiede sintonia con un incantatore)",
			"Mentre il personaggio impugna questa bacchetta, riceve un bonus ai tiri per colpire con incantesimo determinato dalla rarità della bacchetta. Il personaggio può inoltre ignorare mezza copertura quando effettua un attacco con incantesimo.", null),
			("Wand of the War Mage, +1, +2, or +3", "Wand, uncommon (+1), rare (+2), or very rare (+3) (requires attunement by a spellcaster)",
			"While holding this wand, you gain a bonus to spell attack rolls determined by the wand's rarity. In addition, you ignore half cover when making a spell attack.", null));
		yield return Item("wand-of-the-war-mage-1", "wand-of-the-war-mage", 1, MagicItemType.Wand, ItemRarity.Uncommon, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.SpellAttack, 1)),
			("Bacchetta del mago da guerra +1", "Bacchetta, non comune (richiede sintonia con un incantatore)",
			"", null),
			("Wand of the War Mage, +1", "Wand, uncommon (requires attunement by a spellcaster)",
			"", null));
		yield return Item("wand-of-the-war-mage-2", "wand-of-the-war-mage", 2, MagicItemType.Wand, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.SpellAttack, 2)),
			("Bacchetta del mago da guerra +2", "Bacchetta, rara (richiede sintonia con un incantatore)",
			"", null),
			("Wand of the War Mage, +2", "Wand, rare (requires attunement by a spellcaster)",
			"", null));
		yield return Item("wand-of-the-war-mage-3", "wand-of-the-war-mage", 3, MagicItemType.Wand, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.SpellAttack, 3)),
			("Bacchetta del mago da guerra +3", "Bacchetta, molto rara (richiede sintonia con un incantatore)",
			"", null),
			("Wand of the War Mage, +3", "Wand, very rare (requires attunement by a spellcaster)",
			"", null));
	}
}
