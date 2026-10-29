using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Hyena (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantHyena2014Seeder
{
	public static Monster Build() => Create("giant-hyena", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		12, 45, "6d10 + 12", 50, new[] { 16, 14, 14, 2, 12, 7 }, 1m, 200, 2, 13,
		new Text(
			"Iena gigante",
			null,
			"Bestia Grande, senza allineamento",
			"12",
			"15 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Furia.*** Quando la iena riduce una creatura a 0 punti ferita con un attacco in mischia nel suo turno, la iena può effettuare un'azione bonus per muoversi fino a metà della sua velocità ed effettuare un attacco con il morso.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Hyena",
			null,
			"Large beast, unaligned",
			"12",
			"50 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Rampage.*** When the hyena reduces a creature to 0 hit points with a melee attack on its turn, the hyena can take a bonus action to move up to half its speed and make a bite attack.",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) piercing damage.",
			"",
			"",
			"",
			""));
}
