using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Circle of Death (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CircleOfDeath2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "circle-of-death");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "circle-of-death", "en"),
					Language = LanguageCode.En,
					Name = "Circle of Death",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "the powder of a crushed black pearl worth 500+ GP",
					Description = "Negative energy ripples out in a 60-foot-radius Sphere from a point you choose within range. Each creature in that area makes a Constitution saving throw, taking 8d8 Necrotic damage on a failed save or half as much damage on a successful one.",
					HigherLevels = "The damage increases by 2d8 for each spell slot level above 6."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "circle-of-death", "it"),
					Language = LanguageCode.It,
					Name = "Cerchio di Morte",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "la polvere di una perla nera frantumata del valore di almeno 500 mo",
					Description = "Un'ondata di energia negativa si propaga in una sfera del raggio di 18 metri da un punto entro gittata a scelta dell'incantatore. Ogni creatura in quell'area effettua un tiro salvezza su Costituzione, subendo 8d8 danni necrotici se lo fallisce, o la metà di quei danni se lo supera.",
					HigherLevels = "I danni aumentano di 2d8 per ogni livello dello slot incantesimo superiore al 6°."
				}
			}
		};
	}
}
