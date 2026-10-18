using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sacred Flame (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SacredFlame2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sacred-flame");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sacred-flame", "en"),
					Language = LanguageCode.En,
					Name = "Sacred Flame",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Flame-like radiance descends on a creature that you can see within range. The target must succeed on a Dexterity saving throw or take 1d8 radiant damage. The target gains no benefit from cover for this saving throw.\n\nThe spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sacred-flame", "it"),
					Language = LanguageCode.It,
					Name = "Fiamma Sacra",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Uno splendore simile a una fiamma discende su una creatura entro gittata che l'incantatore sia in grado di vedere. Il bersaglio deve superare un tiro salvezza su Destrezza, altrimenti subisce 1d8 danni radiosi. Ai fini di questo tiro salvezza, il bersaglio non ottiene alcun beneficio dalla copertura.\n\nI danni dell'incantesimo aumentano di 1d8 quando l'incantatore raggiunge il 5° livello (2d8), l'11° livello (3d8) e il 17° livello (4d8).",
					HigherLevels = null
				}
			}
		};
	}
}
