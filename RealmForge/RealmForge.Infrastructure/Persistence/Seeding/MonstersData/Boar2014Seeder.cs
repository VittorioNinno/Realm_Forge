using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Boar (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Boar2014Seeder
{
	public static Monster Build() => Create("boar", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		11, 11, "2d8 + 2", 40, new[] { 13, 11, 12, 2, 9, 5 }, 0.25m, 50, 2, 9,
		new Text(
			"Cinghiale",
			null,
			"Bestia Media, senza allineamento",
			"11 (armatura naturale)",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 9",
			"—",
			"***Carica.*** Se il cinghiale si muove di almeno 6 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco con le zanne nello stesso turno, il bersaglio subisce 3 (1d6) danni taglienti extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 11, altrimenti cade a terra prono.\n\n***Implacabile (ricarica dopo un riposo breve o lungo).*** Se il cinghiale subisce un massimo di 7 danni che lo porterebbero a 0 punti ferita, è ridotto invece a 1 punto ferita.",
			"***Zanne.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Boar",
			null,
			"Medium beast, unaligned",
			"11 (natural armor)",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 9",
			"—",
			"***Charge.*** If the boar moves at least 20 ft. straight toward a target and then hits it with a tusk attack on the same turn, the target takes an extra 3 (1d6) slashing damage. If the target is a creature, it must succeed on a DC 11 Strength saving throw or be knocked prone.\n\n***Relentless (Recharges after a Short or Long Rest).*** If the boar takes 7 damage or less that would reduce it to 0 hit points, it is reduced to 1 hit point instead.",
			"***Tusk.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 4 (1d6 + 1) slashing damage.",
			"",
			"",
			"",
			""));
}
