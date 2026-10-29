using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Nothic (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Nothic2014Seeder
{
	public static Monster Build() => Create("nothic", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Aberration,
		15, 45, "6d8 + 18", 30, new[] { 14, 16, 16, 13, 10, 8 }, 2m, 450, 2, 12,
		new Text(
			"Nothic",
			null,
			"Aberrazione Media, neutrale malvagio",
			"15 (armatura naturale)",
			"9 m",
			"",
			"Arcano +3, Furtività +5, Intuizione +4, Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, vista pura 36 m",
			"Sottocomune",
			"***Vista acuta.*** Il nothic dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista.",
			"***Multiattacco.*** Il nothic effettua due attacchi con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni taglienti.\n\n***Sguardo putrefacente.*** Una creatura che il nothic è in grado di vedere entro 9 metri da lui effettua un tiro salvezza su Costituzione con CD 12 contro questa magia, altrimenti subisce 10 (3d6) danni necrotici.\n\n***Intuizione inquietante.*** Una creatura che il nothic è in grado di vedere entro 9 metri da lui effettua una prova di Carisma (Inganno) contrapposta alla prova di Saggezza (Intuizione) del nothic. Se il nothic vince, apprende magicamente un fatto o un segreto sul bersaglio. Una creatura immune alla condizione affascinato vince sempre.",
			"",
			"",
			"",
			""),
		new Text(
			"Nothic",
			null,
			"Medium aberration, neutral evil",
			"15 (natural armor)",
			"30 ft.",
			"",
			"Arcana +3, Insight +4, Perception +2, Stealth +5",
			"",
			"",
			"",
			"",
			"truesight 120 ft., passive Perception 12",
			"Undercommon",
			"***Keen Sight.*** The nothic has advantage on Wisdom (Perception) checks that rely on sight.",
			"***Multiattack.*** The nothic makes two claw attacks.\n\n***Claw.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) slashing damage.\n\n***Rotting Gaze.*** One creature the nothic can see within 30 feet of it makes a DC 12 Constitution saving throw against this magic or takes 10 (3d6) necrotic damage.\n\n***Weird Insight.*** One creature the nothic can see within 30 feet of it makes a Charisma (Deception) check contested by the nothic's Wisdom (Insight) check. If the nothic wins, it magically learns a fact or a secret about the target. A creature immune to being charmed always wins.",
			"",
			"",
			"",
			""));
}
