using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Lizard (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantLizard2014Seeder
{
	public static Monster Build() => Create("giant-lizard", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		12, 19, "3d10 + 3", 30, new[] { 15, 12, 13, 2, 10, 5 }, 0.25m, 50, 2, 10,
		new Text(
			"Lucertola gigante",
			null,
			"Bestia Grande, senza allineamento",
			"12 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 9 m",
			"—",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Lizard",
			null,
			"Large beast, unaligned",
			"12 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 30 ft., passive Perception 10",
			"—",
			"",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
