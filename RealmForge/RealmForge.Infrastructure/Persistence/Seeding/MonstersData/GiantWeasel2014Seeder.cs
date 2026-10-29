using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Weasel (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantWeasel2014Seeder
{
	public static Monster Build() => Create("giant-weasel", null, CreatureSize.Medium, CreatureType.Beast,
		13, 9, "2d8", 40, new[] { 11, 16, 10, 4, 12, 5 }, 0.125m, 25, 2, 13,
		new Text(
			"Faina gigante",
			null,
			"Bestia Media, senza allineamento",
			"13",
			"12 m",
			"",
			"Furtività +5, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, scurovisione 18 m",
			"—",
			"***Udito e olfatto acuti.*** La faina dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d4 + 3) danni perforanti.",
			"",
			""),
		new Text(
			"Giant Weasel",
			null,
			"Medium beast, unaligned",
			"13",
			"40 ft.",
			"",
			"Perception +3, Stealth +5",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 13",
			"—",
			"***Keen Hearing and Smell.*** The weasel has advantage on Wisdom (Perception) checks that rely on hearing or smell.",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 5 (1d4 + 3) piercing damage.",
			"",
			""));
}
