using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young Black Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class YoungBlackDragon2014Seeder
{
	public static Monster Build() => Create("young-black-dragon", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Dragon,
		18, 127, "15d10 + 45", 40, new[] { 19, 14, 17, 12, 11, 15 }, 7m, 2900, 3, 16,
		new Text(
			"Drago nero giovane",
			null,
			"Drago Grande, caotico malvagio",
			"18 (armatura naturale)",
			"12 m, nuotare 12 m, volare 24 m",
			"Car +5, Cos +6, Des +5, Sag +3",
			"Furtività +5, Percezione +6",
			"",
			"",
			"acido",
			"",
			"Percezione passiva 16, scurovisione 36 m, vista cieca 9 m",
			"Comune, Draconico",
			"***Anfibio.*** Il drago può respirare in aria e in acqua.",
			"***Multiattacco.*** Il drago effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (2d10 + 4) danni perforanti più 4 (1d8) danni da acido.\n\n***Soffio di acido (ricarica 5–6).*** Il drago esala una scia di acido lunga 9 metri e larga 1,5 metri. Ogni creatura su quella scia deve effettuare un tiro salvezza su Destrezza con CD 14, subendo 49 (11d8) danni da acido in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Young Black Dragon",
			null,
			"Large dragon, chaotic evil",
			"18 (natural armor)",
			"40 ft., fly 80 ft., swim 40 ft.",
			"Dex +5, Con +6, Wis +3, Cha +5",
			"Perception +6, Stealth +5",
			"",
			"",
			"acid",
			"",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 16",
			"Common, Draconic",
			"***Amphibious.*** The dragon can breathe air and water.",
			"***Multiattack.*** The dragon makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 15 (2d10 + 4) piercing damage plus 4 (1d8) acid damage.\n\n***Claw.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.\n\n***Acid Breath (Recharge 5–6).*** The dragon exhales acid in a 30-foot line that is 5 feet wide. Each creature in that line must make a DC 14 Dexterity saving throw, taking 49 (11d8) acid damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
