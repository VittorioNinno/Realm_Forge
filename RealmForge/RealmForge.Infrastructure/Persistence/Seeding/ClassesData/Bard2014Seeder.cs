using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Bard (2014 ruleset): class features of the SRD 5.1 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Bard2014Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "bard");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			HitDie = 8,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Charisma },
			SavingThrows = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Charisma },
			SkillChoiceCount = 3,
			SkillOptions = new List<Skill>(),
			CasterProgression = CasterProgression.Full,
			SpellcastingAbility = AbilityScore.Charisma,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "bard", "en"),
					Language = LanguageCode.En,
					Name = "Bard",
					Description = "A performer whose words and music carry real magic. Bards inspire allies, unsettle foes and pick up knowledge and spells from every tradition they meet, which makes them versatile helpers in and out of combat.",
					SubclassTitle = "Bard College",
					ArmorProficiencies = "Light armor",
					WeaponProficiencies = "Simple weapons, hand crossbows, longswords, rapiers, shortswords",
					ToolProficiencies = "Three musical instruments of your choice",
					StartingEquipment = "- (a) a rapier, (b) a longsword, or (c) any simple weapon\n- (a) a diplomat’s pack or (b) an entertainer’s pack\n- (a) a lute or (b) any other musical instrument\n- Leather armor and a dagger",
					ProgressionTable = "The 1st–9th columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Features | Cantrips Known | Spells Known | 1st | 2nd | 3rd | 4th | 5th | 6th | 7th | 8th | 9th |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1st | +2 | Spellcasting, Bardic Inspiration (d6) | 2 | 4 | 2 | — | — | — | — | — | — | — | — |\n| 2nd | +2 | Jack of All Trades, Song of Rest (d6) | 2 | 5 | 3 | — | — | — | — | — | — | — | — |\n| 3rd | +2 | Bard College, Expertise | 2 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4th | +2 | Ability Score Improvement | 3 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5th | +3 | Bardic Inspiration (d8), Font of Inspiration | 3 | 8 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6th | +3 | Countercharm, Bard College feature | 3 | 9 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7th | +3 | — | 3 | 10 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8th | +3 | Ability Score Improvement | 3 | 11 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9th | +4 | Song of Rest (d8) | 3 | 12 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10th | +4 | Bardic Inspiration (d10), Expertise, Magical Secrets | 4 | 14 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11th | +4 | — | 4 | 15 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12th | +4 | Ability Score Improvement | 4 | 15 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13th | +5 | Song of Rest (d10) | 4 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14th | +5 | Magical Secrets, Bard College feature | 4 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15th | +5 | Bardic Inspiration (d12) | 4 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16th | +5 | Ability Score Improvement | 4 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17th | +6 | Song of Rest (d12) | 4 | 20 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18th | +6 | Magical Secrets | 4 | 22 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19th | +6 | Ability Score Improvement | 4 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20th | +6 | Superior Inspiration | 4 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "bard", "it"),
					Language = LanguageCode.It,
					Name = "Bardo",
					Description = "Un artista le cui parole e la cui musica racchiudono una magia autentica. Il bardo ispira gli alleati, turba i nemici e raccoglie conoscenze e incantesimi da ogni tradizione che incontra, il che lo rende un aiuto versatile dentro e fuori dal combattimento.",
					SubclassTitle = "Collegio Bardico",
					ArmorProficiencies = "Armature leggere",
					WeaponProficiencies = "Armi semplici, balestre a mano, spade corte, spade lunghe, stocchi",
					ToolProficiencies = "Tre strumenti musicali a scelta",
					StartingEquipment = "- (a) uno stocco, (b) una spada lunga o (c) una qualsiasi arma semplice\n- (a) una dotazione da diplomatico o (b) una dotazione da intrattenitore\n- (a) un liuto o (b) un qualsiasi altro strumento musicale\n- Un'armatura di cuoio e un pugnale",
					ProgressionTable = "Le colonne 1°–9° indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi | Trucchetti conosciuti | Incantesimi conosciuti | 1° | 2° | 3° | 4° | 5° | 6° | 7° | 8° | 9° |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1° | +2 | Incantesimi, Ispirazione Bardica (d6) | 2 | 4 | 2 | — | — | — | — | — | — | — | — |\n| 2° | +2 | Factotum, Canto di Riposo (d6) | 2 | 5 | 3 | — | — | — | — | — | — | — | — |\n| 3° | +2 | Collegio Bardico, Maestria | 2 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4° | +2 | Aumento dei Punteggi di Caratteristica | 3 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5° | +3 | Ispirazione Bardica (d8), Fonte di Ispirazione | 3 | 8 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6° | +3 | Controfascino, Privilegio del Collegio Bardico | 3 | 9 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7° | +3 | — | 3 | 10 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8° | +3 | Aumento dei Punteggi di Caratteristica | 3 | 11 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9° | +4 | Canto di Riposo (d8) | 3 | 12 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10° | +4 | Ispirazione Bardica (d10), Maestria, Segreti Magici | 4 | 14 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11° | +4 | — | 4 | 15 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12° | +4 | Aumento dei Punteggi di Caratteristica | 4 | 15 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13° | +5 | Canto di Riposo (d10) | 4 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14° | +5 | Segreti Magici, Privilegio del Collegio Bardico | 4 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15° | +5 | Ispirazione Bardica (d12) | 4 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16° | +5 | Aumento dei Punteggi di Caratteristica | 4 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17° | +6 | Canto di Riposo (d12) | 4 | 20 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18° | +6 | Segreti Magici | 4 | 22 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19° | +6 | Aumento dei Punteggi di Caratteristica | 4 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20° | +6 | Ispirazione Superiore | 4 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "You have learned to untangle and reshape the fabric of reality in harmony with your wishes and music. Your spells are part of your vast repertoire, magic that you can tune to different situations.\n\n**Cantrips**\n\nYou know two cantrips of your choice from the bard spell list. You learn additional bard cantrips of your choice at higher levels, as shown in the Cantrips Known column of the Bard table.\n\n**Spell Slots**\n\nThe Bard table shows how many spell slots you have to cast your spells of 1st level and higher. To cast one of these spells, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest.\n\nFor example, if you know the 1st-level spell cure wounds and have a 1st-level and a 2nd-level spell slot available, you can cast cure wounds using either slot.\n\n**Spells Known of 1st Level and Higher**\n\nYou know four 1st-level spells of your choice from the bard spell list.\n\nThe Spells Known column of the Bard table shows when you learn more bard spells of your choice. Each of these spells must be of a level for which you have spell slots, as shown on the table. For instance, when you reach 3rd level in this class, you can learn one new spell of 1st or 2nd level.\n\nAdditionally, when you gain a level in this class, you can choose one of the bard spells you know and replace it with another spell from the bard spell list, which also must be of a level for which you have spell slots.\n\n**Spellcasting Ability**\n\nCharisma is your spellcasting ability for your bard spells. Your magic comes from the heart and soul you pour into the performance of your music or oration. You use your Charisma whenever a spell refers to your spellcasting ability. In addition, you use your Charisma modifier when setting the saving throw DC for a bard spell you cast and when making an attack roll with one.\n\n**Spell save DC** = 8 + your proficiency bonus + your Charisma modifier\n\n**Spell attack modifier** = your proficiency bonus + your Charisma modifier\n\n**Ritual Casting**\n\nYou can cast any bard spell you know as a ritual if that spell has the ritual tag.\n\n**Spellcasting Focus**\n\nYou can use a musical instrument as a spellcasting focus for your bard spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Il bardo ha imparato a districare e rimodellare il tessuto della realtà in armonia con i propri desideri e con la propria musica. I suoi incantesimi fanno parte del suo vasto repertorio, una magia che può adattare a situazioni diverse.\n\n**Trucchetti**\n\nIl bardo conosce due trucchetti a sua scelta dalla lista degli incantesimi del bardo. Apprende altri trucchetti da bardo a sua scelta ai livelli più alti, come indicato nella colonna \"Trucchetti conosciuti\" della tabella del Bardo.\n\n**Slot incantesimo**\n\nLa tabella del Bardo indica quanti slot incantesimo possiede il bardo per lanciare i suoi incantesimi di 1° livello e superiore. Per lanciare uno di questi incantesimi deve spendere uno slot di livello pari o superiore a quello dell'incantesimo. Recupera tutti gli slot incantesimo spesi quando completa un riposo lungo.\n\nPer esempio, se conosce l'incantesimo di 1° livello *cura ferite* e ha a disposizione uno slot di 1° livello e uno di 2° livello, può lanciare *cura ferite* usando uno qualsiasi dei due slot.\n\n**Incantesimi conosciuti di 1° livello e superiore**\n\nIl bardo conosce quattro incantesimi di 1° livello a sua scelta dalla lista degli incantesimi del bardo.\n\nLa colonna \"Incantesimi conosciuti\" della tabella del Bardo indica quando apprende altri incantesimi da bardo a sua scelta. Ognuno di questi incantesimi deve essere di un livello per cui possiede slot incantesimo, come indicato nella tabella. Per esempio, quando arriva al 3° livello in questa classe, può apprendere un nuovo incantesimo di 1° o di 2° livello.\n\nInoltre, quando ottiene un livello in questa classe, può scegliere uno degli incantesimi da bardo che conosce e sostituirlo con un altro incantesimo della lista del bardo, che deve anch'esso essere di un livello per cui possiede slot incantesimo.\n\n**Caratteristica da incantatore**\n\nIl Carisma è la caratteristica da incantatore del bardo per i suoi incantesimi da bardo: la sua magia nasce dal cuore e dall'anima che riversa nell'esecuzione della musica o dell'orazione. Il bardo usa il Carisma ogni volta che un incantesimo fa riferimento alla sua caratteristica da incantatore. Usa inoltre il modificatore di Carisma per stabilire la CD dei tiri salvezza di un incantesimo da bardo che lancia e quando effettua un tiro per colpire con uno di essi.\n\n**CD del tiro salvezza degli incantesimi** = 8 + bonus di competenza + modificatore di Carisma\n\n**Modificatore di attacco degli incantesimi** = bonus di competenza + modificatore di Carisma\n\n**Celebrare rituali**\n\nIl bardo può lanciare come rituale qualsiasi incantesimo da bardo che conosce, se quell'incantesimo ha il descrittore rituale.\n\n**Focus da incantatore**\n\nIl bardo può usare uno strumento musicale come focus da incantatore per i suoi incantesimi da bardo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/bardic-inspiration"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/bardic-inspiration", "en"), Language = LanguageCode.En, Name = "Bardic Inspiration", Description = "You can inspire others through stirring words or music. To do so, you use a bonus action on your turn to choose one creature other than yourself within 60 feet of you who can hear you. That creature gains one Bardic Inspiration die, a d6. Once within the next 10 minutes, the creature can roll the die and add the number rolled to one ability check, attack roll, or saving throw it makes. The creature can wait until after it rolls the d20 before deciding to use the Bardic Inspiration die, but must decide before the GM says whether the roll succeeds or fails. Once the Bardic Inspiration die is rolled, it is lost. A creature can have only one Bardic Inspiration die at a time.\n\nYou can use this feature a number of times equal to your Charisma modifier (a minimum of once).\n\nYou regain any expended uses when you finish a long rest.\n\nYour Bardic Inspiration die changes when you reach certain levels in this class. The die becomes a d8 at 5th level, a d10 at 10th level, and a d12 at 15th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/bardic-inspiration", "it"), Language = LanguageCode.It, Name = "Ispirazione Bardica", Description = "Il bardo può ispirare gli altri con parole o musica trascinanti. Per farlo, usa un'azione bonus nel suo turno per scegliere una creatura diversa da sé entro 18 metri che sia in grado di sentirlo. Quella creatura ottiene un dado di Ispirazione Bardica, un d6. Una volta entro i 10 minuti successivi, la creatura può tirare il dado e aggiungere il risultato a una prova di caratteristica, a un tiro per colpire o a un tiro salvezza che effettua. Può aspettare di aver tirato il d20 prima di decidere se usare il dado di Ispirazione Bardica, ma deve decidere prima che il DM dichiari se il tiro ha successo o meno. Una volta tirato, il dado di Ispirazione Bardica è perso. Una creatura può avere un solo dado di Ispirazione Bardica alla volta.\n\nIl bardo può usare questo privilegio un numero di volte pari al suo modificatore di Carisma (minimo una volta).\n\nRecupera tutti gli utilizzi spesi quando completa un riposo lungo.\n\nIl dado di Ispirazione Bardica cambia quando il bardo raggiunge certi livelli in questa classe: diventa un d8 al 5° livello, un d10 al 10° livello e un d12 al 15° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/jack-of-all-trades"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/jack-of-all-trades", "en"), Language = LanguageCode.En, Name = "Jack of All Trades", Description = "Starting at 2nd level, you can add half your proficiency bonus, rounded down, to any ability check you make that doesn't already include your proficiency bonus." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/jack-of-all-trades", "it"), Language = LanguageCode.It, Name = "Factotum", Description = "A partire dal 2° livello, il bardo può aggiungere metà del suo bonus di competenza, arrotondata per difetto, a qualsiasi prova di caratteristica che effettua e che non includa già il suo bonus di competenza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/song-of-rest"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/song-of-rest", "en"), Language = LanguageCode.En, Name = "Song of Rest", Description = "Beginning at 2nd level, you can use soothing music or oration to help revitalize your wounded allies during a short rest.\n\nIf you or any friendly creatures who can hear your performance regain hit points at the end of the short rest by spending one or more Hit Dice, each of those creatures regains an extra 1d6 hit points.\n\nThe extra hit points increase when you reach certain levels in this class: to 1d8 at 9th level, to 1d10 at 13th level, and to 1d12 at 17th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/song-of-rest", "it"), Language = LanguageCode.It, Name = "Canto di Riposo", Description = "A partire dal 2° livello, il bardo può usare una musica o un'orazione rasserenante per aiutare a rinvigorire gli alleati feriti durante un riposo breve.\n\nSe il bardo o qualsiasi creatura amica in grado di sentire la sua esibizione recupera punti ferita alla fine del riposo breve spendendo uno o più Dadi Vita, ognuna di quelle creature recupera 1d6 punti ferita extra.\n\nI punti ferita extra aumentano quando il bardo raggiunge certi livelli in questa classe: diventano 1d8 al 9° livello, 1d10 al 13° livello e 1d12 al 17° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/bard-college"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/bard-college", "en"), Language = LanguageCode.En, Name = "Bard College", Description = "At 3rd level, you delve into the advanced techniques of a bard college of your choice, such as the College of Lore. Your choice grants you features at 3rd level and again at 6th and 14th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/bard-college", "it"), Language = LanguageCode.It, Name = "Collegio Bardico", Description = "Al 3° livello il bardo approfondisce le tecniche avanzate di un collegio bardico a sua scelta, come il Collegio della Sapienza. La scelta gli conferisce privilegi al 3° livello e poi al 6° e al 14° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/expertise"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/expertise", "en"), Language = LanguageCode.En, Name = "Expertise", Description = "At 3rd level, choose two of your skill proficiencies. Your proficiency bonus is doubled for any ability check you make that uses either of the chosen proficiencies. At 10th level, you can choose another two skill proficiencies to gain this benefit." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/expertise", "it"), Language = LanguageCode.It, Name = "Maestria", Description = "Al 3° livello il bardo sceglie due delle sue competenze nelle abilità. Il suo bonus di competenza raddoppia per qualsiasi prova di caratteristica che effettua usando una di quelle competenze. Al 10° livello può scegliere altre due competenze nelle abilità che ottengono questo beneficio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Quando arriva al 4° livello, e poi all'8°, al 12°, al 16° e al 19° livello, il personaggio può aumentare di 2 un punteggio di caratteristica a sua scelta, oppure aumentare di 1 due punteggi di caratteristica a sua scelta. Come di consueto, questo privilegio non consente di aumentare un punteggio di caratteristica oltre 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/font-of-inspiration"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 5,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/font-of-inspiration", "en"), Language = LanguageCode.En, Name = "Font of Inspiration", Description = "Beginning when you reach 5th level, you regain all of your expended uses of Bardic Inspiration when you finish a short or long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/font-of-inspiration", "it"), Language = LanguageCode.It, Name = "Fonte di Ispirazione", Description = "A partire dal 5° livello, il bardo recupera tutti gli utilizzi spesi di Ispirazione Bardica quando completa un riposo breve o lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/countercharm"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/countercharm", "en"), Language = LanguageCode.En, Name = "Countercharm", Description = "At 6th level, you gain the ability to use musical notes or words of power to disrupt mind-influencing effects. As an action, you can start a performance that lasts until the end of your next turn. During that time, you and any friendly creatures within 30 feet of you have advantage on saving throws against being frightened or charmed. A creature must be able to hear you to gain this benefit. The performance ends early if you are incapacitated or silenced or if you voluntarily end it (no action required)." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/countercharm", "it"), Language = LanguageCode.It, Name = "Controfascino", Description = "Al 6° livello il bardo ottiene la capacità di usare note musicali o parole di potere per spezzare gli effetti che influenzano la mente. Come azione, può iniziare un'esibizione che dura fino alla fine del suo turno successivo. Durante quel periodo, il bardo e qualsiasi creatura amica entro 9 metri da lui dispongono di vantaggio ai tiri salvezza per non essere spaventati o affascinati. Per ottenere questo beneficio, una creatura deve essere in grado di sentire il bardo. L'esibizione termina prima se il bardo è incapacitato o ridotto al silenzio, o se decide di interromperla (non richiede alcuna azione)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/magical-secrets"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/magical-secrets", "en"), Language = LanguageCode.En, Name = "Magical Secrets", Description = "By 10th level, you have plundered magical knowledge from a wide spectrum of disciplines.\n\nChoose two spells from any class, including this one. A spell you choose must be of a level you can cast, as shown on the Bard table, or a cantrip.\n\nThe chosen spells count as bard spells for you and are included in the number in the Spells Known column of the Bard table.\n\nYou learn two additional spells from any class at 14th level and again at 18th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/magical-secrets", "it"), Language = LanguageCode.It, Name = "Segreti Magici", Description = "Al 10° livello il bardo ha carpito conoscenze magiche da un'ampia gamma di discipline.\n\nSceglie due incantesimi da qualsiasi classe, inclusa questa. Ogni incantesimo scelto deve essere di un livello che il bardo è in grado di lanciare, come indicato nella tabella del Bardo, oppure un trucchetto.\n\nGli incantesimi scelti contano come incantesimi da bardo per lui e sono inclusi nel numero della colonna \"Incantesimi conosciuti\" della tabella del Bardo.\n\nIl bardo apprende altri due incantesimi da qualsiasi classe al 14° livello e poi di nuovo al 18° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/superior-inspiration"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 20,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/superior-inspiration", "en"), Language = LanguageCode.En, Name = "Superior Inspiration", Description = "At 20th level, when you roll initiative and have no uses of Bardic Inspiration left, you regain one use." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "bard/superior-inspiration", "it"), Language = LanguageCode.It, Name = "Ispirazione Superiore", Description = "Al 20° livello, quando tira per l'iniziativa e non gli resta alcun utilizzo di Ispirazione Bardica, il bardo ne recupera uno." }
					}
				}
			}
		};
	}
}
