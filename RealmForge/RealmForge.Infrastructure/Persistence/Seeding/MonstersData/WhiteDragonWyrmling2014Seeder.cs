using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	White Dragon Wyrmling (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class WhiteDragonWyrmling2014Seeder
{
	public static Monster Build() => Create("white-dragon-wyrmling", null, CreatureSize.Medium, CreatureType.Dragon,
		16, 32, "5d8 + 10", 30, new[] { 14, 10, 14, 5, 10, 11 }, 2m, 450, 2, 14,
		new Text(
			"Drago bianco cucciolo",
			null,
			"Drago Medio, caotico malvagio",
			"16 (armatura naturale)",
			"9 m, nuotare 9 m, scavare 4,5 m, volare 18 m",
			"Car +2, Cos +4, Des +2, Sag +2",
			"Furtività +2, Percezione +4",
			"",
			"",
			"freddo",
			"",
			"Percezione passiva 14, scurovisione 18 m, vista cieca 3 m",
			"Draconico",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d10 + 2) danni perforanti più 2 (1d4) danni da freddo.\n\n***Soffio di freddo (ricarica 5–6).*** Il drago esala una folata gelida in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione con CD 12, subendo 22 (5d8) danni da freddo in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"White Dragon Wyrmling",
			null,
			"Medium dragon, chaotic evil",
			"16 (natural armor)",
			"30 ft., burrow 15 ft., fly 60 ft., swim 30 ft.",
			"Dex +2, Con +4, Wis +2, Cha +2",
			"Perception +4, Stealth +2",
			"",
			"",
			"cold",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 14",
			"Draconic",
			"",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (1d10 + 2) piercing damage plus 2 (1d4) cold damage.\n\n***Cold Breath (Recharge 5–6).*** The dragon exhales an icy blast of hail in a 15-foot cone. Each creature in that area must make a DC 12 Constitution saving throw, taking 22 (5d8) cold damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
