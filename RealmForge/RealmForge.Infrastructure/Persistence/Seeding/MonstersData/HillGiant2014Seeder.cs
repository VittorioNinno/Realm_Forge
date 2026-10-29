using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hill Giant (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class HillGiant2014Seeder
{
	public static Monster Build() => Create("hill-giant", null, CreatureSize.Huge, CreatureType.Giant,
		13, 105, "10d12 + 40", 40, new[] { 21, 8, 19, 5, 9, 6 }, 5m, 1800, 3, 12,
		new Text(
			"Gigante delle colline",
			null,
			"Gigante Enorme, caotico malvagio",
			"13 (armatura naturale)",
			"12 m",
			"",
			"Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12",
			"Gigante",
			"",
			"***Multiattacco.*** Il gigante effettua due attacchi con il randello pesante.\n\n***Randello pesante.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 18 (3d8 + 5) danni contundenti.\n\n***Roccia.*** *Attacco con arma a distanza:* +8 al tiro per colpire, gittata 18/72 m, un bersaglio. *Colpito:* 21 (3d10 + 5) danni contundenti.",
			"",
			""),
		new Text(
			"Hill Giant",
			null,
			"Huge giant, chaotic evil",
			"13 (natural armor)",
			"40 ft.",
			"",
			"Perception +2",
			"",
			"",
			"",
			"",
			"passive Perception 12",
			"Giant",
			"",
			"***Multiattack.*** The giant makes two greatclub attacks.\n\n***Greatclub.*** *Melee Weapon Attack:* +8 to hit, reach 10 ft., one target. *Hit:* 18 (3d8 + 5) bludgeoning damage.\n\n***Rock.*** *Ranged Weapon Attack:* +8 to hit, range 60/240 ft., one target. *Hit:* 21 (3d10 + 5) bludgeoning damage.",
			"",
			""));
}
