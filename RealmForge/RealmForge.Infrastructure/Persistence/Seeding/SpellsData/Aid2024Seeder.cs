using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Aid (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Aid2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aid");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aid", "en"),
					Language = LanguageCode.En,
					Name = "Aid",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = "a strip of white cloth",
					Description = "Choose up to three creatures within range. Each target's Hit Point maximum and current Hit Points increase by 5 for the duration.",
					HigherLevels = "Each target's Hit Points increase by 5 for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "aid", "it"),
					Language = LanguageCode.It,
					Name = "Aiuto",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = "una striscia di stoffa bianca",
					Description = "L'incantatore sceglie fino a tre creature entro gittata. Il massimo dei punti ferita e i punti ferita attuali di ogni bersaglio aumentano di 5 per la durata.",
					HigherLevels = "I punti ferita di ogni bersaglio aumentano di altri 5 per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
