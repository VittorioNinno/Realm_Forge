using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Badger (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Badger2014Seeder
{
	public static Monster Build() => Create("badger", null, CreatureSize.Tiny, CreatureType.Beast,
		10, 3, "1d4 + 1", 20, new[] { 4, 11, 12, 2, 12, 5 }, 0m, 10, 2, 11,
		new Text(
			"Tasso",
			null,
			"Bestia Minuscola, senza allineamento",
			"10",
			"6 m, scavare 1,5 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 9 m",
			"—",
			"***Olfatto acuto.*** Il tasso dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Morso.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno perforante.",
			"",
			""),
		new Text(
			"Badger",
			null,
			"Tiny beast, unaligned",
			"10",
			"20 ft., burrow 5 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 30 ft., passive Perception 11",
			"—",
			"***Keen Smell.*** The badger has advantage on Wisdom (Perception) checks that rely on smell.",
			"***Bite.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 1 piercing damage.",
			"",
			""));
}
