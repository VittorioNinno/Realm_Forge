using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcane Lock (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ArcaneLock2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-lock");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-lock", "en"),
					Language = LanguageCode.En,
					Name = "Arcane Lock",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "gold dust worth at least 25 gp, which the spell consumes",
					Description = "You touch a closed door, window, gate, chest, or other entryway, and it becomes locked for the duration. You and the creatures you designate when you cast this spell can open the object normally. You can also set a password that, when spoken within 5 feet of the object, suppresses this spell for 1 minute. Otherwise, it is impassable until it is broken or the spell is dispelled or suppressed. Casting knock on the object suppresses arcane lock for 10 minutes.\n\nWhile affected by this spell, the object is more difficult to break or force open; the DC to break it or pick any locks on it increases by 10.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "arcane-lock", "it"),
					Language = LanguageCode.It,
					Name = "Serratura Arcana",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "polvere d'oro del valore di almeno 25 mo, che l'incantesimo consuma",
					Description = "L'incantatore tocca una porta, una finestra, un cancello, uno scrigno o un altro accesso chiuso, che rimane serrato per la durata. L'incantatore e le creature da lui designate al momento del lancio possono aprire l'oggetto normalmente. L'incantatore può anche stabilire una parola d'ordine che, se pronunciata entro 1,5 metri dall'oggetto, sopprime questo incantesimo per 1 minuto. Altrimenti, l'oggetto rimane invalicabile finché non viene sfondato o finché l'incantesimo non viene dissolto o soppresso. Lanciare scassinare sull'oggetto sopprime serratura arcana per 10 minuti.\n\nFinché è influenzato da questo incantesimo, l'oggetto è più difficile da rompere o da forzare: la CD per romperlo o per scassinarne le serrature aumenta di 10.",
					HigherLevels = null
				}
			}
		};
	}
}
