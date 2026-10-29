using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Awakened Shrub (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AwakenedShrub2014Seeder
{
	public static Monster Build() => Create("awakened-shrub", null, ContentSource.Srd51, CreatureSize.Small, CreatureType.Plant,
		9, 10, "3d6", 20, new[] { 3, 8, 11, 10, 10, 6 }, 0m, 10, 2, 10,
		new Text(
			"Cespuglio risvegliato",
			null,
			"Vegetale Piccolo, senza allineamento",
			"9",
			"6 m",
			"",
			"",
			"fuoco",
			"perforanti",
			"",
			"",
			"Percezione passiva 10",
			"un linguaggio conosciuto dal suo creatore",
			"***Falso aspetto.*** Finché questo essere rimane immobile, non è possibile distinguerlo da un normale cespuglio.",
			"***Graffiare.*** *Attacco con arma da mischia:* +1 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 (1d4 - 1) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Awakened Shrub",
			null,
			"Small plant, unaligned",
			"9",
			"20 ft.",
			"",
			"",
			"fire",
			"piercing",
			"",
			"",
			"passive Perception 10",
			"one language known by its creator",
			"***False Appearance.*** While the shrub remains motionless, it is indistinguishable from a normal shrub.",
			"***Rake.*** *Melee Weapon Attack:* +1 to hit, reach 5 ft., one target. *Hit:* 1 (1d4 - 1) slashing damage.",
			"",
			"",
			"",
			""));
}
