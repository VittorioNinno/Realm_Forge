using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Half-Ogre (Ogrillon) (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class HalfOgre2014Seeder
{
	public static Monster Build() => Create("half-ogre", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Giant,
		12, 30, "4d10 + 8", 30, new[] { 17, 10, 14, 7, 9, 10 }, 1m, 200, 2, 9,
		new Text(
			"Mezzogre",
			"Ogrillon",
			"Gigante Grande, qualsiasi allineamento caotico",
			"12 (armatura di pelle)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 9, scurovisione 18 m",
			"Comune, Gigante",
			"",
			"***Ascia da battaglia.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d8 + 3) danni taglienti, o 14 (2d10 + 3) danni taglienti se impugnata a due mani.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +5 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Half-Ogre (Ogrillon)",
			null,
			"Large giant, any chaotic alignment",
			"12 (hide armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 9",
			"Common, Giant",
			"",
			"***Battleaxe.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 12 (2d8 + 3) slashing damage, or 14 (2d10 + 3) slashing damage if used with two hands.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +5 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 10 (2d6 + 3) piercing damage.",
			"",
			"",
			"",
			""));
}
