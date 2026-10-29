using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Constrictor Snake (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class ConstrictorSnake2014Seeder
{
	public static Monster Build() => Create("constrictor-snake", null, CreatureSize.Large, CreatureType.Beast,
		12, 13, "2d10 + 2", 30, new[] { 15, 14, 12, 1, 10, 3 }, 0.25m, 50, 2, 10,
		new Text(
			"Serpente stritolatore",
			null,
			"Bestia Grande, senza allineamento",
			"12",
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
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 5 (1d6 + 2) danni perforanti.\n\n***Stritolare.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 6 (1d8 + 2) danni contundenti e il bersaglio è afferrato (CD 14 per sfuggire). Finché è afferrato, il bersaglio è trattenuto e il serpente non può stritolarne un altro.",
			"",
			""),
		new Text(
			"Constrictor Snake",
			null,
			"Large beast, unaligned",
			"12",
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
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Constrict.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 6 (1d8 + 2) bludgeoning damage, and the target is grappled (escape DC 14). Until this grapple ends, the creature is restrained, and the snake can't constrict another target.",
			"",
			""));
}
