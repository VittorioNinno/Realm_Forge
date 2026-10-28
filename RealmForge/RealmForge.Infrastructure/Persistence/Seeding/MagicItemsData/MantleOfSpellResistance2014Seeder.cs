using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Mantle of Spell Resistance (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class MantleOfSpellResistance2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("mantle-of-spell-resistance", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Mantello della resistenza agli incantesimi", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Finché il personaggio indossa questo mantello, dispone di vantaggio ai tiri salvezza contro gli incantesimi."),
			("Mantle of Spell Resistance", "Wondrous item, rare (requires attunement)",
			"You have advantage on saving throws against spells while you wear this cloak.", null));
	}
}
