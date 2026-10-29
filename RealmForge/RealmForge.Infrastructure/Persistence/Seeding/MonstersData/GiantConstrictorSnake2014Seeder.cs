using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Constrictor Snake (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantConstrictorSnake2014Seeder
{
	public static Monster Build() => Create("giant-constrictor-snake", null, CreatureSize.Huge, CreatureType.Beast,
		12, 60, "8d12 + 8", 30, new[] { 19, 14, 12, 1, 10, 3 }, 2m, 450, 2, 12,
		new Text(
			"Serpente stritolatore gigante",
			null,
			"Bestia Enorme, senza allineamento",
			"12",
			"9 m, nuotare 9 m",
			"",
			"Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, vista cieca 3 m",
			"—",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 11 (2d6 + 4) danni perforanti.\n\n***Stritolare.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 13 (2d8 + 4) danni contundenti e il bersaglio è afferrato (CD 16 per sfuggire). Finché è afferrato, il bersaglio è trattenuto e il serpente non può stritolarne un altro.",
			"",
			""),
		new Text(
			"Giant Constrictor Snake",
			null,
			"Huge beast, unaligned",
			"12",
			"30 ft., swim 30 ft.",
			"",
			"Perception +2",
			"",
			"",
			"",
			"",
			"blindsight 10 ft., passive Perception 12",
			"—",
			"",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one creature. *Hit:* 11 (2d6 + 4) piercing damage.\n\n***Constrict.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one creature. *Hit:* 13 (2d8 + 4) bludgeoning damage, and the target is grappled (escape DC 16). Until this grapple ends, the creature is restrained, and the snake can't constrict another target.",
			"",
			""));
}
