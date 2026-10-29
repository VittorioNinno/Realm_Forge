using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Fire Beetle (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantFireBeetle2014Seeder
{
	public static Monster Build() => Create("giant-fire-beetle", null, ContentSource.Srd51, CreatureSize.Small, CreatureType.Beast,
		13, 4, "1d6 + 1", 30, new[] { 8, 10, 12, 1, 7, 3 }, 0m, 10, 2, 8,
		new Text(
			"Scarabeo di fuoco gigante",
			null,
			"Bestia Piccola, senza allineamento",
			"13 (armatura naturale)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 8, vista cieca 9 m",
			"—",
			"***Illuminazione.*** Lo scarabeo proietta luce intensa in un raggio di 3 metri e luce fioca per altri 3 metri.",
			"***Morso.*** *Attacco con arma da mischia:* +1 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 2 (1d6 - 1) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Fire Beetle",
			null,
			"Small beast, unaligned",
			"13 (natural armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"blindsight 30 ft., passive Perception 8",
			"—",
			"***Illumination.*** The beetle sheds bright light in a 10-foot radius and dim light for an additional 10 ft..",
			"***Bite.*** *Melee Weapon Attack:* +1 to hit, reach 5 ft., one target. *Hit:* 2 (1d6 - 1) slashing damage.",
			"",
			"",
			"",
			""));
}
