using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Bead of Force (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BeadOfForce2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("bead-of-force", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, false, ContentSource.Srd51,
			null,
			("Biglia di forza", "Oggetto meraviglioso, raro",
			"Questa piccola sfera nera ha un diametro di 2 cm e pesa 30 grammi. Generalmente le biglie di forza si trovano in gruppi di 1d4 + 4.\n\nUn personaggio può usare un'azione per lanciare la biglia fino a un massimo di 18 metri. Quando colpisce qualcosa, la biglia esplode e si distrugge. Ogni creatura entro un raggio di 3 metri dal punto di impatto della biglia deve superare un tiro salvezza su Destrezza con CD 15, altrimenti subisce 5d4 danni da forza. Poi l'area viene rinchiusa per 1 minuto all'interno di una sfera di forza trasparente. Ogni creatura che ha fallito il tiro salvezza e si trovava completamente all'interno dell'area resta intrappolata all'interno. Chi ha superato il tiro salvezza o si trovava solo parzialmente all'interno dell'area viene allontanato dal centro della sfera e spinto all'esterno. Attraverso le pareti della sfera può passare solo aria respirabile. Non possono passare né attacchi né altri effetti.\n\nUna creatura rinchiusa nell'area può usare la sua azione per spingere le pareti della sfera, muovendola a una velocità massima pari alla metà della propria velocità base sul terreno. La sfera può essere sollevata e la sua magia fa sì che il suo peso sia sempre pari a 0,5 kg, a prescindere dal peso delle creature al suo interno."),
			("Bead of Force", "Wondrous item, rare",
			"This small black Sphere measures 3/4 of an inch in diameter and weighs an ounce. Typically, 1d4 + 4 beads of force are found together.\n\nYou can use an action to throw the bead up to 60 feet. The bead explodes on impact and is destroyed. Each creature within a 10-foot radius of where the bead landed must succeed on a DC 15 Dexterity saving throw or take 5d4 force damage. A Sphere of transparent force then encloses the area for 1 minute. Any creature that failed the save and is completely within the area is trapped inside this Sphere. Creatures that succeeded on the save, or are partially within the area, are pushed away from the center of the Sphere until they are no longer inside it. Only breathable air can pass through the sphere's wall. No attack or other effect can.\n\nAn enclosed creature can use its action to push against the sphere's wall, moving the Sphere up to half the creature's walking speed. The Sphere can be picked up, and its magic causes it to weigh only 1 pound, regardless of the weight of creatures inside.", null));
	}
}
