using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Killer Whale (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class KillerWhale2014Seeder
{
	public static Monster Build() => Create("killer-whale", null, CreatureSize.Huge, CreatureType.Beast,
		12, 90, "12d12 + 12", 0, new[] { 19, 10, 13, 3, 12, 7 }, 3m, 700, 2, 13,
		new Text(
			"Orca assassina",
			null,
			"Bestia Enorme, senza allineamento",
			"12 (armatura naturale)",
			"0 m, nuotare 18 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, vista cieca 36 m",
			"—",
			"***Apnea.*** L'orca può trattenere il respiro per 30 minuti.\n\n***Senso radar.*** L'orca non può usare vista cieca se è assordata.\n\n***Udito acuto.*** L'orca dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 21 (5d6 + 4) danni perforanti.",
			"",
			""),
		new Text(
			"Killer Whale",
			null,
			"Huge beast, unaligned",
			"12 (natural armor)",
			"0 ft., swim 60 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"blindsight 120 ft., passive Perception 13",
			"—",
			"***Echolocation.*** The whale can't use its blindsight while deafened.\n\n***Hold Breath.*** The whale can hold its breath for 30 minutes\n\n***Keen Hearing.*** The whale has advantage on Wisdom (Perception) checks that rely on hearing.",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 21 (5d6 + 4) piercing damage.",
			"",
			""));
}
