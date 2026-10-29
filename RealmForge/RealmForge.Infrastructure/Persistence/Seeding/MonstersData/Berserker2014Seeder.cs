using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Berserker (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Berserker2014Seeder
{
	public static Monster Build() => Create("berserker", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		13, 67, "9d8 + 27", 30, new[] { 16, 12, 17, 9, 11, 9 }, 2m, 450, 2, 10,
		new Text(
			"Berserker",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento caotico",
			"13 (armatura di pelle)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"uno qualsiasi (di solito Comune)",
			"***Avventato.*** All'inizio del suo turno, il berserker può ottenere vantaggio a tutti i tiri per colpire con le armi da mischia che effettua in quel turno, ma i tiri per colpire contro di lui hanno vantaggio fino all'inizio del suo turno successivo.",
			"***Ascia bipenne.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (1d12 + 3) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Berserker",
			null,
			"Medium humanoid (any race), any chaotic alignment",
			"13 (hide armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"any one language (usually Common)",
			"***Reckless.*** At the start of its turn, the berserker can gain advantage on all melee weapon attack rolls during that turn, but attack rolls against it have advantage until the start of its next turn.",
			"***Greataxe.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 9 (1d12 + 3) slashing damage.",
			"",
			"",
			"",
			""));
}
