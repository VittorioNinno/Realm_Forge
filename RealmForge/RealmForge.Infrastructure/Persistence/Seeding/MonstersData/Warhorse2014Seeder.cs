using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Warhorse (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Warhorse2014Seeder
{
	public static Monster Build() => Create("warhorse", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		11, 19, "3d10 + 3", 60, new[] { 18, 12, 13, 2, 12, 7 }, 0.5m, 100, 2, 11,
		new Text(
			"Cavallo da guerra",
			null,
			"Bestia Grande, senza allineamento",
			"11",
			"18 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11",
			"—",
			"***Carica travolgente.*** Se il cavallo si muove di almeno 6 metri in linea retta verso una creatura e poi la colpisce con un attacco con gli zoccoli nello stesso turno, quel bersaglio deve superare un tiro salvezza su Forza con CD 14, altrimenti cade a terra prono. Se il bersaglio è prono, il cavallo può effettuare un altro attacco con gli zoccoli contro di esso come azione bonus.",
			"***Zoccoli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Warhorse",
			null,
			"Large beast, unaligned",
			"11",
			"60 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 11",
			"—",
			"***Trampling Charge.*** If the horse moves at least 20 ft. straight toward a creature and then hits it with a hooves attack on the same turn, that target must succeed on a DC 14 Strength saving throw or be knocked prone. If the target is prone, the horse can make another attack with its hooves against it as a bonus action.",
			"***Hooves.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
