using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ancient Blue Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AncientBlueDragon2014Seeder
{
	public static Monster Build() => Create("ancient-blue-dragon", null, CreatureSize.Gargantuan, CreatureType.Dragon,
		22, 481, "26d20 + 208", 40, new[] { 29, 10, 27, 18, 17, 21 }, 23m, 50000, 7, 27,
		new Text(
			"Drago blu antico",
			null,
			"Drago Mastodontico, legale malvagio",
			"22 (armatura naturale)",
			"12 m, scavare 12 m, volare 24 m",
			"Car +12, Cos +15, Des +7, Sag +10",
			"Furtività +17, Percezione +7",
			"",
			"",
			"fulmine",
			"",
			"Percezione passiva 27, scurovisione 36 m, vista cieca 18 m",
			"Comune, Draconico",
			"***Resistenza leggendaria (3/giorno).*** Se il drago fallisce un tiro salvezza, può scegliere di superarlo comunque.",
			"***Multiattacco.*** Il drago può usare la sua Presenza terrificante. Poi effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +16 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 16 (2d6 + 9) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +16 al tiro per colpire, portata 6 m, un bersaglio. *Colpito:* 18 (2d8 + 9) danni contundenti.\n\n***Morso.*** *Attacco con arma da mischia:* +16 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 20 (2d10 + 9) danni perforanti più 11 (2d10) danni da fulmine.\n\n***Presenza terrificante.*** Ogni creatura a scelta del drago situata entro 36 metri da esso e consapevole della sua presenza deve superare un tiro salvezza su Saggezza con CD 20, altrimenti è spaventata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce. Se una creatura supera il tiro salvezza o se l'effetto per lei termina, è immune alla Presenza terrificante del drago per le 24 ore successive.\n\n***Soffio di fulmini (ricarica 5–6).*** Il drago esala una scarica di fulmini lunga 36 metri e larga 3 metri. Ogni creatura su quella linea deve effettuare un tiro salvezza su Destrezza con CD 23, subendo 88 (16d10) danni da fulmine in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"Il drago può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il drago recupera le azioni leggendarie effettuate.\n\n***Attacco di coda.*** Il drago effettua un attacco con la coda.\n\n***Individuazione.*** Il drago effettua una prova di Saggezza (Percezione).\n\n***Attacco d'ala (costa 2 azioni).*** Il drago sbatte le ali. Ogni creatura entro 4,5 metri dal drago deve superare un tiro salvezza su Destrezza con CD 24, altrimenti subisce 16 (2d6 + 9) danni contundenti e cade a terra prona. Il drago può poi volare fino a metà della sua velocità di volare."),
		new Text(
			"Ancient Blue Dragon",
			null,
			"Gargantuan dragon, lawful evil",
			"22 (natural armor)",
			"40 ft., burrow 40 ft., fly 80 ft.",
			"Dex +7, Con +15, Wis +10, Cha +12",
			"Perception +17, Stealth +7",
			"",
			"",
			"lightning",
			"",
			"blindsight 60 ft., darkvision 120 ft., passive Perception 27",
			"Common, Draconic",
			"***Legendary Resistance (3/Day).*** If the dragon fails a saving throw, it can choose to succeed instead.",
			"***Multiattack.*** The dragon can use its Frightful Presence. It then makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +16 to hit, reach 15 ft., one target. *Hit:* 20 (2d10 + 9) piercing damage plus 11 (2d10) lightning damage.\n\n***Claw.*** *Melee Weapon Attack:* +16 to hit, reach 10 ft., one target. *Hit:* 16 (2d6 + 9) slashing damage.\n\n***Tail.*** *Melee Weapon Attack:* +16 to hit, reach 20 ft., one target. *Hit:* 18 (2d8 + 9) bludgeoning damage.\n\n***Frightful Presence.*** Each creature of the dragon's choice that is within 120 feet of the dragon and aware of it must succeed on a DC 20 Wisdom saving throw or become frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the dragon's Frightful Presence for the next 24 hours.\n\n***Lightning Breath (Recharge 5–6).*** The dragon exhales lightning in a 120-foot line that is 10 feet wide. Each creature in that line must make a DC 23 Dexterity saving throw, taking 88 (16d10) lightning damage on a failed save, or half as much damage on a successful one.",
			"",
			"The dragon can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The dragon regains spent legendary actions at the start of its turn.\n\n***Detect.*** The dragon makes a Wisdom (Perception) check.\n\n***Tail Attack.*** The dragon makes a tail attack.\n\n***Wing Attack (Costs 2 Actions).*** The dragon beats its wings. Each creature within 15 ft. of the dragon must succeed on a DC 24 Dexterity saving throw or take 16 (2d6 + 9) bludgeoning damage and be knocked prone. The dragon can then fly up to half its flying speed."));
}
