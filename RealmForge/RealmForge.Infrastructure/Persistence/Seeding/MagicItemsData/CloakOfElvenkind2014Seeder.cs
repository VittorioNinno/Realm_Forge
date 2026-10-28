using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Cloak of Elvenkind (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CloakOfElvenkind2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("cloak-of-elvenkind", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Mantello elfico", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Quando il personaggio indossa questo mantello con il cappuccio tirato sulla testa, le prove di Saggezza (Percezione) effettuate per vederlo subiscono svantaggio; il personaggio dispone inoltre di vantaggio alle prove di Destrezza (Furtività) effettuate per nascondersi, in quanto il mantello cambia colore per mimetizzarsi con l'ambiente circostante. Per sollevare o abbassare il cappuccio è richiesta un'azione."),
			("Cloak of Elvenkind", "Wondrous item, uncommon (requires attunement)",
			"While you wear this cloak with its hood up, Wisdom (Perception) checks made to see you have disadvantage, and you have advantage on Dexterity (Stealth) checks made to hide, as the cloak's color shifts to camouflage you. Pulling the hood up or down requires an action.", null));
	}
}
