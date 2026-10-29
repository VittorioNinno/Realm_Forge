using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Solar (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Solar2014Seeder
{
	public static Monster Build() => Create("solar", null, ContentSource.Srd51, CreatureSize.Large, CreatureType.Celestial,
		21, 243, "18d10 + 144", 50, new[] { 26, 22, 26, 25, 25, 30 }, 21m, 33000, 7, 24,
		new Text(
			"Solar",
			null,
			"Celestiale Grande, legale buono",
			"21 (armatura naturale)",
			"15 m, volare 45 m",
			"Car +14, Int +17, Sag +14",
			"Percezione +14",
			"",
			"radiosi, contundenti, perforanti e taglienti da attacchi non magici",
			"necrotici, veleno",
			"affascinato, avvelenato, indebolimento, spaventato",
			"Percezione passiva 24, vista pura 36 m",
			"tutti, telepatia 36 m",
			"***Armi angeliche.*** Gli attacchi con arma del solar sono magici. Quando il solar colpisce con qualsiasi arma, la sua arma infligge 6d8 danni radiosi extra (già inclusi nell'attacco).\n\n***Consapevolezza divina.*** Il solar sa riconoscere le menzogne.\n\n***Incantesimi innati.*** La caratteristica da incantatore del solar è Carisma (CD del tiro salvezza sull'incantesimo 25). Per sua natura, è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *individuazione del bene e del male, invisibilità* (solo se stesso)\n- 3/giorno ciascuno: *barriera di lame, dissolvi il bene e il male, resurrezione*\n- 1/giorno ciascuno: *comunione, controllare tempo atmosferico*\n\n***Resistenza alla magia.*** Il solar dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il solar effettua due attacchi con lo spadone.\n\n***Spadone.*** *Attacco con arma da mischia:* +15 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 22 (4d6 + 8) danni taglienti più 27 (6d8) danni radiosi.\n\n***Arco lungo assassino.*** *Attacco con arma a distanza:* +13 al tiro per colpire, gittata 45/180 m, un bersaglio. *Colpito:* 15 (2d8 + 6) danni perforanti più 27 (6d8) danni radiosi. Se il bersaglio è una creatura con 100 punti ferita o meno, deve superare un tiro salvezza su Costituzione con CD 15, altrimenti muore.\n\n***Spada volante.*** Il solar lascia andare il suo spadone, che fluttua magicamente in uno spazio libero entro 1,5 metri da lui. Se il solar è in grado di vedere lo spadone, come azione bonus può ordinargli mentalmente di volare fino a un massimo di 15 metri e di sferrare un attacco contro un bersaglio o di tornare nella sua mano. Se la spada fluttuante è bersagliata da un qualsiasi effetto, è comunque considerata impugnata dal solar. Se il solar muore, la spada fluttuante cade a terra.\n\n***Tocco Guaritore (4/giorno).*** Il solar tocca un'altra creatura. Il bersaglio recupera magicamente 40 (8d8 + 4) punti ferita ed è liberato da qualsiasi maledizione, malattia, veleno, cecità o sordità.",
			"",
			"",
			"Il solar può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del turno, il solar recupera le azioni leggendarie effettuate.\n\n***Teletrasporto.*** Il solar si teletrasporta magicamente, insieme a ogni oggetto che indossa o trasporta, fino a uno spazio libero visibile entro 36 metri.\n\n***Esplosione incandescente (costa 2 azioni).*** Il solar emette un'onda di energia magica divina. Ogni creatura a sua scelta entro un raggio di 3 metri deve effettuare un tiro salvezza su Destrezza con CD 23, subendo 14 (4d6) danni da fuoco più 14 (4d6) danni radiosi in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Sguardo accecante (costa 3 azioni).*** Il solar prende di mira una creatura nel suo campo visivo in un raggio di 9 metri. Se il bersaglio è in grado di vedere il solar, deve superare un tiro salvezza su Costituzione con CD 15, altrimenti è accecato finché una magia come *ristorare inferiore* non rimuove la cecità.",
			""),
		new Text(
			"Solar",
			null,
			"Large celestial, lawful good",
			"21 (natural armor)",
			"50 ft., fly 150 ft.",
			"Int +14, Wis +14, Cha +17",
			"Perception +14",
			"",
			"radiant; bludgeoning, piercing, and slashing from nonmagical weapons",
			"necrotic, poison",
			"charmed, exhaustion, frightened, poisoned",
			"truesight 120 ft., passive Perception 24",
			"all, telepathy 120 ft.",
			"***Angelic Weapons.*** The solar's weapon attacks are magical. When the solar hits with any weapon, the weapon deals an extra 6d8 radiant damage (included in the attack).\n\n***Divine Awareness.*** The solar knows if it hears a lie.\n\n***Innate Spellcasting.*** The solar's spell casting ability is Charisma (spell save DC 25). It can innately cast the following spells, requiring no material components:\n\n- At will: *detect evil and good, invisibility (self only)*\n- 3/day each: *blade barrier, dispel evil and good, resurrection*\n- 1/day each: *commune, control weather*\n\n***Magic Resistance.*** The solar has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The solar makes two greatsword attacks.\n\n***Greatsword.*** *Melee Weapon Attack:* +15 to hit, reach 5 ft., one target. *Hit:* 22 (4d6 + 8) slashing damage plus 27 (6d8) radiant damage.\n\n***Slaying Longbow.*** *Ranged Weapon Attack:* +13 to hit, range 150/600 ft., one target. *Hit:* 15 (2d8 + 6) piercing damage plus 27 (6d8) radiant damage. If the target is a creature that has 190 hit points or fewer, it must succeed on a DC 15 Constitution saving throw or die.\n\n***Flying Sword.*** The solar releases its greatsword to hover magically in an unoccupied space within 5 ft. of it. If the solar can see the sword, the solar can mentally command it as a bonus action to fly up to 50 ft. and either make one attack against a target or return to the solar's hands. If the hovering sword is targeted by any effect, the solar is considered to be holding it. The hovering sword falls if the solar dies.\n\n***Healing Touch (4/Day).*** The solar touches another creature. The target magically regains 40 (8d8 + 4) hit points and is freed from any curse, disease, poison, blindness, or deafness.",
			"",
			"",
			"The solar can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The solar regains spent legendary actions at the start of its turn.\n\n***Teleport.*** The solar magically teleports, along with any equipment it is wearing or carrying, up to 120 ft. to an unoccupied space it can see.\n\n***Searing Burst (Costs 2 Actions).*** The solar emits magical, divine energy. Each creature of its choice in a 10-foot radius must make a DC 23 Dexterity saving throw, taking 14 (4d6) fire damage plus 14 (4d6) radiant damage on a failed save, or half as much damage on a successful one.\n\n***Blinding Gaze (Costs 3 Actions).*** The solar targets one creature it can see within 30 ft. of it. If the target can see it, the target must succeed on a DC 15 Constitution saving throw or be blinded until magic such as the lesser restoration spell removes the blindness.",
			""));
}
