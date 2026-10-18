using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Eyebite (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Eyebite2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "eyebite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "eyebite", "en"),
					Language = LanguageCode.En,
					Name = "Eyebite",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "For the duration, your eyes become an inky void. One creature of your choice within 60 feet of you that you can see must succeed on a Wisdom saving throw or be affected by one of the following effects of your choice for the duration.\n\nOn each of your turns until the spell ends, you can take a Magic action to target another creature but can't target a creature again if it has succeeded on a save against this casting of the spell.\n\n***Asleep.*** The target has the Unconscious condition. It wakes up if it takes any damage or if another creature takes an action to shake it awake.\n\n***Panicked.*** The target has the Frightened condition. On each of its turns, the Frightened target must take the Dash action and move away from you by the safest and shortest route available. If the target moves to a space at least 60 feet away from you where it can't see you, this effect ends.\n\n***Sickened.*** The target has the Poisoned condition.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "eyebite", "it"),
					Language = LanguageCode.It,
					Name = "Sguardo Penetrante",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Per la durata, gli occhi dell'incantatore diventano un vuoto d'inchiostro. Una creatura a scelta dell'incantatore entro 18 metri da lui, che egli è in grado di vedere, deve superare un tiro salvezza su Saggezza, altrimenti subisce per la durata uno degli effetti seguenti, a scelta dell'incantatore.\n\nIn ognuno dei suoi turni finché l'incantesimo non termina, l'incantatore può effettuare un'azione di Magia per prendere come bersaglio un'altra creatura, ma non può prendere di nuovo come bersaglio una creatura che ha superato un tiro salvezza contro questo lancio dell'incantesimo.\n\n***Addormentato.*** Il bersaglio è privo di sensi. Si sveglia se subisce danni o se un'altra creatura effettua un'azione per scuoterlo e svegliarlo.\n\n***Atterrito.*** Il bersaglio è spaventato. In ognuno dei suoi turni, il bersaglio spaventato deve effettuare l'azione di Scatto e allontanarsi dall'incantatore seguendo il percorso più sicuro e più breve disponibile. Se il bersaglio si sposta in uno spazio ad almeno 18 metri dall'incantatore da cui non può vederlo, questo effetto termina.\n\n***Nauseato.*** Il bersaglio è avvelenato.",
					HigherLevels = null
				}
			}
		};
	}
}
