using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Weird (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Weird2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "weird");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 9,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "weird", "en"),
					Language = LanguageCode.En,
					Name = "Weird",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Drawing on the deepest fears of a group of creatures, you create illusory creatures in their minds, visible only to them. Each creature in a 30-foot-radius sphere centered on a point of your choice within range must make a Wisdom saving throw. On a failed save, a creature becomes frightened for the duration. The illusion calls on the creature's deepest fears, manifesting its worst nightmares as an implacable threat. At the start of each of the frightened creature's turns, it must succeed on a Wisdom saving throw or take 4d10 psychic damage. On a successful save, the spell ends for that creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "weird", "it"),
					Language = LanguageCode.It,
					Name = "Fatale",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Attingendo alle paure più profonde di un gruppo di creature, l'incantatore crea nelle loro menti creature illusorie, visibili soltanto a loro. Ogni creatura in una sfera del raggio di 9 metri, centrata su un punto entro gittata a scelta dell'incantatore, deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, la creatura è spaventata per la durata. L'illusione richiama le paure più profonde della creatura, manifestando i suoi peggiori incubi come una minaccia implacabile. All'inizio di ogni turno della creatura spaventata, questa deve superare un tiro salvezza su Saggezza, altrimenti subisce 4d10 danni psichici. Se lo supera, l'incantesimo termina per quella creatura.",
					HigherLevels = null
				}
			}
		};
	}
}
