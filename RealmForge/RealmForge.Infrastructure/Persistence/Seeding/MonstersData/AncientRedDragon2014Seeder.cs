using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ancient Red Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AncientRedDragon2014Seeder
{
	public static Monster Build() => Create("ancient-red-dragon", null, ContentSource.Srd51, CreatureSize.Gargantuan, CreatureType.Dragon,
		22, 546, "28d20 + 252", 40, new[] { 30, 10, 29, 18, 15, 23 }, 24m, 62000, 7, 26,
		new Text(
			"Drago rosso antico",
			null,
			"Drago Mastodontico, caotico malvagio",
			"22 (armatura naturale)",
			"12 m, scalare 12 m, volare 24 m",
			"Car +13, Cos +16, Des +7, Sag +9",
			"Furtività +7, Percezione +16",
			"",
			"",
			"fuoco",
			"",
			"Percezione passiva 26, scurovisione 36 m, vista cieca 18 m",
			"Comune, Draconico",
			"***Resistenza leggendaria (3/giorno).*** Se il drago fallisce un tiro salvezza, può scegliere di superarlo comunque.",
			"***Multiattacco.*** Il drago può usare la sua Presenza terrificante. Poi effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +17 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 17 (2d6 + 10) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +17 al tiro per colpire, portata 6 m, un bersaglio. *Colpito:* 19 (2d8 + 10) danni contundenti.\n\n***Morso.*** *Attacco con arma da mischia:* +17 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 21 (2d10 + 10) danni perforanti più 14 (4d6) danni da fuoco.\n\n***Presenza terrificante.*** Ogni creatura a scelta del drago situata entro 36 metri da esso e consapevole della sua presenza deve superare un tiro salvezza su Saggezza con CD 21, altrimenti è spaventata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce. Se una creatura supera il tiro salvezza o se l'effetto per lei termina, è immune alla Presenza terrificante del drago per le 24 ore successive.\n\n***Soffio di fuoco (ricarica 5–6).*** Il drago esala fuoco in un cono di 27 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 24, subendo 91 (26d6) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"",
			"Il drago può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il drago recupera le azioni leggendarie effettuate.\n\n***Attacco di coda.*** Il drago effettua un attacco con la coda.\n\n***Individuazione.*** Il drago effettua una prova di Saggezza (Percezione).\n\n***Attacco d'ala (costa 2 azioni).*** Il drago sbatte le ali. Ogni creatura entro 4,5 metri dal drago deve superare un tiro salvezza su Destrezza con CD 25, altrimenti subisce 17 (2d6 + 10) danni contundenti e cade a terra prona. Il drago può poi volare fino a metà della sua velocità di volare.",
			""),
		new Text(
			"Ancient Red Dragon",
			null,
			"Gargantuan dragon, chaotic evil",
			"22 (natural armor)",
			"40 ft., climb 40 ft., fly 80 ft.",
			"Dex +7, Con +16, Wis +9, Cha +13",
			"Perception +16, Stealth +7",
			"",
			"",
			"fire",
			"",
			"blindsight 60 ft., darkvision 120 ft., passive Perception 26",
			"Common, Draconic",
			"***Legendary Resistance (3/Day).*** If the dragon fails a saving throw, it can choose to succeed instead.",
			"***Multiattack.*** The dragon can use its Frightful Presence. It then makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +17 to hit, reach 15 ft., one target. *Hit:* 21 (2d10 + 10) piercing damage plus 14 (4d6) fire damage.\n\n***Claw.*** *Melee Weapon Attack:* +17 to hit, reach 10 ft., one target. *Hit:* 17 (2d6 + 10) slashing damage.\n\n***Tail.*** *Melee Weapon Attack:* +17 to hit, reach 20 ft., one target. *Hit:* 19 (2d8 + 10) bludgeoning damage.\n\n***Frightful Presence.*** Each creature of the dragon's choice that is within 120 feet of the dragon and aware of it must succeed on a DC 21 Wisdom saving throw or become frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the dragon's Frightful Presence for the next 24 hours.\n\n***Fire Breath (Recharge 5–6).*** The dragon exhales fire in a 90-foot cone. Each creature in that area must make a DC 24 Dexterity saving throw, taking 91 (26d6) fire damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"The dragon can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The dragon regains spent legendary actions at the start of its turn.\n\n***Detect.*** The dragon makes a Wisdom (Perception) check.\n\n***Tail Attack.*** The dragon makes a tail attack.\n\n***Wing Attack (Costs 2 Actions).*** The dragon beats its wings. Each creature within 15 ft. of the dragon must succeed on a DC 25 Dexterity saving throw or take 17 (2d6 + 10) bludgeoning damage and be knocked prone. The dragon can then fly up to half its flying speed.",
			""));
}
