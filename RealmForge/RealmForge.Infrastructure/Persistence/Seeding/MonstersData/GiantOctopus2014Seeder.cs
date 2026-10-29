using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Octopus (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantOctopus2014Seeder
{
	public static Monster Build() => Create("giant-octopus", null, CreatureSize.Large, CreatureType.Beast,
		11, 52, "8d10 + 8", 10, new[] { 17, 13, 13, 4, 10, 4 }, 1m, 200, 2, 14,
		new Text(
			"Piovra gigante",
			null,
			"Bestia Grande, senza allineamento",
			"11",
			"3 m, nuotare 18 m",
			"",
			"Furtività +5, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 18 m",
			"—",
			"***Apnea.*** Mentre è fuori dall'acqua, la piovra può trattenere il respiro per 1 ora.\n\n***Mimetismo acquatico.*** La piovra dispone di vantaggio alle prove di Destrezza (Furtività) effettuate sott'acqua.\n\n***Respirare sott'acqua.*** La piovra può respirare soltanto sott'acqua.",
			"***Tentacoli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni contundenti. Se il bersaglio è una creatura, viene afferrato (CD 16 per sfuggire). Finché la presa perdura, il bersaglio viene trattenuto e la piovra non può usare i suoi tentacoli su altri.\n\n***Nube di inchiostro (ricarica dopo un riposo breve o lungo).*** Una nube di inchiostro del raggio di 6 metri si diffonde tutt'intorno alla piovra, se quest'ultima si trova sott'acqua. L'area è pesantemente oscurata per 1 minuto, ma una corrente molto intensa può disperdere l'inchiostro. Dopo avere emesso tale sostanza, la piovra può usare l'azione di Scatto come azione bonus.",
			"",
			""),
		new Text(
			"Giant Octopus",
			null,
			"Large beast, unaligned",
			"11",
			"10 ft., swim 60 ft.",
			"",
			"Perception +4, Stealth +5",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 14",
			"—",
			"***Hold Breath.*** While out of water, the octopus can hold its breath for 1 hour.\n\n***Underwater Camouflage.*** The octopus has advantage on Dexterity (Stealth) checks made while underwater.\n\n***Water Breathing.*** The octopus can breathe only underwater.",
			"***Tentacles.*** *Melee Weapon Attack:* +5 to hit, reach 15 ft., one target. *Hit:* 10 (2d6 + 3) bludgeoning damage. If the target is a creature, it is grappled (escape DC 16). Until this grapple ends, the target is restrained, and the octopus can't use its tentacles on another target.\n\n***Ink Cloud (Recharges after a Short or Long Rest).*** A 20-foot-radius cloud of ink extends all around the octopus if it is underwater. The area is heavily obscured for 1 minute, although a significant current can disperse the ink. After releasing the ink, the octopus can use the Dash action as a bonus action.",
			"",
			""));
}
