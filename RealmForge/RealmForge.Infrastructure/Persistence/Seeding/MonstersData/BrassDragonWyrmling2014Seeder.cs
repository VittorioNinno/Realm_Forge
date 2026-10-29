using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Brass Dragon Wyrmling (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BrassDragonWyrmling2014Seeder
{
	public static Monster Build() => Create("brass-dragon-wyrmling", null, CreatureSize.Medium, CreatureType.Dragon,
		16, 16, "3d8 + 3", 30, new[] { 15, 10, 13, 10, 11, 13 }, 1m, 200, 2, 14,
		new Text(
			"Drago d'ottone cucciolo",
			null,
			"Drago Medio, caotico buono",
			"16 (armatura naturale)",
			"9 m, scavare 4,5 m, volare 18 m",
			"Car +3, Cos +3, Des +2, Sag +2",
			"Furtività +2, Percezione +4",
			"",
			"",
			"fuoco",
			"",
			"Percezione passiva 14, scurovisione 18 m, vista cieca 3 m",
			"Draconico",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d10 + 2) danni perforanti.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di fuoco.*** Il drago esala una scia di fuoco lunga 6 metri e larga 1,5 metri. Ogni creatura su quella scia deve effettuare un tiro salvezza su Destrezza con CD 11, subendo 14 (4d6) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio di sonno.*** Il drago esala gas soporifero in un cono di 4,5 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Costituzione con CD 11, altrimenti è priva di sensi per 1 minuto. Questo effetto termina se la creatura subisce danni o se qualcuno usa un'azione per svegliarla.",
			"",
			""),
		new Text(
			"Brass Dragon Wyrmling",
			null,
			"Medium dragon, chaotic good",
			"16 (natural armor)",
			"30 ft., burrow 15 ft., fly 60 ft.",
			"Dex +2, Con +3, Wis +2, Cha +3",
			"Perception +4, Stealth +2",
			"",
			"",
			"fire",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 14",
			"Draconic",
			"",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (1d10 + 2) piercing damage.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nFire Breath. The dragon exhales fire in an 20-foot line that is 5 feet wide. Each creature in that line must make a DC 11 Dexterity saving throw, taking 14 (4d6) fire damage on a failed save, or half as much damage on a successful one.\nSleep Breath. The dragon exhales sleep gas in a 15-foot cone. Each creature in that area must succeed on a DC 11 Constitution saving throw or fall unconscious for 1 minute. This effect ends for a creature if the creature takes damage or someone uses an action to wake it.",
			"",
			""));
}
