using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Rod of the Pact Keeper, +1, +2, or +3 (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class RodOfThePactKeeper2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("rod-of-the-pact-keeper", null, 0, MagicItemType.Rod, null, true, ContentSource.RealmForge,
			null,
			("Verga del custode del patto +1, +2 o +3", "Verga, non comune (+1), rara (+2) o molto rara (+3) (richiede sintonia con un warlock)",
			"Mentre impugna questa verga, il personaggio ottiene un bonus ai tiri per colpire con gli incantesimi e alla CD dei tiri salvezza dei suoi incantesimi da warlock, determinato dalla rarità della verga. Inoltre può usare un'azione per recuperare uno slot incantesimo da warlock mentre la impugna; non può usare di nuovo questa proprietà finché non completa un riposo lungo."),
			("Rod of the Pact Keeper, +1, +2, or +3", "Rod, uncommon (+1), rare (+2), or very rare (+3) (requires attunement by a warlock)",
			"While holding this rod, you gain a bonus to spell attack rolls and to the saving throw DCs of your warlock spells, determined by the rod's rarity. In addition, you can use an action to regain one warlock spell slot while holding it; you can't use this property again until you finish a long rest.", null));
		yield return Item("rod-of-the-pact-keeper-1", "rod-of-the-pact-keeper", 1, MagicItemType.Rod, ItemRarity.Uncommon, true, ContentSource.RealmForge,
			Magic(Effect(MagicEffectKind.SpellAttack, 1), Effect(MagicEffectKind.SpellSaveDc, 1)),
			("Verga del custode del patto +1", "Verga, non comune (richiede sintonia con un warlock)",
			""),
			("Rod of the Pact Keeper, +1", "Rod, uncommon (requires attunement by a warlock)",
			"", null));
		yield return Item("rod-of-the-pact-keeper-2", "rod-of-the-pact-keeper", 2, MagicItemType.Rod, ItemRarity.Rare, true, ContentSource.RealmForge,
			Magic(Effect(MagicEffectKind.SpellAttack, 2), Effect(MagicEffectKind.SpellSaveDc, 2)),
			("Verga del custode del patto +2", "Verga, rara (richiede sintonia con un warlock)",
			""),
			("Rod of the Pact Keeper, +2", "Rod, rare (requires attunement by a warlock)",
			"", null));
		yield return Item("rod-of-the-pact-keeper-3", "rod-of-the-pact-keeper", 3, MagicItemType.Rod, ItemRarity.VeryRare, true, ContentSource.RealmForge,
			Magic(Effect(MagicEffectKind.SpellAttack, 3), Effect(MagicEffectKind.SpellSaveDc, 3)),
			("Verga del custode del patto +3", "Verga, molto rara (richiede sintonia con un warlock)",
			""),
			("Rod of the Pact Keeper, +3", "Rod, very rare (requires attunement by a warlock)",
			"", null));
	}
}
