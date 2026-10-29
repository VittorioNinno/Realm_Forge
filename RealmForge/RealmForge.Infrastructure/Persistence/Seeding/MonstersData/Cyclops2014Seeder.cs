using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Cyclops (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Cyclops2014Seeder
{
	public static Monster Build() => Create("cyclops", null, ContentSource.RealmForge, CreatureSize.Huge, CreatureType.Giant,
		14, 138, "12d12 + 60", 30, new[] { 22, 11, 20, 8, 6, 10 }, 6m, 2300, 3, 8,
		new Text(
			"Ciclope",
			null,
			"Gigante Enorme, caotico neutrale",
			"14 (armatura naturale)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 8",
			"Gigante",
			"***Scarsa percezione della profondità.*** Il ciclope attacca con svantaggio qualsiasi bersaglio che si trovi a più di 9 metri da lui.",
			"***Multiattacco.*** Il ciclope effettua due attacchi con il randello pesante.\n\n***Randello pesante.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 19 (3d8 + 6) danni contundenti.\n\n***Macigno.*** *Attacco con arma a distanza:* +9 al tiro per colpire, gittata 9/36 m, un bersaglio. *Colpito:* 28 (4d10 + 6) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Cyclops",
			null,
			"Huge giant, chaotic neutral",
			"14 (natural armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 8",
			"Giant",
			"***Poor Depth Perception.*** The cyclops attacks with disadvantage any target more than 30 feet away from it.",
			"***Multiattack.*** The cyclops makes two greatclub attacks.\n\n***Greatclub.*** *Melee Weapon Attack:* +9 to hit, reach 10 ft., one target. *Hit:* 19 (3d8 + 6) bludgeoning damage.\n\n***Rock.*** *Ranged Weapon Attack:* +9 to hit, range 30/120 ft., one target. *Hit:* 28 (4d10 + 6) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
