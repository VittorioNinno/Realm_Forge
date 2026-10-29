using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Swarm of Ravens (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SwarmOfRavens2014Seeder
{
	public static Monster Build() => Create("swarm-of-ravens", null, CreatureSize.Medium, CreatureType.Beast,
		12, 24, "7d8 - 7", 10, new[] { 6, 14, 8, 3, 12, 6 }, 0.25m, 50, 2, 15,
		new Text(
			"Sciame di corvi",
			null,
			"Sciame Medio di bestie Minuscole, senza allineamento",
			"12",
			"3 m, volare 15 m",
			"",
			"Percezione +5",
			"",
			"contundenti, perforanti, taglienti",
			"",
			"affascinato, afferrato, paralizzato, pietrificato, prono, spaventato, stordito, trattenuto",
			"Percezione passiva 15",
			"—",
			"***Sciame.*** Lo sciame può occupare lo spazio di un'altra creatura e viceversa, e può muoversi attraverso qualsiasi apertura abbastanza grande per un corvo Minuscolo. Lo sciame non può recuperare punti ferita, né ottenere punti ferita temporanei.",
			"***Becchi.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio nello spazio dello sciame. *Colpito:* 7 (2d6) danni perforanti o 3 (1d6) danni perforanti se lo sciame possiede la metà dei suoi punti ferita o meno.",
			"",
			""),
		new Text(
			"Swarm of Ravens",
			null,
			"Medium swarm of Tiny beasts, unaligned",
			"12",
			"10 ft., fly 50 ft.",
			"",
			"Perception +5",
			"",
			"bludgeoning, piercing, slashing",
			"",
			"charmed, frightened, grappled, paralyzed, petrified, prone, restrained, stunned",
			"passive Perception 15",
			"—",
			"***Swarm.*** The swarm can occupy another creature's space and vice versa, and the swarm can move through any opening large enough for a Tiny raven. The swarm can't regain hit points or gain temporary hit points.",
			"***Beaks.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target in the swarm's space. *Hit:* 7 (2d6) piercing damage, or 3 (1d6) piercing damage if the swarm has half of its hit points or fewer.",
			"",
			""));
}
