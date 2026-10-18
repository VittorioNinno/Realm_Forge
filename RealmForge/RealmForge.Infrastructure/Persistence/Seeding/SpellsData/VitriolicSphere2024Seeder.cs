using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Vitriolic Sphere (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class VitriolicSphere2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "vitriolic-sphere");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "vitriolic-sphere", "en"),
					Language = LanguageCode.En,
					Name = "Vitriolic Sphere",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a drop of bile",
					Description = "You point at a location within range, and a glowing, 1-foot-diameter ball of acid streaks there and explodes in a 20-foot-radius Sphere. Each creature in that area makes a Dexterity saving throw. On a failed save, a creature takes 10d4 Acid damage and another 5d4 Acid damage at the end of its next turn. On a successful save, a creature takes half the initial damage only.",
					HigherLevels = "The initial damage increases by 2d4 for each spell slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "vitriolic-sphere", "it"),
					Language = LanguageCode.It,
					Name = "Sfera al Vetriolo",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "una goccia di bile",
					Description = "L'incantatore indica un punto entro gittata e un globo di acido luminoso, del diametro di 30 centimetri, sfreccia fin lì ed esplode in una sfera del raggio di 6 metri. Ogni creatura in quell'area effettua un tiro salvezza su Destrezza. Se lo fallisce, una creatura subisce 10d4 danni da acido e altri 5d4 danni da acido alla fine del suo turno successivo. Se lo supera, una creatura subisce soltanto la metà dei danni iniziali.",
					HigherLevels = "I danni iniziali aumentano di 2d4 per ogni livello dello slot incantesimo superiore al 4°."
				}
			}
		};
	}
}
