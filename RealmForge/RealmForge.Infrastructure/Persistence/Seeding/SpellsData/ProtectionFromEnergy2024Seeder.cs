using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Protection from Energy (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ProtectionFromEnergy2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "protection-from-energy");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "protection-from-energy", "en"),
					Language = LanguageCode.En,
					Name = "Protection from Energy",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "For the duration, the willing creature you touch has Resistance to one damage type of your choice: Acid, Cold, Fire, Lightning, or Thunder.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "protection-from-energy", "it"),
					Language = LanguageCode.It,
					Name = "Protezione dall'Energia",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "Per la durata, la creatura consenziente toccata dall'incantatore ha resistenza a un tipo di danni a scelta dell'incantatore: acido, freddo, fuoco, fulmine o tuono.",
					HigherLevels = null
				}
			}
		};
	}
}
