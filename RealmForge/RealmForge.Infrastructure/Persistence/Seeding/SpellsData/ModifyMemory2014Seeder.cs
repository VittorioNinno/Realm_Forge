using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Modify Memory (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ModifyMemory2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "modify-memory");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "modify-memory", "en"),
					Language = LanguageCode.En,
					Name = "Modify Memory",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You attempt to reshape another creature's memories. One creature that you can see must make a Wisdom saving throw. If you are fighting the creature, it has advantage on the saving throw. On a failed save, the target becomes charmed by you for the duration. The charmed target is incapacitated and unaware of its surroundings, though it can still hear you. If it takes any damage or is targeted by another spell, this spell ends, and none of the target's memories are modified.\n\nWhile this charm lasts, you can affect the target's memory of an event that it experienced within the last 24 hours and that lasted no more than 10 minutes. You can permanently eliminate all memory of the event, allow the target to recall the event with perfect clarity and exacting detail, change its memory of the details of the event, or create a memory of some other event.\n\nYou must speak to the target to describe how its memories are affected, and it must be able to understand your language for the modified memories to take root. Its mind fills in any gaps in the details of your description. If the spell ends before you have finished describing the modified memories, the creature's memory isn't altered. Otherwise, the modified memories take hold when the spell ends.\n\nA modified memory doesn't necessarily affect how a creature behaves, particularly if the memory contradicts the creature's natural inclinations, alignment, or beliefs. An illogical modified memory, such as implanting a memory of how much the creature enjoyed dousing itself in acid, is dismissed, perhaps as a bad dream. The GM might deem a modified memory too nonsensical to affect a creature in a significant manner.\n\nA remove curse or greater restoration spell cast on the target restores the creature's true memory.",
					HigherLevels = "If you cast this spell using a spell slot of 6th level or higher, you can alter the target's memories of an event that took place up to 7 days ago (6th level), 30 days ago (7th level), 1 year ago (8th level), or any time in the creature's past (9th level)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "modify-memory", "it"),
					Language = LanguageCode.It,
					Name = "Modificare Memoria",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore tenta di rimodellare i ricordi di un'altra creatura. Una creatura che l'incantatore è in grado di vedere deve effettuare un tiro salvezza su Saggezza. Se l'incantatore la sta combattendo, la creatura dispone di vantaggio al tiro salvezza. Se lo fallisce, il bersaglio è affascinato dall'incantatore per la durata. Il bersaglio affascinato è incapacitato e non è consapevole di ciò che lo circonda, ma può comunque sentire l'incantatore. Se subisce danni o viene bersagliato da un altro incantesimo, questo incantesimo termina e nessuno dei ricordi del bersaglio viene modificato.\n\nFinché questo ammaliamento dura, l'incantatore può influenzare il ricordo che il bersaglio ha di un evento che ha vissuto nelle ultime 24 ore e che non è durato più di 10 minuti. Può eliminare permanentemente ogni ricordo dell'evento, permettere al bersaglio di ricordarlo con perfetta chiarezza e dovizia di particolari, modificare il ricordo dei dettagli dell'evento o creare il ricordo di un evento diverso.\n\nL'incantatore deve parlare al bersaglio per descrivere come vengono modificati i suoi ricordi, e il bersaglio deve essere in grado di comprendere il suo linguaggio perché i ricordi modificati attecchiscano. La mente del bersaglio colma eventuali lacune nei dettagli della descrizione. Se l'incantesimo termina prima che l'incantatore abbia finito di descrivere i ricordi modificati, la memoria della creatura non viene alterata. Altrimenti, i ricordi modificati attecchiscono quando l'incantesimo termina.\n\nUn ricordo modificato non influenza necessariamente il comportamento di una creatura, in particolare se contraddice le sue inclinazioni naturali, il suo allineamento o le sue convinzioni. Un ricordo modificato illogico, come l'impianto del ricordo di quanto la creatura si sia divertita a cospargersi di acido, viene scartato, magari come un brutto sogno. Il DM può ritenere un ricordo modificato troppo privo di senso per influenzare la creatura in modo significativo.\n\nUn incantesimo rimuovi maledizione o ristorare superiore lanciato sul bersaglio ripristina i veri ricordi della creatura.",
					HigherLevels = "Se l'incantatore lancia questo incantesimo usando uno slot incantesimo di 6° livello o superiore, può alterare i ricordi del bersaglio relativi a un evento accaduto fino a 7 giorni prima (6° livello), 30 giorni prima (7° livello), 1 anno prima (8° livello) o in qualsiasi momento del passato della creatura (9° livello)."
				}
			}
		};
	}
}
