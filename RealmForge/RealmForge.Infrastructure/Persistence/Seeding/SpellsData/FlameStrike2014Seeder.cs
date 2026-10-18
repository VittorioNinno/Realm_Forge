using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Flame Strike (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FlameStrike2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flame-strike");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flame-strike", "en"),
					Language = LanguageCode.En,
					Name = "Flame Strike",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = "pinch of sulfur",
					Description = "A vertical column of divine fire roars down from the heavens in a location you specify. Each creature in a 10-foot-radius, 40-foot-high cylinder centered on a point within range must make a Dexterity saving throw. A creature takes 4d6 fire damage and 4d6 radiant damage on a failed save, or half as much damage on a successful one.",
					HigherLevels = "When you cast this spell using a spell slot of 6th level or higher, the fire damage or the radiant damage (your choice) increases by 1d6 for each slot level above 5th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flame-strike", "it"),
					Language = LanguageCode.It,
					Name = "Colpo Infuocato",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = "un pizzico di zolfo",
					Description = "Una colonna verticale di fuoco divino si abbatte ruggendo dai cieli in un luogo indicato dall'incantatore. Ogni creatura in un cilindro del raggio di 3 metri e alto 12 metri, centrato su un punto entro gittata, deve effettuare un tiro salvezza su Destrezza. Una creatura subisce 4d6 danni da fuoco e 4d6 danni radiosi se fallisce il tiro salvezza, o la metà di quei danni se lo supera.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 6° livello o superiore, i danni da fuoco o i danni radiosi (a scelta dell'incantatore) aumentano di 1d6 per ogni livello dello slot superiore al 5°."
				}
			}
		};
	}
}
