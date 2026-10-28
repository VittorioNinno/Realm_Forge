using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Periapt of Wound Closure (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PeriaptOfWoundClosure2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("periapt-of-wound-closure", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Talismano della rimarginazione", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Finché il personaggio indossa questo pendente, si stabilizza automaticamente ogni volta che sta per morire all'inizio del suo turno. Inoltre, ogni volta che tira un Dado Vita per recuperare punti ferita, raddoppia il numero di punti ferita ripristinati."),
			("Periapt of Wound Closure", "Wondrous item, uncommon (requires attunement)",
			"While you wear this pendant, you stabilize whenever you are dying at the start of your turn. In addition, whenever you roll a Hit Die to regain hit points, double the number of hit points it restores.", null));
	}
}
