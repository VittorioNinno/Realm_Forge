using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Silver Dragon Wyrmling (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SilverDragonWyrmling2014Seeder
{
	public static Monster Build() => Create("silver-dragon-wyrmling", null, CreatureSize.Medium, CreatureType.Dragon,
		17, 45, "6d8 + 18", 30, new[] { 19, 10, 17, 12, 11, 15 }, 2m, 450, 2, 14,
		new Text(
			"Drago d'argento cucciolo",
			null,
			"Drago Medio, legale buono",
			"17 (armatura naturale)",
			"9 m, volare 18 m",
			"Car +4, Cos +5, Des +2, Sag +2",
			"Furtività +2, Percezione +4",
			"",
			"",
			"freddo",
			"",
			"Percezione passiva 14, scurovisione 18 m, vista cieca 3 m",
			"Draconico",
			"",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (1d10 + 4) danni perforanti.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di freddo.*** Il drago esala una folata gelida in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione con CD 13, subendo 18 (4d8) danni da freddo in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio paralizzante.*** Il drago esala gas paralizzante in un cono di 4,5 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Costituzione con CD 13, altrimenti è paralizzata per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			""),
		new Text(
			"Silver Dragon Wyrmling",
			null,
			"Medium dragon, lawful good",
			"17 (natural armor)",
			"30 ft., fly 60 ft.",
			"Dex +2, Con +5, Wis +2, Cha +4",
			"Perception +4, Stealth +2",
			"",
			"",
			"cold",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 14",
			"Draconic",
			"",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 9 (1d10 + 4) piercing damage.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nCold Breath. The dragon exhales an icy blast in a 15-foot cone. Each creature in that area must make a DC 13 Constitution saving throw, taking 18 (4d8) cold damage on a failed save, or half as much damage on a successful one.\nParalyzing Breath. The dragon exhales paralyzing gas in a 15-foot cone. Each creature in that area must succeed on a DC 13 Constitution saving throw or be paralyzed for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			""));
}
