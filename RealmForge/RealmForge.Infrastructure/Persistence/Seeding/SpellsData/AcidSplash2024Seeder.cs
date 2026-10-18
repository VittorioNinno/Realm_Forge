using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Acid Splash (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AcidSplash2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "acid-splash");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "acid-splash", "en"),
					Language = LanguageCode.En,
					Name = "Acid Splash",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You create an acidic bubble at a point within range, where it explodes in a 5-foot-radius Sphere. Each creature in that Sphere must succeed on a Dexterity saving throw or take 1d6 Acid damage.",
					HigherLevels = "The damage increases by 1d6 when you reach levels 5 (2d6), 11 (3d6), and 17 (4d6)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "acid-splash", "it"),
					Language = LanguageCode.It,
					Name = "Fiotto Acido",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore crea una bolla di acido in un punto entro gittata, dove esplode in una sfera del raggio di 1,5 metri. Ogni creatura in quella sfera deve superare un tiro salvezza su Destrezza, altrimenti subisce 1d6 danni da acido.",
					HigherLevels = "I danni aumentano di 1d6 quando l'incantatore raggiunge il 5° livello (2d6), l'11° livello (3d6) e il 17° livello (4d6)."
				}
			}
		};
	}
}
