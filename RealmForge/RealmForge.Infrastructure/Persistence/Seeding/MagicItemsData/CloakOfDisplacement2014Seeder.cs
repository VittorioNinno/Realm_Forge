using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Cloak of Displacement (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class CloakOfDisplacement2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("cloak-of-displacement", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Mantello distorcente", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Quando il personaggio indossa questo mantello proietta un'illusione che lo fa apparire in un punto diverso da quello in cui si trova in realtà. Di conseguenza, tutte le creature subiscono svantaggio ai tiri per colpire contro di lui. Se il personaggio subisce danni, la proprietà smette di funzionare fino all'inizio del suo turno successivo. Questa proprietà è soppressa finché il personaggio è incapacitato, trattenuto o impossibilitato a muoversi in altri modi.", null),
			("Cloak of Displacement", "Wondrous item, rare (requires attunement)",
			"While you wear this cloak, it projects an illusion that makes you appear to be standing in a place near your actual location, causing any creature to have disadvantage on attack rolls against you. If you take damage, the property ceases to function until the start of your next turn. This property is suppressed while you are incapacitated, restrained, or otherwise unable to move.", null));
	}
}
