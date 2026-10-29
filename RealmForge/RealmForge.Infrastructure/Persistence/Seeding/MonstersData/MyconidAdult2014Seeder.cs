using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Myconid Adult (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class MyconidAdult2014Seeder
{
	public static Monster Build() => Create("myconid-adult", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Plant,
		12, 22, "4d8 + 4", 20, new[] { 10, 10, 12, 10, 13, 7 }, 0.5m, 100, 2, 11,
		new Text(
			"Miconide adulto",
			null,
			"Vegetale Medio, legale neutrale",
			"12 (armatura naturale)",
			"6 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 36 m",
			"—",
			"***Spore di allarme.*** Quando il miconide subisce danni, ogni altro miconide entro 72 metri da lui ne avverte il dolore.\n\n***Malattia del sole.*** Alla luce del sole, il miconide subisce svantaggio alle prove di caratteristica, ai tiri per colpire e ai tiri salvezza; muore se trascorre più di 1 ora alla luce diretta del sole.",
			"***Pugno.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (2d4) danni contundenti più 5 (2d4) danni da veleno.\n\n***Spore pacificanti (3/giorno).*** Il miconide spruzza spore contro una creatura che è in grado di vedere entro 1,5 metri da lui, che effettua un tiro salvezza su Costituzione con CD 11, altrimenti è stordita per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.\n\n***Spore di intesa.*** Il miconide rilascia spore in un raggio di 6 metri attorno a sé; le spore si propagano oltre gli angoli e agiscono solo sulle creature con Intelligenza 2 o superiore che non siano non morti, costrutti o elementali. Per 1 ora, quelle creature possono comunicare telepaticamente tra loro finché si trovano entro 9 metri l'una dall'altra.",
			"",
			"",
			"",
			""),
		new Text(
			"Myconid Adult",
			null,
			"Medium plant, lawful neutral",
			"12 (natural armor)",
			"20 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 11",
			"—",
			"***Distress Spores.*** When the myconid takes damage, every other myconid within 240 feet of it feels its pain.\n\n***Sun Sickness.*** In sunlight, the myconid has disadvantage on ability checks, attack rolls and saving throws; it dies after spending more than 1 hour in direct sunlight.",
			"***Fist.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 5 (2d4) bludgeoning damage plus 5 (2d4) poison damage.\n\n***Pacifying Spores (3/Day).*** The myconid sprays spores at a creature it can see within 5 feet of it, which makes a DC 11 Constitution saving throw or is stunned for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success.\n\n***Rapport Spores.*** The myconid releases spores in a 20-foot radius around it; they spread around corners and affect only creatures with Intelligence 2 or higher that aren't undead, constructs or elementals. For 1 hour, those creatures can talk telepathically with each other while within 30 feet of one another.",
			"",
			"",
			"",
			""));
}
