using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gas Spore (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GasSpore2014Seeder
{
	public static Monster Build() => Create("gas-spore", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Plant,
		5, 1, "1d10 - 4", 0, new[] { 5, 1, 3, 1, 1, 1 }, 0.5m, 100, 2, 5,
		new Text(
			"Spora gassosa",
			null,
			"Vegetale Grande, senza allineamento",
			"5",
			"0 m, volare 3 m (fluttuare)",
			"",
			"",
			"",
			"",
			"veleno",
			"accecato, assordato, avvelenato, paralizzato, prono, spaventato",
			"Percezione passiva 5, vista cieca 9 m (cieco oltre questo raggio)",
			"—",
			"***Esplosione mortale.*** Quando scende a 0 punti ferita, la spora gassosa esplode. Ogni creatura entro 6 metri da lei effettua un tiro salvezza su Costituzione con CD 15; se lo fallisce subisce 10 (3d6) danni da veleno e contrae una malattia (le creature immuni alla condizione avvelenato ne sono immuni). Se non viene curata, le spore che crescono al suo interno la uccidono dopo un numero di ore pari a 1d12 + il suo punteggio di Costituzione, e nella seconda metà di quel tempo la creatura è avvelenata. Dal suo cadavere spuntano 2d4 spore gassose Minuscole, che raggiungono la piena grandezza in 7 giorni.\n\n***Somiglianza inquietante.*** La spora gassosa ha l'aspetto di un beholder. Una creatura in grado di vederla ne riconosce la vera natura superando una prova di Intelligenza (Natura) con CD 15.",
			"***Tocco.*** *Attacco con arma da mischia:* +0 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 1 danno da veleno, e la creatura effettua un tiro salvezza su Costituzione con CD 10, altrimenti contrae la malattia descritta in Esplosione mortale.",
			"",
			"",
			"",
			""),
		new Text(
			"Gas Spore",
			null,
			"Large plant, unaligned",
			"5",
			"0 ft., fly 10 ft. (hover)",
			"",
			"",
			"",
			"",
			"poison",
			"blinded, deafened, frightened, paralyzed, poisoned, prone",
			"blindsight 30 ft. (blind beyond this radius), passive Perception 5",
			"—",
			"***Death Burst.*** When the gas spore drops to 0 hit points it bursts. Each creature within 20 feet of it makes a DC 15 Constitution saving throw; on a failure it takes 10 (3d6) poison damage and catches a disease (creatures immune to the poisoned condition are immune to it). Unless cured, the spores growing inside kill the creature after a number of hours equal to 1d12 + its Constitution score, and the creature is poisoned for the second half of that time. From its corpse sprout 2d4 Tiny gas spores, which reach full size in 7 days.\n\n***Eerie Resemblance.*** The gas spore looks like a beholder. A creature that can see it recognizes its true nature with a DC 15 Intelligence (Nature) check.",
			"***Touch.*** *Melee Weapon Attack:* +0 to hit, reach 5 ft., one creature. *Hit:* 1 poison damage, and the creature makes a DC 10 Constitution saving throw or catches the disease described in Death Burst.",
			"",
			"",
			"",
			""));
}
