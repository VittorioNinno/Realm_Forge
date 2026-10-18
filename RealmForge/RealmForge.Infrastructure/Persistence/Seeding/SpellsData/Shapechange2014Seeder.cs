using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Shapechange (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Shapechange2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shapechange");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 9,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shapechange", "en"),
					Language = LanguageCode.En,
					Name = "Shapechange",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a jade circlet worth at least 1,500 gp, which you must place on your head before you cast the spell",
					Description = "You assume the form of a different creature for the duration. The new form can be of any creature with a challenge rating equal to your level or lower. The creature can't be a construct or an undead, and you must have seen the sort of creature at least once. You transform into an average example of that creature, one without any class levels or the Spellcasting trait.\n\nYour game statistics are replaced by the statistics of the chosen creature, though you retain your alignment and Intelligence, Wisdom, and Charisma scores. You also retain all of your skill and saving throw proficiencies, in addition to gaining those of the creature. If the creature has the same proficiency as you and the bonus listed in its statistics is higher than yours, use the creature's bonus in place of yours. You can't use any legendary actions or lair actions of the new form.\n\nYou assume the hit points and Hit Dice of the new form. When you revert to your normal form, you return to the number of hit points you had before you transformed. If you revert as a result of dropping to 0 hit points, any excess damage carries over to your normal form. As long as the excess damage doesn't reduce your normal form to 0 hit points, you aren't knocked unconscious.\n\nYou retain the benefit of any features from your class, race, or other source and can use them, provided that your new form is physically capable of doing so. You can't use any special senses you have (for example, darkvision) unless your new form also has that sense. You can only speak if the creature can normally speak.\n\nWhen you transform, you choose whether your equipment falls to the ground, merges into the new form, or is worn by it. Worn equipment functions as normal. The GM determines whether it is practical for the new form to wear a piece of equipment, based on the creature's shape and size. Your equipment doesn't change shape or size to match the new form, and any equipment that the new form can't wear must either fall to the ground or merge into your new form. Equipment that merges has no effect in that state.\n\nDuring this spell's duration, you can use your action to assume a different form following the same restrictions and rules for the original form, with one exception: if your new form has more hit points than your current one, your hit points remain at their current value.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shapechange", "it"),
					Language = LanguageCode.It,
					Name = "Trasformazione",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un diadema di giada del valore di almeno 1.500 mo, che l'incantatore deve porsi sul capo prima di lanciare l'incantesimo",
					Description = "Per la durata, l'incantatore assume la forma di una creatura diversa. La nuova forma può essere quella di qualsiasi creatura con grado di sfida pari o inferiore al livello dell'incantatore. La creatura non può essere un costrutto o un non morto, e l'incantatore deve aver visto quel tipo di creatura almeno una volta. Si trasforma in un esemplare medio di quella creatura, privo di livelli di classe e del tratto Incantesimi.\n\nLe statistiche di gioco dell'incantatore vengono sostituite da quelle della creatura scelta, ma l'incantatore conserva il proprio allineamento e i propri punteggi di Intelligenza, Saggezza e Carisma. Conserva inoltre tutte le sue competenze nelle abilità e nei tiri salvezza, oltre a ottenere quelle della creatura. Se la creatura possiede la sua stessa competenza e il bonus indicato nelle sue statistiche è più alto del suo, l'incantatore usa il bonus della creatura al posto del proprio. Non può usare le azioni leggendarie né le azioni di tana della nuova forma.\n\nL'incantatore assume i punti ferita e i Dadi Vita della nuova forma. Quando torna alla sua forma normale, recupera i punti ferita che aveva prima della trasformazione. Se torna alla forma normale perché è sceso a 0 punti ferita, gli eventuali danni in eccesso si trasferiscono alla sua forma normale. Finché i danni in eccesso non riducono la sua forma normale a 0 punti ferita, non cade privo di sensi.\n\nL'incantatore conserva i benefici di tutti i privilegi derivanti dalla sua classe, dalla sua razza o da altre fonti e può usarli, purché la nuova forma sia fisicamente in grado di farlo. Non può usare i sensi speciali che possiede (per esempio la scurovisione), a meno che anche la nuova forma non possieda quel senso. Può parlare soltanto se la creatura è normalmente in grado di parlare.\n\nQuando si trasforma, l'incantatore sceglie se il suo equipaggiamento cade a terra, si fonde nella nuova forma o viene indossato da essa. L'equipaggiamento indossato funziona normalmente. Il DM stabilisce se è pratico per la nuova forma indossare un oggetto dell'equipaggiamento, in base alla forma e alla taglia della creatura. L'equipaggiamento non cambia forma o dimensioni per adattarsi alla nuova forma, e qualsiasi oggetto che la nuova forma non può indossare deve cadere a terra o fondersi nella nuova forma. L'equipaggiamento fuso non ha alcun effetto in quello stato.\n\nPer la durata di questo incantesimo, l'incantatore può usare la sua azione per assumere una forma diversa, seguendo le stesse restrizioni e regole della forma originale, con un'eccezione: se la nuova forma ha più punti ferita di quella attuale, i suoi punti ferita restano al valore attuale.",
					HigherLevels = null
				}
			}
		};
	}
}
