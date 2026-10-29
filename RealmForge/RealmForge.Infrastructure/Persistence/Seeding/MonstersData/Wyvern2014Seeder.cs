using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Wyvern (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Wyvern2014Seeder
{
	public static Monster Build() => Create("wyvern", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Dragon,
		13, 110, "13d10 + 39", 20, new[] { 19, 10, 16, 5, 12, 6 }, 6m, 2300, 3, 14,
		new Text(
			"Viverna",
			null,
			"Drago Grande, senza allineamento",
			"13 (armatura naturale)",
			"6 m, volare 24 m",
			"",
			"Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 18 m",
			"—",
			"",
			"***Multiattacco.*** La viverna effettua due attacchi: uno con il morso e uno con il pungiglione. Mentre vola, può usare gli artigli al posto di un altro attacco.\n\n***Artigli.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 11 (2d6 + 4) danni perforanti.\n\n***Pungiglione.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 11 (2d6 + 4) danni perforanti. Il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 15, subendo 24 (7d6) danni da veleno in caso di fallimento, o la metà in caso di successo.",
			"",
			"",
			"",
			""),
		new Text(
			"Wyvern",
			null,
			"Large dragon, unaligned",
			"13 (natural armor)",
			"20 ft., fly 80 ft.",
			"",
			"Perception +4",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 14",
			"—",
			"",
			"***Multiattack.*** The wyvern makes two attacks: one with its bite and one with its stinger. While flying, it can use its claws in place of one other attack.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one creature. *Hit:* 11 (2d6 + 4) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) slashing damage.\n\n***Stinger.*** *Melee Weapon Attack:* +7 to hit, reach 10 ft., one creature. *Hit:* 11 (2d6 + 4) piercing damage. The target must make a DC 15 Constitution saving throw, taking 24 (7d6) poison damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"",
			""));
}
