using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Baboon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Baboon2014Seeder
{
	public static Monster Build() => Create("baboon", null, CreatureSize.Small, CreatureType.Beast,
		12, 3, "1d6", 30, new[] { 8, 14, 11, 4, 12, 6 }, 0m, 10, 2, 11,
		new Text(
			"Babbuino",
			null,
			"Bestia Piccola, senza allineamento",
			"12",
			"9 m, scalare 9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11",
			"—",
			"***Tattiche del branco.*** Il babbuino dispone di un vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati del babbuino si trova entro 1,5 metri dalla creatura e non è incapacitato.",
			"***Morso.*** *Attacco con arma da mischia:* +1 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 (1d4 - 1) danni perforanti.",
			"",
			""),
		new Text(
			"Baboon",
			null,
			"Small beast, unaligned",
			"12",
			"30 ft., climb 30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 11",
			"—",
			"***Pack Tactics.*** The baboon has advantage on an attack roll against a creature if at least one of the baboon's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Bite.*** *Melee Weapon Attack:* +1 to hit, reach 5 ft., one target. *Hit:* 1 (1d4 - 1) piercing damage.",
			"",
			""));
}
