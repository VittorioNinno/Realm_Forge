using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Cat (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Cat2014Seeder
{
	public static Monster Build() => Create("cat", null, CreatureSize.Tiny, CreatureType.Beast,
		12, 2, "1d4", 40, new[] { 3, 15, 10, 3, 12, 7 }, 0m, 10, 2, 13,
		new Text(
			"Gatto",
			null,
			"Bestia Minuscola, senza allineamento",
			"12",
			"12 m, scalare 9 m",
			"",
			"Furtività +4, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Olfatto acuto.*** Il gatto dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Artigli.*** *Attacco con arma da mischia:* +0 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno tagliente.",
			"",
			""),
		new Text(
			"Cat",
			null,
			"Tiny beast, unaligned",
			"12",
			"40 ft., climb 30 ft.",
			"",
			"Perception +3, Stealth +4",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Smell.*** The cat has advantage on Wisdom (Perception) checks that rely on smell.",
			"***Claws.*** *Melee Weapon Attack:* +0 to hit, reach 5 ft., one target. *Hit:* 1 slashing damage.",
			"",
			""));
}
