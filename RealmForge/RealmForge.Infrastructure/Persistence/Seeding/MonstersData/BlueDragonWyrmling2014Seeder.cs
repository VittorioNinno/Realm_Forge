using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Blue Dragon Wyrmling (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BlueDragonWyrmling2014Seeder
{
	public static Monster Build() => Create("blue-dragon-wyrmling", null, CreatureSize.Medium, CreatureType.Dragon,
		17, 52, "8d8 + 16", 30, new[] { 17, 10, 15, 12, 11, 15 }, 3m, 700, 2, 14,
		new Text(
			"Drago blu cucciolo",
			null,
			"Drago Medio, legale malvagio",
			"17 (armatura naturale)",
			"9 m, scavare 4,5 m, volare 18 m",
			"Car +4, Cos +4, Des +2, Sag +2",
			"Furtività +2, Percezione +4",
			"",
			"",
			"fulmine",
			"",
			"Percezione passiva 14, scurovisione 18 m, vista cieca 3 m",
			"Draconico",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d10 + 3) danni perforanti più 3 (1d6) danni da fulmine.\n\n***Soffio di fulmini (ricarica 5–6).*** Il drago esala una scarica di fulmini lunga 9 metri e larga 1,5 metri. Ogni creatura su quella linea deve effettuare un tiro salvezza su Destrezza con CD 12, subendo 22 (4d10) danni da fulmine in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"Blue Dragon Wyrmling",
			null,
			"Medium dragon, lawful evil",
			"17 (natural armor)",
			"30 ft., burrow 15 ft., fly 60 ft.",
			"Dex +2, Con +4, Wis +2, Cha +4",
			"Perception +4, Stealth +2",
			"",
			"",
			"lightning",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 14",
			"Draconic",
			"",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 8 (1d10 + 3) piercing damage plus 3 (1d6) lightning damage.\n\n***Lightning Breath (Recharge 5–6).*** The dragon exhales lightning in a 30-foot line that is 5 feet wide. Each creature in that line must make a DC 12 Dexterity saving throw, taking 22 (4d10) lightning damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
