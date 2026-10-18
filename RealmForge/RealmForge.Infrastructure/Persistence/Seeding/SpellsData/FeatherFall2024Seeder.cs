using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Feather Fall (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FeatherFall2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "feather-fall");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "feather-fall", "en"),
					Language = LanguageCode.En,
					Name = "Feather Fall",
					CastingTime = "Reaction, which you take when you or a creature you can see within 60 feet of you falls",
					Range = "60 feet",
					Duration = "1 minute",
					MaterialComponent = "a small feather or piece of down",
					Description = "Choose up to five falling creatures within range. A falling creature's rate of descent slows to 60 feet per round until the spell ends. If a creature lands before the spell ends, the creature takes no damage from the fall, and the spell ends for that creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "feather-fall", "it"),
					Language = LanguageCode.It,
					Name = "Caduta Morbida",
					CastingTime = "Reazione, che l'incantatore effettua quando lui stesso o una creatura che è in grado di vedere entro 18 metri da lui sta cadendo",
					Range = "18 metri",
					Duration = "1 minuto",
					MaterialComponent = "una piccola piuma o un po' di piumino",
					Description = "L'incantatore sceglie fino a cinque creature in caduta entro gittata. La velocità di discesa di una creatura in caduta rallenta a 18 metri per round finché l'incantesimo non termina. Se una creatura atterra prima che l'incantesimo termini, non subisce danni da caduta e l'incantesimo termina per quella creatura.",
					HigherLevels = null
				}
			}
		};
	}
}
