using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Peryton (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Peryton2014Seeder
{
	public static Monster Build() => Create("peryton", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Monstrosity,
		13, 33, "6d8 + 6", 20, new[] { 16, 12, 13, 9, 12, 10 }, 2m, 450, 2, 15,
		new Text(
			"Peryton",
			null,
			"Mostruosità Media, caotico malvagio",
			"13 (armatura naturale)",
			"6 m, volare 18 m",
			"",
			"Percezione +5",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"",
			"Percezione passiva 15",
			"capisce il Comune e l'Elfico ma non li parla",
			"***Attacco in picchiata.*** Quando il peryton vola in picchiata per almeno 9 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco con arma da mischia, il colpo infligge 9 (2d8) danni extra.\n\n***Volo radente.*** Il peryton non provoca attacchi di opportunità quando esce in volo dalla portata di un nemico.\n\n***Vista e olfatto acuti.*** Il peryton dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista o sull'olfatto.",
			"***Multiattacco.*** Il peryton effettua un attacco di incornata e uno con gli artigli.\n\n***Incornata.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni perforanti.\n\n***Artigli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (2d4 + 3) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Peryton",
			null,
			"Medium monstrosity, chaotic evil",
			"13 (natural armor)",
			"20 ft., fly 60 ft.",
			"",
			"Perception +5",
			"",
			"bludgeoning, piercing, and slashing from nonmagical attacks",
			"",
			"",
			"passive Perception 15",
			"understands Common and Elvish but can't speak",
			"***Dive Attack.*** When the peryton flies at least 30 feet straight toward a target while diving and then hits it with a melee weapon attack, the hit deals an extra 9 (2d8) damage.\n\n***Flyby.*** The peryton doesn't provoke opportunity attacks when it flies out of an enemy's reach.\n\n***Keen Sight and Smell.*** The peryton has advantage on Wisdom (Perception) checks that rely on sight or smell.",
			"***Multiattack.*** The peryton makes one gore attack and one talon attack.\n\n***Gore.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) piercing damage.\n\n***Talons.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 8 (2d4 + 3) piercing damage.",
			"",
			"",
			"",
			""));
}
