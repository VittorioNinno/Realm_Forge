using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Spy (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Spy2014Seeder
{
	public static Monster Build() => Create("spy", null, CreatureSize.Medium, CreatureType.Humanoid,
		12, 27, "6d8", 30, new[] { 10, 15, 10, 12, 14, 16 }, 1m, 200, 2, 16,
		new Text(
			"Spia",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"12",
			"9 m",
			"",
			"Furtività +4, Indagare +5, Inganno +5, Intuizione +4, Percezione +6, Persuasione +5, Rapidità di Mano +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 16",
			"due qualsiasi",
			"***Attacco furtivo (1/turno).*** La spia infligge 7 (2d6) danni extra quando colpisce un bersaglio con un attacco con un'arma e dispone di vantaggio al tiro per colpire, oppure quando il bersaglio si trova entro 1,5 metri da un alleato della spia (purché quest'ultimo non sia incapacitato e la spia non subisca svantaggio al tiro per colpire).\n\n***Azione scaltra.*** A ogni suo turno, la spia può usare un'azione bonus per effettuare l'azione Scatto, Disimpegno o Nascondersi.",
			"***Multiattacco.*** La spia effettua due attacchi in mischia.\n\n***Spada corta.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.\n\n***Balestra a mano.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 9/36 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			""),
		new Text(
			"Spy",
			null,
			"Medium humanoid (any race), any alignment",
			"12",
			"30 ft.",
			"",
			"Deception +5, Insight +4, Investigation +5, Perception +6, Persuasion +5, Sleight of Hand +4, Stealth +4",
			"",
			"",
			"",
			"",
			"passive Perception 16",
			"any two languages",
			"***Cunning Action.*** On each of its turns, the spy can use a bonus action to take the Dash, Disengage, or Hide action.\n\n***Sneak Attack (1/Turn).*** The spy deals an extra 7 (2d6) damage when it hits a target with a weapon attack and has advantage on the attack roll, or when the target is within 5 ft. of an ally of the spy that isn't incapacitated and the spy doesn't have disadvantage on the attack roll.",
			"***Multiattack.*** The spy makes two melee attacks.\n\n***Shortsword.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Hand Crossbow.*** *Ranged Weapon Attack:* +4 to hit, range 30/120 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.",
			"",
			""));
}
