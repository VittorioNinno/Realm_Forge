using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Feather Fall (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FeatherFall2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "feather-fall");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "feather-fall", "en"),
					Language = LanguageCode.En,
					Name = "Feather Fall",
					CastingTime = "1 reaction, which you take when you or a creature within 60 feet of you falls",
					Range = "60 feet",
					Duration = "1 minute",
					MaterialComponent = "a small feather or a piece of down",
					Description = "Choose up to five falling creatures within range. A falling creature's rate of descent slows to 60 feet per round until the spell ends. If the creature lands before the spell ends, it takes no falling damage and can land on its feet, and the spell ends for that creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "feather-fall", "it"),
					Language = LanguageCode.It,
					Name = "Caduta Morbida",
					CastingTime = "1 reazione, che l'incantatore effettua quando lui o una creatura entro 18 metri da lui cade",
					Range = "18 metri",
					Duration = "1 minuto",
					MaterialComponent = "una piccola piuma o un pezzo di piumino",
					Description = "L'incantatore sceglie fino a cinque creature in caduta entro gittata. La velocità di discesa di una creatura in caduta rallenta a 18 metri per round finché l'incantesimo non termina. Se la creatura tocca terra prima che l'incantesimo termini, non subisce danni da caduta e può atterrare in piedi, e l'incantesimo termina per quella creatura.",
					HigherLevels = null
				}
			}
		};
	}
}
