using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Dire Wolf (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class DireWolf2014Seeder
{
	public static Monster Build() => Create("dire-wolf", null, CreatureSize.Large, CreatureType.Beast,
		14, 37, "5d10 + 10", 50, new[] { 17, 15, 15, 3, 12, 7 }, 1m, 200, 2, 13,
		new Text(
			"Lupo feroce",
			null,
			"Bestia Grande, senza allineamento",
			"14 (armatura naturale)",
			"15 m",
			"",
			"Furtività +4, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Tattiche del branco.*** Il lupo dispone di vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati dell'animale si trova entro 1,5 metri dalla creatura e non è incapacitato.\n\n***Udito e olfatto acuti.*** Il lupo dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni perforanti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 13, altrimenti cade a terra prono.",
			"",
			""),
		new Text(
			"Dire Wolf",
			null,
			"Large beast, unaligned",
			"14 (natural armor)",
			"50 ft.",
			"",
			"Perception +3, Stealth +4",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Hearing and Smell.*** The wolf has advantage on Wisdom (Perception) checks that rely on hearing or smell.\n\n***Pack Tactics.*** The wolf has advantage on an attack roll against a creature if at least one of the wolf's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) piercing damage. If the target is a creature, it must succeed on a DC 13 Strength saving throw or be knocked prone.",
			"",
			""));
}
