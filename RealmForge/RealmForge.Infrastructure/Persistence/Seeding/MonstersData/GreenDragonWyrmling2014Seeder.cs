using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Green Dragon Wyrmling (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GreenDragonWyrmling2014Seeder
{
	public static Monster Build() => Create("green-dragon-wyrmling", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Dragon,
		17, 38, "7d8 + 7", 30, new[] { 15, 12, 13, 14, 11, 13 }, 2m, 450, 2, 14,
		new Text(
			"Drago verde cucciolo",
			null,
			"Drago Medio, legale malvagio",
			"17 (armatura naturale)",
			"9 m, nuotare 9 m, volare 18 m",
			"Car +3, Cos +3, Des +3, Sag +2",
			"Furtività +3, Percezione +4",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 14, scurovisione 18 m, vista cieca 3 m",
			"Draconico",
			"***Anfibio.*** Il drago può respirare in aria e in acqua.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d10 + 2) danni perforanti più 3 (1d6) danni da veleno.\n\n***Soffio di veleno (ricarica 5–6).*** Il drago esala gas velenoso in un cono di 4,5 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione con CD 11, subendo 21 (6d6) danni da veleno in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Green Dragon Wyrmling",
			null,
			"Medium dragon, lawful evil",
			"17 (natural armor)",
			"30 ft., fly 60 ft., swim 30 ft.",
			"Dex +3, Con +3, Wis +2, Cha +3",
			"Perception +4, Stealth +3",
			"",
			"",
			"poison",
			"poisoned",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 14",
			"Draconic",
			"***Amphibious.*** The dragon can breathe air and water.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (1d10 + 2) piercing damage plus 3 (1d6) poison damage.\n\n***Poison Breath (Recharge 5–6).*** The dragon exhales poisonous gas in a 15-foot cone. Each creature in that area must make a DC 11 Constitution saving throw, taking 21 (6d6) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
