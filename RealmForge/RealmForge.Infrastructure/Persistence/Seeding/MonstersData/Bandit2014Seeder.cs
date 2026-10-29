using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Bandit (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Bandit2014Seeder
{
	public static Monster Build() => Create("bandit", null, CreatureSize.Medium, CreatureType.Humanoid,
		12, 11, "2d8 + 2", 30, new[] { 11, 12, 12, 10, 10, 10 }, 0.125m, 25, 2, 10,
		new Text(
			"Bandito",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento non legale",
			"12 (armatura di cuoio)",
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
			"***Scimitarra.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni taglienti.\n\n***Balestra leggera.*** *Attacco con arma a distanza:* +3 al tiro per colpire, gittata 24/96 m, un bersaglio. *Colpito:* 5 (1d8 + 1) danni perforanti.",
			"",
			""),
		new Text(
			"Bandit",
			null,
			"Medium humanoid (any race), any non-lawful alignment",
			"12 (leather armor)",
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
			"***Scimitar.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 4 (1d6 + 1) slashing damage.\n\n***Light Crossbow.*** *Ranged Weapon Attack:* +3 to hit, range 80/320 ft., one target. *Hit:* 5 (1d8 + 1) piercing damage.",
			"",
			""));
}
