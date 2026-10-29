using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Satyr (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Satyr2014Seeder
{
	public static Monster Build() => Create("satyr", null, CreatureSize.Medium, CreatureType.Fey,
		14, 31, "7d8", 40, new[] { 12, 16, 11, 12, 10, 14 }, 0.5m, 100, 2, 12,
		new Text(
			"Satiro",
			null,
			"Folletto Medio, caotico neutrale",
			"14 (armatura di cuoio)",
			"12 m",
			"",
			"Furtività +5, Intrattenere +6, Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12",
			"Comune, Elfico, Silvano",
			"***Resistenza alla magia.*** Il satiro dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Sfondamento.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (2d4 + 1) danni contundenti.\n\n***Spada corta.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.\n\n***Arco corto.*** *Attacco con arma a distanza:* +5 al tiro per colpire, gittata 24/96 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.",
			"",
			""),
		new Text(
			"Satyr",
			null,
			"Medium fey, chaotic neutral",
			"14 (leather armor)",
			"40 ft.",
			"",
			"Perception +2, Performance +6, Stealth +5",
			"",
			"",
			"",
			"",
			"passive Perception 12",
			"Common, Elvish, Sylvan",
			"***Magic Resistance.*** The satyr has advantage on saving throws against spells and other magical effects.",
			"***Ram.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 6 (2d4 + 1) bludgeoning damage.\n\n***Shortsword.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.\n\n***Shortbow.*** *Ranged Weapon Attack:* +5 to hit, range 80/320 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.",
			"",
			""));
}
