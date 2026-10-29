using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Quaggoth (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Quaggoth2014Seeder
{
	public static Monster Build() => Create("quaggoth", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		13, 45, "6d8 + 18", 30, new[] { 17, 12, 16, 6, 12, 7 }, 2m, 450, 2, 11,
		new Text(
			"Quaggoth",
			null,
			"Umanoide Medio (quaggoth), caotico neutrale",
			"13 (armatura naturale)",
			"9 m, scalare 9 m",
			"",
			"Atletica +5",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 11, scurovisione 36 m",
			"Sottocomune",
			"***Furia ferita.*** Finché ha 10 punti ferita o meno, il quaggoth dispone di vantaggio ai tiri per colpire e infligge 7 (2d6) danni extra con ogni colpo in mischia.",
			"***Multiattacco.*** Il quaggoth effettua due attacchi con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Quaggoth",
			null,
			"Medium humanoid (quaggoth), chaotic neutral",
			"13 (natural armor)",
			"30 ft., climb 30 ft.",
			"",
			"Athletics +5",
			"",
			"",
			"poison",
			"poisoned",
			"darkvision 120 ft., passive Perception 11",
			"Undercommon",
			"***Wounded Fury.*** While it has 10 hit points or fewer, the quaggoth has advantage on attack rolls and deals an extra 7 (2d6) damage with each melee hit.",
			"***Multiattack.*** The quaggoth makes two claw attacks.\n\n***Claw.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) slashing damage.",
			"",
			"",
			"",
			""));
}
