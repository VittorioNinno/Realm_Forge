using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Programmed Illusion (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ProgrammedIllusion2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "programmed-illusion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "programmed-illusion", "en"),
					Language = LanguageCode.En,
					Name = "Programmed Illusion",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Until dispelled",
					MaterialComponent = "jade dust worth 25+ GP",
					Description = "You create an illusion of an object, a creature, or some other visible phenomenon within range that activates when a specific trigger occurs. The illusion is imperceptible until then. It must be no larger than a 30-foot Cube, and you decide when you cast the spell how the illusion behaves and what sounds it makes. This scripted performance can last up to 5 minutes.\n\nWhen the trigger you specify occurs, the illusion springs into existence and performs in the manner you described. Once the illusion finishes performing, it disappears and remains dormant for 10 minutes, after which the illusion can be activated again.\n\nThe trigger can be as general or as detailed as you like, though it must be based on visual or audible phenomena that occur within 30 feet of the area. For example, you could create an illusion of yourself to appear and warn off others who attempt to open a trapped door.\n\nPhysical interaction with the image reveals it to be illusory, since things can pass through it. A creature that takes the Study action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the creature can see through the image, and any noise it makes sounds hollow to the creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "programmed-illusion", "it"),
					Language = LanguageCode.It,
					Name = "Illusione Programmata",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "polvere di giada del valore di almeno 25 mo",
					Description = "L'incantatore crea entro gittata l'illusione di un oggetto, di una creatura o di qualche altro fenomeno visibile, che si attiva quando si verifica un innesco specifico. Fino ad allora l'illusione è impercettibile. Non deve essere più grande di un cubo con spigolo di 9 metri, e l'incantatore decide al momento del lancio come si comporta l'illusione e quali suoni emette. Questa esibizione predefinita può durare fino a 5 minuti.\n\nQuando si verifica l'innesco stabilito, l'illusione prende vita e si esibisce nel modo descritto dall'incantatore. Una volta terminata l'esibizione, l'illusione scompare e resta inattiva per 10 minuti, dopodiché può essere attivata di nuovo.\n\nL'innesco può essere generico o dettagliato quanto l'incantatore desidera, ma deve basarsi su fenomeni visivi o udibili che si verificano entro 9 metri dall'area. Per esempio, l'incantatore potrebbe creare un'illusione di sé stesso che compare e avverte di andarsene chi tenta di aprire una porta con una trappola.\n\nL'interazione fisica con l'immagine rivela che si tratta di un'illusione, perché le cose possono attraversarla. Una creatura che effettua l'azione di Studio per esaminare l'immagine può capire che si tratta di un'illusione superando una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se una creatura riconosce l'illusione per ciò che è, può vedere attraverso l'immagine e qualsiasi rumore emesso dall'illusione le suona vuoto.",
					HigherLevels = null
				}
			}
		};
	}
}
