using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Fire Giant (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class FireGiant2014Seeder
{
	public static Monster Build() => Create("fire-giant", null, ContentSource.Srd51, CreatureSize.Huge, CreatureType.Giant,
		18, 162, "13d12 + 78", 30, new[] { 25, 9, 23, 10, 14, 13 }, 9m, 5000, 4, 16,
		new Text(
			"Gigante del fuoco",
			null,
			"Gigante Enorme, legale malvagio",
			"18 (piastre)",
			"9 m",
			"Car +5, Cos +10, Des +3",
			"Atletica +11, Percezione +6",
			"",
			"",
			"fuoco",
			"",
			"Percezione passiva 16",
			"Gigante",
			"",
			"***Multiattacco.*** Il gigante effettua due attacchi con lo spadone.\n\n***Spadone.*** *Attacco con arma da mischia:* +11 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 28 (6d6 + 7) danni taglienti.\n\n***Roccia.*** *Attacco con arma a distanza:* +11 al tiro per colpire, gittata 18/72 m, un bersaglio. *Colpito:* 29 (4d10 + 7) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Fire Giant",
			null,
			"Huge giant, lawful evil",
			"18 (plate armor)",
			"30 ft.",
			"Dex +3, Con +10, Cha +5",
			"Athletics +11, Perception +6",
			"",
			"",
			"fire",
			"",
			"passive Perception 16",
			"Giant",
			"",
			"***Multiattack.*** The giant makes two greatsword attacks.\n\n***Greatsword.*** *Melee Weapon Attack:* +11 to hit, reach 10 ft., one target. *Hit:* 28 (6d6 + 7) slashing damage.\n\n***Rock.*** *Ranged Weapon Attack:* +11 to hit, range 60/240 ft., one target. *Hit:* 29 (4d10 + 7) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
