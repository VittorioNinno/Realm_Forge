using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gelatinous Cube (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GelatinousCube2014Seeder
{
	public static Monster Build() => Create("gelatinous-cube", null, CreatureSize.Large, CreatureType.Ooze,
		6, 84, "8d10 + 40", 15, new[] { 14, 3, 20, 1, 6, 1 }, 2m, 450, 2, 8,
		new Text(
			"Cubo gelatinoso",
			null,
			"Melma Grande, senza allineamento",
			"6",
			"4,5 m",
			"",
			"",
			"",
			"",
			"",
			"accecato, affascinato, assordato, indebolimento, prono, spaventato",
			"Percezione passiva 8, vista cieca 18 m (cecità oltre questo raggio)",
			"—",
			"***Cubo di melma.*** Il cubo occupa tutto il suo spazio. Le altre creature possono accedervi, ma se lo fanno sono soggette all'avviluppamento del cubo e subiscono svantaggio al tiro salvezza. Le creature all'interno del cubo possono essere viste ma beneficiano di copertura totale. Una creatura entro 1,5 metri dal cubo può effettuare un'azione per tirare fuori da esso una creatura o un oggetto. Per farlo è necessario superare una prova di Forza con CD 12 e la creatura che esegue il tentativo subisce 10 (3d6) danni da acido. Il cubo può contenere al suo interno simultaneamente solo una creatura Grande o fino a quattro creature di taglia Media o inferiore.\n\n***Trasparente.*** Anche quando il cubo è in bella vista, è necessario superare una prova di Saggezza (Percezione) con CD 15 per avvistare un cubo che non si sia mosso o che non abbia attaccato. Una creatura che cerca di entrare nello spazio del cubo senza essere consapevole della sua presenza viene colta di sorpresa.",
			"***Pseudopode.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 10 (3d6) danni da acido.\n\n***Avviluppare.*** Il cubo si muove fino al massimo della sua velocità. Durante questo movimento, può entrare negli spazi delle creature di taglia Grande o inferiore. Ogni volta che il cubo entra nello spazio di una creatura, quest'ultima deve effettuare un tiro salvezza su Destrezza con CD 12. Se lo supera, la creatura può scegliere di essere spinta di 1,5 metri indietro o lateralmente rispetto al cubo. Una creatura che sceglie di non essere mossa subisce le conseguenze di un tiro salvezza fallito. In caso di tiro salvezza fallito, il cubo entra nello spazio della creatura, che subisce 10 (3d6) danni da acido ed è avviluppata. In questo stato non può respirare, è trattenuta e riceve 21 (6d6) danni da acido all'inizio di ogni turno del cubo. Quando il cubo si muove, la creatura avviluppata si muove insieme a lui. Una creatura avviluppata può tentare di sfuggire usando un'azione per effettuare una prova di Forza con CD 12. In caso di successo, la creatura sfugge ed entra in uno spazio a sua scelta entro 1,5 metri dal cubo.",
			"",
			""),
		new Text(
			"Gelatinous Cube",
			null,
			"Large ooze, unaligned",
			"6",
			"15 ft.",
			"",
			"",
			"",
			"",
			"",
			"blinded, charmed, deafened, exhaustion, frightened, prone",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 8",
			"—",
			"***Ooze Cube.*** The cube takes up its entire space. Other creatures can enter the space, but a creature that does so is subjected to the cube's Engulf and has disadvantage on the saving throw.\n\nCreatures inside the cube can be seen but have total cover.\nA creature within 5 feet of the cube can take an action to pull a creature or object out of the cube. Doing so requires a successful DC 12 Strength check, and the creature making the attempt takes 10 (3d6) acid damage.\nThe cube can hold only one Large creature or up to four Medium or smaller creatures inside it at a time.\n\n***Transparent.*** Even when the cube is in plain sight, it takes a successful DC 15 Wisdom (Perception) check to spot a cube that has neither moved nor attacked. A creature that tries to enter the cube's space while unaware of the cube is surprised by the cube.",
			"***Pseudopod.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 10 (3d6) acid damage.\n\n***Engulf.*** The cube moves up to its speed. While doing so, it can enter Large or smaller creatures' spaces. Whenever the cube enters a creature's space, the creature must make a DC 12 Dexterity saving throw.\n\nOn a successful save, the creature can choose to be pushed 5 feet back or to the side of the cube. A creature that chooses not to be pushed suffers the consequences of a failed saving throw.\nOn a failed save, the cube enters the creature's space, and the creature takes 10 (3d6) acid damage and is engulfed. The engulfed creature can't breathe, is restrained, and takes 21 (6d6) acid damage at the start of each of the cube's turns. When the cube moves, the engulfed creature moves with it.\nAn engulfed creature can try to escape by taking an action to make a DC 12 Strength check. On a success, the creature escapes and enters a space of its choice within 5 feet of the cube.",
			"",
			""));
}
