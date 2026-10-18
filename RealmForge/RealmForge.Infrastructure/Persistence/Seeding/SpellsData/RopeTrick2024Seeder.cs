using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Rope Trick (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class RopeTrick2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "rope-trick");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "rope-trick", "en"),
					Language = LanguageCode.En,
					Name = "Rope Trick",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a segment of rope",
					Description = "You touch a rope. One end of it hovers upward until the rope hangs perpendicular to the ground or the rope reaches a ceiling. At the rope's upper end, an Invisible 3-foot-by-5-foot portal opens to an extradimensional space that lasts until the spell ends. That space can be reached by climbing the rope, which can be pulled into or dropped out of it.\n\nThe space can hold up to eight Medium or smaller creatures. Attacks, spells, and other effects can't pass into or out of the space, but creatures inside it can see through the portal. Anything inside the space drops out when the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "rope-trick", "it"),
					Language = LanguageCode.It,
					Name = "Trucco della Corda",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "un pezzo di corda",
					Description = "L'incantatore tocca una corda. Una delle sue estremità si solleva finché la corda non pende perpendicolare al terreno o finché non raggiunge un soffitto. All'estremità superiore della corda si apre un portale invisibile di 90 centimetri per 1,5 metri che conduce a uno spazio extradimensionale, il quale permane finché l'incantesimo non termina. Quello spazio può essere raggiunto arrampicandosi sulla corda, che può essere tirata dentro o lasciata cadere fuori da esso.\n\nLo spazio può contenere fino a otto creature di taglia Media o inferiore. Attacchi, incantesimi e altri effetti non possono entrare nello spazio o uscirne, ma le creature al suo interno possono vedere attraverso il portale. Qualsiasi cosa si trovi all'interno dello spazio ne cade fuori quando l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
