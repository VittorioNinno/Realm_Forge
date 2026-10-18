using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Lesser Restoration (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LesserRestoration2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "lesser-restoration");

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
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "lesser-restoration", "en"),
					Language = LanguageCode.En,
					Name = "Lesser Restoration",
					CastingTime = "Bonus Action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You touch a creature and end one condition on it: Blinded, Deafened, Paralyzed, or Poisoned.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "lesser-restoration", "it"),
					Language = LanguageCode.It,
					Name = "Ristorare Inferiore",
					CastingTime = "Azione bonus",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore tocca una creatura e pone fine a una delle seguenti condizioni su di essa: accecato, assordato, avvelenato o paralizzato.",
					HigherLevels = null
				}
			}
		};
	}
}
