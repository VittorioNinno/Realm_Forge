using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Frog (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantFrog2014Seeder
{
	public static Monster Build() => Create("giant-frog", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		11, 18, "4d8", 30, new[] { 12, 13, 11, 2, 10, 3 }, 0.25m, 50, 2, 12,
		new Text(
			"Rana gigante",
			null,
			"Bestia Media, senza allineamento",
			"11",
			"9 m, nuotare 9 m",
			"",
			"Furtività +3, Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, scurovisione 9 m",
			"—",
			"***Anfibio.*** La rana può respirare in aria e in acqua.\n\n***Balzo da fermo.*** La rana può compiere un salto in lungo di un massimo di 6 metri e uno in alto di un massimo di 3 metri, con o senza rincorsa.",
			"***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti e il bersaglio è afferrato (CD 11 per sfuggire). Finché la presa perdura, il bersaglio viene trattenuto e la rana non può morderne un altro.\n\n***Inghiottire.*** La rana effettua un attacco con il morso contro un bersaglio di taglia Piccola o inferiore con cui sta lottando. Se l'attacco va a segno, il bersaglio viene inghiottito e la lotta termina. Mentre è inghiottito, il bersaglio è accecato e trattenuto, beneficia di copertura totale contro gli attacchi e altri effetti al di fuori della rana e subisce 5 (2d4) danni da acido all'inizio di ogni turno dell'animale, che può inghiottire soltanto un bersaglio alla volta. Se la rana muore, la creatura inghiottita non è più trattenuta dal mostro e può sfuggire usando 1,5 metri di movimento, uscendo prona dall'animale.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Frog",
			null,
			"Medium beast, unaligned",
			"11",
			"30 ft., swim 30 ft.",
			"",
			"Perception +2, Stealth +3",
			"",
			"",
			"",
			"",
			"darkvision 30 ft., passive Perception 12",
			"—",
			"***Amphibious.*** The frog can breathe air and water\n\n***Standing Leap.*** The frog's long jump is up to 20 ft. and its high jump is up to 10 ft., with or without a running start.",
			"***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage, and the target is grappled (escape DC 11). Until this grapple ends, the target is restrained, and the frog can't bite another target.\n\n***Swallow.*** The frog makes one bite attack against a Small or smaller target it is grappling. If the attack hits, the target is swallowed, and the grapple ends. The swallowed target is blinded and restrained, it has total cover against attacks and other effects outside the frog, and it takes 5 (2d4) acid damage at the start of each of the frog's turns. The frog can have only one target swallowed at a time. If the frog dies, a swallowed creature is no longer restrained by it and can escape from the corpse using 5 ft. of movement, exiting prone.",
			"",
			"",
			"",
			""));
}
