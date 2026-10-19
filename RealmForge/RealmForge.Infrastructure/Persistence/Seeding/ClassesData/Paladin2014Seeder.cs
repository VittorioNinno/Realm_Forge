using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Paladin (2014 ruleset): class features of the SRD 5.1 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Paladin2014Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "paladin");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "paladin", "en"),
					Language = LanguageCode.En,
					Name = "Paladin",
					Description = "A holy warrior bound by a sacred oath. Paladins wear heavy armor, heal with a touch, smite foes with divine power and protect their allies with auras, drawing magic from the strength of their convictions.",
					SubclassTitle = "Sacred Oath",
					ArmorProficiencies = "All armor, shields",
					WeaponProficiencies = "Simple weapons, martial weapons",
					ToolProficiencies = "None",
					StartingEquipment = "- (a) a martial weapon and a shield or (b) two martial weapons\n- (a) five javelins or (b) any simple melee weapon\n- (a) a priest’s pack or (b) an explorer’s pack\n- Chain mail and a holy symbol",
					ProgressionTable = "The 1st–9th columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Features | 1st | 2nd | 3rd | 4th | 5th |\n|---|---|---|---|---|---|---|---|\n| 1st | +2 | Divine Sense, Lay on Hands | — | — | — | — | — |\n| 2nd | +2 | Fighting Style, Spellcasting, Divine Smite | 2 | — | — | — | — |\n| 3rd | +2 | Divine Health, Sacred Oath | 3 | — | — | — | — |\n| 4th | +2 | Ability Score Improvement | 3 | — | — | — | — |\n| 5th | +3 | Extra Attack | 4 | 2 | — | — | — |\n| 6th | +3 | Aura of Protection | 4 | 2 | — | — | — |\n| 7th | +3 | Sacred Oath feature | 4 | 3 | — | — | — |\n| 8th | +3 | Ability Score Improvement | 4 | 3 | — | — | — |\n| 9th | +4 | — | 4 | 3 | 2 | — | — |\n| 10th | +4 | Aura of Courage | 4 | 3 | 2 | — | — |\n| 11th | +4 | Improved Divine Smite | 4 | 3 | 3 | — | — |\n| 12th | +4 | Ability Score Improvement | 4 | 3 | 3 | — | — |\n| 13th | +5 | — | 4 | 3 | 3 | 1 | — |\n| 14th | +5 | Cleansing Touch | 4 | 3 | 3 | 1 | — |\n| 15th | +5 | Sacred Oath feature | 4 | 3 | 3 | 2 | — |\n| 16th | +5 | Ability Score Improvement | 4 | 3 | 3 | 2 | — |\n| 17th | +6 | — | 4 | 3 | 3 | 3 | 1 |\n| 18th | +6 | Aura improvements | 4 | 3 | 3 | 3 | 1 |\n| 19th | +6 | Ability Score Improvement | 4 | 3 | 3 | 3 | 2 |\n| 20th | +6 | Sacred Oath feature | 4 | 3 | 3 | 3 | 2 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "paladin", "it"),
					Language = LanguageCode.It,
					Name = "Paladino",
					Description = "Un guerriero santo vincolato da un giuramento sacro. Il paladino indossa armature pesanti, guarisce con un tocco, punisce i nemici con il potere divino e protegge gli alleati con le sue aure, traendo la propria magia dalla forza delle sue convinzioni.",
					SubclassTitle = "Giuramento Sacro",
					ArmorProficiencies = "Tutte le armature, scudi",
					WeaponProficiencies = "Armi semplici, armi da guerra",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "- (a) un'arma da guerra e uno scudo o (b) due armi da guerra\n- (a) cinque giavellotti o (b) una qualsiasi arma semplice da mischia\n- (a) una dotazione da sacerdote o (b) una dotazione da esploratore\n- Una cotta di maglia e un simbolo sacro",
					ProgressionTable = "Le colonne 1°–9° indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi | 1° | 2° | 3° | 4° | 5° |\n|---|---|---|---|---|---|---|---|\n| 1° | +2 | Percezione del Divino, Imposizione delle Mani | — | — | — | — | — |\n| 2° | +2 | Stile di Combattimento, Incantesimi, Punizione Divina | 2 | — | — | — | — |\n| 3° | +2 | Salute Divina, Giuramento Sacro | 3 | — | — | — | — |\n| 4° | +2 | Aumento dei Punteggi di Caratteristica | 3 | — | — | — | — |\n| 5° | +3 | Attacco Extra | 4 | 2 | — | — | — |\n| 6° | +3 | Aura di Protezione | 4 | 2 | — | — | — |\n| 7° | +3 | Privilegio del Giuramento Sacro | 4 | 3 | — | — | — |\n| 8° | +3 | Aumento dei Punteggi di Caratteristica | 4 | 3 | — | — | — |\n| 9° | +4 | — | 4 | 3 | 2 | — | — |\n| 10° | +4 | Aura di Coraggio | 4 | 3 | 2 | — | — |\n| 11° | +4 | Punizione Divina Migliorata | 4 | 3 | 3 | — | — |\n| 12° | +4 | Aumento dei Punteggi di Caratteristica | 4 | 3 | 3 | — | — |\n| 13° | +5 | — | 4 | 3 | 3 | 1 | — |\n| 14° | +5 | Tocco Purificante | 4 | 3 | 3 | 1 | — |\n| 15° | +5 | Privilegio del Giuramento Sacro | 4 | 3 | 3 | 2 | — |\n| 16° | +5 | Aumento dei Punteggi di Caratteristica | 4 | 3 | 3 | 2 | — |\n| 17° | +6 | — | 4 | 3 | 3 | 3 | 1 |\n| 18° | +6 | Aure migliorate | 4 | 3 | 3 | 3 | 1 |\n| 19° | +6 | Aumento dei Punteggi di Caratteristica | 4 | 3 | 3 | 3 | 2 |\n| 20° | +6 | Privilegio del Giuramento Sacro | 4 | 3 | 3 | 3 | 2 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/divine-sense"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/divine-sense", "en"), Language = LanguageCode.En, Name = "Divine Sense", Description = "The presence of strong evil registers on your senses like a noxious odor, and powerful good rings like heavenly music in your ears. As an action, you can open your awareness to detect such forces. Until the end of your next turn, you know the location of any celestial, fiend, or undead within 60 feet of you that is not behind total cover. You know the type (celestial, fiend, or undead) of any being whose presence you sense, but not its identity (the vampire Count Strahd von Zarovich, for instance). Within the same radius, you also detect the presence of any place or object that has been consecrated or desecrated, as with the *hallow* spell.\n\nYou can use this feature a number of times equal to 1 + your Charisma modifier. When you finish a long rest, you regain all expended uses." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/divine-sense", "it"), Language = LanguageCode.It, Name = "Percezione del Divino", Description = "La presenza di un male potente si manifesta ai sensi del paladino come un odore nauseabondo, mentre un bene potente risuona nelle sue orecchie come una musica celestiale. Come azione, il paladino può aprire la propria consapevolezza per individuare queste forze. Fino alla fine del suo turno successivo, conosce la posizione di qualsiasi celestiale, immondo o non morto entro 18 metri da lui che non si trovi dietro una copertura totale. Conosce il tipo (celestiale, immondo o non morto) di ogni essere di cui percepisce la presenza, ma non la sua identità (per esempio, il vampiro conte Strahd von Zarovich). Entro lo stesso raggio, individua anche la presenza di qualsiasi luogo od oggetto che sia stato consacrato o sconsacrato, come con l'incantesimo *santificare*.\n\nIl paladino può usare questo privilegio un numero di volte pari a 1 + il suo modificatore di Carisma. Quando completa un riposo lungo, recupera tutti gli utilizzi spesi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/lay-on-hands"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/lay-on-hands", "en"), Language = LanguageCode.En, Name = "Lay on Hands", Description = "Your blessed touch can heal wounds. You have a pool of healing power that replenishes when you take a long rest. With that pool, you can restore a total number of hit points equal to your paladin level × 5.\n\nAs an action, you can touch a creature and draw power from the pool to restore a number of hit points to that creature, up to the maximum amount remaining in your pool.\n\nAlternatively, you can expend 5 hit points from your pool of healing to cure the target of one disease or neutralize one poison affecting it. You can cure multiple diseases and neutralize multiple poisons with a single use of Lay on Hands, expending hit points separately for each one.\n\nThis feature has no effect on undead and constructs." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/lay-on-hands", "it"), Language = LanguageCode.It, Name = "Imposizione delle Mani", Description = "Il tocco benedetto del paladino può guarire le ferite. Il paladino dispone di una riserva di potere curativo che si ricarica quando effettua un riposo lungo. Con questa riserva può ripristinare un totale di punti ferita pari al suo livello da paladino × 5.\n\nCome azione, può toccare una creatura e attingere alla riserva per ripristinarle un certo numero di punti ferita, fino al massimo ancora disponibile nella riserva.\n\nIn alternativa, può spendere 5 punti ferita della sua riserva per curare il bersaglio da una malattia o neutralizzare un veleno che lo affligge. Con un singolo utilizzo di Imposizione delle Mani può curare più malattie e neutralizzare più veleni, spendendo i punti ferita separatamente per ciascuno.\n\nQuesto privilegio non ha effetto sui non morti e sui costrutti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/fighting-style"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/fighting-style", "en"), Language = LanguageCode.En, Name = "Fighting Style", Description = "You adopt a particular style of fighting as your specialty. Choose one of the following options. You can't take a Fighting Style option more than once, even if you later get to choose again.\n\n***Defense.*** While you are wearing armor, you gain a +1 bonus to AC.\n\n***Dueling.*** When you are wielding a melee weapon in one hand and no other weapons, you gain a +2 bonus to damage rolls with that weapon.\n\n***Great Weapon Fighting.*** When you roll a 1 or 2 on a damage die for an attack you make with a melee weapon that you are wielding with two hands, you can reroll the die and must use the new roll, even if the new roll is a 1 or a 2. The weapon must have the two-handed or versatile property for you to gain this benefit.\n\n***Protection.*** When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your reaction to impose disadvantage on the attack roll. You must be wielding a shield." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/fighting-style", "it"), Language = LanguageCode.It, Name = "Stile di Combattimento", Description = "Il paladino adotta come specialità un particolare stile di combattimento. Sceglie una delle opzioni seguenti. Non può scegliere più di una volta la stessa opzione di Stile di Combattimento, anche se in seguito ha la possibilità di sceglierne un'altra.\n\n***Difesa.*** Finché indossa un'armatura, il personaggio ottiene un bonus di +1 alla CA.\n\n***Duellare.*** Quando impugna un'arma da mischia in una mano e nessun'altra arma, il personaggio ottiene un bonus di +2 ai tiri per i danni effettuati con quell'arma.\n\n***Combattere con Armi Possenti.*** Quando ottiene 1 o 2 a un dado di danno per un attacco effettuato con un'arma da mischia impugnata a due mani, il personaggio può ripetere il tiro di quel dado e deve usare il nuovo risultato, anche se è di nuovo 1 o 2. Per ottenere questo beneficio, l'arma deve avere la proprietà a due mani o versatile.\n\n***Protezione.*** Quando una creatura che il personaggio è in grado di vedere attacca un bersaglio diverso da lui che si trova entro 1,5 metri da lui, il personaggio può usare la sua reazione per imporre svantaggio al tiro per colpire. Deve impugnare uno scudo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "By 2nd level, you have learned to draw on divine magic through meditation and prayer to cast spells as a cleric does.\n\n**Preparing and Casting Spells**\n\nThe Paladin table shows how many spell slots you have to cast your spells. To cast one of your paladin spells of 1st level or higher, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest.\n\nYou prepare the list of paladin spells that are available for you to cast, choosing from the paladin spell list. When you do so, choose a number of paladin spells equal to your Charisma modifier + half your paladin level, rounded down (minimum of one spell). The spells must be of a level for which you have spell slots.\n\nFor example, if you are a 5th-level paladin, you have four 1st-level and two 2nd-level spell slots. With a Charisma of 14, your list of prepared spells can include four spells of 1st or 2nd level, in any combination. If you prepare the 1st-level spell cure wounds, you can cast it using a 1st-level or a 2nd-level slot. Casting the spell doesn't remove it from your list of prepared spells.\n\nYou can change your list of prepared spells when you finish a long rest. Preparing a new list of paladin spells requires time spent in prayer and meditation: at least 1 minute per spell level for each spell on your list.\n\n**Spellcasting Ability**\n\nCharisma is your spellcasting ability for your paladin spells, since their power derives from the strength of your convictions. You use your Charisma whenever a spell refers to your spellcasting ability. In addition, you use your Charisma modifier when setting the saving throw DC for a paladin spell you cast and when making an attack roll with one.\n\n**Spell save DC** = 8 + your proficiency bonus + your Charisma modifier\n\n**Spell attack modifier** = your proficiency bonus + your Charisma modifier\n\n**Spellcasting Focus**\n\nYou can use a holy symbol as a spellcasting focus for your paladin spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Al 2° livello il paladino ha imparato ad attingere alla magia divina tramite la meditazione e la preghiera, per lanciare incantesimi come fa un chierico.\n\n**Preparare e lanciare incantesimi**\n\nLa tabella del Paladino indica quanti slot incantesimo possiede il paladino per lanciare i suoi incantesimi. Per lanciare uno dei suoi incantesimi da paladino di 1° livello o superiore deve spendere uno slot di livello pari o superiore a quello dell'incantesimo. Recupera tutti gli slot incantesimo spesi quando completa un riposo lungo.\n\nIl paladino prepara la lista degli incantesimi da paladino che può lanciare, scegliendoli dalla lista degli incantesimi del paladino. Quando lo fa, sceglie un numero di incantesimi da paladino pari al suo modificatore di Carisma + la metà del suo livello da paladino, arrotondata per difetto (minimo un incantesimo). Gli incantesimi devono essere di un livello per cui possiede slot incantesimo.\n\nPer esempio, un paladino di 5° livello ha quattro slot incantesimo di 1° livello e due di 2° livello. Con Carisma 14, la sua lista di incantesimi preparati può includere quattro incantesimi di 1° o di 2° livello, in qualsiasi combinazione. Se prepara l'incantesimo di 1° livello *cura ferite*, può lanciarlo usando uno slot di 1° o di 2° livello. Lanciare l'incantesimo non lo rimuove dalla lista degli incantesimi preparati.\n\nIl paladino può cambiare la sua lista di incantesimi preparati quando completa un riposo lungo. Preparare una nuova lista di incantesimi da paladino richiede tempo dedicato alla preghiera e alla meditazione: almeno 1 minuto per livello di incantesimo per ogni incantesimo della lista.\n\n**Caratteristica da incantatore**\n\nIl Carisma è la caratteristica da incantatore del paladino per i suoi incantesimi da paladino, dato che il loro potere deriva dalla forza delle sue convinzioni. Il paladino usa il Carisma ogni volta che un incantesimo fa riferimento alla sua caratteristica da incantatore. Usa inoltre il modificatore di Carisma per stabilire la CD dei tiri salvezza di un incantesimo da paladino che lancia e quando effettua un tiro per colpire con uno di essi.\n\n**CD del tiro salvezza degli incantesimi** = 8 + bonus di competenza + modificatore di Carisma\n\n**Modificatore di attacco degli incantesimi** = bonus di competenza + modificatore di Carisma\n\n**Focus da incantatore**\n\nIl paladino può usare un simbolo sacro come focus da incantatore per i suoi incantesimi da paladino." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/divine-smite"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/divine-smite", "en"), Language = LanguageCode.En, Name = "Divine Smite", Description = "Starting at 2nd level, when you hit a creature with a melee weapon attack, you can expend one spell slot to deal radiant damage to the target, in addition to the weapon's damage.\n\nThe extra damage is 2d8 for a 1st-level spell slot, plus 1d8 for each spell level higher than 1st, to a maximum of 5d8. The damage increases by 1d8 if the target is an undead or a fiend." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/divine-smite", "it"), Language = LanguageCode.It, Name = "Punizione Divina", Description = "A partire dal 2° livello, quando colpisce una creatura con un attacco con un'arma da mischia, il paladino può spendere uno slot incantesimo per infliggere danni radiosi al bersaglio, in aggiunta ai danni dell'arma.\n\nI danni extra sono 2d8 per uno slot incantesimo di 1° livello, più 1d8 per ogni livello dell'incantesimo superiore al 1°, fino a un massimo di 5d8. I danni aumentano di 1d8 se il bersaglio è un non morto o un immondo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/divine-health"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/divine-health", "en"), Language = LanguageCode.En, Name = "Divine Health", Description = "By 3rd level, the divine magic flowing through you makes you immune to disease." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/divine-health", "it"), Language = LanguageCode.It, Name = "Salute Divina", Description = "Al 3° livello la magia divina che scorre nel paladino lo rende immune alle malattie." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/sacred-oath"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/sacred-oath", "en"), Language = LanguageCode.En, Name = "Sacred Oath", Description = "When you reach 3rd level, you swear the oath that binds you as a paladin forever. Up to this time you have been in a preparatory stage, committed to the path but not yet sworn to it. Now you choose an oath, such as the Oath of Devotion.\n\nYour choice grants you features at 3rd level and again at 7th, 15th, and 20th level. Those features include oath spells and the Channel Divinity feature.\n\n**Oath Spells**\n\nEach oath has a list of associated spells. You gain access to these spells at the levels specified in the oath description. Once you gain access to an oath spell, you always have it prepared. Oath spells don't count against the number of spells you can prepare each day.\n\nIf you gain an oath spell that doesn't appear on the paladin spell list, the spell is nonetheless a paladin spell for you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/sacred-oath", "it"), Language = LanguageCode.It, Name = "Giuramento Sacro", Description = "Quando arriva al 3° livello, il paladino presta il giuramento che lo vincola per sempre come paladino. Fino a quel momento si trovava in una fase preparatoria, impegnato sul cammino ma non ancora vincolato da un giuramento. Ora sceglie un giuramento, come il Giuramento di Devozione.\n\nLa scelta gli conferisce privilegi al 3° livello e poi al 7°, al 15° e al 20° livello. Questi privilegi includono gli incantesimi di giuramento e il privilegio Incanalare Divinità.\n\n**Incantesimi di giuramento**\n\nOgni giuramento ha una lista di incantesimi associati. Il paladino ottiene l'accesso a questi incantesimi ai livelli indicati nella descrizione del giuramento. Una volta ottenuto l'accesso a un incantesimo di giuramento, lo considera sempre preparato. Gli incantesimi di giuramento non contano nel numero di incantesimi che può preparare ogni giorno.\n\nSe ottiene un incantesimo di giuramento che non compare nella lista degli incantesimi del paladino, per lui è comunque un incantesimo da paladino." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/channel-divinity"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/channel-divinity", "en"), Language = LanguageCode.En, Name = "Channel Divinity", Description = "Your oath allows you to channel divine energy to fuel magical effects. Each Channel Divinity option provided by your oath explains how to use it.\n\nWhen you use your Channel Divinity, you choose which option to use. You must then finish a short or long rest to use your Channel Divinity again.\n\nSome Channel Divinity effects require saving throws. When you use such an effect from this class, the DC equals your paladin spell save DC." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/channel-divinity", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità", Description = "Il giuramento del paladino gli permette di incanalare energia divina per alimentare effetti magici. Ogni opzione di Incanalare Divinità fornita dal suo giuramento spiega come usarla.\n\nQuando usa Incanalare Divinità, il paladino sceglie quale opzione usare. Deve poi completare un riposo breve o lungo per poter usare di nuovo Incanalare Divinità.\n\nAlcuni effetti di Incanalare Divinità richiedono tiri salvezza. Quando il paladino usa un effetto di questo tipo concesso da questa classe, la CD è pari alla CD del tiro salvezza dei suoi incantesimi da paladino." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Quando arriva al 4° livello, e poi all'8°, al 12°, al 16° e al 19° livello, il personaggio può aumentare di 2 un punteggio di caratteristica a sua scelta, oppure aumentare di 1 due punteggi di caratteristica a sua scelta. Come di consueto, questo privilegio non consente di aumentare un punteggio di caratteristica oltre 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 5,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "You can attack twice, instead of once, whenever you take the Attack action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Il paladino può attaccare due volte, anziché una, ogni volta che effettua l'azione di Attacco nel proprio turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/aura-of-protection"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/aura-of-protection", "en"), Language = LanguageCode.En, Name = "Aura of Protection", Description = "Starting at 6th level, whenever you or a friendly creature within 10 feet of you must make a saving throw, the creature gains a bonus to the saving throw equal to your Charisma modifier (with a minimum bonus of +1). You must be conscious to grant this bonus.\n\n At 18th level, the range of this aura increases to 30 feet." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/aura-of-protection", "it"), Language = LanguageCode.It, Name = "Aura di Protezione", Description = "A partire dal 6° livello, ogni volta che il paladino o una creatura amica entro 3 metri da lui deve effettuare un tiro salvezza, la creatura ottiene un bonus al tiro salvezza pari al modificatore di Carisma del paladino (con un bonus minimo di +1). Il paladino deve essere cosciente per conferire questo bonus.\n\nAl 18° livello il raggio di questa aura aumenta a 9 metri." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/aura-of-courage"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/aura-of-courage", "en"), Language = LanguageCode.En, Name = "Aura of Courage", Description = "Starting at 10th level, you and friendly creatures within 10 feet of you can't be frightened while you are conscious.\n\nAt 18th level, the range of this aura increases to 30 feet." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/aura-of-courage", "it"), Language = LanguageCode.It, Name = "Aura di Coraggio", Description = "A partire dal 10° livello, il paladino e le creature amiche entro 3 metri da lui non possono essere spaventati finché il paladino è cosciente.\n\nAl 18° livello il raggio di questa aura aumenta a 9 metri." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/improved-divine-smite"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 11,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/improved-divine-smite", "en"), Language = LanguageCode.En, Name = "Improved Divine Smite", Description = "By 11th level, you are so suffused with righteous might that all your melee weapon strikes carry divine power with them.\n\nWhenever you hit a creature with a melee weapon, the creature takes an extra 1d8 radiant damage. If you also use your Divine Smite with an attack, you add this damage to the extra damage of your Divine Smite." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/improved-divine-smite", "it"), Language = LanguageCode.It, Name = "Punizione Divina Migliorata", Description = "All'11° livello il paladino è così pervaso di potenza virtuosa che tutti i suoi colpi con armi da mischia portano con sé il potere divino.\n\nOgni volta che colpisce una creatura con un'arma da mischia, la creatura subisce 1d8 danni radiosi extra. Se il paladino usa anche Punizione Divina con un attacco, aggiunge questi danni ai danni extra di Punizione Divina." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/cleansing-touch"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 13,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/cleansing-touch", "en"), Language = LanguageCode.En, Name = "Cleansing Touch", Description = "Beginning at 14th level, you can use your action to end one spell on yourself or on one willing creature that you touch.\n\nYou can use this feature a number of times equal to your Charisma modifier (a minimum of once). You regain expended uses when you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "paladin/cleansing-touch", "it"), Language = LanguageCode.It, Name = "Tocco Purificante", Description = "A partire dal 14° livello, il paladino può usare la sua azione per porre fine a un incantesimo su se stesso o su una creatura consenziente che tocca.\n\nPuò usare questo privilegio un numero di volte pari al suo modificatore di Carisma (minimo una volta). Recupera gli utilizzi spesi quando completa un riposo lungo." }
					}
				}
			}
		};
	}
}
