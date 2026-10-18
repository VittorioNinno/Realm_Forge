using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Speak with Dead (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpeakWithDead2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "speak-with-dead");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "speak-with-dead", "en"),
					Language = LanguageCode.En,
					Name = "Speak with Dead",
					CastingTime = "1 action",
					Range = "10 feet",
					Duration = "10 minutes",
					MaterialComponent = "burning incense",
					Description = "You grant the semblance of life and intelligence to a corpse of your choice within range, allowing it to answer the questions you pose. The corpse must still have a mouth and can't be undead. The spell fails if the corpse was the target of this spell within the last 10 days.\n\nUntil the spell ends, you can ask the corpse up to five questions. The corpse knows only what it knew in life, including the languages it knew. Answers are usually brief, cryptic, or repetitive, and the corpse is under no compulsion to offer a truthful answer if you are hostile to it or it recognizes you as an enemy. This spell doesn't return the creature's soul to its body, only its animating spirit. Thus, the corpse can't learn new information, doesn't comprehend anything that has happened since it died, and can't speculate about future events.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "speak-with-dead", "it"),
					Language = LanguageCode.It,
					Name = "Parlare con i Morti",
					CastingTime = "1 azione",
					Range = "3 metri",
					Duration = "10 minuti",
					MaterialComponent = "incenso acceso",
					Description = "L'incantatore conferisce una parvenza di vita e d'intelligenza a un cadavere entro gittata a sua scelta, permettendogli di rispondere alle domande che gli pone. Il cadavere deve avere ancora la bocca e non può essere un non morto. L'incantesimo fallisce se il cadavere è stato bersaglio di questo incantesimo negli ultimi 10 giorni.\n\nFinché l'incantesimo non termina, l'incantatore può porre al cadavere fino a cinque domande. Il cadavere sa soltanto ciò che sapeva in vita, inclusi i linguaggi che conosceva. Le risposte sono di solito brevi, enigmatiche o ripetitive, e il cadavere non è obbligato a dare una risposta veritiera se l'incantatore è ostile nei suoi confronti o se lo riconosce come nemico. Questo incantesimo non restituisce l'anima della creatura al suo corpo, ma solo lo spirito che lo animava. Il cadavere, quindi, non può apprendere nuove informazioni, non comprende nulla di ciò che è accaduto dopo la sua morte e non può fare congetture sugli eventi futuri.",
					HigherLevels = null
				}
			}
		};
	}
}
