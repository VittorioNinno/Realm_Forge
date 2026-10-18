using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Programmed Illusion (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ProgrammedIllusion2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "programmed-illusion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "programmed-illusion", "en"),
					Language = LanguageCode.En,
					Name = "Programmed Illusion",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Until dispelled",
					MaterialComponent = "a bit of fleece and jade dust worth at least 25 gp",
					Description = "You create an illusion of an object, a creature, or some other visible phenomenon within range that activates when a specific condition occurs. The illusion is imperceptible until then. It must be no larger than a 30-foot cube, and you decide when you cast the spell how the illusion behaves and what sounds it makes. This scripted performance can last up to 5 minutes.\n\nWhen the condition you specify occurs, the illusion springs into existence and performs in the manner you described. Once the illusion finishes performing, it disappears and remains dormant for 10 minutes. After this time, the illusion can be activated again.\n\nThe triggering condition can be as general or as detailed as you like, though it must be based on visual or audible conditions that occur within 30 feet of the area. For example, you could create an illusion of yourself to appear and warn off others who attempt to open a trapped door, or you could set the illusion to trigger only when a creature says the correct word or phrase.\n\nPhysical interaction with the image reveals it to be an illusion, because things can pass through it. A creature that uses its action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the creature can see through the image, and any noise it makes sounds hollow to the creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "programmed-illusion", "it"),
					Language = LanguageCode.It,
					Name = "Illusione Programmata",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "un po' di vello e polvere di giada del valore di almeno 25 mo",
					Description = "L'incantatore crea entro gittata l'illusione di un oggetto, di una creatura o di un altro fenomeno visibile, che si attiva quando si verifica una condizione specifica. Fino ad allora l'illusione è impercettibile. Non può essere più grande di un cubo con spigolo di 9 metri, e al momento del lancio l'incantatore decide come si comporta l'illusione e quali suoni produce. Questa rappresentazione programmata può durare fino a 5 minuti.\n\nQuando si verifica la condizione specificata, l'illusione si materializza e si comporta nel modo descritto dall'incantatore. Una volta terminata la rappresentazione, l'illusione scompare e rimane inattiva per 10 minuti. Trascorso questo tempo, l'illusione può essere attivata di nuovo.\n\nLa condizione di attivazione può essere generica o dettagliata quanto l'incantatore desidera, ma deve basarsi su condizioni visive o udibili che si verificano entro 9 metri dall'area. Per esempio, l'incantatore potrebbe creare un'illusione di sé stesso che compare e mette in guardia chi tenta di aprire una porta protetta da una trappola, oppure potrebbe impostare l'illusione in modo che si attivi soltanto quando una creatura pronuncia la parola o la frase corretta.\n\nL'interazione fisica con l'immagine rivela che si tratta di un'illusione, perché le cose possono attraversarla. Una creatura che usa la sua azione per esaminare l'immagine può capire che si tratta di un'illusione superando una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se una creatura riconosce l'illusione per ciò che è, può vedere attraverso l'immagine, e qualsiasi rumore prodotto dall'immagine le suona vuoto.",
					HigherLevels = null
				}
			}
		};
	}
}
