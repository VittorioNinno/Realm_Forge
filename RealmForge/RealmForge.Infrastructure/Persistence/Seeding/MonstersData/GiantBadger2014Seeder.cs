using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Badger (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantBadger2014Seeder
{
	public static Monster Build() => Create("giant-badger", null, CreatureSize.Medium, CreatureType.Beast,
		10, 13, "2d8 + 4", 30, new[] { 13, 10, 15, 2, 12, 5 }, 0.25m, 50, 2, 11,
		new Text(
			"Tasso gigante",
			null,
			"Bestia Media, senza allineamento",
			"10",
			"9 m, scavare 3 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 9 m",
			"—",
			"***Olfatto acuto.*** Il tasso dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Multiattacco.*** Il tasso effettua due attacchi: uno con il morso e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (2d4 + 1) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti.",
			"",
			""),
		new Text(
			"Giant Badger",
			null,
			"Medium beast, unaligned",
			"10",
			"30 ft., burrow 10 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 30 ft., passive Perception 11",
			"—",
			"***Keen Smell.*** The badger has advantage on Wisdom (Perception) checks that rely on smell.",
			"***Multiattack.*** The badger makes two attacks: one with its bite and one with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 6 (2d4 + 1) slashing damage.",
			"",
			""));
}
