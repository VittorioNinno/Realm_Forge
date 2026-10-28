using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Horn of Blasting (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class HornOfBlasting2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("horn-of-blasting", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Corno della distruzione", "Oggetto meraviglioso, raro",
			"Il personaggio può usare un'azione per pronunciare la parola d'ordine del corno e suonarlo, emettendo un boato roboante in un cono di 9 metri udibile fino a una distanza di 180 metri. Ogni creatura all'interno del cono deve effettuare un tiro salvezza su Costituzione con CD 15: se lo fallisce, subisce 5d6 danni da tuono ed è assordata per 1 minuto, mentre se lo supera, subisce la metà di quei danni e non viene assordata. Le creature e gli oggetti fatti di vetro o di cristallo hanno svantaggio al tiro salvezza e subiscono 10d6 danni da tuono invece che 5d6.\n\nOgni volta che viene usata la magia del corno esiste una probabilità del 20 percento che esploda. L'esplosione infligge 10d6 danni da fuoco a chi ha suonato il corno e distrugge l'oggetto.", null),
			("Horn of Blasting", "Wondrous item, rare",
			"You can use an action to speak the horn's command word and then blow the horn, which emits a thunderous blast in a 30-foot cone that is audible 600 feet away. Each creature in the cone must make a DC 15 Constitution saving throw. On a failed save, a creature takes 5d6 thunder damage and is deafened for 1 minute. On a successful save, a creature takes half as much damage and isn't deafened. Creatures and objects made of glass or crystal have disadvantage on the saving throw and take 10d6 thunder damage instead of 5d6.\n\nEach use of the horn's magic has a 20 percent chance of causing the horn to explode. The explosion deals 10d6 fire damage to the blower and destroys the horn.", null));
	}
}
