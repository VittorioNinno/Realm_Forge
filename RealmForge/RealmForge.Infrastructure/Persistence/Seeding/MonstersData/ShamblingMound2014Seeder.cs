using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Shambling Mound (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class ShamblingMound2014Seeder
{
	public static Monster Build() => Create("shambling-mound", null, CreatureSize.Large, CreatureType.Plant,
		15, 136, "16d10 + 48", 20, new[] { 18, 8, 16, 5, 10, 5 }, 5m, 1800, 3, 10,
		new Text(
			"Cumulo strisciante",
			null,
			"Vegetale Grande, senza allineamento",
			"15 (armatura naturale)",
			"6 m, nuotare 6 m",
			"",
			"Furtività +2",
			"",
			"freddo, fuoco",
			"fulmine",
			"accecato, assordato, indebolimento",
			"Percezione passiva 10, vista cieca 18 m (cecità oltre questo raggio)",
			"—",
			"***Assorbimento del fulmine.*** Ogni volta che il cumulo strisciante è soggetto a danni da fulmine, non subisce danni e anzi recupera un numero di punti ferita pari ai danni da fulmine inflitti.",
			"***Multiattacco.*** Il cumulo strisciante effettua due attacchi con schianto. Se entrambi gli attacchi colpiscono un bersaglio di taglia Media o inferiore, quest'ultimo viene afferrato (CD 14 per sfuggire) e il mostro usa Avviluppare su di lui.\n\n***Schianto.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni contundenti.\n\n***Avviluppare.*** Il cumulo strisciante avviluppa una creatura di taglia Media o inferiore che ha afferrato. Il bersaglio avviluppato è accecato e trattenuto, non è in grado di respirare e deve superare un tiro salvezza su Costituzione con CD 14 all'inizio di ogni turno del mostro, altrimenti subisce 13 (2d8 + 4) danni contundenti. Se il cumulo si muove, la vittima avviluppata si muove insieme a lui. Il cumulo può eseguire quest'azione su una sola creatura alla volta.",
			"",
			""),
		new Text(
			"Shambling Mound",
			null,
			"Large plant, unaligned",
			"15 (natural armor)",
			"20 ft., swim 20 ft.",
			"",
			"Stealth +2",
			"",
			"cold, fire",
			"lightning",
			"blinded, blinded, exhaustion",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 10",
			"—",
			"***Lightning Absorption.*** Whenever the shambling mound is subjected to lightning damage, it takes no damage and regains a number of hit points equal to the lightning damage dealt.",
			"***Multiattack.*** The shambling mound makes two slam attacks. If both attacks hit a Medium or smaller target, the target is grappled (escape DC 14), and the shambling mound uses its Engulf on it.\n\n***Slam.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) bludgeoning damage.\n\n***Engulf.*** The shambling mound engulfs a Medium or smaller creature grappled by it. The engulfed target is blinded, restrained, and unable to breathe, and it must succeed on a DC 14 Constitution saving throw at the start of each of the mound's turns or take 13 (2d8 + 4) bludgeoning damage. If the mound moves, the engulfed target moves with it. The mound can have only one creature engulfed at a time.",
			"",
			""));
}
