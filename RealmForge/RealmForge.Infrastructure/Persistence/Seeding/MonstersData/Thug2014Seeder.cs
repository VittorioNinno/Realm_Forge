using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Thug (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Thug2014Seeder
{
	public static Monster Build() => Create("thug", null, CreatureSize.Medium, CreatureType.Humanoid,
		11, 32, "5d8 + 10", 30, new[] { 15, 11, 14, 10, 10, 11 }, 0.5m, 100, 2, 10,
		new Text(
			"Malvivente",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento non buono",
			"11 (armatura di cuoio)",
			"9 m",
			"",
			"Intimidire +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"uno qualsiasi (di solito Comune)",
			"***Tattiche del branco.*** Il malvivente dispone di vantaggio nel tiro per colpire contro una creatura se almeno uno degli alleati del malvivente si trova entro 1,5 metri dalla creatura e non è incapacitato.",
			"***Multiattacco.*** Il malvivente effettua due attacchi in mischia.\n\n***Mazza.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 5 (1d6 + 2) danni contundenti.\n\n***Balestra pesante.*** *Attacco con arma a distanza:* +2 al tiro per colpire, gittata 30/120 m, un bersaglio. *Colpito:* 5 (1d10) danni perforanti.",
			"",
			""),
		new Text(
			"Thug",
			null,
			"Medium humanoid (any race), any non-good alignment",
			"11 (leather armor)",
			"30 ft.",
			"",
			"Intimidation +2",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"any one language (usually Common)",
			"***Pack Tactics.*** The thug has advantage on an attack roll against a creature if at least one of the thug's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Multiattack.*** The thug makes two melee attacks.\n\n***Mace.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 5 (1d6 + 2) bludgeoning damage.\n\n***Heavy Crossbow.*** *Ranged Weapon Attack:* +2 to hit, range 100/400 ft., one target. *Hit:* 5 (1d10) piercing damage.",
			"",
			""));
}
