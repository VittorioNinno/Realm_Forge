using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Wasp (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantWasp2014Seeder
{
	public static Monster Build() => Create("giant-wasp", null, CreatureSize.Medium, CreatureType.Beast,
		12, 13, "3d8", 10, new[] { 10, 14, 10, 1, 10, 3 }, 0.5m, 100, 2, 10,
		new Text(
			"Vespa gigante",
			null,
			"Bestia Media, senza allineamento",
			"12",
			"3 m, volare 15 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"",
			"***Pungiglione.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 5 (1d6 + 2) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 11 subendo 10 (3d6) danni da veleno, in caso di fallimento, o la metà in caso di successo. Se i danni da veleno riducono i punti ferita del bersaglio a 0, esso è stabile ma avvelenato per 1 ora anche dopo aver recuperato punti ferita e, mentre è avvelenato in questo modo, è paralizzato.",
			"",
			""),
		new Text(
			"Giant Wasp",
			null,
			"Medium beast, unaligned",
			"12",
			"10 ft., fly 50 ft., swim 50 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"",
			"***Sting.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 5 (1d6 + 2) piercing damage, and the target must make a DC 11 Constitution saving throw, taking 10 (3d6) poison damage on a failed save, or half as much damage on a successful one. If the poison damage reduces the target to 0 hit points, the target is stable but poisoned for 1 hour, even after regaining hit points, and is paralyzed while poisoned in this way.",
			"",
			""));
}
