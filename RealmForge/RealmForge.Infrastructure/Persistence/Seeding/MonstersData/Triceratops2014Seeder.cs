using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Triceratops (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Triceratops2014Seeder
{
	public static Monster Build() => Create("triceratops", null, ContentSource.Srd51, CreatureSize.Huge, CreatureType.Beast,
		13, 95, "10d12 + 30", 50, new[] { 22, 9, 17, 2, 11, 5 }, 5m, 1800, 3, 10,
		new Text(
			"Triceratopo",
			null,
			"Bestia Enorme, senza allineamento",
			"13 (armatura naturale)",
			"15 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"***Carica travolgente.*** Se il triceratopo si muove di almeno 6 metri in linea retta verso una creatura e poi la colpisce con un'incornata nello stesso turno, quel bersaglio deve superare un tiro salvezza su Forza con CD 13, altrimenti cade a terra prono. Se il bersaglio è prono, il triceratopo può effettuare un pestone contro di esso come azione bonus.",
			"***Incornata.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 24 (4d8 + 6) danni perforanti.\n\n***Pestone.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, una creatura prona. *Colpito:* 22 (3d10 + 6) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Triceratops",
			null,
			"Huge beast, unaligned",
			"13 (natural armor)",
			"50 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"***Trampling Charge.*** If the triceratops moves at least 20 ft. straight toward a creature and then hits it with a gore attack on the same turn, that target must succeed on a DC 13 Strength saving throw or be knocked prone. If the target is prone, the triceratops can make one stomp attack against it as a bonus action.",
			"***Gore.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 24 (4d8 + 6) piercing damage.\n\n***Stomp.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one prone creature. *Hit:* 22 (3d10 + 6) bludgeoning damage",
			"",
			"",
			"",
			""));
}
