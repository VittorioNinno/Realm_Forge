using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Black Bear (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BlackBear2014Seeder
{
	public static Monster Build() => Create("black-bear", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		11, 19, "3d8 + 6", 40, new[] { 15, 10, 14, 2, 12, 7 }, 0.5m, 100, 2, 13,
		new Text(
			"Orso nero",
			null,
			"Bestia Media, senza allineamento",
			"11 (armatura naturale)",
			"12 m, scalare 9 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Olfatto acuto.*** L'orso dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.",
			"***Multiattacco.*** L'orso effettua due attacchi: uno con il morso e uno con gli artigli.\n\n***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (2d4 + 2) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Black Bear",
			null,
			"Medium beast, unaligned",
			"11 (natural armor)",
			"40 ft., climb 30 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Smell.*** The bear has advantage on Wisdom (Perception) checks that rely on smell.",
			"***Multiattack.*** The bear makes two attacks: one with its bite and one with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 7 (2d4 + 2) slashing damage.",
			"",
			"",
			"",
			""));
}
