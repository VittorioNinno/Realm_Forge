using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Protection from Poison (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ProtectionFromPoison2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "protection-from-poison");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "protection-from-poison", "en"),
					Language = LanguageCode.En,
					Name = "Protection from Poison",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "You touch a creature. If it is poisoned, you neutralize the poison. If more than one poison afflicts the target, you neutralize one poison that you know is present, or you neutralize one at random.\n\nFor the duration, the target has advantage on saving throws against being poisoned, and it has resistance to poison damage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "protection-from-poison", "it"),
					Language = LanguageCode.It,
					Name = "Protezione dai Veleni",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "L'incantatore tocca una creatura. Se è avvelenata, neutralizza il veleno. Se il bersaglio è afflitto da più di un veleno, l'incantatore ne neutralizza uno che sa essere presente, oppure uno a caso.\n\nPer la durata, il bersaglio dispone di vantaggio ai tiri salvezza per non essere avvelenato e ha resistenza ai danni da veleno.",
					HigherLevels = null
				}
			}
		};
	}
}
