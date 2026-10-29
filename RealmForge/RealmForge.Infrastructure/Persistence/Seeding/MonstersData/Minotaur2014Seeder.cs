using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Minotaur (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Minotaur2014Seeder
{
	public static Monster Build() => Create("minotaur", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Monstrosity,
		14, 76, "9d10 + 27", 40, new[] { 18, 11, 16, 6, 16, 9 }, 3m, 700, 2, 17,
		new Text(
			"Minotauro",
			null,
			"Mostruosità Grande, caotico malvagio",
			"14 (armatura naturale)",
			"12 m",
			"",
			"Percezione +7",
			"",
			"",
			"",
			"",
			"Percezione passiva 17, scurovisione 18 m",
			"Abissale",
			"***Avventato.*** All'inizio del suo turno, il minotauro può ottenere un vantaggio a tutti i tiri per colpire con arma da mischia durante quel turno; tuttavia, i tiri per colpirlo hanno un vantaggio fino all'inizio del suo turno successivo.\n\n***Carica.*** Se il minotauro si muove di almeno 3 metri in linea retta verso un bersaglio e poi lo colpisce con un'incornata nello stesso turno, la vittima subisce 9 (2d8) danni perforanti extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 14, altrimenti viene scagliato a 3 metri di distanza e buttato a terra prono.\n\n***Ricordo labirintico.*** Il minotauro è in grado di ricordarsi alla perfezione qualsiasi tragitto abbia già percorso.",
			"***Ascia bipenne.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 17 (2d12 + 4) danni taglienti.\n\n***Incornata.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Minotaur",
			null,
			"Large monstrosity, chaotic evil",
			"14 (natural armor)",
			"40 ft.",
			"",
			"Perception +7",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 17",
			"Abyssal",
			"***Charge.*** If the minotaur moves at least 10 ft. straight toward a target and then hits it with a gore attack on the same turn, the target takes an extra 9 (2d8) piercing damage. If the target is a creature, it must succeed on a DC 14 Strength saving throw or be pushed up to 10 ft. away and knocked prone.\n\n***Labyrinthine Recall.*** The minotaur can perfectly recall any path it has traveled.\n\n***Reckless.*** At the start of its turn, the minotaur can gain advantage on all melee weapon attack rolls it makes during that turn, but attack rolls against it have advantage until the start of its next turn.",
			"***Greataxe.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 17 (2d12 + 4) slashing damage.\n\n***Gore.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) piercing damage.",
			"",
			"",
			"",
			""));
}
