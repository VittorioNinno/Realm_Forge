using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Mastiff (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Mastiff2014Seeder
{
	public static Monster Build() => Create("mastiff", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		12, 5, "1d8 + 1", 40, new[] { 13, 14, 12, 3, 12, 7 }, 0.125m, 25, 2, 13,
		new Text(
			"Mastino",
			null,
			"Bestia Media, senza allineamento",
			"12",
			"12 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Udito e olfatto acuti.*** Il mastino dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 11, altrimenti cade a terra prono.",
			"",
			"",
			"",
			""),
		new Text(
			"Mastiff",
			null,
			"Medium beast, unaligned",
			"12",
			"40 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Hearing and Smell.*** The mastiff has advantage on Wisdom (Perception) checks that rely on hearing or smell.",
			"***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage. If the target is a creature, it must succeed on a DC 11 Strength saving throw or be knocked prone.",
			"",
			"",
			"",
			""));
}
