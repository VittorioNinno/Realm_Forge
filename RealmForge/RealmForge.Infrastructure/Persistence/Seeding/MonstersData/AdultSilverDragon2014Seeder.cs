using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Adult Silver Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AdultSilverDragon2014Seeder
{
	public static Monster Build() => Create("adult-silver-dragon", null, CreatureSize.Huge, CreatureType.Dragon,
		19, 243, "18d12 + 126", 40, new[] { 27, 10, 25, 16, 13, 21 }, 16m, 15000, 5, 21,
		new Text(
			"Drago d'argento adulto",
			null,
			"Drago Enorme, legale buono",
			"19 (armatura naturale)",
			"12 m, volare 24 m",
			"Car +10, Cos +12, Des +5, Sag +6",
			"Arcano +8, Furtività +5, Percezione +11, Storia +8",
			"",
			"",
			"freddo",
			"",
			"Percezione passiva 21, scurovisione 36 m, vista cieca 18 m",
			"Comune, Draconico",
			"***Resistenza leggendaria (3/giorno).*** Se il drago fallisce un tiro salvezza, può scegliere di superarlo comunque.",
			"***Multiattacco.*** Il drago può usare la sua Presenza terrificante. Poi effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 15 (2d6 + 8) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 17 (2d8 + 8) danni contundenti.\n\n***Morso.*** *Attacco con arma da mischia:* +13 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 19 (2d10 + 8) danni perforanti.\n\n***Cambiare forma.*** Il drago si trasforma magicamente in una bestia o in un umanoide con grado di sfida pari o inferiore al proprio, o ritorna alla sua vera forma. Se muore, torna alla sua forma naturale. Ogni oggetto che indossava o trasportava viene assorbito o trasportato dalla sua nuova forma (a scelta del drago). Nella nuova conformazione, il drago conserva allineamento, punti ferita, Dadi Vita, la capacità di parlare, competenze, Resistenza leggendaria, azioni di tana e punteggi di Intelligenza, Saggezza e Carisma, nonché quest'azione. Le sue statistiche e capacità restanti sono sostituite da quelle della nuova forma, a eccezione di eventuali privilegi di classe o azioni leggendarie.\n\n***Presenza terrificante.*** Ogni creatura a scelta del drago situata entro 36 metri da esso e consapevole della sua presenza deve superare un tiro salvezza su Saggezza con CD 18, altrimenti è spaventata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce. Se una creatura supera il tiro salvezza o se l'effetto per lei termina, è immune alla Presenza terrificante del drago per le 24 ore successive.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di freddo.*** Il drago esala una folata gelida in un cono di 18 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione con CD 20, subendo 58 (13d8) danni da freddo in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio paralizzante.*** Il drago esala gas paralizzante in un cono di 18 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Costituzione con CD 20, altrimenti è paralizzata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			"Il drago può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il drago recupera le azioni leggendarie effettuate.\n\n***Attacco di coda.*** Il drago effettua un attacco con la coda.\n\n***Individuazione.*** Il drago effettua una prova di Saggezza (Percezione).\n\n***Attacco d'ala (costa 2 azioni).*** Il drago sbatte le ali. Ogni creatura entro 3 metri dal drago deve superare un tiro salvezza su Destrezza con CD 21, altrimenti subisce 15 (2d6 + 8) danni contundenti e cade a terra prona. Il drago può poi volare fino a metà della sua velocità di volare."),
		new Text(
			"Adult Silver Dragon",
			null,
			"Huge dragon, lawful good",
			"19 (natural armor)",
			"40 ft., fly 80 ft.",
			"Dex +5, Con +12, Wis +6, Cha +10",
			"Arcana +8, History +8, Perception +11, Stealth +5",
			"",
			"",
			"cold",
			"",
			"blindsight 60 ft., darkvision 120 ft., passive Perception 21",
			"Common, Draconic",
			"***Legendary Resistance (3/Day).*** If the dragon fails a saving throw, it can choose to succeed instead.",
			"***Multiattack.*** The dragon can use its Frightful Presence. It then makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +13 to hit, reach 10 ft., one target. *Hit:* 19 (2d10 + 8) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +13 to hit, reach 5 ft., one target. *Hit:* 15 (2d6 + 8) slashing damage.\n\n***Tail.*** *Melee Weapon Attack:* +13 to hit, reach 15 ft., one target. *Hit:* 17 (2d8 + 8) bludgeoning damage.\n\n***Frightful Presence.*** Each creature of the dragon's choice that is within 120 feet of the dragon and aware of it must succeed on a DC 18 Wisdom saving throw or become frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the dragon's Frightful Presence for the next 24 hours.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nCold Breath. The dragon exhales an icy blast in a 60-foot cone. Each creature in that area must make a DC 20 Constitution saving throw, taking 58 (13d8) cold damage on a failed save, or half as much damage on a successful one.\nParalyzing Breath. The dragon exhales paralyzing gas in a 60-foot cone. Each creature in that area must succeed on a DC 20 Constitution saving throw or be paralyzed for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			"The dragon can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The dragon regains spent legendary actions at the start of its turn.\n\n***Detect.*** The dragon makes a Wisdom (Perception) check.\n\n***Tail Attack.*** The dragon makes a tail attack.\n\n***Wing Attack (Costs 2 Actions).*** The dragon beats its wings. Each creature within 10 ft. of the dragon must succeed on a DC 22 Dexterity saving throw or take 15 (2d6 + 8) bludgeoning damage and be knocked prone. The dragon can then fly up to half its flying speed."));
}
