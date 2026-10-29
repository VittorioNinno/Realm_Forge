using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Banshee (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Banshee2014Seeder
{
	public static Monster Build() => Create("banshee", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Undead,
		12, 58, "13d8", 0, new[] { 1, 14, 10, 12, 11, 17 }, 4m, 1100, 2, 10,
		new Text(
			"Banshee",
			null,
			"Non morto Medio, caotico malvagio",
			"12",
			"0 m, volare 12 m (fluttuare)",
			"Car +4, Sag +2",
			"",
			"",
			"acido, fuoco, fulmine, tuono; contundenti, perforanti e taglienti da attacchi non magici",
			"freddo, necrotici, veleno",
			"affascinato, afferrato, avvelenato, indebolimento, paralizzato, pietrificato, prono, spaventato, trattenuto",
			"Percezione passiva 10, scurovisione 18 m",
			"Comune, Elfico",
			"***Percepire la vita.*** La banshee avverte magicamente la presenza delle creature viventi entro 8 chilometri da lei. Conosce la direzione approssimativa in cui si trovano, ma non il punto esatto.\n\n***Movimento incorporeo.*** La banshee può attraversare creature e oggetti come se fossero terreno difficile. Se termina il turno all'interno di un oggetto, subisce 5 (1d10) danni da forza.",
			"***Tocco corruttore.*** *Attacco con incantesimo in mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (3d6 + 2) danni necrotici.\n\n***Aspetto orripilante.*** Ogni creatura che non sia un non morto, entro 18 metri dalla banshee e in grado di vederla, effettua un tiro salvezza su Saggezza con CD 13; se lo fallisce è spaventata per 1 minuto. La creatura ripete il tiro salvezza alla fine di ogni suo turno, con svantaggio finché vede la banshee, e l'effetto termina con un successo. Una creatura che supera il tiro salvezza, o per cui l'effetto termina, non può più essere colpita dall'Aspetto orripilante di questa banshee per 24 ore.\n\n***Lamento (1/giorno).*** Purché non si trovi alla luce del sole, la banshee emette un grido straziante. Costrutti e non morti non ne sono toccati; ogni altra creatura entro 9 metri da lei in grado di sentirla effettua un tiro salvezza su Costituzione con CD 13. Chi lo fallisce scende a 0 punti ferita; chi lo supera subisce 10 (3d6) danni psichici.",
			"",
			"",
			"",
			""),
		new Text(
			"Banshee",
			null,
			"Medium undead, chaotic evil",
			"12",
			"0 ft., fly 40 ft. (hover)",
			"Wis +2, Cha +4",
			"",
			"",
			"acid, fire, lightning, thunder; bludgeoning, piercing, and slashing from nonmagical attacks",
			"cold, necrotic, poison",
			"charmed, exhaustion, frightened, grappled, paralyzed, petrified, poisoned, prone, restrained",
			"darkvision 60 ft., passive Perception 10",
			"Common, Elvish",
			"***Detect Life.*** The banshee magically feels the presence of living creatures within 5 miles of her. She knows roughly in which direction they are, but not where exactly.\n\n***Incorporeal Movement.*** The banshee can pass through creatures and objects as if they were difficult terrain. If she ends her turn inside an object, she takes 5 (1d10) force damage.",
			"***Corrupting Touch.*** *Melee Spell Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 12 (3d6 + 2) necrotic damage.\n\n***Horrifying Visage.*** Every creature other than undead within 60 feet of the banshee that can see her makes a DC 13 Wisdom saving throw; on a failure it is frightened for 1 minute. The creature repeats the save at the end of each of its turns, with disadvantage while it can see the banshee, and the effect ends on a success. A creature that succeeds, or whose fear ends, can't be affected by this banshee's Horrifying Visage again for 24 hours.\n\n***Wail (1/Day).*** As long as she isn't in sunlight, the banshee lets out a mournful cry. Constructs and undead are unaffected; every other creature within 30 feet of her that can hear her makes a DC 13 Constitution saving throw. A creature that fails drops to 0 hit points; one that succeeds takes 10 (3d6) psychic damage.",
			"",
			"",
			"",
			""));
}
