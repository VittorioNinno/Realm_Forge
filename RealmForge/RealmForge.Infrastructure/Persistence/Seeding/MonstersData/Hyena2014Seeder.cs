using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hyena (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Hyena2014Seeder
{
	public static Monster Build() => Create("hyena", null, CreatureSize.Medium, CreatureType.Beast,
		11, 5, "1d8 + 1", 50, new[] { 11, 13, 12, 2, 12, 5 }, 0m, 10, 2, 13,
		new Text(
			"Iena",
			null,
			"Bestia Media, senza allineamento",
			"11",
			"15 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Tattiche del branco.*** La iena dispone di vantaggio a un tiro per colpire contro una creatura se almeno uno degli alleati dell'animale si trova entro 1,5 metri dalla creatura e non è incapacitato.",
			"***Morso.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d6) danni perforanti.",
			"",
			""),
		new Text(
			"Hyena",
			null,
			"Medium beast, unaligned",
			"11",
			"50 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Pack Tactics.*** The hyena has advantage on an attack roll against a creature if at least one of the hyena's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Bite.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 3 (1d6) piercing damage.",
			"",
			""));
}
