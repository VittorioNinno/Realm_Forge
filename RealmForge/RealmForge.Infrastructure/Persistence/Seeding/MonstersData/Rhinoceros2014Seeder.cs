using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Rhinoceros (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Rhinoceros2014Seeder
{
	public static Monster Build() => Create("rhinoceros", null, CreatureSize.Large, CreatureType.Beast,
		11, 45, "6d10 + 12", 40, new[] { 21, 8, 15, 2, 12, 6 }, 2m, 450, 2, 11,
		new Text(
			"Rinoceronte",
			null,
			"Bestia Grande, senza allineamento",
			"11 (armatura naturale)",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11",
			"—",
			"***Carica.*** Se il rinoceronte si muove di almeno 6 metri in linea retta verso un bersaglio e poi lo colpisce con un'incornata nello stesso turno, la vittima subisce 9 (2d8) danni contundenti extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 15, altrimenti cade a terra prono.",
			"***Incornata.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (2d8 + 5) danni contundenti.",
			"",
			""),
		new Text(
			"Rhinoceros",
			null,
			"Large beast, unaligned",
			"11 (natural armor)",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 11",
			"—",
			"***Charge.*** If the rhinoceros moves at least 20 ft. straight toward a target and then hits it with a gore attack on the same turn, the target takes an extra 9 (2d8) bludgeoning damage. If the target is a creature, it must succeed on a DC 15 Strength saving throw or be knocked prone.",
			"***Gore.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 14 (2d8 + 5) bludgeoning damage.",
			"",
			""));
}
