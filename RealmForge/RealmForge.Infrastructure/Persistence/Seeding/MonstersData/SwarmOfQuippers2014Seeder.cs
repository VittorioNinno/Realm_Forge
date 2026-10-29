using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Swarm of Quippers (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SwarmOfQuippers2014Seeder
{
	public static Monster Build() => Create("swarm-of-quippers", null, CreatureSize.Medium, CreatureType.Beast,
		13, 28, "8d8 - 8", 0, new[] { 13, 16, 9, 1, 7, 2 }, 1m, 200, 2, 8,
		new Text(
			"Sciame di quipper",
			null,
			"Sciame Medio di bestie Minuscole, senza allineamento",
			"13",
			"0 m, nuotare 12 m",
			"",
			"",
			"",
			"contundenti, perforanti, taglienti",
			"",
			"affascinato, afferrato, paralizzato, pietrificato, prono, spaventato, stordito, trattenuto",
			"Percezione passiva 8, scurovisione 18 m",
			"—",
			"***Frenesia di sangue.*** Lo sciame dispone di vantaggio ai tiri per colpire in mischia contro ogni creatura che non possieda tutti i propri punti ferita.\n\n***Respirare sott'acqua.*** Lo sciame può respirare soltanto sott'acqua.\n\n***Sciame.*** Lo sciame può occupare lo spazio di un'altra creatura e viceversa, e può muoversi attraverso qualsiasi apertura sufficientemente larga da far passare un quipper Minuscolo. Lo sciame non può recuperare punti ferita, né ottenere punti ferita temporanei.",
			"***Morsi.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 0 m, una creatura nello spazio dello sciame. *Colpito:* 14 (4d6) danni perforanti o 7 (2d6) danni perforanti se lo sciame ha la metà dei suoi punti ferita o meno.",
			"",
			""),
		new Text(
			"Swarm of Quippers",
			null,
			"Medium swarm of Tiny beasts, unaligned",
			"13",
			"0 ft., swim 40 ft.",
			"",
			"",
			"",
			"bludgeoning, piercing, slashing",
			"",
			"charmed, frightened, grappled, paralyzed, petrified, prone, restrained, stunned",
			"darkvision 60 ft., passive Perception 8",
			"—",
			"***Blood Frenzy.*** The swarm has advantage on melee attack rolls against any creature that doesn't have all its hit points.\n\n***Swarm.*** The swarm can occupy another creature's space and vice versa, and the swarm can move through any opening large enough for a Tiny quipper. The swarm can't regain hit points or gain temporary hit points.\n\n***Water Breathing.*** The swarm can breathe only underwater.",
			"***Bites.*** *Melee Weapon Attack:* +5 to hit, reach 0 ft., one creature in the swarm's space. *Hit:* 14 (4d6) piercing damage, or 7 (2d6) piercing damage if the swarm has half of its hit points or fewer.",
			"",
			""));
}
