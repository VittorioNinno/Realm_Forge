using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ancient Black Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AncientBlackDragon2014Seeder
{
	public static Monster Build() => Create("ancient-black-dragon", null, CreatureSize.Gargantuan, CreatureType.Dragon,
		22, 367, "21d20 + 147", 40, new[] { 27, 14, 25, 16, 15, 19 }, 21m, 33000, 7, 26,
		new Text(
			"Drago nero antico",
			null,
			"Drago Mastodontico, caotico malvagio",
			"22 (armatura naturale)",
			"12 m, nuotare 12 m, volare 24 m",
			"Car +11, Cos +14, Des +9, Sag +9",
			"Furtività +9, Percezione +16",
			"",
			"",
			"acido",
			"",
			"Percezione passiva 26, scurovisione 36 m, vista cieca 18 m",
			"Comune, Draconico",
			"***Anfibio.*** Il drago può respirare in aria e in acqua.\n\n***Resistenza leggendaria (3/giorno).*** Se il drago fallisce un tiro salvezza, può scegliere di superarlo comunque.",
			"***Multiattacco.*** Il drago può usare la sua Presenza terrificante. Poi effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +15 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (2d6 + 8) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +15 al tiro per colpire, portata 6 m, un bersaglio. *Colpito:* 17 (2d8 + 8) danni contundenti.\n\n***Morso.*** *Attacco con arma da mischia:* +15 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 19 (2d10 + 8) danni perforanti più 9 (2d8) danni da acido.\n\n***Presenza terrificante.*** Ogni creatura a scelta del drago situata entro 36 metri da esso e consapevole della sua presenza deve superare un tiro salvezza su Saggezza con CD 19, altrimenti è spaventata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce. Se una creatura supera il tiro salvezza o se l'effetto per lei termina, è immune alla Presenza terrificante del drago per le 24 ore successive.\n\n***Soffio di acido (ricarica 5–6).*** Il drago esala una linea di acido lunga 27 metri e larga 3 metri. Ogni creatura su quella linea deve effettuare un tiro salvezza su Destrezza con CD 22, subendo 67 (15d8) danni da acido in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"Il drago può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il drago recupera le azioni leggendarie effettuate.\n\n***Attacco di coda.*** Il drago effettua un attacco con la coda.\n\n***Individuazione.*** Il drago effettua una prova di Saggezza (Percezione).\n\n***Attacco d'ala (costa 2 azioni).*** Il drago sbatte le ali. Ogni creatura entro 4,5 metri dal drago deve superare un tiro salvezza su Destrezza con CD 23, altrimenti subisce 15 (2d6 + 8) danni contundenti e cade a terra prona. Il drago può poi volare fino a metà della sua velocità di volare."),
		new Text(
			"Ancient Black Dragon",
			null,
			"Gargantuan dragon, chaotic evil",
			"22 (natural armor)",
			"40 ft., fly 80 ft., swim 40 ft.",
			"Dex +9, Con +14, Wis +9, Cha +11",
			"Perception +16, Stealth +9",
			"",
			"",
			"acid",
			"",
			"blindsight 60 ft., darkvision 120 ft., passive Perception 26",
			"Common, Draconic",
			"***Amphibious.*** The dragon can breathe air and water.\n\n***Legendary Resistance (3/Day).*** If the dragon fails a saving throw, it can choose to succeed instead.",
			"***Multiattack.*** The dragon can use its Frightful Presence. It then makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +15 to hit, reach 15 ft., one target. *Hit:* 19 (2d10 + 8) piercing damage plus 9 (2d8) acid damage.\n\n***Claw.*** *Melee Weapon Attack:* +15 to hit, reach 10 ft., one target. *Hit:* 15 (2d6 + 8) slashing damage.\n\n***Tail.*** *Melee Weapon Attack:* +15 to hit, reach 20 ft., one target. *Hit:* 17 (2d8 + 8) bludgeoning damage.\n\n***Frightful Presence.*** Each creature of the dragon's choice that is within 120 feet of the dragon and aware of it must succeed on a DC 19 Wisdom saving throw or become frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the dragon's Frightful Presence for the next 24 hours.\n\n***Acid Breath (Recharge 5–6).*** The dragon exhales acid in a 90-foot line that is 10 feet wide. Each creature in that line must make a DC 22 Dexterity saving throw, taking 67 (15d8) acid damage on a failed save, or half as much damage on a successful one.",
			"",
			"The dragon can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The dragon regains spent legendary actions at the start of its turn.\n\n***Detect.*** The dragon makes a Wisdom (Perception) check.\n\n***Tail Attack.*** The dragon makes a tail attack.\n\n***Wing Attack (Costs 2 Actions).*** The dragon beats its wings. Each creature within 15 ft. of the dragon must succeed on a DC 23 Dexterity saving throw or take 15 (2d6 + 8) bludgeoning damage and be knocked prone. The dragon can then fly up to half its flying speed."));
}
