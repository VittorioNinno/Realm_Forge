using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Barlgura (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Barlgura2014Seeder
{
	public static Monster Build() => Create("barlgura", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Fiend,
		15, 68, "8d10 + 24", 30, new[] { 18, 15, 16, 7, 14, 9 }, 5m, 1800, 3, 15,
		new Text(
			"Barigura",
			null,
			"Immondo Grande (demone), caotico malvagio",
			"15 (armatura naturale)",
			"9 m, scalare 9 m",
			"Cos +6, Des +5",
			"Furtività +5, Percezione +5",
			"",
			"freddo, fuoco, fulmine",
			"veleno",
			"avvelenato",
			"Percezione passiva 15, scurovisione 36 m, vista cieca 9 m",
			"Abissale, telepatia 36 m",
			"***Incantesimi innati.*** La barigura lancia per natura gli incantesimi seguenti usando la Saggezza (CD del tiro salvezza sull'incantesimo 13), senza bisogno di componenti materiali:\n\n- 1/giorno ciascuno: *intralciare*, *allucinazione di forza*\n- 2/giorno ciascuno: *camuffare se stesso*, *invisibilità* (solo su se stessa)\n\n***Avventatezza.*** All'inizio del suo turno, la barigura può scegliere di disporre di vantaggio ai suoi tiri per colpire con armi da mischia in quel turno; in tal caso i tiri per colpire contro di lei dispongono di vantaggio fino all'inizio del suo turno successivo.\n\n***Salto con rincorsa.*** Con la rincorsa, la barigura può saltare fino a 12 metri in lungo e fino a 6 metri in alto.",
			"***Multiattacco.*** La barigura effettua tre attacchi: uno con il morso e due con i pugni.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni perforanti.\n\n***Pugno.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (1d10 + 4) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Barlgura",
			null,
			"Large fiend (demon), chaotic evil",
			"15 (natural armor)",
			"30 ft., climb 30 ft.",
			"Dex +5, Con +6",
			"Perception +5, Stealth +5",
			"",
			"cold, fire, lightning",
			"poison",
			"poisoned",
			"blindsight 30 ft., darkvision 120 ft., passive Perception 15",
			"Abyssal, telepathy 120 ft.",
			"***Innate Spellcasting.*** The barlgura casts the following spells innately, using Wisdom (spell save DC 13) and needing no material components:\n\n- 1/day each: *entangle*, *phantasmal force*\n- 2/day each: *disguise self*, *invisibility* (self only)\n\n***Reckless.*** At the start of its turn, the barlgura can choose to have advantage on its melee weapon attack rolls that turn; if it does, attack rolls against it have advantage until the start of its next turn.\n\n***Running Leap.*** With a run-up, the barlgura can long jump up to 40 feet and high jump up to 20 feet.",
			"***Multiattack.*** The barlgura makes three attacks: a bite and two fist attacks.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) piercing damage.\n\n***Fist.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 9 (1d10 + 4) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
