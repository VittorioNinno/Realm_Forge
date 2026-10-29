using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young Gold Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class YoungGoldDragon2014Seeder
{
	public static Monster Build() => Create("young-gold-dragon", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Dragon,
		18, 178, "17d10 + 85", 40, new[] { 23, 14, 21, 16, 13, 20 }, 10m, 5900, 4, 19,
		new Text(
			"Drago d'oro giovane",
			null,
			"Drago Grande, legale buono",
			"18 (armatura naturale)",
			"12 m, nuotare 12 m, volare 24 m",
			"Car +9, Cos +9, Des +6, Sag +5",
			"Furtività +6, Intuizione +5, Percezione +9, Persuasione +9",
			"",
			"",
			"fuoco",
			"",
			"Percezione passiva 19, scurovisione 36 m, vista cieca 9 m",
			"Comune, Draconico",
			"***Anfibio.*** Il drago può respirare in aria e in acqua.",
			"***Multiattacco.*** Il drago effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d6 + 6) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 17 (2d10 + 6) danni perforanti.\n\n***Soffi (ricarica 5–6).*** Il drago usa uno dei seguenti soffi.\n\n***Soffio di fuoco.*** Il drago esala fuoco in un cono di 9 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 17, subendo 55 (10d10) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Soffio indebolente.*** Il drago esala gas in un cono di 9 metri. Ogni creatura in quell'area deve superare un tiro salvezza su Forza con CD 17, altrimenti subisce svantaggio ai tiri per colpire basati sulla Forza, alle prove di Forza e ai tiri salvezza su Forza per 1 minuto. La creatura può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			"",
			"",
			""),
		new Text(
			"Young Gold Dragon",
			null,
			"Large dragon, lawful good",
			"18 (natural armor)",
			"40 ft., fly 80 ft., swim 40 ft.",
			"Dex +6, Con +9, Wis +5, Cha +9",
			"Insight +5, Perception +9, Persuasion +9, Stealth +6",
			"",
			"",
			"fire",
			"",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 19",
			"Common, Draconic",
			"***Amphibious.*** The dragon can breathe air and water.",
			"***Multiattack.*** The dragon makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 17 (2d10 + 6) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 13 (2d6 + 6) slashing damage.\n\n***Breath Weapons (Recharge 5–6).*** The dragon uses one of the following breath weapons.\n\nFire Breath. The dragon exhales fire in a 30-foot cone. Each creature in that area must make a DC 17 Dexterity saving throw, taking 55 (10d10) fire damage on a failed save, or half as much damage on a successful one.\nWeakening Breath. The dragon exhales gas in a 30-foot cone. Each creature in that area must succeed on a DC 17 Strength saving throw or have disadvantage on Strength-based attack rolls, Strength checks, and Strength saving throws for 1 minute. A creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			"",
			"",
			""));
}
