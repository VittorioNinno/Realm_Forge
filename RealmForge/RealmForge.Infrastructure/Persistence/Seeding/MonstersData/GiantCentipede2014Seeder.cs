using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Centipede (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantCentipede2014Seeder
{
	public static Monster Build() => Create("giant-centipede", null, ContentSource.Srd51, CreatureSize.Small, CreatureType.Beast,
		13, 4, "1d6 + 1", 30, new[] { 5, 14, 12, 1, 7, 3 }, 0.25m, 50, 2, 8,
		new Text(
			"Millepiedi gigante",
			null,
			"Bestia Piccola, senza allineamento",
			"13 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 8, vista cieca 9 m",
			"—",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 4 (1d4 + 2) danni perforanti e il bersaglio deve superare un tiro salvezza su Costituzione con CD 11, altrimenti subisce 10 (3d6) danni da veleno. Se i danni da veleno riducono i punti ferita del bersaglio a 0, esso è stabile ma avvelenato per 1 ora anche dopo aver recuperato punti ferita e, mentre è avvelenato in questo modo, è paralizzato.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Centipede",
			null,
			"Small beast, unaligned",
			"13 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"blindsight 30 ft., passive Perception 8",
			"—",
			"",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 4 (1d4 + 2) piercing damage, and the target must succeed on a DC 11 Constitution saving throw or take 10 (3d6) poison damage. If the poison damage reduces the target to 0 hit points, the target is stable but poisoned for 1 hour, even after regaining hit points, and is paralyzed while poisoned in this way.",
			"",
			"",
			"",
			""));
}
