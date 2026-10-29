using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Wolf (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Wolf2014Seeder
{
	public static Monster Build() => Create("wolf", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Beast,
		13, 11, "2d8 + 2", 40, new[] { 12, 15, 12, 3, 12, 6 }, 0.25m, 50, 2, 13,
		new Text(
			"Lupo",
			null,
			"Bestia Media, senza allineamento",
			"13 (armatura naturale)",
			"12 m",
			"",
			"Furtività +4, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13",
			"—",
			"***Tattiche del branco.*** Il lupo dispone di vantaggio ai tiri per colpire contro una creatura se almeno uno degli alleati del lupo si trova entro 1,5 metri dalla creatura e non è incapacitato.\n\n***Udito e olfatto acuti.*** Il lupo dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto o sull'udito.",
			"***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (2d4 + 2) danni perforanti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 11, altrimenti cade a terra prono.",
			"",
			"",
			"",
			""),
		new Text(
			"Wolf",
			null,
			"Medium beast, unaligned",
			"13 (natural armor)",
			"40 ft.",
			"",
			"Perception +3, Stealth +4",
			"",
			"",
			"",
			"",
			"passive Perception 13",
			"—",
			"***Keen Hearing and Smell.*** The wolf has advantage on Wisdom (Perception) checks that rely on hearing or smell.\n\n***Pack Tactics.*** The wolf has advantage on an attack roll against a creature if at least one of the wolf's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 7 (2d4 + 2) piercing damage. If the target is a creature, it must succeed on a DC 11 Strength saving throw or be knocked prone.",
			"",
			"",
			"",
			""));
}
