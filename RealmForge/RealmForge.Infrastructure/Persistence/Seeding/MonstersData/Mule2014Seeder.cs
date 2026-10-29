using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Mule (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Mule2014Seeder
{
	public static Monster Build() => Create("mule", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		10, 11, "2d8 + 2", 40, new[] { 14, 10, 13, 2, 10, 5 }, 0.125m, 25, 2, 10,
		new Text(
			"Mulo",
			null,
			"Bestia Media, senza allineamento",
			"10",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"—",
			"***Ben piantato.*** Il mulo ha vantaggio ai tiri salvezza su Forza e Destrezza contro effetti che lo farebbero cadere prono.\n\n***Bestia da soma.*** Il mulo è considerato un animale Grande ai fini delle sue capacità di trasporto.",
			"***Zoccoli.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni contundenti.",
			"",
			"",
			"",
			""),
		new Text(
			"Mule",
			null,
			"Medium beast, unaligned",
			"10",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"—",
			"***Beast of Burden.*** The mule is considered to be a Large animal for the purpose of determining its carrying capacity.\n\n***Sure-Footed.*** The mule has advantage on Strength and Dexterity saving throws made against effects that would knock it prone.",
			"***Hooves.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) bludgeoning damage.",
			"",
			"",
			"",
			""));
}
