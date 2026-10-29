using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Reef Shark (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class ReefShark2014Seeder
{
	public static Monster Build() => Create("reef-shark", null, CreatureSize.Medium, CreatureType.Beast,
		12, 22, "4d8 + 4", 0, new[] { 14, 13, 13, 1, 10, 4 }, 0.5m, 100, 2, 12,
		new Text(
			"Squalo tropicale",
			null,
			"Bestia Media, senza allineamento",
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
			"***Respirare sott'acqua.*** Lo squalo può respirare soltanto sott'acqua.\n\n***Tattiche del branco.*** Lo squalo dispone di vantaggio a un tiro per colpire contro una creatura se almeno uno degli alleati dello squalo si trova entro 1,5 metri dalla creatura e non è incapacitato.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti.",
			"",
			""),
		new Text(
			"Reef Shark",
			null,
			"Medium beast, unaligned",
			"12 (natural armor)",
			"0 ft., swim 40 ft.",
			"",
			"Perception +2",
			"",
			"",
			"",
			"",
			"blindsight 30 ft., passive Perception 12",
			"—",
			"***Pack Tactics.*** The shark has advantage on an attack roll against a creature if at least one of the shark's allies is within 5 ft. of the creature and the ally isn't incapacitated.\n\n***Water Breathing.*** The shark can breathe only underwater.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage.",
			"",
			""));
}
