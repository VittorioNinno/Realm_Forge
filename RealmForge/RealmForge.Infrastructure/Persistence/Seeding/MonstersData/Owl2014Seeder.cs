using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Owl (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Owl2014Seeder
{
	public static Monster Build() => Create("owl", null, CreatureSize.Tiny, CreatureType.Beast,
		11, 1, "1d4 - 1", 5, new[] { 3, 13, 8, 2, 12, 7 }, 0m, 10, 2, 13,
		new Text(
			"Gufo",
			null,
			"Bestia Minuscola, senza allineamento",
			"11",
			"1,5 m, volare 18 m",
			"",
			"Furtività +3, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, scurovisione 36 m",
			"—",
			"***Sfuggente.*** Il gufo non provoca attacchi d'opportunità quando vola oltre la portata di un nemico.\n\n***Udito e vista acuti.*** Il gufo dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista o sull'udito.",
			"***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno tagliente.",
			"",
			""),
		new Text(
			"Owl",
			null,
			"Tiny beast, unaligned",
			"11",
			"5 ft., fly 60 ft.",
			"",
			"Perception +3, Stealth +3",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 13",
			"—",
			"***Flyby.*** The owl doesn't provoke opportunity attacks when it flies out of an enemy's reach.\n\n***Keen Hearing and Sight.*** The owl has advantage on Wisdom (Perception) checks that rely on hearing or sight.",
			"***Talons.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 1 slashing damage.",
			"",
			""));
}
