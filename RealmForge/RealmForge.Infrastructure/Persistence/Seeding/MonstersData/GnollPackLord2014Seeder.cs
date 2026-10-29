using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gnoll Pack Lord (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GnollPackLord2014Seeder
{
	public static Monster Build() => Create("gnoll-pack-lord", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		15, 49, "9d8 + 9", 30, new[] { 16, 14, 13, 8, 11, 9 }, 2m, 450, 2, 10,
		new Text(
			"Gnoll signore del branco",
			null,
			"Umanoide Medio (gnoll), caotico malvagio",
			"15 (giaco di maglia)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Gnoll",
			"***Furia.*** Quando lo gnoll porta una creatura a 0 punti ferita con un attacco in mischia durante il suo turno, può effettuare un'azione bonus per muoversi fino a metà della sua velocità ed effettuare un attacco con il morso.",
			"***Multiattacco.*** Lo gnoll effettua due attacchi, con il falcione o con l'arco lungo, e usa Incitare alla furia se può.\n\n***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 5 (1d4 + 3) danni perforanti.\n\n***Falcione.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 8 (1d10 + 3) danni taglienti.\n\n***Arco lungo.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti.\n\n***Incitare alla furia (ricarica 5–6).*** Una creatura che lo gnoll è in grado di vedere entro 9 metri da lui, che può sentirlo e possiede il tratto Furia, può usare la sua reazione per effettuare un attacco in mischia.",
			"",
			"",
			"",
			""),
		new Text(
			"Gnoll Pack Lord",
			null,
			"Medium humanoid (gnoll), chaotic evil",
			"15 (chain shirt)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Gnoll",
			"***Rampage.*** When the gnoll drops a creature to 0 hit points with a melee attack on its turn, it can take a bonus action to move up to half its speed and make a bite attack.",
			"***Multiattack.*** The gnoll makes two attacks, with its glaive or its longbow, and uses Incite Rampage if it can.\n\n***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* 5 (1d4 + 3) piercing damage.\n\n***Glaive.*** *Melee Weapon Attack:* +5 to hit, reach 10 ft., one target. *Hit:* 8 (1d10 + 3) slashing damage.\n\n***Longbow.*** *Ranged Weapon Attack:* +4 to hit, range 150/600 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage.\n\n***Incite Rampage (Recharge 5–6).*** One creature the gnoll can see within 30 feet of it that can hear it and has the Rampage trait can use its reaction to make a melee attack.",
			"",
			"",
			"",
			""));
}
