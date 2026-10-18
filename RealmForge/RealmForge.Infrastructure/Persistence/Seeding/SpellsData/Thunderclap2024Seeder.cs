using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Thunderclap (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class Thunderclap2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thunderclap");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 0,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = false,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thunderclap", "en"),
					Language = LanguageCode.En,
					Name = "Thunderclap",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Bringing your palms together, you set off a sharp blast of thunder that can be heard 100 feet away. Every creature in a 5-foot Emanation around you attempts a Constitution saving throw, suffering 1d6 Thunder damage if it fails.",
					HigherLevels = "The damage becomes 2d6 at level 5, 3d6 at level 11, and 4d6 at level 17."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thunderclap", "it"),
					Language = LanguageCode.It,
					Name = "Rombo di Tuono",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Battendo i palmi, l'incantatore produce un secco scoppio di tuono udibile a 30 metri di distanza. Ogni creatura in un'emanazione di 1,5 metri attorno a lui tenta un tiro salvezza su Costituzione e subisce 1d6 danni da tuono se fallisce.",
					HigherLevels = "I danni diventano 2d6 al 5° livello, 3d6 all'11° livello e 4d6 al 17° livello."
				}
			}
		};
	}
}
