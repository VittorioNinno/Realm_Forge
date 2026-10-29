using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Revenant (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Revenant2014Seeder
{
	public static Monster Build() => Create("revenant", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Undead,
		13, 136, "16d8 + 64", 30, new[] { 18, 14, 18, 13, 16, 18 }, 5m, 1800, 3, 13,
		new Text(
			"Revenant",
			null,
			"Non morto Medio, neutrale",
			"13 (armatura di cuoio)",
			"9 m",
			"Car +7, Cos +7, For +7, Sag +6",
			"",
			"",
			"necrotici, psichici",
			"veleno",
			"affascinato, avvelenato, indebolimento, paralizzato, spaventato, stordito",
			"Percezione passiva 13, scurovisione 18 m",
			"i linguaggi che conosceva in vita",
			"***Rigenerazione.*** Il revenant recupera 10 punti ferita all'inizio del suo turno, a meno che dal turno precedente non abbia subito danni da fuoco o radiosi. Il suo corpo viene distrutto solo se inizia il turno a 0 punti ferita e non si rigenera.\n\n***Ringiovanimento.*** Quando il suo corpo viene distrutto, l'anima del revenant resta. Dopo 24 ore si impossessa di un altro cadavere sullo stesso piano e recupera tutti i suoi punti ferita. Finché l'anima è senza corpo, un incantesimo *desiderio* può mandarla per sempre nell'aldilà.\n\n***Immunità allo scacciare.*** Gli effetti che scacciano i non morti non hanno effetto sul revenant.\n\n***Segugio vendicativo.*** Il revenant conosce sempre la distanza e la direzione di ogni creatura contro cui ha giurato vendetta, anche se si trova su un altro piano, e sa quando una di esse muore.",
			"***Multiattacco.*** Il revenant effettua due attacchi con i pugni.\n\n***Pugno.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti. Una creatura contro cui il revenant ha giurato vendetta subisce 14 (4d6) danni contundenti extra. Invece di infliggere danni, il revenant può afferrare un bersaglio di taglia Grande o inferiore (CD 14 per sfuggire).\n\n***Sguardo vendicativo.*** Una creatura che il revenant è in grado di vedere entro 9 metri da lui, e contro cui ha giurato vendetta, effettua un tiro salvezza su Saggezza con CD 15. Se lo fallisce è paralizzata finché il revenant non le infligge danni o fino alla fine del turno successivo del revenant; poi è spaventata dal revenant per 1 minuto, ripete il tiro salvezza alla fine di ogni suo turno (con svantaggio se può vedere il revenant) e la paura termina con un successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Revenant",
			null,
			"Medium undead, neutral",
			"13 (leather armor)",
			"30 ft.",
			"Str +7, Con +7, Wis +6, Cha +7",
			"",
			"",
			"necrotic, psychic",
			"poison",
			"charmed, exhaustion, frightened, paralyzed, poisoned, stunned",
			"darkvision 60 ft., passive Perception 13",
			"the languages it knew in life",
			"***Regeneration.*** The revenant regains 10 hit points at the start of its turn, unless it took fire or radiant damage since its previous turn. Its body is destroyed only if it starts its turn at 0 hit points and doesn't regenerate.\n\n***Rejuvenation.*** When its body is destroyed, the revenant's soul remains. After 24 hours it takes over another corpse on the same plane and regains all its hit points. While the soul has no body, a wish spell can send it to the afterlife for good.\n\n***Turn Immunity.*** Effects that turn undead have no effect on the revenant.\n\n***Vengeful Tracker.*** The revenant always knows the distance and direction to every creature it has sworn vengeance against, even on another plane, and knows when such a creature dies.",
			"***Multiattack.*** The revenant makes two fist attacks.\n\n***Fist.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage. A creature the revenant has sworn vengeance against takes an extra 14 (4d6) bludgeoning damage. Instead of dealing damage, the revenant can grapple a Large or smaller target (escape DC 14).\n\n***Vengeful Glare.*** A creature the revenant can see within 30 feet of it, and against which it has sworn vengeance, makes a DC 15 Wisdom saving throw. On a failure it is paralyzed until the revenant damages it or until the end of the revenant's next turn; then it is frightened of the revenant for 1 minute, repeating the save at the end of each of its turns (with disadvantage if it can see the revenant) and ending the fear on a success.",
			"",
			"",
			"",
			""));
}
