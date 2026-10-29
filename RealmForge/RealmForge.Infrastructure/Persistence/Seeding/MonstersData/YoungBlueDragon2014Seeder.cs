using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young Blue Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class YoungBlueDragon2014Seeder
{
	public static Monster Build() => Create("young-blue-dragon", null, CreatureSize.Large, CreatureType.Dragon,
		18, 152, "16d10 + 64", 40, new[] { 21, 10, 19, 14, 13, 17 }, 9m, 5000, 4, 19,
		new Text(
			"Drago blu giovane",
			null,
			"Drago Grande, legale malvagio",
			"18 (armatura naturale)",
			"12 m, scavare 6 m, volare 24 m",
			"Car +7, Cos +8, Des +4, Sag +5",
			"Furtività +4, Percezione +9",
			"",
			"",
			"fulmine",
			"",
			"Percezione passiva 19, scurovisione 36 m, vista cieca 9 m",
			"Comune, Draconico",
			"",
			"***Multiattacco.*** Il drago effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 16 (2d10 + 5) danni perforanti più 5 (1d10) danni da fulmine.\n\n***Soffio di fulmini (ricarica 5–6).*** Il drago esala una scarica di fulmini lunga 18 metri e larga 1,5 metri. Ogni creatura su quella linea deve effettuare un tiro salvezza su Destrezza con CD 16, subendo 55 (10d10) danni da fulmine in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"Young Blue Dragon",
			null,
			"Large dragon, lawful evil",
			"18 (natural armor)",
			"40 ft., burrow 20 ft., fly 80 ft.",
			"Dex +4, Con +8, Wis +5, Cha +7",
			"Perception +9, Stealth +4",
			"",
			"",
			"lightning",
			"",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 19",
			"Common, Draconic",
			"",
			"***Multiattack.*** The dragon makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +9 to hit, reach 10 ft., one target. *Hit:* 16 (2d10 + 5) piercing damage plus 5 (1d10) lightning damage.\n\n***Claw.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 12 (2d6 + 5) slashing damage.\n\n***Lightning Breath (Recharge 5–6).*** The dragon exhales lightning in a 60-foot line that is 5 feet wide. Each creature in that line must make a DC 16 Dexterity saving throw, taking 55 (10d10) lightning damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
