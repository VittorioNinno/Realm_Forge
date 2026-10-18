using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Flame Strike (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FlameStrike2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flame-strike");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flame-strike", "en"),
					Language = LanguageCode.En,
					Name = "Flame Strike",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a pinch of sulfur",
					Description = "A vertical column of brilliant fire roars down from above. Each creature in a 10-foot-radius, 40-foot-high Cylinder centered on a point within range makes a Dexterity saving throw, taking 5d6 Fire damage and 5d6 Radiant damage on a failed save or half as much damage on a successful one.",
					HigherLevels = "The Fire damage and the Radiant damage increase by 1d6 for each spell slot level above 5."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flame-strike", "it"),
					Language = LanguageCode.It,
					Name = "Colpo Infuocato",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = "un pizzico di zolfo",
					Description = "Una colonna verticale di fuoco splendente piomba dall'alto con un ruggito. Ogni creatura in un cilindro del raggio di 3 metri e alto 12 metri, centrato su un punto entro gittata, effettua un tiro salvezza su Destrezza, subendo 5d6 danni da fuoco e 5d6 danni radiosi se lo fallisce, o la metà di quei danni se lo supera.",
					HigherLevels = "I danni da fuoco e i danni radiosi aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 5°."
				}
			}
		};
	}
}
