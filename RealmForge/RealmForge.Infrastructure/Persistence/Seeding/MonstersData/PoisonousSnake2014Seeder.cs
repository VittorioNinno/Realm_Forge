using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Poisonous Snake (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class PoisonousSnake2014Seeder
{
	public static Monster Build() => Create("poisonous-snake", null, CreatureSize.Tiny, CreatureType.Beast,
		13, 2, "1d4", 30, new[] { 2, 16, 11, 1, 10, 3 }, 0.125m, 25, 2, 10,
		new Text(
			"Serpente velenoso",
			null,
			"Bestia Minuscola, senza allineamento",
			"13",
			"9 m, nuotare 9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, vista cieca 3 m",
			"—",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno perforante e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 10 subendo 5 (2d4) danni da veleno in caso di fallimento, o la metà in caso di successo.",
			"",
			""),
		new Text(
			"Poisonous Snake",
			null,
			"Tiny beast, unaligned",
			"13",
			"30 ft., swim 30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"blindsight 10 ft., passive Perception 10",
			"—",
			"",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 1 piercing damage, and the target must make a DC 10 Constitution saving throw, taking 5 (2d4) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
