using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Frost Giant (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class FrostGiant2014Seeder
{
	public static Monster Build() => Create("frost-giant", null, CreatureSize.Huge, CreatureType.Giant,
		15, 138, "12d12 + 60", 40, new[] { 23, 9, 21, 9, 10, 12 }, 8m, 3900, 3, 13,
		new Text(
			"Gigante del gelo",
			null,
			"Gigante Enorme, neutrale malvagio",
			"15 (armatura rappezzata)",
			"12 m",
			"Car +4, Cos +8, Sag +3",
			"Atletica +9, Percezione +3",
			"",
			"",
			"freddo",
			"",
			"Percezione passiva 13",
			"Gigante",
			"",
			"***Multiattacco.*** Il gigante effettua due attacchi con l'ascia bipenne.\n\n***Ascia bipenne.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 25 (3d12 + 6) danni taglienti.\n\n***Roccia.*** *Attacco con arma a distanza:* +9 al tiro per colpire, gittata 18/72 m, un bersaglio. *Colpito:* 28 (4d10 + 6) danni contundenti.",
			"",
			""),
		new Text(
			"Frost Giant",
			null,
			"Huge giant, neutral evil",
			"15",
			"40 ft.",
			"Con +8, Wis +3, Cha +4",
			"Athletics +9, Perception +3",
			"",
			"",
			"cold",
			"",
			"passive Perception 13",
			"Giant",
			"",
			"***Multiattack.*** The giant makes two greataxe attacks.\n\n***Greataxe.*** *Melee Weapon Attack:* +9 to hit, reach 10 ft., one target. *Hit:* 25 (3d12 + 6) slashing damage.\n\n***Rock.*** *Ranged Weapon Attack:* +9 to hit, range 60/240 ft., one target. *Hit:* 28 (4d10 + 6) bludgeoning damage.",
			"",
			""));
}
