using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Demilich (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Demilich2014Seeder
{
	public static Monster Build() => Create("demilich", null, ContentSource.RealmForge, CreatureSize.Tiny, CreatureType.Undead,
		20, 80, "20d4", 0, new[] { 1, 20, 10, 20, 17, 20 }, 18m, 20000, 6, 13,
		new Text(
			"Demilich",
			null,
			"Non morto Minuscolo, neutrale malvagio",
			"20 (armatura naturale)",
			"0 m, volare 9 m (fluttuare)",
			"Car +11, Cos +6, Int +11, Sag +9",
			"",
			"",
			"contundenti, perforanti e taglienti da armi magiche",
			"necrotici, veleno, psichici; contundenti, perforanti e taglienti da attacchi non magici",
			"affascinato, assordato, avvelenato, indebolimento, paralizzato, pietrificato, prono, spaventato, stordito",
			"Percezione passiva 13, vista pura 36 m",
			"—",
			"***Elusione.*** Quando un effetto consente al demilich di effettuare un tiro salvezza per subire solo la metà dei danni, non subisce alcun danno se lo supera e solo la metà se lo fallisce.\n\n***Resistenza leggendaria (3/giorno).*** Se il demilich fallisce un tiro salvezza, può scegliere di superarlo comunque.\n\n***Immunità allo scacciare.*** Gli effetti che scacciano i non morti non hanno effetto sul demilich.",
			"***Ululato (ricarica 5–6).*** Il demilich emette un ululato agghiacciante. Ogni creatura entro 9 metri da lui in grado di sentirlo effettua un tiro salvezza su Costituzione con CD 15: se lo fallisce scende a 0 punti ferita, se lo supera è spaventata fino alla fine del suo turno successivo.\n\n***Prosciugare la vita.*** Fino a tre creature che il demilich è in grado di vedere entro 3 metri da lui effettuano ciascuna un tiro salvezza su Costituzione con CD 19 e subiscono 21 (6d6) danni necrotici se lo falliscono. Il demilich recupera tanti punti ferita quanti sono i danni inflitti in totale.",
			"",
			"",
			"Il demilich può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il demilich recupera le azioni leggendarie effettuate.\n\n***Volo.*** Il demilich vola fino a metà della sua velocità di volare.\n\n***Nube di polvere.*** Il demilich solleva magicamente i suoi resti polverosi. Ogni creatura entro 3 metri da lui, anche oltre un angolo, effettua un tiro salvezza su Costituzione con CD 15, altrimenti è accecata fino alla fine del turno successivo del demilich. Una creatura che lo supera non può esserne colpita di nuovo fino alla fine del turno successivo del demilich.\n\n***Risucchio di energia (costa 2 azioni).*** Ogni creatura entro 9 metri dal demilich effettua un tiro salvezza su Costituzione con CD 15. Se lo fallisce, i suoi punti ferita massimi sono ridotti magicamente di 10 (3d6); una creatura i cui punti ferita massimi scendono a 0 muore. L'incantesimo *ristorare superiore* o una magia simile ripristina il massimo perduto.\n\n***Maledizione infame (costa 3 azioni).*** Una creatura che il demilich è in grado di vedere entro 9 metri da lui effettua un tiro salvezza su Saggezza con CD 15, altrimenti è magicamente maledetta e subisce svantaggio ai tiri per colpire e ai tiri salvezza. Ripete il tiro salvezza alla fine di ogni suo turno e la maledizione termina con un successo.",
			"Un demilich ha sempre il massimo dei punti ferita consentito dai suoi Dadi Vita."),
		new Text(
			"Demilich",
			null,
			"Tiny undead, neutral evil",
			"20 (natural armor)",
			"0 ft., fly 30 ft. (hover)",
			"Con +6, Int +11, Wis +9, Cha +11",
			"",
			"",
			"bludgeoning, piercing, and slashing from magic weapons",
			"necrotic, poison, psychic; bludgeoning, piercing, and slashing from nonmagical attacks",
			"charmed, deafened, exhaustion, frightened, paralyzed, petrified, poisoned, prone, stunned",
			"truesight 120 ft., passive Perception 13",
			"—",
			"***Avoidance.*** When an effect lets the demilich make a saving throw to take only half damage, it takes no damage on a success and only half damage on a failure.\n\n***Legendary Resistance (3/Day).*** If the demilich fails a saving throw, it can choose to succeed instead.\n\n***Turn Immunity.*** Effects that turn undead have no effect on the demilich.",
			"***Howl (Recharge 5–6).*** The demilich lets out a bloodcurdling howl. Each creature within 30 feet of it that can hear it makes a DC 15 Constitution saving throw: on a failure it drops to 0 hit points, on a success it is frightened until the end of its next turn.\n\n***Life Drain.*** Up to three creatures the demilich can see within 10 feet of it each make a DC 19 Constitution saving throw, taking 21 (6d6) necrotic damage on a failure. The demilich regains as many hit points as the total damage dealt.",
			"",
			"",
			"The demilich can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The demilich regains spent legendary actions at the start of its turn.\n\n***Flight.*** The demilich flies up to half its flying speed.\n\n***Cloud of Dust.*** The demilich magically stirs up its dusty remains. Each creature within 10 feet of it, even around a corner, makes a DC 15 Constitution saving throw or is blinded until the end of the demilich's next turn. A creature that succeeds can't be affected by this again until the end of the demilich's next turn.\n\n***Energy Drain (Costs 2 Actions).*** Each creature within 30 feet of the demilich makes a DC 15 Constitution saving throw. On a failure, its hit point maximum is magically reduced by 10 (3d6); a creature whose maximum drops to 0 dies. The greater restoration spell or similar magic restores the lost maximum.\n\n***Vile Curse (Costs 3 Actions).*** One creature the demilich can see within 30 feet of it makes a DC 15 Wisdom saving throw or is magically cursed, having disadvantage on attack rolls and saving throws. It repeats the save at the end of each of its turns, ending the curse on a success.",
			"A demilich always has the maximum hit points for its Hit Dice."));
}
