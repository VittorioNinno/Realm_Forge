using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Elephant (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Elephant2014Seeder
{
	public static Monster Build() => Create("elephant", null, ContentSource.Srd51, CreatureSize.Huge, CreatureType.Beast,
		12, 76, "8d12 + 24", 40, new[] { 22, 9, 17, 3, 11, 6 }, 4m, 1100, 2, 10,
		new Text(
			"Elefante",
			null,
			"Bestia Enorme, senza allineamento",
			"12 (armatura naturale)",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"***Carica travolgente.*** Se l'elefante si muove di almeno 6 metri in linea retta verso una creatura e poi la colpisce effettuando un'incornata con le zanne nello stesso turno, quel bersaglio deve superare un tiro salvezza su Forza con CD 12, altrimenti cade a terra prono. Se il bersaglio è prono, l'elefante può effettuare un pestone contro di esso come azione bonus.",
			"***Incornata.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 19 (3d8 + 6) danni perforanti.\n\n***Pestone.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, una creatura prona. *Colpito:* 22 (3d10 + 6) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Elephant",
			null,
			"Huge beast, unaligned",
			"12 (natural armor)",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"***Trampling Charge.*** If the elephant moves at least 20 ft. straight toward a creature and then hits it with a gore attack on the same turn, that target must succeed on a DC 12 Strength saving throw or be knocked prone. If the target is prone, the elephant can make one stomp attack against it as a bonus action.",
			"***Gore.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 19 (3d8 + 6) piercing damage.\n\n***Stomp.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one prone creature. *Hit:* 22 (3d10 + 6) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
