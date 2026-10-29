using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Veteran (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Veteran2014Seeder
{
	public static Monster Build() => Create("veteran", null, CreatureSize.Medium, CreatureType.Humanoid,
		17, 58, "9d8 + 18", 30, new[] { 16, 13, 14, 10, 11, 10 }, 3m, 700, 2, 12,
		new Text(
			"Veterano",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"17 (corazza a strisce)",
			"9 m",
			"",
			"Atletica +5, Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12",
			"uno qualsiasi (di solito Comune)",
			"",
			"***Multiattacco.*** Il veterano sferra due attacchi con la spada lunga. Se ha sfoderato una spada corta, può effettuare anche un attacco con la spada corta.\n\n***Spada corta.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.\n\n***Spada lunga.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni taglienti o 8 (1d10 + 3) danni taglienti se usata a due mani.\n\n***Balestra pesante.*** *Attacco con arma a distanza:* +3 al tiro per colpire, gittata 30/120 m, un bersaglio. *Colpito:* 6 (1d10 + 1) danni perforanti.",
			"",
			""),
		new Text(
			"Veteran",
			null,
			"Medium humanoid (any race), any alignment",
			"17 (splint armor)",
			"30 ft.",
			"",
			"Athletics +5, Perception +2",
			"",
			"",
			"",
			"",
			"passive Perception 12",
			"any one language (usually Common)",
			"",
			"***Multiattack.*** The veteran makes two longsword attacks. If it has a shortsword drawn, it can also make a shortsword attack.\n\n***Longsword.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) slashing damage, or 8 (1d10 + 3) slashing damage if used with two hands.\n\n***Shortsword.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.\n\n***Heavy Crossbow.*** *Ranged Weapon Attack:* +3 to hit, range 100/400 ft., one target. *Hit:* 6 (1d10 + 1) piercing damage.",
			"",
			""));
}
