using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Sea Horse (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantSeaHorse2014Seeder
{
	public static Monster Build() => Create("giant-sea-horse", null, CreatureSize.Large, CreatureType.Beast,
		13, 16, "3d10", 0, new[] { 12, 15, 11, 2, 12, 5 }, 0.5m, 100, 2, 11,
		new Text(
			"Cavalluccio marino gigante",
			null,
			"Bestia Grande, senza allineamento",
			"13 (armatura naturale)",
			"0 m, nuotare 12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11",
			"—",
			"***Carica.*** Se il cavalluccio marino si muove di almeno 6 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco da sfondamento nello stesso turno, il bersaglio subisce 7 (2d6) danni contundenti extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 11, altrimenti cade a terra prono.\n\n***Respirare sott'acqua.*** Il cavalluccio marino può respirare soltanto sott'acqua.",
			"***Sfondamento.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni contundenti.",
			"",
			""),
		new Text(
			"Giant Sea Horse",
			null,
			"Large beast, unaligned",
			"13 (natural armor)",
			"0 ft., swim 40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 11",
			"—",
			"***Charge.*** If the sea horse moves at least 20 ft. straight toward a target and then hits it with a ram attack on the same turn, the target takes an extra 7 (2d6) bludgeoning damage. If the target is a creature, it must succeed on a DC 11 Strength saving throw or be knocked prone.\n\n***Water Breathing.*** The sea horse can breathe only underwater.",
			"***Ram.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 4 (1d6 + 1) bludgeoning damage.",
			"",
			""));
}
