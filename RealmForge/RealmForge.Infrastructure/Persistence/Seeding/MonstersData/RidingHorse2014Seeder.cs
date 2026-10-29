using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Riding Horse (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class RidingHorse2014Seeder
{
	public static Monster Build() => Create("riding-horse", null, CreatureSize.Large, CreatureType.Beast,
		10, 13, "2d10 + 2", 60, new[] { 16, 10, 12, 2, 11, 7 }, 0.25m, 50, 2, 10,
		new Text(
			"Cavallo da galoppo",
			null,
			"Bestia Grande, senza allineamento",
			"10",
			"18 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"",
			"***Zoccoli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (2d4 + 3) danni contundenti.",
			"",
			""),
		new Text(
			"Riding Horse",
			null,
			"Large beast, unaligned",
			"10",
			"60 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"",
			"***Hooves.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 8 (2d4 + 3) bludgeoning damage.",
			"",
			""));
}
