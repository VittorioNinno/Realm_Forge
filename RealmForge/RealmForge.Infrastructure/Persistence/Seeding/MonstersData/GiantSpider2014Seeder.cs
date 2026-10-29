using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Giant Spider (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GiantSpider2014Seeder
{
	public static Monster Build() => Create("giant-spider", null, CreatureSize.Large, CreatureType.Beast,
		14, 26, "4d10 + 4", 30, new[] { 14, 16, 12, 2, 11, 4 }, 1m, 200, 2, 10,
		new Text(
			"Ragno gigante",
			null,
			"Bestia Grande, senza allineamento",
			"14 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"Furtività +7",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m, vista cieca 3 m",
			"—",
			"***Arrampicatele.*** Il ragno ignora le restrizioni di movimento causate dalle ragnatele.\n\n***Movimenti del ragno.*** Il ragno può scalare le superfici difficili, compresi i soffitti (lungo i quali si muove a testa in giù), senza effettuare una prova di caratteristica.\n\n***Percezione della Ragnatela.*** Finché è in contatto con una ragnatela, il ragno conosce l'ubicazione esatta di ogni altra creatura a contatto con la stessa ragnatela.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 7 (1d8 + 3) danni perforanti e il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 11, subendo 9 (2d8) danni da veleno in caso di fallimento, o la metà in caso di successo. Se i danni da veleno riducono i punti ferita del bersaglio a 0, esso è stabile ma avvelenato per 1 ora anche dopo aver recuperato punti ferita e, mentre è avvelenato in questo modo, è paralizzato.\n\n***Ragnatela (ricarica 5–6).*** *Attacco con arma a distanza:* +5 al tiro per colpire, gittata 9/18 m, una creatura. *Colpito:* il bersaglio è trattenuto dalle ragnatele. Con un'azione, il bersaglio trattenuto può effettuare una prova di Forza con CD 12. Se la supera, strappa le ragnatele. La ragnatela può anche essere attaccata e distrutta (CA 10; 5 punti ferita; vulnerabilità ai danni da fuoco; immunità ai danni contundenti, da veleno e psichici).",
			"",
			""),
		new Text(
			"Giant Spider",
			null,
			"Large beast, unaligned",
			"14 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"Stealth +7",
			"",
			"",
			"",
			"",
			"blindsight 10 ft., darkvision 60 ft., passive Perception 10",
			"—",
			"***Spider Climb.*** The spider can climb difficult surfaces, including upside down on ceilings, without needing to make an ability check.\n\n***Web Sense.*** While in contact with a web, the spider knows the exact location of any other creature in contact with the same web.\n\n***Web Walker.*** The spider ignores movement restrictions caused by webbing.",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* 7 (1d8 + 3) piercing damage, and the target must make a DC 11 Constitution saving throw, taking 9 (2d8) poison damage on a failed save, or half as much damage on a successful one. If the poison damage reduces the target to 0 hit points, the target is stable but poisoned for 1 hour, even after regaining hit points, and is paralyzed while poisoned in this way.\n\n***Web (Recharge 5–6).*** *Ranged Weapon Attack:* +5 to hit, range 30/60 ft., one creature. *Hit:* The target is restrained by webbing. As an action, the restrained target can make a DC 12 Strength check, bursting the webbing on a success. The webbing can also be attacked and destroyed (AC 10; hp 5; vulnerability to fire damage; immunity to bludgeoning, poison, and psychic damage).",
			"",
			""));
}
