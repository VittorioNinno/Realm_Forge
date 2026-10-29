using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Noble (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Noble2014Seeder
{
	public static Monster Build() => Create("noble", null, CreatureSize.Medium, CreatureType.Humanoid,
		15, 9, "2d8", 30, new[] { 11, 12, 11, 12, 14, 16 }, 0.125m, 25, 2, 12,
		new Text(
			"Nobile",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"15 (corazza)",
			"9 m",
			"",
			"Inganno +5, Intuizione +4, Persuasione +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 12",
			"due qualsiasi",
			"",
			"***Stocco.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d8 + 1) danni perforanti.",
			"***Parata.*** Il nobile aggiunge 2 alla sua CA contro un attacco in mischia che lo colpirebbe. Per farlo, deve vedere l'attaccante e deve impugnare un'arma da mischia.",
			""),
		new Text(
			"Noble",
			null,
			"Medium humanoid (any race), any alignment",
			"15 (breastplate)",
			"30 ft.",
			"",
			"Deception +5, Insight +4, Persuasion +5",
			"",
			"",
			"",
			"",
			"passive Perception 12",
			"any two languages",
			"",
			"***Rapier.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 5 (1d8 + 1) piercing damage.",
			"***Parry.*** The noble adds 2 to its AC against one melee attack that would hit it. To do so, the noble must see the attacker and be wielding a melee weapon.",
			""));
}
