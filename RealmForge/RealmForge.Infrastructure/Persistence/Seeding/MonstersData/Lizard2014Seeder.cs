using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Lizard (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Lizard2014Seeder
{
	public static Monster Build() => Create("lizard", null, CreatureSize.Tiny, CreatureType.Beast,
		10, 2, "1d4", 20, new[] { 2, 11, 10, 1, 8, 3 }, 0m, 10, 2, 9,
		new Text(
			"Lucertola",
			null,
			"Bestia Minuscola, senza allineamento",
			"10",
			"6 m, scalare 6 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 9, scurovisione 9 m",
			"—",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +0 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno perforante.",
			"",
			""),
		new Text(
			"Lizard",
			null,
			"Tiny beast, unaligned",
			"10",
			"20 ft., climb 20 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 30 ft., passive Perception 9",
			"—",
			"",
			"***Bite.*** *Melee Weapon Attack:* +0 to hit, reach 5 ft., one target. *Hit:* 1 piercing damage.",
			"",
			""));
}
