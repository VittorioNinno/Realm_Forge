using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Illusory Script (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class IllusoryScript2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "illusory-script");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = false,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "illusory-script", "en"),
					Language = LanguageCode.En,
					Name = "Illusory Script",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "10 days",
					MaterialComponent = "ink worth 10+ GP, which the spell consumes",
					Description = "You write on parchment, paper, or another suitable material and imbue it with an illusion that lasts for the duration. To you and any creatures you designate when you cast the spell, the writing appears normal, seems to be written in your hand, and conveys whatever meaning you intended when you wrote the text. To all others, the writing appears as if it were written in an unknown or magical script that is unintelligible. Alternatively, the illusion can alter the meaning, handwriting, and language of the text, though the language must be one you know.\n\nIf the spell is dispelled, the original script and the illusion both disappear.\n\nA creature that has Truesight can read the hidden message.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "illusory-script", "it"),
					Language = LanguageCode.It,
					Name = "Scritto Illusorio",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "10 giorni",
					MaterialComponent = "inchiostro del valore di almeno 10 mo, che l'incantesimo consuma",
					Description = "L'incantatore scrive su una pergamena, su un foglio di carta o su un altro materiale adatto e lo infonde di un'illusione che permane per la durata. Per l'incantatore e per le eventuali creature da lui designate al momento del lancio, lo scritto appare normale, sembra scritto di suo pugno e trasmette il significato che intendeva dargli quando lo ha scritto. Per tutti gli altri, lo scritto appare come se fosse redatto in una scrittura sconosciuta o magica, del tutto incomprensibile. In alternativa, l'illusione può alterare il significato, la calligrafia e il linguaggio del testo, ma il linguaggio deve essere uno di quelli conosciuti dall'incantatore.\n\nSe l'incantesimo viene dissolto, sia lo scritto originale sia l'illusione scompaiono.\n\nUna creatura che dispone di vista pura può leggere il messaggio nascosto.",
					HigherLevels = null
				}
			}
		};
	}
}
