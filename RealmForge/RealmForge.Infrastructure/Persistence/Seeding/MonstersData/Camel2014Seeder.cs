using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Camel (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Camel2014Seeder
{
	public static Monster Build() => Create("camel", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		9, 15, "2d10 + 4", 50, new[] { 16, 8, 14, 2, 8, 5 }, 0.125m, 25, 2, 9,
		new Text(
			"Cammello",
			null,
			"Bestia Grande, senza allineamento",
			"9",
			"15 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 9",
			"—",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 2 (1d4) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Camel",
			null,
			"Large beast, unaligned",
			"9",
			"50 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 9",
			"—",
			"",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 2 (1d4) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
