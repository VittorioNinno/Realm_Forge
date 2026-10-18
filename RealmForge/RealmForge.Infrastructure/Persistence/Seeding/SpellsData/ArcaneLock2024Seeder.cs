using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcane Lock (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ArcaneLock2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-lock");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-lock", "en"),
					Language = LanguageCode.En,
					Name = "Arcane Lock",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "gold dust worth 25+ GP, which the spell consumes",
					Description = "You touch a closed door, window, gate, container, or hatch and magically lock it for the duration. This lock can't be unlocked by any nonmagical means. You and any creatures you designate when you cast the spell can open and close the object despite the lock. You can also set a password that, when spoken within 5 feet of the object, unlocks it for 1 minute.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-lock", "it"),
					Language = LanguageCode.It,
					Name = "Serratura Arcana",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "polvere d'oro del valore di almeno 25 mo, che l'incantesimo consuma",
					Description = "L'incantatore tocca una porta, una finestra, un cancello, un contenitore o una botola chiusi e li blocca magicamente per la durata. Questa serratura non può essere aperta con mezzi non magici. L'incantatore e le eventuali creature da lui designate al momento del lancio possono aprire e chiudere l'oggetto nonostante la serratura. L'incantatore può anche stabilire una parola d'ordine che, se pronunciata entro 1,5 metri dall'oggetto, lo sblocca per 1 minuto.",
					HigherLevels = null
				}
			}
		};
	}
}
