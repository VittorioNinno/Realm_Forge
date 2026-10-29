using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Goat (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantGoat2014Seeder
{
	public static Monster Build() => Create("giant-goat", null, CreatureSize.Large, CreatureType.Beast,
		11, 19, "3d10 + 3", 40, new[] { 17, 11, 12, 3, 12, 6 }, 0.5m, 100, 2, 11,
		new Text(
			"Capra gigante",
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
			"***Ben piantato.*** La capra ha vantaggio ai tiri salvezza su Forza e Destrezza contro effetti che la farebbero cadere prona.\n\n***Carica.*** Se la capra si muove di almeno 6 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco da sfondamento nello stesso turno, il bersaglio subisce 5 (2d4) danni contundenti extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 13, altrimenti cade a terra prono.",
			"***Sfondamento.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (2d4 + 3) danni contundenti.",
			"",
			""),
		new Text(
			"Giant Goat",
			null,
			"Large beast, unaligned",
			"11",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 11",
			"—",
			"***Charge.*** If the goat moves at least 20 ft. straight toward a target and then hits it with a ram attack on the same turn, the target takes an extra 5 (2d4) bludgeoning damage. If the target is a creature, it must succeed on a DC 13 Strength saving throw or be knocked prone.\n\n***Sure-Footed.*** The goat has advantage on Strength and Dexterity saving throws made against effects that would knock it prone.",
			"***Ram.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 8 (2d4 + 3) bludgeoning damage.",
			"",
			""));
}
