using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Invisible Stalker (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class InvisibleStalker2014Seeder
{
	public static Monster Build() => Create("invisible-stalker", null, CreatureSize.Medium, CreatureType.Elemental,
		14, 104, "16d8 + 32", 50, new[] { 16, 19, 14, 10, 15, 11 }, 6m, 2300, 3, 18,
		new Text(
			"Cacciatore invisibile",
			null,
			"Elementale Medio, neutrale",
			"14",
			"15 m, volare 15 m (fluttuare)",
			"",
			"Furtività +10, Percezione +8",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"afferrato, avvelenato, indebolimento, paralizzato, pietrificato, privo di sensi, prono, trattenuto",
			"Percezione passiva 18, scurovisione 18 m",
			"Auran, capisce il Comune ma non lo parla",
			"***Invisibilità.*** Il cacciatore è invisibile.\n\n***Segugio infallibile.*** L'evocatore indica una preda al cacciatore. Il cacciatore conosce la direzione e la distanza a cui si trova la preda, purché entrambi siano sullo stesso piano di esistenza. Il cacciatore conosce anche l'ubicazione del suo evocatore.",
			"***Multiattacco.*** Il cacciatore effettua due attacchi con schianto.\n\n***Schianto.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni contundenti.",
			"",
			""),
		new Text(
			"Invisible Stalker",
			null,
			"Medium elemental, neutral",
			"14",
			"50 ft., fly 50 ft. (hover)",
			"",
			"Perception +8, Stealth +10",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons",
			"poison",
			"exhaustion, grappled, paralyzed, petrified, poisoned, prone, restrained, unconscious",
			"darkvision 60 ft., passive Perception 18",
			"Auran, understands Common but doesn't speak it",
			"***Invisibility.*** The stalker is invisible.\n\n***Faultless Tracker.*** The stalker is given a quarry by its summoner. The stalker knows the direction and distance to its quarry as long as the two of them are on the same plane of existence. The stalker also knows the location of its summoner.",
			"***Multiattack.*** The stalker makes two slam attacks.\n\n***Slam.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) bludgeoning damage.",
			"",
			""));
}
