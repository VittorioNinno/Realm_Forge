using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Wizard (2024 ruleset): class features of the SRD 5.2 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Wizard2024Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "wizard");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			HitDie = 6,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Intelligence },
			SavingThrows = new List<AbilityScore> { AbilityScore.Intelligence, AbilityScore.Wisdom },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.Arcana, Skill.History, Skill.Insight, Skill.Investigation, Skill.Medicine, Skill.Nature, Skill.Religion },
			CasterProgression = CasterProgression.Full,
			SpellcastingAbility = AbilityScore.Intelligence,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "wizard", "en"),
					Language = LanguageCode.En,
					Name = "Wizard",
					Description = "A scholarly magic-user who masters the arcane through study. Wizards record their spells in a precious spellbook, prepare a versatile arsenal each day and specialize in a school of magic, wielding an unmatched breadth of spells to protect, reveal, destroy or deceive.",
					SubclassTitle = "Wizard Subclass",
					ArmorProficiencies = "None",
					WeaponProficiencies = "Simple weapons",
					ToolProficiencies = "None",
					StartingEquipment = "Choose A or B:\n- (A) 2 Daggers, Arcane Focus (Quarterstaff), Robe, Spellbook, Scholar's Pack and 5 GP\n- (B) 55 GP",
					ProgressionTable = "The 1–9 columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Class Features | Cantrips | Prepared Spells | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Spellcasting, Ritual Adept, Arcane Recovery | 3 | 4 | 2 | — | — | — | — | — | — | — | — |\n| 2 | +2 | Scholar | 3 | 5 | 3 | — | — | — | — | — | — | — | — |\n| 3 | +2 | Wizard Subclass | 3 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4 | +2 | Ability Score Improvement | 4 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5 | +3 | Memorize Spell | 4 | 9 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6 | +3 | Subclass feature | 4 | 10 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7 | +3 | — | 4 | 11 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8 | +3 | Ability Score Improvement | 4 | 12 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9 | +4 | — | 4 | 14 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10 | +4 | Subclass feature | 5 | 15 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11 | +4 | — | 5 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12 | +4 | Ability Score Improvement | 5 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13 | +5 | — | 5 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14 | +5 | Subclass feature | 5 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15 | +5 | — | 5 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16 | +5 | Ability Score Improvement | 5 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17 | +6 | — | 5 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18 | +6 | Spell Mastery | 5 | 20 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19 | +6 | Epic Boon | 5 | 21 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20 | +6 | Signature Spells | 5 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "wizard", "it"),
					Language = LanguageCode.It,
					Name = "Mago",
					Description = "Un erudito della magia che padroneggia l'arcano attraverso lo studio. Il mago trascrive i suoi incantesimi in un prezioso libro, prepara ogni giorno un arsenale versatile e si specializza in una scuola di magia, impugnando una varietà di incantesimi senza pari per proteggere, rivelare, distruggere o ingannare.",
					SubclassTitle = "Sottoclasse del mago",
					ArmorProficiencies = "Nessuna",
					WeaponProficiencies = "Armi semplici",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "A scelta tra A e B:\n- (A) 2 pugnali, un focus arcano (bastone ferrato), una veste, un libro degli incantesimi, una dotazione da studioso e 5 mo\n- (B) 55 mo",
					ProgressionTable = "Le colonne 1–9 indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi di classe | Trucchetti | Incantesimi preparati | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Incantesimi, Adepto dei Rituali, Recupero Arcano | 3 | 4 | 2 | — | — | — | — | — | — | — | — |\n| 2 | +2 | Studioso | 3 | 5 | 3 | — | — | — | — | — | — | — | — |\n| 3 | +2 | Sottoclasse del Mago | 3 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4 | +2 | Aumento dei Punteggi di Caratteristica | 4 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5 | +3 | Memorizzare Incantesimi | 4 | 9 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6 | +3 | Privilegio della sottoclasse | 4 | 10 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7 | +3 | — | 4 | 11 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8 | +3 | Aumento dei Punteggi di Caratteristica | 4 | 12 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9 | +4 | — | 4 | 14 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10 | +4 | Privilegio della sottoclasse | 5 | 15 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11 | +4 | — | 5 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12 | +4 | Aumento dei Punteggi di Caratteristica | 5 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13 | +5 | — | 5 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14 | +5 | Privilegio della sottoclasse | 5 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15 | +5 | — | 5 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16 | +5 | Aumento dei Punteggi di Caratteristica | 5 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17 | +6 | — | 5 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18 | +6 | Maestria negli Incantesimi | 5 | 20 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19 | +6 | Dono Epico | 5 | 21 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20 | +6 | Incantesimi Personali | 5 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "As a student of arcane magic, you have learned to cast spells. See the spells chapter for the rules on spellcasting. The information below details how you use those rules with Wizard spells, which appear in the Wizard spell list.\n\n**Cantrips.** You know three Wizard cantrips of your choice. Light, Mage Hand, and Ray of Frost are recommended. Whenever you finish a Long Rest, you can replace one of your cantrips from this feature with another Wizard cantrip of your choice.\n\nWhen you reach Wizard levels 4 and 10, you learn another Wizard cantrip of your choice, as shown in the Cantrips column of the Wizard Features table.\n\n**Spellbook.** Your wizardly apprenticeship culminated in the creation of a unique book: your spellbook. It is a Tiny object that weighs 3 pounds, contains 100 pages, and can be read only by you or someone casting Identify. You determine the book's appearance and materials, such as a gilt-edged tome or a collection of vellum bound with twine.\n\nThe book contains the level 1+ spells you know. It starts with six level 1 Wizard spells of your choice. Detect Magic, Feather Fall, Mage Armor, Magic Missile, Sleep, and Thunderwave are recommended.\n\nWhenever you gain a Wizard level after 1, add two Wizard spells of your choice to your spellbook. Each of these spells must be of a level for which you have spell slots, as shown in the Wizard Features table. The spells are the culmination of arcane research you do regularly.\n\n**Spell Slots.** The Wizard Features table shows how many spell slots you have to cast your level 1+ spells. You regain all expended slots when you finish a Long Rest.\n\n**Prepared Spells of Level 1+.** You prepare the list of level 1+ spells that are available for you to cast with this feature. To do so, choose four spells from your spellbook. The chosen spells must be of a level for which you have spell slots.\n\nThe number of spells on your list increases as you gain Wizard levels, as shown in the Prepared Spells column of the Wizard Features table. Whenever that number increases, choose additional Wizard spells until the number of spells on your list matches the number in the table. The chosen spells must be of a level for which you have spell slots. For example, if you're a level 3 Wizard, your list of prepared spells can include six spells of levels 1 and 2 in any combination, chosen from your spellbook.\n\nIf another Wizard feature gives you spells that you always have prepared, those spells don't count against the number of spells you can prepare with this feature, but those spells otherwise count as Wizard spells for you.\n\n**Changing Your Prepared Spells.** Whenever you finish a Long Rest, you can change your list of prepared spells, replacing any of the spells there with spells from your spellbook.\n\n**Spellcasting Ability.** Intelligence is your spellcasting ability for your Wizard spells.\n\n**Spellcasting Focus.** You can use an Arcane Focus or your spellbook as a Spellcasting Focus for your Wizard spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Grazie allo studio della magia arcana, il mago ha imparato a lanciare incantesimi (le regole per lanciarli si trovano nel capitolo sugli incantesimi). Di seguito è spiegato come il mago applica quelle regole agli incantesimi da mago, che compaiono nella lista degli incantesimi da mago.\n\n**Trucchetti.** Il mago conosce tre trucchetti da mago a sua scelta; sono consigliati *luce*, *mano magica* e *raggio di gelo*. Ogni volta che completa un riposo lungo, può sostituire uno dei trucchetti ottenuti con questo privilegio con un altro trucchetto da mago a sua scelta. Al 4° e al 10° livello da mago impara un altro trucchetto da mago a sua scelta, come indicato nella colonna Trucchetti della tabella dei privilegi del mago.\n\n**Libro degli incantesimi.** L'apprendistato del mago è culminato nella creazione di un libro unico: il suo libro degli incantesimi. È un oggetto Minuscolo che pesa 1,5 chilogrammi, contiene 100 pagine e può essere letto soltanto dal mago o da qualcuno che lancia *identificare*. Il mago ne stabilisce l'aspetto e i materiali, come un tomo dai bordi dorati o una raccolta di fogli di pergamena legati con lo spago.\n\nIl libro contiene gli incantesimi di 1° livello o superiore che il mago conosce. All'inizio contiene sei incantesimi da mago di 1° livello a sua scelta; sono consigliati *armatura magica*, *caduta morbida*, *dardo incantato*, *individuazione del magico*, *onda tonante* e *sonno*.\n\nOgni volta che sale di livello come mago dopo il 1°, aggiunge al libro due incantesimi da mago a sua scelta, ognuno di un livello per cui possiede slot incantesimo, come indicato nella tabella dei privilegi del mago. Questi incantesimi sono il frutto delle ricerche arcane che il mago svolge regolarmente.\n\n**Slot incantesimo.** La tabella dei privilegi del mago indica quanti slot incantesimo possiede il mago per lanciare i suoi incantesimi di 1° livello o superiore. Recupera tutti gli slot spesi quando completa un riposo lungo.\n\n**Incantesimi preparati di 1° livello o superiore.** Il mago prepara l'elenco degli incantesimi di 1° livello o superiore che può lanciare con questo privilegio, scegliendo per cominciare quattro incantesimi dal suo libro; gli incantesimi scelti devono essere di un livello per cui possiede slot incantesimo.\n\nIl numero di incantesimi del suo elenco aumenta man mano che sale di livello come mago, come indicato nella colonna Incantesimi preparati della tabella dei privilegi del mago. Ogni volta che quel numero aumenta, sceglie altri incantesimi da mago finché il numero di incantesimi nel suo elenco non coincide con quello della tabella. Gli incantesimi scelti devono essere di un livello per cui possiede slot incantesimo. Per esempio, un mago di 3° livello può avere nel suo elenco sei incantesimi di 1° e 2° livello in qualsiasi combinazione, scelti dal suo libro.\n\nSe un altro privilegio da mago gli fa avere incantesimi sempre preparati, quegli incantesimi non contano nel numero di incantesimi che può preparare con questo privilegio, ma per il resto contano come incantesimi da mago per lui.\n\n**Cambiare gli incantesimi preparati.** Ogni volta che completa un riposo lungo, il mago può modificare il suo elenco di incantesimi preparati, sostituendone uno qualsiasi con altri incantesimi del suo libro.\n\n**Caratteristica da incantatore.** L'Intelligenza è la caratteristica da incantatore del mago per i suoi incantesimi da mago.\n\n**Focus da incantatore.** Il mago può usare un focus arcano o il suo libro degli incantesimi come focus da incantatore per i suoi incantesimi da mago." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/ritual-adept"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/ritual-adept", "en"), Language = LanguageCode.En, Name = "Ritual Adept", Description = "You can cast any spell as a Ritual if that spell has the Ritual tag and the spell is in your spellbook. You needn’t have the spell prepared, but you must read from the book to cast a spell in this way." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/ritual-adept", "it"), Language = LanguageCode.It, Name = "Adepto dei Rituali", Description = "Il mago può lanciare come rituale qualsiasi incantesimo con il descrittore rituale presente nel suo libro degli incantesimi. Non ha bisogno di averlo preparato, ma deve leggerlo dal libro per lanciarlo in questo modo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/arcane-recovery"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/arcane-recovery", "en"), Language = LanguageCode.En, Name = "Arcane Recovery", Description = "You can regain some of your magical energy by studying your spellbook. When you finish a Short Rest, you can choose expended spell slots to recover. The spell slots can have a combined level equal to no more than half your Wizard level (round up), and none of the slots can be level 6 or higher. For example, if you’re a level 4 Wizard, you can recover up to two levels’ worth of spell slots, regaining either one level 2 spell slot or two level 1 spell slots.\n\nOnce you use this feature, you can’t do so again until you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/arcane-recovery", "it"), Language = LanguageCode.It, Name = "Recupero Arcano", Description = "Il mago può recuperare parte della sua energia magica studiando il suo libro degli incantesimi. Quando completa un riposo breve, può scegliere alcuni slot incantesimo spesi da recuperare. Gli slot possono avere un livello complessivo non superiore alla metà del suo livello da mago (arrotondata per eccesso) e nessuno di essi può essere di 6° livello o superiore. Per esempio, un mago di 4° livello può recuperare slot incantesimo per un totale di due livelli, ottenendo uno slot di 2° livello oppure due slot di 1° livello.\n\nDopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/scholar"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/scholar", "en"), Language = LanguageCode.En, Name = "Scholar", Description = "While studying magic, you also specialized in another field of study. Choose one of the following skills in which you have proficiency: Arcana, History, Investigation, Medicine, Nature, or Religion. You have Expertise in the chosen skill." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/scholar", "it"), Language = LanguageCode.It, Name = "Studioso", Description = "Mentre studiava la magia, il mago si è specializzato anche in un altro campo del sapere. Sceglie una delle abilità seguenti in cui ha competenza: Arcano, Indagare, Medicina, Natura, Religione o Storia. Ottiene Maestria nell'abilità scelta." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/wizard-subclass"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/wizard-subclass", "en"), Language = LanguageCode.En, Name = "Wizard Subclass", Description = "You gain a Wizard subclass of your choice. The Abjurer, Diviner, Evoker, and Illusionist subclasses are detailed after this class’s description. A subclass is a specialization that grants you features at certain Wizard levels. For the rest of your career, you gain each of your subclass’s features that are of your Wizard level or lower." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/wizard-subclass", "it"), Language = LanguageCode.It, Name = "Sottoclasse del Mago", Description = "Il mago ottiene una sottoclasse del mago a sua scelta: Abiuratore, Divinatore, Illusionista o Invocatore. Una sottoclasse è una specializzazione che conferisce privilegi a determinati livelli da mago. Per il resto della sua carriera, il mago ottiene ogni privilegio della sottoclasse di livello pari o inferiore al suo livello da mago." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "You gain the Ability Score Improvement feat (see chapter 5) or another feat of your choice for which you qualify. You gain this feature again at Wizard levels 8, 12, and 16." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Il mago ottiene il talento Aumento dei punteggi di caratteristica o un altro talento a sua scelta di cui soddisfa i prerequisiti. Ottiene di nuovo questo privilegio all'8°, al 12° e al 16° livello da mago." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/memorize-spell"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/memorize-spell", "en"), Language = LanguageCode.En, Name = "Memorize Spell", Description = "Whenever you finish a Short Rest, you can study your spellbook and replace one of the level 1+ Wizard spells you have prepared for your Spellcasting feature with another level 1+ spell from the book." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/memorize-spell", "it"), Language = LanguageCode.It, Name = "Memorizzare Incantesimi", Description = "Ogni volta che completa un riposo breve, il mago può studiare il suo libro degli incantesimi e sostituire uno degli incantesimi da mago di 1° livello o superiore che ha preparati per il privilegio Incantesimi con un altro incantesimo di 1° livello o superiore del libro." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/spell-mastery"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/spell-mastery", "en"), Language = LanguageCode.En, Name = "Spell Mastery", Description = "You have achieved such mastery over certain spells that you can cast them at will. Choose a level 1 and a level 2 spell in your spellbook that have a casting time of an action. You always have those spells prepared, and you can cast them at their lowest level without expending a spell slot. To cast either spell at a higher level, you must expend a spell slot.\n\nWhenever you finish a Long Rest, you can study your spellbook and replace one of those spells with an eligible spell of the same level from the book." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/spell-mastery", "it"), Language = LanguageCode.It, Name = "Maestria negli Incantesimi", Description = "Il mago ha raggiunto una tale padronanza di alcuni incantesimi da poterli lanciare a volontà. Sceglie nel suo libro un incantesimo di 1° livello e uno di 2° livello con un tempo di lancio di un'azione: li ha sempre preparati e può lanciarli al loro livello più basso senza spendere uno slot incantesimo. Per lanciarli a un livello superiore, deve spendere uno slot incantesimo.\n\nOgni volta che completa un riposo lungo, può studiare il suo libro e sostituire uno di quegli incantesimi con un incantesimo idoneo dello stesso livello presente nel libro." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/epic-boon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 19,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/epic-boon", "en"), Language = LanguageCode.En, Name = "Epic Boon", Description = "You gain an Epic Boon feat (see chapter 5) or another feat of your choice for which you qualify. Boon of Spell Recall is recommended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/epic-boon", "it"), Language = LanguageCode.It, Name = "Dono Epico", Description = "Il mago ottiene un talento Dono epico o un altro talento a sua scelta di cui soddisfa i prerequisiti. È consigliato il Dono del richiamo degli incantesimi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/signature-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/signature-spells", "en"), Language = LanguageCode.En, Name = "Signature Spells", Description = "Choose two level 3 spells in your spellbook as your signature spells. You always have these spells prepared, and you can cast each of them once at level 3 without expending a spell slot. When you do so, you can’t cast them in this way again until you finish a Short or Long Rest. To cast either spell at a higher level, you must expend a spell slot." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "wizard/signature-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi Personali", Description = "Il mago sceglie nel suo libro due incantesimi di 3° livello come suoi incantesimi personali. Li ha sempre preparati e può lanciare ciascuno di essi una volta al 3° livello senza spendere uno slot incantesimo; dopo averlo fatto, non può lanciarli di nuovo in questo modo finché non completa un riposo breve o lungo. Per lanciarli a un livello superiore, deve spendere uno slot incantesimo." }
					}
				}
			}
		};
	}
}
