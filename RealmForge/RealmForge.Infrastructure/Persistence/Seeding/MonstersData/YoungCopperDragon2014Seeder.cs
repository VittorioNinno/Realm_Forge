using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young Copper Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class YoungCopperDragon2014Seeder
{
	public static Monster Build() => Create("young-copper-dragon", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Dragon,
		17, 119, "14d10 + 42", 40, new[] { 19, 12, 17, 16, 13, 15 }, 7m, 2900, 3, 17,
		new Text(
			"Drago di rame giovane",
			null,
			"Drago Grande, caotico buono",
			"17 (armatura naturale)",
			"12 m, scalare 12 m, volare 24 m",
			"Car +5, Cos +6, Des +4, Sag +4",
			"Furtività +4, Inganno +5, Percezione +7",
			"",
			"",
			"acido",
			"",
			"Percezione passiva 17, scurovisione 36 m, vista cieca 9 m",
			"Comune, Draconico",
			"",
			"***Multiattacco.*** Il drago effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (2d10 + 4) danni perforanti.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di acido.*** Il drago esala una scia di fuoco lunga 12 metri e larga 1,5 metri. Ogni creatura su quella scia deve effettuare un tiro salvezza su Destrezza con CD 14, subendo 40 (9d8) danni da acido in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio rallentante.*** Il drago esala gas in un cono di 9 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Costituzione con CD 14; se lo fallisce, non può usare reazioni, la sua velocità è dimezzata e non può effettuare più di un attacco nel suo turno. Inoltre, nel suo turno la creatura può usare un'azione o un'azione bonus, ma non entrambe. Questi effetti durano 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto per lei termina.",
			"",
			"",
			"",
			""),
		new Text(
			"Young Copper Dragon",
			null,
			"Large dragon, chaotic good",
			"17 (natural armor)",
			"40 ft., climb 40 ft., fly 80 ft.",
			"Dex +4, Con +6, Wis +4, Cha +5",
			"Deception +5, Perception +7, Stealth +4",
			"",
			"",
			"acid",
			"",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 17",
			"Common, Draconic",
			"",
			"***Multiattack.*** The dragon makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 15 (2d10 + 4) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nAcid Breath. The dragon exhales acid in an 40-foot line that is 5 feet wide. Each creature in that line must make a DC 14 Dexterity saving throw, taking 40 (9d8) acid damage on a failed save, or half as much damage on a successful one.\nSlowing Breath. The dragon exhales gas in a 30-foot cone. Each creature in that area must succeed on a DC 14 Constitution saving throw. On a failed save, the creature can't use reactions, its speed is halved, and it can't make more than one attack on its turn. In addition, the creature can use either an action or a bonus action on its turn, but not both. These effects last for 1 minute. The creature can repeat the saving throw at the end of each of its turns, ending the effect on itself with a successful save.",
			"",
			"",
			"",
			""));
}
