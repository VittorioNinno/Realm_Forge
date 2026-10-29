using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gorgon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Gorgon2014Seeder
{
	public static Monster Build() => Create("gorgon", null, CreatureSize.Large, CreatureType.Monstrosity,
		19, 114, "12d10 + 48", 40, new[] { 20, 11, 18, 2, 12, 7 }, 5m, 1800, 3, 14,
		new Text(
			"Gorgone",
			null,
			"Mostruosità Grande, senza allineamento",
			"19 (armatura naturale)",
			"12 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"pietrificato",
			"Percezione passiva 14, scurovisione 18 m",
			"—",
			"***Carica travolgente.*** Se la gorgone si muove di almeno 6 metri in linea retta verso una creatura e poi la colpisce con un'incornata nello stesso turno, quel bersaglio deve superare un tiro salvezza su Forza con CD 16, altrimenti cade a terra prono. Se il bersaglio è prono, la gorgone può effettuare un'azione bonus per sferrare un attacco con gli zoccoli contro di lui.",
			"***Incornata.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 18 (2d12 + 5) danni perforanti.\n\n***Zoccoli.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 16 (2d10 + 5) danni contundenti.\n\n***Soffio pietrificante (ricarica 5–6).*** La gorgone esala gas pietrificante in un cono di 9 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Costituzione con CD 13; altrimenti inizia a trasformarsi in pietra ed è trattenuta. Il bersaglio trattenuto deve ripetere il tiro salvezza alla fine del proprio turno successivo. In caso di successo, l'effetto svanisce. In caso di fallimento, è pietrificato finché non viene liberato da un incantesimo *ristorare superiore* o da una magia analoga.",
			"",
			""),
		new Text(
			"Gorgon",
			null,
			"Large monstrosity, unaligned",
			"19 (natural armor)",
			"40 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"petrified",
			"darkvision 60 ft., passive Perception 14",
			"—",
			"***Trampling Charge.*** If the gorgon moves at least 20 feet straight toward a creature and then hits it with a gore attack on the same turn, that target must succeed on a DC 16 Strength saving throw or be knocked prone. If the target is prone, the gorgon can make one attack with its hooves against it as a bonus action.",
			"***Gore.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 18 (2d12 + 5) piercing damage.\n\n***Hooves.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 16 (2d10 + 5) bludgeoning damage.\n\n***Petrifying Breath (Recharge 5–6).*** The gorgon exhales petrifying gas in a 30-foot cone. Each creature in that area must succeed on a DC 13 Constitution saving throw. On a failed save, a target begins to turn to stone and is restrained. The restrained target must repeat the saving throw at the end of its next turn. On a success, the effect ends on the target. On a failure, the target is petrified until freed by the greater restoration spell or other magic.",
			"",
			""));
}
