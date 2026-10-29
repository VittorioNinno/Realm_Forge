using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Tarrasque (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Tarrasque2014Seeder
{
	public static Monster Build() => Create("tarrasque", null, CreatureSize.Gargantuan, CreatureType.Monstrosity,
		25, 676, "33d20 + 330", 40, new[] { 30, 11, 30, 3, 11, 11 }, 30m, 155000, 9, 10,
		new Text(
			"Tarrasque",
			null,
			"Mostruosità mastodontica (titano), senza allineamento",
			"25 (armatura naturale)",
			"12 m",
			"Car +9, Int +5, Sag +9",
			"",
			"",
			"",
			"fuoco, veleno; contundenti, perforanti e taglienti da attacchi non magici",
			"affascinato, avvelenato, paralizzato, spaventato",
			"Percezione passiva 10, vista cieca 36 m",
			"—",
			"***Carapace riflettente.*** Ogni volta che il tarrasque è bersagliato da un incantesimo *dardo incantato,* un incantesimo che ha una linea come area di effetto o un incantesimo che richiede un tiro per colpire a distanza, si tira un d6. Con un risultato da 1 a 5, il tarrasque non ne è influenzato. Con un risultato di 6, il tarrasque non ne è influenzato e l'effetto viene riflesso contro l'incantatore come se avesse origine dal tarrasque, rendendo l'incantatore il bersaglio.\n\n***Mostro da assedio.*** Il tarrasque infligge danni doppi a oggetti e strutture.\n\n***Resistenza alla magia.*** Il tarrasque dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Resistenza leggendaria (3/giorno).*** Se il tarrasque fallisce un tiro salvezza, può scegliere di superarlo comunque.",
			"***Multiattacco.*** Il tarrasque può usare la sua presenza terrificante. Poi effettua cinque attacchi: uno con il morso, due con gli artigli, uno con le corna e uno con la coda. Può usare Inghiottire al posto del morso.\n\n***Artiglio.*** *Attacco con arma da mischia:* +19 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 28 (4d8 + 10) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +19 al tiro per colpire, portata 6 m, un bersaglio. *Colpito:* 24 (4d6 + 10) danni contundenti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 20, altrimenti cade a terra prono.\n\n***Corna.*** *Attacco con arma da mischia:* +19 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 32 (4d10 + 10) danni perforanti.\n\n***Morso.*** *Attacco con arma da mischia:* +19 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 36 (4d12 + 10) danni perforanti. Se il bersaglio è una creatura, viene afferrato (CD 20 per sfuggire). Finché la presa perdura, il bersaglio viene trattenuto e il tarrasque non può morderne un altro.\n\n***Inghiottire.*** Il tarrasque effettua un attacco con il morso contro una creatura di taglia Grande o inferiore con cui sta lottando. Se l'attacco va a segno, il bersaglio subisce i danni del morso, viene inghiottito e la lotta termina. Mentre è inghiottita, la creatura è accecata e trattenuta, beneficia di copertura totale contro gli attacchi e altri effetti al di fuori del tarrasque e subisce 56 (16d6) danni da acido all'inizio di ogni turno del mostro. Se il tarrasque subisce 60 o più danni in un singolo turno da una creatura inghiottita, il tarrasque deve superare un tiro salvezza su Costituzione con CD 20 alla fine di quel turno, altrimenti rigurgita tutte le creature inghiottite, che cadono prone in uno spazio entro 3 metri dal tarrasque. Se il tarrasque muore, la creatura inghiottita non è più trattenuta dal mostro e può sfuggire usando 9 metri di movimento, uscendo prona dal cadavere.\n\n***Presenza terrificante.*** Ogni creatura a scelta del tarrasque situata entro 36 metri da esso e che sia consapevole della sua presenza deve superare un tiro salvezza su Saggezza con CD 17, altrimenti è spaventata per 1 minuto. Una creatura può ripetere il tiro salvezza alla fine di ogni suo turno, subendo svantaggio se il tarrasque è situato nel suo campo visivo; se lo supera, l'effetto svanisce. Se una creatura supera il tiro salvezza o se l'effetto per lei termina, diventa immune alla presenza terrificante del tarrasque per le 24 ore successive.",
			"",
			"Il tarrasque può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il tarrasque recupera le azioni leggendarie effettuate.\n\n***Attacco.*** Il tarrasque effettua un attacco con l'artiglio o con la coda.\n\n***Movimento.*** Il tarrasque si muove fino a metà della sua velocità.\n\n***Masticare (costa 2 azioni).*** Il tarrasque effettua un attacco con il morso o usa Inghiottire."),
		new Text(
			"Tarrasque",
			null,
			"Gargantuan monstrosity (titan), unaligned",
			"25 (natural armor)",
			"40 ft.",
			"Int +5, Wis +9, Cha +9",
			"",
			"",
			"",
			"fire, poison; bludgeoning, piercing, and slashing from nonmagical weapons",
			"charmed, frightened, paralyzed, poisoned",
			"blindsight 120 ft., passive Perception 10",
			"—",
			"***Legendary Resistance (3/Day).*** If the tarrasque fails a saving throw, it can choose to succeed instead.\n\n***Magic Resistance.*** The tarrasque has advantage on saving throws against spells and other magical effects.\n\n***Reflective Carapace.*** Any time the tarrasque is targeted by a magic missile spell, a line spell, or a spell that requires a ranged attack roll, roll a d6. On a 1 to 5, the tarrasque is unaffected. On a 6, the tarrasque is unaffected, and the effect is reflected back at the caster as though it originated from the tarrasque, turning the caster into the target.\n\n***Siege Monster.*** The tarrasque deals double damage to objects and structures.",
			"***Multiattack.*** The tarrasque can use its Frightful Presence. It then makes five attacks: one with its bite, two with its claws, one with its horns, and one with its tail. It can use its Swallow instead of its bite.\n\n***Bite.*** *Melee Weapon Attack:* +19 to hit, reach 10 ft., one target. *Hit:* 36 (4d12 + 10) piercing damage. If the target is a creature, it is grappled (escape DC 20). Until this grapple ends, the target is restrained, and the tarrasque can't bite another target.\n\n***Claw.*** *Melee Weapon Attack:* +19 to hit, reach 15 ft., one target. *Hit:* 28 (4d8 + 10) slashing damage.\n\n***Horns.*** *Melee Weapon Attack:* +19 to hit, reach 10 ft., one target. *Hit:* 32 (4d10 + 10) piercing damage.\n\n***Tail.*** *Melee Weapon Attack:* +19 to hit, reach 20 ft., one target. *Hit:* 24 (4d6 + 10) bludgeoning damage. If the target is a creature, it must succeed on a DC 20 Strength saving throw or be knocked prone.\n\n***Frightful Presence.*** Each creature of the tarrasque's choice within 120 feet of it and aware of it must succeed on a DC 17 Wisdom saving throw or become frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, with disadvantage if the tarrasque is within line of sight, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the tarrasque's Frightful Presence for the next 24 hours.\n\n***Swallow.*** The tarrasque makes one bite attack against a Large or smaller creature it is grappling. If the attack hits, the target takes the bite's damage, the target is swallowed, and the grapple ends. While swallowed, the creature is blinded and restrained, it has total cover against attacks and other effects outside the tarrasque, and it takes 56 (16d6) acid damage at the start of each of the tarrasque's turns.\n\nIf the tarrasque takes 60 damage or more on a single turn from a creature inside it, the tarrasque must succeed on a DC 20 Constitution saving throw at the end of that turn or regurgitate all swallowed creatures, which fall prone in a space within 10 feet of the tarrasque. If the tarrasque dies, a swallowed creature is no longer restrained by it and can escape from the corpse by using 30 feet of movement, exiting prone.",
			"",
			"The tarrasque can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The tarrasque regains spent legendary actions at the start of its turn.\n\n***Attack.*** The tarrasque makes one claw attack or tail attack.\n\n***Move.*** The tarrasque moves up to half its speed.\n\n***Chomp (Costs 2 Actions).*** The tarrasque makes one bite attack or uses its Swallow."));
}
