using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Scout (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Scout2014Seeder
{
	public static Monster Build() => Create("scout", null, CreatureSize.Medium, CreatureType.Humanoid,
		13, 16, "3d8 + 3", 30, new[] { 11, 14, 12, 11, 13, 11 }, 0.5m, 100, 2, 15,
		new Text(
			"Esploratore",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"13 (armatura di cuoio)",
			"9 m",
			"",
			"Furtività +6, Natura +4, Percezione +5, Sopravvivenza +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 15",
			"uno qualsiasi (di solito Comune)",
			"***Udito e vista acuti.*** L'esploratore dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista o sull'udito.",
			"***Multiattacco.*** L'esploratore effettua due attacchi in mischia o due attacchi a distanza.\n\n***Spada corta.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti.\n\n***Arco lungo.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti.",
			"",
			""),
		new Text(
			"Scout",
			null,
			"Medium humanoid (any race), any alignment",
			"13 (leather armor)",
			"30 ft.",
			"",
			"Nature +4, Perception +5, Stealth +6, Survival +5",
			"",
			"",
			"",
			"",
			"passive Perception 15",
			"any one language (usually Common)",
			"***Keen Hearing and Sight.*** The scout has advantage on Wisdom (Perception) checks that rely on hearing or sight.",
			"***Multiattack.*** The scout makes two melee attacks or two ranged attacks.\n\n***Shortsword.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage.\n\n***Longbow.*** *Ranged Weapon Attack:* +4 to hit, range 150/600 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage.",
			"",
			""));
}
