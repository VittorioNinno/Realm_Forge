using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Treant (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Treant2014Seeder
{
	public static Monster Build() => Create("treant", null, CreatureSize.Huge, CreatureType.Plant,
		16, 138, "12d12 + 60", 30, new[] { 23, 8, 21, 12, 16, 12 }, 9m, 5000, 4, 13,
		new Text(
			"Treant",
			null,
			"Vegetale Enorme, caotico buono",
			"16 (armatura naturale)",
			"9 m",
			"",
			"",
			"fuoco",
			"contundenti, perforanti",
			"",
			"",
			"Percezione passiva 13",
			"Comune, Druidico, Elfico, Silvano",
			"***Falso aspetto.*** Finché il treant rimane immobile, non è possibile distinguerlo da un normale albero.\n\n***Mostro da assedio.*** Il treant infligge danni doppi a oggetti e strutture.",
			"***Multiattacco.*** Il treant effettua due attacchi con schianto.\n\n***Schianto.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 16 (3d6 + 6) danni contundenti.\n\n***Roccia.*** *Attacco con arma a distanza:* +10 al tiro per colpire, gittata 18/54 m, un bersaglio. *Colpito:* 28 (4d10 + 6) danni contundenti.\n\n***Fronde animate (1/giorno).*** Il treant anima magicamente uno o due alberi nel suo campo visivo in un raggio di 18 metri. Questi alberi possiedono le stesse statistiche del treant, a eccezione dei punteggi di Intelligenza e Carisma pari a 1. Inoltre, non possono parlare e possiedono soltanto l'opzione di azione Schianto. Un albero animato funge da alleato del treant. L'albero rimane animato per 1 giorno o finché non muore, fin quando il treant muore o si trova a più di 36 metri dall'albero, oppure finché il treant non compie un'azione bonus per trasformarlo di nuovo in un albero inanimato. Dopodiché, qualora possibile, l'albero mette radici.",
			"",
			""),
		new Text(
			"Treant",
			null,
			"Huge plant, chaotic good",
			"16 (natural armor)",
			"30 ft.",
			"",
			"",
			"fire",
			"bludgeoning, piercing",
			"",
			"",
			"passive Perception 13",
			"Common, Druidic, Elvish, Sylvan",
			"***False Appearance.*** While the treant remains motionless, it is indistinguishable from a normal tree.\n\n***Siege Monster.*** The treant deals double damage to objects and structures.",
			"***Multiattack.*** The treant makes two slam attacks.\n\n***Slam.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 16 (3d6 + 6) bludgeoning damage.\n\n***Rock.*** *Ranged Weapon Attack:* +10 to hit, range 60/180 ft., one target. *Hit:* 28 (4d10 + 6) bludgeoning damage.\n\n***Animate Trees (1/Day).*** The treant magically animates one or two trees it can see within 60 feet of it. These trees have the same statistics as a treant, except they have Intelligence and Charisma scores of 1, they can't speak, and they have only the Slam action option. An animated tree acts as an ally of the treant. The tree remains animate for 1 day or until it dies; until the treant dies or is more than 120 feet from the tree; or until the treant takes a bonus action to turn it back into an inanimate tree. The tree then takes root if possible.",
			"",
			""));
}
