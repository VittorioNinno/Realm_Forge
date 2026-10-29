using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ape (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Ape2014Seeder
{
	public static Monster Build() => Create("ape", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		12, 19, "3d8 + 6", 30, new[] { 16, 14, 14, 6, 12, 7 }, 0.5m, 100, 2, 13,
		new Text(
			"Gorilla",
			null,
			"Bestia Media, senza allineamento",
			"12",
			"9 m, scalare 9 m",
			"",
			"Atletica +5, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"",
			"***Multiattacco.*** Il gorilla effettua due attacchi con i pugni.\n\n***Pugno.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni contundenti.\n\n***Roccia.*** *Attacco con arma a distanza:* +5 al tiro per colpire, gittata 7,5/15 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Ape",
			null,
			"Medium beast, unaligned",
			"12",
			"30 ft., climb 30 ft.",
			"",
			"Athletics +5, Perception +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"",
			"***Multiattack.*** The ape makes two fist attacks.\n\n***Fist.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) bludgeoning damage.\n\n***Rock.*** *Ranged Weapon Attack:* +5 to hit, range 25/50 ft., one target. *Hit:* 6 (1d6 + 3) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
