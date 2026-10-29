using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Aboleth (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Aboleth2014Seeder
{
	public static Monster Build() => Create("aboleth", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Aberration,
		17, 135, "18d10 + 36", 10, new[] { 21, 9, 15, 18, 15, 18 }, 10m, 5900, 4, 20,
		new Text(
			"Aboleth",
			null,
			"Aberrazione Grande, legale malvagio",
			"17 (armatura naturale)",
			"3 m, nuotare 12 m",
			"Cos +6, Int +8, Sag +6",
			"Percezione +10, Storia +12",
			"",
			"",
			"",
			"",
			"Percezione passiva 20, scurovisione 36 m",
			"Gergo delle profondità, telepatia 36 m",
			"***Anfibio.*** L'aboleth può respirare in aria e in acqua.\n\n***Nube di muco.*** Finché si trova sott'acqua, l'aboleth è circondato da uno strato di muco mutageno. Se una creatura tocca l'aboleth o lo colpisce con un attacco in mischia mentre si trova a 1,5 metri da esso, quella creatura deve effettuare un tiro salvezza su Costituzione con CD 14. Se lo fallisce, si ammala per 1d4 ore. La creatura malata può respirare soltanto sott'acqua.\n\n***Sonda telepatica.*** Se una creatura comunica telepaticamente con l'aboleth, quest'ultimo apprende i più grandi desideri della creatura, se è in grado di vederla.",
			"***Multiattacco.*** L'aboleth effettua tre attacchi con i tentacoli.\n\n***Coda.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 15 (3d6 + 5) danni contundenti.\n\n***Tentacolo.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni contundenti. Se il bersaglio è una creatura, deve superare un tiro salvezza su Costituzione con CD 14, altrimenti si ammala. La malattia non ha effetto per 1 minuto e può essere rimossa da qualsiasi magia in grado di curare malattie. Dopo 1 minuto, la pelle della creatura malata diventa traslucida e viscida, la creatura non può recuperare punti ferita a meno che non si trovi sott'acqua e la malattia può essere rimossa soltanto da *guarigione* o da un altro incantesimo in grado di curare malattie di 6° livello o superiore. Quando la creatura si trova al di fuori di uno specchio d'acqua, subisce 6 (1d12) danni da acido ogni 10 minuti, a meno che la sua pelle non venga inumidita prima che i 10 minuti siano trascorsi.\n\n***Schiavizzare (3/giorno).*** L'aboleth prende di mira una creatura nel suo campo visivo in un raggio di 9 metri. Il bersaglio deve superare un tiro salvezza su Saggezza con CD 14, altrimenti è affascinato magicamente dall'aboleth finché quest'ultimo non muore o non si trova su un piano di esistenza diverso da quello del bersaglio. Il bersaglio affascinato è sotto il controllo dell'aboleth e non può avere reazioni. Inoltre, l'aboleth e il bersaglio possono comunicare telepaticamente l'uno con l'altro a qualsiasi distanza. Ogni volta che il bersaglio affascinato subisce danni, può ripetere il tiro salvezza. Se lo supera, l'effetto svanisce. Non più di una volta ogni 24 ore, il bersaglio può anche ripetere il tiro salvezza quando si trova ad almeno 1,5 chilometri dall'aboleth.",
			"",
			"",
			"L'aboleth può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del turno, l'aboleth recupera le azioni leggendarie effettuate.\n\n***Individuazione.*** L'aboleth effettua una prova di Saggezza (Percezione).\n\n***Spazzata di coda.*** L'aboleth effettua un attacco con la coda.\n\n***Risucchio psichico (costa 2 azioni).*** Una creatura affascinata dall'aboleth subisce 10 (3d6) danni psichici e l'aboleth recupera un numero di punti ferita pari ai danni subiti dalla creatura.",
			""),
		new Text(
			"Aboleth",
			null,
			"Large aberration, lawful evil",
			"17 (natural armor)",
			"10 ft., swim 40 ft.",
			"Con +6, Int +8, Wis +6",
			"History +12, Perception +10",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 20",
			"Deep Speech, telepathy 120 ft.",
			"***Amphibious.*** The aboleth can breathe air and water.\n\n***Mucous Cloud.*** While underwater, the aboleth is surrounded by transformative mucus. A creature that touches the aboleth or that hits it with a melee attack while within 5 ft. of it must make a DC 14 Constitution saving throw. On a failure, the creature is diseased for 1d4 hours. The diseased creature can breathe only underwater.\n\n***Probing Telepathy.*** If a creature communicates telepathically with the aboleth, the aboleth learns the creature's greatest desires if the aboleth can see the creature.",
			"***Multiattack.*** The aboleth makes three tentacle attacks.\n\n***Tentacle.*** *Melee Weapon Attack:* +9 to hit, reach 10 ft., one target. *Hit:* 12 (2d6 + 5) bludgeoning damage. If the target is a creature, it must succeed on a DC 14 Constitution saving throw or become diseased. The disease has no effect for 1 minute and can be removed by any magic that cures disease. After 1 minute, the diseased creature's skin becomes translucent and slimy, the creature can't regain hit points unless it is underwater, and the disease can be removed only by heal or another disease-curing spell of 6th level or higher. When the creature is outside a body of water, it takes 6 (1d12) acid damage every 10 minutes unless moisture is applied to the skin before 10 minutes have passed.\n\n***Tail.*** *Melee Weapon Attack:* +9 to hit, reach 10 ft., one target. *Hit:* 15 (3d6 + 5) bludgeoning damage.\n\n***Enslave (3/Day).*** The aboleth targets one creature it can see within 30 ft. of it. The target must succeed on a DC 14 Wisdom saving throw or be magically charmed by the aboleth until the aboleth dies or until it is on a different plane of existence from the target. The charmed target is under the aboleth's control and can't take reactions, and the aboleth and the target can communicate telepathically with each other over any distance.\n\nWhenever the charmed target takes damage, the target can repeat the saving throw. On a success, the effect ends. No more than once every 24 hours, the target can also repeat the saving throw when it is at least 1 mile away from the aboleth.",
			"",
			"",
			"The aboleth can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The aboleth regains spent legendary actions at the start of its turn.\n\n***Detect.*** The aboleth makes a Wisdom (Perception) check.\n\n***Tail Swipe.*** The aboleth makes one tail attack.\n\n***Psychic Drain (Costs 2 Actions).*** One creature charmed by the aboleth takes 10 (3d6) psychic damage, and the aboleth regains hit points equal to the damage the creature takes.",
			""));
}
