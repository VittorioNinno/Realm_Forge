using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Eagle (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Eagle2014Seeder
{
	public static Monster Build() => Create("eagle", null, CreatureSize.Small, CreatureType.Beast,
		12, 3, "1d6", 10, new[] { 6, 15, 10, 2, 14, 7 }, 0m, 10, 2, 14,
		new Text(
			"Aquila",
			null,
			"Bestia Piccola, senza allineamento",
			"12",
			"3 m, volare 18 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"—",
			"***Vista acuta.*** L'aquila dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Artigli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni taglienti.",
			"",
			""),
		new Text(
			"Eagle",
			null,
			"Small beast, unaligned",
			"12",
			"10 ft., fly 60 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"—",
			"***Keen Sight.*** The eagle has advantage on Wisdom (Perception) checks that rely on sight.",
			"***Talons.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) slashing damage.",
			"",
			""));
}
