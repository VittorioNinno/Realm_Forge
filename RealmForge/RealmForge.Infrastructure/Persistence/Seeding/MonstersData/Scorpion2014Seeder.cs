using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Scorpion (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Scorpion2014Seeder
{
	public static Monster Build() => Create("scorpion", null, CreatureSize.Tiny, CreatureType.Beast,
		11, 1, "1d4 - 1", 10, new[] { 2, 11, 8, 1, 8, 2 }, 0m, 10, 2, 9,
		new Text(
			"Scorpione",
			null,
			"Bestia Minuscola, senza allineamento",
			"11 (armatura naturale)",
			"3 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 9, vista cieca 3 m",
			"—",
			"",
			"***Pungiglione.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 1 danno perforante e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 9, subendo 4 (1d8) danni da veleno in caso di fallimento, o la metà in caso di successo.",
			"",
			""),
		new Text(
			"Scorpion",
			null,
			"Tiny beast, unaligned",
			"11 (natural armor)",
			"10 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"blindsight 10 ft., passive Perception 9",
			"—",
			"",
			"***Sting.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one creature. *Hit:* 1 piercing damage, and the target must make a DC 9 Constitution saving throw, taking 4 (1d8) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
