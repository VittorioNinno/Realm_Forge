using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Death Tyrant (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class DeathTyrant2014Seeder
{
	public static Monster Build() => Create("death-tyrant", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Undead,
		19, 187, "25d10 + 50", 0, new[] { 10, 14, 14, 19, 15, 19 }, 14m, 11500, 5, 22,
		new Text(
			"Tiranno della morte",
			null,
			"Non morto Grande, legale malvagio",
			"19 (armatura naturale)",
			"0 m, volare 6 m (fluttuare)",
			"Car +9, Cos +7, For +5, Int +9, Sag +7",
			"Percezione +12",
			"",
			"",
			"veleno",
			"affascinato, avvelenato, indebolimento, paralizzato, pietrificato, prono",
			"Percezione passiva 22, scurovisione 36 m",
			"Gergo delle profondità, Sottocomune",
			"***Cono di energia negativa.*** L'occhio centrale del tiranno della morte emana un cono invisibile e magico di energia negativa di 45 metri; all'inizio di ogni suo turno il tiranno decide dove orientarlo e se tenerlo attivo. Le creature nel cono non possono recuperare punti ferita. Un umanoide che vi muore si rialza come zombi agli ordini del tiranno all'inizio del suo turno successivo, mantenendo il suo posto nell'ordine di iniziativa, a meno che il suo corpo non sia stato distrutto del tutto.",
			"***Morso.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (4d6) danni perforanti.\n\n***Raggi oculari.*** Il tiranno della morte spara tre diversi raggi oculari magici scelti a caso (si ritira un risultato già uscito), contro uno, due o tre bersagli che è in grado di vedere entro 36 metri da lui:\n\n1. *Raggio ammaliante.* Il bersaglio effettua un tiro salvezza su Saggezza con CD 17. Se lo fallisce è affascinato dal tiranno per 1 ora, o finché il tiranno non gli fa del male.\n2. *Raggio paralizzante.* Il bersaglio effettua un tiro salvezza su Costituzione con CD 17, altrimenti è paralizzato per 1 minuto. Ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.\n3. *Raggio della paura.* Il bersaglio effettua un tiro salvezza su Saggezza con CD 17, altrimenti è spaventato per 1 minuto. Ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.\n4. *Raggio rallentante.* Il bersaglio effettua un tiro salvezza su Destrezza con CD 17. Se lo fallisce, per 1 minuto la sua velocità è dimezzata, non può effettuare reazioni e nel suo turno può effettuare un'azione o un'azione bonus, non entrambe. Ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.\n5. *Raggio snervante.* Il bersaglio effettua un tiro salvezza su Costituzione con CD 17 e subisce 36 (8d8) danni necrotici se lo fallisce, o la metà se lo supera.\n6. *Raggio telecinetico.* Una creatura colpita da questo raggio effettua un tiro salvezza su Forza con CD 17; se lo fallisce il tiranno la sposta fino a 9 metri in qualsiasi direzione, e resta trattenuta dalla presa telecinetica fino all'inizio del turno successivo del tiranno o finché questo non è incapacitato. Un oggetto di 150 kg o meno che nessuno indossa o trasporta viene semplicemente spostato fino a 9 metri; con questo raggio il tiranno può anche maneggiare oggetti con precisione, ad esempio usare un attrezzo semplice o aprire una porta o un contenitore.\n7. *Raggio del sonno.* Il bersaglio effettua un tiro salvezza su Saggezza con CD 17, altrimenti cade addormentato, privo di sensi, per 1 minuto; si sveglia se subisce danni o se un'altra creatura usa un'azione per svegliarlo. Costrutti e non morti sono immuni a questo raggio.\n8. *Raggio pietrificante.* Il bersaglio effettua un tiro salvezza su Destrezza con CD 17. Se lo fallisce comincia a trasformarsi in pietra ed è trattenuto; alla fine del suo turno successivo ripete il tiro salvezza: con un successo l'effetto termina, con un fallimento resta pietrificato finché l'incantesimo *ristorare superiore* o un'altra magia non lo libera.\n9. *Raggio disintegrante.* Una creatura effettua un tiro salvezza su Destrezza con CD 17, altrimenti subisce 45 (10d8) danni da forza; se questi danni la portano a 0 punti ferita, il suo corpo diventa polvere grigia sottile. Un oggetto non magico o una creazione di forza magica di taglia Grande o inferiore viene disintegrato senza tiro salvezza; se è Enorme o più grande, il raggio ne disintegra un cubo di 3 metri di lato.\n10. *Raggio della morte.* Il bersaglio effettua un tiro salvezza su Destrezza con CD 17, altrimenti subisce 55 (10d10) danni necrotici. Se questi danni lo portano a 0 punti ferita, muore.",
			"",
			"",
			"Il tiranno della morte può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il tiranno della morte recupera le azioni leggendarie effettuate.\n\n***Raggio oculare.*** Il tiranno della morte spara un raggio oculare scelto a caso.",
			""),
		new Text(
			"Death Tyrant",
			null,
			"Large undead, lawful evil",
			"19 (natural armor)",
			"0 ft., fly 20 ft. (hover)",
			"Str +5, Con +7, Int +9, Wis +7, Cha +9",
			"Perception +12",
			"",
			"",
			"poison",
			"charmed, exhaustion, paralyzed, petrified, poisoned, prone",
			"darkvision 120 ft., passive Perception 22",
			"Deep Speech, Undercommon",
			"***Negative Energy Cone.*** The death tyrant's central eye emits an invisible, magical 150-foot cone of negative energy; at the start of each of its turns the tyrant decides where it points and whether it is active. Creatures in the cone can't regain hit points. A humanoid that dies in it rises as a zombie obeying the tyrant at the start of its next turn, keeping its place in the initiative order, unless its body has been completely destroyed.",
			"***Bite.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 14 (4d6) piercing damage.\n\n***Eye Rays.*** The death tyrant fires three different magical eye rays chosen at random (reroll any duplicate), at one to three targets it can see within 120 feet of it:\n\n1. *Charm Ray.* The target makes a DC 17 Wisdom saving throw. On a failure, it is charmed by the tyrant for 1 hour, or until the tyrant harms it.\n2. *Paralyzing Ray.* The target makes a DC 17 Constitution saving throw or is paralyzed for 1 minute. It repeats the save at the end of each of its turns, ending the effect on a success.\n3. *Fear Ray.* The target makes a DC 17 Wisdom saving throw or is frightened for 1 minute. It repeats the save at the end of each of its turns, ending the effect on a success.\n4. *Slowing Ray.* The target makes a DC 17 Dexterity saving throw. On a failure, for 1 minute its speed is halved, it can't take reactions, and on its turn it can take an action or a bonus action, not both. It repeats the save at the end of each of its turns, ending the effect on a success.\n5. *Enervation Ray.* The target makes a DC 17 Constitution saving throw, taking 36 (8d8) necrotic damage on a failure, or half as much on a success.\n6. *Telekinetic Ray.* A creature hit by this ray makes a DC 17 Strength saving throw; on a failure the tyrant moves it up to 30 feet in any direction, and it stays restrained by the telekinetic grip until the start of the tyrant's next turn or until the tyrant is incapacitated. An object of 300 pounds or less that nobody is wearing or carrying is simply moved up to 30 feet; the tyrant can also handle objects finely with this ray, for example using a simple tool or opening a door or a container.\n7. *Sleep Ray.* The target makes a DC 17 Wisdom saving throw or falls asleep, unconscious, for 1 minute; it wakes up if it takes damage or if another creature uses an action to wake it. Constructs and undead are immune to this ray.\n8. *Petrification Ray.* The target makes a DC 17 Dexterity saving throw. On a failure it starts turning to stone and is restrained; at the end of its next turn it repeats the save, ending the effect on a success or becoming petrified on a failure, until the greater restoration spell or other magic frees it.\n9. *Disintegration Ray.* A creature makes a DC 17 Dexterity saving throw or takes 45 (10d8) force damage; if this drops it to 0 hit points, its body turns into fine gray dust. A Large or smaller nonmagical object or creation of magical force is disintegrated with no save; against a Huge or larger one, the ray disintegrates a 10-foot cube of it.\n10. *Death Ray.* The target makes a DC 17 Dexterity saving throw or takes 55 (10d10) necrotic damage. If this damage drops it to 0 hit points, it dies.",
			"",
			"",
			"The death tyrant can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The death tyrant regains spent legendary actions at the start of its turn.\n\n***Eye Ray.*** The death tyrant fires one random eye ray.",
			""));
}
