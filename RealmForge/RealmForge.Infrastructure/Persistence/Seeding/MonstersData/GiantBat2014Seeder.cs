using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Bat (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantBat2014Seeder
{
	public static Monster Build() => Create("giant-bat", null, CreatureSize.Large, CreatureType.Beast,
		13, 22, "4d10", 10, new[] { 15, 16, 11, 2, 12, 6 }, 0.25m, 50, 2, 11,
		new Text(
			"Pipistrello gigante",
			null,
			"Bestia Grande, senza allineamento",
			"13",
			"3 m, volare 18 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, vista cieca 18 m",
			"—",
			"***Senso radar.*** Il pipistrello non può usare vista cieca se è assordato.\n\n***Udito acuto.*** Il pipistrello dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			""),
		new Text(
			"Giant Bat",
			null,
			"Large beast, unaligned",
			"13",
			"10 ft., fly 60 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"blindsight 60 ft., passive Perception 11",
			"—",
			"***Echolocation.*** The bat can't use its blindsight while deafened.\n\n***Keen Hearing.*** The bat has advantage on Wisdom (Perception) checks that rely on hearing.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 5 (1d6 + 2) piercing damage.",
			"",
			""));
}
