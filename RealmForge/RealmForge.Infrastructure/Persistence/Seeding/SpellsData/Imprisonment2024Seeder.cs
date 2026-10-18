using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Imprisonment (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Imprisonment2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "imprisonment");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "imprisonment", "en"),
					Language = LanguageCode.En,
					Name = "Imprisonment",
					CastingTime = "1 minute",
					Range = "30 feet",
					Duration = "Until dispelled",
					MaterialComponent = "a statuette of the target worth 5,000+ GP",
					Description = "You create a magical restraint to hold a creature that you can see within range. The target must make a Wisdom saving throw. On a successful save, the target is unaffected, and it is immune to this spell for the next 24 hours. On a failed save, the target is imprisoned. While imprisoned, the target doesn't need to breathe, eat, or drink, and it doesn't age. Divination spells can't locate or perceive the imprisoned target, and the target can't teleport.\n\nUntil the spell ends, the target is also affected by one of the following effects of your choice:\n\n**Burial.** The target is entombed beneath the earth in a hollow globe of magical force that is just large enough to contain the target. Nothing can pass into or out of the globe.\n\n**Chaining.** Chains firmly rooted in the ground hold the target in place. The target has the Restrained condition and can't be moved by any means.\n\n**Hedged Prison.** The target is trapped in a demiplane that is warded against teleportation and planar travel. The demiplane is your choice of a labyrinth, a cage, a tower, or the like.\n\n**Minimus Containment.** The target becomes 1 inch tall and is trapped inside an indestructible gemstone or a similar object. Light can pass through the gemstone (allowing the target to see out and other creatures to see in), but nothing else can pass through by any means.\n\n**Slumber.** The target has the Unconscious condition and can't be awoken.\n\n***Ending the Spell.*** When you cast the spell, specify a trigger that will end it. The trigger can be as simple or as elaborate as you choose, but the GM must agree that it has a high likelihood of happening within the next decade. The trigger must be an observable action, such as someone making a particular offering at the temple of your god, saving your true love, or defeating a specific monster.\n\nA *Dispel Magic* spell can end the spell only if it is cast with a level 9 spell slot, targeting either the prison or the component used to create it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "imprisonment", "it"),
					Language = LanguageCode.It,
					Name = "Imprigionare",
					CastingTime = "1 minuto",
					Range = "9 metri",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "una statuetta raffigurante il bersaglio del valore di almeno 5.000 mo",
					Description = "L'incantatore crea un vincolo magico per imprigionare una creatura entro gittata che è in grado di vedere. Il bersaglio deve effettuare un tiro salvezza su Saggezza. Se lo supera, il bersaglio non viene influenzato ed è immune a questo incantesimo per le 24 ore successive. Se lo fallisce, il bersaglio viene imprigionato. Finché è imprigionato, il bersaglio non ha bisogno di respirare, mangiare o bere e non invecchia. Gli incantesimi di divinazione non possono localizzare né percepire il bersaglio imprigionato, e il bersaglio non può teletrasportarsi.\n\nFinché l'incantesimo non termina, il bersaglio è inoltre soggetto a uno degli effetti seguenti, a scelta dell'incantatore:\n\n**Sepoltura.** Il bersaglio viene sepolto sottoterra in un globo cavo di forza magica, grande quanto basta per contenerlo. Nulla può entrare nel globo o uscirne.\n\n**Incatenamento.** Catene saldamente ancorate al terreno tengono il bersaglio fermo sul posto. Il bersaglio è trattenuto e non può essere spostato con alcun mezzo.\n\n**Prigione Recintata.** Il bersaglio viene intrappolato in un semipiano protetto contro il teletrasporto e i viaggi planari. Il semipiano è, a scelta dell'incantatore, un labirinto, una gabbia, una torre o qualcosa di simile.\n\n**Contenimento Minimo.** Il bersaglio diventa alto 2,5 centimetri e viene intrappolato all'interno di una gemma indistruttibile o di un oggetto simile. La luce può attraversare la gemma (permettendo al bersaglio di vedere fuori e alle altre creature di vedere dentro), ma nient'altro può attraversarla con alcun mezzo.\n\n**Sopore.** Il bersaglio è privo di sensi e non può essere svegliato.\n\n***Porre Fine all'Incantesimo.*** Quando lancia l'incantesimo, l'incantatore stabilisce un innesco che vi porrà fine. L'innesco può essere semplice o elaborato quanto desidera, ma il DM deve concordare che abbia un'alta probabilità di verificarsi entro il decennio successivo. L'innesco deve essere un'azione osservabile, come qualcuno che fa una determinata offerta al tempio del dio dell'incantatore, salvare il suo vero amore o sconfiggere un mostro specifico.\n\nUn incantesimo *dissolvi magie* può porre fine all'incantesimo soltanto se viene lanciato con uno slot incantesimo di 9° livello, prendendo come bersaglio la prigione o la componente usata per crearla.",
					HigherLevels = null
				}
			}
		};
	}
}
