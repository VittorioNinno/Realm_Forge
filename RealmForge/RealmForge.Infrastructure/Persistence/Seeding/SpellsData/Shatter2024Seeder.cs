using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Shatter (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Shatter2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shatter");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shatter", "en"),
					Language = LanguageCode.En,
					Name = "Shatter",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a chip of mica",
					Description = "A loud noise erupts from a point of your choice within range. Each creature in a 10-foot-radius Sphere centered there makes a Constitution saving throw, taking 3d8 Thunder damage on a failed save or half as much damage on a successful one. A Construct has Disadvantage on the save.\n\nA nonmagical object that isn't being worn or carried also takes the damage if it's in the spell's area.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "shatter", "it"),
					Language = LanguageCode.It,
					Name = "Frantumare",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = "una scaglia di mica",
					Description = "Un rumore assordante erompe da un punto entro gittata a scelta dell'incantatore. Ogni creatura in una sfera del raggio di 3 metri centrata su quel punto effettua un tiro salvezza su Costituzione, subendo 3d8 danni da tuono se lo fallisce, o la metà di quei danni se lo supera. Un costrutto subisce svantaggio al tiro salvezza.\n\nAnche un oggetto non magico che non sia indossato o trasportato subisce i danni se si trova nell'area dell'incantesimo.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
