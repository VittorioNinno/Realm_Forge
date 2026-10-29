using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young Red Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class YoungRedDragon2014Seeder
{
	public static Monster Build() => Create("young-red-dragon", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Dragon,
		18, 178, "17d10 + 85", 40, new[] { 23, 10, 21, 14, 11, 19 }, 10m, 5900, 4, 18,
		new Text(
			"Drago rosso giovane",
			null,
			"Drago Grande, caotico malvagio",
			"18 (armatura naturale)",
			"12 m, scalare 12 m, volare 24 m",
			"Car +8, Cos +9, Des +4, Sag +4",
			"Furtività +4, Percezione +8",
			"",
			"",
			"fuoco",
			"",
			"Percezione passiva 18, scurovisione 36 m, vista cieca 9 m",
			"Comune, Draconico",
			"",
			"***Multiattacco.*** Il drago effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d6 + 6) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 17 (2d10 + 6) danni perforanti più 3 (1d6) danni da fuoco.\n\n***Soffio di fuoco (ricarica 5–6).*** Il drago esala fuoco in un cono di 9 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Destrezza con CD 17, subendo 56 (16d6) danni da fuoco in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Young Red Dragon",
			null,
			"Large dragon, chaotic evil",
			"18 (natural armor)",
			"40 ft., climb 40 ft., fly 80 ft.",
			"Dex +4, Con +9, Wis +4, Cha +8",
			"Perception +8, Stealth +4",
			"",
			"",
			"fire",
			"",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 18",
			"Common, Draconic",
			"",
			"***Multiattack.*** The dragon makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 17 (2d10 + 6) piercing damage plus 3 (1d6) fire damage.\n\n***Claw.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 13 (2d6 + 6) slashing damage.\n\n***Fire Breath (Recharge 5–6).*** The dragon exhales fire in a 30-foot cone. Each creature in that area must make a DC 17 Dexterity saving throw, taking 56 (16d6) fire damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
