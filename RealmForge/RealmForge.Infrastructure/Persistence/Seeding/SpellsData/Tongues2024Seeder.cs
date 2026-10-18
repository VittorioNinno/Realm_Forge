using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Tongues (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Tongues2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tongues");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tongues", "en"),
					Language = LanguageCode.En,
					Name = "Tongues",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a miniature ziggurat",
					Description = "This spell grants the creature you touch the ability to understand any spoken or signed language that it hears or sees. Moreover, when the target communicates by speaking or signing, any creature that knows at least one language can understand it if that creature can hear the speech or see the signing.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tongues", "it"),
					Language = LanguageCode.It,
					Name = "Linguaggi",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "una ziggurat in miniatura",
					Description = "Questo incantesimo conferisce alla creatura toccata dall'incantatore la capacità di comprendere qualsiasi linguaggio parlato o dei segni che sente o vede. Inoltre, quando il bersaglio comunica parlando o a gesti, qualsiasi creatura che conosce almeno un linguaggio può comprenderlo, se è in grado di sentirne le parole o di vederne i gesti.",
					HigherLevels = null
				}
			}
		};
	}
}
