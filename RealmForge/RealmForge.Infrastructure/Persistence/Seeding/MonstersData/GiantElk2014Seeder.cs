using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Elk (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantElk2014Seeder
{
	public static Monster Build() => Create("giant-elk", null, ContentSource.Srd51, CreatureSize.Huge, CreatureType.Beast,
		14, 42, "5d12 + 10", 60, new[] { 19, 16, 14, 7, 14, 10 }, 2m, 450, 2, 14,
		new Text(
			"Alce gigante",
			null,
			"Bestia Enorme, senza allineamento",
			"14 (armatura naturale)",
			"18 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"Alce Gigante, capisce il Comune, l'Elfico e il Silvano ma non li parla",
			"***Carica.*** Se l'alce si muove di almeno 6 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco da sfondamento nello stesso turno, il bersaglio subisce 7 (2d6) danni extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 14, altrimenti cade a terra prono.",
			"***Sfondamento.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti.\n\n***Zoccoli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, una creatura prona. *Colpito:* 22 (4d8 + 4) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Elk",
			null,
			"Huge beast, unaligned",
			"14 (natural armor)",
			"60 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"Giant Elk, understands Common, Elvish, and Sylvan but can't speak",
			"***Charge.*** If the elk moves at least 20 ft. straight toward a target and then hits it with a ram attack on the same turn, the target takes an extra 7 (2d6) damage. If the target is a creature, it must succeed on a DC 14 Strength saving throw or be knocked prone.",
			"***Ram.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage.\n\n***Hooves.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one prone creature. *Hit:* 22 (4d8 + 4) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
