using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Orc War Chief (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class OrcWarChief2014Seeder
{
	public static Monster Build() => Create("orc-war-chief", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		16, 93, "11d8 + 44", 30, new[] { 18, 12, 18, 11, 11, 16 }, 4m, 1100, 2, 10,
		new Text(
			"Orco capotribù guerriero",
			null,
			"Umanoide Medio (orco), caotico malvagio",
			"16 (cotta di maglia)",
			"9 m",
			"Cos +6, For +6, Sag +2",
			"Intimidire +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Comune, Orchesco",
			"***Aggressivo.*** Come azione bonus, l'orco può muoversi fino alla sua velocità verso una creatura ostile che è in grado di vedere.\n\n***Furia di Gruumsh.*** Ogni volta che l'orco colpisce con un attacco con arma, infligge 4 (1d8) danni extra (già inclusi nei suoi attacchi).",
			"***Multiattacco.*** L'orco effettua due attacchi con l'ascia bipenne o due con la lancia.\n\n***Ascia bipenne.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 14 (1d12 + 4 più 1d8) danni taglienti.\n\n***Lancia.*** *Attacco con arma da mischia o a distanza:* +6 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 12 (1d6 + 4 più 1d8) danni perforanti, o 13 (2d8 + 4) danni perforanti se impugnata a due mani in mischia.\n\n***Grido di battaglia (1/giorno).*** Ogni creatura a scelta del capotribù entro 9 metri da lui che può sentirlo, e che non è già sotto l'effetto di un Grido di battaglia, dispone di vantaggio ai tiri per colpire fino all'inizio del turno successivo del capotribù. Il capotribù può poi effettuare un attacco come azione bonus.",
			"",
			"",
			"",
			""),
		new Text(
			"Orc War Chief",
			null,
			"Medium humanoid (orc), chaotic evil",
			"16 (chain mail)",
			"30 ft.",
			"Str +6, Con +6, Wis +2",
			"Intimidation +5",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Common, Orc",
			"***Aggressive.*** As a bonus action, the orc can move up to its speed toward a hostile creature it can see.\n\n***Gruumsh's Fury.*** Whenever the orc hits with a weapon attack, it deals an extra 4 (1d8) damage (already counted in its attacks).",
			"***Multiattack.*** The orc makes two greataxe or two spear attacks.\n\n***Greataxe.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one creature. *Hit:* 14 (1d12 + 4 plus 1d8) slashing damage.\n\n***Spear.*** *Melee or Ranged Weapon Attack:* +6 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 12 (1d6 + 4 plus 1d8) piercing damage, or 13 (2d8 + 4) piercing damage if used with two hands in melee.\n\n***Battle Cry (1/Day).*** Every creature of the war chief's choice within 30 feet of it that can hear it, and isn't already under a Battle Cry, has advantage on attack rolls until the start of the war chief's next turn. The war chief can then make one attack as a bonus action.",
			"",
			"",
			"",
			""));
}
