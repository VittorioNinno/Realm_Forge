using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Bugbear (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Bugbear2014Seeder
{
	public static Monster Build() => Create("bugbear", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		16, 27, "5d8 + 5", 30, new[] { 15, 14, 13, 8, 11, 9 }, 1m, 200, 2, 10,
		new Text(
			"Bugbear",
			null,
			"Umanoide Medio (goblinoide), caotico malvagio",
			"16 (armatura di pelle, scudo)",
			"9 m",
			"",
			"Furtività +6, Sopravvivenza +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Comune, Goblin",
			"***Attacco a sorpresa.*** Se il bugbear sorprende una creatura e la colpisce con un attacco durante il primo round di combattimento, il bersaglio subisce 7 (2d6) danni extra dall'attacco.\n\n***Bruto.*** Quando il bugbear colpisce con un'arma da mischia, l'attacco infligge un dado extra del tipo di danno dell'arma (già incluso nell'attacco).",
			"***Mazza chiodata.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d8 + 2) danni perforanti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +4 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 10 (2d6 + 2) danni perforanti in mischia o 5 (1d6 + 2) danni perforanti a distanza.",
			"",
			"",
			"",
			""),
		new Text(
			"Bugbear",
			null,
			"Medium humanoid (goblinoid), chaotic evil",
			"16 (shield, hide armor)",
			"30 ft.",
			"",
			"Stealth +6, Survival +2",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Common, Goblin",
			"***Brute.*** A melee weapon deals one extra die of its damage when the bugbear hits with it (included in the attack).\n\n***Surprise Attack.*** If the bugbear surprises a creature and hits it with an attack during the first round of combat, the target takes an extra 7 (2d6) damage from the attack.",
			"***Morningstar.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 11 (2d8 + 2) piercing damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +4 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 9 (2d6 + 2) piercing damage in melee or 5 (1d6 + 2) piercing damage at range.",
			"",
			"",
			"",
			""));
}
