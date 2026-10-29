using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Wolf Spider (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantWolfSpider2014Seeder
{
	public static Monster Build() => Create("giant-wolf-spider", null, CreatureSize.Medium, CreatureType.Beast,
		13, 11, "2d8 + 2", 40, new[] { 12, 16, 13, 3, 12, 4 }, 0.25m, 50, 2, 13,
		new Text(
			"Ragno lupo gigante",
			null,
			"Bestia Media, senza allineamento",
			"13",
			"12 m, scalare 12 m",
			"",
			"Furtività +7, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, scurovisione 18 m, vista cieca 3 m",
			"—",
			"***Arrampicatele.*** Il ragno ignora le restrizioni di movimento causate dalle ragnatele.\n\n***Movimenti del ragno.*** Il ragno può scalare le superfici difficili, compresi i soffitti (lungo i quali si muove a testa in giù), senza effettuare una prova di caratteristica.\n\n***Percezione della Ragnatela.*** Finché è in contatto con una ragnatela, il ragno conosce l'ubicazione esatta di ogni altra creatura a contatto con la stessa ragnatela.",
			"***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 4 (1d6 + 1) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 11 subendo 7 (2d6) danni da veleno in caso di fallimento, o la metà in caso di successo. Se i danni da veleno riducono i punti ferita del bersaglio a 0, esso è stabile ma avvelenato per 1 ora anche dopo aver recuperato punti ferita e, mentre è avvelenato in questo modo, è paralizzato.",
			"",
			""),
		new Text(
			"Giant Wolf Spider",
			null,
			"Medium beast, unaligned",
			"13",
			"40 ft., climb 40 ft.",
			"",
			"Perception +3, Stealth +7",
			"",
			"",
			"",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 13",
			"—",
			"***Spider Climb.*** The spider can climb difficult surfaces, including upside down on ceilings, without needing to make an ability check.\n\n***Web Sense.*** While in contact with a web, the spider knows the exact location of any other creature in contact with the same web.\n\n***Web Walker.*** The spider ignores movement restrictions caused by webbing.",
			"***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one creature. *Hit:* 4 (1d6 + 1) piercing damage, and the target must make a DC 11 Constitution saving throw, taking 7 (2d6) poison damage on a failed save, or half as much damage on a successful one. If the poison damage reduces the target to 0 hit points, the target is stable but poisoned for 1 hour, even after regaining hit points, and is paralyzed while poisoned in this way.",
			"",
			""));
}
