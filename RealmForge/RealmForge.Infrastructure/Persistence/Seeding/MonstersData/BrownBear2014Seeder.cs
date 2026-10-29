using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Brown Bear (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BrownBear2014Seeder
{
	public static Monster Build() => Create("brown-bear", null, CreatureSize.Large, CreatureType.Beast,
		11, 34, "4d10 + 12", 40, new[] { 19, 10, 16, 2, 13, 7 }, 1m, 200, 2, 13,
		new Text(
			"Orso bruno",
			null,
			"Bestia Grande, senza allineamento",
			"11 (armatura naturale)",
			"12 m, scalare 9 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Olfatto acuto.*** L'orso dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Multiattacco.*** L'orso effettua due attacchi: uno con il morso e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d8 + 4) danni perforanti.",
			"",
			""),
		new Text(
			"Brown Bear",
			null,
			"Large beast, unaligned",
			"11 (natural armor)",
			"40 ft., climb 30 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Smell.*** The bear has advantage on Wisdom (Perception) checks that rely on smell.",
			"***Multiattack.*** The bear makes two attacks: one with its bite and one with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 8 (1d8 + 4) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.",
			"",
			""));
}
