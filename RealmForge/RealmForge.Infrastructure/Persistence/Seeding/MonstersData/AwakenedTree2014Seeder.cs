using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Awakened Tree (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AwakenedTree2014Seeder
{
	public static Monster Build() => Create("awakened-tree", null, CreatureSize.Huge, CreatureType.Plant,
		13, 59, "7d12 + 14", 20, new[] { 19, 6, 15, 10, 10, 7 }, 2m, 450, 2, 10,
		new Text(
			"Albero risvegliato",
			null,
			"Vegetale Enorme, senza allineamento",
			"13 (armatura naturale)",
			"6 m",
			"",
			"",
			"fuoco",
			"contundenti, perforanti",
			"",
			"",
			"Percezione passiva 10",
			"un linguaggio conosciuto dal suo creatore",
			"***Falso aspetto.*** Finché questo essere rimane immobile, non è possibile distinguerlo da un normale albero.",
			"***Schianto.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 14 (3d6 + 4) danni contundenti.",
			"",
			""),
		new Text(
			"Awakened Tree",
			null,
			"Huge plant, unaligned",
			"13 (natural armor)",
			"20 ft.",
			"",
			"",
			"fire",
			"bludgeoning, piercing",
			"",
			"",
			"passive Perception 10",
			"one language known by its creator",
			"***False Appearance.*** While the tree remains motionless, it is indistinguishable from a normal tree.",
			"***Slam.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one target. *Hit:* 14 (3d6 + 4) bludgeoning damage.",
			"",
			""));
}
