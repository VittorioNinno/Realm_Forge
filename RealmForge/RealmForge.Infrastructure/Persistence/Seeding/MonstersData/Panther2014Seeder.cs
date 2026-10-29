using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Panther (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Panther2014Seeder
{
	public static Monster Build() => Create("panther", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		12, 13, "3d8", 50, new[] { 14, 15, 10, 3, 14, 7 }, 0.25m, 50, 2, 14,
		new Text(
			"Pantera",
			null,
			"Bestia Media, senza allineamento",
			"12",
			"15 m, scalare 12 m",
			"",
			"Furtività +6, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"—",
			"***Balzo.*** Se la pantera si muove di almeno 6 metri in linea retta verso una creatura e poi la colpisce con un attacco con gli artigli nello stesso turno, quel bersaglio deve superare un tiro salvezza su Forza con CD 12, altrimenti cade a terra prono. Se il bersaglio è prono, la pantera può effettuare un attacco con il morso contro di esso come azione bonus.\n\n***Olfatto acuto.*** La pantera dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Artiglio.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Panther",
			null,
			"Medium beast, unaligned",
			"12",
			"50 ft., climb 40 ft.",
			"",
			"Perception +4, Stealth +6",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"—",
			"***Keen Smell.*** The panther has advantage on Wisdom (Perception) checks that rely on smell.\n\n***Pounce.*** If the panther moves at least 20 ft. straight toward a creature and then hits it with a claw attack on the same turn, that target must succeed on a DC 12 Strength saving throw or be knocked prone. If the target is prone, the panther can make one bite attack against it as a bonus action.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) slashing damage.",
			"",
			"",
			"",
			""));
}
