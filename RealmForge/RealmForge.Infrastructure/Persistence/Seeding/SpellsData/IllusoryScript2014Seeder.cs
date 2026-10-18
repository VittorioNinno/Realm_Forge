using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Illusory Script (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class IllusoryScript2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "illusory-script");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "illusory-script", "en"),
					Language = LanguageCode.En,
					Name = "Illusory Script",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "10 days",
					MaterialComponent = "a lead-based ink worth at least 10 gp, which this spell consumes",
					Description = "You write on parchment, paper, or some other suitable writing material and imbue it with a potent illusion that lasts for the duration.\n\nTo you and any creatures you designate when you cast the spell, the writing appears normal, written in your hand, and conveys whatever meaning you intended when you wrote the text. To all others, the writing appears as if it were written in an unknown or magical script that is unintelligible. Alternatively, you can cause the writing to appear to be an entirely different message, written in a different hand and language, though the language must be one you know.\n\nShould the spell be dispelled, the original script and the illusion both disappear.\n\nA creature with truesight can read the hidden message.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "illusory-script", "it"),
					Language = LanguageCode.It,
					Name = "Scritto Illusorio",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "10 giorni",
					MaterialComponent = "un inchiostro a base di piombo del valore di almeno 10 mo, che l'incantesimo consuma",
					Description = "L'incantatore scrive su una pergamena, su un foglio di carta o su un altro materiale adatto alla scrittura e lo infonde di una potente illusione che dura per la durata.\n\nPer l'incantatore e per le creature da lui designate al momento del lancio, la scrittura appare normale, vergata di suo pugno, e trasmette il significato che intendeva dare al testo. Per tutti gli altri, la scrittura appare come se fosse redatta in una grafia sconosciuta o magica, del tutto incomprensibile. In alternativa, l'incantatore può far apparire la scrittura come un messaggio completamente diverso, scritto da un'altra mano e in un altro linguaggio, che però deve essere un linguaggio da lui conosciuto.\n\nSe l'incantesimo viene dissolto, scompaiono sia la scrittura originale sia l'illusione.\n\nUna creatura dotata di vista pura può leggere il messaggio nascosto.",
					HigherLevels = null
				}
			}
		};
	}
}
