using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Allosaurus (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Allosaurus2014Seeder
{
	public static Monster Build() => Create("allosaurus", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Beast,
		13, 51, "6d10 + 18", 60, new[] { 19, 13, 17, 2, 12, 5 }, 2m, 450, 2, 15,
		new Text(
			"Allosauro",
			null,
			"Bestia Grande, senza allineamento",
			"13 (armatura naturale)",
			"18 m",
			"",
			"Percezione +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 15",
			"—",
			"***Balzo.*** Se l'allosauro si muove di almeno 9 metri in linea retta verso una creatura e poi la colpisce con un attacco di artiglio nello stesso turno, il bersaglio effettua un tiro salvezza su Forza con CD 13, altrimenti cade prono. Contro un bersaglio prono, l'allosauro può effettuare un attacco con il morso come azione bonus.",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 15 (2d10 + 4) danni perforanti.\n\n***Artiglio.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d8 + 4) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Allosaurus",
			null,
			"Large beast, unaligned",
			"13 (natural armor)",
			"60 ft.",
			"",
			"Perception +5",
			"",
			"",
			"",
			"",
			"passive Perception 15",
			"—",
			"***Pounce.*** If the allosaurus moves at least 30 feet straight toward a creature and then hits it with a claw attack on the same turn, the target makes a DC 13 Strength saving throw or is knocked prone. Against a prone target, the allosaurus can make one bite attack as a bonus action.",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 15 (2d10 + 4) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 8 (1d8 + 4) slashing damage.",
			"",
			"",
			"",
			""));
}
