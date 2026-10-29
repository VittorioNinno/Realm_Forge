using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Ape (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantApe2014Seeder
{
	public static Monster Build() => Create("giant-ape", null, ContentSource.Srd51, CreatureSize.Huge, CreatureType.Beast,
		12, 157, "15d12 + 60", 40, new[] { 23, 14, 18, 7, 12, 7 }, 7m, 2900, 3, 14,
		new Text(
			"Gorilla gigante",
			null,
			"Bestia Enorme, senza allineamento",
			"12",
			"12 m, scalare 12 m",
			"",
			"Atletica +9, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"—",
			"",
			"***Multiattacco.*** Il gorilla effettua due attacchi con i pugni.\n\n***Pugno.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 22 (3d10 + 6) danni contundenti.\n\n***Roccia.*** *Attacco con arma a distanza:* +9 al tiro per colpire, gittata 15/30 m, un bersaglio. *Colpito:* 30 (7d6 + 6) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Ape",
			null,
			"Huge beast, unaligned",
			"12",
			"40 ft., climb 40 ft.",
			"",
			"Athletics +9, Perception +4",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"—",
			"",
			"***Multiattack.*** The ape makes two fist attacks.\n\n***Fist.*** *Melee Weapon Attack:* +9 to hit, reach 10 ft., one target. *Hit:* 22 (3d10 + 6) bludgeoning damage.\n\n***Rock.*** *Ranged Weapon Attack:* +9 to hit, range 50/100 ft., one target. *Hit:* 30 (7d6 + 6) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
