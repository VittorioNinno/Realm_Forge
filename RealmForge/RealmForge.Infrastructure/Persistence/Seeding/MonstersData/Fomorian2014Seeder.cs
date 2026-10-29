using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Fomorian (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Fomorian2014Seeder
{
	public static Monster Build() => Create("fomorian", null, ContentSource.RealmForge, CreatureSize.Huge, CreatureType.Giant,
		14, 149, "13d12 + 65", 30, new[] { 23, 10, 20, 9, 14, 6 }, 8m, 3900, 3, 18,
		new Text(
			"Fomorian",
			null,
			"Gigante Enorme, caotico malvagio",
			"14 (armatura naturale)",
			"9 m",
			"",
			"Furtività +3, Percezione +8",
			"",
			"",
			"",
			"",
			"Percezione passiva 18, scurovisione 36 m",
			"Gigante, Sottocomune",
			"",
			"***Multiattacco.*** Il fomorian effettua due attacchi con il randello pesante, oppure un attacco con il randello pesante e un uso di Malocchio.\n\n***Randello pesante.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 4,5 m, un bersaglio. *Colpito:* 19 (3d8 + 6) danni contundenti.\n\n***Malocchio.*** Con uno sguardo magico, il fomorian costringe una creatura che è in grado di vedere entro 18 metri da lui a effettuare un tiro salvezza su Carisma con CD 14; la creatura subisce 27 (6d8) danni psichici se lo fallisce, o la metà se lo supera.\n\n***Maledizione del malocchio (ricarica dopo un riposo breve o lungo).*** Il fomorian usa Malocchio; una creatura che fallisce il tiro salvezza è anche maledetta con deformità magiche. Finché è deforme, la sua velocità è dimezzata e subisce svantaggio alle prove di caratteristica, ai tiri salvezza e agli attacchi basati su Forza o Destrezza. Ripete il tiro salvezza ogni volta che completa un riposo lungo, e la maledizione termina con un successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Fomorian",
			null,
			"Huge giant, chaotic evil",
			"14 (natural armor)",
			"30 ft.",
			"",
			"Perception +8, Stealth +3",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 18",
			"Giant, Undercommon",
			"",
			"***Multiattack.*** The fomorian makes two greatclub attacks, or one greatclub attack and one use of Evil Eye.\n\n***Greatclub.*** *Melee Weapon Attack:* +9 to hit, reach 15 ft., one target. *Hit:* 19 (3d8 + 6) bludgeoning damage.\n\n***Evil Eye.*** With a magical glare, the fomorian forces a creature it can see within 60 feet of it to make a DC 14 Charisma saving throw, taking 27 (6d8) psychic damage on a failure, or half as much on a success.\n\n***Curse of the Evil Eye (Recharges after a Short or Long Rest).*** The fomorian uses Evil Eye; a creature that fails the save is also cursed with magical deformities. While deformed, its speed is halved and it has disadvantage on ability checks, saving throws and attacks based on Strength or Dexterity. It repeats the save each time it finishes a long rest, ending the curse on a success.",
			"",
			"",
			"",
			""));
}
