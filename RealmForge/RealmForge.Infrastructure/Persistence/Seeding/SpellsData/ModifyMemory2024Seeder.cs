using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Modify Memory (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ModifyMemory2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "modify-memory");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "modify-memory", "en"),
					Language = LanguageCode.En,
					Name = "Modify Memory",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You attempt to reshape another creature's memories. One creature that you can see within range makes a Wisdom saving throw. If you are fighting the creature, it has Advantage on the save. On a failed save, the target has the Charmed condition for the duration. While Charmed in this way, the target also has the Incapacitated condition and is unaware of its surroundings, though it can hear you. If it takes any damage or is targeted by another spell, this spell ends, and no memories are modified.\n\nWhile this charm lasts, you can affect the target's memory of an event that it experienced within the last 24 hours and that lasted no more than 10 minutes. You can permanently eliminate all memory of the event, allow the target to recall the event with perfect clarity, change its memory of the event's details, or create a memory of some other event.\n\nYou must speak to the target to describe how its memories are affected, and it must be able to understand your language for the modified memories to take root. Its mind fills in any gaps in the details of your description. If the spell ends before you finish describing the modified memories, the creature's memory isn't altered. Otherwise, the modified memories take hold when the spell ends.\n\nA modified memory doesn't necessarily affect how a creature behaves, particularly if the memory contradicts the creature's natural inclinations, alignment, or beliefs. An illogical modified memory, such as a false memory of how much the creature enjoyed swimming in acid, is dismissed as a bad dream. The GM might deem a modified memory too nonsensical to affect a creature.\n\nA *Remove Curse* or *Greater Restoration* spell cast on the target restores the creature's true memory.",
					HigherLevels = "You can alter the target's memories of an event that took place up to 7 days ago (level 6 spell slot), 30 days ago (level 7 spell slot), 365 days ago (level 8 spell slot), or any time in the creature's past (level 9 spell slot)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "modify-memory", "it"),
					Language = LanguageCode.It,
					Name = "Modificare Memoria",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore tenta di rimodellare i ricordi di un'altra creatura. Una creatura entro gittata che è in grado di vedere effettua un tiro salvezza su Saggezza. Se l'incantatore sta combattendo contro la creatura, questa dispone di vantaggio al tiro salvezza. Se lo fallisce, il bersaglio è affascinato per la durata. Finché è affascinato in questo modo, il bersaglio è anche incapacitato e non è consapevole di ciò che lo circonda, anche se è in grado di sentire l'incantatore. Se subisce danni o è preso come bersaglio da un altro incantesimo, questo incantesimo termina e nessun ricordo viene modificato.\n\nFinché questo ammaliamento dura, l'incantatore può influenzare il ricordo del bersaglio relativo a un evento che ha vissuto nelle ultime 24 ore e che non è durato più di 10 minuti. Può eliminare permanentemente ogni ricordo dell'evento, permettere al bersaglio di ricordarlo con perfetta chiarezza, modificare il ricordo dei dettagli dell'evento o creare il ricordo di un altro evento.\n\nL'incantatore deve parlare al bersaglio per descrivere in che modo i suoi ricordi vengono modificati, e il bersaglio deve essere in grado di comprendere il suo linguaggio perché i ricordi modificati attecchiscano. La mente del bersaglio colma le eventuali lacune nei dettagli della descrizione. Se l'incantesimo termina prima che l'incantatore abbia finito di descrivere i ricordi modificati, la memoria della creatura non viene alterata. Altrimenti, i ricordi modificati si consolidano quando l'incantesimo termina.\n\nUn ricordo modificato non influenza necessariamente il comportamento di una creatura, in particolare se contraddice le sue inclinazioni naturali, il suo allineamento o le sue convinzioni. Un ricordo modificato illogico, come il falso ricordo di quanto alla creatura sia piaciuto nuotare nell'acido, viene liquidato come un brutto sogno. Il DM potrebbe ritenere un ricordo modificato troppo insensato per influenzare una creatura.\n\nUn incantesimo *rimuovi maledizione* o *ristorare superiore* lanciato sul bersaglio ripristina i veri ricordi della creatura.",
					HigherLevels = "L'incantatore può alterare i ricordi del bersaglio relativi a un evento avvenuto fino a 7 giorni prima (slot incantesimo di 6° livello), 30 giorni prima (slot incantesimo di 7° livello), 365 giorni prima (slot incantesimo di 8° livello) o in qualsiasi momento del passato della creatura (slot incantesimo di 9° livello)."
				}
			}
		};
	}
}
