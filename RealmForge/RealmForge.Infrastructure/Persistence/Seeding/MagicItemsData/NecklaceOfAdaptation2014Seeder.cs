using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Necklace of Adaptation (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class NecklaceOfAdaptation2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("necklace-of-adaptation", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Collana dell'adattamento", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Mentre il personaggio indossa questa collana, può respirare normalmente in qualsiasi ambiente e dispone di vantaggio ai tiri salvezza contro gas e vapori nocivi (come gli effetti di *nube maleodorante* e *nube mortale,* i veleni inalati e i soffi di alcuni draghi).", null),
			("Necklace of Adaptation", "Wondrous item, uncommon (requires attunement)",
			"While wearing this necklace, you can breathe normally in any environment, and you have advantage on saving throws made against harmful gases and vapors (such as cloudkill and stinking cloud effects, inhaled poisons, and the breath weapons of some dragons).", null));
	}
}
