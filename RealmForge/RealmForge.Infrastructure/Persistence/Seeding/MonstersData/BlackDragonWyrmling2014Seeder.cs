using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Black Dragon Wyrmling (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BlackDragonWyrmling2014Seeder
{
	public static Monster Build() => Create("black-dragon-wyrmling", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Dragon,
		17, 33, "6d8 + 6", 30, new[] { 15, 14, 13, 10, 11, 13 }, 2m, 450, 2, 14,
		new Text(
			"Drago nero cucciolo",
			null,
			"Drago Medio, caotico malvagio",
			"17 (armatura naturale)",
			"9 m, nuotare 9 m, volare 18 m",
			"Car +3, Cos +3, Des +4, Sag +2",
			"Furtività +4, Percezione +4",
			"",
			"",
			"acido",
			"",
			"Percezione passiva 14, scurovisione 18 m, vista cieca 3 m",
			"Draconico",
			"***Anfibio.*** Il drago può respirare in aria e in acqua.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d10 + 2) danni perforanti più 2 (1d4) danni da acido.\n\n***Soffio di acido (ricarica 5–6).*** Il drago esala una scia di acido lunga 4,5 metri e larga 1,5 metri. Ogni creatura su quella scia deve effettuare un tiro salvezza su Destrezza con CD 11, subendo 22 (5d8) danni da acido in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Black Dragon Wyrmling",
			null,
			"Medium dragon, chaotic evil",
			"17 (natural armor)",
			"30 ft., fly 60 ft., swim 30 ft.",
			"Dex +4, Con +3, Wis +2, Cha +3",
			"Perception +4, Stealth +4",
			"",
			"",
			"acid",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 14",
			"Draconic",
			"***Amphibious.*** The dragon can breathe air and water.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (1d10 + 2) piercing damage plus 2 (1d4) acid damage.\n\n***Acid Breath (Recharge 5–6).*** The dragon exhales acid in a 15-foot line that is 5 feet wide. Each creature in that line must make a DC 11 Dexterity saving throw, taking 22 (5d8) acid damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
