using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Manticore (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Manticore2014Seeder
{
	public static Monster Build() => Create("manticore", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Monstrosity,
		14, 68, "8d10 + 24", 30, new[] { 17, 16, 17, 7, 12, 8 }, 3m, 700, 2, 11,
		new Text(
			"Manticora",
			null,
			"Mostruosità Grande, legale malvagia",
			"14 (armatura naturale)",
			"9 m, volare 15 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 18 m",
			"Comune",
			"***Ricrescita degli aculei caudali.*** La manticora possiede ventiquattro aculei caudali. Quelli usati ricrescono quando la manticora completa un riposo lungo.",
			"***Multiattacco.*** La manticora effettua tre attacchi: uno con il morso e due con gli artigli oppure tre con gli aculei caudali.\n\n***Artiglio.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni perforanti.\n\n***Aculeo caudale.*** *Attacco con arma a distanza:* +5 al tiro per colpire, gittata 30/60 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Manticore",
			null,
			"Large monstrosity, lawful evil",
			"14 (natural armor)",
			"30 ft., fly 50 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 11",
			"—",
			"***Tail Spike Regrowth.*** The manticore has twenty-four tail spikes. Used spikes regrow when the manticore finishes a long rest.",
			"***Multiattack.*** The manticore makes three attacks: one with its bite and two with its claws or three with its tail spikes.\n\n***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) piercing damage.\n\n***Claw.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) slashing damage.\n\n***Tail Spike.*** *Ranged Weapon Attack:* +5 to hit, range 100/200 ft., one target. *Hit:* 7 (1d8 + 3) piercing damage.",
			"",
			"",
			"",
			""));
}
