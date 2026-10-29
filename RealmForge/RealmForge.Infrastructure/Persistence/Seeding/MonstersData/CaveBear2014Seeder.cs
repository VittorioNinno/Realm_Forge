using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Cave Bear (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class CaveBear2014Seeder
{
	public static Monster Build() => Create("cave-bear", "polar-bear", ContentSource.RealmForge, CreatureSize.Large, CreatureType.Beast,
		12, 42, "5d10 + 15", 40, new[] { 20, 10, 16, 2, 13, 7 }, 2m, 450, 2, 13,
		new Text(
			"Orso delle caverne",
			null,
			"Bestia Grande, senza allineamento",
			"12 (armatura naturale)",
			"12 m, nuotare 9 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, scurovisione 18 m",
			"—",
			"***Olfatto acuto.*** L'orso dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Multiattacco.*** L'orso effettua due attacchi: uno con il morso e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (1d8 + 5) danni perforanti.",
			"",
			"",
			"",
			"Gli orsi delle caverne si sono adattati alla vita sotterranea, nutrendosi di licheni e pesci ciechi. Questi bestioni irascibili hanno pelo ruvido e scuro e scurovisione; per il resto usano le statistiche dell'orso polare."),
		new Text(
			"Cave Bear",
			null,
			"Large beast, unaligned",
			"12 (natural armor)",
			"40 ft., swim 30 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 13",
			"—",
			"***Keen Smell.*** The bear has advantage on Wisdom (Perception) checks that rely on smell.",
			"***Multiattack.*** The bear makes two attacks: one with its bite and one with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 9 (1d8 + 5) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 12 (2d6 + 5) slashing damage.",
			"",
			"",
			"",
			"Cave bears have adapted to life underground, feeding on lichen and blind fish. These bad-tempered brutes have coarse, dark fur and darkvision; otherwise they use the polar bear statistics."));
}
