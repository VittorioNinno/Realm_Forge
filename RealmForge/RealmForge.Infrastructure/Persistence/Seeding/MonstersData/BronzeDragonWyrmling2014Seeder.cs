using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Bronze Dragon Wyrmling (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BronzeDragonWyrmling2014Seeder
{
	public static Monster Build() => Create("bronze-dragon-wyrmling", null, CreatureSize.Medium, CreatureType.Dragon,
		17, 32, "5d8 + 10", 30, new[] { 17, 10, 15, 12, 11, 15 }, 2m, 450, 2, 14,
		new Text(
			"Drago di bronzo cucciolo",
			null,
			"Drago Medio, legale buono",
			"17 (armatura naturale)",
			"9 m, nuotare 9 m, volare 18 m",
			"Car +4, Cos +4, Des +2, Sag +2",
			"Furtività +2, Percezione +4",
			"",
			"",
			"fulmine",
			"",
			"Percezione passiva 14, scurovisione 18 m, vista cieca 3 m",
			"Draconico",
			"***Anfibio.*** Il drago può respirare in aria e in acqua.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d10 + 3) danni perforanti.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di fulmini.*** Il drago esala una scarica di fulmini lunga 12 metri e larga 1,5 metri. Ogni creatura su quella linea deve effettuare un tiro salvezza su Destrezza con CD 12, subendo 16 (3d10) danni da fulmine in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio repulsivo.*** Il drago esala energia repulsiva in un cono di 9 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Forza con CD 12. Se lo fallisce, viene scagliata a 9 metri dal drago.",
			"",
			""),
		new Text(
			"Bronze Dragon Wyrmling",
			null,
			"Medium dragon, lawful good",
			"17 (natural armor)",
			"30 ft., fly 60 ft., swim 30 ft.",
			"Dex +2, Con +4, Wis +2, Cha +4",
			"Perception +4, Stealth +2",
			"",
			"",
			"lightning",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 14",
			"Draconic",
			"***Amphibious.*** The dragon can breathe air and water.",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 8 (1d10 + 3) piercing damage.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nLightning Breath. The dragon exhales lightning in a 40-foot line that is 5 feet wide. Each creature in that line must make a DC 12 Dexterity saving throw, taking 16 (3d10) lightning damage on a failed save, or half as much damage on a successful one.\nRepulsion Breath. The dragon exhales repulsion energy in a 30-foot cone. Each creature in that area must succeed on a DC 12 Strength saving throw. On a failed save, the creature is pushed 30 feet away from the dragon.",
			"",
			""));
}
