using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Stirge (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Stirge2014Seeder
{
	public static Monster Build() => Create("stirge", null, ContentSource.Srd51, CreatureSize.Tiny, CreatureType.Beast,
		14, 2, "1d4", 10, new[] { 4, 16, 11, 2, 8, 6 }, 0.125m, 25, 2, 9,
		new Text(
			"Uccello stigeo",
			null,
			"Bestia Minuscola, senza allineamento",
			"14 (armatura naturale)",
			"3 m, volare 12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 9, scurovisione 18 m",
			"—",
			"",
			"***Risucchio di sangue.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 5 (1d4 + 3) danni perforanti e l'uccello stigeo si avvinghia al bersaglio. Finché è avvinghiato, l'uccello stigeo non attacca. All'inizio di ogni turno del mostro, il bersaglio perde 5 (1d4 + 3) punti ferita a causa del dissanguamento. L'uccello stigeo può staccarsi da solo utilizzando 1,5 metri del suo movimento. Lo fa dopo aver risucchiato 10 punti ferita di sangue dal bersaglio o se il bersaglio muore. Una creatura, incluso il bersaglio, può usare la sua azione per staccare l'essere.",
			"",
			"",
			"",
			""),
		new Text(
			"Stirge",
			null,
			"Tiny beast, unaligned",
			"14 (natural armor)",
			"10 ft., fly 40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 9",
			"—",
			"",
			"***Blood Drain.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* 5 (1d4 + 3) piercing damage, and the stirge attaches to the target. While attached, the stirge doesn't attack. Instead, at the start of each of the stirge's turns, the target loses 5 (1d4 + 3) hit points due to blood loss.\n\nThe stirge can detach itself by spending 5 feet of its movement. It does so after it drains 10 hit points of blood from the target or the target dies. A creature, including the target, can use its action to detach the stirge.",
			"",
			"",
			"",
			""));
}
