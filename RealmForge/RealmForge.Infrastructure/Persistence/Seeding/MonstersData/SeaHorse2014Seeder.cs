using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Sea Horse (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SeaHorse2014Seeder
{
	public static Monster Build() => Create("sea-horse", null, ContentSource.Srd51, CreatureSize.Tiny, CreatureType.Beast,
		11, 1, "1d4 - 1", 0, new[] { 1, 12, 8, 1, 10, 2 }, 0m, 0, 2, 10,
		new Text(
			"Cavalluccio marino",
			null,
			"Bestia Minuscola, senza allineamento",
			"11",
			"0 m, nuotare 6 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"***Respirare sott'acqua.*** Il cavalluccio marino può respirare soltanto sott'acqua.",
			"",
			"",
			"",
			"",
			""),
		new Text(
			"Sea Horse",
			null,
			"Tiny beast, unaligned",
			"11",
			"0 ft., swim 20 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"***Water Breathing.*** The sea horse can breathe only underwater.",
			"",
			"",
			"",
			"",
			""));
}
