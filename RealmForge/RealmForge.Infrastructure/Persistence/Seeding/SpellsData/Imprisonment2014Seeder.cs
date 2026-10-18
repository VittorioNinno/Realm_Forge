using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Imprisonment (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Imprisonment2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "imprisonment");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 9,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "imprisonment", "en"),
					Language = LanguageCode.En,
					Name = "Imprisonment",
					CastingTime = "1 minute",
					Range = "30 feet",
					Duration = "Until dispelled",
					MaterialComponent = "a vellum depiction or a carved statuette in the likeness of the target, and a special component that varies according to the version of the spell you choose, worth at least 500 gp per Hit Die of the target",
					Description = "You create a magical restraint to hold a creature that you can see within range. The target must succeed on a Wisdom saving throw or be bound by the spell; if it succeeds, it is immune to this spell if you cast it again. While affected by this spell, the creature doesn't need to breathe, eat, or drink, and it doesn't age. Divination spells can't locate or perceive the target.\n\nWhen you cast the spell, you choose one of the following forms of imprisonment.\n\n***Burial.*** The target is entombed far beneath the earth in a sphere of magical force that is just large enough to contain the target. Nothing can pass through the sphere, nor can any creature teleport or use planar travel to get into or out of it.\n\nThe special component for this version of the spell is a small mithral orb.\n\n***Chaining.*** Heavy chains, firmly rooted in the ground, hold the target in place. The target is restrained until the spell ends, and it can't move or be moved by any means until then.\n\nThe special component for this version of the spell is a fine chain of precious metal.\n\n***Hedged Prison.*** The spell transports the target into a tiny demiplane that is warded against teleportation and planar travel. The demiplane can be a labyrinth, a cage, a tower, or any similar confined structure or area of your choice.\n\nThe special component for this version of the spell is a miniature representation of the prison made from jade.\n\n***Minimus Containment.*** The target shrinks to a height of 1 inch and is imprisoned inside a gemstone or similar object. Light can pass through the gemstone normally (allowing the target to see out and other creatures to see in), but nothing else can pass through, even by means of teleportation or planar travel. The gemstone can't be cut or broken while the spell remains in effect.\n\nThe special component for this version of the spell is a large, transparent gemstone, such as a corundum, diamond, or ruby.\n\n***Slumber.*** The target falls asleep and can't be awoken.\n\nThe special component for this version of the spell consists of rare soporific herbs.\n\n***Ending the Spell.*** During the casting of the spell, in any of its versions, you can specify a condition that will cause the spell to end and release the target. The condition can be as specific or as elaborate as you choose, but the GM must agree that the condition is reasonable and has a likelihood of coming to pass. The conditions can be based on a creature's name, identity, or deity but otherwise must be based on observable actions or qualities and not based on intangibles such as level, class, or hit points.\n\nA dispel magic spell can end the spell only if it is cast as a 9th-level spell, targeting either the prison or the special component used to create it.\n\nYou can use a particular special component to create only one prison at a time. If you cast the spell again using the same component, the target of the first casting is immediately freed from its binding.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "imprisonment", "it"),
					Language = LanguageCode.It,
					Name = "Imprigionare",
					CastingTime = "1 minuto",
					Range = "9 metri",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "una raffigurazione su pergamena o una statuetta scolpita che ritrae il bersaglio, e una componente speciale che varia a seconda della versione dell'incantesimo scelta, del valore di almeno 500 mo per ogni Dado Vita del bersaglio",
					Description = "L'incantatore crea un vincolo magico per imprigionare una creatura entro gittata che sia in grado di vedere. Il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è vincolato dall'incantesimo; se lo supera, è immune a questo incantesimo se l'incantatore lo lancia di nuovo. Finché è influenzata da questo incantesimo, la creatura non ha bisogno di respirare, mangiare o bere, e non invecchia. Gli incantesimi di divinazione non possono localizzare né percepire il bersaglio.\n\nQuando lancia l'incantesimo, l'incantatore sceglie una delle forme di prigionia seguenti.\n\n***Sepoltura.*** Il bersaglio viene sepolto nelle profondità della terra, all'interno di una sfera di forza magica grande appena quanto basta per contenerlo. Nulla può attraversare la sfera, e nessuna creatura può teletrasportarsi o usare i viaggi planari per entrarvi o uscirne.\n\nLa componente speciale per questa versione dell'incantesimo è un piccolo globo di mithral.\n\n***Incatenamento.*** Pesanti catene, saldamente ancorate al terreno, tengono fermo il bersaglio. Il bersaglio è trattenuto finché l'incantesimo non termina e fino ad allora non può muoversi né essere spostato con alcun mezzo.\n\nLa componente speciale per questa versione dell'incantesimo è una sottile catena di metallo prezioso.\n\n***Prigione Recintata.*** L'incantesimo trasporta il bersaglio in un minuscolo semipiano protetto contro il teletrasporto e i viaggi planari. Il semipiano può essere un labirinto, una gabbia, una torre o qualsiasi struttura o area chiusa simile a scelta dell'incantatore.\n\nLa componente speciale per questa versione dell'incantesimo è una riproduzione in miniatura della prigione, fatta di giada.\n\n***Contenimento Minimo.*** Il bersaglio si rimpicciolisce fino a un'altezza di 2,5 cm e viene imprigionato all'interno di una gemma o di un oggetto simile. La luce può attraversare normalmente la gemma (permettendo al bersaglio di vedere fuori e alle altre creature di vedere dentro), ma nient'altro può attraversarla, nemmeno tramite il teletrasporto o i viaggi planari. La gemma non può essere tagliata né rotta finché l'incantesimo rimane attivo.\n\nLa componente speciale per questa versione dell'incantesimo è una grande gemma trasparente, come un corindone, un diamante o un rubino.\n\n***Sopore.*** Il bersaglio si addormenta e non può essere svegliato.\n\nLa componente speciale per questa versione dell'incantesimo consiste in rare erbe soporifere.\n\n***Fine dell'Incantesimo.*** Durante il lancio dell'incantesimo, in qualsiasi sua versione, l'incantatore può specificare una condizione che farà terminare l'incantesimo e libererà il bersaglio. La condizione può essere specifica o elaborata quanto l'incantatore desidera, ma il DM deve concordare sul fatto che sia ragionevole e che abbia una certa probabilità di verificarsi. Le condizioni possono basarsi sul nome, sull'identità o sulla divinità di una creatura, ma per il resto devono basarsi su azioni o qualità osservabili e non su elementi intangibili come il livello, la classe o i punti ferita.\n\nUn incantesimo dissolvi magie può porre fine all'incantesimo soltanto se viene lanciato come incantesimo di 9° livello, bersagliando la prigione o la componente speciale usata per crearla.\n\nL'incantatore può usare una particolare componente speciale per creare soltanto una prigione alla volta. Se lancia di nuovo l'incantesimo usando la stessa componente, il bersaglio del primo lancio viene immediatamente liberato dal suo vincolo.",
					HigherLevels = null
				}
			}
		};
	}
}
