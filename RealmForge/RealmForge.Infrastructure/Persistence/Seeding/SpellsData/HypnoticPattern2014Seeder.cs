using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hypnotic Pattern (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HypnoticPattern2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hypnotic-pattern");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hypnotic-pattern", "en"),
					Language = LanguageCode.En,
					Name = "Hypnotic Pattern",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a glowing stick of incense or a crystal vial filled with phosphorescent material",
					Description = "You create a twisting pattern of colors that weaves through the air inside a 30-foot cube within range. The pattern appears for a moment and vanishes. Each creature in the area who sees the pattern must make a Wisdom saving throw. On a failed save, the creature becomes charmed for the duration. While charmed by this spell, the creature is incapacitated and has a speed of 0.\n\nThe spell ends for an affected creature if it takes any damage or if someone else uses an action to shake the creature out of its stupor.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hypnotic-pattern", "it"),
					Language = LanguageCode.It,
					Name = "Trama Ipnotica",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un bastoncino d'incenso acceso o una fiala di cristallo piena di materiale fosforescente",
					Description = "L'incantatore crea una trama contorta di colori che si intreccia nell'aria all'interno di un cubo con spigolo di 9 metri entro gittata. La trama compare per un istante e poi svanisce. Ogni creatura nell'area che vede la trama deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, la creatura è affascinata per la durata. Finché è affascinata da questo incantesimo, la creatura è incapacitata e ha velocità 0.\n\nL'incantesimo termina per una creatura influenzata se subisce danni o se qualcun altro usa un'azione per scuoterla dal suo torpore.",
					HigherLevels = null
				}
			}
		};
	}
}
