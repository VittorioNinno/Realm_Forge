using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Warhorse Skeleton (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class WarhorseSkeleton2014Seeder
{
	public static Monster Build() => Create("warhorse-skeleton", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Undead,
		13, 22, "3d10 + 6", 60, new[] { 18, 12, 15, 2, 8, 5 }, 0.5m, 100, 2, 9,
		new Text(
			"Scheletro di cavallo da guerra",
			null,
			"Non morto Grande, legale malvagio",
			"13 (frammenti di bardatura)",
			"18 m",
			"",
			"",
			"contundenti",
			"",
			"veleno",
			"avvelenato, indebolimento",
			"Percezione passiva 9, scurovisione 18 m",
			"—",
			"",
			"***Zoccoli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Warhorse Skeleton",
			null,
			"Large undead, lawful evil",
			"13",
			"60 ft.",
			"",
			"",
			"bludgeoning",
			"",
			"poison",
			"exhaustion, poisoned",
			"darkvision 60 ft., passive Perception 9",
			"—",
			"",
			"***Hooves.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
