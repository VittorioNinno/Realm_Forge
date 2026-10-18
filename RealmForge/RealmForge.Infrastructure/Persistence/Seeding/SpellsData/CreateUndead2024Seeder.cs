using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Create Undead (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CreateUndead2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "create-undead");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "create-undead", "en"),
					Language = LanguageCode.En,
					Name = "Create Undead",
					CastingTime = "1 minute",
					Range = "10 feet",
					Duration = "Instantaneous",
					MaterialComponent = "one 150+ GP black onyx stone for each corpse",
					Description = "You can cast this spell only at night. Choose up to three corpses of Medium or Small Humanoids within range. Each one becomes a **Ghoul** under your control (see \"Monsters\" for its stat block).\n\nAs a Bonus Action on each of your turns, you can mentally command any creature you animated with this spell if the creature is within 120 feet of you (if you control multiple creatures, you can command any of them at the same time, issuing the same command to them). You decide what action the creature will take and where it will move on its next turn, or you can issue a general command, such as to guard a particular place. If you issue no commands, the creature takes the Dodge action and moves only to avoid harm. Once given an order, the creature continues to follow the order until its task is complete.\n\nThe creature is under your control for 24 hours, after which it stops obeying any command you've given it. To maintain control of the creature for another 24 hours, you must cast this spell on the creature before the current 24-hour period ends. This use of the spell reasserts your control over up to three creatures you have animated with this spell rather than animating new ones.",
					HigherLevels = "If you use a level 7 spell slot, you can animate or reassert control over four **Ghouls**. If you use a level 8 spell slot, you can animate or reassert control over five **Ghouls** or two **Ghasts** or **Wights**. If you use a level 9 spell slot, you can animate or reassert control over six **Ghouls**, three **Ghasts** or **Wights**, or two **Mummies**. See \"Monsters\" for these stat blocks."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "create-undead", "it"),
					Language = LanguageCode.It,
					Name = "Creare Non Morti",
					CastingTime = "1 minuto",
					Range = "3 metri",
					Duration = "Istantanea",
					MaterialComponent = "una pietra di onice nero del valore di almeno 150 mo per ogni cadavere",
					Description = "L'incantatore può lanciare questo incantesimo soltanto di notte. Sceglie entro gittata fino a tre cadaveri di umanoidi di taglia Media o Piccola. Ognuno di essi diventa un **ghoul** sotto il controllo dell'incantatore (la scheda delle statistiche si trova nel capitolo \"Mostri\" dell'SRD).\n\nCome azione bonus in ognuno dei suoi turni, l'incantatore può impartire mentalmente un comando a qualsiasi creatura animata con questo incantesimo, se la creatura si trova entro 36 metri da lui (se controlla più creature, può impartire un comando a qualsiasi di esse contemporaneamente, dando a tutte lo stesso comando). L'incantatore decide quale azione effettuerà la creatura e dove si muoverà nel suo turno successivo, oppure può impartire un comando generico, come sorvegliare un luogo specifico. Se l'incantatore non impartisce alcun comando, la creatura effettua l'azione di Schivata e si muove soltanto per evitare pericoli. Una volta ricevuto un ordine, la creatura continua a eseguirlo finché il compito non è portato a termine.\n\nLa creatura è sotto il controllo dell'incantatore per 24 ore, dopodiché smette di obbedire ai comandi ricevuti. Per mantenere il controllo della creatura per altre 24 ore, l'incantatore deve lanciare questo incantesimo sulla creatura prima che termini il periodo di 24 ore in corso. Questo utilizzo dell'incantesimo riafferma il controllo su un massimo di tre creature animate con questo incantesimo, invece di animarne di nuove.",
					HigherLevels = "Se usa uno slot incantesimo di 7° livello, l'incantatore può animare o riaffermare il controllo su quattro **ghoul**. Se usa uno slot incantesimo di 8° livello, può animare o riaffermare il controllo su cinque **ghoul** oppure su due **ghast** o **wight**. Se usa uno slot incantesimo di 9° livello, può animare o riaffermare il controllo su sei **ghoul**, su tre **ghast** o **wight**, oppure su due **mummie**. Le schede delle statistiche di queste creature si trovano nel capitolo \"Mostri\" dell'SRD."
				}
			}
		};
	}
}
