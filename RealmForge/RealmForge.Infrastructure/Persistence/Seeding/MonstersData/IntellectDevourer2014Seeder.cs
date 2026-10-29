using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Intellect Devourer (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class IntellectDevourer2014Seeder
{
	public static Monster Build() => Create("intellect-devourer", null, ContentSource.RealmForge, CreatureSize.Tiny, CreatureType.Aberration,
		12, 21, "6d4 + 6", 40, new[] { 6, 14, 13, 12, 11, 10 }, 2m, 450, 2, 12,
		new Text(
			"Divoracervelli",
			null,
			"Aberrazione Minuscola, legale malvagio",
			"12",
			"12 m",
			"",
			"Furtività +4, Percezione +2",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"accecato",
			"Percezione passiva 12, vista cieca 18 m (cieco oltre questo raggio)",
			"capisce il Gergo delle profondità ma non lo parla, telepatia 18 m",
			"***Percepire le menti.*** Il divoracervelli percepisce la presenza e la posizione di ogni creatura con Intelligenza 3 o superiore entro 90 metri da lui, qualunque cosa si trovi in mezzo, a meno che la creatura non sia protetta da un incantesimo *vuoto mentale*.",
			"***Multiattacco.*** Il divoracervelli effettua un attacco con gli artigli e usa Divorare intelletto.\n\n***Artigli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (2d4 + 2) danni taglienti.\n\n***Divorare intelletto.*** Una creatura dotata di cervello che il divoracervelli è in grado di vedere entro 3 metri da lui effettua un tiro salvezza su Intelligenza con CD 12 contro questa magia. Se lo fallisce subisce 11 (2d10) danni psichici, e il divoracervelli tira 3d6: se il totale è pari o superiore al punteggio di Intelligenza del bersaglio, quel punteggio scende a 0, e il bersaglio è stordito finché non recupera almeno 1 punto di Intelligenza.\n\n***Ladro di corpi.*** Il divoracervelli avvia una prova contrapposta di Intelligenza con un umanoide incapacitato entro 1,5 metri da lui. Se vince, divora magicamente il cervello del bersaglio, si teletrasporta nel suo cranio e prende il controllo del corpo. Al suo interno ha copertura totale contro attacchi ed effetti provenienti dall'esterno; mantiene la sua Intelligenza, Saggezza e Carisma, la comprensione del Gergo delle profondità, la telepatia e i suoi tratti, usa le altre statistiche dell'ospite e conosce tutto ciò che l'ospite conosceva, incantesimi e linguaggi compresi.\n\nDeve uscire se il corpo scende a 0 punti ferita, e viene scacciato da un incantesimo *protezione dal bene e dal male* lanciato sul corpo o se l'ospite riottiene il suo cervello tramite un *desiderio*. Può anche uscire di sua volontà spendendo 1,5 metri di movimento, teletrasportandosi nello spazio libero più vicino entro 1,5 metri; il corpo allora muore, a meno che il suo cervello non venga ripristinato entro 1 round.",
			"",
			"",
			"",
			""),
		new Text(
			"Intellect Devourer",
			null,
			"Tiny aberration, lawful evil",
			"12",
			"40 ft.",
			"",
			"Perception +2, Stealth +4",
			"",
			"bludgeoning, piercing, and slashing from nonmagical attacks",
			"",
			"blinded",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 12",
			"understands Deep Speech but can't speak, telepathy 60 ft.",
			"***Detect Sentience.*** The intellect devourer senses the presence and position of every creature with Intelligence 3 or higher within 300 feet of it, whatever lies in between, unless the creature is protected by a mind blank spell.",
			"***Multiattack.*** The intellect devourer makes one claws attack and uses Devour Intellect.\n\n***Claws.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (2d4 + 2) slashing damage.\n\n***Devour Intellect.*** One creature with a brain that the intellect devourer can see within 10 feet of it makes a DC 12 Intelligence saving throw against this magic. On a failure it takes 11 (2d10) psychic damage, and the devourer rolls 3d6: if the total equals or exceeds the target's Intelligence score, that score drops to 0, and the target is stunned until it regains at least 1 point of Intelligence.\n\n***Body Thief.*** The intellect devourer starts an Intelligence contest with an incapacitated humanoid within 5 feet of it. If it wins, it magically eats the target's brain, teleports into its skull and takes over its body. Inside, it has total cover against attacks and effects coming from outside; it keeps its own Intelligence, Wisdom and Charisma, its understanding of Deep Speech, its telepathy and its traits, uses the host's other statistics, and knows everything the host knew, spells and languages included.\n\nIt must leave if the body drops to 0 hit points, and it is driven out by a protection from evil and good spell cast on the body or if the host gets its brain back through a wish. It can also leave on its own by spending 5 feet of movement, teleporting to the nearest free space within 5 feet; the body then dies, unless its brain is restored within 1 round.",
			"",
			"",
			"",
			""));
}
