using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Phase Spider (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class PhaseSpider2014Seeder
{
	public static Monster Build() => Create("phase-spider", null, CreatureSize.Large, CreatureType.Monstrosity,
		13, 32, "5d10 + 5", 30, new[] { 15, 15, 12, 6, 10, 6 }, 3m, 700, 2, 10,
		new Text(
			"Ragno-fase",
			null,
			"Mostruosità Grande, senza allineamento",
			"13 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"Furtività +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"—",
			"***Arrampicatele.*** Il ragno ignora le restrizioni di movimento causate dalle ragnatele.\n\n***Movimenti del ragno.*** Il ragno può scalare le superfici difficili, compresi i soffitti (lungo i quali si muove a testa in giù), senza effettuare una prova di caratteristica.\n\n***Transizione eterea.*** Come azione bonus, il ragno può spostarsi magicamente dal Piano Materiale al Piano Etereo o viceversa.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 7 (1d10 + 2) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 11, subendo 18 (4d8) danni da veleno in caso di fallimento, o la metà in caso di successo. Se i danni da veleno riducono i punti ferita del bersaglio a 0, esso è stabile ma avvelenato per 1 ora anche dopo aver recuperato punti ferita e, mentre è avvelenato in questo modo, è paralizzato.",
			"",
			""),
		new Text(
			"Phase Spider",
			null,
			"Large monstrosity, unaligned",
			"13 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"Stealth +6",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"—",
			"***Ethereal Jaunt.*** As a bonus action, the spider can magically shift from the Material Plane to the Ethereal Plane, or vice versa.\n\n***Spider Climb.*** The spider can climb difficult surfaces, including upside down on ceilings, without needing to make an ability check.\n\n***Web Walker.*** The spider ignores movement restrictions caused by webbing.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 7 (1d10 + 2) piercing damage, and the target must make a DC 11 Constitution saving throw, taking 18 (4d8) poison damage on a failed save, or half as much damage on a successful one. If the poison damage reduces the target to 0 hit points, the target is stable but poisoned for 1 hour, even after regaining hit points, and is paralyzed while poisoned in this way.",
			"",
			""));
}
