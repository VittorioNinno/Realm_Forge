using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Bat (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Bat2014Seeder
{
	public static Monster Build() => Create("bat", null, CreatureSize.Tiny, CreatureType.Beast,
		12, 1, "1d4 - 1", 5, new[] { 2, 15, 8, 2, 12, 4 }, 0m, 10, 2, 11,
		new Text(
			"Pipistrello",
			null,
			"Bestia Minuscola, senza allineamento",
			"12",
			"1,5 m, volare 9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, vista cieca 18 m",
			"—",
			"***Senso radar.*** Il pipistrello non può usare vista cieca se è assordato.\n\n***Udito acuto.*** Il pipistrello dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +0 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 1 danno perforante.",
			"",
			""),
		new Text(
			"Bat",
			null,
			"Tiny beast, unaligned",
			"12",
			"5 ft., fly 30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"blindsight 60 ft., passive Perception 11",
			"—",
			"***Echolocation.*** The bat can't use its blindsight while deafened.\n\n***Keen Hearing.*** The bat has advantage on Wisdom (Perception) checks that rely on hearing.",
			"***Bite.*** *Melee Weapon Attack:* +0 to hit, reach 5 ft., one creature. *Hit:* 1 piercing damage.",
			"",
			""));
}
