using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Swarm of Rats (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SwarmOfRats2014Seeder
{
	public static Monster Build() => Create("swarm-of-rats", null, CreatureSize.Medium, CreatureType.Beast,
		10, 24, "7d8 - 7", 30, new[] { 9, 11, 9, 2, 10, 3 }, 0.25m, 50, 2, 10,
		new Text(
			"Sciame di topi",
			null,
			"Sciame Medio di bestie Minuscole, senza allineamento",
			"10",
			"9 m",
			"",
			"",
			"",
			"contundenti, perforanti, taglienti",
			"",
			"affascinato, afferrato, paralizzato, pietrificato, prono, spaventato, stordito, trattenuto",
			"Percezione passiva 10, scurovisione 9 m",
			"—",
			"***Olfatto acuto.*** Lo sciame dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.\n\n***Sciame.*** Lo sciame può occupare lo spazio di un'altra creatura e viceversa, e può muoversi attraverso qualsiasi apertura abbastanza grande per un ratto Minuscolo. Lo sciame non può recuperare punti ferita, né ottenere punti ferita temporanei.",
			"***Morsi.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 0 m, un bersaglio nello spazio dello sciame. *Colpito:* 7 (2d6) danni perforanti o 3 (1d6) danni perforanti se lo sciame possiede la metà dei suoi punti ferita o meno.",
			"",
			""),
		new Text(
			"Swarm of Rats",
			null,
			"Medium swarm of Tiny beasts, unaligned",
			"10",
			"30 ft.",
			"",
			"",
			"",
			"bludgeoning, piercing, slashing",
			"",
			"charmed, frightened, grappled, paralyzed, petrified, prone, restrained, stunned",
			"darkvision 30 ft., passive Perception 10",
			"—",
			"***Keen Smell.*** The swarm has advantage on Wisdom (Perception) checks that rely on smell.\n\n***Swarm.*** The swarm can occupy another creature's space and vice versa, and the swarm can move through any opening large enough for a Tiny rat. The swarm can't regain hit points or gain temporary hit points.",
			"***Bites.*** *Melee Weapon Attack:* +2 to hit, reach 0 ft., one target in the swarm's space. *Hit:* 7 (2d6) piercing damage, or 3 (1d6) piercing damage if the swarm has half of its hit points or fewer.",
			"",
			""));
}
