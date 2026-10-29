using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Pony (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Pony2014Seeder
{
	public static Monster Build() => Create("pony", null, CreatureSize.Medium, CreatureType.Beast,
		10, 11, "2d8 + 2", 40, new[] { 15, 10, 13, 2, 11, 7 }, 0.125m, 25, 2, 10,
		new Text(
			"Pony",
			null,
			"Bestia Media, senza allineamento",
			"10",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"",
			"***Zoccoli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (2d4 + 2) danni contundenti.",
			"",
			""),
		new Text(
			"Pony",
			null,
			"Medium beast, unaligned",
			"10",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"",
			"***Hooves.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (2d4 + 2) bludgeoning damage.",
			"",
			""));
}
