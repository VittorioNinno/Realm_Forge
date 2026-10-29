using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hunter Shark (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class HunterShark2014Seeder
{
	public static Monster Build() => Create("hunter-shark", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		12, 45, "6d10 + 12", 0, new[] { 18, 13, 15, 1, 10, 4 }, 2m, 450, 2, 12,
		new Text(
			"Squalo cacciatore",
			null,
			"Bestia Grande, senza allineamento",
			"12 (armatura naturale)",
			"0 m, nuotare 12 m",
			"",
			"Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, vista cieca 9 m",
			"—",
			"***Frenesia di sangue.*** Lo squalo dispone di vantaggio ai tiri per colpire in mischia contro ogni creatura che non possieda tutti i propri punti ferita.\n\n***Respirare sott'acqua.*** Lo squalo può respirare soltanto sott'acqua.",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Hunter Shark",
			null,
			"Large beast, unaligned",
			"12",
			"0 ft., swim 40 ft.",
			"",
			"Perception +2",
			"",
			"",
			"",
			"",
			"darkvision 30 ft., passive Perception 12",
			"—",
			"***Blood Frenzy.*** The shark has advantage on melee attack rolls against any creature that doesn't have all its hit points.\n\n***Water Breathing.*** The shark can breathe only underwater.",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) piercing damage.",
			"",
			"",
			"",
			""));
}
