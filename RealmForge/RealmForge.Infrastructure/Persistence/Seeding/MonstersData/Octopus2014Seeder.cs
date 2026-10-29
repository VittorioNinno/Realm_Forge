using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Octopus (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Octopus2014Seeder
{
	public static Monster Build() => Create("octopus", null, CreatureSize.Small, CreatureType.Beast,
		12, 3, "1d6", 5, new[] { 4, 15, 11, 3, 10, 4 }, 0m, 10, 2, 12,
		new Text(
			"Piovra",
			null,
			"Bestia Piccola, senza allineamento",
			"12",
			"1,5 m, nuotare 9 m",
			"",
			"Furtività +4, Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, scurovisione 9 m",
			"—",
			"***Apnea.*** Mentre è fuori dall'acqua, la piova può trattenere il respiro per 30 minuti.\n\n***Mimetismo acquatico.*** La piovra dispone di vantaggio alle prove di Destrezza (Furtività) effettuate sott'acqua.\n\n***Respirare sott'acqua.*** La piovra può respirare soltanto sott'acqua.",
			"***Tentacoli.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 danno contundente e il bersaglio è afferrato (CD 10 per sfuggire). Finché la presa perdura, la piovra non può usare i suoi tentacoli su altri.\n\n***Nube di inchiostro (ricarica dopo un riposo breve o lungo).*** Una nube di inchiostro del raggio di 1,5 metri si diffonde tutt'intorno alla piovra se quest'ultima si trova sott'acqua. L'area è pesantemente oscurata per 1 minuto, ma una corrente molto intensa può disperdere l'inchiostro. Dopo avere emesso tale sostanza, la piovra può usare l'azione di Scatto come azione bonus.",
			"",
			""),
		new Text(
			"Octopus",
			null,
			"Small beast, unaligned",
			"12",
			"5 ft., swim 30 ft.",
			"",
			"Perception +2, Stealth +4",
			"",
			"",
			"",
			"",
			"darkvision 30 ft., passive Perception 12",
			"—",
			"***Hold Breath.*** While out of water, the octopus can hold its breath for 30 minutes.\n\n***Underwater Camouflage.*** The octopus has advantage on Dexterity (Stealth) checks made while underwater.\n\n***Water Breathing.*** The octopus can breathe only underwater.",
			"***Tentacles.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 1 bludgeoning damage, and the target is grappled (escape DC 10). Until this grapple ends, the octopus can't use its tentacles on another target.\n\n***Ink Cloud (Recharges after a Short or Long Rest).*** A 5-foot-radius cloud of ink extends all around the octopus if it is underwater. The area is heavily obscured for 1 minute, although a significant current can disperse the ink. After releasing the ink, the octopus can use the Dash action as a bonus action.",
			"",
			""));
}
