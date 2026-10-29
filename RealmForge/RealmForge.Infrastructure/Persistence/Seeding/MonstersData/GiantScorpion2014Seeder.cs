using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Scorpion (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantScorpion2014Seeder
{
	public static Monster Build() => Create("giant-scorpion", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Beast,
		15, 52, "7d10 + 14", 40, new[] { 15, 13, 15, 1, 9, 3 }, 3m, 700, 2, 9,
		new Text(
			"Scorpione gigante",
			null,
			"Bestia Grande, senza allineamento",
			"15 (armatura naturale)",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 9, vista cieca 18 m",
			"—",
			"",
			"***Multiattacco.*** Lo scorpione effettua tre attacchi: due con gli artigli e uno con il pungiglione.\n\n***Artiglio.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni contundenti e il bersaglio è afferrato (CD 12 per sfuggire). Lo scorpione ha due artigli, ognuno dei quali può afferrare un solo bersaglio.\n\n***Pungiglione.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 7 (1d10 + 2) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 12, subendo 22 (4d10) danni da veleno in caso di fallimento, o la metà in caso di successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Giant Scorpion",
			null,
			"Large beast, unaligned",
			"15 (natural armor)",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"blindsight 60 ft., passive Perception 9",
			"—",
			"",
			"***Claw.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 6 (1d8 + 2) bludgeoning damage, and the target is grappled (escape DC 12). The scorpion has two claws, each of which can grapple only one target.\n\n***Multiattack.*** The scorpion makes three attacks: two with its claws and one with its sting.\n\n***Sting.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 7 (1d10 + 2) piercing damage, and the target must make a DC 12 Constitution saving throw, taking 22 (4d10) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
