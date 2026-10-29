using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Behir (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Behir2014Seeder
{
	public static Monster Build() => Create("behir", null, CreatureSize.Huge, CreatureType.Monstrosity,
		17, 168, "16d12 + 64", 50, new[] { 23, 16, 18, 7, 14, 12 }, 11m, 7200, 4, 16,
		new Text(
			"Behir",
			null,
			"Mostruosità Enorme, neutrale malvagio",
			"17 (armatura naturale)",
			"15 m, scalare 12 m",
			"",
			"Furtività +7, Percezione +6",
			"",
			"",
			"fulmine",
			"",
			"Percezione passiva 16, scurovisione 27 m",
			"Draconico",
			"",
			"***Multiattacco.*** Il behir effettua due attacchi: uno con il morso e uno per stritolare.\n\n***Morso.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 22 (3d10 + 6) danni perforanti.\n\n***Stritolare.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, una creatura di taglia Grande o inferiore. *Colpito:* 17 (2d10 + 6) danni contundenti più 17 (2d10 + 6) danni taglienti. Il bersaglio è afferrato (CD 16 per sfuggire). Finché la presa perdura, il bersaglio è trattenuto e il behir non può stritolarne un altro.\n\n***Inghiottire.*** Il behir effettua un attacco con il morso contro una creatura di taglia Media o inferiore con cui sta lottando. Se l'attacco va a segno, il bersaglio viene anche inghiottito e la lotta termina. Mentre è inghiottito, il bersaglio è accecato e trattenuto, beneficia di copertura totale contro gli attacchi e altri effetti al di fuori del behir e subisce 21 (6d6) danni da acido all'inizio di ogni turno del behir, che può inghiottire soltanto una creatura alla volta. Se il behir subisce 30 o più danni in un singolo turno dalla creatura inghiottita, deve superare un tiro salvezza su Costituzione con CD 14 alla fine di quel turno, altrimenti rigurgita la creatura, che cade prona in uno spazio entro 3 metri dal behir. Se il behir muore, la creatura inghiottita non è più trattenuta dal mostro e può sfuggire usando 4,5 metri di movimento, uscendo prona dal mostro.\n\n***Soffio di fulmini (ricarica 5–6).*** Il behir esala una scarica di fulmini lunga 6 metri e larga 1,5 metri. Ogni creatura su quella linea deve effettuare un tiro salvezza su Destrezza con CD 16, subendo 66 (12d10) danni da fulmine in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"Behir",
			null,
			"Huge monstrosity, neutral evil",
			"17 (natural armor)",
			"50 ft., climb 40 ft.",
			"",
			"Perception +6, Stealth +7",
			"",
			"",
			"lightning",
			"",
			"darkvision 90 ft., passive Perception 16",
			"Draconic",
			"",
			"***Multiattack.*** The behir makes two attacks: one with its bite and one to constrict.\n\n***Bite.*** *Melee Weapon Attack:* +10 to hit, reach 10 ft., one target. *Hit:* 22 (3d10 + 6) piercing damage.\n\n***Constrict.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one Large or smaller creature. *Hit:* 17 (2d10 + 6) bludgeoning damage plus 17 (2d10 + 6) slashing damage. The target is grappled (escape DC 16) if the behir isn't already constricting a creature, and the target is restrained until this grapple ends.\n\n***Lightning Breath (Recharge 5–6).*** The behir exhales a line of lightning that is 20 ft. long and 5 ft. wide. Each creature in that line must make a DC 16 Dexterity saving throw, taking 66 (12d10) lightning damage on a failed save, or half as much damage on a successful one.\n\n***Swallow.*** The behir makes one bite attack against a Medium or smaller target it is grappling. If the attack hits, the target is also swallowed, and the grapple ends. While swallowed, the target is blinded and restrained, it has total cover against attacks and other effects outside the behir, and it takes 21 (6d6) acid damage at the start of each of the behir's turns. A behir can have only one creature swallowed at a time.\n\nIf the behir takes 30 damage or more on a single turn from the swallowed creature, the behir must succeed on a DC 14 Constitution saving throw at the end of that turn or regurgitate the creature, which falls prone in a space within 10 ft. of the behir. If the behir dies, a swallowed creature is no longer restrained by it and can escape from the corpse by using 15 ft. of movement, exiting prone.",
			"",
			""));
}
