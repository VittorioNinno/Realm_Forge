using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Crab (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantCrab2014Seeder
{
	public static Monster Build() => Create("giant-crab", null, CreatureSize.Medium, CreatureType.Beast,
		15, 13, "3d8", 30, new[] { 13, 15, 11, 1, 9, 3 }, 0.125m, 25, 2, 9,
		new Text(
			"Granchio gigante",
			null,
			"Bestia Media, senza allineamento",
			"15 (armatura naturale)",
			"9 m, nuotare 9 m",
			"",
			"Furtività +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 9, vista cieca 9 m",
			"—",
			"***Anfibio.*** Il granchio può respirare in aria e in acqua.",
			"***Artiglio.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni contundenti e il bersaglio è afferrato (CD 11 per sfuggire). Il granchio è dotato di due chele, ognuna delle quali può afferrare un solo bersaglio.",
			"",
			""),
		new Text(
			"Giant Crab",
			null,
			"Medium beast, unaligned",
			"15 (natural armor)",
			"30 ft., swim 30 ft.",
			"",
			"Stealth +4",
			"",
			"",
			"",
			"",
			"blindsight 30 ft., passive Perception 9",
			"—",
			"***Amphibious.*** The crab can breathe air and water.",
			"***Claw.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 4 (1d6 + 1) bludgeoning damage, and the target is grappled (escape DC 11). The crab has two claws, each of which can grapple only one target.",
			"",
			""));
}
