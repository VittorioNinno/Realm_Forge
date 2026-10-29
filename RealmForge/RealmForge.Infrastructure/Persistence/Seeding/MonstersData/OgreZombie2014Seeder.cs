using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ogre Zombie (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class OgreZombie2014Seeder
{
	public static Monster Build() => Create("ogre-zombie", null, CreatureSize.Large, CreatureType.Undead,
		8, 85, "9d10 + 36", 30, new[] { 19, 6, 18, 3, 6, 5 }, 2m, 450, 2, 8,
		new Text(
			"Zombi ogre",
			null,
			"Non morto Grande, neutrale malvagio",
			"8",
			"9 m",
			"Sag +0",
			"",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 8, scurovisione 18 m",
			"capisce il Comune e il Gigante ma non li parla",
			"***Tempra dei non morti.*** Se i danni riducono lo zombi a 0 punti ferita, esso deve effettuare un tiro salvezza su Costituzione con una CD pari a 5 + i danni subiti, a meno che non si tratti di danni radiosi o di un colpo critico. In caso di successo, lo zombi scende invece a 1 punto ferita.",
			"***Mazza chiodata.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni contundenti.",
			"",
			""),
		new Text(
			"Ogre Zombie",
			null,
			"Large undead, neutral evil",
			"8",
			"30 ft.",
			"Wis +0",
			"",
			"",
			"",
			"poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 8",
			"understands Common and Giant but can't speak",
			"***Undead Fortitude.*** If damage reduces the zombie to 0 hit points, it must make a Constitution saving throw with a DC of 5+the damage taken, unless the damage is radiant or from a critical hit. On a success, the zombie drops to 1 hit point instead.",
			"***Morningstar.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) bludgeoning damage.",
			"",
			""));
}
