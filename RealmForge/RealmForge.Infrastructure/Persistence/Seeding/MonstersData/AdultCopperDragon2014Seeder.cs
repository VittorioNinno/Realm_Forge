using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Adult Copper Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class AdultCopperDragon2014Seeder
{
	public static Monster Build() => Create("adult-copper-dragon", null, ContentSource.Srd51, CreatureSize.Huge, CreatureType.Dragon,
		18, 184, "16d12 + 80", 40, new[] { 23, 12, 21, 18, 15, 17 }, 14m, 11500, 5, 22,
		new Text(
			"Drago di rame adulto",
			null,
			"Drago Enorme, caotico buono",
			"18 (armatura naturale)",
			"12 m, scalare 12 m, volare 24 m",
			"Car +8, Cos +10, Des +6, Sag +7",
			"Furtività +6, Inganno +8, Percezione +12",
			"",
			"",
			"acido",
			"",
			"Percezione passiva 22, scurovisione 36 m, vista cieca 18 m",
			"Comune, Draconico",
			"***Resistenza leggendaria (3/giorno).*** Se il drago fallisce un tiro salvezza, può scegliere di superarlo comunque.",
			"***Multiattacco.*** Il drago può usare la sua Presenza terrificante. Poi effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +11 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d6 + 6) danni taglienti.\n\n***Coda.*** *Attacco con arma da mischia:* +11 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 15 (2d8 + 6) danni contundenti.\n\n***Morso.*** *Attacco con arma da mischia:* +11 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 17 (2d10 + 6) danni perforanti.\n\n***Presenza terrificante.*** Ogni creatura a scelta del drago situata entro 36 metri da esso e consapevole della sua presenza deve superare un tiro salvezza su Saggezza con CD 16, altrimenti è spaventata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce. Se una creatura supera il tiro salvezza o se l'effetto per lei termina, è immune alla Presenza terrificante del drago per le 24 ore successive.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di acido.*** Il drago esala una scia di fuoco lunga 18 metri e larga 1,5 metri. Ogni creatura su quella scia deve effettuare un tiro salvezza su Destrezza con CD 18, subendo 54 (12d8) danni da acido in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio rallentante.*** Il drago esala gas in un cono di 18 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Costituzione con CD 18; se lo fallisce, non può usare reazioni, la sua velocità è dimezzata e non può effettuare più di un attacco nel suo turno. Inoltre, nel suo turno la creatura può usare un'azione o un'azione bonus, ma non entrambe. Questi effetti durano 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto per lei termina.",
			"",
			"",
			"Il drago può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il drago recupera le azioni leggendarie effettuate.\n\n***Attacco di coda.*** Il drago effettua un attacco con la coda.\n\n***Individuazione.*** Il drago effettua una prova di Saggezza (Percezione).\n\n***Attacco d'ala (costa 2 azioni).*** Il drago sbatte le ali. Ogni creatura entro 3 metri dal drago deve superare un tiro salvezza su Destrezza con CD 19, altrimenti subisce 13 (2d6 + 6) danni contundenti e cade a terra prona. Il drago può poi volare fino a metà della sua velocità di volare.",
			""),
		new Text(
			"Adult Copper Dragon",
			null,
			"Huge dragon, chaotic good",
			"18 (natural armor)",
			"40 ft., climb 40 ft., fly 80 ft.",
			"Dex +6, Con +10, Wis +7, Cha +8",
			"Deception +8, Perception +12, Stealth +6",
			"",
			"",
			"acid",
			"",
			"blindsight 60 ft., darkvision 120 ft., passive Perception 22",
			"Common, Draconic",
			"***Legendary Resistance (3/Day).*** If the dragon fails a saving throw, it can choose to succeed instead.",
			"***Multiattack.*** The dragon can use its Frightful Presence. It then makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +11 to hit, reach 10 ft., one target. *Hit:* 17 (2d10 + 6) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +11 to hit, reach 5 ft., one target. *Hit:* 13 (2d6 + 6) slashing damage.\n\n***Tail.*** *Melee Weapon Attack:* +11 to hit, reach 15 ft., one target. *Hit:* 15 (2d8 + 6) bludgeoning damage.\n\n***Frightful Presence.*** Each creature of the dragon's choice that is within 120 feet of the dragon and aware of it must succeed on a DC 16 Wisdom saving throw or become frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the dragon's Frightful Presence for the next 24 hours.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nAcid Breath. The dragon exhales acid in an 60-foot line that is 5 feet wide. Each creature in that line must make a DC 18 Dexterity saving throw, taking 54 (12d8) acid damage on a failed save, or half as much damage on a successful one.\nSlowing Breath. The dragon exhales gas in a 60-foot cone. Each creature in that area must succeed on a DC 18 Constitution saving throw. On a failed save, the creature can't use reactions, its speed is halved, and it can't make more than one attack on its turn. In addition, the creature can use either an action or a bonus action on its turn, but not both. These effects last for 1 minute. The creature can repeat the saving throw at the end of each of its turns, ending the effect on itself with a successful save.",
			"",
			"",
			"The dragon can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The dragon regains spent legendary actions at the start of its turn.\n\n***Detect.*** The dragon makes a Wisdom (Perception) check.\n\n***Tail Attack.*** The dragon makes a tail attack.\n\n***Wing Attack (Costs 2 Actions).*** The dragon beats its wings. Each creature within 10 ft. of the dragon must succeed on a DC 19 Dexterity saving throw or take 13 (2d6 + 6) bludgeoning damage and be knocked prone. The dragon can then fly up to half its flying speed.",
			""));
}
