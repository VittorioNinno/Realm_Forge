using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Wizard (2014 ruleset): class features of the SRD 5.1 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Wizard2014Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "wizard");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			HitDie = 6,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Intelligence },
			SavingThrows = new List<AbilityScore> { AbilityScore.Intelligence, AbilityScore.Wisdom },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.Arcana, Skill.History, Skill.Insight, Skill.Investigation, Skill.Medicine, Skill.Religion },
			CasterProgression = CasterProgression.Full,
			SpellcastingAbility = AbilityScore.Intelligence,
			SubclassLevel = 2,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "wizard", "en"),
					Language = LanguageCode.En,
					Name = "Wizard",
					Description = "A scholarly spellcaster who masters magic through study. Wizards record their spells in a spellbook, prepare a different selection each day, and specialize in one of the eight schools of magic.",
					SubclassTitle = "Arcane Tradition",
					ArmorProficiencies = "None",
					WeaponProficiencies = "Daggers, darts, slings, quarterstaffs, light crossbows",
					ToolProficiencies = "None",
					StartingEquipment = "- (a) a quarterstaff or (b) a dagger\n- (a) a component pouch or (b) an arcane focus\n- (a) a scholar’s pack or (b) an explorer’s pack\n- A spellbook",
					ProgressionTable = "The 1st–9th columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Features | Cantrips Known | 1st | 2nd | 3rd | 4th | 5th | 6th | 7th | 8th | 9th |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1st | +2 | Spellcasting, Arcane Recovery | 3 | 2 | — | — | — | — | — | — | — | — |\n| 2nd | +2 | Arcane Tradition | 3 | 3 | — | — | — | — | — | — | — | — |\n| 3rd | +2 | — | 3 | 4 | 2 | — | — | — | — | — | — | — |\n| 4th | +2 | Ability Score Improvement | 4 | 4 | 3 | — | — | — | — | — | — | — |\n| 5th | +3 | — | 4 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6th | +3 | Arcane Tradition feature | 4 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7th | +3 | — | 4 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8th | +3 | Ability Score Improvement | 4 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9th | +4 | — | 4 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10th | +4 | Arcane Tradition feature | 5 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11th | +4 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12th | +4 | Ability Score Improvement | 5 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13th | +5 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14th | +5 | Arcane Tradition feature | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15th | +5 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16th | +5 | Ability Score Improvement | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17th | +6 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18th | +6 | Spell Mastery | 5 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19th | +6 | Ability Score Improvement | 5 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20th | +6 | Signature Spells | 5 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "wizard", "it"),
					Language = LanguageCode.It,
					Name = "Mago",
					Description = "Un incantatore erudito che padroneggia la magia attraverso lo studio. Il mago trascrive i suoi incantesimi in un libro degli incantesimi, ne prepara ogni giorno una selezione diversa e si specializza in una delle otto scuole di magia.",
					SubclassTitle = "Tradizione Arcana",
					ArmorProficiencies = "Nessuna",
					WeaponProficiencies = "Balestre leggere, bastoni ferrati, dardi, fionde, pugnali",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "- (a) un bastone ferrato o (b) un pugnale\n- (a) una borsa per componenti o (b) un focus arcano\n- (a) una dotazione da studioso o (b) una dotazione da esploratore\n- Un libro degli incantesimi",
					ProgressionTable = "Le colonne 1°–9° indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi | Trucchetti conosciuti | 1° | 2° | 3° | 4° | 5° | 6° | 7° | 8° | 9° |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1° | +2 | Incantesimi, Recupero Arcano | 3 | 2 | — | — | — | — | — | — | — | — |\n| 2° | +2 | Tradizione Arcana | 3 | 3 | — | — | — | — | — | — | — | — |\n| 3° | +2 | — | 3 | 4 | 2 | — | — | — | — | — | — | — |\n| 4° | +2 | Aumento dei Punteggi di Caratteristica | 4 | 4 | 3 | — | — | — | — | — | — | — |\n| 5° | +3 | — | 4 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6° | +3 | Privilegio della Tradizione Arcana | 4 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7° | +3 | — | 4 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8° | +3 | Aumento dei Punteggi di Caratteristica | 4 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9° | +4 | — | 4 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10° | +4 | Privilegio della Tradizione Arcana | 5 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11° | +4 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12° | +4 | Aumento dei Punteggi di Caratteristica | 5 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13° | +5 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14° | +5 | Privilegio della Tradizione Arcana | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15° | +5 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16° | +5 | Aumento dei Punteggi di Caratteristica | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17° | +6 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18° | +6 | Maestria negli Incantesimi | 5 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19° | +6 | Aumento dei Punteggi di Caratteristica | 5 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20° | +6 | Incantesimi Personali | 5 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "As a student of arcane magic, you have a spellbook containing spells that show the first glimmerings of your true power.\n\n**Cantrips.** At 1st level, you know three cantrips of your choice from the wizard spell list. You learn additional wizard cantrips of your choice at higher levels, as shown in the Cantrips Known column of the Wizard table.\n\n**Spellbook.** At 1st level, you have a spellbook containing six 1st-level wizard spells of your choice. Your spellbook is the repository of the wizard spells you know, except your cantrips, which are fixed in your mind.\n\n**Preparing and Casting Spells.** The Wizard table shows how many spell slots you have to cast your spells of 1st level and higher. To cast one of these spells, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest.\n\nYou prepare the list of wizard spells that are available for you to cast. To do so, choose a number of wizard spells from your spellbook equal to your Intelligence modifier + your wizard level (minimum of one spell). The spells must be of a level for which you have spell slots.\n\nFor example, if you're a 3rd-level wizard, you have four 1st-level and two 2nd-level spell slots. With an Intelligence of 16, your list of prepared spells can include six spells of 1st or 2nd level, in any combination, chosen from your spellbook. If you prepare the 1st-level spell *magic missile*, you can cast it using a 1st-level or a 2nd-level slot. Casting the spell doesn't remove it from your list of prepared spells.\n\nYou can change your list of prepared spells when you finish a long rest. Preparing a new list of wizard spells requires time spent studying your spellbook and memorizing the incantations and gestures you must make to cast the spell: at least 1 minute per spell level for each spell on your list.\n\n**Spellcasting Ability.** Intelligence is your spellcasting ability for your wizard spells, since you learn your spells through dedicated study and memorization. You use your Intelligence whenever a spell refers to your spellcasting ability. In addition, you use your Intelligence modifier when setting the saving throw DC for a wizard spell you cast and when making an attack roll with one.\n\n**Spell save DC** = 8 + your proficiency bonus + your Intelligence modifier\n\n**Spell attack modifier** = your proficiency bonus + your Intelligence modifier\n\n**Ritual Casting.** You can cast a wizard spell as a ritual if that spell has the ritual tag and you have the spell in your spellbook. You don't need to have the spell prepared.\n\n**Spellcasting Focus.** You can use an arcane focus as a spellcasting focus for your wizard spells.\n\n**Learning Spells of 1st Level and Higher.** Each time you gain a wizard level, you can add two wizard spells of your choice to your spellbook for free. Each of these spells must be of a level for which you have spell slots, as shown on the Wizard table. On your adventures, you might find other spells that you can add to your spellbook (see \"Your Spellbook\" below).\n\n**Your Spellbook.** The spells you add to your spellbook as you gain levels reflect your own research and intellectual breakthroughs. You might find other spells during your adventures, such as a spell on a scroll in an evil wizard's chest or in a dusty tome in an ancient library.\n\n*Copying a Spell into the Book.* When you find a wizard spell of 1st level or higher, you can add it to your spellbook if it is of a level for which you have spell slots and if you can spare the time to decipher and copy it. For each level of the spell, the process takes 2 hours and costs 50 gp, which covers the material components you use as you experiment with the spell and the fine inks you need to record it. Once you have spent this time and money, you can prepare the spell just like your other spells.\n\n*Replacing the Book.* You can copy a spell from your own spellbook into another book, for example to make a backup copy. This is just like copying a new spell into your spellbook, but faster and easier: you need spend only 1 hour and 10 gp for each level of the copied spell. If you lose your spellbook, you can use the same procedure to transcribe the spells you have prepared into a new spellbook. Filling out the rest of the new book requires you to find new spells to do so, as normal.\n\n*The Book's Appearance.* Your spellbook is a unique compilation of spells, with its own decorative flourishes and margin notes. It might be a plain, functional leather volume you received from your master, a finely bound gilt-edged tome found in an ancient library, or a loose collection of notes scrounged together after you lost your previous book." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "In quanto studioso di magia arcana, il mago possiede un libro degli incantesimi che contiene incantesimi in cui si intravedono i primi bagliori del suo vero potere.\n\n**Trucchetti.** Al 1° livello il mago conosce tre trucchetti a sua scelta dalla lista degli incantesimi del mago. Apprende altri trucchetti da mago a sua scelta ai livelli superiori, come indicato nella colonna \"Trucchetti conosciuti\" della tabella del Mago.\n\n**Libro degli incantesimi.** Al 1° livello il mago possiede un libro degli incantesimi che contiene sei incantesimi da mago di 1° livello a sua scelta. Il libro raccoglie gli incantesimi da mago che conosce, tranne i trucchetti, che sono impressi nella sua mente.\n\n**Preparare e lanciare incantesimi.** La tabella del Mago indica quanti slot incantesimo possiede il mago per lanciare i suoi incantesimi di 1° livello e superiore. Per lanciare uno di questi incantesimi, deve spendere uno slot di livello pari o superiore a quello dell'incantesimo. Recupera tutti gli slot incantesimo spesi quando completa un riposo lungo.\n\nIl mago prepara la lista degli incantesimi da mago che può lanciare. Per farlo, sceglie dal suo libro degli incantesimi un numero di incantesimi da mago pari al suo modificatore di Intelligenza + il suo livello da mago (minimo un incantesimo). Gli incantesimi devono essere di un livello per cui possiede slot incantesimo.\n\nPer esempio, un mago di 3° livello possiede quattro slot incantesimo di 1° livello e due di 2° livello. Con un'Intelligenza di 16, la sua lista di incantesimi preparati può comprendere sei incantesimi di 1° o 2° livello, in qualsiasi combinazione, scelti dal suo libro degli incantesimi. Se prepara l'incantesimo di 1° livello *dardo incantato*, può lanciarlo usando uno slot di 1° o di 2° livello. Lanciare l'incantesimo non lo rimuove dalla lista degli incantesimi preparati.\n\nIl mago può cambiare la sua lista di incantesimi preparati quando completa un riposo lungo. Preparare una nuova lista di incantesimi da mago richiede del tempo da passare a studiare il libro degli incantesimi e a memorizzare le formule e i gesti necessari per lanciarli: almeno 1 minuto per livello di incantesimo per ogni incantesimo della lista.\n\n**Caratteristica da incantatore.** L'Intelligenza è la caratteristica da incantatore per gli incantesimi da mago, dato che il mago apprende i suoi incantesimi attraverso lo studio e la memorizzazione. Usa l'Intelligenza ogni volta che un incantesimo fa riferimento alla sua caratteristica da incantatore. Usa inoltre il suo modificatore di Intelligenza per stabilire la CD dei tiri salvezza degli incantesimi da mago che lancia e quando effettua un tiro per colpire con uno di essi.\n\n**CD del tiro salvezza degli incantesimi** = 8 + bonus di competenza + modificatore di Intelligenza\n\n**Modificatore di attacco degli incantesimi** = bonus di competenza + modificatore di Intelligenza\n\n**Celebrare rituali.** Il mago può lanciare un incantesimo da mago come rituale se l'incantesimo ha la caratteristica rituale e si trova nel suo libro degli incantesimi. Non deve necessariamente averlo preparato.\n\n**Focus da incantatore.** Il mago può usare un focus arcano come focus da incantatore per i suoi incantesimi da mago.\n\n**Apprendere incantesimi di 1° livello e superiore.** Ogni volta che ottiene un livello da mago, il mago può aggiungere gratuitamente al suo libro degli incantesimi due incantesimi da mago a sua scelta. Ognuno di essi deve essere di un livello per cui possiede slot incantesimo, come indicato nella tabella del Mago. Durante le sue avventure potrebbe trovare altri incantesimi da aggiungere al libro (vedi \"Il libro degli incantesimi\" qui sotto).\n\n**Il libro degli incantesimi.** Gli incantesimi che il mago aggiunge al suo libro salendo di livello riflettono le sue ricerche e le sue scoperte intellettuali. Durante le avventure potrebbe trovarne altri, come un incantesimo su una pergamena nel forziere di un mago malvagio o in un tomo polveroso di un'antica biblioteca.\n\n*Copiare un incantesimo nel libro.* Quando trova un incantesimo da mago di 1° livello o superiore, il mago può aggiungerlo al suo libro se è di un livello per cui possiede slot incantesimo e se ha il tempo di decifrarlo e copiarlo. Per ogni livello dell'incantesimo, la procedura richiede 2 ore e costa 50 mo, che coprono le componenti materiali consumate sperimentando l'incantesimo e gli inchiostri pregiati necessari per trascriverlo. Una volta spesi questo tempo e questo denaro, può preparare l'incantesimo come gli altri suoi incantesimi.\n\n*Sostituire il libro.* Il mago può copiare un incantesimo dal proprio libro in un altro libro, per esempio per farne una copia di riserva. La procedura è la stessa usata per copiare un nuovo incantesimo, ma è più rapida e semplice: richiede soltanto 1 ora e 10 mo per ogni livello dell'incantesimo copiato. Se perde il suo libro degli incantesimi, può usare la stessa procedura per trascrivere gli incantesimi preparati in un nuovo libro. Per completare il resto del nuovo libro deve trovare nuovi incantesimi, come di consueto.\n\n*L'aspetto del libro.* Il libro degli incantesimi del mago è una raccolta unica, con decorazioni e annotazioni a margine tutte sue. Potrebbe essere un semplice volume di cuoio ricevuto dal suo maestro, un tomo rilegato con cura e dai bordi dorati trovato in un'antica biblioteca, o una raccolta di appunti sciolti messa insieme dopo avere perduto il libro precedente." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/arcane-recovery"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/arcane-recovery", "en"), Language = LanguageCode.En, Name = "Arcane Recovery", Description = "You have learned to regain some of your magical energy by studying your spellbook. Once per day when you finish a short rest, you can choose expended spell slots to recover. The spell slots can have a combined level that is equal to or less than half your wizard level (rounded up), and none of the slots can be 6th level or higher.\n\nFor example, if you're a 4th-level wizard, you can recover up to two levels worth of spell slots. You can recover either a 2nd-level spell slot or two 1st-level spell slots." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/arcane-recovery", "it"), Language = LanguageCode.It, Name = "Recupero Arcano", Description = "Il mago ha imparato a recuperare parte della sua energia magica studiando il suo libro degli incantesimi. Una volta al giorno, quando completa un riposo breve, può scegliere degli slot incantesimo spesi da recuperare. Gli slot possono avere un livello complessivo pari o inferiore alla metà del suo livello da mago (arrotondata per eccesso), e nessuno di essi può essere di 6° livello o superiore.\n\nPer esempio, un mago di 4° livello può recuperare slot incantesimo per un totale di due livelli: uno slot di 2° livello o due slot di 1° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/arcane-tradition"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/arcane-tradition", "en"), Language = LanguageCode.En, Name = "Arcane Tradition", Description = "When you reach 2nd level, you choose an arcane tradition, shaping your practice of magic through one of eight schools, such as Evocation.\n\nYour choice grants you features at 2nd level and again at 6th, 10th, and 14th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/arcane-tradition", "it"), Language = LanguageCode.It, Name = "Tradizione Arcana", Description = "Quando arriva al 2° livello, il mago sceglie una tradizione arcana, plasmando la sua pratica della magia attraverso una delle otto scuole, come quella di Invocazione.\n\nLa scelta gli conferisce privilegi al 2° livello e poi al 6°, al 10° e al 14° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Quando arriva al 4° livello, e poi all'8°, al 12°, al 16° e al 19° livello, il personaggio può aumentare di 2 un punteggio di caratteristica a sua scelta, oppure aumentare di 1 due punteggi di caratteristica a sua scelta. Come di consueto, questo privilegio non consente di aumentare un punteggio di caratteristica oltre 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/spell-mastery"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 18,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/spell-mastery", "en"), Language = LanguageCode.En, Name = "Spell Mastery", Description = "At 18th level, you have achieved such mastery over certain spells that you can cast them at will. Choose a 1st-level wizard spell and a 2nd-level wizard spell that are in your spellbook. You can cast those spells at their lowest level without expending a spell slot when you have them prepared. If you want to cast either spell at a higher level, you must expend a spell slot as normal.\n\nBy spending 8 hours in study, you can exchange one or both of the spells you chose for different spells of the same levels." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/spell-mastery", "it"), Language = LanguageCode.It, Name = "Maestria negli Incantesimi", Description = "Al 18° livello il mago ha acquisito una tale padronanza di alcuni incantesimi da poterli lanciare a volontà. Sceglie un incantesimo da mago di 1° livello e uno di 2° livello presenti nel suo libro degli incantesimi. Quando li ha preparati, può lanciarli al loro livello più basso senza spendere uno slot incantesimo. Se vuole lanciare uno dei due a un livello superiore, deve spendere uno slot incantesimo come di consueto.\n\nPassando 8 ore a studiare, può sostituire uno o entrambi gli incantesimi scelti con altri incantesimi degli stessi livelli." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/signature-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 20,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/signature-spells", "en"), Language = LanguageCode.En, Name = "Signature Spells", Description = "When you reach 20th level, you gain mastery over two powerful spells and can cast them with little effort. Choose two 3rd-level wizard spells in your spellbook as your signature spells. You always have these spells prepared, they don't count against the number of spells you have prepared, and you can cast each of them once at 3rd level without expending a spell slot. When you do so, you can't do so again until you finish a short or long rest.\n\nIf you want to cast either spell at a higher level, you must expend a spell slot as normal." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "wizard/signature-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi Personali", Description = "Quando arriva al 20° livello, il mago ottiene la padronanza di due incantesimi potenti e può lanciarli con uno sforzo minimo. Sceglie come incantesimi personali due incantesimi da mago di 3° livello presenti nel suo libro. Ha sempre questi incantesimi preparati, non contano ai fini del numero di incantesimi preparati e può lanciare ciascuno di essi una volta al 3° livello senza spendere uno slot incantesimo. Quando lo fa, non può farlo di nuovo finché non completa un riposo breve o lungo.\n\nSe vuole lanciare uno dei due a un livello superiore, deve spendere uno slot incantesimo come di consueto." }
					}
				}
			}
		};
	}
}
