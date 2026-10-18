using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Animate Dead (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AnimateDead2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animate-dead");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animate-dead", "en"),
					Language = LanguageCode.En,
					Name = "Animate Dead",
					CastingTime = "1 minute",
					Range = "10 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a drop of blood, a piece of flesh, and a pinch of bone dust",
					Description = "This spell creates an undead servant. Choose a pile of bones or a corpse of a Medium or Small humanoid within range. Your spell imbues the target with a foul mimicry of life, raising it as an undead creature. The target becomes a skeleton if you chose bones or a zombie if you chose a corpse (the GM has the creature's game statistics).\n\nOn each of your turns, you can use a bonus action to mentally command any creature you made with this spell if the creature is within 60 feet of you (if you control multiple creatures, you can command any or all of them at the same time, issuing the same command to each one). You decide what action the creature will take and where it will move during its next turn, or you can issue a general command, such as to guard a particular chamber or corridor. If you issue no commands, the creature only defends itself against hostile creatures. Once given an order, the creature continues to follow it until its task is complete.\n\nThe creature is under your control for 24 hours, after which it stops obeying any command you've given it. To maintain control of the creature for another 24 hours, you must cast this spell on the creature again before the current 24-hour period ends. This use of the spell reasserts your control over up to four creatures you have animated with this spell, rather than animating a new one.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, you animate or reassert control over two additional undead creatures for each slot level above 3rd. Each of the creatures must come from a different corpse or pile of bones."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animate-dead", "it"),
					Language = LanguageCode.It,
					Name = "Animare Morti",
					CastingTime = "1 minuto",
					Range = "3 metri",
					Duration = "Istantanea",
					MaterialComponent = "una goccia di sangue, un pezzo di carne e un pizzico di polvere d'ossa",
					Description = "Questo incantesimo crea un servitore non morto. L'incantatore sceglie entro gittata un mucchio di ossa o il cadavere di un umanoide di taglia Media o Piccola. L'incantesimo infonde nel bersaglio una ripugnante parodia di vita, rianimandolo come creatura non morta. Il bersaglio diventa uno scheletro se l'incantatore ha scelto delle ossa, o uno zombi se ha scelto un cadavere (il DM possiede le statistiche di gioco della creatura).\n\nIn ogni suo turno, l'incantatore può usare un'azione bonus per impartire mentalmente un comando a qualsiasi creatura creata con questo incantesimo, se la creatura si trova entro 18 metri da lui (se controlla più creature, può impartire un comando a una qualsiasi di esse o a tutte contemporaneamente, dando lo stesso ordine a ciascuna). L'incantatore decide quale azione compirà la creatura e dove si muoverà durante il suo turno successivo, oppure può impartire un comando generico, come sorvegliare una certa stanza o un certo corridoio. Se non impartisce alcun comando, la creatura si limita a difendersi dalle creature ostili. Una volta ricevuto un ordine, la creatura continua a eseguirlo finché il suo compito non è portato a termine.\n\nLa creatura rimane sotto il controllo dell'incantatore per 24 ore, dopodiché smette di obbedire a qualsiasi comando ricevuto. Per mantenere il controllo della creatura per altre 24 ore, l'incantatore deve lanciare di nuovo questo incantesimo sulla creatura prima che termini il periodo di 24 ore in corso. Questo utilizzo dell'incantesimo riafferma il controllo dell'incantatore su un massimo di quattro creature animate con questo incantesimo, invece di animarne una nuova.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, anima o riafferma il controllo su due creature non morte aggiuntive per ogni livello dello slot superiore al 3°. Ognuna di queste creature deve provenire da un cadavere o da un mucchio di ossa diverso."
				}
			}
		};
	}
}
