using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Cloak of Protection (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CloakOfProtection2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("cloak-of-protection", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1), Effect(MagicEffectKind.SavingThrows, 1)),
			("Mantello della protezione", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Il personaggio che indossa questo mantello riceve un bonus di +1 alla CA e ai tiri salvezza."),
			("Cloak of Protection", "Wondrous item, uncommon (requires attunement)",
			"You gain a +1 bonus to AC and saving throws while you wear this cloak.", null));
	}
}
