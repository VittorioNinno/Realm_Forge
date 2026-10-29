using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Aarakocra (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Aarakocra2014Seeder
{
	public static Monster Build() => Create("aarakocra", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		12, 13, "3d8", 20, new[] { 10, 14, 10, 11, 12, 11 }, 0.25m, 50, 2, 15,
		new Text(
			"Aarakocra",
			null,
			"Umanoide Medio (aarakocra), neutrale buono",
			"12",
			"6 m, volare 15 m",
			"",
			"Percezione +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 15",
			"Auran",
			"***Attacco in picchiata.*** Quando l'aarakocra vola in picchiata per almeno 9 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco con arma da mischia, il colpo infligge 3 (1d6) danni extra.",
			"***Artiglio.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni taglienti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +4 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Aarakocra",
			null,
			"Medium humanoid (aarakocra), neutral good",
			"12",
			"20 ft., fly 50 ft.",
			"",
			"Perception +5",
			"",
			"",
			"",
			"",
			"passive Perception 15",
			"Auran",
			"***Dive Attack.*** When the aarakocra flies at least 30 feet straight toward a target while diving and then hits it with a melee weapon attack, the hit deals an extra 3 (1d6) damage.",
			"***Talon.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) slashing damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +4 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
