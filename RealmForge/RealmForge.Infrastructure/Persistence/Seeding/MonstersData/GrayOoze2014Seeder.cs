using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gray Ooze (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GrayOoze2014Seeder
{
	public static Monster Build() => Create("gray-ooze", null, CreatureSize.Medium, CreatureType.Ooze,
		8, 22, "3d8 + 9", 10, new[] { 12, 6, 16, 1, 6, 2 }, 0.5m, 100, 2, 8,
		new Text(
			"Melma grigia",
			null,
			"Melma Media, senza allineamento",
			"8",
			"3 m, scalare 3 m",
			"",
			"Furtività +2",
			"",
			"acido, freddo, fuoco",
			"",
			"accecato, affascinato, assordato, indebolimento, prono, spaventato",
			"Percezione passiva 8, vista cieca 18 m (cecità oltre questo raggio)",
			"—",
			"***Amorfo.*** La melma può muoversi attraverso uno spazio stretto fino a 2,5 centimetri senza doversi stringere.\n\n***Corrodere il metallo.*** Qualsiasi arma non magica fatta di metallo colpisca la melma si corrode. Dopo avere inflitto danni, l'arma subisce una penalità cumulativa e permanente di -1 ai tiri per i danni. Se la sua penalità scende a -5, l'arma viene distrutta. Le munizioni non magiche fatte di metallo che colpiscono la melma vengono distrutte dopo aver inflitto danni. La melma può corrodere fino a 5 centimetri di metallo non magico in 1 round.\n\n***Falso aspetto.*** Finché la melma rimane immobile, non è distinguibile da una pozza oleosa o da una roccia umida.",
			"***Pseudopode.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni contundenti più 7 (2d6) danni da acido e, se il bersaglio indossa un'armatura di metallo non magica, quest'ultima viene in parte corrosa e subisce una penalità cumulativa e permanente di -1 alla CA che fornisce. Se la penalità riduce la sua CA a 10, l'armatura si distrugge.",
			"",
			""),
		new Text(
			"Gray Ooze",
			null,
			"Medium ooze, unaligned",
			"8",
			"10 ft., climb 10 ft.",
			"",
			"Stealth +2",
			"",
			"acid, cold, fire",
			"",
			"blinded, charmed, deafened, exhaustion, frightened, prone",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 8",
			"—",
			"***Amorphous.*** The ooze can move through a space as narrow as 1 inch wide without squeezing.\n\n***Corrode Metal.*** Any nonmagical weapon made of metal that hits the ooze corrodes. After dealing damage, the weapon takes a permanent and cumulative -1 penalty to damage rolls. If its penalty drops to -5, the weapon is destroyed. Nonmagical ammunition made of metal that hits the ooze is destroyed after dealing damage.\n\nThe ooze can eat through 2-inch-thick, nonmagical metal in 1 round.\n\n***False Appearance.*** While the ooze remains motionless, it is indistinguishable from an oily pool or wet rock.",
			"***Pseudopod.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 4 (1d6 + 1) bludgeoning damage plus 7 (2d6) acid damage, and if the target is wearing nonmagical metal armor, its armor is partly corroded and takes a permanent and cumulative -1 penalty to the AC it offers. The armor is destroyed if the penalty reduces its AC to 10.",
			"",
			""));
}
