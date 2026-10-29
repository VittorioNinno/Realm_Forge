using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Spider (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Spider2014Seeder
{
	public static Monster Build() => Create("spider", null, ContentSource.Srd51, CreatureSize.Tiny, CreatureType.Beast,
		12, 1, "1d4 - 1", 20, new[] { 2, 14, 8, 1, 10, 2 }, 0m, 10, 2, 10,
		new Text(
			"Ragno",
			null,
			"Bestia Minuscola, senza allineamento",
			"12",
			"6 m, scalare 6 m",
			"",
			"Furtività +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 9 m",
			"—",
			"***Arrampicatele.*** Il ragno ignora le restrizioni di movimento causate dalle ragnatele.\n\n***Movimenti del ragno.*** Il ragno può scalare le superfici difficili, compresi i soffitti (lungo i quali si muove a testa in giù), senza effettuare una prova di caratteristica.\n\n***Percezione della Ragnatela.*** Finché è in contatto con una ragnatela, il ragno conosce l'ubicazione esatta di ogni altra creatura a contatto con la stessa ragnatela.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 1 danno perforante e il bersaglio deve superare un tiro salvezza su Costituzione con CD 9, altrimenti subisce 2 (1d4) danni da veleno.",
			"",
			"",
			"",
			""),
		new Text(
			"Spider",
			null,
			"Tiny beast, unaligned",
			"12",
			"20 ft., climb 20 ft.",
			"",
			"Stealth +4",
			"",
			"",
			"",
			"",
			"darkvision 30 ft., passive Perception 10",
			"—",
			"***Spider Climb.*** The spider can climb difficult surfaces, including upside down on ceilings, without needing to make an ability check.\n\n***Web Sense.*** While in contact with a web, the spider knows the exact location of any other creature in contact with the same web.\n\n***Web Walker.*** The spider ignores movement restrictions caused by webbing.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 1 piercing damage, and the target must succeed on a DC 9 Constitution saving throw or take 2 (1d4) poison damage.",
			"",
			"",
			"",
			""));
}
