using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young Brass Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class YoungBrassDragon2014Seeder
{
	public static Monster Build() => Create("young-brass-dragon", null, CreatureSize.Large, CreatureType.Dragon,
		17, 110, "13d10 + 39", 40, new[] { 19, 10, 17, 12, 11, 15 }, 6m, 2300, 3, 16,
		new Text(
			"Drago d'ottone giovane",
			null,
			"Drago Grande, caotico buono",
			"17 (armatura naturale)",
			"12 m, scavare 6 m, volare 24 m",
			"Car +5, Cos +6, Des +3, Sag +3",
			"Furtività +3, Percezione +6, Persuasione +5",
			"",
			"",
			"fuoco",
			"",
			"Percezione passiva 16, scurovisione 36 m, vista cieca 9 m",
			"Comune, Draconico",
			"",
			"***Multiattacco.*** Il drago effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (2d10 + 4) danni perforanti.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di fuoco.*** Il drago esala una scia di fuoco lunga 12 metri e larga 1,5 metri. Ogni creatura su quella scia deve effettuare un tiro salvezza su Destrezza con CD 14, subendo 42 (12d6) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio di sonno.*** Il drago esala gas soporifero in un cono di 9 metri. Ogni creatura nell'area deve superare un tiro salvezza su Costituzione con CD 14, altrimenti diventa priva di sensi per 5 minuti. Questo effetto termina se la creatura subisce danni o se qualcuno usa un'azione per svegliarla.",
			"",
			""),
		new Text(
			"Young Brass Dragon",
			null,
			"Large dragon, chaotic good",
			"17 (natural armor)",
			"40 ft., burrow 20 ft., fly 80 ft.",
			"Dex +3, Con +6, Wis +3, Cha +5",
			"Perception +6, Persuasion +5, Stealth +3",
			"",
			"",
			"fire",
			"",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 16",
			"Common, Draconic",
			"",
			"***Multiattack.*** The dragon makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 15 (2d10 + 4) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nFire Breath. The dragon exhales fire in a 40-foot line that is 5 feet wide. Each creature in that line must make a DC 14 Dexterity saving throw, taking 42 (12d6) fire damage on a failed save, or half as much damage on a successful one.\nSleep Breath. The dragon exhales sleep gas in a 30-foot cone. Each creature in that area must succeed on a DC 14 Constitution saving throw or fall unconscious for 5 minutes. This effect ends for a creature if the creature takes damage or someone uses an action to wake it.",
			"",
			""));
}
