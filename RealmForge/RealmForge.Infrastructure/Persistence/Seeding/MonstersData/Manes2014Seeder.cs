using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Manes (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Manes2014Seeder
{
	public static Monster Build() => Create("manes", null, ContentSource.RealmForge, CreatureSize.Small, CreatureType.Fiend,
		9, 9, "2d6 + 2", 20, new[] { 10, 9, 13, 3, 8, 4 }, 0.125m, 25, 2, 9,
		new Text(
			"Mane",
			null,
			"Immondo Piccolo (demone), caotico malvagio",
			"9",
			"6 m",
			"",
			"",
			"",
			"freddo, fuoco, fulmine",
			"veleno",
			"affascinato, avvelenato, spaventato",
			"Percezione passiva 9, scurovisione 18 m",
			"capisce l'Abissale ma non lo parla",
			"",
			"***Artigli.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (2d4) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Manes",
			null,
			"Small fiend (demon), chaotic evil",
			"9",
			"20 ft.",
			"",
			"",
			"",
			"cold, fire, lightning",
			"poison",
			"charmed, frightened, poisoned",
			"darkvision 60 ft., passive Perception 9",
			"understands Abyssal but can't speak",
			"",
			"***Claws.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 5 (2d4) slashing damage.",
			"",
			"",
			"",
			""));
}
