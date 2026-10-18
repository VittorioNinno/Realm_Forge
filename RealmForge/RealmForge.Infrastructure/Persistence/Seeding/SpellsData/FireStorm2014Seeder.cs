using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fire Storm (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FireStorm2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fire-storm");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Sorcerer },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fire-storm", "en"),
					Language = LanguageCode.En,
					Name = "Fire Storm",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "A storm made up of sheets of roaring flame appears in a location you choose within range. The area of the storm consists of up to ten 10-foot cubes, which you can arrange as you wish. Each cube must have at least one face adjacent to the face of another cube. Each creature in the area must make a Dexterity saving throw. It takes 7d10 fire damage on a failed save, or half as much damage on a successful one.\n\nThe fire damages objects in the area and ignites flammable objects that aren't being worn or carried. If you choose, plant life in the area is unaffected by this spell.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fire-storm", "it"),
					Language = LanguageCode.It,
					Name = "Tempesta di Fuoco",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Una tempesta composta da cortine di fiamme ruggenti compare in un luogo entro gittata scelto dall'incantatore. L'area della tempesta è composta da un massimo di dieci cubi con spigolo di 3 metri, che l'incantatore può disporre a suo piacimento. Ogni cubo deve avere almeno una faccia adiacente alla faccia di un altro cubo. Ogni creatura nell'area deve effettuare un tiro salvezza su Destrezza. Subisce 7d10 danni da fuoco se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\nIl fuoco danneggia gli oggetti nell'area e incendia gli oggetti infiammabili che non sono indossati o trasportati. Se l'incantatore lo desidera, la vegetazione nell'area non è influenzata da questo incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
