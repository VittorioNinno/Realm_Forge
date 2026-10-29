using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ogre (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Ogre2014Seeder
{
	public static Monster Build() => Create("ogre", null, CreatureSize.Large, CreatureType.Giant,
		11, 59, "7d10 + 21", 40, new[] { 19, 8, 16, 5, 7, 7 }, 2m, 450, 2, 8,
		new Text(
			"Ogre",
			null,
			"Gigante Grande, caotico malvagio",
			"11 (armatura di pelle)",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 8, scurovisione 18 m",
			"Comune, Gigante",
			"",
			"***Randello pesante.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni contundenti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +6 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni perforanti.",
			"",
			""),
		new Text(
			"Ogre",
			null,
			"Large giant, chaotic evil",
			"11 (hide armor)",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 8",
			"Common, Giant",
			"",
			"***Greatclub.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) bludgeoning damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +6 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 11 (2d6 + 4) piercing damage.",
			"",
			""));
}
