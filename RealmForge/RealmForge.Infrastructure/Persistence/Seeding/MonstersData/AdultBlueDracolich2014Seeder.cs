using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Adult Blue Dracolich (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class AdultBlueDracolich2014Seeder
{
	public static Monster Build() => Create("adult-blue-dracolich", null, ContentSource.RealmForge, CreatureSize.Huge, CreatureType.Undead,
		19, 225, "18d12 + 108", 40, new[] { 25, 10, 23, 16, 15, 19 }, 17m, 18000, 6, 22,
		new Text(
			"Dracolich blu adulto",
			null,
			"Non morto Enorme, legale malvagio",
			"19 (armatura naturale)",
			"12 m, scavare 9 m, volare 24 m",
			"Car +9, Cos +11, Des +5, Sag +7",
			"Furtività +5, Percezione +12",
			"",
			"necrotici",
			"fulmine, veleno",
			"affascinato, avvelenato, indebolimento, paralizzato, spaventato",
			"Percezione passiva 22, scurovisione 36 m, vista cieca 18 m",
			"Comune, Draconico",
			"***Resistenza leggendaria (3/giorno).*** Se il dracolich fallisce un tiro salvezza, può scegliere di superarlo comunque.\n\n***Resistenza alla magia.*** Il dracolich dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il dracolich può usare la sua Presenza terrificante, poi effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Morso.*** *Attacco con arma da mischia:* +12 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 18 (2d10 + 7) danni perforanti più 5 (1d10) danni da fulmine.\n\n***Artiglio.*** *Attacco con arma da mischia:* +12 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (2d6 + 7) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +12 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 16 (2d8 + 7) danni contundenti.\n\n***Presenza terrificante.*** Ogni creatura a scelta del dracolich che si trova entro 36 metri da lui ed è consapevole della sua presenza effettua un tiro salvezza su Saggezza con CD 18, altrimenti è spaventata per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo. Una creatura che lo supera, o per cui l'effetto termina, è immune alla Presenza terrificante di questo dracolich per 24 ore.\n\n***Soffio di fulmini (ricarica 5–6).*** Il dracolich esala fulmini in una linea lunga 27 metri e larga 1,5 metri. Ogni creatura sulla linea effettua un tiro salvezza su Destrezza con CD 20 e subisce 66 (12d10) danni da fulmine se lo fallisce, o la metà se lo supera.",
			"",
			"",
			"Il dracolich può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il dracolich recupera le azioni leggendarie effettuate.\n\n***Individuare.*** Il dracolich effettua una prova di Saggezza (Percezione).\n\n***Attacco con la coda.*** Il dracolich effettua un attacco con la coda.\n\n***Attacco d'ala (costa 2 azioni).*** Il dracolich sbatte le sue ali lacere. Ogni creatura entro 3 metri da lui effettua un tiro salvezza su Destrezza con CD 21, altrimenti subisce 14 (2d6 + 7) danni contundenti e cade prona. Il dracolich può poi volare fino a metà della sua velocità di volare.",
			""),
		new Text(
			"Adult Blue Dracolich",
			null,
			"Huge undead, lawful evil",
			"19 (natural armor)",
			"40 ft., burrow 30 ft., fly 80 ft.",
			"Dex +5, Con +11, Wis +7, Cha +9",
			"Perception +12, Stealth +5",
			"",
			"necrotic",
			"lightning, poison",
			"charmed, exhaustion, frightened, paralyzed, poisoned",
			"blindsight 60 ft., darkvision 120 ft., passive Perception 22",
			"Common, Draconic",
			"***Legendary Resistance (3/Day).*** If the dracolich fails a saving throw, it can choose to succeed instead.\n\n***Magic Resistance.*** The dracolich has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The dracolich can use its Frightful Presence, then makes three attacks: one bite and two claw attacks.\n\n***Bite.*** *Melee Weapon Attack:* +12 to hit, reach 10 ft., one target. *Hit:* 18 (2d10 + 7) piercing damage plus 5 (1d10) lightning damage.\n\n***Claw.*** *Melee Weapon Attack:* +12 to hit, reach 5 ft., one target. *Hit:* 14 (2d6 + 7) slashing damage.\n\n***Tail.*** *Melee Weapon Attack:* +12 to hit, reach 15 ft., one target. *Hit:* 16 (2d8 + 7) bludgeoning damage.\n\n***Frightful Presence.*** Each creature of the dracolich's choice within 120 feet of it that is aware of it makes a DC 18 Wisdom saving throw or is frightened for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success. A creature that succeeds, or whose fear ends, is immune to this dracolich's Frightful Presence for 24 hours.\n\n***Lightning Breath (Recharge 5–6).*** The dracolich breathes lightning in a 90-foot line, 5 feet wide. Each creature in the line makes a DC 20 Dexterity saving throw, taking 66 (12d10) lightning damage on a failure, or half as much on a success.",
			"",
			"",
			"The dracolich can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The dracolich regains spent legendary actions at the start of its turn.\n\n***Detect.*** The dracolich makes a Wisdom (Perception) check.\n\n***Tail Attack.*** The dracolich makes a tail attack.\n\n***Wing Attack (Costs 2 Actions).*** The dracolich beats its ragged wings. Each creature within 10 feet of it makes a DC 21 Dexterity saving throw or takes 14 (2d6 + 7) bludgeoning damage and is knocked prone. The dracolich can then fly up to half its flying speed.",
			""));
}
