using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fireball (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Fireball2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fireball");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fireball", "en"),
					Language = LanguageCode.En,
					Name = "Fireball",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a ball of bat guano and sulfur",
					Description = "A bright streak flashes from you to a point you choose within range and then blossoms with a low roar into a fiery explosion. Each creature in a 20-foot-radius Sphere centered on that point makes a Dexterity saving throw, taking 8d6 Fire damage on a failed save or half as much damage on a successful one.\n\nFlammable objects in the area that aren't being worn or carried start burning.",
					HigherLevels = "The damage increases by 1d6 for each spell slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fireball", "it"),
					Language = LanguageCode.It,
					Name = "Palla di Fuoco",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "una pallina di guano di pipistrello e zolfo",
					Description = "Una scia luminosa scaturisce dall'incantatore e raggiunge un punto a sua scelta entro gittata, dove sboccia con un rombo sordo in un'esplosione di fiamme. Ogni creatura in una sfera del raggio di 6 metri centrata su quel punto effettua un tiro salvezza su Destrezza, subendo 8d6 danni da fuoco se lo fallisce, o la metà di quei danni se lo supera.\n\nGli oggetti infiammabili nell'area che non sono indossati o trasportati prendono fuoco.",
					HigherLevels = "I danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 3°."
				}
			}
		};
	}
}
