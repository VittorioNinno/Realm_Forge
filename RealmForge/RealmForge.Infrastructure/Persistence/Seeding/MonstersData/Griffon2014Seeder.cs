using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Griffon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Griffon2014Seeder
{
	public static Monster Build() => Create("griffon", null, CreatureSize.Large, CreatureType.Monstrosity,
		12, 59, "7d10 + 21", 30, new[] { 18, 15, 16, 2, 13, 8 }, 2m, 450, 2, 15,
		new Text(
			"Grifone",
			null,
			"Mostruosità Grande, senza allineamento",
			"12",
			"9 m, volare 24 m",
			"",
			"Percezione +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 15, scurovisione 18 m",
			"—",
			"***Vista acuta.*** Il grifone dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Multiattacco.*** Il grifone effettua due attacchi: uno con il becco e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Becco.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d8 + 4) danni perforanti.",
			"",
			""),
		new Text(
			"Griffon",
			null,
			"Large monstrosity, unaligned",
			"12",
			"30 ft., fly 80 ft.",
			"",
			"Perception +5",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 15",
			"—",
			"***Keen Sight.*** The griffon has advantage on Wisdom (Perception) checks that rely on sight.",
			"***Multiattack.*** The griffon makes two attacks: one with its beak and one with its claws.\n\n***Beak.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 8 (1d8 + 4) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.",
			"",
			""));
}
