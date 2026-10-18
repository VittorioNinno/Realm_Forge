using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fear (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Fear2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fear");

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
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fear", "en"),
					Language = LanguageCode.En,
					Name = "Fear",
					CastingTime = "1 action",
					Range = "Self (30-foot cone)",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a white feather or the heart of a hen",
					Description = "You project a phantasmal image of a creature's worst fears. Each creature in a 30-foot cone must succeed on a Wisdom saving throw or drop whatever it is holding and become frightened for the duration.\n\nWhile frightened by this spell, a creature must take the Dash action and move away from you by the safest available route on each of its turns, unless there is nowhere to move. If the creature ends its turn in a location where it doesn't have line of sight to you, the creature can make a Wisdom saving throw. On a successful save, the spell ends for that creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fear", "it"),
					Language = LanguageCode.It,
					Name = "Paura",
					CastingTime = "1 azione",
					Range = "Incantatore (cono di 9 metri)",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una piuma bianca o il cuore di una gallina",
					Description = "L'incantatore proietta un'immagine illusoria delle peggiori paure di una creatura. Ogni creatura in un cono di 9 metri deve superare un tiro salvezza su Saggezza, altrimenti lascia cadere qualsiasi cosa stia impugnando ed è spaventata per la durata.\n\nFinché è spaventata da questo incantesimo, in ognuno dei suoi turni la creatura deve effettuare l'azione di Scatto e allontanarsi dall'incantatore seguendo il percorso più sicuro disponibile, a meno che non ci sia alcun luogo in cui spostarsi. Se la creatura termina il proprio turno in un luogo da cui non ha linea di vista con l'incantatore, può effettuare un tiro salvezza su Saggezza. Se lo supera, l'incantesimo termina per quella creatura.",
					HigherLevels = null
				}
			}
		};
	}
}
