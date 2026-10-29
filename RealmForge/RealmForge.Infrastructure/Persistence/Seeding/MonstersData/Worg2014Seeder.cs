using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Worg (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Worg2014Seeder
{
	public static Monster Build() => Create("worg", null, CreatureSize.Large, CreatureType.Monstrosity,
		13, 26, "4d10 + 4", 50, new[] { 16, 13, 13, 7, 11, 8 }, 0.5m, 100, 2, 14,
		new Text(
			"Worg",
			null,
			"Mostruosità Grande, neutrale malvagio",
			"13 (armatura naturale)",
			"15 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 18 m",
			"Goblin, Worg",
			"***Udito e olfatto acuti.*** Il worg dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni perforanti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 13, altrimenti cade a terra prono.",
			"",
			""),
		new Text(
			"Worg",
			null,
			"Large monstrosity, neutral evil",
			"13 (natural armor)",
			"50 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 14",
			"Goblin, Worg",
			"***Keen Hearing and Smell.*** The worg has advantage on Wisdom (Perception) checks that rely on hearing or smell.",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) piercing damage. If the target is a creature, it must succeed on a DC 13 Strength saving throw or be knocked prone.",
			"",
			""));
}
