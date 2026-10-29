using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Rat (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Rat2014Seeder
{
	public static Monster Build() => Create("rat", null, ContentSource.Srd51, CreatureSize.Tiny, CreatureType.Beast,
		10, 1, "1d4 - 1", 20, new[] { 2, 11, 9, 2, 10, 4 }, 0m, 10, 2, 10,
		new Text(
			"Topo",
			null,
			"Bestia Minuscola, senza allineamento",
			"10",
			"6 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 9 m",
			"—",
			"***Olfatto acuto.*** Il topo dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Morso.*** *Attacco con arma da mischia:* +0 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno perforante.",
			"",
			"",
			"",
			""),
		new Text(
			"Rat",
			null,
			"Tiny beast, unaligned",
			"10",
			"20 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 30 ft., passive Perception 10",
			"—",
			"***Keen Smell.*** The rat has advantage on Wisdom (Perception) checks that rely on smell.",
			"***Bite.*** *Melee Weapon Attack:* +0 to hit, reach 5 ft., one target. *Hit:* 1 piercing damage.",
			"",
			"",
			"",
			""));
}
