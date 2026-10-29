using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Toad (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantToad2014Seeder
{
	public static Monster Build() => Create("giant-toad", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		11, 39, "6d10 + 6", 20, new[] { 15, 13, 13, 2, 10, 3 }, 1m, 200, 2, 10,
		new Text(
			"Rospo gigante",
			null,
			"Bestia Grande, senza allineamento",
			"11",
			"6 m, nuotare 12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 9 m",
			"—",
			"***Anfibio.*** Il rospo può respirare in aria e in acqua.\n\n***Balzo da fermo.*** Il rospo può compiere un salto in lungo di massimo 6 metri e uno in alto di massimo 3 metri, con o senza rincorsa.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d10 + 2) danni perforanti più 5 (1d10) danni da veleno e il bersaglio è afferrato (CD 13 per sfuggire). Finché la presa perdura, il bersaglio viene trattenuto e il rospo non può morderne un altro.\n\n***Inghiottire.*** Il rospo effettua un attacco con il morso contro un bersaglio di taglia Media o inferiore con cui stia lottando. Se l'attacco va a segno, il bersaglio viene inghiottito e la lotta termina. Mentre è inghiottito, il bersaglio è accecato e trattenuto, beneficia di copertura totale contro gli attacchi e altri effetti al di fuori del rospo e subisce 10 (3d6) danni da acido all'inizio di ogni turno dell'animale, che può inghiottire soltanto un bersaglio alla volta. Se il rospo muore, la creatura inghiottita non è più trattenuta dalla bestia e può sfuggire usando 1,5 metri di movimento, uscendo prona dal cadavere.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Toad",
			null,
			"Large beast, unaligned",
			"11",
			"20 ft., swim 40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 30 ft., passive Perception 10",
			"—",
			"***Amphibious.*** The toad can breathe air and water\n\n***Standing Leap.*** The toad's long jump is up to 20 ft. and its high jump is up to 10 ft., with or without a running start.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (1d10 + 2) piercing damage plus 5 (1d10) poison damage, and the target is grappled (escape DC 13). Until this grapple ends, the target is restrained, and the toad can't bite another target.\n\n***Swallow.*** The toad makes one bite attack against a Medium or smaller target it is grappling. If the attack hits, the target is swallowed, and the grapple ends. The swallowed target is blinded and restrained, it has total cover against attacks and other effects outside the toad, and it takes 10 (3d6) acid damage at the start of each of the toad's turns. The toad can have only one target swallowed at a time.\n\nIf the toad dies, a swallowed creature is no longer restrained by it and can escape from the corpse using 5 feet of movement, exiting prone.",
			"",
			"",
			"",
			""));
}
