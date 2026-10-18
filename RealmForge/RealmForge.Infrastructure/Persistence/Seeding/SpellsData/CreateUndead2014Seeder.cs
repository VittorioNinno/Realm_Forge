using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Create Undead (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CreateUndead2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "create-undead");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "create-undead", "en"),
					Language = LanguageCode.En,
					Name = "Create Undead",
					CastingTime = "1 minute",
					Range = "10 feet",
					Duration = "Instantaneous",
					MaterialComponent = "one clay pot filled with grave dirt, one clay pot filled with brackish water, and one 150 gp black onyx stone for each corpse",
					Description = "You can cast this spell only at night. Choose up to three corpses of Medium or Small humanoids within range. Each corpse becomes a ghoul under your control. (The GM has game statistics for these creatures.)\n\nAs a bonus action on each of your turns, you can mentally command any creature you animated with this spell if the creature is within 120 feet of you (if you control multiple creatures, you can command any or all of them at the same time, issuing the same command to each one). You decide what action the creature will take and where it will move during its next turn, or you can issue a general command, such as to guard a particular chamber or corridor. If you issue no commands, the creature only defends itself against hostile creatures. Once given an order, the creature continues to follow it until its task is complete.\n\nThe creature is under your control for 24 hours, after which it stops obeying any command you have given it. To maintain control of the creature for another 24 hours, you must cast this spell on the creature before the current 24-hour period ends. This use of the spell reasserts your control over up to three creatures you have animated with this spell, rather than animating new ones.",
					HigherLevels = "When you cast this spell using a 7th-level spell slot, you can animate or reassert control over four ghouls. When you cast this spell using an 8th-level spell slot, you can animate or reassert control over five ghouls or two ghasts or wights. When you cast this spell using a 9th-level spell slot, you can animate or reassert control over six ghouls, three ghasts or wights, or two mummies."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "create-undead", "it"),
					Language = LanguageCode.It,
					Name = "Creare Non Morti",
					CastingTime = "1 minuto",
					Range = "3 metri",
					Duration = "Istantanea",
					MaterialComponent = "un vaso di terracotta pieno di terra di sepoltura, un vaso di terracotta pieno di acqua salmastra e una pietra di onice nero da 150 mo per ogni cadavere",
					Description = "L'incantatore può lanciare questo incantesimo soltanto di notte. Sceglie fino a tre cadaveri di umanoidi di taglia Media o Piccola entro gittata. Ogni cadavere diventa un ghoul sotto il suo controllo. (Il DM possiede le statistiche di gioco di queste creature.)\n\nCome azione bonus in ognuno dei suoi turni, l'incantatore può impartire mentalmente un comando a qualsiasi creatura animata con questo incantesimo, se la creatura si trova entro 36 metri da lui (se controlla più creature, può impartire un comando a una qualsiasi di esse o a tutte contemporaneamente, dando lo stesso ordine a ciascuna). L'incantatore decide quale azione compirà la creatura e dove si muoverà durante il suo turno successivo, oppure può impartire un comando generico, come sorvegliare una certa stanza o un certo corridoio. Se non impartisce alcun comando, la creatura si limita a difendersi dalle creature ostili. Una volta ricevuto un ordine, la creatura continua a eseguirlo finché il suo compito non è portato a termine.\n\nLa creatura rimane sotto il controllo dell'incantatore per 24 ore, dopodiché smette di obbedire a qualsiasi comando ricevuto. Per mantenere il controllo della creatura per altre 24 ore, l'incantatore deve lanciare questo incantesimo sulla creatura prima che termini il periodo di 24 ore in corso. Questo utilizzo dell'incantesimo riafferma il controllo dell'incantatore su un massimo di tre creature animate con questo incantesimo, invece di animarne di nuove.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 7° livello, può animare quattro ghoul o riaffermare il controllo su di essi. Quando lo lancia usando uno slot incantesimo di 8° livello, può animare cinque ghoul oppure due ghast o wight, o riaffermare il controllo su di essi. Quando lo lancia usando uno slot incantesimo di 9° livello, può animare sei ghoul, tre ghast o wight oppure due mummie, o riaffermare il controllo su di essi."
				}
			}
		};
	}
}
