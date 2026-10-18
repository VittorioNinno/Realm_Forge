using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Light (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Light2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "light");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "light", "en"),
					Language = LanguageCode.En,
					Name = "Light",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a firefly or phosphorescent moss",
					Description = "You touch one Large or smaller object that isn't being worn or carried by someone else. Until the spell ends, the object sheds Bright Light in a 20-foot radius and Dim Light for an additional 20 feet. The light can be colored as you like.\n\nCovering the object with something opaque blocks the light. The spell ends if you cast it again.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "light", "it"),
					Language = LanguageCode.It,
					Name = "Luce",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "una lucciola o del muschio fosforescente",
					Description = "L'incantatore tocca un oggetto di taglia Grande o inferiore che non sia indossato o trasportato da qualcun altro. Finché l'incantesimo non termina, l'oggetto proietta luce intensa in un raggio di 6 metri e luce fioca per altri 6 metri. La luce può essere del colore che l'incantatore preferisce.\n\nCoprire l'oggetto con qualcosa di opaco blocca la luce. L'incantesimo termina se l'incantatore lo lancia di nuovo.",
					HigherLevels = null
				}
			}
		};
	}
}
