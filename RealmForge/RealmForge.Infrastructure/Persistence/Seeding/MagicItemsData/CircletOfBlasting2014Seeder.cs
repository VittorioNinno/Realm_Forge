using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Circlet of Blasting (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CircletOfBlasting2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("circlet-of-blasting", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Diadema incandescente", "Oggetto meraviglioso, non comune",
			"Il personaggio che indossa questo diadema può usare un'azione per lanciare l'incantesimo *raggio rovente.* I tiri per colpire effettuati per l'incantesimo ottengono un bonus di attacco di +5. Il diadema non può essere riutilizzato in questo modo fino all'alba successiva.", null),
			("Circlet of Blasting", "Wondrous item, uncommon",
			"While wearing this circlet, you can use an action to cast the scorching ray spell with it. When you make the spell's attacks, you do so with an attack bonus of +5. The circlet can't be used this way again until the next dawn.", null));
	}
}
