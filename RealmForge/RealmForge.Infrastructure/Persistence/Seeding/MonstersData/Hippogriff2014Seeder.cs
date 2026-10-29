using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Hippogriff (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Hippogriff2014Seeder
{
	public static Monster Build() => Create("hippogriff", null, CreatureSize.Large, CreatureType.Monstrosity,
		11, 19, "3d10 + 3", 40, new[] { 17, 13, 13, 2, 12, 8 }, 1m, 200, 2, 15,
		new Text(
			"Ippogrifo",
			null,
			"Mostruosità Grande, senza allineamento",
			"11",
			"12 m, volare 18 m",
			"",
			"Percezione +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 15",
			"—",
			"***Vista acuta.*** L'ippogrifo dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Multiattacco.*** L'ippogrifo effettua due attacchi: uno con il becco e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni taglienti.\n\n***Becco.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d10 + 3) danni perforanti.",
			"",
			""),
		new Text(
			"Hippogriff",
			null,
			"Large monstrosity, unaligned",
			"11",
			"40 ft., fly 60 ft.",
			"",
			"Perception +5",
			"",
			"",
			"",
			"",
			"passive Perception 15",
			"—",
			"***Keen Sight.*** The hippogriff has advantage on Wisdom (Perception) checks that rely on sight.",
			"***Multiattack.*** The hippogriff makes two attacks: one with its beak and one with its claws.\n\n***Beak.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 8 (1d10 + 3) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) slashing damage.",
			"",
			""));
}
