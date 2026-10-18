using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Unseen Servant (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class UnseenServant2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "unseen-servant");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "unseen-servant", "en"),
					Language = LanguageCode.En,
					Name = "Unseen Servant",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "1 hour",
					MaterialComponent = "a bit of string and of wood",
					Description = "This spell creates an Invisible, mindless, shapeless, Medium force that performs simple tasks at your command until the spell ends. The servant springs into existence in an unoccupied space on the ground within range. It has AC 10, 1 Hit Point, and a Strength of 2, and it can't attack. If it drops to 0 Hit Points, the spell ends.\n\nOnce on each of your turns as a Bonus Action, you can mentally command the servant to move up to 15 feet and interact with an object. The servant can perform simple tasks that a human could do, such as fetching things, cleaning, mending, folding clothes, lighting fires, serving food, and pouring drinks. Once you give the command, the servant performs the task to the best of its ability until it completes the task, then waits for your next command.\n\nIf you command the servant to perform a task that would move it more than 60 feet away from you, the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "unseen-servant", "it"),
					Language = LanguageCode.It,
					Name = "Servitore Inosservato",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "1 ora",
					MaterialComponent = "un pezzetto di spago e uno di legno",
					Description = "Questo incantesimo crea una forza invisibile, priva di mente e di forma, di taglia Media, che svolge compiti semplici al comando dell'incantatore finché l'incantesimo non termina. Il servitore prende forma in uno spazio libero sul terreno entro gittata. Ha CA 10, 1 punto ferita e Forza 2, e non può attaccare. Se scende a 0 punti ferita, l'incantesimo termina.\n\nUna volta in ognuno dei suoi turni, come azione bonus, l'incantatore può ordinare mentalmente al servitore di muoversi fino a 4,5 metri e di interagire con un oggetto. Il servitore può svolgere compiti semplici che potrebbe svolgere un umano, come andare a prendere oggetti, pulire, rammendare, piegare abiti, accendere fuochi, servire il cibo e versare da bere. Una volta ricevuto il comando, il servitore svolge il compito al meglio delle sue capacità finché non lo porta a termine, poi attende il comando successivo.\n\nSe l'incantatore ordina al servitore di svolgere un compito che lo porterebbe a più di 18 metri di distanza da lui, l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
