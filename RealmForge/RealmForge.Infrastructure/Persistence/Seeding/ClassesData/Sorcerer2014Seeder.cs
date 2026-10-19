using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Sorcerer (2014 ruleset): class features of the SRD 5.1 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Sorcerer2014Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "sorcerer");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			HitDie = 6,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Charisma },
			SavingThrows = new List<AbilityScore> { AbilityScore.Constitution, AbilityScore.Charisma },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.Arcana, Skill.Deception, Skill.Insight, Skill.Intimidation, Skill.Persuasion, Skill.Religion },
			CasterProgression = CasterProgression.Full,
			SpellcastingAbility = AbilityScore.Charisma,
			SubclassLevel = 1,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "sorcerer", "en"),
					Language = LanguageCode.En,
					Name = "Sorcerer",
					Description = "A spellcaster whose magic is innate rather than studied. Sorcerers draw on power carried in their blood or granted by a strange event, and they can bend and reshape their spells with sorcery points and Metamagic.",
					SubclassTitle = "Sorcerous Origin",
					ArmorProficiencies = "None",
					WeaponProficiencies = "Daggers, darts, slings, quarterstaffs, light crossbows",
					ToolProficiencies = "None",
					StartingEquipment = "- (a) a light crossbow and 20 bolts or (b) any simple weapon\n- (a) a component pouch or (b) an arcane focus\n- (a) a dungeoneer’s pack or (b) an explorer’s pack\n- Two daggers",
					ProgressionTable = "The 1st–9th columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Features | Sorcery Points | Cantrips Known | Spells Known | 1st | 2nd | 3rd | 4th | 5th | 6th | 7th | 8th | 9th |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1st | +2 | Spellcasting, Sorcerous Origin | — | 4 | 2 | 2 | — | — | — | — | — | — | — | — |\n| 2nd | +2 | Font of Magic | 2 | 4 | 3 | 3 | — | — | — | — | — | — | — | — |\n| 3rd | +2 | Metamagic | 3 | 4 | 4 | 4 | 2 | — | — | — | — | — | — | — |\n| 4th | +2 | Ability Score Improvement | 4 | 5 | 5 | 4 | 3 | — | — | — | — | — | — | — |\n| 5th | +3 | — | 5 | 5 | 6 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6th | +3 | Sorcerous Origin feature | 6 | 5 | 7 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7th | +3 | — | 7 | 5 | 8 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8th | +3 | Ability Score Improvement | 8 | 5 | 9 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9th | +4 | — | 9 | 5 | 10 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10th | +4 | Metamagic | 10 | 6 | 11 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11th | +4 | — | 11 | 6 | 12 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12th | +4 | Ability Score Improvement | 12 | 6 | 12 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13th | +5 | — | 13 | 6 | 13 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14th | +5 | Sorcerous Origin feature | 14 | 6 | 13 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15th | +5 | — | 15 | 6 | 14 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16th | +5 | Ability Score Improvement | 16 | 6 | 14 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17th | +6 | Metamagic | 17 | 6 | 15 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18th | +6 | Sorcerous Origin feature | 18 | 6 | 15 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19th | +6 | Ability Score Improvement | 19 | 6 | 15 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20th | +6 | Sorcerous Restoration | 20 | 6 | 15 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "sorcerer", "it"),
					Language = LanguageCode.It,
					Name = "Stregone",
					Description = "Un incantatore la cui magia è innata anziché frutto dello studio. Lo stregone attinge a un potere che scorre nel suo sangue o che gli è stato conferito da un evento straordinario, e può piegare e rimodellare i suoi incantesimi grazie ai punti stregoneria e alla Metamagia.",
					SubclassTitle = "Origine Stregonesca",
					ArmorProficiencies = "Nessuna",
					WeaponProficiencies = "Balestre leggere, bastoni ferrati, dardi, fionde, pugnali",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "- (a) una balestra leggera e 20 quadrelli o (b) un'arma semplice qualsiasi\n- (a) una borsa per componenti o (b) un focus arcano\n- (a) una dotazione da esploratore di dungeon o (b) una dotazione da esploratore\n- Due pugnali",
					ProgressionTable = "Le colonne 1°–9° indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi | Punti stregoneria | Trucchetti conosciuti | Incantesimi conosciuti | 1° | 2° | 3° | 4° | 5° | 6° | 7° | 8° | 9° |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1° | +2 | Incantesimi, Origine Stregonesca | — | 4 | 2 | 2 | — | — | — | — | — | — | — | — |\n| 2° | +2 | Fonte di Magia | 2 | 4 | 3 | 3 | — | — | — | — | — | — | — | — |\n| 3° | +2 | Metamagia | 3 | 4 | 4 | 4 | 2 | — | — | — | — | — | — | — |\n| 4° | +2 | Aumento dei Punteggi di Caratteristica | 4 | 5 | 5 | 4 | 3 | — | — | — | — | — | — | — |\n| 5° | +3 | — | 5 | 5 | 6 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6° | +3 | Privilegio dell'Origine Stregonesca | 6 | 5 | 7 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7° | +3 | — | 7 | 5 | 8 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8° | +3 | Aumento dei Punteggi di Caratteristica | 8 | 5 | 9 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9° | +4 | — | 9 | 5 | 10 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10° | +4 | Metamagia | 10 | 6 | 11 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11° | +4 | — | 11 | 6 | 12 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12° | +4 | Aumento dei Punteggi di Caratteristica | 12 | 6 | 12 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13° | +5 | — | 13 | 6 | 13 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14° | +5 | Privilegio dell'Origine Stregonesca | 14 | 6 | 13 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15° | +5 | — | 15 | 6 | 14 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16° | +5 | Aumento dei Punteggi di Caratteristica | 16 | 6 | 14 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17° | +6 | Metamagia | 17 | 6 | 15 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18° | +6 | Privilegio dell'Origine Stregonesca | 18 | 6 | 15 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19° | +6 | Aumento dei Punteggi di Caratteristica | 19 | 6 | 15 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20° | +6 | Ripristino Stregonesco | 20 | 6 | 15 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "An event in your past, or in the life of a parent or ancestor, left an indelible mark on you, infusing you with arcane magic. This font of magic, whatever its origin, fuels your spells.\n\n**Cantrips.** At 1st level, you know four cantrips of your choice from the sorcerer spell list. You learn additional sorcerer cantrips of your choice at higher levels, as shown in the Cantrips Known column of the Sorcerer table.\n\n**Spell Slots.** The Sorcerer table shows how many spell slots you have to cast your spells of 1st level and higher. To cast one of these sorcerer spells, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest.\n\nFor example, if you know the 1st-level spell *burning hands* and have a 1st-level and a 2nd-level spell slot available, you can cast *burning hands* using either slot.\n\n**Spells Known of 1st Level and Higher.** You know two 1st-level spells of your choice from the sorcerer spell list.\n\nThe Spells Known column of the Sorcerer table shows when you learn more sorcerer spells of your choice. Each of these spells must be of a level for which you have spell slots. For instance, when you reach 3rd level in this class, you can learn one new spell of 1st or 2nd level.\n\nAdditionally, when you gain a level in this class, you can choose one of the sorcerer spells you know and replace it with another spell from the sorcerer spell list, which also must be of a level for which you have spell slots.\n\n**Spellcasting Ability.** Charisma is your spellcasting ability for your sorcerer spells, since the power of your magic relies on your ability to project your will into the world. You use your Charisma whenever a spell refers to your spellcasting ability. In addition, you use your Charisma modifier when setting the saving throw DC for a sorcerer spell you cast and when making an attack roll with one.\n\n**Spell save DC** = 8 + your proficiency bonus + your Charisma modifier\n\n**Spell attack modifier** = your proficiency bonus + your Charisma modifier\n\n**Spellcasting Focus.** You can use an arcane focus as a spellcasting focus for your sorcerer spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Un evento del passato dello stregone, o della vita di un suo genitore o antenato, ha lasciato su di lui un segno indelebile, infondendogli la magia arcana. Questa fonte di magia, qualunque sia la sua origine, alimenta i suoi incantesimi.\n\n**Trucchetti.** Al 1° livello lo stregone conosce quattro trucchetti a sua scelta dalla lista degli incantesimi dello stregone. Apprende altri trucchetti da stregone a sua scelta ai livelli superiori, come indicato nella colonna \"Trucchetti conosciuti\" della tabella dello Stregone.\n\n**Slot incantesimo.** La tabella dello Stregone indica quanti slot incantesimo possiede lo stregone per lanciare i suoi incantesimi di 1° livello e superiore. Per lanciare uno di questi incantesimi, deve spendere uno slot di livello pari o superiore a quello dell'incantesimo. Recupera tutti gli slot incantesimo spesi quando completa un riposo lungo.\n\nPer esempio, se conosce l'incantesimo di 1° livello *mani brucianti* e dispone di uno slot di 1° livello e di uno slot di 2° livello, può lanciare *mani brucianti* usando l'uno o l'altro slot.\n\n**Incantesimi conosciuti di 1° livello e superiore.** Lo stregone conosce due incantesimi di 1° livello a sua scelta dalla lista degli incantesimi dello stregone.\n\nLa colonna \"Incantesimi conosciuti\" della tabella dello Stregone indica quando apprende altri incantesimi da stregone a sua scelta. Ognuno di essi deve essere di un livello per cui possiede slot incantesimo. Per esempio, quando arriva al 3° livello in questa classe, può apprendere un nuovo incantesimo di 1° o di 2° livello.\n\nInoltre, quando ottiene un livello in questa classe, può scegliere uno degli incantesimi da stregone che conosce e sostituirlo con un altro incantesimo della lista dello stregone, che deve a sua volta essere di un livello per cui possiede slot incantesimo.\n\n**Caratteristica da incantatore.** Il Carisma è la caratteristica da incantatore per gli incantesimi da stregone, dato che la potenza della sua magia dipende dalla capacità di imporre la propria volontà sul mondo. Lo stregone usa il Carisma ogni volta che un incantesimo fa riferimento alla sua caratteristica da incantatore. Usa inoltre il suo modificatore di Carisma per stabilire la CD dei tiri salvezza degli incantesimi da stregone che lancia e quando effettua un tiro per colpire con uno di essi.\n\n**CD del tiro salvezza degli incantesimi** = 8 + bonus di competenza + modificatore di Carisma\n\n**Modificatore di attacco degli incantesimi** = bonus di competenza + modificatore di Carisma\n\n**Focus da incantatore.** Lo stregone può usare un focus arcano come focus da incantatore per i suoi incantesimi da stregone." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/sorcerous-origins"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/sorcerous-origins", "en"), Language = LanguageCode.En, Name = "Sorcerous Origins", Description = "Choose a sorcerous origin, which describes the source of your innate magical power, such as Draconic Bloodline.\n\nYour choice grants you features when you choose it at 1st level and again at 6th, 14th, and 18th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/sorcerous-origins", "it"), Language = LanguageCode.It, Name = "Origine Stregonesca", Description = "Lo stregone sceglie un'origine stregonesca che descrive la fonte del suo potere magico innato, come la Discendenza Draconica.\n\nLa scelta gli conferisce privilegi al 1° livello e poi al 6°, al 14° e al 18° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/font-of-magic"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/font-of-magic", "en"), Language = LanguageCode.En, Name = "Font of Magic", Description = "At 2nd level, you tap into a deep wellspring of magic within yourself. This wellspring is represented by sorcery points, which allow you to create a variety of magical effects.\n\n**Sorcery Points.** You have 2 sorcery points, and you gain more as you reach higher levels. Your sorcerer level equals the number of sorcery points you have, so a 4th-level sorcerer has 4 sorcery points, a 16th-level sorcerer has 16. You can never have more sorcery points than your level dictates.  You regain all spent sorcery points when you finish a long rest.\n\n**Flexible Casting.** You can use your sorcery points to gain additional spell slots, or sacrifice spell slots to gain additional sorcery points. You learn other ways to use your sorcery points as you reach higher levels.\n\n**Creating Spell Slots.** You can transform unexpended sorcery points into one spell slot as a bonus action on your turn. The Creating Spell Slots table shows the cost of creating a spell slot of a given level. You can create spell slots no higher in level than 5th.\n\nAny spell slot you create with this feature vanishes when you finish a long rest.\n\n| Spell Slot Level | Sorcery Point Cost |\n|---|---|\n| 1st | 2 |\n| 2nd | 3 |\n| 3rd | 5 |\n| 4th | 6 |\n| 5th | 7 |\n\n**Converting a Spell Slot to Sorcery Points.** As a bonus action on your turn, you can expend one spell slot and gain a number of sorcery points equal to the slot's level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/font-of-magic", "it"), Language = LanguageCode.It, Name = "Fonte di Magia", Description = "Al 2° livello lo stregone attinge a una profonda sorgente di magia interiore. Questa sorgente è rappresentata dai punti stregoneria, che gli permettono di creare svariati effetti magici.\n\n**Punti stregoneria.** Lo stregone possiede 2 punti stregoneria e ne ottiene altri quando sale di livello. Il suo livello da stregone è pari al numero di punti stregoneria che possiede: uno stregone di 4° livello ha 4 punti stregoneria, uno di 16° livello ne ha 16. Non può mai avere più punti stregoneria di quanti gliene conceda il suo livello. Recupera tutti i punti stregoneria spesi quando completa un riposo lungo.\n\n**Incantesimi flessibili.** Lo stregone può usare i suoi punti stregoneria per ottenere slot incantesimo aggiuntivi, oppure sacrificare slot incantesimo per ottenere punti stregoneria aggiuntivi. Apprende altri modi di usare i punti stregoneria quando arriva ai livelli superiori.\n\n**Creare slot incantesimo.** Come azione bonus nel suo turno, lo stregone può trasformare punti stregoneria non spesi in uno slot incantesimo. La tabella \"Creazione degli slot incantesimo\" indica il costo per creare uno slot di un dato livello. Lo stregone non può creare slot incantesimo di livello superiore al 5°.\n\nOgni slot incantesimo creato con questo privilegio svanisce quando lo stregone completa un riposo lungo.\n\n| Livello dello slot | Costo in punti stregoneria |\n|---|---|\n| 1° | 2 |\n| 2° | 3 |\n| 3° | 5 |\n| 4° | 6 |\n| 5° | 7 |\n\n**Convertire uno slot incantesimo in punti stregoneria.** Come azione bonus nel suo turno, lo stregone può spendere uno slot incantesimo e ottenere un numero di punti stregoneria pari al livello dello slot." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/metamagic"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/metamagic", "en"), Language = LanguageCode.En, Name = "Metamagic", Description = "At 3rd level, you gain the ability to twist your spells to suit your needs. You gain two of the following Metamagic options of your choice. You gain another one at 10th and 17th level. You can use only one Metamagic option on a spell when you cast it, unless otherwise noted.\n\n***Careful Spell.*** When you cast a spell that forces other creatures to make a saving throw, you can protect some of those creatures from the spell's full force. To do so, you spend 1 sorcery point and choose a number of those creatures up to your Charisma modifier (minimum of one creature). A chosen creature automatically succeeds on its saving throw against the spell.\n\n***Distant Spell.*** When you cast a spell that has a range of 5 feet or greater, you can spend 1 sorcery point to double the range of the spell.\n\nWhen you cast a spell that has a range of touch, you can spend 1 sorcery point to make the range of the spell 30 feet.\n\n***Empowered Spell.*** When you roll damage for a spell, you can spend 1 sorcery point to reroll a number of the damage dice up to your Charisma modifier (minimum of one). You must use the new rolls.\n\nYou can use Empowered Spell even if you have already used a different Metamagic option during the casting of the spell.\n\n***Extended Spell.*** When you cast a spell that has a duration of 1 minute or longer, you can spend 1 sorcery point to double its duration, to a maximum duration of 24 hours.\n\n***Heightened Spell.*** When you cast a spell that forces a creature to make a saving throw to resist its effects, you can spend 3 sorcery points to give one target of the spell disadvantage on its first saving throw made against the spell.\n\n***Quickened Spell.*** When you cast a spell that has a casting time of 1 action, you can spend 2 sorcery points to change the casting time to 1 bonus action for this casting.\n\n***Subtle Spell.*** When you cast a spell, you can spend 1 sorcery point to cast it without any somatic or verbal components.\n\n***Twinned Spell.*** When you cast a spell that targets only one creature and doesn't have a range of self, you can spend a number of sorcery points equal to the spell's level to target a second creature in range with the same spell (1 sorcery point if the spell is a cantrip).\n\nTo be eligible, a spell must be incapable of targeting more than one creature at the spell's current level. For example, *magic missile* and *scorching ray* aren't eligible, but *ray of frost* is." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/metamagic", "it"), Language = LanguageCode.It, Name = "Metamagia", Description = "Al 3° livello lo stregone ottiene la capacità di plasmare i suoi incantesimi secondo le sue necessità. Ottiene due delle seguenti opzioni di Metamagia a sua scelta, e un'altra al 10° e al 17° livello. Può usare una sola opzione di Metamagia su un incantesimo quando lo lancia, salvo diversa indicazione.\n\n***Incantesimo Celato.*** Quando lancia un incantesimo, lo stregone può spendere 1 punto stregoneria per lanciarlo senza alcuna componente somatica o verbale.\n\n***Incantesimo Distante.*** Quando lancia un incantesimo con una gittata pari o superiore a 1,5 metri, lo stregone può spendere 1 punto stregoneria per raddoppiarne la gittata.\n\nQuando lancia un incantesimo con gittata a contatto, può spendere 1 punto stregoneria per portarne la gittata a 9 metri.\n\n***Incantesimo Esteso.*** Quando lancia un incantesimo con una durata pari o superiore a 1 minuto, lo stregone può spendere 1 punto stregoneria per raddoppiarne la durata, fino a un massimo di 24 ore.\n\n***Incantesimo Intensificato.*** Quando lancia un incantesimo che costringe una creatura a effettuare un tiro salvezza per resistere ai suoi effetti, lo stregone può spendere 3 punti stregoneria per imporre svantaggio a un bersaglio dell'incantesimo al primo tiro salvezza che effettua contro di esso.\n\n***Incantesimo Potenziato.*** Quando tira per i danni di un incantesimo, lo stregone può spendere 1 punto stregoneria per ripetere il tiro di un numero di dadi dei danni pari al massimo al suo modificatore di Carisma (minimo uno). Deve usare i nuovi risultati.\n\nLo stregone può usare Incantesimo Potenziato anche se ha già usato un'altra opzione di Metamagia durante il lancio dell'incantesimo.\n\n***Incantesimo Preciso.*** Quando lancia un incantesimo che costringe altre creature a effettuare un tiro salvezza, lo stregone può proteggere alcune di quelle creature dalla piena forza dell'incantesimo. Per farlo spende 1 punto stregoneria e sceglie un numero di quelle creature pari al massimo al suo modificatore di Carisma (minimo una creatura). Ogni creatura scelta supera automaticamente il suo tiro salvezza contro l'incantesimo.\n\n***Incantesimo Raddoppiato.*** Quando lancia un incantesimo che bersaglia una sola creatura e non ha gittata \"incantatore\", lo stregone può spendere un numero di punti stregoneria pari al livello dell'incantesimo per bersagliare con lo stesso incantesimo una seconda creatura entro gittata (1 punto stregoneria se l'incantesimo è un trucchetto).\n\nPer poter essere scelto, un incantesimo non deve essere in grado di bersagliare più di una creatura al livello a cui viene lanciato. Per esempio, *dardo incantato* e *raggio rovente* non possono essere scelti, mentre *raggio di gelo* sì.\n\n***Incantesimo Rapido.*** Quando lancia un incantesimo con un tempo di lancio di 1 azione, lo stregone può spendere 2 punti stregoneria per cambiare il tempo di lancio in 1 azione bonus per quel lancio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Quando arriva al 4° livello, e poi all'8°, al 12°, al 16° e al 19° livello, il personaggio può aumentare di 2 un punteggio di caratteristica a sua scelta, oppure aumentare di 1 due punteggi di caratteristica a sua scelta. Come di consueto, questo privilegio non consente di aumentare un punteggio di caratteristica oltre 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/sorcerous-restoration"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 20,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/sorcerous-restoration", "en"), Language = LanguageCode.En, Name = "Sorcerous Restoration", Description = "At 20th level, you regain 4 expended sorcery points whenever you finish a short rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "sorcerer/sorcerous-restoration", "it"), Language = LanguageCode.It, Name = "Ripristino Stregonesco", Description = "Al 20° livello lo stregone recupera 4 punti stregoneria spesi ogni volta che completa un riposo breve." }
					}
				}
			}
		};
	}
}
