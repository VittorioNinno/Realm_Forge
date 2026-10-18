using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Faithful Hound (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FaithfulHound2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "faithful-hound");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Conjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "faithful-hound", "en"),
					Language = LanguageCode.En,
					Name = "Faithful Hound",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = "a silver whistle",
					Description = "You conjure a phantom watchdog in an unoccupied space that you can see within range. The hound remains for the duration or until the two of you are more than 300 feet apart from each other.\n\nNo one but you can see the hound, and it is intangible and invulnerable. When a Small or larger creature comes within 30 feet of it without first speaking the password that you specify when you cast this spell, the hound starts barking loudly. The hound has Truesight with a range of 30 feet.\n\nAt the start of each of your turns, the hound attempts to bite one enemy within 5 feet of it. That enemy must succeed on a Dexterity saving throw or take 4d8 Force damage.\n\nOn your later turns, you can take a Magic action to move the hound up to 30 feet.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "faithful-hound", "it"),
					Language = LanguageCode.It,
					Name = "Segugio Fedele",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = "un fischietto d'argento",
					Description = "L'incantatore evoca un cane da guardia fantasma in uno spazio libero entro gittata che è in grado di vedere. Il segugio rimane per la durata o finché l'incantatore e il segugio non si trovano a più di 90 metri di distanza l'uno dall'altro.\n\nNessuno tranne l'incantatore può vedere il segugio, che è intangibile e invulnerabile. Quando una creatura di taglia Piccola o superiore arriva entro 9 metri da esso senza aver prima pronunciato la parola d'ordine stabilita dall'incantatore al momento del lancio, il segugio inizia ad abbaiare rumorosamente. Il segugio dispone di vista pura con un raggio di 9 metri.\n\nAll'inizio di ogni turno dell'incantatore, il segugio tenta di mordere un nemico entro 1,5 metri da sé. Quel nemico deve superare un tiro salvezza su Destrezza, altrimenti subisce 4d8 danni da forza.\n\nNei turni successivi, l'incantatore può effettuare un'azione di Magia per spostare il segugio fino a 9 metri.",
					HigherLevels = null
				}
			}
		};
	}
}
