using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Blood Hawk (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BloodHawk2014Seeder
{
	public static Monster Build() => Create("blood-hawk", null, CreatureSize.Small, CreatureType.Beast,
		12, 7, "2d6", 10, new[] { 6, 14, 10, 3, 14, 5 }, 0.125m, 25, 2, 14,
		new Text(
			"Falco di sangue",
			null,
			"Bestia Piccola, senza allineamento",
			"12",
			"3 m, volare 18 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"—",
			"***Tattiche del branco.*** Il falco dispone di vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati dell'animale si trova entro 1,5 metri dalla creatura e non è incapacitato.\n\n***Vista acuta.*** Il falco dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Becco.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti.",
			"",
			""),
		new Text(
			"Blood Hawk",
			null,
			"Small beast, unaligned",
			"12",
			"10 ft., fly 60 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"—",
			"***Keen Sight.*** The hawk has advantage on Wisdom (Perception) checks that rely on sight.\n\n***Pack Tactics.*** The hawk has advantage on an attack roll against a creature if at least one of the hawk's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Beak.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage.",
			"",
			""));
}
