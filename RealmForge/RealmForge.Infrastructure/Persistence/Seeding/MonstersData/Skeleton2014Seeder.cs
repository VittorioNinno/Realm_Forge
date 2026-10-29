using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Skeleton (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Skeleton2014Seeder
{
	public static Monster Build() => Create("skeleton", null, CreatureSize.Medium, CreatureType.Undead,
		13, 13, "2d8 + 4", 30, new[] { 10, 14, 15, 6, 8, 5 }, 0.25m, 50, 2, 9,
		new Text(
			"Scheletro",
			null,
			"Non morto Medio, legale malvagio",
			"13 (frammenti di armatura)",
			"9 m",
			"",
			"",
			"contundenti",
			"",
			"veleno",
			"avvelenato, indebolimento",
			"Percezione passiva 9, scurovisione 18 m",
			"capisce quelli che conosceva in vita, ma non è in grado di parlarli",
			"",
			"***Spada corta.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.\n\n***Arco corto.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 24/96 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			""),
		new Text(
			"Skeleton",
			null,
			"Medium undead, lawful evil",
			"13",
			"30 ft.",
			"",
			"",
			"bludgeoning",
			"",
			"poison",
			"poisoned, exhaustion",
			"darkvision 60 ft., passive Perception 9",
			"understands all languages it spoke in life but can't speak",
			"",
			"***Shortsword.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Shortbow.*** *Ranged Weapon Attack:* +4 to hit, range 80/320 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.",
			"",
			""));
}
