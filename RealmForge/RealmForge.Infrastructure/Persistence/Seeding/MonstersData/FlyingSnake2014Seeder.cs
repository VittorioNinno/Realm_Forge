using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Flying Snake (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class FlyingSnake2014Seeder
{
	public static Monster Build() => Create("flying-snake", null, CreatureSize.Tiny, CreatureType.Beast,
		14, 5, "2d4", 30, new[] { 4, 18, 11, 2, 12, 5 }, 0.125m, 25, 2, 11,
		new Text(
			"Serpente volante",
			null,
			"Bestia Minuscola, senza allineamento",
			"14",
			"9 m, nuotare 9 m, volare 18 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, vista cieca 3 m",
			"—",
			"***Sfuggente.*** Il serpente non provoca attacchi d'opportunità quando vola oltre la portata di un nemico.",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno perforante più 7 (3d4) danni da veleno.",
			"",
			""),
		new Text(
			"Flying Snake",
			null,
			"Tiny beast, unaligned",
			"14",
			"30 ft., fly 60 ft., swim 30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"blindsight 10 ft., passive Perception 11",
			"—",
			"***Flyby.*** The snake doesn't provoke opportunity attacks when it flies out of an enemy's reach.",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 1 piercing damage plus 7 (3d4) poison damage.",
			"",
			""));
}
