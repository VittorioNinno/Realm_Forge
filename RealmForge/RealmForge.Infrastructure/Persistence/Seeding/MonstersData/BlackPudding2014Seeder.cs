using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Black Pudding (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class BlackPudding2014Seeder
{
	public static Monster Build() => Create("black-pudding", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Ooze,
		7, 85, "10d10 + 30", 20, new[] { 16, 5, 16, 1, 6, 1 }, 4m, 1100, 2, 8,
		new Text(
			"Protoplasma nero",
			null,
			"Melma Grande, senza allineamento",
			"7",
			"6 m, scalare 6 m",
			"",
			"",
			"",
			"",
			"acido, freddo, fulmine, tagliente",
			"accecato, affascinato, assordato, indebolimento, prono, spaventato",
			"Percezione passiva 8, vista cieca 18 m (cecità oltre questo raggio)",
			"—",
			"***Amorfo.*** Il protoplasma può muoversi attraverso uno spazio stretto fino a 2,5 centimetri senza doversi stringere.\n\n***Forma corrosiva.*** Una creatura che tocchi il protoplasma o lo colpisca con un attacco in mischia mentre si trova entro 1,5 metri da esso subisce 4 (1d8) danni da acido. Qualsiasi arma non magica fatta di metallo o di legno colpisca il protoplasma si corrode. Dopo avere inflitto danni, l'arma subisce una penalità cumulativa e permanente di -1 ai tiri per i danni. Se la sua penalità scende a -5, l'arma viene distrutta. Le munizioni non magiche fatte di metallo o di legno che colpiscono il protoplasma vengono distrutte dopo aver inflitto danni. Il protoplasma può corrodere fino a 5 centimetri di legno o di metallo non magico in 1 round.\n\n***Movimenti del ragno.*** Il protoplasma può scalare le superfici difficili, inclusi i soffitti, lungo i quali si muove a testa in giù, senza effettuare una prova di caratteristica.",
			"***Pseudopode.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni contundenti più 18 (4d8) danni da acido. Inoltre, le armature non magiche indossate dal bersaglio vengono parzialmente dissolte e subiscono una penalità cumulativa e permanente di -1 alla CA che forniscono. Se la penalità riduce la sua CA a 10, l'armatura si distrugge.",
			"",
			"***Scindersi.*** Quando un protoplasma di taglia Media o superiore è soggetto a danni da fulmine o taglienti, si scinde in due nuovi protoplasmi se possiede almeno 10 punti ferita. Ogni nuovo protoplasma ha un numero di punti ferita pari alla metà del protoplasma originale, arrotondando per difetto. I nuovi protoplasmi sono inferiori di una taglia rispetto al protoplasma originale.",
			"",
			""),
		new Text(
			"Black Pudding",
			null,
			"Large ooze, unaligned",
			"7",
			"20 ft., climb 20 ft.",
			"",
			"",
			"",
			"",
			"acid, cold, lightning, slashing",
			"blinded, charmed, exhaustion, frightened, prone",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 8",
			"—",
			"***Amorphous.*** The pudding can move through a space as narrow as 1 inch wide without squeezing.\n\n***Corrosive Form.*** A creature that touches the pudding or hits it with a melee attack while within 5 feet of it takes 4 (1d8) acid damage. Any nonmagical weapon made of metal or wood that hits the pudding corrodes. After dealing damage, the weapon takes a permanent and cumulative -1 penalty to damage rolls. If its penalty drops to -5, the weapon is destroyed. Nonmagical ammunition made of metal or wood that hits the pudding is destroyed after dealing damage. The pudding can eat through 2-inch-thick, nonmagical wood or metal in 1 round.\n\n***Spider Climb.*** The pudding can climb difficult surfaces, including upside down on ceilings, without needing to make an ability check.",
			"***Pseudopod.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) bludgeoning damage plus 18 (4d8) acid damage. In addition, nonmagical armor worn by the target is partly dissolved and takes a permanent and cumulative -1 penalty to the AC it offers. The armor is destroyed if the penalty reduces its AC to 10.",
			"",
			"***Split.*** When a pudding that is Medium or larger is subjected to lightning or slashing damage, it splits into two new puddings if it has at least 10 hit points. Each new pudding has hit points equal to half the original pudding's, rounded down. New puddings are one size smaller than the original pudding.",
			"",
			""));
}
