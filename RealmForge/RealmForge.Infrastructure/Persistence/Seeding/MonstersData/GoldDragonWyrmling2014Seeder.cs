using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gold Dragon Wyrmling (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GoldDragonWyrmling2014Seeder
{
	public static Monster Build() => Create("gold-dragon-wyrmling", null, CreatureSize.Medium, CreatureType.Dragon,
		17, 60, "8d8 + 24", 30, new[] { 19, 14, 17, 14, 11, 16 }, 3m, 700, 2, 14,
		new Text(
			"Drago d'oro cucciolo",
			null,
			"Drago Medio, legale buono",
			"17 (armatura naturale)",
			"9 m, nuotare 9 m, volare 18 m",
			"Car +5, Cos +5, Des +4, Sag +2",
			"Furtività +4, Percezione +4",
			"",
			"",
			"fuoco",
			"",
			"Percezione passiva 14, scurovisione 18 m, vista cieca 3 m",
			"Draconico",
			"***Anfibio.*** Il drago può respirare in aria e in acqua.",
			"***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (1d10 + 4) danni perforanti.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di fuoco.*** Il drago esala fuoco in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 13, subendo 22 (4d10) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio indebolente.*** Il drago esala gas in un cono di 4,5 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Forza con CD 13, altrimenti subisce svantaggio ai tiri per colpire basati sulla Forza, alle prove di Forza e ai tiri salvezza su Forza per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			""),
		new Text(
			"Gold Dragon Wyrmling",
			null,
			"Medium dragon, lawful good",
			"17 (natural armor)",
			"30 ft., fly 60 ft., swim 30 ft.",
			"Dex +4, Con +5, Wis +2, Cha +5",
			"Perception +4, Stealth +4",
			"",
			"",
			"fire",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 14",
			"Draconic",
			"***Amphibious.*** The dragon can breathe air and water.",
			"***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 9 (1d10 + 4) piercing damage.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nFire Breath. The dragon exhales fire in a 15-foot cone. Each creature in that area must make a DC 13 Dexterity saving throw, taking 22 (4d10) fire damage on a failed save, or half as much damage on a successful one.\nWeakening Breath. The dragon exhales gas in a 15-foot cone. Each creature in that area must succeed on a DC 13 Strength saving throw or have disadvantage on Strength-based attack rolls, Strength checks, and Strength saving throws for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			""));
}
