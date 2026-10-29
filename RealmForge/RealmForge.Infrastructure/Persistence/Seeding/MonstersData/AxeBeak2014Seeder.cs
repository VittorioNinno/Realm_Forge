using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Axe Beak (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AxeBeak2014Seeder
{
	public static Monster Build() => Create("axe-beak", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		11, 19, "3d10 + 3", 50, new[] { 14, 12, 12, 2, 10, 5 }, 0.25m, 50, 2, 10,
		new Text(
			"Beccoaguzzo",
			null,
			"Bestia Grande, senza allineamento",
			"11",
			"15 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"",
			"***Becco.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Axe Beak",
			null,
			"Large beast, unaligned",
			"11",
			"50 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"",
			"***Beak.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 6 (1d8 + 2) slashing damage.",
			"",
			"",
			"",
			""));
}
