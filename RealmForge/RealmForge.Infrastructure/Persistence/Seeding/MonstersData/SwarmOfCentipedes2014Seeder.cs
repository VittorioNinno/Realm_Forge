using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Swarm of Centipedes (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SwarmOfCentipedes2014Seeder
{
	public static Monster Build() => Create("swarm-of-centipedes", "swarm-of-insects", ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		12, 22, "5d8", 20, new[] { 3, 13, 10, 1, 7, 1 }, 0.5m, 100, 2, 8,
		new Text(
			"Sciame di millepiedi",
			null,
			"Sciame Medio di bestie Minuscole, senza allineamento",
			"12 (armatura naturale)",
			"6 m, scalare 6 m",
			"",
			"",
			"",
			"contundenti, perforanti, taglienti",
			"",
			"affascinato, afferrato, paralizzato, pietrificato, prono, spaventato, stordito, trattenuto",
			"Percezione passiva 8, vista cieca 3 m",
			"—",
			"***Sciame.*** Lo sciame può occupare lo spazio di un'altra creatura e viceversa, e può muoversi attraverso qualsiasi apertura sufficientemente larga da far passare un insetto Minuscolo. Lo sciame non può recuperare punti ferita, né ottenere punti ferita temporanei.",
			"***Morsi.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 0 m, un bersaglio nello spazio dello sciame. *Colpito:* 10 (4d4) danni perforanti o 5 (2d4) danni perforanti se lo sciame ha la metà dei suoi punti ferita o meno.\n\nUna creatura ridotta a 0 punti ferita da uno sciame di millepiedi è stabile ma avvelenata per 1 ora, anche dopo avere recuperato punti ferita, e rimane paralizzata finché è avvelenata.",
			"",
			"",
			"",
			""),
		new Text(
			"Swarm of Centipedes",
			null,
			"Medium swarm of Tiny beasts, unaligned",
			"12 (natural armor)",
			"20 ft., climb 20 ft.",
			"",
			"",
			"",
			"bludgeoning, piercing, slashing",
			"",
			"charmed, frightened, grappled, paralyzed, petrified, prone, restrained, stunned",
			"blindsight 10 ft., passive Perception 8",
			"—",
			"***Swarm.*** The swarm can occupy another creature's space and vice versa, and the swarm can move through any opening large enough for a Tiny insect. The swarm can't regain hit points or gain temporary hit points.",
			"***Bites.*** *Melee Weapon Attack:* +3 to hit, reach 0 ft., one target in the swarm's space. *Hit:* 10 (4d4) piercing damage, or 5 (2d4) piercing damage if the swarm has half of its hit points or fewer.\n\nA creature reduced to 0 hit points by a swarm of centipedes is stable but poisoned for 1 hour, even after regaining hit points, and paralyzed while poisoned in this way.",
			"",
			"",
			"",
			""));
}
