using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Kraken (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Kraken2014Seeder
{
	public static Monster Build() => Create("kraken", null, ContentSource.Srd51, CreatureSize.Gargantuan, CreatureType.Monstrosity,
		18, 472, "27d20 + 189", 20, new[] { 30, 11, 25, 22, 18, 20 }, 23m, 50000, 7, 14,
		new Text(
			"Kraken",
			null,
			"Mostruosità Mastodontica (titano), caotico malvagio",
			"18 (armatura naturale)",
			"6 m, nuotare 18 m",
			"For +17, Des +7, Cos +14, Int +13, Sag +11",
			"",
			"",
			"",
			"fulmine; contundenti, perforanti e taglienti da attacchi non magici",
			"paralizzato, spaventato",
			"Percezione passiva 14, vista pura 36 m",
			"capisce l'Abissale, il Celestiale, l'Infernale e il Primordiale ma non li parla, telepatia 36 m",
			"***Anfibio.*** Il kraken può respirare in aria e in acqua.\n\n***Libertà di movimento.*** Il kraken ignora il terreno difficile e gli effetti magici non possono ridurre la sua velocità o trattenerlo. Può spendere 1,5 metri di movimento per liberarsi dalle costrizioni non magiche o dall'essere afferrato.\n\n***Mostro da assedio.*** Il kraken infligge danni doppi agli oggetti e alle strutture.",
			"***Multiattacco.*** Il kraken effettua tre attacchi con i tentacoli; ognuno può essere sostituito con un uso di Scagliare.\n\n***Morso.*** *Attacco con arma da mischia:* +17 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 23 (3d8 + 10) danni perforanti. Se il bersaglio afferrato è una creatura di taglia Grande o inferiore, viene inghiottito e il kraken molla la presa. Mentre è inghiottita, la creatura è accecata e trattenuta, beneficia di copertura totale contro gli attacchi e altri effetti al di fuori del kraken, e subisce 42 (12d6) danni da acido all'inizio di ogni turno del mostro. Se il kraken subisce 50 o più danni in un singolo turno da una creatura al suo interno, deve superare un tiro salvezza su Costituzione con CD 25 alla fine di quel turno, altrimenti rigurgita tutte le creature inghiottite, che cadono prone in uno spazio entro 3 metri da lui. Se il kraken muore, la creatura inghiottita non è più trattenuta dal mostro e può sfuggire usando 4,5 metri di movimento, uscendo prona dal mostro.\n\n***Tentacolo.*** *Attacco con arma da mischia:* +17 al tiro per colpire, portata 9 m, un bersaglio. *Colpito:* 20 (3d6 + 10) danni contundenti e il bersaglio è afferrato (CD 18 per sfuggire). Finché la presa perdura, il bersaglio viene trattenuto. Il kraken ha dieci tentacoli, ognuno dei quali può afferrare un bersaglio.\n\n***Scagliare.*** Un oggetto impugnato o una creatura afferrata dal kraken di taglia Grande o inferiore viene scagliato a un'altezza massima di 18 metri in una direzione casuale e gettato a terra prono. Se un bersaglio scagliato colpisce una superficie solida, subisce 3 (1d6) danni contundenti per ogni 3 metri di cui è stato scagliato. Se il bersaglio viene lanciato contro un'altra creatura, quest'ultima deve superare un tiro salvezza su Destrezza con CD 18, altrimenti subirà gli stessi danni e cadrà a terra prona.\n\n***Tempesta di fulmini.*** Il kraken crea magicamente tre fulmini, ognuno dei quali può colpire un bersaglio nel suo campo visivo in un raggio di 36 metri. Il bersaglio deve effettuare un tiro salvezza su Destrezza con CD 23, subendo 22 (4d10) danni da fulmine in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			"",
			"Il kraken può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il kraken recupera le azioni leggendarie effettuate.\n\n***Attacco Tentacolo o Scagliare.*** Il kraken effettua un attacco con i tentacoli o usa Scagliare.\n\n***Tempesta di fulmini (costa 2 azioni).*** Il kraken usa tempesta di fulmini.\n\n***Nebbia di inchiostro (costa 3 azioni).*** Mentre è sott'acqua, il kraken espelle una nube d'inchiostro nel raggio di 18 metri. La nube si diffonde nell'ambiente e quell'area è pesantemente oscurata per tutte le creature tranne il kraken. Ogni creatura diversa dal kraken che termina il proprio turno in quell'area deve effettuare un tiro salvezza su Costituzione con CD 23, subendo 16 (3d10) danni da veleno in caso di fallimento, o la metà in caso di successo. Una corrente forte disperde la nube, che altrimenti si dissipa alla fine del turno successivo del kraken.",
			""),
		new Text(
			"Kraken",
			null,
			"Gargantuan monstrosity (titan), chaotic evil",
			"18 (natural armor)",
			"20 ft., swim 60 ft.",
			"Str +17, Dex +7, Con +14, Int +13, Wis +11",
			"",
			"",
			"",
			"lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"frightened, paralyzed",
			"truesight 120 ft., passive Perception 14",
			"understands Abyssal, Celestial, Infernal, and Primordial but can't speak, telepathy 120 ft.",
			"***Amphibious.*** The kraken can breathe air and water.\n\n***Freedom of Movement.*** The kraken ignores difficult terrain, and magical effects can't reduce its speed or cause it to be restrained. It can spend 5 feet of movement to escape from nonmagical restraints or being grappled.\n\n***Siege Monster.*** The kraken deals double damage to objects and structures.",
			"***Multiattack.*** The kraken makes three tentacle attacks, each of which it can replace with one use of Fling.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 23 (3d8 + 10) piercing damage. If the target is a Large or smaller creature grappled by the kraken, that creature is swallowed, and the grapple ends. While swallowed, the creature is blinded and restrained, it has total cover against attacks and other effects outside the kraken, and it takes 42 (12d6) acid damage at the start of each of the kraken's turns. If the kraken takes 50 damage or more on a single turn from a creature inside it, the kraken must succeed on a DC 25 Constitution saving throw at the end of that turn or regurgitate all swallowed creatures, which fall prone in a space within 10 feet of the kraken. If the kraken dies, a swallowed creature is no longer restrained by it and can escape from the corpse using 15 feet of movement, exiting prone.\n\n***Tentacle.*** *Melee Weapon Attack:* +7 to hit, reach 30 ft., one target. *Hit:* 20 (3d6 + 10) bludgeoning damage, and the target is grappled (escape DC 18). Until this grapple ends, the target is restrained. The kraken has ten tentacles, each of which can grapple one target.\n\n***Fling.*** One Large or smaller object held or creature grappled by the kraken is thrown up to 60 feet in a random direction and knocked prone. If a thrown target strikes a solid surface, the target takes 3 (1d6) bludgeoning damage for every 10 feet it was thrown. If the target is thrown at another creature, that creature must succeed on a DC 18 Dexterity saving throw or take the same damage and be knocked prone.\n\n***Lightning Storm.*** The kraken magically creates three bolts of lightning, each of which can strike a target the kraken can see within 120 feet of it. A target must make a DC 23 Dexterity saving throw, taking 22 (4d10) lightning damage on a failed save, or half as much damage on a successful one.",
			"",
			"",
			"The kraken can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The kraken regains spent legendary actions at the start of its turn.\n\n***Tentacle Attack or Fling.*** The kraken makes one tentacle attack or uses its Fling.\n\n***Lightning Storm (Costs 2 Actions).*** The kraken uses Lightning Storm.\n\n***Ink Cloud (Costs 3 Actions).*** While underwater, the kraken expels an ink cloud in a 60-foot radius. The cloud spreads around corners, and that area is heavily obscured to creatures other than the kraken. Each creature other than the kraken that ends its turn there must succeed on a DC 23 Constitution saving throw, taking 16 (3d10) poison damage on a failed save, or half as much damage on a successful one. A strong current disperses the cloud, which otherwise disappears at the end of the kraken's next turn.",
			""));
}
