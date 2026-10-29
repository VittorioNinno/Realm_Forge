using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Copper Dragon Wyrmling (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class CopperDragonWyrmling2014Seeder
{
	public static Monster Build() => Create("copper-dragon-wyrmling", null, CreatureSize.Medium, CreatureType.Dragon,
		16, 22, "4d8 + 4", 30, new[] { 15, 12, 13, 14, 11, 13 }, 1m, 200, 2, 14,
		new Text(
			"Drago di rame cucciolo",
			null,
			"Drago Medio, caotico buono",
			"16 (armatura naturale)",
			"9 m, scalare 9 m, volare 18 m",
			"Car +3, Cos +3, Des +3, Sag +2",
			"Furtività +3, Percezione +4",
			"",
			"",
			"acido",
			"",
			"Percezione passiva 14, scurovisione 18 m, vista cieca 3 m",
			"Draconico",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d10 + 2) danni perforanti.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di acido.*** Il drago esala una scia di fuoco lunga 6 metri e larga 1,5 metri. Ogni creatura su quella linea deve effettuare un tiro salvezza su Destrezza con CD 11, subendo 18 (4d8) danni da acido in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio rallentante.*** Il drago esala gas in un cono di 4,5 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Costituzione con CD 11; se lo fallisce, non può usare reazioni, la sua velocità è dimezzata e non può effettuare più di un attacco nel suo turno. Inoltre, nel suo turno la creatura può usare un'azione o un'azione bonus, ma non entrambe. Questi effetti durano 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto per lei termina.",
			"",
			""),
		new Text(
			"Copper Dragon Wyrmling",
			null,
			"Medium dragon, chaotic good",
			"16 (natural armor)",
			"30 ft., climb 30 ft., fly 60 ft.",
			"Dex +3, Con +3, Wis +2, Cha +3",
			"Perception +4, Stealth +3",
			"",
			"",
			"acid",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 14",
			"Draconic",
			"",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (1d10 + 2) piercing damage.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nAcid Breath. The dragon exhales acid in an 20-foot line that is 5 feet wide. Each creature in that line must make a DC 11 Dexterity saving throw, taking 18 (4d8) acid damage on a failed save, or half as much damage on a successful one.\nSlowing Breath. The dragon exhales gas in a 15-foot cone. Each creature in that area must succeed on a DC 11 Constitution saving throw. On a failed save, the creature can't use reactions, its speed is halved, and it can't make more than one attack on its turn. In addition, the creature can use either an action or a bonus action on its turn, but not both. These effects last for 1 minute. The creature can repeat the saving throw at the end of each of its turns, ending the effect on itself with a successful save.",
			"",
			""));
}
