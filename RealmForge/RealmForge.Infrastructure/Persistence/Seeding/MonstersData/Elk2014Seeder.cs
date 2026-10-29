using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Elk (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Elk2014Seeder
{
	public static Monster Build() => Create("elk", null, CreatureSize.Large, CreatureType.Beast,
		10, 13, "2d10 + 2", 50, new[] { 16, 10, 12, 2, 10, 6 }, 0.25m, 50, 2, 10,
		new Text(
			"Alce",
			null,
			"Bestia Grande, senza allineamento",
			"10",
			"15 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"***Carica.*** Se l'alce si muove di almeno 6 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco da sfondamento nello stesso turno, il bersaglio subisce 7 (2d6) danni extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 13, altrimenti cade a terra prono.",
			"***Sfondamento.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni contundenti.\n\n***Zoccoli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura prona. *Colpito:* 8 (2d4 + 3) danni contundenti.",
			"",
			""),
		new Text(
			"Elk",
			null,
			"Large beast, unaligned",
			"10",
			"50 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"***Charge.*** If the elk moves at least 20 ft. straight toward a target and then hits it with a ram attack on the same turn, the target takes an extra 7 (2d6) damage. If the target is a creature, it must succeed on a DC 13 Strength saving throw or be knocked prone.",
			"***Ram.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) bludgeoning damage.\n\n***Hooves.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one prone creature. *Hit:* 8 (2d4 + 3) bludgeoning damage.",
			"",
			""));
}
