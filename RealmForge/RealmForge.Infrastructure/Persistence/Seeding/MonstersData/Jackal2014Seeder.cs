using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Jackal (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Jackal2014Seeder
{
	public static Monster Build() => Create("jackal", null, CreatureSize.Small, CreatureType.Beast,
		12, 3, "1d6", 40, new[] { 8, 15, 11, 3, 12, 6 }, 0m, 10, 2, 13,
		new Text(
			"Sciacallo",
			null,
			"Bestia Piccola, senza allineamento",
			"12",
			"12 m",
			"",
			"Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Tattiche del branco.*** Lo sciacallo dispone di un vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati dell'animale si trova entro 1,5 metri dalla creatura e non è incapacitato.\n\n***Udito e olfatto acuti.*** Lo sciacallo dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +1 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 1 (1d4 - 1) danni perforanti.",
			"",
			""),
		new Text(
			"Jackal",
			null,
			"Small beast, unaligned",
			"12",
			"40 ft.",
			"",
			"Perception +3",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Hearing and Smell.*** The jackal has advantage on Wisdom (Perception) checks that rely on hearing or smell.\n\n***Pack Tactics.*** The jackal has advantage on an attack roll against a creature if at least one of the jackal's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Bite.*** *Melee Weapon Attack:* +1 to hit, reach 5 ft., one target. *Hit:* 1 (1d4 - 1) piercing damage.",
			"",
			""));
}
