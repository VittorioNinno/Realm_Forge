using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Ranger (2024 ruleset): class features of the SRD 5.2 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Ranger2024Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "ranger");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			HitDie = 10,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Wisdom },
			SavingThrows = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity },
			SkillChoiceCount = 3,
			SkillOptions = new List<Skill> { Skill.Animal Handling, Skill.Athletics, Skill.Insight, Skill.Investigation, Skill.Nature, Skill.Perception, Skill.Stealth, Skill.Survival },
			CasterProgression = CasterProgression.Half,
			SpellcastingAbility = AbilityScore.Wisdom,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "ranger", "en"),
					Language = LanguageCode.En,
					Name = "Ranger",
					Description = "A wandering warrior of the wild frontiers. Rangers blend martial skill, primal magic and survival lore to track their quarry, guide travelers through untamed lands and strike from afar, standing watch against the monsters that threaten the borders of civilization.",
					SubclassTitle = "Ranger Subclass",
					ArmorProficiencies = "Light and Medium armor; Shields",
					WeaponProficiencies = "Simple and Martial weapons",
					ToolProficiencies = "None",
					StartingEquipment = "Choose A or B:\n- (A) Studded Leather Armor, Scimitar, Shortsword, Longbow, 20 Arrows, Quiver, Druidic Focus (sprig of mistletoe), Explorer's Pack and 7 GP\n- (B) 150 GP",
					ProgressionTable = "The 1–5 columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Class Features | Favored Enemy | Prepared Spells | 1 | 2 | 3 | 4 | 5 |\n|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Spellcasting, Favored Enemy, Weapon Mastery | 2 | 2 | 2 | — | — | — | — |\n| 2 | +2 | Deft Explorer, Fighting Style | 2 | 3 | 2 | — | — | — | — |\n| 3 | +2 | Ranger Subclass | 2 | 4 | 3 | — | — | — | — |\n| 4 | +2 | Ability Score Improvement | 2 | 5 | 3 | — | — | — | — |\n| 5 | +3 | Extra Attack | 3 | 6 | 4 | 2 | — | — | — |\n| 6 | +3 | Roving | 3 | 6 | 4 | 2 | — | — | — |\n| 7 | +3 | Subclass feature | 3 | 7 | 4 | 3 | — | — | — |\n| 8 | +3 | Ability Score Improvement | 3 | 7 | 4 | 3 | — | — | — |\n| 9 | +4 | Expertise | 4 | 9 | 4 | 3 | 2 | — | — |\n| 10 | +4 | Tireless | 4 | 9 | 4 | 3 | 2 | — | — |\n| 11 | +4 | Subclass feature | 4 | 10 | 4 | 3 | 3 | — | — |\n| 12 | +4 | Ability Score Improvement | 4 | 10 | 4 | 3 | 3 | — | — |\n| 13 | +5 | Relentless Hunter | 5 | 11 | 4 | 3 | 3 | 1 | — |\n| 14 | +5 | Nature's Veil | 5 | 11 | 4 | 3 | 3 | 1 | — |\n| 15 | +5 | Subclass feature | 5 | 12 | 4 | 3 | 3 | 2 | — |\n| 16 | +5 | Ability Score Improvement | 5 | 12 | 4 | 3 | 3 | 2 | — |\n| 17 | +6 | Precise Hunter | 6 | 14 | 4 | 3 | 3 | 3 | 1 |\n| 18 | +6 | Feral Senses | 6 | 14 | 4 | 3 | 3 | 3 | 1 |\n| 19 | +6 | Epic Boon | 6 | 15 | 4 | 3 | 3 | 3 | 2 |\n| 20 | +6 | Foe Slayer | 6 | 15 | 4 | 3 | 3 | 3 | 2 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "ranger", "it"),
					Language = LanguageCode.It,
					Name = "Ranger",
					Description = "Un guerriero errante delle frontiere selvagge. Il ranger unisce l'abilità marziale, la magia primordiale e l'arte della sopravvivenza per seguire le tracce delle prede, guidare i viaggiatori nelle terre incontaminate e colpire da lontano, vegliando sui mostri che minacciano i confini della civiltà.",
					SubclassTitle = "Sottoclasse del ranger",
					ArmorProficiencies = "Armature leggere e medie; scudi",
					WeaponProficiencies = "Armi semplici e da guerra",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "A scelta tra A e B:\n- (A) un'armatura di cuoio borchiato, una scimitarra, una spada corta, un arco lungo, 20 frecce, una faretra, un focus druidico (rametto di vischio), una dotazione da esploratore e 7 mo\n- (B) 150 mo",
					ProgressionTable = "Le colonne 1–5 indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi di classe | Nemico prescelto | Incantesimi preparati | 1 | 2 | 3 | 4 | 5 |\n|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Incantesimi, Nemico Prescelto, Padronanza nelle Armi | 2 | 2 | 2 | — | — | — | — |\n| 2 | +2 | Esploratore Esperto, Stile di Combattimento | 2 | 3 | 2 | — | — | — | — |\n| 3 | +2 | Sottoclasse del Ranger | 2 | 4 | 3 | — | — | — | — |\n| 4 | +2 | Aumento dei Punteggi di Caratteristica | 2 | 5 | 3 | — | — | — | — |\n| 5 | +3 | Attacco Extra | 3 | 6 | 4 | 2 | — | — | — |\n| 6 | +3 | Girovago | 3 | 6 | 4 | 2 | — | — | — |\n| 7 | +3 | Privilegio della sottoclasse | 3 | 7 | 4 | 3 | — | — | — |\n| 8 | +3 | Aumento dei Punteggi di Caratteristica | 3 | 7 | 4 | 3 | — | — | — |\n| 9 | +4 | Maestria | 4 | 9 | 4 | 3 | 2 | — | — |\n| 10 | +4 | Instancabile | 4 | 9 | 4 | 3 | 2 | — | — |\n| 11 | +4 | Privilegio della sottoclasse | 4 | 10 | 4 | 3 | 3 | — | — |\n| 12 | +4 | Aumento dei Punteggi di Caratteristica | 4 | 10 | 4 | 3 | 3 | — | — |\n| 13 | +5 | Cacciatore Implacabile | 5 | 11 | 4 | 3 | 3 | 1 | — |\n| 14 | +5 | Velo della Natura | 5 | 11 | 4 | 3 | 3 | 1 | — |\n| 15 | +5 | Privilegio della sottoclasse | 5 | 12 | 4 | 3 | 3 | 2 | — |\n| 16 | +5 | Aumento dei Punteggi di Caratteristica | 5 | 12 | 4 | 3 | 3 | 2 | — |\n| 17 | +6 | Precisione del Cacciatore | 6 | 14 | 4 | 3 | 3 | 3 | 1 |\n| 18 | +6 | Sensi Ferini | 6 | 14 | 4 | 3 | 3 | 3 | 1 |\n| 19 | +6 | Dono Epico | 6 | 15 | 4 | 3 | 3 | 3 | 2 |\n| 20 | +6 | Sterminatore di Nemici | 6 | 15 | 4 | 3 | 3 | 3 | 2 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "You have learned to channel the magical essence of nature to cast spells. See chapter 7 for the rules on spellcasting. The information below details how you use those rules with Ranger spells, which appear in the Ranger spell list later in the class’s description.\n\n**Spell Slots.** The Ranger Features table shows how many spell slots you have to cast your level 1+ spells. You regain all expended slots when you finish a Long Rest.\n\n**Prepared Spells of Level 1+.** You prepare the list of level 1+ spells that are available for you to cast with this feature. To start, choose two level 1 Ranger spells. Cure Wounds and Ensnaring Strike are recommended.\n\nThe number of spells on your list increases as you gain Ranger levels, as shown in the Prepared Spells column of the Ranger Features table. Whenever that number increases, choose additional Ranger spells until the number of spells on your list matches the number in the Ranger Features table. The chosen spells must be of a level for which you have spell slots. For example, if you’re a level 5 Ranger, your list of prepared spells can include six Ranger spells of level 1 or 2 in any combination.\n\nIf another Ranger feature gives you spells that you always have prepared, those spells don’t count against the number of spells you can prepare with this feature, but those spells otherwise count as Ranger spells for you.\n\n**Changing Your Prepared Spells.** Whenever you finish a Long Rest, you can replace one spell on your list with another Ranger spell for which you have spell slots.\n\n**Spellcasting Ability.** Wisdom is your spellcasting ability for your Ranger spells.\n\n**Spellcasting Focus.** You can use a Druidic Focus as a Spellcasting Focus for your Ranger spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Il ranger ha imparato a incanalare l'essenza magica della natura per lanciare incantesimi (le regole per lanciarli si trovano nel capitolo sugli incantesimi). Di seguito è spiegato come il ranger applica quelle regole agli incantesimi da ranger, che compaiono nella lista degli incantesimi da ranger.\n\n**Slot incantesimo.** La tabella dei privilegi del ranger indica quanti slot incantesimo possiede il ranger per lanciare i suoi incantesimi di 1° livello o superiore. Recupera tutti gli slot spesi quando completa un riposo lungo.\n\n**Incantesimi preparati di 1° livello o superiore.** Il ranger prepara l'elenco degli incantesimi di 1° livello o superiore che può lanciare con questo privilegio. Per cominciare, sceglie due incantesimi da ranger di 1° livello; sono consigliati *colpo intrappolante* e *cura ferite*.\n\nIl numero di incantesimi del suo elenco aumenta man mano che sale di livello come ranger, come indicato nella colonna Incantesimi preparati della tabella dei privilegi del ranger. Ogni volta che quel numero aumenta, sceglie altri incantesimi da ranger finché il numero di incantesimi nel suo elenco non coincide con quello della tabella. Gli incantesimi scelti devono essere di un livello per cui il ranger possiede slot incantesimo. Per esempio, un ranger di 5° livello può avere nel suo elenco sei incantesimi da ranger di 1° o 2° livello in qualsiasi combinazione.\n\nSe un altro privilegio da ranger gli fa avere incantesimi sempre preparati, quegli incantesimi non contano nel numero di incantesimi che può preparare con questo privilegio, ma per il resto contano come incantesimi da ranger per lui.\n\n**Cambiare gli incantesimi preparati.** Ogni volta che completa un riposo lungo, il ranger può sostituire un incantesimo del suo elenco con un altro incantesimo da ranger per cui possiede slot incantesimo.\n\n**Caratteristica da incantatore.** La Saggezza è la caratteristica da incantatore del ranger per i suoi incantesimi da ranger.\n\n**Focus da incantatore.** Il ranger può usare un focus druidico come focus da incantatore per i suoi incantesimi da ranger." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/favored-enemy"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/favored-enemy", "en"), Language = LanguageCode.En, Name = "Favored Enemy", Description = "You always have the Hunter’s Mark spell prepared. You can cast it twice without expending a spell slot, and you regain all expended uses of this ability when you finish a Long Rest.\n\nThe number of times you can cast the spell without a spell slot increases when you reach certain Ranger levels, as shown in the Favored Enemy column of the Ranger Features table." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/favored-enemy", "it"), Language = LanguageCode.It, Name = "Nemico Prescelto", Description = "Il ranger ha sempre preparato l'incantesimo *marchio del cacciatore*. Può lanciarlo due volte senza spendere uno slot incantesimo e recupera tutti gli utilizzi spesi di questa capacità quando completa un riposo lungo.\n\nIl numero di volte in cui può lanciare l'incantesimo senza slot incantesimo aumenta a determinati livelli da ranger, come indicato nella colonna Nemico prescelto della tabella dei privilegi del ranger." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/weapon-mastery"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/weapon-mastery", "en"), Language = LanguageCode.En, Name = "Weapon Mastery", Description = "Your training with weapons allows you to use the mastery properties of two kinds of weapons of your choice with which you have proficiency, such as Longbows and Shortswords.\n\nWhenever you finish a Long Rest, you can change the kinds of weapons you chose. For example, you could switch to using the mastery properties of Scimitars and Longswords." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/weapon-mastery", "it"), Language = LanguageCode.It, Name = "Padronanza nelle Armi", Description = "Il suo addestramento con le armi permette al ranger di usare le proprietà di padronanza di due tipi di armi a sua scelta in cui ha competenza, come gli archi lunghi e le spade corte.\n\nOgni volta che completa un riposo lungo, può cambiare i tipi di armi scelti; per esempio, potrebbe passare alle proprietà di padronanza delle scimitarre e delle spade lunghe." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/deft-explorer"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/deft-explorer", "en"), Language = LanguageCode.En, Name = "Deft Explorer", Description = "Thanks to your travels, you gain the following benefits.\n\n**Expertise.** Choose one of your skill proficiencies with which you lack Expertise. You gain Expertise in that skill.\n\n**Languages.** You know two languages of your choice from the language tables in chapter 2." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/deft-explorer", "it"), Language = LanguageCode.It, Name = "Esploratore Esperto", Description = "Grazie ai suoi viaggi, il ranger ottiene i benefici seguenti.\n\n**Maestria.** Il ranger sceglie un'abilità in cui ha competenza ma non Maestria, e ottiene Maestria in quell'abilità.\n\n**Lingue.** Il ranger conosce due lingue a sua scelta tra quelle delle tabelle delle lingue." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/fighting-style"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/fighting-style", "en"), Language = LanguageCode.En, Name = "Fighting Style", Description = "You gain a Fighting Style feat of your choice (see chapter 5). Instead of choosing one of those feats, you can choose the option below.\n\n**Druidic Warrior.** You learn two Druid cantrips of your choice (see the Druid class’s section for a list of Druid spells). Guidance and Starry Wisp are recommended. The chosen cantrips count as Ranger spells for you, and Wisdom is your spellcasting ability for them. Whenever you gain a Ranger level, you can replace one of these cantrips with another Druid cantrip." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/fighting-style", "it"), Language = LanguageCode.It, Name = "Stile di Combattimento", Description = "Il ranger ottiene un talento Stile di combattimento a sua scelta. Invece di scegliere uno di quei talenti, può scegliere l'opzione seguente.\n\n**Guerriero druidico.** Il ranger impara due trucchetti da druido a sua scelta; sono consigliati *guida* e *luce splendente*. I trucchetti scelti contano come incantesimi da ranger per lui, e la sua caratteristica da incantatore per essi è la Saggezza. Ogni volta che sale di livello come ranger, può sostituire uno di questi trucchetti con un altro trucchetto da druido." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/ranger-subclass"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/ranger-subclass", "en"), Language = LanguageCode.En, Name = "Ranger Subclass", Description = "You gain a Ranger subclass of your choice.The Beast Master, Fey Wanderer, Gloom Stalker, and Hunter subclasses are detailed after this class’s description. A subclass is a specialization that grants you features at certain Ranger levels. For the rest of your career, you gain each of your subclass’s features that are of your Ranger level or lower." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/ranger-subclass", "it"), Language = LanguageCode.It, Name = "Sottoclasse del Ranger", Description = "Il ranger ottiene una sottoclasse del ranger a sua scelta: Cacciatore, Cacciatore delle Tenebre, Signore delle Bestie o Viandante Fatato. Una sottoclasse è una specializzazione che conferisce privilegi a determinati livelli da ranger. Per il resto della sua carriera, il ranger ottiene ogni privilegio della sottoclasse di livello pari o inferiore al suo livello da ranger." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "You gain the Ability Score Improvement feat (see chapter 5) or another feat of your choice for which you qualify. You gain this feature again at Ranger levels 8, 12, and 16." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Il ranger ottiene il talento Aumento dei punteggi di caratteristica o un altro talento a sua scelta di cui soddisfa i prerequisiti. Ottiene di nuovo questo privilegio all'8°, al 12° e al 16° livello da ranger." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "You can attack twice instead of once whenever you take the Attack action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Ogni volta che sceglie l'azione di Attacco durante il proprio turno, il ranger effettua due attacchi invece di uno solo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/roving"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/roving", "en"), Language = LanguageCode.En, Name = "Roving", Description = "Your Speed increases by 10 feet while you aren’t wearing Heavy armor. You also have a Climb Speed and a Swim Speed equal to your Speed." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/roving", "it"), Language = LanguageCode.It, Name = "Girovago", Description = "Finché non indossa armature pesanti, la velocità del ranger aumenta di 3 metri. Il ranger ha inoltre una velocità di scalare e una velocità di nuotare pari alla sua velocità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/expertise"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 9,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/expertise", "en"), Language = LanguageCode.En, Name = "Expertise", Description = "Choose two of your skill proficiencies with which you lack Expertise. You gain Expertise in those skills." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/expertise", "it"), Language = LanguageCode.It, Name = "Maestria", Description = "Il ranger sceglie due abilità in cui ha competenza ma non Maestria, e ottiene Maestria in quelle abilità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/tireless"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/tireless", "en"), Language = LanguageCode.En, Name = "Tireless", Description = "Primal forces now help fuel you on your journeys, granting you the following benefits.\n\n**Temporary Hit Points.** As a Magic action, you can give yourself a number of Temporary Hit Points equal to 1d8 plus your Wisdom modifier (minimum of 1). You can use this action a number of times equal to your Wisdom modifier (minimum of once), and you regain all expended uses when you finish a Long Rest.\n\n**Decrease Exhaustion.** Whenever you finish a Short Rest, your Exhaustion level, if any, decreases by 1." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/tireless", "it"), Language = LanguageCode.It, Name = "Instancabile", Description = "Le forze primordiali sostengono ora il ranger nei suoi viaggi, conferendogli i benefici seguenti.\n\n**Punti ferita temporanei.** Con un'azione di Magia, il ranger può conferirsi un numero di punti ferita temporanei pari a 1d8 + il suo modificatore di Saggezza (minimo 1). Può usare questa azione un numero di volte pari al suo modificatore di Saggezza (minimo una volta) e recupera tutti gli utilizzi spesi quando completa un riposo lungo.\n\n**Diminuire l'indebolimento.** Ogni volta che il ranger completa un riposo breve, il suo livello di indebolimento, se ne ha, diminuisce di 1." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/relentless-hunter"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 13,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/relentless-hunter", "en"), Language = LanguageCode.En, Name = "Relentless Hunter", Description = "Taking damage can’t break your Concentration on Hunter’s Mark." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/relentless-hunter", "it"), Language = LanguageCode.It, Name = "Cacciatore Implacabile", Description = "Subire danni non può interrompere la concentrazione del ranger su *marchio del cacciatore*." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/natures-veil"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/natures-veil", "en"), Language = LanguageCode.En, Name = "Nature's Veil", Description = "You invoke spirits of nature to magically hide yourself. As a Bonus Action, you can give yourself the Invisible condition until the end of your next turn.\n\nYou can use this feature a number of times equal to your Wisdom modifier (minimum of once), and you regain all expended uses when you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/natures-veil", "it"), Language = LanguageCode.It, Name = "Velo della Natura", Description = "Il ranger invoca gli spiriti della natura per nascondersi magicamente. Come azione bonus, può conferirsi la condizione di invisibile fino alla fine del suo turno successivo.\n\nPuò usare questo privilegio un numero di volte pari al suo modificatore di Saggezza (minimo una volta) e recupera tutti gli utilizzi spesi quando completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/precise-hunter"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 13,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/precise-hunter", "en"), Language = LanguageCode.En, Name = "Precise Hunter", Description = "You have Advantage on attack rolls against the creature currently marked by your Hunter’s Mark." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/precise-hunter", "it"), Language = LanguageCode.It, Name = "Precisione del Cacciatore", Description = "Il ranger dispone di vantaggio ai tiri per colpire contro la creatura attualmente marchiata dal suo *marchio del cacciatore*." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/feral-senses"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 14,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/feral-senses", "en"), Language = LanguageCode.En, Name = "Feral Senses", Description = "Your connection to the forces of nature grants you Blindsight with a range of 30 feet." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/feral-senses", "it"), Language = LanguageCode.It, Name = "Sensi Ferini", Description = "Il legame con le forze della natura conferisce al ranger vista cieca con un raggio di 9 metri." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/epic-boon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 19,
					SortOrder = 15,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/epic-boon", "en"), Language = LanguageCode.En, Name = "Epic Boon", Description = "You gain an Epic Boon feat (see chapter 5) or another feat of your choice for which you qualify. Boon of Dimensional Travel is recommended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/epic-boon", "it"), Language = LanguageCode.It, Name = "Dono Epico", Description = "Il ranger ottiene un talento Dono epico o un altro talento a sua scelta di cui soddisfa i prerequisiti. È consigliato il Dono del viaggio dimensionale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/foe-slayer"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 16,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/foe-slayer", "en"), Language = LanguageCode.En, Name = "Foe Slayer", Description = "The damage die of your Hunter’s Mark is a d10 rather than a d6." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "ranger/foe-slayer", "it"), Language = LanguageCode.It, Name = "Sterminatore di Nemici", Description = "Il dado dei danni del *marchio del cacciatore* del ranger è un d10 anziché un d6." }
					}
				}
			}
		};
	}
}
