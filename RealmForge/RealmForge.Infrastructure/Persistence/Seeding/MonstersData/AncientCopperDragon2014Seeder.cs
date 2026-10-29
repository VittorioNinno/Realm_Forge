using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ancient Copper Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AncientCopperDragon2014Seeder
{
	public static Monster Build() => Create("ancient-copper-dragon", null, CreatureSize.Gargantuan, CreatureType.Dragon,
		21, 350, "20d20 + 140", 40, new[] { 27, 12, 25, 20, 17, 19 }, 21m, 33000, 7, 27,
		new Text(
			"Drago di rame antico",
			null,
			"Drago Mastodontico, caotico buono",
			"21 (armatura naturale)",
			"12 m, scalare 12 m, volare 24 m",
			"Car +11, Cos +14, Des +8, Sag +10",
			"Furtività +8, Inganno +11, Percezione +17",
			"",
			"",
			"acido",
			"",
			"Percezione passiva 27, scurovisione 36 m, vista cieca 18 m",
			"Comune, Draconico",
			"***Resistenza leggendaria (3/giorno).*** Se il drago fallisce un tiro salvezza, può scegliere di superarlo comunque.",
			"***Multiattacco.*** Il drago può usare la sua Presenza terrificante. Poi effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +15 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (2d6 + 8) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +15 al tiro per colpire, portata 6 m, un bersaglio. *Colpito:* 17 (2d8 + 8) danni contundenti.\n\n***Morso.*** *Attacco con arma da mischia:* +15 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 19 (2d10 + 8) danni perforanti.\n\n***Cambiare forma.*** Il drago si trasforma magicamente in una bestia o in un umanoide con grado di sfida pari o inferiore al proprio, o ritorna alla sua vera forma. Se muore, torna alla sua forma naturale. Ogni oggetto che indossava o trasportava viene assorbito o trasportato dalla sua nuova forma (a scelta del drago). Nella nuova conformazione, il drago conserva allineamento, punti ferita, Dadi Vita, la capacità di parlare, competenze, Resistenza leggendaria, azioni di tana e punteggi di Intelligenza, Saggezza e Carisma, nonché quest'azione. Le sue statistiche e capacità restanti sono sostituite da quelle della nuova forma, a eccezione di eventuali privilegi di classe o azioni leggendarie.\n\n***Presenza terrificante.*** Ogni creatura a scelta del drago situata entro 36 metri da esso e consapevole della sua presenza deve superare un tiro salvezza su Saggezza con CD 19, altrimenti è spaventata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce. Se una creatura supera il tiro salvezza o se l'effetto per lei termina, è immune alla Presenza terrificante del drago per le 24 ore successive.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di acido.*** Il drago esala una scia di acido lunga 27 metri e larga 3 metri. Ogni creatura su quella scia deve effettuare un tiro salvezza su Destrezza con CD 22, subendo 63 (14d8) danni da acido in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio rallentante.*** Il drago esala gas in un cono di 27 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Costituzione con CD 22; se lo fallisce, non può usare reazioni, la sua velocità è dimezzata e non può effettuare più di un attacco nel suo turno. Inoltre, nel suo turno la creatura può usare un'azione o un'azione bonus, ma non entrambe. Questi effetti durano 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto per lei termina.",
			"",
			"Il drago può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il drago recupera le azioni leggendarie effettuate.\n\n***Attacco di coda.*** Il drago effettua un attacco con la coda.\n\n***Individuazione.*** Il drago effettua una prova di Saggezza (Percezione).\n\n***Attacco d'ala (costa 2 azioni).*** Il drago sbatte le ali. Ogni creatura entro 4,5 metri dal drago deve superare un tiro salvezza su Destrezza con CD 23, altrimenti subisce 15 (2d6 + 8) danni contundenti e cade a terra prona. Il drago può poi volare fino a metà della sua velocità di volare."),
		new Text(
			"Ancient Copper Dragon",
			null,
			"Gargantuan dragon, chaotic good",
			"21 (natural armor)",
			"40 ft., climb 40 ft., fly 80 ft.",
			"Dex +8, Con +14, Wis +10, Cha +11",
			"Deception +11, Perception +17, Stealth +8",
			"",
			"",
			"acid",
			"",
			"blindsight 60 ft., darkvision 120 ft., passive Perception 27",
			"Common, Draconic",
			"***Legendary Resistance (3/Day).*** If the dragon fails a saving throw, it can choose to succeed instead.",
			"***Multiattack.*** The dragon can use its Frightful Presence. It then makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +15 to hit, reach 15 ft., one target. *Hit:* 19 (2d10 + 8) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +15 to hit, reach 10 ft., one target. *Hit:* 15 (2d6 + 8) slashing damage.\n\n***Tail.*** *Melee Weapon Attack:* +15 to hit, reach 20 ft., one target. *Hit:* 17 (2d8 + 8) bludgeoning damage.\n\n***Frightful Presence.*** Each creature of the dragon's choice that is within 120 feet of the dragon and aware of it must succeed on a DC 19 Wisdom saving throw or become frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the dragon's Frightful Presence for the next 24 hours.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nAcid Breath. The dragon exhales acid in an 90-foot line that is 10 feet wide. Each creature in that line must make a DC 22 Dexterity saving throw, taking 63 (14d8) acid damage on a failed save, or half as much damage on a successful one.\nSlowing Breath. The dragon exhales gas in a 90-foot cone. Each creature in that area must succeed on a DC 22 Constitution saving throw. On a failed save, the creature can't use reactions, its speed is halved, and it can't make more than one attack on its turn. In addition, the creature can use either an action or a bonus action on its turn, but not both. These effects last for 1 minute. The creature can repeat the saving throw at the end of each of its turns, ending the effect on itself with a successful save.\n\n***Change Shape.*** The dragon magically polymorphs into a humanoid or beast that has a challenge rating no higher than its own, or back into its true form. It reverts to its true form if it dies. Any equipment it is wearing or carrying is absorbed or borne by the new form (the dragon's choice).\n\nIn a new form, the dragon retains its alignment, hit points, Hit Dice, ability to speak, proficiencies, Legendary Resistance, lair actions, and Intelligence, Wisdom, and Charisma scores, as well as this action. Its statistics and capabilities are otherwise replaced by those of the new form, except any class features or legendary actions of that form.",
			"",
			"The dragon can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The dragon regains spent legendary actions at the start of its turn.\n\n***Detect.*** The dragon makes a Wisdom (Perception) check.\n\n***Tail Attack.*** The dragon makes a tail attack.\n\n***Wing Attack (Costs 2 Actions).*** The dragon beats its wings. Each creature within 15 ft. of the dragon must succeed on a DC 23 Dexterity saving throw or take 15 (2d6 + 8) bludgeoning damage and be knocked prone. The dragon can then fly up to half its flying speed."));
}
