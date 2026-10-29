using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gnoll Fang of Yeenoghu (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GnollFangOfYeenoghu2014Seeder
{
	public static Monster Build() => Create("gnoll-fang-of-yeenoghu", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Fiend,
		14, 65, "10d8 + 20", 30, new[] { 17, 15, 15, 10, 11, 13 }, 4m, 1100, 2, 10,
		new Text(
			"Gnoll zanna di Yeenoghu",
			null,
			"Immondo Medio (gnoll), caotico malvagio",
			"14 (armatura di pelle)",
			"9 m",
			"Car +3, Cos +4, Sag +2",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Abissale, Gnoll",
			"***Furia.*** Quando lo gnoll porta una creatura a 0 punti ferita con un attacco in mischia durante il suo turno, può effettuare un'azione bonus per muoversi fino a metà della sua velocità ed effettuare un attacco con il morso.",
			"***Multiattacco.*** Lo gnoll effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 6 (1d6 + 3) danni perforanti. Il bersaglio effettua un tiro salvezza su Costituzione con CD 12, altrimenti subisce 7 (2d6) danni da veleno.\n\n***Artiglio.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Gnoll Fang of Yeenoghu",
			null,
			"Medium fiend (gnoll), chaotic evil",
			"14 (hide armor)",
			"30 ft.",
			"Con +4, Wis +2, Cha +3",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Abyssal, Gnoll",
			"***Rampage.*** When the gnoll drops a creature to 0 hit points with a melee attack on its turn, it can take a bonus action to move up to half its speed and make a bite attack.",
			"***Multiattack.*** The gnoll makes three attacks: one bite and two claw attacks.\n\n***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* 6 (1d6 + 3) piercing damage. The target makes a DC 12 Constitution saving throw or takes 7 (2d6) poison damage.\n\n***Claw.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) slashing damage.",
			"",
			"",
			"",
			""));
}
