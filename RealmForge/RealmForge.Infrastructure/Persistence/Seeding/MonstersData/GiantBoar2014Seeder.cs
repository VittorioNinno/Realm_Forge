using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Boar (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantBoar2014Seeder
{
	public static Monster Build() => Create("giant-boar", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		12, 42, "5d10 + 15", 40, new[] { 17, 10, 16, 2, 7, 5 }, 2m, 450, 2, 8,
		new Text(
			"Cinghiale gigante",
			null,
			"Bestia Grande, senza allineamento",
			"12 (armatura naturale)",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 8",
			"—",
			"***Carica.*** Se il cinghiale si muove di almeno 6 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco con le zanne nello stesso turno, il bersaglio subisce 7 (2d6) danni taglienti extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 13, altrimenti cade a terra prono.\n\n***Implacabile (ricarica dopo un riposo breve o lungo).*** Se il cinghiale subisce un massimo di 10 danni che lo porterebbero a 0 punti ferita, viene ridotto invece a 1 punto ferita.",
			"***Zanne.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Boar",
			null,
			"Large beast, unaligned",
			"12 (natural armor)",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 8",
			"—",
			"***Charge.*** If the boar moves at least 20 ft. straight toward a target and then hits it with a tusk attack on the same turn, the target takes an extra 7 (2d6) slashing damage. If the target is a creature, it must succeed on a DC 13 Strength saving throw or be knocked prone.\n\n***Relentless (Recharges after a Short or Long Rest).*** If the boar takes 10 damage or less that would reduce it to 0 hit points, it is reduced to 1 hit point instead.",
			"***Tusk.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) slashing damage.",
			"",
			"",
			"",
			""));
}
