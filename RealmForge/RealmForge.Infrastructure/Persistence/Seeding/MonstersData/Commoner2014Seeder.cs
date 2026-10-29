using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Commoner (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Commoner2014Seeder
{
	public static Monster Build() => Create("commoner", null, CreatureSize.Medium, CreatureType.Humanoid,
		10, 4, "1d8", 30, new[] { 10, 10, 10, 10, 10, 10 }, 0m, 10, 2, 10,
		new Text(
			"Popolano",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"10",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"uno qualsiasi (di solito Comune)",
			"",
			"***Randello.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 2 (1d4) danni contundenti.",
			"",
			""),
		new Text(
			"Commoner",
			null,
			"Medium humanoid (any race), any alignment",
			"10",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"any one language (usually Common)",
			"",
			"***Club.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 2 (1d4) bludgeoning damage.",
			"",
			""));
}
