using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Eagle (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantEagle2014Seeder
{
	public static Monster Build() => Create("giant-eagle", null, CreatureSize.Large, CreatureType.Beast,
		13, 26, "4d10 + 4", 10, new[] { 16, 17, 13, 8, 14, 10 }, 1m, 200, 2, 14,
		new Text(
			"Aquila gigante",
			null,
			"Bestia Grande, neutrale buona",
			"13",
			"3 m, volare 24 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"Aquila Gigante, capisce il Comune e l'Auran ma non li parla",
			"***Vista acuta.*** L'aquila dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Multiattacco.*** L'aquila effettua due attacchi: uno con il becco e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni taglienti.\n\n***Becco.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.",
			"",
			""),
		new Text(
			"Giant Eagle",
			null,
			"Large beast, neutral good",
			"13",
			"10 ft., fly 80 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"Giant Eagle, understands Common and Auran but can't speak",
			"***Keen Sight.*** The eagle has advantage on Wisdom (Perception) checks that rely on sight.",
			"***Multiattack.*** The eagle makes two attacks: one with its beak and one with its talons.\n\n***Beak.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.\n\n***Talons.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) slashing damage.",
			"",
			""));
}
