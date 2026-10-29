using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Merfolk (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Merfolk2014Seeder
{
	public static Monster Build() => Create("merfolk", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		11, 11, "2d8 + 2", 10, new[] { 10, 13, 12, 11, 11, 12 }, 0.125m, 25, 2, 12,
		new Text(
			"Marinide",
			null,
			"Umanoide Medio (marinide), neutrale",
			"11",
			"3 m, nuotare 12 m",
			"",
			"Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12",
			"Aquan, Comune",
			"***Anfibio.*** Il marinide può respirare in aria e in acqua.",
			"***Lancia.*** *Attacco con arma da mischia o a distanza:* +2 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 3 (1d6) danni perforanti o 4 (1d8) danni perforanti se usata a due mani per effettuare un attacco in mischia.",
			"",
			"",
			"",
			""),
		new Text(
			"Merfolk",
			null,
			"Medium humanoid (merfolk), neutral",
			"11",
			"10 ft., swim 40 ft.",
			"",
			"Perception +2",
			"",
			"",
			"",
			"",
			"passive Perception 12",
			"Aquan, Common",
			"***Amphibious.*** The merfolk can breathe air and water.",
			"***Spear.*** *Melee or Ranged Weapon Attack:* +2 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 3 (1d6) piercing damage, or 4 (1d8) piercing damage if used with two hands to make a melee attack.",
			"",
			"",
			"",
			""));
}
