using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Troglodyte (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Troglodyte2014Seeder
{
	public static Monster Build() => Create("troglodyte", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		11, 13, "2d8 + 4", 30, new[] { 14, 10, 14, 6, 10, 6 }, 0.25m, 50, 2, 10,
		new Text(
			"Troglodita",
			null,
			"Umanoide Medio (troglodita), caotico malvagio",
			"11 (armatura naturale)",
			"9 m",
			"",
			"Furtività +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, scurovisione 18 m",
			"Troglodita",
			"***Pelle camaleontica.*** Il troglodita dispone di vantaggio alle prove di Destrezza (Furtività) per nascondersi.\n\n***Fetore.*** Ogni creatura che non sia un troglodita e che inizia il suo turno entro 1,5 metri dal troglodita effettua un tiro salvezza su Costituzione con CD 12, altrimenti è avvelenata fino all'inizio del suo turno successivo. Una creatura che lo supera è immune al fetore di tutti i trogloditi per 1 ora.\n\n***Sensibilità alla luce del sole.*** Finché si trova alla luce del sole, il troglodita subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Multiattacco.*** Il troglodita effettua tre attacchi: uno con il morso e due con gli artigli.\n\n***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti.\n\n***Artiglio.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Troglodyte",
			null,
			"Medium humanoid (troglodyte), chaotic evil",
			"11 (natural armor)",
			"30 ft.",
			"",
			"Stealth +2",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 10",
			"Troglodyte",
			"***Chameleon Skin.*** The troglodyte has advantage on Dexterity (Stealth) checks to hide.\n\n***Stench.*** Any creature other than a troglodyte that starts its turn within 5 feet of the troglodyte makes a DC 12 Constitution saving throw or is poisoned until the start of its next turn. A creature that succeeds is immune to the stench of every troglodyte for 1 hour.\n\n***Sunlight Sensitivity.*** While in sunlight, the troglodyte has disadvantage on attack rolls, as well as on Wisdom (Perception) checks that rely on sight.",
			"***Multiattack.*** The troglodyte makes three attacks: one bite and two claw attacks.\n\n***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) slashing damage.",
			"",
			"",
			"",
			""));
}
