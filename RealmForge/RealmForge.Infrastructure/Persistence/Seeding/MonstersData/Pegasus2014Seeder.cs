using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Pegasus (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Pegasus2014Seeder
{
	public static Monster Build() => Create("pegasus", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Celestial,
		12, 59, "7d10 + 21", 60, new[] { 18, 15, 16, 10, 15, 13 }, 2m, 450, 2, 16,
		new Text(
			"Pegaso",
			null,
			"Celestiale grande, caotico buono",
			"12",
			"18 m, volare 27 m",
			"Car +3, Des +4, Sag +4",
			"Percezione +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 16",
			"comprende Celestiale, Comune, Elfico e Silvano ma non li parla",
			"",
			"***Zoccoli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Pegasus",
			null,
			"Large celestial, chaotic good",
			"12",
			"60 ft., fly 90 ft.",
			"Dex +4, Wis +4, Cha +3",
			"Perception +6",
			"",
			"",
			"",
			"",
			"passive Perception 16",
			"understands Celestial, Common, Elvish, and Sylvan but can't speak",
			"",
			"***Hooves.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
