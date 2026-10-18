using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Protection from Poison (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ProtectionFromPoison2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "protection-from-poison");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "protection-from-poison", "en"),
					Language = LanguageCode.En,
					Name = "Protection from Poison",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "You touch a creature and end the Poisoned condition on it. For the duration, the target has Advantage on saving throws to avoid or end the Poisoned condition, and it has Resistance to Poison damage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "protection-from-poison", "it"),
					Language = LanguageCode.It,
					Name = "Protezione dai Veleni",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "L'incantatore tocca una creatura e pone fine alla condizione avvelenato su di essa. Per la durata, il bersaglio dispone di vantaggio ai tiri salvezza per evitare la condizione avvelenato o porvi fine, e ha resistenza ai danni da veleno.",
					HigherLevels = null
				}
			}
		};
	}
}
