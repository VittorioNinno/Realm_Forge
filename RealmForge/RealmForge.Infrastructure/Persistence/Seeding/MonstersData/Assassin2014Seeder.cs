using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Assassin (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Assassin2014Seeder
{
	public static Monster Build() => Create("assassin", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		15, 78, "12d8 + 24", 30, new[] { 11, 16, 14, 13, 11, 10 }, 8m, 3900, 3, 13,
		new Text(
			"Assassino",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento non buono",
			"15 (cuoio borchiato)",
			"9 m",
			"Des +6, Int + +4",
			"Acrobazia +6, Furtività +9, Inganno +3, Percezione +3",
			"",
			"veleno",
			"",
			"",
			"Percezione passiva 13",
			"Gergo Ladresco più due qualsiasi",
			"***Assassinare.*** Durante il suo primo turno, l'assassino dispone di vantaggio ai tiri per colpire contro ogni creatura che non abbia ancora svolto il proprio turno. Ogni colpo che va a segno contro una creatura sorpresa è considerato un colpo critico.\n\n***Elusione.*** Se l'assassino è soggetto a un effetto che gli consente di effettuare un tiro salvezza su Destrezza per subire danni dimezzati, non subisce alcun danno in caso di successo, e ne subisce solo metà in caso di fallimento.\n\n***Attacco furtivo.*** Una volta per turno, l'assassino infligge 14 (4d6) danni extra quando colpisce un bersaglio con un attacco con un'arma e ha vantaggio al tiro per colpire, oppure quando il bersaglio si trova entro 1,5 metri da un alleato dell'assassino (purché l'alleato non sia incapacitato e l'assassino non subisca svantaggio al tiro per colpire).",
			"***Multiattacco.*** L'assassino effettua due attacchi con la spada corta.\n\n***Spada corta.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 15, subendo 24 (7d6) danni da veleno in caso di fallimento, o la metà dei danni in caso di successo\n\n***Balestra leggera.*** *Attacco con arma a distanza:* +6 al tiro per colpire, gittata 24/96 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 15, subendo 24 (7d6) danni da veleno in caso di fallimento, o la metà dei danni in caso di successo",
			"",
			"",
			"",
			""),
		new Text(
			"Assassin",
			null,
			"Medium humanoid (any race), any non-good alignment",
			"15 (studded leather armor)",
			"30 ft.",
			"Dex +6, Int +4",
			"Acrobatics +6, Deception +3, Perception +3, Stealth +9",
			"",
			"poison",
			"",
			"",
			"passive Perception 13",
			"Thieves' cant plus any two languages",
			"***Assassinate.*** During its first turn, the assassin has advantage on attack rolls against any creature that hasn't taken a turn. Any hit the assassin scores against a surprised creature is a critical hit.\n\n***Evasion.*** If the assassin is subjected to an effect that allows it to make a Dexterity saving throw to take only half damage, the assassin instead takes no damage if it succeeds on the saving throw, and only half damage if it fails.\n\n***Sneak Attack (1/Turn).*** The assassin deals an extra 13 (4d6) damage when it hits a target with a weapon attack and has advantage on the attack roll, or when the target is within 5 ft. of an ally of the assassin that isn't incapacitated and the assassin doesn't have disadvantage on the attack roll.",
			"***Multiattack.*** The assassin makes two shortsword attacks.\n\n***Shortsword.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage, and the target must make a DC 15 Constitution saving throw, taking 24 (7d6) poison damage on a failed save, or half as much damage on a successful one.\n\n***Light Crossbow.*** *Ranged Weapon Attack:* +6 to hit, range 80/320 ft., one target. *Hit:* 7 (1d8 + 3) piercing damage, and the target must make a DC 15 Constitution saving throw, taking 24 (7d6) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
