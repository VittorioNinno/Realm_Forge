using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Goodberry (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Goodberry2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "goodberry");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "goodberry", "en"),
					Language = LanguageCode.En,
					Name = "Goodberry",
					CastingTime = "Action",
					Range = "Self",
					Duration = "24 hours",
					MaterialComponent = "a sprig of mistletoe",
					Description = "Ten berries appear in your hand and are infused with magic for the duration. A creature can take a Bonus Action to eat one berry. Eating a berry restores 1 Hit Point, and the berry provides enough nourishment to sustain a creature for one day.\n\nUneaten berries disappear when the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "goodberry", "it"),
					Language = LanguageCode.It,
					Name = "Bacche Benefiche",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "24 ore",
					MaterialComponent = "un rametto di vischio",
					Description = "Nella mano dell'incantatore compaiono dieci bacche, infuse di magia per la durata. Una creatura può effettuare un'azione bonus per mangiare una bacca. Mangiare una bacca fa recuperare 1 punto ferita, e la bacca fornisce nutrimento sufficiente a sostentare una creatura per un giorno.\n\nLe bacche non consumate scompaiono quando l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
