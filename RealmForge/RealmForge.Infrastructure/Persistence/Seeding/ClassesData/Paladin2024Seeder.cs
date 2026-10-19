using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Paladin (2024 ruleset): class features of the SRD 5.2 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Paladin2024Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "paladin");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			HitDie = 10,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Charisma },
			SavingThrows = new List<AbilityScore> { AbilityScore.Wisdom, AbilityScore.Charisma },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.Athletics, Skill.Insight, Skill.Intimidation, Skill.Medicine, Skill.Persuasion, Skill.Religion },
			CasterProgression = CasterProgression.Half,
			SpellcastingAbility = AbilityScore.Charisma,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "paladin", "en"),
					Language = LanguageCode.En,
					Name = "Paladin",
					Description = "A holy warrior bound by a sacred oath. Paladins blend martial training with divine magic: they heal with a touch, smite foes with radiant power and project auras that shield their allies, drawing their strength from the conviction of the vow they have sworn.",
					SubclassTitle = "Paladin Subclass",
					ArmorProficiencies = "Light, Medium and Heavy armor; Shields",
					WeaponProficiencies = "Simple and Martial weapons",
					ToolProficiencies = "None",
					StartingEquipment = "Choose A or B:\n- (A) Chain Mail, Shield, Longsword, 6 Javelins, Holy Symbol, Priest's Pack and 9 GP\n- (B) 150 GP",
					ProgressionTable = "The 1–5 columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Class Features | Channel Divinity | Prepared Spells | 1 | 2 | 3 | 4 | 5 |\n|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Lay On Hands, Spellcasting, Weapon Mastery | — | 2 | 2 | — | — | — | — |\n| 2 | +2 | Fighting Style, Paladin's Smite | — | 3 | 2 | — | — | — | — |\n| 3 | +2 | Channel Divinity, Paladin Subclass | 2 | 4 | 3 | — | — | — | — |\n| 4 | +2 | Ability Score Improvement | 2 | 5 | 3 | — | — | — | — |\n| 5 | +3 | Extra Attack, Faithful Steed | 2 | 6 | 4 | 2 | — | — | — |\n| 6 | +3 | Aura of Protection | 2 | 6 | 4 | 2 | — | — | — |\n| 7 | +3 | Subclass feature | 2 | 7 | 4 | 3 | — | — | — |\n| 8 | +3 | Ability Score Improvement | 2 | 7 | 4 | 3 | — | — | — |\n| 9 | +4 | Abjure Foes | 2 | 9 | 4 | 3 | 2 | — | — |\n| 10 | +4 | Aura of Courage | 2 | 9 | 4 | 3 | 2 | — | — |\n| 11 | +4 | Radiant Strikes | 3 | 10 | 4 | 3 | 3 | — | — |\n| 12 | +4 | Ability Score Improvement | 3 | 10 | 4 | 3 | 3 | — | — |\n| 13 | +5 | — | 3 | 11 | 4 | 3 | 3 | 1 | — |\n| 14 | +5 | Restoring Touch | 3 | 11 | 4 | 3 | 3 | 1 | — |\n| 15 | +5 | Subclass feature | 3 | 12 | 4 | 3 | 3 | 2 | — |\n| 16 | +5 | Ability Score Improvement | 3 | 12 | 4 | 3 | 3 | 2 | — |\n| 17 | +6 | — | 3 | 14 | 4 | 3 | 3 | 3 | 1 |\n| 18 | +6 | Aura Expansion | 3 | 14 | 4 | 3 | 3 | 3 | 1 |\n| 19 | +6 | Epic Boon | 3 | 15 | 4 | 3 | 3 | 3 | 2 |\n| 20 | +6 | Subclass feature | 3 | 15 | 4 | 3 | 3 | 3 | 2 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "paladin", "it"),
					Language = LanguageCode.It,
					Name = "Paladino",
					Description = "Un guerriero sacro vincolato da un giuramento solenne. Il paladino unisce l'addestramento marziale alla magia divina: cura con un tocco, punisce i nemici con un potere radioso e proietta aure che proteggono i suoi alleati, traendo la propria forza dalla convinzione del voto pronunciato.",
					SubclassTitle = "Sottoclasse del paladino",
					ArmorProficiencies = "Armature leggere, medie e pesanti; scudi",
					WeaponProficiencies = "Armi semplici e da guerra",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "A scelta tra A e B:\n- (A) una cotta di maglia, uno scudo, una spada lunga, 6 giavellotti, un simbolo sacro, una dotazione da sacerdote e 9 mo\n- (B) 150 mo",
					ProgressionTable = "Le colonne 1–5 indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi di classe | Incanalare Divinità | Incantesimi preparati | 1 | 2 | 3 | 4 | 5 |\n|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Imposizione delle Mani, Incantesimi, Padronanza nelle Armi | — | 2 | 2 | — | — | — | — |\n| 2 | +2 | Stile di Combattimento, Punizione del Paladino | — | 3 | 2 | — | — | — | — |\n| 3 | +2 | Incanalare Divinità, Sottoclasse del Paladino | 2 | 4 | 3 | — | — | — | — |\n| 4 | +2 | Aumento dei Punteggi di Caratteristica | 2 | 5 | 3 | — | — | — | — |\n| 5 | +3 | Attacco Extra, Fido Destriero | 2 | 6 | 4 | 2 | — | — | — |\n| 6 | +3 | Aura di Protezione | 2 | 6 | 4 | 2 | — | — | — |\n| 7 | +3 | Privilegio della sottoclasse | 2 | 7 | 4 | 3 | — | — | — |\n| 8 | +3 | Aumento dei Punteggi di Caratteristica | 2 | 7 | 4 | 3 | — | — | — |\n| 9 | +4 | Abiurare Nemici | 2 | 9 | 4 | 3 | 2 | — | — |\n| 10 | +4 | Aura di Coraggio | 2 | 9 | 4 | 3 | 2 | — | — |\n| 11 | +4 | Colpi Radiosi | 3 | 10 | 4 | 3 | 3 | — | — |\n| 12 | +4 | Aumento dei Punteggi di Caratteristica | 3 | 10 | 4 | 3 | 3 | — | — |\n| 13 | +5 | — | 3 | 11 | 4 | 3 | 3 | 1 | — |\n| 14 | +5 | Tocco Rigenerante | 3 | 11 | 4 | 3 | 3 | 1 | — |\n| 15 | +5 | Privilegio della sottoclasse | 3 | 12 | 4 | 3 | 3 | 2 | — |\n| 16 | +5 | Aumento dei Punteggi di Caratteristica | 3 | 12 | 4 | 3 | 3 | 2 | — |\n| 17 | +6 | — | 3 | 14 | 4 | 3 | 3 | 3 | 1 |\n| 18 | +6 | Ampliamento dell'Aura | 3 | 14 | 4 | 3 | 3 | 3 | 1 |\n| 19 | +6 | Dono Epico | 3 | 15 | 4 | 3 | 3 | 3 | 2 |\n| 20 | +6 | Privilegio della sottoclasse | 3 | 15 | 4 | 3 | 3 | 3 | 2 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/lay-on-hands"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/lay-on-hands", "en"), Language = LanguageCode.En, Name = "Lay On Hands", Description = "Your blessed touch can heal wounds. You have a pool of healing power that replenishes when you finish a Long Rest. With that pool, you can restore a total number of Hit Points equal to five times your Paladin level.\n\nAs a Bonus Action, you can touch a creature (which could be yourself) and draw power from the pool of healing to restore a number of Hit Points to that creature, up to the maximum amount remaining in the pool.\n\nYou can also expend 5 Hit Points from the pool of healing power to remove the Poisoned condition from the creature; those points don’t also restore Hit Points to the creature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/lay-on-hands", "it"), Language = LanguageCode.It, Name = "Imposizione delle Mani", Description = "Il tocco benedetto del paladino è in grado di curare le ferite. Il paladino possiede una riserva di potere curativo che si ricarica quando completa un riposo lungo; con essa può ripristinare un totale di punti ferita pari a cinque volte il suo livello da paladino.\n\nCome azione bonus, il paladino può toccare una creatura (anche se stesso) e attingere alla riserva per farle recuperare punti ferita, fino al massimo rimasto nella riserva.\n\nPuò anche spendere 5 punti ferita della riserva per rimuovere dalla creatura la condizione di avvelenato; quei punti non le fanno recuperare anche punti ferita." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "You have learned to cast spells through prayer and meditation. See chapter 7 for the rules on spellcasting. The information below details how you use those rules with Paladin spells, which appear in the Paladin spell list later in the class’s description.\n\n**Spell Slots.** The Paladin Features table shows how many spell slots you have to cast your level 1+ spells. You regain all expended slots when you finish a Long Rest.\n\n**Prepared Spells of Level 1+.** You prepare the list of level 1+ spells that are available for you to cast with this feature. To start, choose two level 1 Paladin spells. Heroism and Searing Smite are recommended.\n\nThe number of spells on your list increases as you gain Paladin levels, as shown in the Prepared Spells column of the Paladin Features table. Whenever that number increases, choose additional Paladin spells until the number of spells on your list matches the number in the Paladin Features table. The chosen spells must be of a level for which you have spell slots. For example, if you’re a level 5 Paladin, your list of prepared spells can include six Paladin spells of level 1 or 2 in any combination.\n\nIf another Paladin feature gives you spells that you always have prepared, those spells don’t count against the number of spells you can prepare with this feature, but those spells otherwise count as Paladin spells for you.\n\n**Changing Your Prepared Spells.** Whenever you finish a Long Rest, you can replace one spell on your list with another Paladin spell for which you have spell slots.\n\n**Spellcasting Ability.** Charisma is your spellcasting ability for your Paladin spells.\n\n**Spellcasting Focus.** You can use a Holy Symbol as a Spellcasting Focus for your Paladin spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Grazie alla preghiera e alla meditazione, il paladino ha imparato a lanciare incantesimi (le regole per lanciarli si trovano nel capitolo sugli incantesimi). Di seguito è spiegato come il paladino applica quelle regole agli incantesimi da paladino, che compaiono nella lista degli incantesimi da paladino.\n\n**Slot incantesimo.** La tabella dei privilegi del paladino indica quanti slot incantesimo possiede il paladino per lanciare i suoi incantesimi di 1° livello o superiore. Recupera tutti gli slot spesi quando completa un riposo lungo.\n\n**Incantesimi preparati di 1° livello o superiore.** Il paladino prepara l'elenco degli incantesimi di 1° livello o superiore che può lanciare con questo privilegio. Per cominciare, sceglie due incantesimi da paladino di 1° livello; sono consigliati *eroismo* e *punizione incandescente*.\n\nIl numero di incantesimi del suo elenco aumenta man mano che sale di livello come paladino, come indicato nella colonna Incantesimi preparati della tabella dei privilegi del paladino. Ogni volta che quel numero aumenta, sceglie altri incantesimi da paladino finché il numero di incantesimi nel suo elenco non coincide con quello della tabella. Gli incantesimi scelti devono essere di un livello per cui il paladino possiede slot incantesimo. Per esempio, un paladino di 5° livello può avere nel suo elenco sei incantesimi da paladino di 1° o 2° livello in qualsiasi combinazione.\n\nSe un altro privilegio da paladino gli fa avere incantesimi sempre preparati, quegli incantesimi non contano nel numero di incantesimi che può preparare con questo privilegio, ma per il resto contano come incantesimi da paladino per lui.\n\n**Cambiare gli incantesimi preparati.** Ogni volta che completa un riposo lungo, il paladino può sostituire un incantesimo del suo elenco con un altro incantesimo da paladino per cui possiede slot incantesimo.\n\n**Caratteristica da incantatore.** Il Carisma è la caratteristica da incantatore del paladino per i suoi incantesimi da paladino.\n\n**Focus da incantatore.** Il paladino può usare un simbolo sacro come focus da incantatore per i suoi incantesimi da paladino." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/weapon-mastery"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/weapon-mastery", "en"), Language = LanguageCode.En, Name = "Weapon Mastery", Description = "Your training with weapons allows you to use the mastery properties of two kinds of weapons of your choice with which you have proficiency, such as Longswords and Javelins.\n\nWhenever you finish a Long Rest, you can change the kinds of weapons you chose. For example, you could switch to using the mastery properties of Halberds and Flails." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/weapon-mastery", "it"), Language = LanguageCode.It, Name = "Padronanza nelle Armi", Description = "Il suo addestramento con le armi permette al paladino di usare le proprietà di padronanza di due tipi di armi a sua scelta in cui ha competenza, come le spade lunghe e i giavellotti.\n\nOgni volta che completa un riposo lungo, può cambiare i tipi di armi scelti; per esempio, potrebbe passare alle proprietà di padronanza delle alabarde e dei mazzafrusti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/fighting-style"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/fighting-style", "en"), Language = LanguageCode.En, Name = "Fighting Style", Description = "You gain a Fighting Style feat of your choice (see chapter 5 for feats). Instead of choosing one of those feats, you can choose the option below.\n\n**Blessed Warrior.** You learn two Cleric cantrips of your choice (see the Cleric class’s section for a list of Cleric spells). Guidance and Sacred Flame are recommended. The chosen cantrips count as Paladin spells for you, and Charisma is your spellcasting ability for them. Whenever you gain a Paladin level, you can replace one of these cantrips with another Cleric cantrip." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/fighting-style", "it"), Language = LanguageCode.It, Name = "Stile di Combattimento", Description = "Il paladino ottiene un talento Stile di combattimento a sua scelta. Invece di scegliere uno di quei talenti, può scegliere l'opzione seguente.\n\n**Guerriero benedetto.** Il paladino impara due trucchetti da chierico a sua scelta; sono consigliati *fiamma sacra* e *guida*. I trucchetti scelti contano come incantesimi da paladino per lui, e la sua caratteristica da incantatore per essi è il Carisma. Ogni volta che sale di livello come paladino, può sostituire uno di questi trucchetti con un altro trucchetto da chierico." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/paladins-smite"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/paladins-smite", "en"), Language = LanguageCode.En, Name = "Paladin's Smite", Description = "You always have the Divine Smite spell prepared. In addition, you can cast it without expending a spell slot, but you must finish a Long Rest before you can cast it in this way again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/paladins-smite", "it"), Language = LanguageCode.It, Name = "Punizione del Paladino", Description = "Il paladino ha sempre preparato l'incantesimo *punizione divina*. Inoltre, può lanciarlo senza spendere uno slot incantesimo, ma deve completare un riposo lungo prima di poterlo lanciare di nuovo in questo modo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/channel-divinity"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/channel-divinity", "en"), Language = LanguageCode.En, Name = "Channel Divinity", Description = "You can channel divine energy directly from the Outer Planes, using it to fuel magical effects. You start with one such effect: Divine Sense, which is described below. Other Paladin features give additional Channel Divinity effect options. Each time you use this class’s Channel Divinity, you choose which effect from this class to create.\n\nYou can use this class’s Channel Divinity twice. You regain one of its expended uses when you finish a Short Rest, and you regain all expended uses when you finish a Long Rest. You gain an additional use when you reach Paladin level 11.\n\nIf a Channel Divinity effect requires a saving throw, the DC equals the spell save DC from this class’s Spellcasting feature.\n\n**Divine Sense.** As a Bonus Action, you can open your awareness to detect Celestials, Fiends, and Undead. For the next 10 minutes or until you have the Incapacitated condition, you know the location of any creature of those types within 60 feet of yourself, and you know its creature type. Within the same radius, you also detect the presence of any place or object that has been consecrated or desecrated, as with the Hallow spell." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/channel-divinity", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità", Description = "Il paladino è in grado di incanalare energia divina direttamente dai Piani Esterni per alimentare effetti magici. Inizia con un solo effetto di questo tipo, Percezione del divino, descritto di seguito; altri privilegi da paladino conferiscono ulteriori opzioni. Ogni volta che usa Incanalare Divinità di questa classe, sceglie quale effetto di questa classe creare.\n\nIl paladino può usare Incanalare Divinità di questa classe due volte. Recupera un utilizzo speso quando completa un riposo breve e tutti gli utilizzi spesi quando completa un riposo lungo. Ottiene un utilizzo aggiuntivo all'11° livello da paladino.\n\nSe un effetto di Incanalare Divinità richiede un tiro salvezza, la CD è pari alla CD del tiro salvezza degli incantesimi del privilegio Incantesimi di questa classe.\n\n**Percezione del divino.** Come azione bonus, il paladino può aprire i propri sensi per individuare celestiali, immondi e non morti. Per i 10 minuti successivi o finché non subisce la condizione di incapacitato, conosce la posizione di qualsiasi creatura di quei tipi entro 18 metri da lui e ne conosce il tipo. Entro lo stesso raggio percepisce anche la presenza di qualsiasi luogo od oggetto consacrato o sconsacrato, come con l'incantesimo *santificare*." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/paladin-subclass"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/paladin-subclass", "en"), Language = LanguageCode.En, Name = "Paladin Subclass", Description = "You gain a Paladin subclass of your choice. The Oath of Devotion, Oath of Glory, Oath of the Ancients, and Oath of Vengeance subclasses are detailed after this class’s description. A subclass is a specialization that grants you features at certain Paladin levels. For the rest of your career, you gain each of your subclass’s features that are of your Paladin level or lower." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/paladin-subclass", "it"), Language = LanguageCode.It, Name = "Sottoclasse del Paladino", Description = "Il paladino ottiene una sottoclasse del paladino a sua scelta: Giuramento degli Antichi, Giuramento di Devozione, Giuramento di Gloria o Giuramento di Vendetta. Una sottoclasse è una specializzazione che conferisce privilegi a determinati livelli da paladino. Per il resto della sua carriera, il paladino ottiene ogni privilegio della sottoclasse di livello pari o inferiore al suo livello da paladino." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "You gain the Ability Score Improvement feat (see chapter 5) or another feat of your choice for which you qualify. You gain this feature again at Paladin levels 8, 12, and 16." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Il paladino ottiene il talento Aumento dei punteggi di caratteristica o un altro talento a sua scelta di cui soddisfa i prerequisiti. Ottiene di nuovo questo privilegio all'8°, al 12° e al 16° livello da paladino." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "You can attack twice instead of once whenever you take the Attack action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Ogni volta che sceglie l'azione di Attacco durante il proprio turno, il paladino effettua due attacchi invece di uno solo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/faithful-steed"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/faithful-steed", "en"), Language = LanguageCode.En, Name = "Faithful Steed", Description = "You can call on the aid of an otherworldly steed. You always have the Find Steed spell prepared.\n\nYou can also cast the spell once without expending a spell slot, and you regain the ability to do so when you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/faithful-steed", "it"), Language = LanguageCode.It, Name = "Fido Destriero", Description = "Il paladino può invocare l'aiuto di una cavalcatura ultraterrena: ha sempre preparato l'incantesimo *trova cavalcatura*.\n\nPuò inoltre lanciare l'incantesimo una volta senza spendere uno slot incantesimo, e riacquista questa possibilità quando completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/aura-of-protection"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/aura-of-protection", "en"), Language = LanguageCode.En, Name = "Aura of Protection", Description = "You radiate a protective, unseeable aura in a 10-foot Emanation that originates from you. The aura is inactive while you have the Incapacitated condition.\n\nYou and your allies in the aura gain a bonus to saving throws equal to your Charisma modifier (minimum bonus of +1). If another Paladin is present, a creature can benefit from only one Aura of Protection at a time; the creature chooses which aura while in them." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/aura-of-protection", "it"), Language = LanguageCode.It, Name = "Aura di Protezione", Description = "Il paladino irradia un'aura protettiva e invisibile in un'emanazione di 3 metri che parte da lui. L'aura è inattiva finché il paladino è incapacitato.\n\nIl paladino e i suoi alleati nell'aura ottengono un bonus ai tiri salvezza pari al suo modificatore di Carisma (bonus minimo +1). Se è presente un altro paladino, una creatura può beneficiare di una sola Aura di protezione alla volta e sceglie quale, se si trova in più di una." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/abjure-foes"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 9,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/abjure-foes", "en"), Language = LanguageCode.En, Name = "Abjure Foes", Description = "As a Magic action, you can expend one use of this class’s Channel Divinity to overwhelm foes with awe. As you present your Holy Symbol or weapon, you can target a number of creatures equal to your Charisma modifier (minimum of one creature) that you can see within 60 feet of yourself. Each target must succeed on a Wisdom saving throw or have the Frightened condition for 1 minute or until it takes any damage. While Frightened in this way, a target can do only one of the following on its turns: move, take an action, or take a Bonus Action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/abjure-foes", "it"), Language = LanguageCode.It, Name = "Abiurare Nemici", Description = "Con un'azione di Magia, il paladino può spendere un utilizzo di Incanalare Divinità di questa classe per sopraffare i nemici con un timore reverenziale. Presentando il suo simbolo sacro o la sua arma, può prendere come bersaglio un numero di creature che è in grado di vedere entro 18 metri da lui pari al suo modificatore di Carisma (minimo una). Ogni bersaglio deve superare un tiro salvezza su Saggezza, altrimenti subisce la condizione di spaventato per 1 minuto o finché non subisce danni. Finché è spaventato in questo modo, nei suoi turni un bersaglio può fare soltanto una delle cose seguenti: muoversi, effettuare un'azione o effettuare un'azione bonus." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/aura-of-courage"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/aura-of-courage", "en"), Language = LanguageCode.En, Name = "Aura of Courage", Description = "You and your allies have Immunity to the Frightened condition while in your Aura of Protection. If a Frightened ally enters the aura, that condition has no effect on that ally while there." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/aura-of-courage", "it"), Language = LanguageCode.It, Name = "Aura di Coraggio", Description = "Il paladino e i suoi alleati sono immuni alla condizione di spaventato finché si trovano nella sua Aura di protezione. Se un alleato spaventato entra nell'aura, la condizione non ha effetto su di lui finché vi rimane." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/radiant-strikes"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 13,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/radiant-strikes", "en"), Language = LanguageCode.En, Name = "Radiant Strikes", Description = "Your strikes now carry supernatural power. When you hit a target with an attack roll using a Melee weapon or an Unarmed Strike, the target takes an extra 1d8 Radiant damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/radiant-strikes", "it"), Language = LanguageCode.It, Name = "Colpi Radiosi", Description = "I colpi del paladino ora portano con sé un potere soprannaturale. Quando colpisce un bersaglio con un tiro per colpire effettuato con un'arma da mischia o con un colpo senz'armi, il bersaglio subisce 1d8 danni radiosi extra." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/restoring-touch"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 14,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/restoring-touch", "en"), Language = LanguageCode.En, Name = "Restoring Touch", Description = "When you use Lay On Hands on a creature, you can also remove one or more of the following conditions from the creature: Blinded, Charmed, Deafened, Frightened, Paralyzed, or Stunned. You must expend 5 Hit Points from the healing pool of Lay On Hands for each of these conditions you remove; those points don’t also restore Hit Points to the creature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/restoring-touch", "it"), Language = LanguageCode.It, Name = "Tocco Rigenerante", Description = "Quando usa Imposizione delle mani su una creatura, il paladino può anche rimuoverle una o più delle condizioni seguenti: accecato, affascinato, assordato, paralizzato, spaventato o stordito. Per ogni condizione rimossa deve spendere 5 punti ferita dalla riserva di Imposizione delle mani; quei punti non fanno recuperare anche punti ferita alla creatura." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/aura-expansion"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 15,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/aura-expansion", "en"), Language = LanguageCode.En, Name = "Aura Expansion", Description = "Your Aura of Protection is now a 30-foot Emanation." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/aura-expansion", "it"), Language = LanguageCode.It, Name = "Ampliamento dell'Aura", Description = "Il raggio dell'Aura di protezione si allarga: d'ora in poi l'emanazione si estende per 9 metri attorno al paladino." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/epic-boon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 19,
					SortOrder = 16,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/epic-boon", "en"), Language = LanguageCode.En, Name = "Epic Boon", Description = "You gain an Epic Boon feat (see chapter 5) or another feat of your choice for which you qualify. Boon of Truesight is recommended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "paladin/epic-boon", "it"), Language = LanguageCode.It, Name = "Dono Epico", Description = "Il paladino ottiene un talento Dono epico o un altro talento a sua scelta di cui soddisfa i prerequisiti. È consigliato il Dono della vista pura." }
					}
				}
			}
		};
	}
}
