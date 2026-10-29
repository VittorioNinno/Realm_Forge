using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Orc (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Orc2014Seeder
{
	public static Monster Build() => Create("orc", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		13, 15, "2d8 + 6", 30, new[] { 16, 12, 16, 7, 11, 10 }, 0.5m, 100, 2, 10,
		new Text(
			"Orco",
			null,
			"Umanoide Medio (orco), caotico malvagio",
			"13 (armatura di pelle)",
			"9 m",
			"",
			"Intimidire +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Comune, Orchesco",
			"***Aggressivo.*** Come azione bonus, l'orco può muoversi fino alla sua velocità massima verso una creatura ostile nel suo campo visivo.",
			"***Ascia bipenne.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (1d12 + 3) danni taglienti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +5 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Orc",
			null,
			"Medium humanoid (orc), chaotic evil",
			"13 (hide armor)",
			"30 ft.",
			"",
			"Intimidation +2",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Common, Orc",
			"***Aggressive.*** As a bonus action, the orc can move up to its speed toward a hostile creature that it can see.",
			"***Greataxe.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 9 (1d12 + 3) slashing damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +5 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.",
			"",
			"",
			"",
			""));
}
