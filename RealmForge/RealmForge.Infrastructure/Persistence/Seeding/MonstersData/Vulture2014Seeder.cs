using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Vulture (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Vulture2014Seeder
{
	public static Monster Build() => Create("vulture", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		10, 5, "1d8 + 1", 10, new[] { 7, 10, 13, 2, 12, 4 }, 0m, 10, 2, 13,
		new Text(
			"Avvoltoio",
			null,
			"Bestia Media, senza allineamento",
			"10",
			"3 m, volare 15 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Tattiche del branco.*** L'avvoltoio dispone di vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati dell'animale si trova entro 1,5 metri dalla creatura e non è incapacitato.\n\n***Vista e olfatto acuti.*** L'avvoltoio dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista o sull'olfatto.",
			"***Becco.*** *Attacco con arma da mischia:* +2 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 2 (1d4) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Vulture",
			null,
			"Medium beast, unaligned",
			"10",
			"10 ft., fly 50 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Sight and Smell.*** The vulture has advantage on Wisdom (Perception) checks that rely on sight or smell.\n\n***Pack Tactics.*** The vulture has advantage on an attack roll against a creature if at least one of the vulture's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Beak.*** *Melee Weapon Attack:* +2 to hit, reach 5 ft., one target. *Hit:* 2 (1d4) piercing damage.",
			"",
			"",
			"",
			""));
}
