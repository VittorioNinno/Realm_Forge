using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ancient Silver Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AncientSilverDragon2014Seeder
{
	public static Monster Build() => Create("ancient-silver-dragon", null, CreatureSize.Gargantuan, CreatureType.Dragon,
		22, 487, "25d20 + 225", 40, new[] { 30, 10, 29, 18, 15, 23 }, 23m, 50000, 7, 26,
		new Text(
			"Drago d'argento antico",
			null,
			"Drago Mastodontico, legale buono",
			"22 (armatura naturale)",
			"12 m, volare 24 m",
			"Car +13, Cos +16, Des +7, Sag +9",
			"Arcano +11, Furtività +7, Percezione +16, Storia +11",
			"",
			"",
			"freddo",
			"",
			"Percezione passiva 26, scurovisione 36 m, vista cieca 18 m",
			"Comune, Draconico",
			"***Resistenza leggendaria (3/giorno).*** Se il drago fallisce un tiro salvezza, può scegliere di superarlo comunque.",
			"***Multiattacco.*** Il drago può usare la sua Presenza terrificante. Poi effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +17 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 17 (2d6 + 10) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +17 al tiro per colpire, portata 6 m, un bersaglio. *Colpito:* 19 (2d8 + 10) danni contundenti.\n\n***Morso.*** *Attacco con arma da mischia:* +17 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 21 (2d10 + 10) danni perforanti.\n\n***Cambiare forma.*** Il drago si trasforma magicamente in una bestia o in un umanoide con grado di sfida pari o inferiore al proprio, o ritorna alla sua vera forma. Se muore, torna alla sua forma naturale. Ogni oggetto che indossava o trasportava viene assorbito o trasportato dalla sua nuova forma (a scelta del drago). Nella nuova conformazione, il drago conserva allineamento, punti ferita, Dadi Vita, la capacità di parlare, competenze, Resistenza leggendaria, azioni di tana e punteggi di Intelligenza, Saggezza e Carisma, nonché quest'azione. Le sue statistiche e capacità restanti sono sostituite da quelle della nuova forma, a eccezione di eventuali privilegi di classe o azioni leggendarie.\n\n***Presenza terrificante.*** Ogni creatura a scelta del drago situata entro 36 metri da esso e consapevole della sua presenza deve superare un tiro salvezza su Saggezza con CD 21, altrimenti è spaventata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce. Se una creatura supera il tiro salvezza o se l'effetto per lei termina, è immune alla Presenza terrificante del drago per le 24 ore successive.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di freddo.*** Il drago esala una folata gelida in un cono di 27 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione con CD 24, subendo 67 (15d8) danni da freddo in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio paralizzante.*** Il drago esala gas paralizzante in un cono di 27 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Costituzione con CD 24, altrimenti è paralizzata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			"Il drago può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il drago recupera le azioni leggendarie effettuate.\n\n***Attacco di coda.*** Il drago effettua un attacco con la coda.\n\n***Individuazione.*** Il drago effettua una prova di Saggezza (Percezione).\n\n***Attacco d'ala (costa 2 azioni).*** Il drago sbatte le ali. Ogni creatura entro 4,5 metri dal drago deve superare un tiro salvezza su Destrezza con CD 25, altrimenti subisce 17 (2d6 + 10) danni contundenti e cade a terra prona. Il drago può poi volare fino a metà della sua velocità di volare."),
		new Text(
			"Ancient Silver Dragon",
			null,
			"Gargantuan dragon, lawful good",
			"22 (natural armor)",
			"40 ft., fly 80 ft.",
			"Dex +7, Con +16, Wis +9, Cha +13",
			"Arcana +11, History +11, Perception +16, Stealth +7",
			"",
			"",
			"cold",
			"",
			"blindsight 60 ft., darkvision 120 ft., passive Perception 26",
			"Common, Draconic",
			"***Legendary Resistance (3/Day).*** If the dragon fails a saving throw, it can choose to succeed instead.",
			"***Multiattack.*** The dragon can use its Frightful Presence. It then makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +17 to hit, reach 15 ft., one target. *Hit:* 21 (2d10 + 10) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +17 to hit, reach 10 ft., one target. *Hit:* 17 (2d6 + 10) slashing damage.\n\n***Tail.*** *Melee Weapon Attack:* +17 to hit, reach 20 ft., one target. *Hit:* 19 (2d8 + 10) bludgeoning damage.\n\n***Frightful Presence.*** Each creature of the dragon's choice that is within 120 feet of the dragon and aware of it must succeed on a DC 21 Wisdom saving throw or become frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the dragon's Frightful Presence for the next 24 hours.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nCold Breath. The dragon exhales an icy blast in a 90-foot cone. Each creature in that area must make a DC 24 Constitution saving throw, taking 67 (15d8) cold damage on a failed save, or half as much damage on a successful one.\nParalyzing Breath. The dragon exhales paralyzing gas in a 90-foot cone. Each creature in that area must succeed on a DC 24 Constitution saving throw or be paralyzed for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.\n\n***Change Shape.*** The dragon magically polymorphs into a humanoid or beast that has a challenge rating no higher than its own, or back into its true form. It reverts to its true form if it dies. Any equipment it is wearing or carrying is absorbed or borne by the new form (the dragon's choice).\n\nIn a new form, the dragon retains its alignment, hit points, Hit Dice, ability to speak, proficiencies, Legendary Resistance, lair actions, and Intelligence, Wisdom, and Charisma scores, as well as this action. Its statistics and capabilities are otherwise replaced by those of the new form, except any class features or legendary actions of that form.",
			"",
			"The dragon can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The dragon regains spent legendary actions at the start of its turn.\n\n***Detect.*** The dragon makes a Wisdom (Perception) check.\n\n***Tail Attack.*** The dragon makes a tail attack.\n\n***Wing Attack (Costs 2 Actions).*** The dragon beats its wings. Each creature within 15 ft. of the dragon must succeed on a DC 25 Dexterity saving throw or take 17 (2d6 + 10) bludgeoning damage and be knocked prone. The dragon can then fly up to half its flying speed."));
}
