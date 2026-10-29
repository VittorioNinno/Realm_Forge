using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hawk (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Hawk2014Seeder
{
	public static Monster Build() => Create("hawk", null, ContentSource.Srd51, CreatureSize.Tiny, CreatureType.Beast,
		13, 1, "1d4 - 1", 10, new[] { 5, 16, 8, 2, 14, 6 }, 0m, 10, 2, 14,
		new Text(
			"Falco",
			null,
			"Bestia Minuscola, senza allineamento",
			"13",
			"3 m, volare 18 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"—",
			"***Vista acuta.*** Il falco dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Artigli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno tagliente.",
			"",
			"",
			"",
			""),
		new Text(
			"Hawk",
			null,
			"Tiny beast, unaligned",
			"13",
			"10 ft., fly 60 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"—",
			"***Keen Sight.*** The hawk has advantage on Wisdom (Perception) checks that rely on sight.",
			"***Talons.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 1 slashing damage.",
			"",
			"",
			"",
			""));
}
