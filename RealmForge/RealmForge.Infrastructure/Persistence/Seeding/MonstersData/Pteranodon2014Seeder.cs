using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Pteranodon (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Pteranodon2014Seeder
{
	public static Monster Build() => Create("pteranodon", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Beast,
		13, 13, "3d8", 10, new[] { 12, 15, 10, 2, 9, 5 }, 0.25m, 50, 2, 11,
		new Text(
			"Pteranodonte",
			null,
			"Bestia Media, senza allineamento",
			"13 (armatura naturale)",
			"3 m, volare 18 m",
			"",
			"Percezione +1",
			"",
			"",
			"",
			"",
			"Percezione passiva 11",
			"—",
			"***Volo radente.*** Lo pteranodonte non provoca attacchi di opportunità quando esce in volo dalla portata di un nemico.",
			"***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (2d4 + 1) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Pteranodon",
			null,
			"Medium beast, unaligned",
			"13 (natural armor)",
			"10 ft., fly 60 ft.",
			"",
			"Perception +1",
			"",
			"",
			"",
			"",
			"passive Perception 11",
			"—",
			"***Flyby.*** The pteranodon doesn't provoke opportunity attacks when it flies out of an enemy's reach.",
			"***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 6 (2d4 + 1) piercing damage.",
			"",
			"",
			"",
			""));
}
