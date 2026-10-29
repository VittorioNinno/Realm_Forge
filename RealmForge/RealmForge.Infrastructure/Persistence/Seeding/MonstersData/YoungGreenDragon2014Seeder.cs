using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Young Green Dragon (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class YoungGreenDragon2014Seeder
{
	public static Monster Build() => Create("young-green-dragon", null, CreatureSize.Large, CreatureType.Dragon,
		18, 136, "16d10 + 48", 40, new[] { 19, 12, 17, 16, 13, 15 }, 8m, 3900, 3, 17,
		new Text(
			"Drago verde giovane",
			null,
			"Drago Grande, legale malvagio",
			"18 (armatura naturale)",
			"12 m, nuotare 12 m, volare 24 m",
			"Car +5, Cos +6, Des +4, Sag +4",
			"Furtività +4, Inganno +5, Percezione +7",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 17, scurovisione 36 m, vista cieca 9 m",
			"Comune, Draconico",
			"***Anfibio.*** Il drago può respirare in aria e in acqua.",
			"***Multiattacco.*** Il drago effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (2d10 + 4) danni perforanti più 7 (2d6) danni da veleno.\n\n***Soffio di veleno (ricarica 5–6).*** Il drago esala gas velenoso in un cono di 9 metri. Ogni creatura in quell'area deve effettuare un tiro salvezza su Costituzione con CD 14, subendo 42 (12d6) danni da veleno in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"Young Green Dragon",
			null,
			"Large dragon, lawful evil",
			"18 (natural armor)",
			"40 ft., fly 80 ft., swim 40 ft.",
			"Dex +4, Con +6, Wis +4, Cha +5",
			"Deception +5, Perception +7, Stealth +4",
			"",
			"",
			"poison",
			"poisoned",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 17",
			"Common, Draconic",
			"***Amphibious.*** The dragon can breathe air and water.",
			"***Multiattack.*** The dragon makes three attacks: one with its bite and two with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one target. *Hit:* 15 (2d10 + 4) piercing damage plus 7 (2d6) poison damage.\n\n***Claw.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.\n\n***Poison Breath (Recharge 5–6).*** The dragon exhales poisonous gas in a 30-foot cone. Each creature in that area must make a DC 14 Constitution saving throw, taking 42 (12d6) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
