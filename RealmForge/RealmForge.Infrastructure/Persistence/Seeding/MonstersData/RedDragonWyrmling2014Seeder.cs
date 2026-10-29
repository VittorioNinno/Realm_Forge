using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Red Dragon Wyrmling (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class RedDragonWyrmling2014Seeder
{
	public static Monster Build() => Create("red-dragon-wyrmling", null, CreatureSize.Medium, CreatureType.Dragon,
		17, 75, "10d8 + 30", 30, new[] { 19, 10, 17, 12, 11, 15 }, 4m, 1100, 2, 14,
		new Text(
			"Drago rosso cucciolo",
			null,
			"Drago Medio, caotico malvagio",
			"17 (armatura naturale)",
			"9 m, scalare 9 m, volare 18 m",
			"Car +4, Cos +5, Des +2, Sag +2",
			"Furtività +2, Percezione +4",
			"",
			"",
			"fuoco",
			"",
			"Percezione passiva 14, scurovisione 18 m, vista cieca 3 m",
			"Draconico",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (1d10 + 4) danni perforanti più 3 (1d6) danni da fuoco.\n\n***Soffio di fuoco (ricarica 5–6).*** Il drago esala fuoco in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 13, subendo 24 (7d6) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"Red Dragon Wyrmling",
			null,
			"Medium dragon, chaotic evil",
			"17 (natural armor)",
			"30 ft., climb 30 ft., fly 60 ft.",
			"Dex +2, Con +5, Wis +2, Cha +4",
			"Perception +4, Stealth +2",
			"",
			"",
			"fire",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 14",
			"Draconic",
			"",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 9 (1d10 + 4) piercing damage plus 3 (1d6) fire damage.\n\n***Fire Breath (Recharge 5–6).*** The dragon exhales fire in a 15-foot cone. Each creature in that area must make a DC 13 Dexterity saving throw, taking 24 (7d6) fire damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
