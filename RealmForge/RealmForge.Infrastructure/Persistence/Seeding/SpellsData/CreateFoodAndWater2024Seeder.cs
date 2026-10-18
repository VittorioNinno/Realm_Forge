using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Create Food and Water (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CreateFoodAndWater2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "create-food-and-water");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "create-food-and-water", "en"),
					Language = LanguageCode.En,
					Name = "Create Food and Water",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You create 45 pounds of food and 30 gallons of fresh water on the ground or in containers within range—both useful in fending off the hazards of malnutrition and dehydration. The food is bland but nourishing and looks like a food of your choice, and the water is clean. The food spoils after 24 hours if uneaten.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "create-food-and-water", "it"),
					Language = LanguageCode.It,
					Name = "Creare Cibo e Acqua",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore crea 22,5 kg di cibo e 120 litri di acqua dolce sul terreno o in contenitori entro gittata: entrambi sono utili per scongiurare i pericoli della malnutrizione e della disidratazione. Il cibo è insipido ma nutriente e ha l'aspetto di un alimento a scelta dell'incantatore, e l'acqua è pulita. Il cibo si guasta dopo 24 ore se non viene consumato.",
					HigherLevels = null
				}
			}
		};
	}
}
