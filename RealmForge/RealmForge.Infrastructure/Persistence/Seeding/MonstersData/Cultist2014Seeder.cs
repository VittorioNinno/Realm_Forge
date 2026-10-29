using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Cultist (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Cultist2014Seeder
{
	public static Monster Build() => Create("cultist", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		12, 9, "2d8", 30, new[] { 11, 12, 10, 10, 11, 10 }, 0.125m, 25, 2, 10,
		new Text(
			"Cultista",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento non buono",
			"12 (armatura di cuoio)",
			"9 m",
			"",
			"Inganno +2, Religione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"uno qualsiasi (di solito Comune)",
			"***Devozione oscura.*** Il cultista dispone di vantaggio ai tiri salvezza contro le condizioni affascinato e spaventato.",
			"***Scimitarra.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 4 (1d6 + 1) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Cultist",
			null,
			"Medium humanoid (any race), any non-good alignment",
			"12 (leather armor)",
			"30 ft.",
			"",
			"Deception +2, Religion +2",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"any one language (usually Common)",
			"***Dark Devotion.*** The cultist has advantage on saving throws against being charmed or frightened.",
			"***Scimitar.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one creature. *Hit:* 4 (1d6 + 1) slashing damage.",
			"",
			"",
			"",
			""));
}
