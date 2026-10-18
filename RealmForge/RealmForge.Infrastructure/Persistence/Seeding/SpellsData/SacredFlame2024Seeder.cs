using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sacred Flame (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SacredFlame2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sacred-flame");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sacred-flame", "en"),
					Language = LanguageCode.En,
					Name = "Sacred Flame",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Flame-like radiance descends on a creature that you can see within range. The target must succeed on a Dexterity saving throw or take 1d8 Radiant damage. The target gains no benefit from Half Cover or Three-Quarters Cover for this save.",
					HigherLevels = "The damage increases by 1d8 when you reach levels 5 (2d8), 11 (3d8), and 17 (4d8)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sacred-flame", "it"),
					Language = LanguageCode.It,
					Name = "Fiamma Sacra",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Uno splendore simile a una fiamma discende su una creatura entro gittata che l'incantatore è in grado di vedere. Il bersaglio deve superare un tiro salvezza su Destrezza, altrimenti subisce 1d8 danni radiosi. Il bersaglio non ottiene alcun beneficio dalla mezza copertura o dalla copertura dei tre quarti per questo tiro salvezza.",
					HigherLevels = "I danni aumentano di 1d8 quando l'incantatore raggiunge il 5° livello (2d8), l'11° livello (3d8) e il 17° livello (4d8)."
				}
			}
		};
	}
}
