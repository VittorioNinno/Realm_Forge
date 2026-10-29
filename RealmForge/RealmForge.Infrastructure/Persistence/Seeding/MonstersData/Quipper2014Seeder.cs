using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Quipper (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Quipper2014Seeder
{
	public static Monster Build() => Create("quipper", null, CreatureSize.Tiny, CreatureType.Beast,
		13, 1, "1d4 - 1", 0, new[] { 2, 16, 9, 1, 7, 2 }, 0m, 10, 2, 8,
		new Text(
			"Quipper",
			null,
			"Bestia Minuscola, senza allineamento",
			"13",
			"0 m, nuotare 12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 8, scurovisione 18 m",
			"—",
			"***Frenesia di sangue.*** Il quipper dispone di vantaggio ai tiri per colpire in mischia contro ogni creatura che non possieda tutti i propri punti ferita.\n\n***Respirare sott'acqua.*** Il quipper può respirare soltanto sott'acqua.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno perforante.",
			"",
			""),
		new Text(
			"Quipper",
			null,
			"Tiny beast, unaligned",
			"13",
			"0 ft., swim 40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 8",
			"—",
			"***Blood Frenzy.*** The quipper has advantage on melee attack rolls against any creature that doesn't have all its hit points.\n\n***Water Breathing.*** The quipper can breathe only underwater.",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 1 piercing damage.",
			"",
			""));
}
