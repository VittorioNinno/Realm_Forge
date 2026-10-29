using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Grell (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Grell2014Seeder
{
	public static Monster Build() => Create("grell", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Aberration,
		12, 55, "10d8 + 10", 10, new[] { 15, 14, 13, 12, 11, 9 }, 3m, 700, 2, 14,
		new Text(
			"Grell",
			null,
			"Aberrazione Media, neutrale malvagio",
			"12",
			"3 m, volare 9 m (fluttuare)",
			"",
			"Furtività +6, Percezione +4",
			"",
			"",
			"fulmine",
			"accecato, prono",
			"Percezione passiva 14, vista cieca 18 m (cieco oltre questo raggio)",
			"Grell",
			"",
			"***Multiattacco.*** Il grell effettua due attacchi: uno con i tentacoli e uno con il becco.\n\n***Tentacoli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 7 (1d10 + 2) danni perforanti. Il bersaglio effettua un tiro salvezza su Costituzione con CD 11, altrimenti è avvelenato per 1 minuto e resta paralizzato finché è avvelenato; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.\n\nIl bersaglio è anche afferrato (CD 15 per sfuggire) e, se è di taglia Media o inferiore, resta trattenuto finché dura la presa. Finché lo trattiene, il grell dispone di vantaggio ai tiri per colpire contro di lui, non può usare questo attacco contro nessun altro e, quando si muove, trascina con sé un bersaglio di taglia Media o inferiore.\n\n***Becco.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 7 (2d4 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Grell",
			null,
			"Medium aberration, neutral evil",
			"12",
			"10 ft., fly 30 ft. (hover)",
			"",
			"Perception +4, Stealth +6",
			"",
			"",
			"lightning",
			"blinded, prone",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 14",
			"Grell",
			"",
			"***Multiattack.*** The grell makes two attacks: one with its tentacles and one with its beak.\n\n***Tentacles.*** *Melee Weapon Attack:* +4 to hit, reach 10 ft., one creature. *Hit:* 7 (1d10 + 2) piercing damage. The target makes a DC 11 Constitution saving throw or is poisoned for 1 minute, and paralyzed for as long as it is poisoned; it repeats the save at the end of each of its turns, ending the effect on a success.\n\nThe target is also grappled (escape DC 15) and, if Medium or smaller, restrained for as long as the grapple lasts. While it holds the target, the grell has advantage on attack rolls against it, can't use this attack on anyone else, and carries a Medium or smaller target along when it moves.\n\n***Beak.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 7 (2d4 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
