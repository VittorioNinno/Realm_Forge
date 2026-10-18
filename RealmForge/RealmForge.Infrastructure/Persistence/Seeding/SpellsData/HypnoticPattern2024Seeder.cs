using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hypnotic Pattern (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HypnoticPattern2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hypnotic-pattern");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = false,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hypnotic-pattern", "en"),
					Language = LanguageCode.En,
					Name = "Hypnotic Pattern",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a pinch of confetti",
					Description = "You create a twisting pattern of colors in a 30-foot Cube within range. The pattern appears for a moment and vanishes. Each creature in the area who can see the pattern must succeed on a Wisdom saving throw or have the Charmed condition for the duration. While Charmed, the creature has the Incapacitated condition and a Speed of 0.\n\nThe spell ends for an affected creature if it takes any damage or if someone else uses an action to shake the creature out of its stupor.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hypnotic-pattern", "it"),
					Language = LanguageCode.It,
					Name = "Trama Ipnotica",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pizzico di coriandoli",
					Description = "L'incantatore crea una trama di colori vorticanti in un cubo con spigolo di 9 metri entro gittata. La trama compare per un istante e poi svanisce. Ogni creatura nell'area che è in grado di vedere la trama deve superare un tiro salvezza su Saggezza, altrimenti è affascinata per la durata. Finché è affascinata, la creatura è incapacitata e ha velocità 0.\n\nL'incantesimo termina per una creatura influenzata se subisce danni o se qualcun altro usa un'azione per scuoterla dal suo torpore.",
					HigherLevels = null
				}
			}
		};
	}
}
