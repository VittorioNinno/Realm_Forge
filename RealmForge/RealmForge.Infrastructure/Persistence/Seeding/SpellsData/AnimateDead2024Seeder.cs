using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Animate Dead (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AnimateDead2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animate-dead");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animate-dead", "en"),
					Language = LanguageCode.En,
					Name = "Animate Dead",
					CastingTime = "1 minute",
					Range = "10 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a drop of blood, a piece of flesh, and a pinch of bone dust",
					Description = "Choose a pile of bones or a corpse of a Medium or Small Humanoid within range. The target becomes an Undead creature: a **Skeleton** if you chose bones or a **Zombie** if you chose a corpse (see \"Monsters\" for the stat blocks).\n\nOn each of your turns, you can take a Bonus Action to mentally command any creature you made with this spell if the creature is within 60 feet of you (if you control multiple creatures, you can command any of them at the same time, issuing the same command to each one). You decide what action the creature will take and where it will move on its next turn, or you can issue a general command, such as to guard a chamber or corridor. If you issue no commands, the creature takes the Dodge action and moves only to avoid harm. Once given an order, the creature continues to follow it until its task is complete.\n\nThe creature is under your control for 24 hours, after which it stops obeying any command you've given it. To maintain control of the creature for another 24 hours, you must cast this spell on the creature again before the current 24-hour period ends. This use of the spell reasserts your control over up to four creatures you have animated with this spell rather than animating a new creature.",
					HigherLevels = "You animate or reassert control over two additional Undead creatures for each spell slot level above 3. Each of the creatures must come from a different corpse or pile of bones."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animate-dead", "it"),
					Language = LanguageCode.It,
					Name = "Animare Morti",
					CastingTime = "1 minuto",
					Range = "3 metri",
					Duration = "Istantanea",
					MaterialComponent = "una goccia di sangue, un pezzo di carne e un pizzico di polvere d'ossa",
					Description = "L'incantatore sceglie entro gittata un mucchio di ossa o il cadavere di un umanoide di taglia Media o Piccola. Il bersaglio diventa una creatura non morta: uno **scheletro** se l'incantatore ha scelto delle ossa o uno **zombi** se ha scelto un cadavere (le schede delle statistiche si trovano nel capitolo \"Mostri\" dell'SRD).\n\nIn ognuno dei suoi turni, l'incantatore può effettuare un'azione bonus per impartire mentalmente un comando a qualsiasi creatura creata con questo incantesimo, se la creatura si trova entro 18 metri da lui (se controlla più creature, può impartire un comando a qualsiasi di esse contemporaneamente, dando lo stesso comando a ciascuna). L'incantatore decide quale azione effettuerà la creatura e dove si muoverà nel suo turno successivo, oppure può impartire un comando generico, come sorvegliare una stanza o un corridoio. Se l'incantatore non impartisce alcun comando, la creatura effettua l'azione di Schivata e si muove soltanto per evitare pericoli. Una volta ricevuto un ordine, la creatura continua a eseguirlo finché il compito non è portato a termine.\n\nLa creatura è sotto il controllo dell'incantatore per 24 ore, dopodiché smette di obbedire ai comandi ricevuti. Per mantenere il controllo della creatura per altre 24 ore, l'incantatore deve lanciare di nuovo questo incantesimo sulla creatura prima che termini il periodo di 24 ore in corso. Questo utilizzo dell'incantesimo riafferma il controllo su un massimo di quattro creature animate con questo incantesimo, invece di animarne una nuova.",
					HigherLevels = "L'incantatore anima o riafferma il controllo su due creature non morte aggiuntive per ogni livello dello slot incantesimo superiore al 3°. Ognuna delle creature deve provenire da un cadavere o da un mucchio di ossa diverso."
				}
			}
		};
	}
}
