using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Owlbear (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Owlbear2014Seeder
{
	public static Monster Build() => Create("owlbear", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Monstrosity,
		13, 59, "7d10 + 21", 40, new[] { 20, 12, 17, 3, 12, 7 }, 3m, 700, 2, 13,
		new Text(
			"Orsogufo",
			null,
			"Mostruosità Grande, senza allineamento",
			"13 (armatura naturale)",
			"12 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, scurovisione 18 m",
			"—",
			"***Vista e olfatto acuti.*** L'orsogufo dispone di vantaggio nelle prove di Saggezza (Percezione) basate sulla vista o sull'olfatto.",
			"***Multiattacco.*** L'orsogufo effettua due attacchi: uno con il becco e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (2d8 + 5) danni taglienti.\n\n***Becco.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 10 (1d10 + 5) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Owlbear",
			null,
			"Large monstrosity, unaligned",
			"13 (natural armor)",
			"40 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 13",
			"—",
			"***Keen Sight and Smell.*** The owlbear has advantage on Wisdom (Perception) checks that rely on sight or smell.",
			"***Multiattack.*** The owlbear makes two attacks: one with its beak and one with its claws.\n\n***Beak.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one creature. *Hit:* 10 (1d10 + 5) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 14 (2d8 + 5) slashing damage.",
			"",
			"",
			"",
			""));
}
