using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Eyebite (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Eyebite2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "eyebite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "eyebite", "en"),
					Language = LanguageCode.En,
					Name = "Eyebite",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "For the spell's duration, your eyes become an inky void imbued with dread power. One creature of your choice within 60 feet of you that you can see must succeed on a Wisdom saving throw or be affected by one of the following effects of your choice for the duration. On each of your turns until the spell ends, you can use your action to target another creature but can't target a creature again if it has succeeded on a saving throw against this casting of eyebite.\n\n***Asleep.*** The target falls unconscious. It wakes up if it takes any damage or if another creature uses its action to shake the sleeper awake.\n\n***Panicked.*** The target is frightened of you. On each of its turns, the frightened creature must take the Dash action and move away from you by the safest and shortest available route, unless there is nowhere to move. If the target moves to a place at least 60 feet away from you where it can no longer see you, this effect ends.\n\n***Sickened.*** The target has disadvantage on attack rolls and ability checks. At the end of each of its turns, it can make another Wisdom saving throw. If it succeeds, the effect ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "eyebite", "it"),
					Language = LanguageCode.It,
					Name = "Sguardo Penetrante",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Per la durata dell'incantesimo, gli occhi dell'incantatore diventano un vuoto d'inchiostro intriso di un potere terribile. Una creatura a sua scelta entro 18 metri da lui, che egli sia in grado di vedere, deve superare un tiro salvezza su Saggezza, altrimenti per la durata è influenzata da uno degli effetti seguenti, a scelta dell'incantatore. In ognuno dei suoi turni, finché l'incantesimo non termina, l'incantatore può usare la sua azione per bersagliare un'altra creatura, ma non può bersagliare di nuovo una creatura che abbia superato un tiro salvezza contro questo lancio di sguardo penetrante.\n\n***Addormentato.*** Il bersaglio cade privo di sensi. Si sveglia se subisce danni o se un'altra creatura usa la propria azione per scuoterlo e svegliarlo.\n\n***Atterrito.*** Il bersaglio è spaventato dall'incantatore. In ognuno dei suoi turni, la creatura spaventata deve effettuare l'azione di Scatto e allontanarsi dall'incantatore seguendo il percorso più sicuro e più breve disponibile, a meno che non ci sia alcun luogo in cui spostarsi. Se il bersaglio raggiunge un luogo ad almeno 18 metri dall'incantatore da cui non può più vederlo, questo effetto termina.\n\n***Nauseato.*** Il bersaglio subisce svantaggio ai tiri per colpire e alle prove di caratteristica. Alla fine di ogni suo turno, può effettuare un altro tiro salvezza su Saggezza. Se lo supera, l'effetto termina.",
					HigherLevels = null
				}
			}
		};
	}
}
