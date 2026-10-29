using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Plesiosaurus (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Plesiosaurus2014Seeder
{
	public static Monster Build() => Create("plesiosaurus", null, CreatureSize.Large, CreatureType.Beast,
		13, 68, "8d10 + 24", 20, new[] { 18, 15, 16, 2, 12, 5 }, 2m, 450, 2, 13,
		new Text(
			"Plesiosauro",
			null,
			"Bestia Grande, senza allineamento",
			"13 (armatura naturale)",
			"6 m, nuotare 12 m",
			"",
			"Furtività +4, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Apnea.*** Il plesiosauro può trattenere il respiro per 1 ora.",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 14 (3d6 + 4) danni perforanti.",
			"",
			""),
		new Text(
			"Plesiosaurus",
			null,
			"Large beast, unaligned",
			"13 (natural armor)",
			"20 ft., swim 40 ft.",
			"",
			"Perception +3, Stealth +4",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Hold Breath.*** The plesiosaurus can hold its breath for 1 hour.",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one target. *Hit:* 14 (3d6 + 4) piercing damage.",
			"",
			""));
}
