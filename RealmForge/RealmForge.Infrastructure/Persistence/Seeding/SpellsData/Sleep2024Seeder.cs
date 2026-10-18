using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sleep (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Sleep2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sleep");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sleep", "en"),
					Language = LanguageCode.En,
					Name = "Sleep",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a pinch of sand or rose petals",
					Description = "Each creature of your choice in a 5-foot-radius Sphere centered on a point within range must succeed on a Wisdom saving throw or have the Incapacitated condition until the end of its next turn, at which point it must repeat the save. If the target fails the second save, the target has the Unconscious condition for the duration. The spell ends on a target if it takes damage or someone within 5 feet of it takes an action to shake it out of the spell's effect.\n\nCreatures that don't sleep, such as elves, or that have Immunity to the Exhaustion condition automatically succeed on saves against this spell.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sleep", "it"),
					Language = LanguageCode.It,
					Name = "Sonno",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pizzico di sabbia o di petali di rosa",
					Description = "Ogni creatura a scelta dell'incantatore in una sfera del raggio di 1,5 metri centrata su un punto entro gittata deve superare un tiro salvezza su Saggezza, altrimenti è incapacitata fino alla fine del suo turno successivo, momento in cui deve ripetere il tiro salvezza. Se fallisce il secondo tiro salvezza, il bersaglio è privo di sensi per la durata. L'incantesimo termina su un bersaglio se questo subisce danni o se qualcuno entro 1,5 metri da esso effettua un'azione per scuoterlo e liberarlo dall'effetto dell'incantesimo.\n\nLe creature che non dormono, come gli elfi, o che sono immuni alla condizione indebolimento superano automaticamente i tiri salvezza contro questo incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
