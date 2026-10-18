using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Thunderwave (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Thunderwave2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thunderwave");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thunderwave", "en"),
					Language = LanguageCode.En,
					Name = "Thunderwave",
					CastingTime = "1 action",
					Range = "Self (15-foot cube)",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "A wave of thunderous force sweeps out from you. Each creature in a 15-foot cube originating from you must make a Constitution saving throw. On a failed save, a creature takes 2d8 thunder damage and is pushed 10 feet away from you. On a successful save, the creature takes half as much damage and isn't pushed.\n\nIn addition, unsecured objects that are completely within the area of effect are automatically pushed 10 feet away from you by the spell's effect, and the spell emits a thunderous boom audible out to 300 feet.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d8 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "thunderwave", "it"),
					Language = LanguageCode.It,
					Name = "Onda Tonante",
					CastingTime = "1 azione",
					Range = "Incantatore (cubo di 4,5 metri)",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Un'onda di forza tonante si propaga dall'incantatore. Ogni creatura in un cubo con spigolo di 4,5 metri che parte dall'incantatore deve effettuare un tiro salvezza su Costituzione. Se lo fallisce, la creatura subisce 2d8 danni da tuono e viene spinta di 3 metri lontano dall'incantatore. Se lo supera, subisce la metà di quei danni e non viene spinta.\n\nInoltre, gli oggetti non fissati che si trovano completamente all'interno dell'area d'effetto vengono spinti automaticamente di 3 metri lontano dall'incantatore dall'effetto dell'incantesimo, e l'incantesimo emette un boato tonante udibile fino a 90 metri di distanza.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni aumentano di 1d8 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
