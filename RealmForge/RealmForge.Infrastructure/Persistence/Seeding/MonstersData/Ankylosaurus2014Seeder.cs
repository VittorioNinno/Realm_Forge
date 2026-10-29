using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ankylosaurus (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Ankylosaurus2014Seeder
{
	public static Monster Build() => Create("ankylosaurus", null, ContentSource.RealmForge, CreatureSize.Huge, CreatureType.Beast,
		15, 68, "8d12 + 16", 30, new[] { 19, 11, 15, 2, 12, 5 }, 3m, 700, 2, 11,
		new Text(
			"Anchilosauro",
			null,
			"Bestia Enorme, senza allineamento",
			"15 (armatura naturale)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11",
			"—",
			"",
			"***Coda.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 18 (4d6 + 4) danni contundenti. Una creatura colpita deve superare un tiro salvezza su Forza con CD 14, altrimenti cade prona.",
			"",
			"",
			"",
			""),
		new Text(
			"Ankylosaurus",
			null,
			"Huge beast, unaligned",
			"15 (natural armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 11",
			"—",
			"",
			"***Tail.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 18 (4d6 + 4) bludgeoning damage. A creature hit must succeed on a DC 14 Strength saving throw or be knocked prone.",
			"",
			"",
			"",
			""));
}
