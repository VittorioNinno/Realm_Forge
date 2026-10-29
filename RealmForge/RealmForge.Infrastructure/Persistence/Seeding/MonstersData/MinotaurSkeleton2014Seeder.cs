using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Minotaur Skeleton (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class MinotaurSkeleton2014Seeder
{
	public static Monster Build() => Create("minotaur-skeleton", null, CreatureSize.Large, CreatureType.Undead,
		12, 67, "9d10 + 18", 40, new[] { 18, 11, 15, 6, 8, 5 }, 2m, 450, 2, 9,
		new Text(
			"Scheletro di minotauro",
			"Scheletro minotauro",
			"Non morto Grande, legale malvagio",
			"12 (armatura naturale)",
			"12 m",
			"",
			"",
			"contundenti",
			"",
			"veleno",
			"avvelenato, indebolimento",
			"Percezione passiva 9, scurovisione 18 m",
			"capisce l'Abissale ma non lo parla",
			"***Carica.*** Se lo scheletro si muove di almeno 3 metri in linea retta verso un bersaglio e poi lo colpisce con un'incornata nello stesso turno, la vittima subisce 9 (2d8) danni perforanti extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 14, altrimenti viene scagliato a 3 metri di distanza e buttato a terra prono.",
			"***Ascia bipenne.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 17 (2d12 + 4) danni taglienti.\n\n***Incornata.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni perforanti.",
			"",
			""),
		new Text(
			"Minotaur Skeleton",
			null,
			"Large undead, lawful evil",
			"12 (natural armor)",
			"40 ft.",
			"",
			"",
			"bludgeoning",
			"",
			"poison",
			"exhaustion, poisoned",
			"darkvision 60 ft., passive Perception 9",
			"understands Abyssal but can't speak",
			"***Charge.*** If the skeleton moves at least 10 feet straight toward a target and then hits it with a gore attack on the same turn, the target takes an extra 9 (2d8) piercing damage. If the target is a creature, it must succeed on a DC 14 Strength saving throw or be pushed up to 10 feet away and knocked prone.",
			"***Greataxe.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 17 (2d12 + 4) slashing damage.\n\n***Gore.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) piercing damage.",
			"",
			""));
}
