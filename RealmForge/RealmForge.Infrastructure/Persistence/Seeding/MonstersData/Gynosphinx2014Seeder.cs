using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gynosphinx (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Gynosphinx2014Seeder
{
	public static Monster Build() => Create("gynosphinx", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Monstrosity,
		17, 136, "16d10 + 48", 40, new[] { 18, 15, 16, 18, 18, 18 }, 11m, 7200, 4, 18,
		new Text(
			"Ginosfinge",
			null,
			"Mostruosità Grande, legale neutrale",
			"17 (armatura naturale)",
			"12 m, volare 18 m",
			"",
			"Arcano +12, Percezione +8, Religione +8, Storia +12",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"psichici",
			"affascinato, spaventato",
			"Percezione passiva 18, vista pura 36 m",
			"Comune, Sfinge",
			"***Armi magiche.*** Gli attacchi con arma della sfinge sono magici.\n\n***Imperscrutabile.*** La sfinge è immune a qualsiasi effetto che tenti di percepire le emozioni o leggere nel pensiero, nonché a qualsiasi incantesimo di divinazione a cui rifiuti di sottoporsi. Le prove di Saggezza (Intuizione) effettuate per discernere le intenzioni o la sincerità della sfinge subiscono svantaggio.\n\n***Incantesimi.*** La sfinge è un'incantatrice di 9° livello: la sua caratteristica da incantatore è Intelligenza (CD del tiro salvezza sull'incantesimo 16, +8 al tiro per colpire con attacco con incantesimo). Non ha bisogno di componenti materiali per lanciare i suoi incantesimi. La sfinge ha a disposizione i seguenti incantesimi da mago:\n\n- Trucchetti (a volontà): *illusione minore, mano magica, prestidigitazione*\n- 1° livello (4 slot): *identificare, individuazione del magico, scudo*\n- 2° livello (3 slot): *oscurità, localizza oggetto, suggestione*\n- 3° livello (3 slot): *dissolvi magie, linguaggi, rimuovi maledizione*\n- 4° livello (3 slot): *esilio, invisibilità superiore*\n- 5° livello (1 slot): *conoscenza delle leggende*",
			"***Multiattacco.*** La sfinge effettua due attacchi con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni taglienti.",
			"",
			"",
			"La sfinge può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. La sfinge recupera le azioni leggendarie effettuate.\n\n***Attacco con artiglio.*** La sfinge effettua un attacco con artiglio.\n\n***Teletrasporto (costa 2 azioni).*** La sfinge si teletrasporta magicamente, insieme a ogni oggetto che indossa o trasporta, fino a uno spazio libero visibile entro 36 metri.\n\n***Lanciare un incantesimo (costa 3 azioni).*** La sfinge lancia un incantesimo dalla sua lista degli incantesimi preparati, usando uno slot incantesimo come di consueto.",
			""),
		new Text(
			"Gynosphinx",
			null,
			"Large monstrosity, lawful neutral",
			"17 (natural armor)",
			"40 ft., fly 60 ft.",
			"",
			"Arcana +12, History +12, Perception +8, Religion +8",
			"",
			"bludgeoning, piercing, and slashing from nonmagical weapons",
			"psychic",
			"charmed, frightened",
			"truesight 120 ft., passive Perception 18",
			"Common, Sphinx",
			"***Inscrutable.*** The sphinx is immune to any effect that would sense its emotions or read its thoughts, as well as any divination spell that it refuses. Wisdom (Insight) checks made to ascertain the sphinx's intentions or sincerity have disadvantage.\n\n***Magic Weapons.*** The sphinx's weapon attacks are magical.\n\n***Spellcasting.*** The sphinx is a 9th-level spellcaster. Its spellcasting ability is Intelligence (spell save DC 16, +8 to hit with spell attacks). It requires no material components to cast its spells. The sphinx has the following wizard spells prepared:\n\n- Cantrips (at will): *mage hand, minor illusion, prestidigitation*\n- 1st level (4 slots): *detect magic, identify, shield*\n- 2nd level (3 slots): *darkness, locate object, suggestion*\n- 3rd level (3 slots): *dispel magic, remove curse, tongues*\n- 4th level (3 slots): *banishment, greater invisibility*\n- 5th level (1 slot): *legend lore*",
			"***Multiattack.*** The sphinx makes two claw attacks.\n\n***Claw.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) slashing damage.",
			"",
			"",
			"The gynosphinx can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The gynosphinx regains spent legendary actions at the start of its turn.\n\n***Claw Attack.*** The sphinx makes one claw attack.\n\n***Teleport (Costs 2 Actions).*** The sphinx magically teleports, along with any equipment it is wearing or carrying, up to 120 feet to an unoccupied space it can see.\n\n***Cast a Spell (Costs 3 Actions).*** The sphinx casts a spell from its list of prepared spells, using a spell slot as normal.",
			""));
}
