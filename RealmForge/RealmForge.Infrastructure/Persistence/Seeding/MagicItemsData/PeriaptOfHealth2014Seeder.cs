using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Periapt of Health (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PeriaptOfHealth2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("periapt-of-health", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Talismano della salute", "Oggetto meraviglioso, non comune",
			"Finché il personaggio indossa questo pendente, è immune a ogni forma di malattia. Se era già infetto prima di indossarlo, gli effetti della malattia sono soppressi fintantoché il personaggio lo indossa."),
			("Periapt of Health", "Wondrous item, uncommon",
			"You are immune to contracting any disease while you wear this pendant. If you are already infected with a disease, the effects of the disease are suppressed you while you wear the pendant.", null));
	}
}
