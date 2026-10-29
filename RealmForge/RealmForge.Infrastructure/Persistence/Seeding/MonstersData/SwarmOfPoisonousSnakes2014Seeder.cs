using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Swarm of Poisonous Snakes (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SwarmOfPoisonousSnakes2014Seeder
{
	public static Monster Build() => Create("swarm-of-poisonous-snakes", null, CreatureSize.Medium, CreatureType.Beast,
		14, 36, "8d8", 30, new[] { 8, 18, 11, 1, 10, 3 }, 2m, 450, 2, 10,
		new Text(
			"Sciame di serpenti velenosi",
			null,
			"Sciame Medio di bestie Minuscole, senza allineamento",
			"14",
			"9 m, nuotare 9 m",
			"",
			"",
			"",
			"contundenti, perforanti, taglienti",
			"",
			"affascinato, afferrato, paralizzato, pietrificato, prono, spaventato, stordito, trattenuto",
			"Percezione passiva 10, vista cieca 3 m",
			"—",
			"***Sciame.*** Lo sciame può occupare lo spazio di un'altra creatura e viceversa, e può muoversi attraverso qualsiasi apertura sufficientemente larga da far passare un serpente Minuscolo. Lo sciame non può recuperare punti ferita, né ottenere punti ferita temporanei.",
			"***Morsi.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 0 m, una creatura nello spazio dello sciame. *Colpito:* 7 (2d6) danni perforanti o 3 (1d6) danni perforanti se lo sciame possiede la metà dei suoi punti ferita o meno. Il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 10, subendo 14 (4d6) danni da veleno in caso di fallimento, o la metà in caso di successo.",
			"",
			""),
		new Text(
			"Swarm of Poisonous Snakes",
			null,
			"Medium swarm of Tiny beasts, unaligned",
			"14",
			"30 ft., swim 30 ft.",
			"",
			"",
			"",
			"bludgeoning, piercing, slashing",
			"",
			"charmed, frightened, grappled, paralyzed, petrified, prone, restrained, stunned",
			"blindsight 10 ft., passive Perception 10",
			"—",
			"***Swarm.*** The swarm can occupy another creature's space and vice versa, and the swarm can move through any opening large enough for a Tiny snake. The swarm can't regain hit points or gain temporary hit points.",
			"***Bites.*** *Melee Weapon Attack:* +6 to hit, reach 0 ft., one creature in the swarm's space. *Hit:* 7 (2d6) piercing damage, or 3 (1d6) piercing damage if the swarm has half of its hit points or fewer. The target must make a DC 10 Constitution saving throw, taking 14 (4d6) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
