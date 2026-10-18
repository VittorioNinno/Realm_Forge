using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Message (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Message2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "message");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "message", "en"),
					Language = LanguageCode.En,
					Name = "Message",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "1 round",
					MaterialComponent = "a short piece of copper wire",
					Description = "You point your finger toward a creature within range and whisper a message. The target (and only the target) hears the message and can reply in a whisper that only you can hear.\n\nYou can cast this spell through solid objects if you are familiar with the target and know it is beyond the barrier. Magical silence, 1 foot of stone, 1 inch of common metal, a thin sheet of lead, or 3 feet of wood blocks the spell. The spell doesn't have to follow a straight line and can travel freely around corners or through openings.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "message", "it"),
					Language = LanguageCode.It,
					Name = "Messaggio",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "1 round",
					MaterialComponent = "un corto pezzo di filo di rame",
					Description = "L'incantatore punta il dito verso una creatura entro gittata e sussurra un messaggio. Il bersaglio (e soltanto il bersaglio) sente il messaggio e può rispondere con un sussurro che soltanto l'incantatore può sentire.\n\nL'incantatore può lanciare questo incantesimo attraverso oggetti solidi se conosce il bersaglio e sa che si trova oltre la barriera. Il silenzio magico, 30 cm di pietra, 2,5 cm di metallo comune, una sottile lamina di piombo o 90 cm di legno bloccano l'incantesimo. L'incantesimo non deve seguire una linea retta e può aggirare liberamente gli angoli o passare attraverso le aperture.",
					HigherLevels = null
				}
			}
		};
	}
}
