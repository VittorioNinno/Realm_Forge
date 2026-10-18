using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Magic Mouth (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MagicMouth2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-mouth");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-mouth", "en"),
					Language = LanguageCode.En,
					Name = "Magic Mouth",
					CastingTime = "1 minute",
					Range = "30 feet",
					Duration = "Until dispelled",
					MaterialComponent = "jade dust worth 10+ GP, which the spell consumes",
					Description = "You implant a message within an object in range—a message that is uttered when a trigger condition is met. Choose an object that you can see and that isn't being worn or carried by another creature. Then speak the message, which must be 25 words or fewer, though it can be delivered over as long as 10 minutes. Finally, determine the circumstance that will trigger the spell to deliver your message.\n\nWhen that trigger occurs, a magical mouth appears on the object and recites the message in your voice and at the same volume you spoke. If the object you chose has a mouth or something that looks like a mouth (for example, the mouth of a statue), the magical mouth appears there, so the words appear to come from the object's mouth. When you cast this spell, you can have the spell end after it delivers its message, or it can remain and repeat its message whenever the trigger occurs.\n\nThe trigger can be as general or as detailed as you like, though it must be based on visual or audible conditions that occur within 30 feet of the object. For example, you could instruct the mouth to speak when any creature moves within 30 feet of the object or when a silver bell rings within 30 feet of it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magic-mouth", "it"),
					Language = LanguageCode.It,
					Name = "Bocca Magica",
					CastingTime = "1 minuto",
					Range = "9 metri",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "polvere di giada del valore di almeno 10 mo, che l'incantesimo consuma",
					Description = "L'incantatore impianta un messaggio in un oggetto entro gittata: un messaggio che viene pronunciato quando si verifica una condizione di innesco. Sceglie un oggetto che è in grado di vedere e che non sia indossato o trasportato da un'altra creatura. Poi pronuncia il messaggio, che deve essere composto da 25 parole o meno, anche se può essere recitato nell'arco di un massimo di 10 minuti. Infine, stabilisce la circostanza che innescherà l'incantesimo per far recitare il messaggio.\n\nQuando si verifica l'innesco, sull'oggetto compare una bocca magica che recita il messaggio con la voce dell'incantatore e allo stesso volume con cui lo ha pronunciato. Se l'oggetto scelto ha una bocca o qualcosa che somiglia a una bocca (per esempio, la bocca di una statua), la bocca magica compare lì, in modo che le parole sembrino provenire dalla bocca dell'oggetto. Quando lancia questo incantesimo, l'incantatore può far terminare l'incantesimo dopo che ha recitato il messaggio, oppure farlo rimanere attivo affinché ripeta il messaggio ogni volta che si verifica l'innesco.\n\nL'innesco può essere generico o dettagliato quanto l'incantatore desidera, ma deve basarsi su condizioni visive o udibili che si verificano entro 9 metri dall'oggetto. Per esempio, l'incantatore potrebbe ordinare alla bocca di parlare quando una qualsiasi creatura si muove entro 9 metri dall'oggetto o quando una campanella d'argento suona entro 9 metri da esso.",
					HigherLevels = null
				}
			}
		};
	}
}
