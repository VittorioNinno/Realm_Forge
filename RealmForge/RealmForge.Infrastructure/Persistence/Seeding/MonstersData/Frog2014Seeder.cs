using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Frog (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Frog2014Seeder
{
	public static Monster Build() => Create("frog", null, CreatureSize.Tiny, CreatureType.Beast,
		11, 1, "1d4 - 1", 20, new[] { 1, 13, 8, 1, 8, 3 }, 0m, 0, 2, 11,
		new Text(
			"Rana",
			null,
			"Bestia Minuscola, senza allineamento",
			"11",
			"6 m, nuotare 6 m",
			"",
			"Furtività +3, Percezione +1",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 9 m",
			"—",
			"***Anfibio.*** La rana può respirare in aria e in acqua.\n\n***Balzo da fermo.*** La rana può compiere un salto in lungo di un massimo di 3 metri e uno in alto di un massimo di 1,5 metri, con o senza rincorsa.",
			"",
			"",
			""),
		new Text(
			"Frog",
			null,
			"Tiny beast, unaligned",
			"11",
			"20 ft., swim 20 ft.",
			"",
			"Perception +1, Stealth +3",
			"",
			"",
			"",
			"",
			"darkvision 30 ft., passive Perception 11",
			"—",
			"***Amphibious.*** The frog can breathe air and water\n\n***Standing Leap.*** The frog's long jump is up to 10 ft. and its high jump is up to 5 ft., with or without a running start.",
			"",
			"",
			""));
}
