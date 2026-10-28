using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Cloak of the Manta Ray (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CloakOfTheMantaRay2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("cloak-of-the-manta-ray", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Mantello della manta", "Oggetto meraviglioso, non comune",
			"Il personaggio che indossa questo mantello con il cappuccio tirato sulla testa può respirare sott'acqua e ottiene una velocità di nuotare pari a 18 metri. Per sollevare o abbassare il cappuccio è richiesta un'azione."),
			("Cloak of the Manta Ray", "Wondrous item, uncommon",
			"While wearing this cloak with its hood up, you can breathe underwater, and you have a swimming speed of 60 feet. Pulling the hood up or down requires an action.", null));
	}
}
