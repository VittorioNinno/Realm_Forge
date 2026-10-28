using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Stone of Good Luck (Luckstone) (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StoneOfGoodLuckLuckstone2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("stone-of-good-luck-luckstone", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AbilityChecks, 1), Effect(MagicEffectKind.SavingThrows, 1)),
			("Pietra della buona fortuna (pietrafortuna)", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Mentre il personaggio porta quest'agata levigata sulla sua persona, ottiene un bonus di +1 alle prove di caratteristica e ai tiri salvezza.", null),
			("Stone of Good Luck (Luckstone)", "Wondrous item, uncommon (requires attunement)",
			"While this polished agate is on your person, you gain a +1 bonus to ability checks and saving throws.", null));
	}
}
