using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Crab (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Crab2014Seeder
{
	public static Monster Build() => Create("crab", null, ContentSource.Srd51, CreatureSize.Tiny, CreatureType.Beast,
		11, 2, "1d4", 20, new[] { 2, 11, 10, 1, 8, 2 }, 0m, 10, 2, 9,
		new Text(
			"Granchio",
			null,
			"Bestia Minuscola, senza allineamento",
			"11 (armatura naturale)",
			"6 m, nuotare 6 m",
			"",
			"Furtività +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 9, vista cieca 9 m",
			"—",
			"***Anfibio.*** Il granchio può respirare in aria e in acqua.",
			"***Artiglio.*** *Attacco con arma da mischia:* +0 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno contundente.",
			"",
			"",
			"",
			""),
		new Text(
			"Crab",
			null,
			"Tiny beast, unaligned",
			"11 (natural armor)",
			"20 ft., swim 20 ft.",
			"",
			"Stealth +2",
			"",
			"",
			"",
			"",
			"blindsight 30 ft., passive Perception 9",
			"—",
			"***Amphibious.*** The crab can breathe air and water.",
			"***Claw.*** *Melee Weapon Attack:* +0 to hit, reach 5 ft., one target. *Hit:* 1 bludgeoning damage.",
			"",
			"",
			"",
			""));
}
