using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Zombie (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Zombie2014Seeder
{
	public static Monster Build() => Create("zombie", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Undead,
		8, 22, "3d8 + 9", 20, new[] { 13, 6, 16, 3, 6, 5 }, 0.25m, 50, 2, 8,
		new Text(
			"Zombi",
			null,
			"Non morto Medio, neutrale malvagio",
			"8",
			"6 m",
			"Sag +0",
			"",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 8, scurovisione 18 m",
			"capisce quelli che conosceva in vita, ma non è in grado di parlarli",
			"***Tempra dei non morti.*** Se i danni riducono lo zombi a 0 punti ferita, esso deve effettuare un tiro salvezza su Costituzione con una CD pari a 5 + i danni subiti, a meno che non si tratti di danni radiosi o di un colpo critico. In caso di successo, lo zombi scende invece a 1 punto ferita.",
			"***Schianto.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Zombie",
			null,
			"Medium undead, neutral evil",
			"8",
			"20 ft.",
			"Wis +0",
			"",
			"",
			"",
			"poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 8",
			"understands all languages it spoke in life but can't speak",
			"***Undead Fortitude.*** If damage reduces the zombie to 0 hit points, it must make a Constitution saving throw with a DC of 5+the damage taken, unless the damage is radiant or from a critical hit. On a success, the zombie drops to 1 hit point instead.",
			"***Slam.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 4 (1d6 + 1) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
