using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Seeming (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Seeming2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "seeming");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "seeming", "en"),
					Language = LanguageCode.En,
					Name = "Seeming",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = null,
					Description = "This spell allows you to change the appearance of any number of creatures that you can see within range. You give each target you choose a new, illusory appearance. An unwilling target can make a Charisma saving throw, and if it succeeds, it is unaffected by this spell.\n\nThe spell disguises physical appearance as well as clothing, armor, weapons, and equipment. You can make each creature seem 1 foot shorter or taller and appear thin, fat, or in between. You can't change a target's body type, so you must choose a form that has the same basic arrangement of limbs. Otherwise, the extent of the illusion is up to you. The spell lasts for the duration, unless you use your action to dismiss it sooner.\n\nThe changes wrought by this spell fail to hold up to physical inspection. For example, if you use this spell to add a hat to a creature's outfit, objects pass through the hat, and anyone who touches it would feel nothing or would feel the creature's head and hair. If you use this spell to appear thinner than you are, the hand of someone who reaches out to touch you would bump into you while it was seemingly still in midair.\n\nA creature can use its action to inspect a target and make an Intelligence (Investigation) check against your spell save DC. If it succeeds, it becomes aware that the target is disguised.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "seeming", "it"),
					Language = LanguageCode.It,
					Name = "Sembrare",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = null,
					Description = "Questo incantesimo permette all'incantatore di modificare l'aspetto di un qualsiasi numero di creature entro gittata che sia in grado di vedere. Conferisce a ogni bersaglio scelto un nuovo aspetto illusorio. Un bersaglio non consenziente può effettuare un tiro salvezza su Carisma e, se lo supera, non è influenzato da questo incantesimo.\n\nL'incantesimo camuffa l'aspetto fisico, oltre agli abiti, all'armatura, alle armi e all'equipaggiamento. L'incantatore può far sembrare ogni creatura più bassa o più alta di 30 cm e farla apparire magra, grassa o una via di mezzo. Non può cambiare la struttura corporea di un bersaglio, quindi deve scegliere una forma con la stessa disposizione di base degli arti. Per il resto, la portata dell'illusione dipende da lui. L'incantesimo dura per la durata, a meno che l'incantatore non usi la sua azione per congedarlo prima.\n\nI cambiamenti prodotti da questo incantesimo non resistono a un'ispezione fisica. Per esempio, se l'incantatore usa questo incantesimo per aggiungere un cappello all'abbigliamento di una creatura, gli oggetti attraversano il cappello e chiunque lo tocchi non sentirebbe nulla, oppure sentirebbe la testa e i capelli della creatura. Se usa questo incantesimo per apparire più magro di quanto sia, la mano di chi cerca di toccarlo urterebbe il suo corpo mentre sembra ancora trovarsi a mezz'aria.\n\nUna creatura può usare la sua azione per esaminare un bersaglio ed effettuare una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se la supera, si accorge che il bersaglio è camuffato.",
					HigherLevels = null
				}
			}
		};
	}
}
