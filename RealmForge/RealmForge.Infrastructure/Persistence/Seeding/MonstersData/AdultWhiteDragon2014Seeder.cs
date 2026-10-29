using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Adult White Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AdultWhiteDragon2014Seeder
{
	public static Monster Build() => Create("adult-white-dragon", null, CreatureSize.Huge, CreatureType.Dragon,
		18, 200, "16d12 + 96", 40, new[] { 22, 10, 22, 8, 12, 12 }, 13m, 10000, 5, 21,
		new Text(
			"Drago bianco adulto",
			null,
			"Drago Enorme, caotico malvagio",
			"18 (armatura naturale)",
			"12 m, nuotare 12 m, scavare 9 m, volare 24 m",
			"Car +6, Cos +11, Des +5, Sag +6",
			"Furtività +5, Percezione +11",
			"",
			"",
			"freddo",
			"",
			"Percezione passiva 21, scurovisione 36 m, vista cieca 18 m",
			"Comune, Draconico",
			"***Camminare sul ghiaccio.*** Il drago può muoversi sulle superfici di ghiaccio e scalarle senza bisogno di effettuare una prova di caratteristica. Inoltre, un terreno difficile costituito da ghiaccio o neve non gli costa alcun movimento aggiuntivo.\n\n***Resistenza leggendaria (3/giorno).*** Se il drago fallisce un tiro salvezza, può scegliere di superarlo comunque.",
			"***Multiattacco.*** Il drago può usare la sua Presenza terrificante. Poi effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +11 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d6 + 6) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +11 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 15 (2d8 + 6) danni contundenti.\n\n***Morso.*** *Attacco con arma da mischia:* +11 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 17 (2d10 + 6) danni perforanti più 4 (1d8) danni da freddo.\n\n***Presenza terrificante.*** Ogni creatura a scelta del drago situata entro 36 metri da esso e consapevole della sua presenza deve superare un tiro salvezza su Saggezza con CD 14, altrimenti è spaventata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce. Se una creatura supera il tiro salvezza o se l'effetto per lei termina, è immune alla Presenza terrificante del drago per le 24 ore successive.\n\n***Soffio di freddo (ricarica 5–6).*** Il drago esala una folata gelida in un cono di 18 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione con CD 19, subendo 54 (12d8) danni da freddo in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"Il drago può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il drago recupera le azioni leggendarie effettuate.\n\n***Attacco di coda.*** Il drago effettua un attacco con la coda.\n\n***Individuazione.*** Il drago effettua una prova di Saggezza (Percezione).\n\n***Attacco d'ala (costa 2 azioni).*** Il drago sbatte le ali. Ogni creatura entro 3 metri dal drago deve superare un tiro salvezza su Destrezza con CD 19, altrimenti subisce 13 (2d6 + 6) danni contundenti e cade a terra prona. Il drago può poi volare fino a metà della sua velocità di volare."),
		new Text(
			"Adult White Dragon",
			null,
			"Huge dragon, chaotic evil",
			"18 (natural armor)",
			"40 ft., burrow 30 ft., fly 80 ft., swim 40 ft.",
			"Dex +5, Con +11, Wis +6, Cha +6",
			"Perception +11, Stealth +5",
			"",
			"",
			"cold",
			"",
			"blindsight 60 ft., darkvision 120 ft., passive Perception 21",
			"Common, Draconic",
			"***Ice Walk.*** The dragon can move across and climb icy surfaces without needing to make an ability check. Additionally, difficult terrain composed of ice or snow doesn't cost it extra movement.\n\n***Legendary Resistance (3/Day).*** If the dragon fails a saving throw, it can choose to succeed instead.",
			"***Multiattack.*** The dragon can use its Frightful Presence. It then makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +11 to hit, reach 10 ft., one target. *Hit:* 17 (2d10 + 6) piercing damage plus 4 (1d8) cold damage.\n\n***Claw.*** *Melee Weapon Attack:* +11 to hit, reach 5 ft., one target. *Hit:* 13 (2d6 + 6) slashing damage.\n\n***Tail.*** *Melee Weapon Attack:* +11 to hit, reach 15 ft., one target. *Hit:* 15 (2d8 + 6) bludgeoning damage.\n\n***Frightful Presence.*** Each creature of the dragon's choice that is within 120 ft. of the dragon and aware of it must succeed on a DC 14 Wisdom saving throw or become frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the dragon's Frightful Presence for the next 24 hours.\n\n***Cold Breath (Recharge 5–6).*** The dragon exhales an icy blast in a 60-foot cone. Each creature in that area must make a DC 19 Constitution saving throw, taking 54 (12d8) cold damage on a failed save, or half as much damage on a successful one.",
			"",
			"The dragon can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The dragon regains spent legendary actions at the start of its turn.\n\n***Detect.*** The dragon makes a Wisdom (Perception) check.\n\n***Tail Attack.*** The dragon makes a tail attack.\n\n***Wing Attack (Costs 2 Actions).*** The dragon beats its wings. Each creature within 10 ft. of the dragon must succeed on a DC 19 Dexterity saving throw or take 13 (2d6 + 6) bludgeoning damage and be knocked prone. The dragon can then fly up to half its flying speed."));
}
