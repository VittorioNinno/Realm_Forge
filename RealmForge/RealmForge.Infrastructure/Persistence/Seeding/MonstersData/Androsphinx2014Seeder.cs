using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Androsphinx (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Androsphinx2014Seeder
{
	public static Monster Build() => Create("androsphinx", null, CreatureSize.Large, CreatureType.Monstrosity,
		17, 199, "19d10 + 95", 40, new[] { 22, 10, 20, 16, 18, 23 }, 17m, 18000, 6, 20,
		new Text(
			"Androsfinge",
			null,
			"Mostruosità Grande, legale neutrale",
			"17 (armatura naturale)",
			"12 m, volare 18 m",
			"Cos +11, Des +6, Int +9, Sag +10",
			"Arcano +9, Percezione +10, Religione +15",
			"",
			"",
			"psichici; contundenti, perforanti e taglienti da attacchi non magici",
			"affascinato, spaventato",
			"Percezione passiva 20, vista pura 36 m",
			"Comune, Sfinge",
			"***Armi magiche.*** Gli attacchi con arma della sfinge sono magici.\n\n***Imperscrutabile.*** La sfinge è immune a qualsiasi effetto che tenti di percepire le emozioni o leggere nel pensiero, nonché a qualsiasi incantesimo di divinazione a cui rifiuti di sottoporsi. Le prove di Saggezza (Intuizione) effettuate per discernere le intenzioni o la sincerità della sfinge subiscono svantaggio.\n\n***Incantesimi.*** La sfinge è un'incantatrice di 12° livello: la sua caratteristica da incantatore è Saggezza (CD del tiro salvezza sull'incantesimo 18, +10 al tiro per colpire con attacco con incantesimo). Non ha bisogno di componenti materiali per lanciare i suoi incantesimi. La sfinge ha a disposizione i seguenti incantesimi da chierico:\n\n- Trucchetti (a volontà): *fiamma sacra, salvare i morenti, taumaturgia*\n- 1° livello (4 slot): *comando, individuazione del bene e del male, individuazione del magico*\n- 2° livello (3 slot): *ristorare inferiore, zona di verità*\n- 3° livello (3 slot): *dissolvi magie, linguaggi*\n- 4° livello (3 slot): *esilio, libertà di movimento*\n- 5° livello (2 slot): *colpo infuocato, ristorare superiore*\n- 6° livello (1 slot): *banchetto degli eroi*",
			"***Multiattacco.*** La sfinge effettua due attacchi con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +12 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 17 (2d10 + 6) danni taglienti.\n\n***Ruggito (3/giorno).*** La sfinge emette un ruggito magico. Ogni volta che ruggisce prima di completare un riposo lungo, il verso è più forte e l'effetto è diverso, come descritto di seguito. Ogni creatura entro 150 metri dalla sfinge e in grado di udire il ruggito deve effettuare un tiro salvezza.\n\n***Primo ruggito.*** Ogni creatura che fallisce un tiro salvezza su Saggezza con CD 18 è spaventata per 1 minuto. La creatura spaventata può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.\n\n***Secondo ruggito.*** Ogni creatura che fallisce un tiro salvezza su Saggezza con CD 18 è assordata e spaventata per 1 minuto. La creatura spaventata è paralizzata e può ripetere il tiro salvezza alla fine di ogni suo turno: se lo supera, l'effetto svanisce.\n\n***Terzo ruggito.*** Ogni creatura effettua un tiro salvezza su Costituzione con CD 18: chi lo fallisce subisce 44 (8d10) danni da tuono e cade a terra prona; chi lo supera, invece, subisce soltanto la metà di quei danni e non viene buttata a terra prona.",
			"",
			"La sfinge può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. La sfinge recupera le azioni leggendarie effettuate.\n\n***Attacco con artiglio.*** La sfinge effettua un attacco con artiglio.\n\n***Teletrasporto (costa 2 azioni).*** La sfinge si teletrasporta magicamente, insieme a ogni oggetto che indossa o trasporta, fino a uno spazio libero visibile entro 36 metri.\n\n***Lanciare un incantesimo (costa 3 azioni).*** La sfinge lancia un incantesimo dalla sua lista degli incantesimi preparati, usando uno slot incantesimo come di consueto."),
		new Text(
			"Androsphinx",
			null,
			"Large monstrosity, lawful neutral",
			"17 (natural armor)",
			"40 ft., fly 60 ft.",
			"Dex +6, Con +11, Int +9, Wis +10",
			"Arcana +9, Perception +10, Religion +15",
			"",
			"",
			"psychic; bludgeoning, piercing, and slashing from nonmagical weapons",
			"charmed, frightened",
			"truesight 120 ft., passive Perception 20",
			"Common, Sphinx",
			"***Inscrutable.*** The sphinx is immune to any effect that would sense its emotions or read its thoughts, as well as any divination spell that it refuses. Wisdom (Insight) checks made to ascertain the sphinx's intentions or sincerity have disadvantage.\n\n***Magic Weapons.*** The sphinx's weapon attacks are magical.\n\n***Spellcasting.*** The sphinx is a 12th-level spellcaster. Its spellcasting ability is Wisdom (spell save DC 18, +10 to hit with spell attacks). It requires no material components to cast its spells. The sphinx has the following cleric spells prepared:\n\n- Cantrips (at will): *sacred flame, spare the dying, thaumaturgy*\n- 1st level (4 slots): *command, detect evil and good, detect magic*\n- 2nd level (3 slots): *lesser restoration, zone of truth*\n- 3rd level (3 slots): *dispel magic, tongues*\n- 4th level (3 slots): *banishment, freedom of movement*\n- 5th level (2 slots): *flame strike, greater restoration*\n- 6th level (1 slot): *heroes' feast*",
			"***Multiattack.*** The sphinx makes two claw attacks.\n\n***Claw.*** *Melee Weapon Attack:* +12 to hit, reach 5 ft., one target. *Hit:* 17 (2d10 + 6) slashing damage.\n\n***Roar (3/Day).*** The sphinx emits a magical roar. Each time it roars before finishing a long rest, the roar is louder and the effect is different, as detailed below. Each creature within 500 feet of the sphinx and able to hear the roar must make a saving throw.\n\n\nFirst Roar. Each creature that fails a DC 18 Wisdom saving throw is frightened for 1 minute. A frightened creature can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.\n\nSecond Roar. Each creature that fails a DC 18 Wisdom saving throw is deafened and frightened for 1 minute. A frightened creature is paralyzed and can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.\n\nThird Roar. Each creature makes a DC 18 Constitution saving throw. On a failed save, a creature takes 44 (8d10) thunder damage and is knocked prone. On a successful save, the creature takes half as much damage and isn't knocked prone.",
			"",
			"The androsphinx can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The androsphinx regains spent legendary actions at the start of its turn.\n\n***Claw Attack.*** The sphinx makes one claw attack.\n\n***Teleport (Costs 2 Actions).*** The sphinx magically teleports, along with any equipment it is wearing or carrying, up to 120 feet to an unoccupied space it can see.\n\n***Cast a Spell (Costs 3 Actions).*** The sphinx casts a spell from its list of prepared spells, using a spell slot as normal."));
}
