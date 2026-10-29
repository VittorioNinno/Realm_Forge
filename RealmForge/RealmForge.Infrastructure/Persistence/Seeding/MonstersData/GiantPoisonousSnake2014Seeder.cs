using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Poisonous Snake (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantPoisonousSnake2014Seeder
{
	public static Monster Build() => Create("giant-poisonous-snake", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		14, 11, "2d8 + 2", 30, new[] { 10, 18, 13, 2, 10, 3 }, 0.25m, 50, 2, 12,
		new Text(
			"Serpente velenoso gigante",
			null,
			"Bestia Media, senza allineamento",
			"14",
			"9 m, nuotare 9 m",
			"",
			"Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, vista cieca 3 m",
			"—",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 6 (1d4 + 4) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 11 subendo 10 (3d6) danni da veleno in caso di fallimento, o la metà in caso di successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Poisonous Snake",
			null,
			"Medium beast, unaligned",
			"14",
			"30 ft., swim 30 ft.",
			"",
			"Perception +2",
			"",
			"",
			"",
			"",
			"blindsight 10 ft., passive Perception 12",
			"—",
			"",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one target. *Hit:* 6 (1d4 + 4) piercing damage, and the target must make a DC 11 Constitution saving throw, taking 10 (3d6) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
