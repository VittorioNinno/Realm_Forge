using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Crocodile (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Crocodile2014Seeder
{
	public static Monster Build() => Create("crocodile", null, CreatureSize.Large, CreatureType.Beast,
		12, 19, "3d10 + 3", 20, new[] { 15, 10, 13, 2, 10, 5 }, 0.5m, 100, 2, 10,
		new Text(
			"Coccodrillo",
			null,
			"Bestia Grande, senza allineamento",
			"12 (armatura naturale)",
			"6 m, nuotare 9 m",
			"",
			"Furtività +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"***Apnea.*** Il coccodrillo può trattenere il respiro per 15 minuti.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 7 (1d10 + 2) danni perforanti e il bersaglio viene afferrato (CD 12 per sfuggire). Finché la presa perdura, il bersaglio viene trattenuto e il coccodrillo non può morderne un altro.",
			"",
			""),
		new Text(
			"Crocodile",
			null,
			"Large beast, unaligned",
			"12 (natural armor)",
			"20 ft., swim 20 ft.",
			"",
			"Stealth +2",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"***Hold Breath.*** The crocodile can hold its breath for 15 minutes.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 7 (1d10 + 2) piercing damage, and the target is grappled (escape DC 12). Until this grapple ends, the target is restrained, and the crocodile can't bite another target",
			"",
			""));
}
