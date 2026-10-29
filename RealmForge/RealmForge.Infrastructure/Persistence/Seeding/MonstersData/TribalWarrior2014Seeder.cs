using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Tribal Warrior (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class TribalWarrior2014Seeder
{
	public static Monster Build() => Create("tribal-warrior", null, CreatureSize.Medium, CreatureType.Humanoid,
		12, 11, "2d8 + 2", 30, new[] { 13, 11, 12, 8, 11, 8 }, 0.125m, 25, 2, 10,
		new Text(
			"Combattente tribale",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"12 (armatura di pelle)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"uno qualsiasi",
			"***Tattiche del branco.*** Il combattente dispone di vantaggio nel tiro per colpire contro una creatura se almeno uno dei suoi alleati si trova entro 1,5 metri dalla creatura e non è incapacitato.",
			"***Lancia.*** *Attacco con arma da mischia o a distanza:* +3 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti o 5 (1d8 + 1) danni perforanti se usata a due mani per effettuare un attacco in mischia.",
			"",
			""),
		new Text(
			"Tribal Warrior",
			null,
			"Medium humanoid (any race), any alignment",
			"12 (hide armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"any one language",
			"***Pack Tactics.*** The warrior has advantage on an attack roll against a creature if at least one of the warrior's allies is within 5 ft. of the creature and the ally isn't incapacitated.",
			"***Spear.*** *Melee or Ranged Weapon Attack:* +3 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage, or 5 (1d8 + 1) piercing damage if used with two hands to make a melee attack.",
			"",
			""));
}
