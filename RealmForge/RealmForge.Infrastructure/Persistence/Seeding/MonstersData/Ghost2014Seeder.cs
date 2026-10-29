using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ghost (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Ghost2014Seeder
{
	public static Monster Build() => Create("ghost", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Undead,
		11, 45, "10d8", 0, new[] { 7, 13, 10, 10, 12, 17 }, 4m, 1100, 2, 11,
		new Text(
			"Fantasma",
			null,
			"Non morto Medio, qualsiasi allineamento",
			"11",
			"0 m, volare 12 m (fluttuare)",
			"",
			"",
			"",
			"acido, fulmine, fuoco, tuono; contundenti, perforanti e taglienti da attacchi non magici",
			"freddo, necrotico, veleno",
			"affascinato, afferrato, avvelenato, indebolimento, paralizzato, pietrificato, prono, spaventato, trattenuto",
			"Percezione passiva 11, scurovisione 18 m",
			"tutti quelli conosciuti in vita",
			"***Movimento incorporeo.*** Il fantasma può muoversi attraverso altri oggetti o creature come se fossero terreno difficile. Subisce 5 (1d10) danni da forza se termina il proprio turno all'interno di un oggetto.\n\n***Vista eterea.*** Il fantasma può vedere per 18 metri sul Piano Etereo quando si trova sul Piano Materiale e viceversa.",
			"***Tocco inaridente.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 17 (4d6 + 3) danni necrotici.\n\n***Forma eterea.*** Il fantasma entra nel Piano Etereo dal Piano Materiale o viceversa. È visibile sul Piano Materiale finché si trova sul Confine Etereo e viceversa, ma non può influenzare o essere influenzato da nulla sull'altro piano.\n\n***Possessione (ricarica 6).*** Un umanoide nel campo visivo del fantasma in un raggio di 1,5 metri da lui deve superare un tiro salvezza su Carisma con CD 13, altrimenti viene posseduto; poi il fantasma scompare e il bersaglio è incapacitato e perde il controllo del suo corpo. Ora il fantasma controlla il corpo del bersaglio, ma senza privarlo della sua consapevolezza. Il fantasma non può essere bersagliato da nessun attacco, incantesimo o altro effetto, a eccezione di quelli che scacciano i non morti, e conserva allineamento, Intelligenza, Saggezza, Carisma e immunità alle condizioni affascinato e spaventato. Altrimenti, utilizza le statistiche del bersaglio posseduto, ma non può accedere ai suoi privilegi di classe, alle sue conoscenze o competenze. La possessione dura finché il corpo non scende a 0 punti ferita, finché il fantasma non la termina usando un'azione bonus oppure finché non viene scacciato o espulso dal corpo da un effetto come l'incantesimo *dissolvi il bene e il male.* Quando termina la possessione, il fantasma ricompare in uno spazio libero entro 1,5 metri dal corpo. Il bersaglio è immune alla possessione di questo fantasma per 24 ore dopo avere superato il tiro salvezza o dopo che la possessione è terminata.\n\n***Volto terrificante.*** Ogni creatura che non sia un non morto, situata entro 18 metri dal fantasma e che sia in grado di vederlo, deve superare un tiro salvezza su Saggezza con CD 13, altrimenti è spaventata per 1 minuto. Se fallisce il tiro salvezza di 5 o più, il bersaglio invecchia anche di 1d4 × 10 anni. Il bersaglio spaventato può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce. Se il bersaglio supera il tiro salvezza o se l'effetto termina, è immune al Volto terrificante di questo fantasma per le 24 ore successive. L'effetto di invecchiamento può essere invertito con un incantesimo *ristorare superiore,* ma soltanto entro 24 ore dal momento in cui è stato subito.",
			"",
			"",
			"",
			""),
		new Text(
			"Ghost",
			null,
			"Medium undead, any alignment",
			"11",
			"0 ft., fly 40 ft. (hover)",
			"",
			"",
			"",
			"acid, fire, lightning, thunder; bludgeoning, piercing, and slashing from nonmagical weapons",
			"cold, necrotic, poison",
			"charmed, exhaustion, frightened, grappled, paralyzed, petrified, poisoned, prone, restrained",
			"darkvision 60 ft., passive Perception 11",
			"any languages it knew in life",
			"***Ethereal Sight.*** The ghost can see 60 ft. into the Ethereal Plane when it is on the Material Plane, and vice versa.\n\n***Incorporeal Movement.*** The ghost can move through other creatures and objects as if they were difficult terrain. It takes 5 (1d10) force damage if it ends its turn inside an object.",
			"***Withering Touch.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 17 (4d6 + 3) necrotic damage.\n\n***Etherealness.*** The ghost enters the Ethereal Plane from the Material Plane, or vice versa. It is visible on the Material Plane while it is in the Border Ethereal, and vice versa, yet it can't affect or be affected by anything on the other plane.\n\n***Horrifying Visage.*** Each non-undead creature within 60 ft. of the ghost that can see it must succeed on a DC 13 Wisdom saving throw or be frightened for 1 minute. If the save fails by 5 or more, the target also ages 1d4 × 10 years. A frightened target can repeat the saving throw at the end of each of its turns, ending the frightened condition on itself on a success. If a target's saving throw is successful or the effect ends for it, the target is immune to this ghost's Horrifying Visage for the next 24 hours. The aging effect can be reversed with a greater restoration spell, but only within 24 hours of it occurring.\n\n***Possession (Recharge 6).*** One humanoid that the ghost can see within 5 ft. of it must succeed on a DC 13 Charisma saving throw or be possessed by the ghost; the ghost then disappears, and the target is incapacitated and loses control of its body. The ghost now controls the body but doesn't deprive the target of awareness. The ghost can't be targeted by any attack, spell, or other effect, except ones that turn undead, and it retains its alignment, Intelligence, Wisdom, Charisma, and immunity to being charmed and frightened. It otherwise uses the possessed target's statistics, but doesn't gain access to the target's knowledge, class features, or proficiencies.\n\nThe possession lasts until the body drops to 0 hit points, the ghost ends it as a bonus action, or the ghost is turned or forced out by an effect like the dispel evil and good spell. When the possession ends, the ghost reappears in an unoccupied space within 5 ft. of the body. The target is immune to this ghost's Possession for 24 hours after succeeding on the saving throw or after the possession ends.",
			"",
			"",
			"",
			""));
}
