using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Weasel (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Weasel2014Seeder
{
	public static Monster Build() => Create("weasel", null, ContentSource.Srd51, CreatureSize.Tiny, CreatureType.Beast,
		13, 1, "1d4 - 1", 30, new[] { 3, 16, 8, 2, 12, 3 }, 0m, 10, 2, 13,
		new Text(
			"Faina",
			null,
			"Bestia Minuscola, senza allineamento",
			"13",
			"9 m",
			"",
			"Furtività +5, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Udito e olfatto acuti.*** La faina dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno perforante.",
			"",
			"",
			"",
			""),
		new Text(
			"Weasel",
			null,
			"Tiny beast, unaligned",
			"13",
			"30 ft.",
			"",
			"Perception +3, Stealth +5",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Hearing and Smell.*** The weasel has advantage on Wisdom (Perception) checks that rely on hearing or smell.",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* 1 piercing damage.",
			"",
			"",
			"",
			""));
}
