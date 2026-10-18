using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Faithful Hound (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FaithfulHound2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "faithful-hound");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "faithful-hound", "en"),
					Language = LanguageCode.En,
					Name = "Faithful Hound",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = "a tiny silver whistle, a piece of bone, and a thread",
					Description = "You conjure a phantom watchdog in an unoccupied space that you can see within range, where it remains for the duration, until you dismiss it as an action, or until you move more than 100 feet away from it.\n\nThe hound is invisible to all creatures except you and can't be harmed. When a Small or larger creature comes within 30 feet of it without first speaking the password that you specify when you cast this spell, the hound starts barking loudly. The hound sees invisible creatures and can see into the Ethereal Plane. It ignores illusions.\n\nAt the start of each of your turns, the hound attempts to bite one creature within 5 feet of it that is hostile to you. The hound's attack bonus is equal to your spellcasting ability modifier + your proficiency bonus. On a hit, it deals 4d8 piercing damage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "faithful-hound", "it"),
					Language = LanguageCode.It,
					Name = "Segugio Fedele",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = "un minuscolo fischietto d'argento, un frammento d'osso e un filo",
					Description = "L'incantatore evoca un cane da guardia spettrale in uno spazio libero entro gittata che sia in grado di vedere. Il cane vi rimane per la durata, finché l'incantatore non lo congeda come azione o finché l'incantatore non si allontana di più di 30 metri da esso.\n\nIl segugio è invisibile a tutte le creature tranne l'incantatore e non può essere ferito. Quando una creatura di taglia Piccola o superiore arriva entro 9 metri da esso senza prima pronunciare la parola d'ordine stabilita dall'incantatore al momento del lancio, il segugio inizia ad abbaiare fragorosamente. Il segugio vede le creature invisibili e può vedere nel Piano Etereo. Ignora le illusioni.\n\nAll'inizio di ogni turno dell'incantatore, il segugio tenta di mordere una creatura ostile all'incantatore che si trovi entro 1,5 metri da esso. Il bonus di attacco del segugio è pari al modificatore di caratteristica da incantatore dell'incantatore + il suo bonus di competenza. Se colpisce, infligge 4d8 danni perforanti.",
					HigherLevels = null
				}
			}
		};
	}
}
