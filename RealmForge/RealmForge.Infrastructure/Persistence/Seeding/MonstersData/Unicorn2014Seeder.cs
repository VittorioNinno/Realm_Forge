using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Unicorn (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Unicorn2014Seeder
{
	public static Monster Build() => Create("unicorn", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Celestial,
		12, 67, "9d10 + 18", 50, new[] { 18, 14, 15, 11, 17, 16 }, 5m, 1800, 3, 13,
		new Text(
			"Unicorno",
			null,
			"Celestiale Grande, legale buono",
			"12",
			"15 m",
			"",
			"",
			"",
			"",
			"veleno",
			"affascinato, avvelenato, paralizzato",
			"Percezione passiva 13, scurovisione 18 m",
			"Celestiale, Elfico, Silvano, telepatia 18 m",
			"***Armi magiche.*** Gli attacchi con arma dell'unicorno sono magici.\n\n***Carica.*** Se l'unicorno si muove di almeno 6 metri in linea retta verso un bersaglio e poi lo colpisce con il corno nello stesso turno, la vittima subisce 9 (2d8) danni perforanti extra. Se il bersaglio è una creatura, deve superare un tiro salvezza su Forza con CD 15, altrimenti cade a terra prono.\n\n***Incantesimi innati.*** La caratteristica innata da incantatore dell'unicorno è Carisma (CD del tiro salvezza sull'incantesimo 14). Per sua natura, l'unicorno è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *artificio druidico, individuazione del bene e del male, passare senza tracce*\n- 1/giorno ciascuno: *calmare emozioni, dissolvi il bene e il male, intralciare*\n\n***Resistenza alla magia.*** L'unicorno dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** L'unicorno effettua due attacchi: uno con gli zoccoli e uno con il corno.\n\n***Corno.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d8 + 4) danni perforanti.\n\n***Zoccoli.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti.\n\n***Tocco Guaritore (3/giorno).*** L'unicorno tocca un'altra creatura con il corno. Il bersaglio recupera magicamente 11 (2d8 + 2) punti ferita. Inoltre, il tocco rimuove tutte le malattie e neutralizza tutti i veleni che affliggono il bersaglio.\n\n***Teletrasporto (1/giorno).*** L'unicorno teletrasporta magicamente se stesso e fino a tre creature consenzienti nel suo campo visivo situate entro 1,5 metri, insieme a ogni oggetto che queste ultime indossano o trasportano, fino a un luogo familiare all'unicorno, entro un raggio di 1,5 chilometri.",
			"",
			"",
			"L'unicorno può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, l'unicorno recupera le azioni leggendarie effettuate.\n\n***Zoccoli.*** L'unicorno effettua un attacco con gli zoccoli.\n\n***Scudo scintillante (costa 2 azioni).*** L'unicorno crea un campo magico scintillante attorno a sé o a un'altra creatura situata nel suo campo visivo in un raggio di 18 metri. Il bersaglio ottiene un bonus di +2 alla CA fino alla fine del turno successivo dell'unicorno.\n\n***Guarire se stesso (costa 3 azioni).*** L'unicorno recupera magicamente 11 (2d8 + 2) punti ferita.",
			""),
		new Text(
			"Unicorn",
			null,
			"Large celestial, lawful good",
			"12",
			"50 ft.",
			"",
			"",
			"",
			"",
			"poison",
			"charmed, paralyzed, poisoned",
			"darkvision 60 ft., passive Perception 13",
			"Celestial, Elvish, Sylvan, telepathy 60 ft.",
			"***Charge.*** If the unicorn moves at least 20 ft. straight toward a target and then hits it with a horn attack on the same turn, the target takes an extra 9 (2d8) piercing damage. If the target is a creature, it must succeed on a DC 15 Strength saving throw or be knocked prone.\n\n***Innate Spellcasting.*** The unicorn's innate spellcasting ability is Charisma (spell save DC 14). The unicorn can innately cast the following spells, requiring no components:\n\n\n- At will: *detect evil and good, druidcraft, pass without trace*\n- 1/day each: *calm emotions, dispel evil and good, entangle*\n\n***Magic Resistance.*** The unicorn has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The unicorn's weapon attacks are magical.",
			"***Multiattack.*** The unicorn makes two attacks: one with its hooves and one with its horn.\n\n***Hooves.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage.\n\n***Horn.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 8 (1d8 + 4) piercing damage.\n\n***Healing Touch (3/Day).*** The unicorn touches another creature with its horn. The target magically regains 11 (2d8 + 2) hit points. In addition, the touch removes all diseases and neutralizes all poisons afflicting the target.\n\n***Teleport (1/Day).*** The unicorn magically teleports itself and up to three willing creatures it can see within 5 ft. of it, along with any equipment they are wearing or carrying, to a location the unicorn is familiar with, up to 1 mile away.",
			"",
			"",
			"The unicorn can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The unicorn regains spent legendary actions at the start of its turn.\n\n***Hooves.*** The unicorn makes one attack with its hooves.\n\n***Shimmering Shield (Costs 2 Actions).*** The unicorn creates a shimmering, magical field around itself or another creature it can see within 60 ft. of it. The target gains a +2 bonus to AC until the end of the unicorn's next turn.\n\n***Heal Self (Costs 3 Actions).*** The unicorn magically regains 11 (2d8 + 2) hit points.",
			""));
}
