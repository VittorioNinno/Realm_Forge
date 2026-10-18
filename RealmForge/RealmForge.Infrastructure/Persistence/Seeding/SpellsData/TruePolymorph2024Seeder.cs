using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	True Polymorph (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TruePolymorph2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "true-polymorph");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 9,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "true-polymorph", "en"),
					Language = LanguageCode.En,
					Name = "True Polymorph",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a drop of mercury, a dollop of gum arabic, and a wisp of smoke",
					Description = "Choose one creature or nonmagical object that you can see within range. The creature shape-shifts into a different creature or a nonmagical object, or the object shape-shifts into a creature (the object must be neither worn nor carried). The transformation lasts for the duration or until the target dies or is destroyed, but if you maintain Concentration on this spell for the full duration, the spell lasts until dispelled.\n\nAn unwilling creature can make a Wisdom saving throw, and if it succeeds, it isn't affected by this spell.\n\n***Creature into Creature.*** If you turn a creature into another kind of creature, the new form can be any kind you choose that has a Challenge Rating equal to or less than the target's Challenge Rating or level. The target's game statistics are replaced by the stat block of the new form, but it retains its Hit Points, Hit Point Dice, alignment, and personality.\n\nThe target gains a number of Temporary Hit Points equal to the Hit Points of the new form. These Temporary Hit Points vanish if any remain when the spell ends.\n\nThe target is limited in the actions it can perform by the anatomy of its new form, and it can't speak or cast spells.\n\nThe target's gear melds into the new form. The creature can't use or otherwise benefit from any of that equipment.\n\n***Object into Creature.*** You can turn an object into any kind of creature, as long as the creature's size is no larger than the object's size and the creature has a Challenge Rating of 9 or lower. The creature is Friendly to you and your allies. In combat, it takes its turns immediately after yours, and it obeys your commands.\n\nIf the spell lasts more than an hour, you no longer control the creature. It might remain Friendly to you, depending on how you have treated it.\n\n***Creature into Object.*** If you turn a creature into an object, it transforms along with whatever it is wearing and carrying into that form, as long as the object's size is no larger than the creature's size. The creature's statistics become those of the object, and the creature has no memory of time spent in this form after the spell ends and it returns to normal.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "true-polymorph", "it"),
					Language = LanguageCode.It,
					Name = "Metamorfosi Pura",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "una goccia di mercurio, un grumo di gomma arabica e un filo di fumo",
					Description = "L'incantatore sceglie una creatura o un oggetto non magico entro gittata che è in grado di vedere. La creatura si trasforma in una creatura diversa o in un oggetto non magico, oppure l'oggetto si trasforma in una creatura (l'oggetto non deve essere né indossato né trasportato). La trasformazione dura per la durata o finché il bersaglio non muore o viene distrutto, ma se l'incantatore mantiene la concentrazione su questo incantesimo per l'intera durata, l'incantesimo dura finché non viene dissolto.\n\nUna creatura non consenziente può effettuare un tiro salvezza su Saggezza e, se lo supera, non è influenzata da questo incantesimo.\n\n***Da Creatura a Creatura.*** Se l'incantatore trasforma una creatura in un altro tipo di creatura, la nuova forma può essere di qualsiasi tipo a sua scelta, purché abbia un Grado di Sfida pari o inferiore al Grado di Sfida o al livello del bersaglio. Le statistiche di gioco del bersaglio sono sostituite dalla scheda delle statistiche della nuova forma, ma il bersaglio mantiene i propri punti ferita, i Dadi Vita, l'allineamento e la personalità.\n\nIl bersaglio ottiene un numero di punti ferita temporanei pari ai punti ferita della nuova forma. Gli eventuali punti ferita temporanei rimasti svaniscono quando l'incantesimo termina.\n\nLe azioni che il bersaglio può effettuare sono limitate dall'anatomia della sua nuova forma, e il bersaglio non può parlare né lanciare incantesimi.\n\nL'equipaggiamento del bersaglio si fonde con la nuova forma. La creatura non può usare nessun oggetto di quell'equipaggiamento né trarne beneficio in altro modo.\n\n***Da Oggetto a Creatura.*** L'incantatore può trasformare un oggetto in qualsiasi tipo di creatura, purché la taglia della creatura non sia superiore alla taglia dell'oggetto e la creatura abbia un Grado di Sfida pari o inferiore a 9. La creatura è amichevole nei confronti dell'incantatore e dei suoi alleati. In combattimento, svolge i propri turni subito dopo quelli dell'incantatore e obbedisce ai suoi comandi.\n\nSe l'incantesimo dura più di un'ora, l'incantatore non controlla più la creatura. Questa potrebbe restare amichevole nei suoi confronti, a seconda di come è stata trattata.\n\n***Da Creatura a Oggetto.*** Se l'incantatore trasforma una creatura in un oggetto, la creatura si trasforma in quella forma insieme a tutto ciò che indossa e trasporta, purché la taglia dell'oggetto non sia superiore alla taglia della creatura. Le statistiche della creatura diventano quelle dell'oggetto e, quando l'incantesimo termina e torna normale, la creatura non ha alcun ricordo del tempo trascorso in questa forma.",
					HigherLevels = null
				}
			}
		};
	}
}
