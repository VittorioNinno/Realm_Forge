using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Guard (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Guard2014Seeder
{
	public static Monster Build() => Create("guard", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		16, 11, "2d8 + 2", 30, new[] { 13, 12, 12, 10, 11, 10 }, 0.125m, 25, 2, 12,
		new Text(
			"Guardia",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"16 (giaco di maglia, scudo)",
			"9 m",
			"",
			"Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12",
			"uno qualsiasi (di solito Comune)",
			"",
			"***Lancia.*** *Attacco con arma da mischia o a distanza:* +3 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti o 5 (1d8 + 1) danni perforanti se usata a due mani per effettuare un attacco in mischia.",
			"",
			"",
			"",
			""),
		new Text(
			"Guard",
			null,
			"Medium humanoid (any race), any alignment",
			"16 (chain shirt, shield)",
			"30 ft.",
			"",
			"Perception +2",
			"",
			"",
			"",
			"",
			"passive Perception 12",
			"any one language (usually Common)",
			"",
			"***Spear.*** *Melee or Ranged Weapon Attack:* +3 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage or 5 (1d8 + 1) piercing damage if used with two hands to make a melee attack.",
			"",
			"",
			"",
			""));
}
