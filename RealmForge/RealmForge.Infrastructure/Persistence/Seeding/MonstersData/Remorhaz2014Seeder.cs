using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Remorhaz (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Remorhaz2014Seeder
{
	public static Monster Build() => Create("remorhaz", null, CreatureSize.Huge, CreatureType.Monstrosity,
		17, 195, "17d12 + 85", 30, new[] { 24, 13, 21, 4, 10, 5 }, 11m, 7200, 4, 10,
		new Text(
			"Remorhaz",
			null,
			"Mostruosità Enorme, senza allineamento",
			"17 (armatura naturale)",
			"9 m, scavare 6 m",
			"",
			"",
			"",
			"",
			"freddo, fuoco",
			"",
			"Percezione passiva 10, percezione tellurica 18 m, scurovisione 18 m",
			"—",
			"***Corpo surriscaldato.*** Una creatura che tocchi il remorhaz o lo colpisca con un attacco in mischia mentre si trova entro 1,5 metri da lui subisce 10 (3d6) danni da fuoco.",
			"***Morso.*** *Attacco con arma da mischia:* +11 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 40 (6d10 + 7) danni perforanti più 10 (3d6) danni da fuoco. Se il bersaglio è una creatura, viene afferrato (CD 17 per sfuggire). Finché la presa perdura, il bersaglio viene trattenuto e il remorhaz non può morderne un altro.\n\n***Inghiottire.*** Il remorhaz effettua un attacco con il morso contro una creatura di taglia Media o inferiore con cui sta lottando. Se l'attacco va a segno, la creatura subisce i danni del morso e viene inghiottita, ma la lotta termina. Mentre è inghiottita, la creatura è accecata e trattenuta, beneficia di copertura totale contro gli attacchi e altri effetti al di fuori del remorhaz e subisce 21 (6d6) danni da acido all'inizio di ogni turno del mostro. Se il remorhaz subisce 30 o più danni in un singolo turno da una creatura al suo interno, deve superare un tiro salvezza su Costituzione con CD 15 alla fine di quel turno, altrimenti rigurgita tutte le creature inghiottite, che cadono a terra prone in uno spazio entro 3 metri da lui. Se il remorhaz muore, la creatura inghiottita non è più trattenuta dal mostro e può sfuggire usando 4,5 metri di movimento, uscendo prona dal mostro.",
			"",
			""),
		new Text(
			"Remorhaz",
			null,
			"Huge monstrosity, unaligned",
			"17 (natural armor)",
			"30 ft., burrow 20 ft.",
			"",
			"",
			"",
			"",
			"cold, fire",
			"",
			"darkvision 60 ft., tremorsense 60 ft., passive Perception 10",
			"—",
			"***Heated Body.*** A creature that touches the remorhaz or hits it with a melee attack while within 5 feet of it takes 10 (3d6) fire damage.",
			"***Bite.*** *Melee Weapon Attack:* +11 to hit, reach 10 ft., one target. *Hit:* 40 (6d10 + 7) piercing damage plus 10 (3d6) fire damage. If the target is a creature, it is grappled (escape DC 17). Until this grapple ends, the target is restrained, and the remorhaz can't bite another target.\n\n***Swallow.*** The remorhaz makes one bite attack against a Medium or smaller creature it is grappling. If the attack hits, that creature takes the bite's damage and is swallowed, and the grapple ends. While swallowed, the creature is blinded and restrained, it has total cover against attacks and other effects outside the remorhaz, and it takes 21 (6d6) acid damage at the start of each of the remorhaz's turns.\n\nIf the remorhaz takes 30 damage or more on a single turn from a creature inside it, the remorhaz must succeed on a DC 15 Constitution saving throw at the end of that turn or regurgitate all swallowed creatures, which fall prone in a space within 10 feet of the remorhaz. If the remorhaz dies, a swallowed creature is no longer restrained by it and can escape from the corpse using 15 feet of movement, exiting prone.",
			"",
			""));
}
