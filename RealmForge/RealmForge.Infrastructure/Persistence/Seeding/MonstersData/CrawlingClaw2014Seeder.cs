using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Crawling Claw (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class CrawlingClaw2014Seeder
{
	public static Monster Build() => Create("crawling-claw", null, ContentSource.RealmForge, CreatureSize.Tiny, CreatureType.Undead,
		12, 2, "1d4", 20, new[] { 13, 14, 11, 5, 10, 4 }, 0m, 10, 2, 10,
		new Text(
			"Artiglio strisciante",
			null,
			"Non morto Minuscolo, neutrale malvagio",
			"12",
			"6 m, scalare 6 m",
			"",
			"",
			"",
			"",
			"veleno",
			"affascinato, avvelenato, indebolimento",
			"Percezione passiva 10, vista cieca 9 m (cieco oltre questo raggio)",
			"capisce il Comune ma non lo parla",
			"***Immunità allo scacciare.*** Gli effetti che scacciano i non morti non hanno effetto sull'artiglio.",
			"***Artiglio.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni contundenti o taglienti (a scelta dell'artiglio).",
			"",
			"",
			"",
			""),
		new Text(
			"Crawling Claw",
			null,
			"Tiny undead, neutral evil",
			"12",
			"20 ft., climb 20 ft.",
			"",
			"",
			"",
			"",
			"poison",
			"charmed, exhaustion, poisoned",
			"blindsight 30 ft. (blind beyond this radius), passive Perception 10",
			"understands Common but can't speak",
			"***Turn Immunity.*** Effects that turn undead have no effect on the claw.",
			"***Claw.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) bludgeoning or slashing damage (the claw's choice).",
			"",
			"",
			"",
			""));
}
