using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fire Storm (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FireStorm2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fire-storm");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fire-storm", "en"),
					Language = LanguageCode.En,
					Name = "Fire Storm",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "A storm of fire appears within range. The area of the storm consists of up to ten 10-foot Cubes, which you arrange as you like. Each Cube must be contiguous with at least one other Cube. Each creature in the area makes a Dexterity saving throw, taking 7d10 Fire damage on a failed save or half as much damage on a successful one.\n\nFlammable objects in the area that aren't being worn or carried start burning.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fire-storm", "it"),
					Language = LanguageCode.It,
					Name = "Tempesta di Fuoco",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Una tempesta di fuoco compare entro gittata. L'area della tempesta è costituita da un massimo di dieci cubi con spigolo di 3 metri, che l'incantatore dispone come preferisce. Ogni cubo deve essere adiacente ad almeno un altro cubo. Ogni creatura nell'area effettua un tiro salvezza su Destrezza, subendo 7d10 danni da fuoco se lo fallisce, o la metà di quei danni se lo supera.\n\nGli oggetti infiammabili nell'area che non sono indossati o trasportati prendono fuoco.",
					HigherLevels = null
				}
			}
		};
	}
}
