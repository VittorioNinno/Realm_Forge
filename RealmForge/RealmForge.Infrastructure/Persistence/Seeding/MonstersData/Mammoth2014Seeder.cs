using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Mammoth (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Mammoth2014Seeder
{
	public static Monster Build() => Create("mammoth", null, ContentSource.Srd51, CreatureSize.Huge, CreatureType.Beast,
		13, 126, "11d12 + 55", 40, new[] { 24, 9, 21, 3, 11, 6 }, 6m, 2300, 3, 10,
		new Text(
			"Mammut",
			null,
			"Bestia Enorme, senza allineamento",
			"13 (armatura naturale)",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"***Carica travolgente.*** Se il mammut si muove di almeno 6 metri in linea retta verso una creatura e poi la colpisce effettuando un'incornata con le zanne nello stesso turno, quel bersaglio deve superare un tiro salvezza su Forza con CD 18, altrimenti cade a terra prono. Se il bersaglio è prono, il mammut può effettuare un pestone contro di esso come azione bonus.",
			"***Incornata.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 25 (4d8 + 7) danni perforanti.\n\n***Pestone.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, una creatura prona. *Colpito:* 29 (4d10 + 7) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Mammoth",
			null,
			"Huge beast, unaligned",
			"13 (natural armor)",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"***Trampling Charge.*** If the mammoth moves at least 20 ft. straight toward a creature and then hits it with a gore attack on the same turn, that target must succeed on a DC 18 Strength saving throw or be knocked prone. If the target is prone, the mammoth can make one stomp attack against it as a bonus action.",
			"***Gore.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 25 (4d8 + 7) piercing damage.\n\n***Stomp.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one prone creature. *Hit:* 29 (4d10 + 7) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
