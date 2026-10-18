using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Message (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Message2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "message");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = false,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "message", "en"),
					Language = LanguageCode.En,
					Name = "Message",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "1 round",
					MaterialComponent = "a copper wire",
					Description = "You point toward a creature within range and whisper a message. The target (and only the target) hears the message and can reply in a whisper that only you can hear.\n\nYou can cast this spell through solid objects if you are familiar with the target and know it is beyond the barrier. Magical silence; 1 foot of stone, metal, or wood; or a thin sheet of lead blocks the spell.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "message", "it"),
					Language = LanguageCode.It,
					Name = "Messaggio",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "1 round",
					MaterialComponent = "un filo di rame",
					Description = "L'incantatore indica una creatura entro gittata e sussurra un messaggio. Il bersaglio (e soltanto il bersaglio) sente il messaggio e può rispondere con un sussurro che soltanto l'incantatore può sentire.\n\nL'incantatore può lanciare questo incantesimo attraverso oggetti solidi, se conosce il bersaglio e sa che si trova oltre la barriera. Il silenzio magico, 30 centimetri di pietra, metallo o legno, o una sottile lamina di piombo bloccano l'incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
