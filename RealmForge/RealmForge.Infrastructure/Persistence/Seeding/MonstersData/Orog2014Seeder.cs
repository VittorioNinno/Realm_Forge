using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Orog (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Orog2014Seeder
{
	public static Monster Build() => Create("orog", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		18, 42, "5d8 + 20", 30, new[] { 18, 12, 18, 12, 11, 12 }, 2m, 450, 2, 10,
		new Text(
			"Orog",
			null,
			"Umanoide Medio (orco), caotico malvagio",
			"18 (armatura completa)",
			"9 m",
			"",
			"Intimidire +5, Sopravvivenza +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Comune, Orchesco",
			"***Aggressivo.*** Come azione bonus, l'orog può muoversi fino alla sua velocità verso una creatura ostile che è in grado di vedere.",
			"***Multiattacco.*** L'orog effettua due attacchi con l'ascia bipenne.\n\n***Ascia bipenne.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (1d12 + 4) danni taglienti.\n\n***Giavellotto.*** *Attacco con arma da mischia o a distanza:* +6 al tiro per colpire, portata 1,5 m o gittata 9/36 m, un bersaglio. *Colpito:* 7 (1d6 + 4) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Orog",
			null,
			"Medium humanoid (orc), chaotic evil",
			"18 (plate)",
			"30 ft.",
			"",
			"Intimidation +5, Survival +2",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Common, Orc",
			"***Aggressive.*** As a bonus action, the orog can move up to its speed toward a hostile creature it can see.",
			"***Multiattack.*** The orog makes two greataxe attacks.\n\n***Greataxe.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 10 (1d12 + 4) slashing damage.\n\n***Javelin.*** *Melee or Ranged Weapon Attack:* +6 to hit, reach 5 ft. or range 30/120 ft., one target. *Hit:* 7 (1d6 + 4) piercing damage.",
			"",
			"",
			"",
			""));
}
