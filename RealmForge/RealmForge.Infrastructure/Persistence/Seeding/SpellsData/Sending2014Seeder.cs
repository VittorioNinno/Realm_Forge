using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sending (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Sending2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sending");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sending", "en"),
					Language = LanguageCode.En,
					Name = "Sending",
					CastingTime = "1 action",
					Range = "Unlimited",
					Duration = "1 round",
					MaterialComponent = "a short piece of fine copper wire",
					Description = "You send a short message of twenty-five words or less to a creature with which you are familiar. The creature hears the message in its mind, recognizes you as the sender if it knows you, and can answer in a like manner immediately. The spell enables creatures with Intelligence scores of at least 1 to understand the meaning of your message.\n\nYou can send the message across any distance and even to other planes of existence, but if the target is on a different plane than you, there is a 5 percent chance that the message doesn't arrive.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sending", "it"),
					Language = LanguageCode.It,
					Name = "Inviare",
					CastingTime = "1 azione",
					Range = "Illimitata",
					Duration = "1 round",
					MaterialComponent = "un corto pezzo di filo di rame sottile",
					Description = "L'incantatore invia un breve messaggio di venticinque parole o meno a una creatura che conosce. La creatura sente il messaggio nella propria mente, riconosce l'incantatore come mittente se lo conosce e può rispondere immediatamente allo stesso modo. L'incantesimo permette alle creature con un punteggio di Intelligenza pari ad almeno 1 di comprendere il significato del messaggio.\n\nL'incantatore può inviare il messaggio a qualsiasi distanza e perfino in altri piani di esistenza, ma se il bersaglio si trova su un piano diverso dal suo, c'è una probabilità del 5 per cento che il messaggio non arrivi.",
					HigherLevels = null
				}
			}
		};
	}
}
