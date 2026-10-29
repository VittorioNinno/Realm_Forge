using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Shark (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantShark2014Seeder
{
	public static Monster Build() => Create("giant-shark", null, ContentSource.Srd51, CreatureSize.Huge, CreatureType.Beast,
		13, 126, "11d12 + 55", 0, new[] { 23, 11, 21, 1, 10, 5 }, 5m, 1800, 3, 13,
		new Text(
			"Squalo gigante",
			null,
			"Bestia Enorme, senza allineamento",
			"13 (armatura naturale)",
			"0 m, nuotare 15 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, vista cieca 18 m",
			"—",
			"***Frenesia di sangue.*** Lo squalo dispone di vantaggio ai tiri per colpire in mischia contro ogni creatura che non possieda tutti i propri punti ferita.\n\n***Respirare sott'acqua.*** Lo squalo può respirare soltanto sott'acqua.",
			"***Morso.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 22 (3d10 + 6) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Shark",
			null,
			"Huge beast, unaligned",
			"13 (natural armor)",
			"0 ft., swim 50 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"blindsight 60 ft., passive Perception 13",
			"—",
			"***Blood Frenzy.*** The shark has advantage on melee attack rolls against any creature that doesn't have all its hit points.\n\n***Water Breathing.*** The shark can breathe only underwater.",
			"***Bite.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 22 (3d10 + 6) piercing damage.",
			"",
			"",
			"",
			""));
}
