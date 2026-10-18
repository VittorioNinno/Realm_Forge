using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Tongues (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Tongues2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "tongues");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "tongues", "en"),
					Language = LanguageCode.En,
					Name = "Tongues",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a small clay model of a ziggurat",
					Description = "This spell grants the creature you touch the ability to understand any spoken language it hears. Moreover, when the target speaks, any creature that knows at least one language and can hear the target understands what it says.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "tongues", "it"),
					Language = LanguageCode.It,
					Name = "Linguaggi",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "un piccolo modellino di argilla di una ziggurat",
					Description = "Questo incantesimo conferisce alla creatura toccata dall'incantatore la capacità di comprendere qualsiasi linguaggio parlato che sente. Inoltre, quando il bersaglio parla, qualsiasi creatura che conosce almeno un linguaggio e che può sentirlo comprende ciò che dice.",
					HigherLevels = null
				}
			}
		};
	}
}
