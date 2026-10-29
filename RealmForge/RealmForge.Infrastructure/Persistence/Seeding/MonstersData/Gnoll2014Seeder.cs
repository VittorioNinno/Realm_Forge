using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gnoll (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Gnoll2014Seeder
{
	public static Monster Build() => Create("gnoll", null, CreatureSize.Medium, CreatureType.Humanoid,
		15, 22, "5d8", 30, new[] { 14, 12, 11, 6, 10, 7 }, 0.5m, 100, 2, 10,
		new Text(
			"Gnoll",
			null,
			"Umanoide Medio (gnoll), caotico malvagio",
			"15 (armatura di pelle, scudo)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Gnoll",
			"***Furia.*** Quando lo gnoll riduce una creatura a 0 punti ferita con un attacco in mischia nel suo turno, il mostro può effettuare un'azione bonus per muoversi fino a metà della sua velocità ed effettuare un attacco con il morso.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 4 (1d4 + 2) danni perforanti.\n\n***Lancia.*** *Attacco con arma da mischia o a distanza:* +4 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti o 6 (1d8 + 2) danni perforanti se impugnata con due mani per effettuare un attacco in mischia.\n\n***Arco lungo.*** *Attacco con arma a distanza:* +3 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 5 (1d8 + 1) danni perforanti.",
			"",
			""),
		new Text(
			"Gnoll",
			null,
			"Medium humanoid (gnoll), chaotic evil",
			"15 (hide armor, shield)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Gnoll",
			"***Rampage.*** When the gnoll reduces a creature to 0 hit points with a melee attack on its turn, the gnoll can take a bonus action to move up to half its speed and make a bite attack.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 4 (1d4 + 2) piercing damage.\n\n***Spear.*** *Melee or Ranged Weapon Attack:* +4 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage, or 6 (1d8 + 2) piercing damage if used with two hands to make a melee attack.\n\n***Longbow.*** *Ranged Weapon Attack:* +3 to hit, range 150/600 ft., one target. *Hit:* 5 (1d8 + 1) piercing damage.",
			"",
			""));
}
