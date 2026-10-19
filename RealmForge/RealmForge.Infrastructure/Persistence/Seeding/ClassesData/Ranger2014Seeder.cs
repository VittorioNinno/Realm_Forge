using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Ranger (2014 ruleset): class features of the SRD 5.1 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Ranger2014Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "ranger");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			HitDie = 10,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Wisdom },
			SavingThrows = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity },
			SkillChoiceCount = 3,
			SkillOptions = new List<Skill> { Skill.AnimalHandling, Skill.Athletics, Skill.Insight, Skill.Investigation, Skill.Nature, Skill.Perception, Skill.Stealth, Skill.Survival },
			CasterProgression = CasterProgression.Half,
			SpellcastingAbility = AbilityScore.Wisdom,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "ranger", "en"),
					Language = LanguageCode.En,
					Name = "Ranger",
					Description = "A hunter and tracker of the wild frontiers. Rangers know their favored terrain and quarry better than anyone, fight with bow or blade and use a little nature magic to stalk and outwit the threats that lurk beyond civilization.",
					SubclassTitle = "Ranger Archetype",
					ArmorProficiencies = "Light armor, medium armor, shields",
					WeaponProficiencies = "Simple weapons, martial weapons",
					ToolProficiencies = "None",
					StartingEquipment = "- (a) scale mail or (b) leather armor\n- (a) two shortswords or (b) two simple melee weapons\n- (a) a dungeoneer’s pack or (b) an explorer’s pack\n- A longbow and a quiver of 20 arrows",
					ProgressionTable = "The 1st–9th columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Features | Spells Known | 1st | 2nd | 3rd | 4th | 5th |\n|---|---|---|---|---|---|---|---|---|\n| 1st | +2 | Favored Enemy, Natural Explorer | — | — | — | — | — | — |\n| 2nd | +2 | Fighting Style, Spellcasting | 2 | 2 | — | — | — | — |\n| 3rd | +2 | Ranger Archetype, Primeval Awareness | 3 | 3 | — | — | — | — |\n| 4th | +2 | Ability Score Improvement | 3 | 3 | — | — | — | — |\n| 5th | +3 | Extra Attack | 4 | 4 | 2 | — | — | — |\n| 6th | +3 | Favored Enemy and Natural Explorer improvements | 4 | 4 | 2 | — | — | — |\n| 7th | +3 | Ranger Archetype feature | 5 | 4 | 3 | — | — | — |\n| 8th | +3 | Ability Score Improvement, Land's Stride | 5 | 4 | 3 | — | — | — |\n| 9th | +4 | — | 6 | 4 | 3 | 2 | — | — |\n| 10th | +4 | Natural Explorer improvement, Hide in Plain Sight | 6 | 4 | 3 | 2 | — | — |\n| 11th | +4 | Ranger Archetype feature | 7 | 4 | 3 | 3 | — | — |\n| 12th | +4 | Ability Score Improvement | 7 | 4 | 3 | 3 | — | — |\n| 13th | +5 | — | 8 | 4 | 3 | 3 | 1 | — |\n| 14th | +5 | Favored Enemy improvement, Vanish | 8 | 4 | 3 | 3 | 1 | — |\n| 15th | +5 | Ranger Archetype feature | 9 | 4 | 3 | 3 | 2 | — |\n| 16th | +5 | Ability Score Improvement | 9 | 4 | 3 | 3 | 2 | — |\n| 17th | +6 | — | 10 | 4 | 3 | 3 | 3 | 1 |\n| 18th | +6 | Feral Senses | 10 | 4 | 3 | 3 | 3 | 1 |\n| 19th | +6 | Ability Score Improvement | 11 | 4 | 3 | 3 | 3 | 2 |\n| 20th | +6 | Foe Slayer | 11 | 4 | 3 | 3 | 3 | 2 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "ranger", "it"),
					Language = LanguageCode.It,
					Name = "Ranger",
					Description = "Un cacciatore e un segugio delle frontiere selvagge. Il ranger conosce il suo terreno prescelto e le sue prede meglio di chiunque altro, combatte con l'arco o con la lama e usa un po' di magia della natura per braccare e ingannare le minacce che si annidano oltre i confini della civiltà.",
					SubclassTitle = "Archetipo Ranger",
					ArmorProficiencies = "Armature leggere, armature medie, scudi",
					WeaponProficiencies = "Armi semplici, armi da guerra",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "- (a) una corazza di scaglie o (b) un'armatura di cuoio\n- (a) due spade corte o (b) due armi semplici da mischia\n- (a) una dotazione da avventuriero o (b) una dotazione da esploratore\n- Un arco lungo e una faretra con 20 frecce",
					ProgressionTable = "Le colonne 1°–9° indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi | Incantesimi conosciuti | 1° | 2° | 3° | 4° | 5° |\n|---|---|---|---|---|---|---|---|---|\n| 1° | +2 | Nemico Prescelto, Esploratore Nato | — | — | — | — | — | — |\n| 2° | +2 | Stile di Combattimento, Incantesimi | 2 | 2 | — | — | — | — |\n| 3° | +2 | Archetipo Ranger, Consapevolezza Primordiale | 3 | 3 | — | — | — | — |\n| 4° | +2 | Aumento dei Punteggi di Caratteristica | 3 | 3 | — | — | — | — |\n| 5° | +3 | Attacco Extra | 4 | 4 | 2 | — | — | — |\n| 6° | +3 | Nemico Prescelto ed Esploratore Nato migliorati | 4 | 4 | 2 | — | — | — |\n| 7° | +3 | Privilegio dell'Archetipo Ranger | 5 | 4 | 3 | — | — | — |\n| 8° | +3 | Aumento dei Punteggi di Caratteristica, Andatura sul Territorio | 5 | 4 | 3 | — | — | — |\n| 9° | +4 | — | 6 | 4 | 3 | 2 | — | — |\n| 10° | +4 | Esploratore Nato migliorato, Nascondersi in Piena Vista | 6 | 4 | 3 | 2 | — | — |\n| 11° | +4 | Privilegio dell'Archetipo Ranger | 7 | 4 | 3 | 3 | — | — |\n| 12° | +4 | Aumento dei Punteggi di Caratteristica | 7 | 4 | 3 | 3 | — | — |\n| 13° | +5 | — | 8 | 4 | 3 | 3 | 1 | — |\n| 14° | +5 | Nemico Prescelto migliorato, Svanire | 8 | 4 | 3 | 3 | 1 | — |\n| 15° | +5 | Privilegio dell'Archetipo Ranger | 9 | 4 | 3 | 3 | 2 | — |\n| 16° | +5 | Aumento dei Punteggi di Caratteristica | 9 | 4 | 3 | 3 | 2 | — |\n| 17° | +6 | — | 10 | 4 | 3 | 3 | 3 | 1 |\n| 18° | +6 | Sensi Ferini | 10 | 4 | 3 | 3 | 3 | 1 |\n| 19° | +6 | Aumento dei Punteggi di Caratteristica | 11 | 4 | 3 | 3 | 3 | 2 |\n| 20° | +6 | Sterminatore di Nemici | 11 | 4 | 3 | 3 | 3 | 2 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/favored-enemy"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/favored-enemy", "en"), Language = LanguageCode.En, Name = "Favored Enemy", Description = "Beginning at 1st level, you have significant experience studying, tracking, hunting, and even talking to a certain type of enemy.\n\nChoose a type of favored enemy: aberrations, beasts, celestials, constructs, dragons, elementals, fey, fiends, giants, monstrosities, oozes, plants, or undead. Alternatively, you can select two races of humanoid (such as gnolls and orcs) as favored enemies.\n\nYou have advantage on Wisdom (Survival) checks to track your favored enemies, as well as on Intelligence checks to recall information about them.\n\nWhen you gain this feature, you also learn one language of your choice that is spoken by your favored enemies, if they speak one at all.\n\nYou choose one additional favored enemy, as well as an associated language, at 6th and 14th level. As you gain levels, your choices should reflect the types of monsters you have encountered on your adventures." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/favored-enemy", "it"), Language = LanguageCode.It, Name = "Nemico Prescelto", Description = "A partire dal 1° livello, il ranger ha una notevole esperienza nello studiare, seguire, cacciare e persino parlare con un certo tipo di nemico.\n\nSceglie un tipo di nemico prescelto: aberrazioni, bestie, celestiali, costrutti, draghi, elementali, folletti, immondi, giganti, mostruosità, melme, vegetali o non morti. In alternativa, può scegliere come nemici prescelti due razze di umanoidi (come gnoll e orchi).\n\nIl ranger dispone di vantaggio alle prove di Saggezza (Sopravvivenza) per seguire le tracce dei suoi nemici prescelti, oltre che alle prove di Intelligenza per ricordare informazioni su di essi.\n\nQuando ottiene questo privilegio, il ranger impara anche un linguaggio a sua scelta parlato dai suoi nemici prescelti, se ne parlano uno.\n\nIl ranger sceglie un nemico prescelto aggiuntivo, insieme a un linguaggio associato, al 6° e al 14° livello. Man mano che sale di livello, le sue scelte dovrebbero riflettere i tipi di mostri che ha incontrato nelle sue avventure." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/natural-explorer"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/natural-explorer", "en"), Language = LanguageCode.En, Name = "Natural Explorer", Description = "You are particularly familiar with one type of natural environment and are adept at traveling and surviving in such regions. Choose one type of favored terrain: arctic, coast, desert, forest, grassland, mountain, or swamp. When you make an Intelligence or Wisdom check related to your favored terrain, your proficiency bonus is doubled if you are using a skill that you're proficient in.\n\nWhile traveling for an hour or more in your favored terrain, you gain the following benefits:\n- Difficult terrain doesn't slow your group's travel.\n- Your group can't become lost except by magical means.\n- Even when you are engaged in another activity while traveling (such as foraging, navigating, or tracking), you remain alert to danger.\n- If you are traveling alone, you can move stealthily at a normal pace.\n- When you forage, you find twice as much food as you normally would.\n- While tracking other creatures, you also learn their exact number, their sizes, and how long ago they passed through the area.\n\nYou choose additional favored terrain types at 6th and 10th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/natural-explorer", "it"), Language = LanguageCode.It, Name = "Esploratore Nato", Description = "Il ranger ha una particolare familiarità con un tipo di ambiente naturale ed è esperto nel viaggiare e sopravvivere in quelle regioni. Sceglie un tipo di terreno prescelto: artico, costa, deserto, foresta, prateria, montagna o palude. Quando effettua una prova di Intelligenza o di Saggezza legata al suo terreno prescelto, il suo bonus di competenza raddoppia se usa un'abilità in cui ha competenza.\n\nQuando viaggia per un'ora o più nel suo terreno prescelto, ottiene i benefici seguenti:\n- Il terreno difficile non rallenta il viaggio del suo gruppo.\n- Il suo gruppo non può perdersi, se non per mezzi magici.\n- Anche quando durante il viaggio è impegnato in un'altra attività (come cercare cibo, orientarsi o seguire tracce), resta all'erta contro il pericolo.\n- Se viaggia da solo, può muoversi furtivamente a passo normale.\n- Quando cerca cibo, ne trova il doppio del normale.\n- Quando segue le tracce di altre creature, ne scopre anche il numero esatto, la taglia e da quanto tempo sono passate nella zona.\n\nIl ranger sceglie altri tipi di terreno prescelto al 6° e al 10° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/fighting-style"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/fighting-style", "en"), Language = LanguageCode.En, Name = "Fighting Style", Description = "You adopt a particular style of fighting as your specialty. Choose one of the following options. You can't take a Fighting Style option more than once, even if you later get to choose again.\n\n***Archery.*** You gain a +2 bonus to attack rolls you make with ranged weapons.\n\n***Defense.*** While you are wearing armor, you gain a +1 bonus to AC.\n\n***Dueling.*** When you are wielding a melee weapon in one hand and no other weapons, you gain a +2 bonus to damage rolls with that weapon.\n\n***Two-Weapon Fighting.*** When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second attack." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/fighting-style", "it"), Language = LanguageCode.It, Name = "Stile di Combattimento", Description = "Il ranger adotta come specialità un particolare stile di combattimento. Sceglie una delle opzioni seguenti. Non può scegliere più di una volta la stessa opzione di Stile di Combattimento, anche se in seguito ha la possibilità di sceglierne un'altra.\n\n***Tiro.*** Il personaggio ottiene un bonus di +2 ai tiri per colpire effettuati con le armi a distanza.\n\n***Difesa.*** Finché indossa un'armatura, il personaggio ottiene un bonus di +1 alla CA.\n\n***Duellare.*** Quando impugna un'arma da mischia in una mano e nessun'altra arma, il personaggio ottiene un bonus di +2 ai tiri per i danni effettuati con quell'arma.\n\n***Combattere con Due Armi.*** Quando combatte con due armi, il personaggio può aggiungere il suo modificatore di caratteristica ai danni del secondo attacco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "By the time you reach 2nd level, you have learned to use the magical essence of nature to cast spells, much as a druid does.\n\n**Spell Slots**\n\nThe Ranger table shows how many spell slots you have to cast your spells of 1st level and higher. To cast one of these spells, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest.\n\nFor example, if you know the 1st-level spell *animal friendship* and have a 1st-level and a 2nd-level spell slot available, you can cast *animal friendship* using either slot.\n\n**Spells Known of 1st Level and Higher**\n\nYou know two 1st-level spells of your choice from the ranger spell list.\n\nThe Spells Known column of the Ranger table shows when you learn more ranger spells of your choice. Each of these spells must be of a level for which you have spell slots. For instance, when you reach 5th level in this class, you can learn one new spell of 1st or 2nd level.\n\nAdditionally, when you gain a level in this class, you can choose one of the ranger spells you know and replace it with another spell from the ranger spell list, which also must be of a level for which you have spell slots.\n\n**Spellcasting Ability**\n\nWisdom is your spellcasting ability for your ranger spells, since your magic draws on your attunement to nature. You use your Wisdom whenever a spell refers to your spellcasting ability. In addition, you use your Wisdom modifier when setting the saving throw DC for a ranger spell you cast and when making an attack roll with one.\n\n**Spell save DC** = 8 + your proficiency bonus + your Wisdom modifier\n\n**Spell attack modifier** = your proficiency bonus + your Wisdom modifier" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Quando arriva al 2° livello, il ranger ha imparato a usare l'essenza magica della natura per lanciare incantesimi, in modo simile a un druido.\n\n**Slot incantesimo**\n\nLa tabella del Ranger indica quanti slot incantesimo possiede il ranger per lanciare i suoi incantesimi di 1° livello e superiore. Per lanciare uno di questi incantesimi deve spendere uno slot di livello pari o superiore a quello dell'incantesimo. Recupera tutti gli slot incantesimo spesi quando completa un riposo lungo.\n\nPer esempio, se conosce l'incantesimo di 1° livello *amicizia con gli animali* e ha a disposizione uno slot di 1° livello e uno di 2° livello, può lanciare *amicizia con gli animali* usando uno qualsiasi dei due slot.\n\n**Incantesimi conosciuti di 1° livello e superiore**\n\nIl ranger conosce due incantesimi di 1° livello a sua scelta dalla lista degli incantesimi del ranger.\n\nLa colonna \"Incantesimi conosciuti\" della tabella del Ranger indica quando apprende altri incantesimi da ranger a sua scelta. Ognuno di questi incantesimi deve essere di un livello per cui possiede slot incantesimo. Per esempio, quando arriva al 5° livello in questa classe, può apprendere un nuovo incantesimo di 1° o di 2° livello.\n\nInoltre, quando ottiene un livello in questa classe, può scegliere uno degli incantesimi da ranger che conosce e sostituirlo con un altro incantesimo della lista del ranger, che deve anch'esso essere di un livello per cui possiede slot incantesimo.\n\n**Caratteristica da incantatore**\n\nLa Saggezza è la caratteristica da incantatore del ranger per i suoi incantesimi da ranger, dato che la sua magia deriva dalla sintonia con la natura. Il ranger usa la Saggezza ogni volta che un incantesimo fa riferimento alla sua caratteristica da incantatore. Usa inoltre il modificatore di Saggezza per stabilire la CD dei tiri salvezza di un incantesimo da ranger che lancia e quando effettua un tiro per colpire con uno di essi.\n\n**CD del tiro salvezza degli incantesimi** = 8 + bonus di competenza + modificatore di Saggezza\n\n**Modificatore di attacco degli incantesimi** = bonus di competenza + modificatore di Saggezza" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/ranger-archetype"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/ranger-archetype", "en"), Language = LanguageCode.En, Name = "Ranger Archetype", Description = "At 3rd level, you choose an archetype that you strive to emulate, such as the Hunter. Your choice grants you features at 3rd level and again at 7th, 11th, and 15th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/ranger-archetype", "it"), Language = LanguageCode.It, Name = "Archetipo Ranger", Description = "Al 3° livello il ranger sceglie un archetipo da emulare, come il Cacciatore. La scelta gli conferisce privilegi al 3° livello e poi al 7°, all'11° e al 15° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/primeval-awareness"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/primeval-awareness", "en"), Language = LanguageCode.En, Name = "Primeval Awareness", Description = "Beginning at 3rd level, you can use your action and expend one ranger spell slot to focus your awareness on the region around you. For 1 minute per level of the spell slot you expend, you can sense whether the following types of creatures are present within 1 mile of you (or within up to 6 miles if you are in your favored terrain): aberrations, celestials, dragons, elementals, fey, fiends, and undead. This feature doesn't reveal the creatures' location or number." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/primeval-awareness", "it"), Language = LanguageCode.It, Name = "Consapevolezza Primordiale", Description = "A partire dal 3° livello, il ranger può usare la sua azione e spendere uno slot incantesimo da ranger per concentrare la propria percezione sulla regione circostante. Per 1 minuto per livello dello slot speso, percepisce se entro 1,5 km da lui (o entro 9 km se si trova nel suo terreno prescelto) sono presenti creature dei tipi seguenti: aberrazioni, celestiali, draghi, elementali, folletti, immondi e non morti. Questo privilegio non rivela la posizione né il numero delle creature." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Quando arriva al 4° livello, e poi all'8°, al 12°, al 16° e al 19° livello, il personaggio può aumentare di 2 un punteggio di caratteristica a sua scelta, oppure aumentare di 1 due punteggi di caratteristica a sua scelta. Come di consueto, questo privilegio non consente di aumentare un punteggio di caratteristica oltre 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 5,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "You can attack twice, instead of once, whenever you take the Attack action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Il ranger può attaccare due volte, anziché una, ogni volta che effettua l'azione di Attacco nel proprio turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/land-s-stride"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 8,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/land-s-stride", "en"), Language = LanguageCode.En, Name = "Land's Stride", Description = "Starting at 8th level, moving through nonmagical difficult terrain costs you no extra movement. You can also pass through nonmagical plants without being slowed by them and without taking damage from them if they have thorns, spines, or a similar hazard.\n\nIn addition, you have advantage on saving throws against plants that are magically created or manipulated to impede movement, such as those created by the *entangle* spell." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/land-s-stride", "it"), Language = LanguageCode.It, Name = "Andatura sul Territorio", Description = "A partire dall'8° livello, attraversare terreno difficile non magico non costa al ranger movimento extra. Può inoltre attraversare la vegetazione non magica senza esserne rallentato e senza subire danni se presenta spine, aculei o pericoli simili.\n\nInoltre dispone di vantaggio ai tiri salvezza contro le piante create o manipolate magicamente per ostacolare il movimento, come quelle create dall'incantesimo *intralciare*." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/hide-in-plain-sight"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/hide-in-plain-sight", "en"), Language = LanguageCode.En, Name = "Hide in Plain Sight", Description = "Starting at 10th level, you can spend 1 minute creating camouflage for yourself. You must have access to fresh mud, dirt, plants, soot, and other naturally occurring materials with which to create your camouflage.\n\nOnce you are camouflaged in this way, you can try to hide by pressing yourself up against a solid surface, such as a tree or wall, that is at least as tall and wide as you are. You gain a +10 bonus to Dexterity (Stealth) checks as long as you remain there without moving or taking actions. Once you move or take an action or a reaction, you must camouflage yourself again to gain this benefit." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/hide-in-plain-sight", "it"), Language = LanguageCode.It, Name = "Nascondersi in Piena Vista", Description = "A partire dal 10° livello, il ranger può impiegare 1 minuto per mimetizzarsi. Deve avere a disposizione fango fresco, terra, piante, fuliggine e altri materiali naturali con cui creare il suo camuffamento.\n\nUna volta mimetizzato in questo modo, può tentare di nascondersi premendosi contro una superficie solida, come un albero o un muro, alta e larga almeno quanto lui. Ottiene un bonus di +10 alle prove di Destrezza (Furtività) finché resta lì senza muoversi né compiere azioni. Una volta che si muove o compie un'azione o una reazione, deve mimetizzarsi di nuovo per ottenere questo beneficio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/vanish"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/vanish", "en"), Language = LanguageCode.En, Name = "Vanish", Description = "Starting at 14th level, you can use the Hide action as a bonus action on your turn. Also, you can't be tracked by nonmagical means, unless you choose to leave a trail." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/vanish", "it"), Language = LanguageCode.It, Name = "Svanire", Description = "A partire dal 14° livello, il ranger può effettuare l'azione di Nascondersi come azione bonus nel proprio turno. Inoltre non può essere seguito con mezzi non magici, a meno che non scelga di lasciare tracce." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/feral-senses"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 18,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/feral-senses", "en"), Language = LanguageCode.En, Name = "Feral Senses", Description = "At 18th level, you gain preternatural senses that help you fight creatures you can't see. When you attack a creature you can't see, your inability to see it doesn't impose disadvantage on your attack rolls against it.\n\nYou are also aware of the location of any invisible creature within 30 feet of you, provided that the creature isn't hidden from you and you aren't blinded or deafened." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/feral-senses", "it"), Language = LanguageCode.It, Name = "Sensi Ferini", Description = "Al 18° livello il ranger ottiene sensi sovrannaturali che lo aiutano a combattere le creature che non è in grado di vedere. Quando attacca una creatura che non è in grado di vedere, questa incapacità non gli impone svantaggio ai tiri per colpire contro di essa.\n\nInoltre è consapevole della posizione di qualsiasi creatura invisibile entro 9 metri da lui, a patto che la creatura non si stia nascondendo da lui e che lui non sia accecato o assordato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/foe-slayer"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 20,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/foe-slayer", "en"), Language = LanguageCode.En, Name = "Foe Slayer", Description = "At 20th level, you become an unparalleled hunter of your enemies. Once on each of your turns, you can add your Wisdom modifier to the attack roll or the damage roll of an attack you make against one of your favored enemies. You can choose to use this feature before or after the roll, but before any effects of the roll are applied." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "ranger/foe-slayer", "it"), Language = LanguageCode.It, Name = "Sterminatore di Nemici", Description = "Al 20° livello il ranger diventa un cacciatore impareggiabile dei suoi nemici. Una volta in ognuno dei suoi turni, può aggiungere il suo modificatore di Saggezza al tiro per colpire o al tiro per i danni di un attacco che effettua contro uno dei suoi nemici prescelti. Può decidere di usare questo privilegio prima o dopo il tiro, ma prima che se ne applichino gli effetti." }
					}
				}
			}
		};
	}
}
