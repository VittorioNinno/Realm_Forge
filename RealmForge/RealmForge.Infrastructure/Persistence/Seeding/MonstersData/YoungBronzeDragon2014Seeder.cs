using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young Bronze Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class YoungBronzeDragon2014Seeder
{
	public static Monster Build() => Create("young-bronze-dragon", null, CreatureSize.Large, CreatureType.Dragon,
		18, 142, "15d10 + 60", 40, new[] { 21, 10, 19, 14, 13, 17 }, 8m, 3900, 3, 17,
		new Text(
			"Drago di bronzo giovane",
			null,
			"Drago Grande, legale buono",
			"18 (armatura naturale)",
			"12 m, nuotare 12 m, volare 24 m",
			"Car +6, Cos +7, Des +3, Sag +4",
			"Furtività +3, Intuizione +4, Percezione +7",
			"",
			"",
			"fulmine",
			"",
			"Percezione passiva 17, scurovisione 36 m, vista cieca 9 m",
			"Comune, Draconico",
			"***Anfibio.*** Il drago può respirare in aria e in acqua.",
			"***Multiattacco.*** Il drago effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 16 (2d10 + 5) danni perforanti.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di fulmini.*** Il drago esala una scarica di fulmini lunga 18 metri e larga 1,5 metri. Ogni creatura su quella linea deve effettuare un tiro salvezza su Destrezza con CD 15, subendo 55 (10d10) danni da fulmine in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio repulsivo.*** Il drago esala energia repulsiva in un cono di 9 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Forza con CD 15. Se lo fallisce, viene scagliata a 12 metri dal drago.",
			"",
			""),
		new Text(
			"Young Bronze Dragon",
			null,
			"Large dragon, lawful good",
			"18 (natural armor)",
			"40 ft., fly 80 ft., swim 40 ft.",
			"Dex +3, Con +7, Wis +4, Cha +6",
			"Insight +4, Perception +7, Stealth +3",
			"",
			"",
			"lightning",
			"",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 17",
			"Common, Draconic",
			"***Amphibious.*** The dragon can breathe air and water.",
			"***Multiattack.*** The dragon makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +8 to hit, reach 10 ft., one target. *Hit:* 16 (2d10 + 5) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 12 (2d6 + 5) slashing damage.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nLightning Breath. The dragon exhales lightning in a 60-foot line that is 5 feet wide. Each creature in that line must make a DC 15 Dexterity saving throw, taking 55 (10d10) lightning damage on a failed save, or half as much damage on a successful one.\nRepulsion Breath. The dragon exhales repulsion energy in a 30-foot cone. Each creature in that area must succeed on a DC 15 Strength saving throw. On a failed save, the creature is pushed 40 feet away from the dragon.",
			"",
			""));
}
