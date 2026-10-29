using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Myconid Sprout (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class MyconidSprout2014Seeder
{
	public static Monster Build() => Create("myconid-sprout", null, ContentSource.RealmForge, CreatureSize.Small, CreatureType.Plant,
		10, 7, "2d6", 10, new[] { 8, 10, 10, 8, 11, 5 }, 0m, 10, 2, 10,
		new Text(
			"Miconide germoglio",
			null,
			"Vegetale Piccolo, legale neutrale",
			"10",
			"3 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 36 m",
			"—",
			"***Spore di allarme.*** Quando il miconide subisce danni, ogni altro miconide entro 72 metri da lui ne avverte il dolore.\n\n***Malattia del sole.*** Alla luce del sole, il miconide subisce svantaggio alle prove di caratteristica, ai tiri per colpire e ai tiri salvezza; muore se trascorre più di 1 ora alla luce diretta del sole.",
			"***Pugno.*** *Attacco con arma da mischia:* +1 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 (1d4 - 1) danni contundenti più 2 (1d4) danni da veleno.\n\n***Spore di intesa (3/giorno).*** Il miconide rilascia spore in un raggio di 3 metri attorno a sé; le spore si propagano oltre gli angoli e agiscono solo sulle creature con Intelligenza 2 o superiore che non siano non morti, costrutti o elementali. Per 1 ora, quelle creature possono comunicare telepaticamente tra loro finché si trovano entro 9 metri l'una dall'altra.",
			"",
			"",
			"",
			""),
		new Text(
			"Myconid Sprout",
			null,
			"Small plant, lawful neutral",
			"10",
			"10 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 10",
			"—",
			"***Distress Spores.*** When the myconid takes damage, every other myconid within 240 feet of it feels its pain.\n\n***Sun Sickness.*** In sunlight, the myconid has disadvantage on ability checks, attack rolls and saving throws; it dies after spending more than 1 hour in direct sunlight.",
			"***Fist.*** *Melee Weapon Attack:* +1 to hit, reach 5 ft., one target. *Hit:* 1 (1d4 - 1) bludgeoning damage plus 2 (1d4) poison damage.\n\n***Rapport Spores (3/Day).*** The myconid releases spores in a 10-foot radius around it; they spread around corners and affect only creatures with Intelligence 2 or higher that aren't undead, constructs or elementals. For 1 hour, those creatures can talk telepathically with each other while within 30 feet of one another.",
			"",
			"",
			"",
			""));
}
