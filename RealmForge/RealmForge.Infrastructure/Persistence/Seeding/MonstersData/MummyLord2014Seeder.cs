using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Mummy Lord (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class MummyLord2014Seeder
{
	public static Monster Build() => Create("mummy-lord", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Undead,
		17, 97, "13d8 + 39", 20, new[] { 18, 10, 17, 11, 18, 16 }, 15m, 13000, 5, 14,
		new Text(
			"Signore delle mummie",
			null,
			"Non morto Medio, legale malvagio",
			"17 (armatura naturale)",
			"6 m",
			"Car +8, Cos +8, Int +5, Sag +9",
			"Religione +5, Storia +5",
			"fuoco",
			"",
			"necrotici, veleno; contundenti, perforanti e taglienti da attacchi non magici",
			"affascinato, avvelenato, indebolimento, paralizzato, spaventato",
			"Percezione passiva 14, scurovisione 18 m",
			"quelli conosciuti in vita",
			"***Incantesimi.*** Il signore delle mummie è un incantatore di 10° livello: la sua caratteristica da incantatore è Saggezza (CD del tiro salvezza sull'incantesimo 17, +9 al tiro per colpire con attacco con incantesimo). Ha a disposizione i seguenti incantesimi da chierico:\n\n- Trucchetti (a volontà): *fiamma sacra, taumaturgia*\n- 1° livello (4 slot): *comando, dardo tracciante, scudo della fede*\n- 2° livello (3 slot): *arma spirituale, blocca persone, silenzio*\n- 3° livello (3 slot): *animare morti, dissolvi magie*\n- 4° livello (3 slot): *divinazione, guardiano della fede*\n- 5° livello (2 slot): *contagio, piaga degli insetti*\n- 6° livello (1 slot): *ferire*\n\n***Resistenza alla magia.*** Il signore delle mummie dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Rigenerazione.*** Un signore delle mummie distrutto ottiene un nuovo corpo nel giro di 24 ore se il suo cuore è intatto, recuperando tutti i suoi punti ferita e tornando a essere attivo. Il nuovo corpo compare entro 1,5 metri dal cuore del signore delle mummie.",
			"***Multiattacco.*** La mummia può usare lo sguardo funesto ed effettuare un attacco con il pugno di putrefazione.\n\n***Pugno di putrefazione.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (3d6 + 4) danni contundenti più 21 (6d6) danni necrotici. Se il bersaglio è una creatura, deve superare un tiro salvezza su Costituzione con CD 16, altrimenti è maledetto dalla putrefazione della mummia. In tal caso, non può riguadagnare punti ferita e i suoi punti ferita massimi diminuiscono di 10 (3d6) ogni 24 ore trascorse. Se la maledizione riduce i punti ferita massimi del bersaglio a 0, quest'ultimo muore e il suo corpo si trasforma in polvere. La maledizione permane finché non viene rimossa da un incantesimo *rimuovi maledizione* o da una magia analoga.\n\n***Sguardo funesto.*** Il signore delle mummie prende di mira una creatura nel suo campo visivo in un raggio di 18 metri. Se il bersaglio può vedere il signore delle mummie, deve superare un tiro salvezza su Saggezza con CD 16 contro questa magia, altrimenti è spaventato fino alla fine del turno successivo del mostro. Se il bersaglio fallisce il tiro salvezza di 5 o più, è anche paralizzato per la stessa durata. Un bersaglio che supera il tiro salvezza è immune allo sguardo funesto di tutte le mummie e di tutti i signori delle mummie per le 24 ore successive.",
			"",
			"",
			"Il signore delle mummie può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il signore delle mummie recupera le azioni leggendarie effettuate.\n\n***Attacco.*** Il signore delle mummie effettua un attacco con il pugno di putrefazione o usa lo sguardo funesto.\n\n***Polvere accecante.*** Una nube di polvere e sabbia accecante si solleva magicamente attorno al signore delle mummie. Ogni creatura entro 1,5 metri da lui deve superare un tiro salvezza su Costituzione con CD 16, altrimenti è accecata fino alla fine del proprio turno successivo.\n\n***Incanalare energia negativa (costa 2 azioni).*** Il signore delle mummie scatena magicamente un'ondata di energia negativa. Le creature entro 18 metri dal signore delle mummie, incluse quelle dietro una barriera o oltre un angolo, non possono recuperare punti ferita fino alla fine del turno successivo del signore delle mummie.\n\n***Parola blasfema (costa 2 azioni).*** Il signore delle mummie pronuncia una parola blasfema. Ogni creatura che non sia un non morto, situata entro 3 metri dal signore delle mummie e che possa sentire l'enunciazione magica, deve superare un tiro salvezza su Costituzione con CD 16, altrimenti è stordita fino alla fine del turno successivo del mostro.\n\n***Turbine di sabbia (costa 2 azioni).*** Il signore delle mummie si trasforma magicamente in un turbine di sabbia, si sposta al massimo di 18 metri e torna alla sua forma normale. Finché è in forma di turbine, è immune a tutti i danni e non può essere afferrato, pietrificato, buttato a terra prono, trattenuto o stordito. Ogni oggetto indossato o trasportato dal signore delle mummie resta in suo possesso.",
			""),
		new Text(
			"Mummy Lord",
			null,
			"Medium undead, lawful evil",
			"17 (natural armor)",
			"20 ft.",
			"Con +8, Int +5, Wis +9, Cha +8",
			"History +5, Religion +5",
			"fire",
			"",
			"necrotic, poison; bludgeoning, piercing, and slashing from nonmagical weapons",
			"charmed, exhaustion, frightened, paralyzed, poisoned",
			"darkvision 60 ft., passive Perception 14",
			"the languages it knew in life",
			"***Magic Resistance.*** The mummy lord has advantage on saving throws against spells and other magical effects.\n\n***Rejuvenation.*** A destroyed mummy lord gains a new body in 24 hours if its heart is intact, regaining all its hit points and becoming active again. The new body appears within 5 feet of the mummy lord's heart.\n\n***Spellcasting.*** The mummy lord is a 10th-level spellcaster. Its spellcasting ability is Wisdom (spell save DC 17, +9 to hit with spell attacks). The mummy lord has the following cleric spells prepared:\n\n- Cantrips (at will): *sacred flame, thaumaturgy*\n- 1st level (4 slots): *command, guiding bolt, shield of faith*\n- 2nd level (3 slots): *hold person, silence, spiritual weapon*\n- 3rd level (3 slots): *animate dead, dispel magic*\n- 4th level (3 slots): *divination, guardian of faith*\n- 5th level (2 slots): *contagion, insect plague*\n- 6th level (1 slot): *harm*",
			"***Multiattack.*** The mummy can use its Dreadful Glare and makes one attack with its rotting fist.\n\n***Rotting Fist.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 14 (3d6 + 4) bludgeoning damage plus 21 (6d6) necrotic damage. If the target is a creature, it must succeed on a DC 16 Constitution saving throw or be cursed with mummy rot. The cursed target can't regain hit points, and its hit point maximum decreases by 10 (3d6) for every 24 hours that elapse. If the curse reduces the target's hit point maximum to 0, the target dies, and its body turns to dust. The curse lasts until removed by the remove curse spell or other magic.\n\n***Dreadful Glare.*** The mummy lord targets one creature it can see within 60 feet of it. If the target can see the mummy lord, it must succeed on a DC 16 Wisdom saving throw against this magic or become frightened until the end of the mummy's next turn. If the target fails the saving throw by 5 or more, it is also paralyzed for the same duration. A target that succeeds on the saving throw is immune to the Dreadful Glare of all mummies and mummy lords for the next 24 hours.",
			"",
			"",
			"The mummy lord can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The mummy lord regains spent legendary actions at the start of its turn.\n\n***Attack.*** The mummy lord makes one attack with its rotting fist or uses its Dreadful Glare.\n\n***Blinding Dust.*** Blinding dust and sand swirls magically around the mummy lord. Each creature within 5 feet of the mummy lord must succeed on a DC 16 Constitution saving throw or be blinded until the end of the creature's next turn.\n\n***Blasphemous Word (Costs 2 Actions).*** The mummy lord utters a blasphemous word. Each non-undead creature within 10 feet of the mummy lord that can hear the magical utterance must succeed on a DC 16 Constitution saving throw or be stunned until the end of the mummy lord's next turn.\n\n***Channel Negative Energy (Costs 2 Actions).*** The mummy lord magically unleashes negative energy. Creatures within 60 feet of the mummy lord, including ones behind barriers and around corners, can't regain hit points until the end of the mummy lord's next turn.\n\n***Whirlwind of Sand (Costs 2 Actions).*** The mummy lord magically transforms into a whirlwind of sand, moves up to 60 feet, and reverts to its normal form. While in whirlwind form, the mummy lord is immune to all damage, and it can't be grappled, petrified, knocked prone, restrained, or stunned. Equipment worn or carried by the mummy lord remain in its possession.",
			""));
}
