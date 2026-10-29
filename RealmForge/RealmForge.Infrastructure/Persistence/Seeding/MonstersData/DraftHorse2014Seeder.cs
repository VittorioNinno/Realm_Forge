using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Draft Horse (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class DraftHorse2014Seeder
{
	public static Monster Build() => Create("draft-horse", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		10, 19, "3d10 + 3", 40, new[] { 18, 10, 12, 2, 11, 7 }, 0.25m, 50, 2, 10,
		new Text(
			"Cavallo da tiro",
			null,
			"Bestia Grande, senza allineamento",
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
			"***Zoccoli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (2d4 + 4) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Draft Horse",
			null,
			"Large beast, unaligned",
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
			"***Hooves.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 9 (2d4 + 4) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
