using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Horseshoes of a Zephyr (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class HorseshoesOfAZephyr2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("horseshoes-of-a-zephyr", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Ferri dello zefiro", "Oggetto meraviglioso, molto raro",
			"Questi ferri da cavallo sono creati a gruppi di quattro. Quando vengono applicati tutti e quattro agli zoccoli di un cavallo o di una creatura simile, permettono a tale creatura di muoversi normalmente fluttuando a 10 cm dal suolo. Grazie a questo effetto la creatura può stazionare o muoversi su superfici non solide o instabili, come l'acqua o la lava. La creatura non lascia tracce e ignora il terreno difficile. Può inoltre muoversi a velocità normale fino a 12 ore al giorno senza subire l'indebolimento dovuto a una marcia forzata."),
			("Horseshoes of a Zephyr", "Wondrous item, very rare",
			"These iron horseshoes come in a set of four. While all four shoes are affixed to the hooves of a horse or similar creature, they allow the creature to move normally while floating 4 inches above the ground. This effect means the creature can cross or stand above nonsolid or unstable surfaces, such as water or lava. The creature leaves no tracks and ignores difficult terrain. In addition, the creature can move at normal speed for up to 12 hours a day without suffering exhaustion from a forced march.", null));
	}
}
