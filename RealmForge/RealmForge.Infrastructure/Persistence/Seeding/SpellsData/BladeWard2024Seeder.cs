using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blade Ward (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class BladeWard2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blade-ward");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 0,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blade-ward", "en"),
					Language = LanguageCode.En,
					Name = "Blade Ward",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "A shimmer of protective magic surrounds you. Until the spell ends, any creature that makes an attack roll against you subtracts 1d4 from the roll.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blade-ward", "it"),
					Language = LanguageCode.It,
					Name = "Interdizione alle Lame",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Un velo di magia protettiva circonda l'incantatore. Finché l'incantesimo non termina, qualsiasi creatura che effettua un tiro per colpire contro l'incantatore sottrae 1d4 al tiro.",
					HigherLevels = null
				}
			}
		};
	}
}
