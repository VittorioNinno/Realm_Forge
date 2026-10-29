using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Darkmantle (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Darkmantle2014Seeder
{
	public static Monster Build() => Create("darkmantle", null, CreatureSize.Small, CreatureType.Monstrosity,
		11, 22, "5d6 + 5", 10, new[] { 16, 12, 13, 2, 10, 5 }, 0.5m, 100, 2, 10,
		new Text(
			"Mantoscuro",
			null,
			"Mostruosità Piccola, senza allineamento",
			"11",
			"3 m, volare 9 m",
			"",
			"Furtività +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 10, vista cieca 18 m",
			"—",
			"***Falso aspetto.*** Finché il mantoscuro rimane immobile, non è distinguibile da una formazione rocciosa come una stalattite o una stalagmite.\n\n***Senso radar.*** Il mantoscuro non può usare vista cieca se è assordato.",
			"***Schiacciare.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 6 (1d6 + 3) danni contundenti e il mantoscuro si avvinghia al bersaglio. Se il bersaglio è di taglia Media o inferiore e il mantoscuro dispone di vantaggio al tiro per colpire, quest'ultimo si avvinghia avviluppandosi alla testa del bersaglio: il bersaglio è anche accecato e non può respirare finché il mantoscuro resta avvinghiato in questo modo. Finché è avvinghiato al bersaglio, il mantoscuro può attaccare solamente il bersaglio, ma dispone di vantaggio ai suoi tiri per colpire. Inoltre, il mantoscuro si muove insieme al bersaglio, la sua velocità diventa 0 e non può beneficiare di alcun bonus alla velocità. Una creatura può staccare il mantoscuro con un'azione effettuando con successo una prova di Forza con CD 13. Nel suo turno, il mantoscuro può staccarsi spontaneamente dal bersaglio usando 1,5 metri di movimento.\n\n***Aura di oscurità (1/giorno).*** Un'oscurità magica si estende dal mantoscuro in un raggio di 4,5 metri, spostandosi insieme a lui e diffondendosi nell'ambiente. L'oscurità permane finché il mantoscuro mantiene la concentrazione (come se si concentrasse su un incantesimo) fino a un massimo di 10 minuti. La scurovisione non riesce a penetrare questo tipo di oscurità e nessuna luce naturale può illuminarla. Se una qualsiasi parte di oscurità si sovrappone a un'area di luce creata da un incantesimo di 2° livello o inferiore, l'incantesimo che crea la luce è dissolto.",
			"",
			""),
		new Text(
			"Darkmantle",
			null,
			"Small monstrosity, unaligned",
			"11",
			"10 ft., fly 30 ft.",
			"",
			"Stealth +3",
			"",
			"",
			"",
			"",
			"blindsight 60 ft., passive Perception 10",
			"—",
			"***Echolocation.*** The darkmantle can't use its blindsight while deafened.\n\n***False Appearance.*** While the darkmantle remains motionless, it is indistinguishable from a cave formation such as a stalactite or stalagmite.",
			"***Crush.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* 6 (1d6 + 3) bludgeoning damage, and the darkmantle attaches to the target. If the target is Medium or smaller and the darkmantle has advantage on the attack roll, it attaches by engulfing the target's head, and the target is also blinded and unable to breathe while the darkmantle is attached in this way.\n\nWhile attached to the target, the darkmantle can attack no other creature except the target but has advantage on its attack rolls. The darkmantle's speed also becomes 0, it can't benefit from any bonus to its speed, and it moves with the target.\nA creature can detach the darkmantle by making a successful DC 13 Strength check as an action. On its turn, the darkmantle can detach itself from the target by using 5 feet of movement.\n\n***Darkness Aura (1/Day).*** A 15-foot radius of magical darkness extends out from the darkmantle, moves with it, and spreads around corners. The darkness lasts as long as the darkmantle maintains concentration, up to 10 minutes (as if concentrating on a spell). Darkvision can't penetrate this darkness, and no natural light can illuminate it. If any of the darkness overlaps with an area of light created by a spell of 2nd level or lower, the spell creating the light is dispelled.",
			"",
			""));
}
