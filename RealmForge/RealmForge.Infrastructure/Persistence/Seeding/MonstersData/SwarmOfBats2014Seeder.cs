using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Swarm of Bats (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SwarmOfBats2014Seeder
{
	public static Monster Build() => Create("swarm-of-bats", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		12, 22, "5d8", 0, new[] { 5, 15, 10, 2, 12, 4 }, 0.25m, 50, 2, 11,
		new Text(
			"Sciame di pipistrelli",
			null,
			"Sciame Medio di bestie Minuscole, senza allineamento",
			"12",
			"0 m, volare 9 m",
			"",
			"",
			"",
			"contundenti, perforanti, taglienti",
			"",
			"affascinato, afferrato, paralizzato, pietrificato, prono, spaventato, stordito, trattenuto",
			"Percezione passiva 11, vista cieca 18 m",
			"—",
			"***Sciame.*** Lo sciame può occupare lo spazio di un'altra creatura e viceversa, e può muoversi attraverso qualsiasi apertura sufficientemente larga da far passare un pipistrello Minuscolo. Lo sciame non può recuperare punti ferita, né ottenere punti ferita temporanei.\n\n***Senso radar.*** Lo sciame non può usare vista cieca se è assordato.\n\n***Udito acuto.*** Lo sciame dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'udito.",
			"***Morsi.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 0 m, una creatura nello spazio dello sciame. *Colpito:* 5 (2d4) danni perforanti o 2 (1d4) danni perforanti se lo sciame possiede la metà dei suoi punti ferita o meno.",
			"",
			"",
			"",
			""),
		new Text(
			"Swarm of Bats",
			null,
			"Medium swarm of Tiny beasts, unaligned",
			"12",
			"0 ft., fly 30 ft.",
			"",
			"",
			"",
			"bludgeoning, piercing, slashing",
			"",
			"charmed, frightened, grappled, paralyzed, petrified, prone, restrained, stunned",
			"blindsight 60 ft., passive Perception 11",
			"—",
			"***Echolocation.*** The swarm can't use its blindsight while deafened.\n\n***Keen Hearing.*** The swarm has advantage on Wisdom (Perception) checks that rely on hearing.\n\n***Swarm.*** The swarm can occupy another creature's space and vice versa, and the swarm can move through any opening large enough for a Tiny bat. The swarm can't regain hit points or gain temporary hit points.",
			"***Bites.*** *Melee Weapon Attack:* +4 to hit, reach 0 ft., one creature in the swarm's space. *Hit:* 5 (2d4) piercing damage, or 2 (1d4) piercing damage if the swarm has half of its hit points or fewer.",
			"",
			"",
			"",
			""));
}
