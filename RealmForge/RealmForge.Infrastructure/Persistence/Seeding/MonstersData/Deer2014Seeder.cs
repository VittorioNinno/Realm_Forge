using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Deer (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Deer2014Seeder
{
	public static Monster Build() => Create("deer", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		13, 4, "1d8", 50, new[] { 11, 16, 11, 2, 14, 5 }, 0m, 10, 2, 12,
		new Text(
			"Daino",
			null,
			"Bestia Media, senza allineamento",
			"13",
			"15 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 12",
			"—",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 2 (1d4) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Deer",
			null,
			"Medium beast, unaligned",
			"13",
			"50 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 12",
			"—",
			"",
			"***Bite.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 2 (1d4) piercing damage.",
			"",
			"",
			"",
			""));
}
