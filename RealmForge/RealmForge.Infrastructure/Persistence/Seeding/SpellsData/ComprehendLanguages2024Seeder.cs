using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Comprehend Languages (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ComprehendLanguages2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "comprehend-languages");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "comprehend-languages", "en"),
					Language = LanguageCode.En,
					Name = "Comprehend Languages",
					CastingTime = "Action",
					Range = "Self",
					Duration = "1 hour",
					MaterialComponent = "a pinch of soot and salt",
					Description = "For the duration, you understand the literal meaning of any language that you hear or see signed. You also understand any written language that you see, but you must be touching the surface on which the words are written. It takes about 1 minute to read one page of text. This spell doesn't decode symbols or secret messages.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "comprehend-languages", "it"),
					Language = LanguageCode.It,
					Name = "Comprensione dei Linguaggi",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "1 ora",
					MaterialComponent = "un pizzico di fuliggine e sale",
					Description = "Per la durata, l'incantatore comprende il significato letterale di qualsiasi linguaggio che sente o che vede segnato a gesti. Comprende inoltre qualsiasi linguaggio scritto che vede, ma deve toccare la superficie su cui sono scritte le parole. Leggere una pagina di testo richiede circa 1 minuto. Questo incantesimo non decifra simboli o messaggi segreti.",
					HigherLevels = null
				}
			}
		};
	}
}
