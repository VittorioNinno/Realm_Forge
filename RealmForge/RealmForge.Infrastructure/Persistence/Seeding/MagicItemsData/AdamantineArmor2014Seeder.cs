using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Adamantine Armor (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class AdamantineArmor2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("adamantine-armor", null, 0, MagicItemType.Armor, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Armatura adamantina", "Armatura (media o pesante, ma non di pelle), non comune",
			"Quest'armatura include dei rinforzi di adamantio, uno dei materiali più duri in assoluto. Tutti i colpi critici che un personaggio subisce mentre indossa questa armatura diventano colpi normali.", null),
			("Adamantine Armor", "Armor (medium or heavy, but not hide), uncommon",
			"This suit of armor is reinforced with adamantine, one of the hardest substances in existence. While you're wearing it, any critical hit against you becomes a normal hit.", null));
	}
}
