using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Rope Trick (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class RopeTrick2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "rope-trick");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "rope-trick", "en"),
					Language = LanguageCode.En,
					Name = "Rope Trick",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "powdered corn extract and a twisted loop of parchment",
					Description = "You touch a length of rope that is up to 60 feet long. One end of the rope then rises into the air until the whole rope hangs perpendicular to the ground. At the upper end of the rope, an invisible entrance opens to an extradimensional space that lasts until the spell ends.\n\nThe extradimensional space can be reached by climbing to the top of the rope. The space can hold as many as eight Medium or smaller creatures. The rope can be pulled into the space, making the rope disappear from view outside the space.\n\nAttacks and spells can't cross through the entrance into or out of the extradimensional space, but those inside can see out of it as if through a 3-foot-by-5-foot window centered on the rope.\n\nAnything inside the extradimensional space drops out when the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "rope-trick", "it"),
					Language = LanguageCode.It,
					Name = "Trucco della Corda",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "estratto di mais in polvere e un anello di pergamena attorcigliato",
					Description = "L'incantatore tocca una corda lunga fino a 18 metri. Un'estremità della corda si solleva in aria finché l'intera corda non pende perpendicolare al terreno. All'estremità superiore della corda si apre un ingresso invisibile verso uno spazio extradimensionale, che dura finché l'incantesimo non termina.\n\nLo spazio extradimensionale può essere raggiunto arrampicandosi fino alla cima della corda e può contenere fino a otto creature di taglia Media o inferiore. La corda può essere tirata all'interno dello spazio, facendola scomparire alla vista dall'esterno.\n\nGli attacchi e gli incantesimi non possono attraversare l'ingresso, né per entrare né per uscire dallo spazio extradimensionale, ma chi si trova all'interno può vedere all'esterno come attraverso una finestra di 90 cm per 1,5 metri centrata sulla corda.\n\nQuando l'incantesimo termina, tutto ciò che si trova all'interno dello spazio extradimensionale cade fuori.",
					HigherLevels = null
				}
			}
		};
	}
}
