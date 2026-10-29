using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Saber-Toothed Tiger (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SaberToothedTiger2014Seeder
{
	public static Monster Build() => Create("saber-toothed-tiger", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		12, 52, "7d10 + 14", 40, new[] { 18, 14, 15, 3, 12, 8 }, 2m, 450, 2, 13,
		new Text(
			"Tigre dai denti a sciabola",
			null,
			"Bestia Grande, senza allineamento",
			"12",
			"12 m",
			"",
			"Furtività +6, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Balzo.*** Se la tigre si muove di almeno 6 metri in linea retta verso una creatura e poi la colpisce con un attacco con gli artigli nello stesso turno, quel bersaglio deve superare un tiro salvezza su Forza con CD 14, altrimenti cade a terra prono. Se il bersaglio è prono, la tigre può effettuare un attacco con il morso contro di esso come azione bonus.\n\n***Olfatto acuto.*** La tigre dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Artiglio.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (1d10 + 5) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Saber-Toothed Tiger",
			null,
			"Large beast, unaligned",
			"12",
			"40 ft.",
			"",
			"Perception +3, Stealth +6",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Smell.*** The tiger has advantage on Wisdom (Perception) checks that rely on smell.\n\n***Pounce.*** If the tiger moves at least 20 ft. straight toward a creature and then hits it with a claw attack on the same turn, that target must succeed on a DC 14 Strength saving throw or be knocked prone. If the target is prone, the tiger can make one bite attack against it as a bonus action.",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 10 (1d10 + 5) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 12 (2d6 + 5) slashing damage.",
			"",
			"",
			"",
			""));
}
