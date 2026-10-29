using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Fire Snake (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class FireSnake2014Seeder
{
	public static Monster Build() => Create("fire-snake", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Elemental,
		14, 22, "5d8", 30, new[] { 12, 14, 11, 7, 10, 8 }, 1m, 200, 2, 10,
		new Text(
			"Serpente di fuoco",
			null,
			"Elementale Medio, neutrale malvagio",
			"14 (armatura naturale)",
			"9 m",
			"",
			"",
			"freddo",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"fuoco",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"capisce l'Ignan ma non lo parla",
			"***Corpo rovente.*** Una creatura che tocca il serpente, o che lo colpisce con un attacco in mischia trovandosi entro 1,5 metri da lui, subisce 3 (1d6) danni da fuoco.",
			"***Multiattacco.*** Il serpente effettua due attacchi: uno con il morso e uno con la coda.\n\n***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni perforanti più 3 (1d6) danni da fuoco.\n\n***Coda.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni contundenti più 3 (1d6) danni da fuoco.",
			"",
			"",
			"",
			"Un serpente di fuoco è una salamandra appena uscita dall'uovo; diventa adulta entro un anno."),
		new Text(
			"Fire Snake",
			null,
			"Medium elemental, neutral evil",
			"14 (natural armor)",
			"30 ft.",
			"",
			"",
			"cold",
			"bludgeoning, piercing, and slashing from nonmagical attacks",
			"fire",
			"",
			"darkvision 60 ft., passive Perception 10",
			"understands Ignan but can't speak",
			"***Heated Body.*** A creature that touches the snake, or hits it with a melee attack while within 5 feet of it, takes 3 (1d6) fire damage.",
			"***Multiattack.*** The snake makes two attacks: one with its bite and one with its tail.\n\n***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) piercing damage plus 3 (1d6) fire damage.\n\n***Tail.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) bludgeoning damage plus 3 (1d6) fire damage.",
			"",
			"",
			"",
			"A fire snake is a newly hatched salamander; it grows into an adult within a year."));
}
