using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Umber Hulk (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class UmberHulk2014Seeder
{
	public static Monster Build() => Create("umber-hulk", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Monstrosity,
		18, 93, "11d10 + 33", 30, new[] { 20, 13, 16, 9, 10, 10 }, 5m, 1800, 3, 10,
		new Text(
			"Umber hulk",
			null,
			"Mostruosità Grande, caotico malvagio",
			"18 (armatura naturale)",
			"9 m, scavare 6 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, percezione tellurica 18 m, scurovisione 36 m",
			"Umber hulk",
			"***Sguardo confondente.*** Quando una creatura in grado di vedere gli occhi dell'umber hulk inizia il suo turno entro 9 metri da lui, l'umber hulk (se non è incapacitato) può costringerla magicamente a effettuare un tiro salvezza su Carisma con CD 15. Se lo fallisce, la creatura non può effettuare reazioni fino all'inizio del suo turno successivo e tira un d8 per stabilire cosa fa in quel turno: con 1–4 nulla; con 5–6 non effettua azioni ma usa tutto il suo movimento per andare in una direzione casuale; con 7–8 effettua un attacco in mischia contro una creatura casuale entro la sua portata, o non fa nulla se non ce ne sono.\n\nUna creatura che non è sorpresa può distogliere lo sguardo all'inizio del suo turno per evitare il tiro salvezza; in tal caso non può vedere l'umber hulk fino all'inizio del suo turno successivo, e se lo guarda nel frattempo deve effettuare subito il tiro salvezza.\n\n***Scavatore.*** L'umber hulk può scavare nella roccia solida a metà della sua velocità di scavare, lasciandosi dietro un tunnel largo 1,5 metri e alto 2,4 metri.",
			"***Multiattacco.*** L'umber hulk effettua tre attacchi: due con gli artigli e uno con le mandibole.\n\n***Artiglio.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (1d8 + 5) danni taglienti.\n\n***Mandibole.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (2d8 + 5) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Umber Hulk",
			null,
			"Large monstrosity, chaotic evil",
			"18 (natural armor)",
			"30 ft., burrow 20 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., tremorsense 60 ft., passive Perception 10",
			"Umber Hulk",
			"***Confusing Gaze.*** When a creature that can see the umber hulk's eyes starts its turn within 30 feet of it, the umber hulk (unless incapacitated) can magically force it to make a DC 15 Charisma saving throw. On a failure, the creature can't take reactions until the start of its next turn and rolls a d8 to see what it does that turn: on 1–4 nothing; on 5–6 it takes no action but spends all its movement going in a random direction; on 7–8 it makes one melee attack against a random creature within its reach, or does nothing if there is none.\n\nA creature that isn't surprised can avert its eyes at the start of its turn to skip the save; it then can't see the umber hulk until the start of its next turn, and if it looks at it meanwhile it must make the save at once.\n\n***Tunneler.*** The umber hulk can burrow through solid rock at half its burrowing speed, leaving a tunnel 5 feet wide and 8 feet high behind it.",
			"***Multiattack.*** The umber hulk makes three attacks: two with its claws and one with its mandibles.\n\n***Claw.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 9 (1d8 + 5) slashing damage.\n\n***Mandibles.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 14 (2d8 + 5) slashing damage.",
			"",
			"",
			"",
			""));
}
