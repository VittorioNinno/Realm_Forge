using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Goat (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Goat2014Seeder
{
	public static Monster Build() => Create("goat", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		10, 4, "1d8", 40, new[] { 12, 10, 11, 2, 10, 5 }, 0m, 10, 2, 10,
		new Text(
			"Capra",
			null,
			"Bestia Media, senza allineamento",
			"10",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"***Ben piantato.*** La capra ha vantaggio ai tiri salvezza su Forza e Destrezza contro effetti che la farebbero cadere prona.\n\n***Carica.*** Se la capra si muove di almeno 6 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco da sfondamento nello stesso turno, il bersaglio subisce 2 (1d4) danni contundenti extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 10, altrimenti cade a terra prono.",
			"***Sfondamento.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Goat",
			null,
			"Medium beast, unaligned",
			"10",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"***Charge.*** If the goat moves at least 20 ft. straight toward a target and then hits it with a ram attack on the same turn, the target takes an extra 2 (1d4) bludgeoning damage. If the target is a creature, it must succeed on a DC 10 Strength saving throw or be knocked prone.\n\n***Sure-Footed.*** The goat has advantage on Strength and Dexterity saving throws made against effects that would knock it prone.",
			"***Ram.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
