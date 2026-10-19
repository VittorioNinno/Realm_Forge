using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Cleric (2024 ruleset): class features of the SRD 5.2 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Cleric2024Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "cleric");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			HitDie = 8,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Wisdom },
			SavingThrows = new List<AbilityScore> { AbilityScore.Wisdom, AbilityScore.Charisma },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.History, Skill.Insight, Skill.Medicine, Skill.Persuasion, Skill.Religion },
			CasterProgression = CasterProgression.Full,
			SpellcastingAbility = AbilityScore.Wisdom,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "cleric", "en"),
					Language = LanguageCode.En,
					Name = "Cleric",
					Description = "A priestly champion who draws power from the gods of the multiverse. Clerics heal the wounded, shield the faithful and smite the enemies of their deity, wielding divine magic shaped by prayer, devotion and the sacred domain they serve.",
					SubclassTitle = "Cleric Subclass",
					ArmorProficiencies = "Light and Medium armor; Shields",
					WeaponProficiencies = "Simple weapons",
					ToolProficiencies = "None",
					StartingEquipment = "Choose A or B:\n- (A) Chain Shirt, Shield, Mace, Holy Symbol, Priest's Pack and 7 GP\n- (B) 110 GP",
					ProgressionTable = "The 1–9 columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Class Features | Channel Divinity | Cantrips | Prepared Spells | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Spellcasting, Divine Order | — | 3 | 4 | 2 | — | — | — | — | — | — | — | — |\n| 2 | +2 | Channel Divinity | 2 | 3 | 5 | 3 | — | — | — | — | — | — | — | — |\n| 3 | +2 | Cleric Subclass | 2 | 3 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4 | +2 | Ability Score Improvement | 2 | 4 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5 | +3 | Sear Undead | 2 | 4 | 9 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6 | +3 | Subclass feature | 3 | 4 | 10 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7 | +3 | Blessed Strikes | 3 | 4 | 11 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8 | +3 | Ability Score Improvement | 3 | 4 | 12 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9 | +4 | — | 3 | 4 | 14 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10 | +4 | Divine Intervention | 3 | 5 | 15 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11 | +4 | — | 3 | 5 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12 | +4 | Ability Score Improvement | 3 | 5 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13 | +5 | — | 3 | 5 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14 | +5 | Improved Blessed Strikes | 3 | 5 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15 | +5 | — | 3 | 5 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16 | +5 | Ability Score Improvement | 3 | 5 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17 | +6 | Subclass feature | 3 | 5 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18 | +6 | — | 4 | 5 | 20 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19 | +6 | Epic Boon | 4 | 5 | 21 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20 | +6 | Greater Divine Intervention | 4 | 5 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "cleric", "it"),
					Language = LanguageCode.It,
					Name = "Chierico",
					Description = "Un campione sacerdotale che trae il proprio potere dalle divinità del multiverso. Il chierico cura i feriti, protegge i fedeli e colpisce i nemici del suo dio, impugnando una magia divina plasmata dalla preghiera, dalla devozione e dal dominio sacro che serve.",
					SubclassTitle = "Sottoclasse del chierico",
					ArmorProficiencies = "Armature leggere e medie; scudi",
					WeaponProficiencies = "Armi semplici",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "A scelta tra A e B:\n- (A) una giacca di maglia, uno scudo, una mazza, un simbolo sacro, una dotazione da sacerdote e 7 mo\n- (B) 110 mo",
					ProgressionTable = "Le colonne 1–9 indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi di classe | Incanalare Divinità | Trucchetti | Incantesimi preparati | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Incantesimi, Ordine Divino | — | 3 | 4 | 2 | — | — | — | — | — | — | — | — |\n| 2 | +2 | Incanalare Divinità | 2 | 3 | 5 | 3 | — | — | — | — | — | — | — | — |\n| 3 | +2 | Sottoclasse del Chierico | 2 | 3 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4 | +2 | Aumento dei Punteggi di Caratteristica | 2 | 4 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5 | +3 | Bruciare i Non Morti | 2 | 4 | 9 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6 | +3 | Privilegio della sottoclasse | 3 | 4 | 10 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7 | +3 | Colpi Benedetti | 3 | 4 | 11 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8 | +3 | Aumento dei Punteggi di Caratteristica | 3 | 4 | 12 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9 | +4 | — | 3 | 4 | 14 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10 | +4 | Intervento Divino | 3 | 5 | 15 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11 | +4 | — | 3 | 5 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12 | +4 | Aumento dei Punteggi di Caratteristica | 3 | 5 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13 | +5 | — | 3 | 5 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14 | +5 | Colpi Benedetti Migliorati | 3 | 5 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15 | +5 | — | 3 | 5 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16 | +5 | Aumento dei Punteggi di Caratteristica | 3 | 5 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17 | +6 | Privilegio della sottoclasse | 3 | 5 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18 | +6 | — | 4 | 5 | 20 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19 | +6 | Dono Epico | 4 | 5 | 21 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20 | +6 | Intervento Divino Superiore | 4 | 5 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "You have learned to cast spells through prayer and meditation. See chapter 7 for the rules on spellcasting. The information below details how you use those rules with Cleric spells, which appear on the Cleric spell list later in the class’s description.\n\n**Cantrips.** You know three cantrips of your choice from the Cleric spell list. Guidance, Sacred Flame, and Thaumaturgy are recommended. Whenever you gain a Cleric level, you can replace one of your cantrips with another cantrip of your choice from the Cleric spell list. When you reach Cleric levels 4 and 10, you learn another cantrip of your choice from the Cleric spell list, as shown in the Cantrips column of the Cleric Features table.\n\n**Spell Slots.** The Cleric Features table shows how many spell slots you have to cast your level 1+ spells. You regain all expended slots when you finish a Long Rest.\n\n**Prepared Spells of Level 1+.** You prepare the list of level 1+ spells that are available for you to cast with this feature. To start, choose four level 1 spells from the Cleric spell list. Bless, Cure Wounds, Guiding Bolt, and Shield of Faith are recommended.\n\nThe number of spells on your list increases as you gain Cleric levels, as shown in the Prepared Spells column of the Cleric Features table. Whenever that number increases, choose additional spells from the Cleric spell list until the number of spells on your list matches the number on the table. The chosen spells must be of a level for which you have spell slots. For example, if you’re a level 3 Cleric, your list of prepared spells can include six spells of levels 1 and 2 in any combination.\n\nIf another Cleric feature gives you spells that you always have prepared, those spells don’t count against the number of spells you can prepare with this feature, but those spells otherwise count as Cleric spells for you.\n\n**Changing Your Prepared Spells.** Whenever you finish a Long Rest, you can change your list of prepared spells, replacing any of the spells there with other Cleric spells for which you have spell slots.\n\n**Spellcasting Ability.** Wisdom is your spellcasting ability for your Cleric spells.\n\n**Spellcasting Focus.** You can use a Holy Symbol as a Spellcasting Focus for your Cleric spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Grazie alla preghiera e alla meditazione, il chierico ha imparato a lanciare incantesimi (le regole per lanciarli si trovano nel capitolo sugli incantesimi). Di seguito è spiegato come il chierico applica quelle regole agli incantesimi da chierico, che compaiono nella lista degli incantesimi da chierico.\n\n**Trucchetti.** Il chierico conosce tre trucchetti a sua scelta dalla lista degli incantesimi da chierico; sono consigliati *fiamma sacra*, *guida* e *taumaturgia*. Ogni volta che sale di livello come chierico, può sostituire uno dei suoi trucchetti con un altro trucchetto a sua scelta dalla stessa lista. Al 4° e al 10° livello da chierico impara un altro trucchetto a sua scelta dalla lista, come indicato nella colonna Trucchetti della tabella dei privilegi del chierico.\n\n**Slot incantesimo.** La tabella dei privilegi del chierico indica quanti slot incantesimo possiede il chierico per lanciare i suoi incantesimi di 1° livello o superiore. Recupera tutti gli slot spesi quando completa un riposo lungo.\n\n**Incantesimi preparati di 1° livello o superiore.** Il chierico prepara l'elenco degli incantesimi di 1° livello o superiore che può lanciare con questo privilegio. Per cominciare, sceglie quattro incantesimi di 1° livello dalla lista degli incantesimi da chierico; sono consigliati *benedizione*, *cura ferite*, *dardo tracciante* e *scudo della fede*.\n\nIl numero di incantesimi del suo elenco aumenta man mano che sale di livello come chierico, come indicato nella colonna Incantesimi preparati della tabella dei privilegi del chierico. Ogni volta che quel numero aumenta, sceglie altri incantesimi dalla lista degli incantesimi da chierico finché il numero di incantesimi nel suo elenco non coincide con quello della tabella. Gli incantesimi scelti devono essere di un livello per cui il chierico possiede slot incantesimo. Per esempio, un chierico di 3° livello può avere nel suo elenco sei incantesimi di 1° e 2° livello in qualsiasi combinazione.\n\nSe un altro privilegio da chierico gli fa avere incantesimi sempre preparati, quegli incantesimi non contano nel numero di incantesimi che può preparare con questo privilegio, ma per il resto contano come incantesimi da chierico per lui.\n\n**Cambiare gli incantesimi preparati.** Ogni volta che completa un riposo lungo, il chierico può modificare il suo elenco di incantesimi preparati, sostituendone uno qualsiasi con altri incantesimi da chierico per cui possiede slot incantesimo.\n\n**Caratteristica da incantatore.** La Saggezza è la caratteristica da incantatore del chierico per i suoi incantesimi da chierico.\n\n**Focus da incantatore.** Il chierico può usare un simbolo sacro come focus da incantatore per i suoi incantesimi da chierico." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/divine-order"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/divine-order", "en"), Language = LanguageCode.En, Name = "Divine Order", Description = "You have dedicated yourself to one of the following sacred roles of your choice.\n\n**Protector.** Trained for battle, you gain proficiency with Martial weapons and training with Heavy armor.\n\n**Thaumaturge.** You know one extra cantrip from the Cleric spell list. In addition, your mystical connection to the divine gives you a bonus to your Intelligence (Arcana or Religion) checks. The bonus equals your Wisdom modifier (minimum of +1)." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/divine-order", "it"), Language = LanguageCode.It, Name = "Ordine Divino", Description = "Il chierico si è consacrato a uno dei ruoli sacri seguenti, a sua scelta.\n\n**Protettore.** Addestrato alla battaglia, il chierico ottiene competenza nelle armi da guerra e addestramento nelle armature pesanti.\n\n**Taumaturgo.** Il chierico conosce un trucchetto aggiuntivo dalla lista degli incantesimi da chierico. Inoltre, il suo legame mistico con il divino gli conferisce un bonus alle prove di Intelligenza (Arcano o Religione) pari al suo modificatore di Saggezza (minimo +1)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/channel-divinity"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/channel-divinity", "en"), Language = LanguageCode.En, Name = "Channel Divinity", Description = "You can channel divine energy directly from the Outer Planes to fuel magical effects. You start with two such effects: Divine Spark and Turn Undead, each of which is described below. Each time you use this class’s Channel Divinity, choose which Channel Divinity effect from this class to create. You gain additional effect options at higher Cleric levels.\n\nYou can use this class’s Channel Divinity twice. You regain one of its expended uses when you finish a Short Rest, and you regain all expended uses when you finish a Long Rest. You gain additional uses when you reach certain Cleric levels, as shown in the Channel Divinity column of the Cleric Features table.\n\nIf a Channel Divinity effect requires a saving throw, the DC equals the spell save DC from this class’s Spellcasting feature.\n\n**Divine Spark.** As a Magic action, you point your Holy Symbol at another creature you can see within 30 feet of yourself and focus divine energy at it. Roll 1d8 and add your Wisdom modifier. You either restore Hit Points to the creature equal to that total or force the creature to make a Constitution saving throw. On a failed save, the creature takes Necrotic or Radiant damage (your choice) equal to that total. On a successful save, the creature takes half as much damage (round down).\n\nYou roll an additional d8 when you reach Cleric levels 7 (2d8), 13 (3d8), and 18 (4d8).\n\n**Turn Undead.** As a Magic action, you present your Holy Symbol and censure Undead creatures. Each Undead of your choice within 30 feet of you must make a Wisdom saving throw. If the creature fails its save, it has the Frightened and Incapacitated conditions for 1 minute. For that duration, it tries to move as far from you as it can on its turns. This effect ends early on the creature if it takes any damage, if you have the Incapacitated condition, or if you die." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/channel-divinity", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità", Description = "Il chierico è in grado di incanalare energia divina direttamente dai Piani Esterni per alimentare effetti magici. Inizia con due di questi effetti, Scintilla divina e Scacciare non morti, descritti di seguito. Ogni volta che usa Incanalare Divinità di questa classe, sceglie quale effetto di Incanalare Divinità di questa classe creare. Ottiene ulteriori opzioni di effetto ai livelli da chierico più alti.\n\nIl chierico può usare Incanalare Divinità di questa classe due volte. Recupera un utilizzo speso quando completa un riposo breve e tutti gli utilizzi spesi quando completa un riposo lungo. Ottiene utilizzi aggiuntivi a determinati livelli da chierico, come indicato nella colonna Incanalare Divinità della tabella dei privilegi del chierico.\n\nSe un effetto di Incanalare Divinità richiede un tiro salvezza, la CD è pari alla CD del tiro salvezza degli incantesimi del privilegio Incantesimi di questa classe.\n\n**Scintilla divina.** Con un'azione di Magia, il chierico punta il suo simbolo sacro verso un'altra creatura che è in grado di vedere entro 9 metri da lui e concentra su di essa energia divina. Tira 1d8 e somma il suo modificatore di Saggezza: può far recuperare alla creatura un numero di punti ferita pari al totale oppure costringerla a effettuare un tiro salvezza su Costituzione. Se lo fallisce, la creatura subisce danni necrotici o radiosi (a scelta del chierico) pari al totale; se lo supera, subisce la metà di quei danni (arrotondati per difetto).\n\nIl chierico tira un d8 aggiuntivo al 7° (2d8), al 13° (3d8) e al 18° livello da chierico (4d8).\n\n**Scacciare non morti.** Con un'azione di Magia, il chierico presenta il suo simbolo sacro e condanna i non morti. Ogni non morto a sua scelta entro 9 metri da lui deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, subisce le condizioni di spaventato e incapacitato per 1 minuto e, per quella durata, nei suoi turni cerca di allontanarsi il più possibile dal chierico. L'effetto termina prima su quella creatura se subisce danni, se il chierico subisce la condizione di incapacitato o se il chierico muore." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/cleric-subclass"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/cleric-subclass", "en"), Language = LanguageCode.En, Name = "Cleric Subclass", Description = "You gain a Cleric subclass of your choice. The Life Domain, Light Domain, Trickery Domain, and War Domain subclasses are detailed after this class’s description. A subclass is a specialization that grants you features at certain Cleric levels. For the rest of your career, you gain each of your subclass’s features that are of your Cleric level or lower." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/cleric-subclass", "it"), Language = LanguageCode.It, Name = "Sottoclasse del Chierico", Description = "Il chierico ottiene una sottoclasse del chierico a sua scelta: Dominio della Guerra, Dominio dell'Inganno, Dominio della Luce o Dominio della Vita. Una sottoclasse è una specializzazione che conferisce privilegi a determinati livelli da chierico. Per il resto della sua carriera, il chierico ottiene ogni privilegio della sottoclasse di livello pari o inferiore al suo livello da chierico." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "You gain the Ability Score Improvement feat (see chapter 5) or another feat of your choice for which you qualify. You gain this feature again at Cleric levels 8, 12, and 16." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Il chierico ottiene il talento Aumento dei punteggi di caratteristica o un altro talento a sua scelta di cui soddisfa i prerequisiti. Ottiene di nuovo questo privilegio all'8°, al 12° e al 16° livello da chierico." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/sear-undead"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/sear-undead", "en"), Language = LanguageCode.En, Name = "Sear Undead", Description = "Whenever you use Turn Undead, you can roll a number of d8s equal to your Wisdom modifier (minimum of 1d8) and add the rolls together. Each Undead that fails its saving throw against that use of Turn Undead takes Radiant damage equal to the roll’s total. This damage doesn’t end the turn effect." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/sear-undead", "it"), Language = LanguageCode.It, Name = "Bruciare i Non Morti", Description = "Quando il chierico usa Scacciare non morti, può tirare tanti d8 quanto è il suo modificatore di Saggezza (almeno 1d8) e sommarli: i non morti che falliscono il tiro salvezza contro quell'effetto subiscono danni radiosi pari al totale ottenuto. I danni non interrompono l'effetto di Scacciare non morti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/blessed-strikes"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/blessed-strikes", "en"), Language = LanguageCode.En, Name = "Blessed Strikes", Description = "Divine power infuses you in battle. You gain one of the following options of your choice (if you get either option from a Cleric subclass in an older book, use only the option you choose for this feature).\n\n**Divine Strike.** Once on each of your turns when you hit a creature with an attack roll using a weapon, you can cause the target to take an extra 1d8 Necrotic or Radiant damage (your choice).\n\n**Potent Spellcasting.** Add your Wisdom modifier to the damage you deal with any Cleric cantrip." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/blessed-strikes", "it"), Language = LanguageCode.It, Name = "Colpi Benedetti", Description = "Il potere divino pervade il chierico in battaglia. Ottiene una delle opzioni seguenti, a sua scelta (se ottiene una delle due opzioni da una sottoclasse del chierico di un manuale precedente, usa soltanto l'opzione scelta per questo privilegio).\n\n**Colpo divino.** Una volta in ognuno dei suoi turni, quando colpisce una creatura con un tiro per colpire effettuato con un'arma, il chierico può infliggere al bersaglio 1d8 danni necrotici o radiosi extra (a sua scelta).\n\n**Incantesimi potenti.** Il chierico somma il suo modificatore di Saggezza ai danni che infligge con qualsiasi trucchetto da chierico." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/divine-intervention"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/divine-intervention", "en"), Language = LanguageCode.En, Name = "Divine Intervention", Description = "You can call on your deity or pantheon to intervene on your behalf. As a Magic action, choose any Cleric spell of level 5 or lower that doesn’t require a Reaction to cast. As part of the same action, you cast that spell without expending a spell slot or needing Material components. You can’t use this feature again until you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/divine-intervention", "it"), Language = LanguageCode.It, Name = "Intervento Divino", Description = "Il chierico può invocare il suo dio o il suo pantheon affinché intervenga in suo favore. Con un'azione di Magia, sceglie un qualsiasi incantesimo da chierico di 5° livello o inferiore che non richieda una reazione per essere lanciato e, come parte della stessa azione, lo lancia senza spendere uno slot incantesimo e senza bisogno di componenti materiali. Non può usare di nuovo questo privilegio finché non completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/improved-blessed-strikes"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/improved-blessed-strikes", "en"), Language = LanguageCode.En, Name = "Improved Blessed Strikes", Description = "The option you chose for Blessed Strikes grows more powerful.\n\n**Divine Strike.** The extra damage of your Divine Strike increases to 2d8.\n\n**Potent Spellcasting.** When you cast a Cleric cantrip and deal damage to a creature with it, you can give vitality to yourself or another creature within 60 feet of yourself, granting a number of Temporary Hit Points equal to twice your Wisdom modifier." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/improved-blessed-strikes", "it"), Language = LanguageCode.It, Name = "Colpi Benedetti Migliorati", Description = "L'opzione presa con Colpi benedetti si rafforza.\n\n**Colpo divino.** Il Colpo divino ora infligge 2d8 danni extra.\n\n**Incantesimi potenti.** Ogni volta che un trucchetto da chierico lanciato dal chierico danneggia una creatura, il chierico può conferire a se stesso o a un'altra creatura entro 18 metri punti ferita temporanei pari a due volte il suo modificatore di Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/epic-boon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 19,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/epic-boon", "en"), Language = LanguageCode.En, Name = "Epic Boon", Description = "You gain an Epic Boon feat (see chapter 5) or another feat of your choice for which you qualify. Boon of Fate is recommended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/epic-boon", "it"), Language = LanguageCode.It, Name = "Dono Epico", Description = "Il chierico ottiene un talento Dono epico o un altro talento a sua scelta di cui soddisfa i prerequisiti. È consigliato il Dono del fato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/greater-divine-intervention"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/greater-divine-intervention", "en"), Language = LanguageCode.En, Name = "Greater Divine Intervention", Description = "You can call on even more powerful divine intervention. When you use your Divine Intervention feature, you can choose Wish when you select a spell. If you do so, you can’t use Divine Intervention again until you finish 2d4 Long Rests." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "cleric/greater-divine-intervention", "it"), Language = LanguageCode.It, Name = "Intervento Divino Superiore", Description = "L'aiuto divino che il chierico può invocare si fa ancora più grande: con Intervento divino può ora scegliere anche l'incantesimo *desiderio*. Se lo fa, Intervento divino torna disponibile soltanto dopo che il chierico ha completato 2d4 riposi lunghi." }
					}
				}
			}
		};
	}
}
