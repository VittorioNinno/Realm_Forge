using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Polar Bear (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class PolarBear2014Seeder
{
	public static Monster Build() => Create("polar-bear", null, CreatureSize.Large, CreatureType.Beast,
		12, 42, "5d10 + 15", 40, new[] { 20, 10, 16, 2, 13, 7 }, 2m, 450, 2, 13,
		new Text(
			"Orso polare",
			null,
			"Bestia Grande, senza allineamento",
			"12 (armatura naturale)",
			"12 m, nuotare 9 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Olfatto acuto.*** L'orso dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Multiattacco.*** L'orso effettua due attacchi: uno con il morso e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (1d8 + 5) danni perforanti.",
			"",
			""),
		new Text(
			"Polar Bear",
			null,
			"Large beast, unaligned",
			"12 (natural armor)",
			"40 ft., swim 30 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Smell.*** The bear has advantage on Wisdom (Perception) checks that rely on smell.",
			"***Multiattack.*** The bear makes two attacks: one with its bite and one with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 9 (1d8 + 5) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 12 (2d6 + 5) slashing damage.",
			"",
			""));
}
