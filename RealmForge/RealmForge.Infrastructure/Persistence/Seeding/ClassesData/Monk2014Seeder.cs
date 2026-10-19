using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Monk (2014 ruleset): class features of the SRD 5.1 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Monk2014Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "monk");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			HitDie = 8,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Wisdom },
			SavingThrows = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.Acrobatics, Skill.Athletics, Skill.History, Skill.Insight, Skill.Religion, Skill.Stealth },
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "monk", "en"),
					Language = LanguageCode.En,
					Name = "Monk",
					Description = "A disciplined martial artist who channels the mystic energy called ki. Monks fight with bare hands and simple weapons, move with astonishing speed and use ki to dodge, stun and perform supernatural feats.",
					SubclassTitle = "Monastic Tradition",
					ArmorProficiencies = "None",
					WeaponProficiencies = "Simple weapons, shortswords",
					ToolProficiencies = "Choose one type of artisan's tools or one musical instrument",
					StartingEquipment = "- (a) a shortsword or (b) any simple weapon\n- (a) a dungeoneer’s pack or (b) an explorer’s pack\n- 10 darts",
					ProgressionTable = "| Level | Proficiency Bonus | Features | Martial Arts | Ki Points | Unarmored Movement |\n|---|---|---|---|---|---|\n| 1st | +2 | Unarmored Defense, Martial Arts | 1d4 | — | — |\n| 2nd | +2 | Ki, Unarmored Movement | 1d4 | 2 | +10 ft. |\n| 3rd | +2 | Monastic Tradition, Deflect Missiles | 1d4 | 3 | +10 ft. |\n| 4th | +2 | Ability Score Improvement, Slow Fall | 1d4 | 4 | +10 ft. |\n| 5th | +3 | Extra Attack, Stunning Strike | 1d6 | 5 | +10 ft. |\n| 6th | +3 | Ki-Empowered Strikes, Monastic Tradition feature | 1d6 | 6 | +15 ft. |\n| 7th | +3 | Evasion, Stillness of Mind | 1d6 | 7 | +15 ft. |\n| 8th | +3 | Ability Score Improvement | 1d6 | 8 | +15 ft. |\n| 9th | +4 | Unarmored Movement improvement | 1d6 | 9 | +15 ft. |\n| 10th | +4 | Purity of Body | 1d6 | 10 | +20 ft. |\n| 11th | +4 | Monastic Tradition feature | 1d8 | 11 | +20 ft. |\n| 12th | +4 | Ability Score Improvement | 1d8 | 12 | +20 ft. |\n| 13th | +5 | Tongue of the Sun and Moon | 1d8 | 13 | +20 ft. |\n| 14th | +5 | Diamond Soul | 1d8 | 14 | +25 ft. |\n| 15th | +5 | Timeless Body | 1d8 | 15 | +25 ft. |\n| 16th | +5 | Ability Score Improvement | 1d8 | 16 | +25 ft. |\n| 17th | +6 | Monastic Tradition feature | 1d10 | 17 | +25 ft. |\n| 18th | +6 | Empty Body | 1d10 | 18 | +30 ft. |\n| 19th | +6 | Ability Score Improvement | 1d10 | 19 | +30 ft. |\n| 20th | +6 | Perfect Self | 1d10 | 20 | +30 ft. |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "monk", "it"),
					Language = LanguageCode.It,
					Name = "Monaco",
					Description = "Un artista marziale disciplinato che incanala l'energia mistica chiamata ki. Il monaco combatte a mani nude e con armi semplici, si muove con una rapidità sorprendente e usa il ki per schivare, stordire e compiere imprese sovrannaturali.",
					SubclassTitle = "Tradizione Monastica",
					ArmorProficiencies = "Nessuna",
					WeaponProficiencies = "Armi semplici, spade corte",
					ToolProficiencies = "Un tipo di strumenti da artigiano o uno strumento musicale a scelta",
					StartingEquipment = "- (a) una spada corta o (b) una qualsiasi arma semplice\n- (a) una dotazione da avventuriero o (b) una dotazione da esploratore\n- 10 dardi",
					ProgressionTable = "| Livello | Bonus di competenza | Privilegi | Arti marziali | Punti ki | Movimento senza armatura |\n|---|---|---|---|---|---|\n| 1° | +2 | Difesa Senza Armatura, Arti Marziali | 1d4 | — | — |\n| 2° | +2 | Ki, Movimento Senza Armatura | 1d4 | 2 | +3 m |\n| 3° | +2 | Tradizione Monastica, Deviare Proiettili | 1d4 | 3 | +3 m |\n| 4° | +2 | Aumento dei Punteggi di Caratteristica, Caduta Lenta | 1d4 | 4 | +3 m |\n| 5° | +3 | Attacco Extra, Colpo Stordente | 1d6 | 5 | +3 m |\n| 6° | +3 | Colpi Ki Potenziati, Privilegio della Tradizione Monastica | 1d6 | 6 | +4,5 m |\n| 7° | +3 | Elusione, Mente Lucida | 1d6 | 7 | +4,5 m |\n| 8° | +3 | Aumento dei Punteggi di Caratteristica | 1d6 | 8 | +4,5 m |\n| 9° | +4 | Movimento Senza Armatura migliorato | 1d6 | 9 | +4,5 m |\n| 10° | +4 | Purezza del Corpo | 1d6 | 10 | +6 m |\n| 11° | +4 | Privilegio della Tradizione Monastica | 1d8 | 11 | +6 m |\n| 12° | +4 | Aumento dei Punteggi di Caratteristica | 1d8 | 12 | +6 m |\n| 13° | +5 | Lingua del Sole e della Luna | 1d8 | 13 | +6 m |\n| 14° | +5 | Anima Adamantina | 1d8 | 14 | +7,5 m |\n| 15° | +5 | Corpo Senza Tempo | 1d8 | 15 | +7,5 m |\n| 16° | +5 | Aumento dei Punteggi di Caratteristica | 1d8 | 16 | +7,5 m |\n| 17° | +6 | Privilegio della Tradizione Monastica | 1d10 | 17 | +7,5 m |\n| 18° | +6 | Corpo Vuoto | 1d10 | 18 | +9 m |\n| 19° | +6 | Aumento dei Punteggi di Caratteristica | 1d10 | 19 | +9 m |\n| 20° | +6 | Perfezione Interiore | 1d10 | 20 | +9 m |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/unarmored-defense"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/unarmored-defense", "en"), Language = LanguageCode.En, Name = "Unarmored Defense", Description = "Beginning at 1st level, while you are wearing no armor and not wielding a shield, your AC equals 10 + your Dexterity modifier + your Wisdom modifier." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/unarmored-defense", "it"), Language = LanguageCode.It, Name = "Difesa Senza Armatura", Description = "A partire dal 1° livello, finché non indossa alcuna armatura e non impugna uno scudo, la CA del monaco è pari a 10 + il suo modificatore di Destrezza + il suo modificatore di Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/martial-arts"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/martial-arts", "en"), Language = LanguageCode.En, Name = "Martial Arts", Description = "At 1st level, your practice of martial arts gives you mastery of combat styles that use unarmed strikes and monk weapons, which are shortswords and any simple melee weapons that don't have the two-handed or heavy property. You gain the following benefits while you are unarmed or wielding only monk weapons and you aren't wearing armor or wielding a shield:\n- You can use Dexterity instead of Strength for the attack and damage rolls of your unarmed strikes and monk weapons.\n- You can roll a d4 in place of the normal damage of your unarmed strike or monk weapon. This die changes as you gain monk levels, as shown in the Martial Arts column of the Monk table.\n- When you use the Attack action with an unarmed strike or a monk weapon on your turn, you can make one unarmed strike as a bonus action. For example, if you take the Attack action and attack with a quarterstaff, you can also make an unarmed strike as a bonus action, assuming you haven't already taken a bonus action this turn.\n\nCertain monasteries use specialized forms of the monk weapons. For example, you might use a club that is two lengths of wood connected by a short chain (called a nunchaku) or a sickle with a shorter, straighter blade (called a kama). Whatever name you use for a monk weapon, you can use the game statistics provided for the weapon." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/martial-arts", "it"), Language = LanguageCode.It, Name = "Arti Marziali", Description = "Al 1° livello la pratica delle arti marziali conferisce al monaco la padronanza degli stili di combattimento che usano colpi senz'armi e armi da monaco, cioè le spade corte e qualsiasi arma semplice da mischia che non abbia la proprietà a due mani o pesante. Finché è senz'armi o impugna soltanto armi da monaco, e non indossa armature né impugna uno scudo, ottiene i benefici seguenti:\n- Può usare la Destrezza al posto della Forza per i tiri per colpire e per i danni dei suoi colpi senz'armi e delle armi da monaco.\n- Può tirare un d4 al posto dei normali danni del suo colpo senz'armi o della sua arma da monaco. Questo dado cambia man mano che sale di livello come monaco, come indicato nella colonna \"Arti marziali\" della tabella del Monaco.\n- Quando usa l'azione di Attacco con un colpo senz'armi o con un'arma da monaco nel suo turno, può effettuare un colpo senz'armi come azione bonus. Per esempio, se effettua l'azione di Attacco e attacca con un bastone ferrato, può effettuare anche un colpo senz'armi come azione bonus, a patto di non aver già effettuato un'azione bonus in quel turno.\n\nAlcuni monasteri usano forme specializzate delle armi da monaco. Per esempio, un monaco potrebbe usare un randello composto da due pezzi di legno uniti da una corta catena (detto nunchaku) o un falcetto con una lama più corta e dritta (detto kama). Qualunque sia il nome usato per un'arma da monaco, il monaco può usare le statistiche di gioco fornite per quell'arma." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/ki"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/ki", "en"), Language = LanguageCode.En, Name = "Ki", Description = "Starting at 2nd level, your training allows you to harness the mystic energy of ki. Your access to this energy is represented by a number of ki points. Your monk level equals the number of ki points you have, so a 2nd level monk has 2 ki points, a 16th level monk has 16.\n\nYou can spend these points to fuel various ki features. You start knowing three such features: Flurry of Blows, Patient Defense, and Step of the Wind. You learn more ki features as you gain levels in this class.\n\nWhen you spend a ki point, it is unavailable until you finish a short or long rest, at the end of which you draw all of your expended ki back into yourself. You must spend at least 30 minutes of the rest meditating to regain your ki points.\n\nSome of your ki features require your target to make a saving throw to resist the feature's effects. The saving throw DC is calculated as follows:\n\n**Ki save DC** = 8 + your proficiency bonus + your Wisdom modifier" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/ki", "it"), Language = LanguageCode.It, Name = "Ki", Description = "A partire dal 2° livello, l'addestramento del monaco gli permette di imbrigliare l'energia mistica del ki. L'accesso a questa energia è rappresentato da un numero di punti ki. Il livello da monaco è pari al numero di punti ki posseduti: un monaco di 2° livello ha 2 punti ki, un monaco di 16° livello ne ha 16.\n\nIl monaco può spendere questi punti per alimentare vari privilegi ki. Inizialmente conosce tre di questi privilegi: Raffica di Colpi, Difesa Paziente e Passo del Vento. Ne apprende altri man mano che sale di livello in questa classe.\n\nQuando spende un punto ki, quel punto non è disponibile finché il monaco non completa un riposo breve o lungo, al termine del quale riassorbe in sé tutto il ki speso. Deve passare almeno 30 minuti del riposo meditando per recuperare i suoi punti ki.\n\nAlcuni privilegi ki richiedono che il bersaglio effettui un tiro salvezza per resistere ai loro effetti. La CD del tiro salvezza si calcola come segue:\n\n**CD del tiro salvezza del ki** = 8 + bonus di competenza + modificatore di Saggezza" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/flurry-of-blows"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/flurry-of-blows", "en"), Language = LanguageCode.En, Name = "Flurry of Blows", Description = "Immediately after you take the Attack action on your turn, you can spend 1 ki point to make two unarmed strikes as a bonus action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/flurry-of-blows", "it"), Language = LanguageCode.It, Name = "Raffica di Colpi", Description = "Subito dopo aver effettuato l'azione di Attacco nel suo turno, il monaco può spendere 1 punto ki per effettuare due colpi senz'armi come azione bonus." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/patient-defense"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/patient-defense", "en"), Language = LanguageCode.En, Name = "Patient Defense", Description = "You can spend 1 ki point to take the Dodge action as a bonus action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/patient-defense", "it"), Language = LanguageCode.It, Name = "Difesa Paziente", Description = "Il monaco può spendere 1 punto ki per effettuare l'azione di Schivata come azione bonus nel suo turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/step-of-the-wind"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/step-of-the-wind", "en"), Language = LanguageCode.En, Name = "Step of the Wind", Description = "You can spend 1 ki point to take the Disengage or Dash action as a bonus action on your turn, and your jump distance is doubled for the turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/step-of-the-wind", "it"), Language = LanguageCode.It, Name = "Passo del Vento", Description = "Il monaco può spendere 1 punto ki per effettuare l'azione di Disimpegno o di Scatto come azione bonus nel suo turno, e la distanza dei suoi salti raddoppia per quel turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/unarmored-movement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/unarmored-movement", "en"), Language = LanguageCode.En, Name = "Unarmored Movement", Description = "Starting at 2nd level, your speed increases by 10 feet while you are not wearing armor or wielding a shield. This bonus increases when you reach certain monk levels, as shown in the Monk table.\n\nAt 9th level, you gain the ability to move along vertical surfaces and across liquids on your turn without falling during the move." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/unarmored-movement", "it"), Language = LanguageCode.It, Name = "Movimento Senza Armatura", Description = "A partire dal 2° livello, la velocità del monaco aumenta di 3 metri finché non indossa armature né impugna uno scudo. Questo bonus aumenta quando raggiunge determinati livelli da monaco, come indicato nella tabella del Monaco.\n\nAl 9° livello ottiene la capacità di muoversi lungo superfici verticali e sopra i liquidi nel suo turno senza cadere durante il movimento." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/monastic-tradition"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/monastic-tradition", "en"), Language = LanguageCode.En, Name = "Monastic Tradition", Description = "When you reach 3rd level, you commit yourself to a monastic tradition, such as the Way of the Open Hand. Your tradition grants you features at 3rd level and again at 6th, 11th, and 17th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/monastic-tradition", "it"), Language = LanguageCode.It, Name = "Tradizione Monastica", Description = "Quando arriva al 3° livello, il monaco si vota a una tradizione monastica, come la Via della Mano Aperta. La tradizione gli conferisce privilegi al 3° livello e poi al 6°, all'11° e al 17° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/deflect-missiles"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/deflect-missiles", "en"), Language = LanguageCode.En, Name = "Deflect Missiles", Description = "Starting at 3rd level, you can use your reaction to deflect or catch the missile when you are hit by a ranged weapon attack. When you do so, the damage you take from the attack is reduced by 1d10 + your Dexterity modifier + your monk level.\n\nIf you reduce the damage to 0, you can catch the missile if it is small enough for you to hold in one hand and you have at least one hand free. If you catch a missile in this way, you can spend 1 ki point to make a ranged attack with the weapon or piece of ammunition you just caught, as part of the same reaction. You make this attack with proficiency, regardless of your weapon proficiencies, and the missile counts as a monk weapon for the attack, which has a normal range of 20 feet and a long range of 60 feet." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/deflect-missiles", "it"), Language = LanguageCode.It, Name = "Deviare Proiettili", Description = "A partire dal 3° livello, quando è colpito da un attacco con un'arma a distanza, il monaco può usare la sua reazione per deviare o afferrare il proiettile. In questo caso, i danni che subisce dall'attacco sono ridotti di 1d10 + il suo modificatore di Destrezza + il suo livello da monaco.\n\nSe riduce i danni a 0, può afferrare il proiettile se è abbastanza piccolo da essere tenuto in una mano e se ha almeno una mano libera. Se afferra un proiettile in questo modo, può spendere 1 punto ki per effettuare un attacco a distanza con l'arma o la munizione appena afferrata, come parte della stessa reazione. Effettua questo attacco con competenza, a prescindere dalle sue competenze nelle armi, e per quell'attacco il proiettile conta come un'arma da monaco, con una gittata normale di 6 metri e una gittata lunga di 18 metri." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/slow-fall"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/slow-fall", "en"), Language = LanguageCode.En, Name = "Slow Fall", Description = "Beginning at 4th level, you can use your reaction when you fall to reduce any falling damage you take by an amount equal to five times your monk level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/slow-fall", "it"), Language = LanguageCode.It, Name = "Caduta Lenta", Description = "A partire dal 4° livello, quando cade, il monaco può usare la sua reazione per ridurre i danni da caduta che subisce di un ammontare pari a cinque volte il suo livello da monaco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Quando arriva al 4° livello, e poi all'8°, al 12°, al 16° e al 19° livello, il personaggio può aumentare di 2 un punteggio di caratteristica a sua scelta, oppure aumentare di 1 due punteggi di caratteristica a sua scelta. Come di consueto, questo privilegio non consente di aumentare un punteggio di caratteristica oltre 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 5,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "You can attack twice, instead of once, whenever you take the Attack action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Il monaco può attaccare due volte, anziché una, ogni volta che effettua l'azione di Attacco nel proprio turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/stunning-strike"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 5,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/stunning-strike", "en"), Language = LanguageCode.En, Name = "Stunning Strike", Description = "Starting at 5th level, you can interfere with the flow of ki in an opponent's body. When you hit another creature with a melee weapon attack, you can spend 1 ki point to attempt a stunning strike. The target must succeed on a Constitution saving throw or be stunned until the end of your next turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/stunning-strike", "it"), Language = LanguageCode.It, Name = "Colpo Stordente", Description = "A partire dal 5° livello, il monaco può interferire con il flusso del ki nel corpo di un avversario. Quando colpisce un'altra creatura con un attacco con un'arma da mischia, può spendere 1 punto ki per tentare un colpo stordente. Il bersaglio deve superare un tiro salvezza su Costituzione, altrimenti è stordito fino alla fine del turno successivo del monaco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/ki-empowered-strikes"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 13,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/ki-empowered-strikes", "en"), Language = LanguageCode.En, Name = "Ki-Empowered Strikes", Description = "Starting at 6th level, your unarmed strikes count as magical for the purpose of overcoming resistance and immunity to nonmagical attacks and damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/ki-empowered-strikes", "it"), Language = LanguageCode.It, Name = "Colpi Ki Potenziati", Description = "A partire dal 6° livello, i colpi senz'armi del monaco sono considerati magici ai fini di superare la resistenza e l'immunità agli attacchi e ai danni non magici." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/evasion"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 14,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/evasion", "en"), Language = LanguageCode.En, Name = "Evasion", Description = "At 7th level, your instinctive agility lets you dodge out of the way of certain area effects, such as a blue dragon's lightning breath or a *fireball* spell. When you are subjected to an effect that allows you to make a Dexterity saving throw to take only half damage, you instead take no damage if you succeed on the saving throw, and only half damage if you fail." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/evasion", "it"), Language = LanguageCode.It, Name = "Elusione", Description = "Al 7° livello l'agilità istintiva del monaco gli permette di sottrarsi ad alcuni effetti ad area, come il soffio fulminante di un drago blu o un incantesimo *palla di fuoco*. Quando è soggetto a un effetto che gli consente di effettuare un tiro salvezza su Destrezza per subire soltanto la metà dei danni, non subisce invece alcun danno se supera il tiro salvezza, e soltanto la metà dei danni se lo fallisce." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/stillness-of-mind"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 15,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/stillness-of-mind", "en"), Language = LanguageCode.En, Name = "Stillness of Mind", Description = "Starting at 7th level, you can use your action to end one effect on yourself that is causing you to be charmed or frightened." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/stillness-of-mind", "it"), Language = LanguageCode.It, Name = "Mente Lucida", Description = "A partire dal 7° livello, il monaco può usare la sua azione per porre fine a un effetto su di sé che lo rende affascinato o spaventato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/purity-of-body"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 16,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/purity-of-body", "en"), Language = LanguageCode.En, Name = "Purity of Body", Description = "At 10th level, your mastery of the ki flowing through you makes you immune to disease and poison." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/purity-of-body", "it"), Language = LanguageCode.It, Name = "Purezza del Corpo", Description = "Al 10° livello la padronanza del ki che scorre in lui rende il monaco immune alle malattie e ai veleni." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/tongue-of-the-sun-and-moon"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 13,
					SortOrder = 17,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/tongue-of-the-sun-and-moon", "en"), Language = LanguageCode.En, Name = "Tongue of the Sun and Moon", Description = "Starting at 13th level, you learn to touch the ki of other minds so that you understand all spoken languages. Moreover, any creature that can understand a language can understand what you say." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/tongue-of-the-sun-and-moon", "it"), Language = LanguageCode.It, Name = "Lingua del Sole e della Luna", Description = "A partire dal 13° livello, il monaco impara a toccare il ki di altre menti, così da comprendere tutti i linguaggi parlati. Inoltre, qualsiasi creatura in grado di comprendere un linguaggio può capire ciò che il monaco dice." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/diamond-soul"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 18,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/diamond-soul", "en"), Language = LanguageCode.En, Name = "Diamond Soul", Description = "Beginning at 14th level, your mastery of ki grants you proficiency in all saving throws. Additionally, whenever you make a saving throw and fail, you can spend 1 ki point to reroll it and take the second result." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/diamond-soul", "it"), Language = LanguageCode.It, Name = "Anima Adamantina", Description = "A partire dal 14° livello, la padronanza del ki conferisce al monaco competenza in tutti i tiri salvezza. Inoltre, ogni volta che effettua un tiro salvezza e lo fallisce, può spendere 1 punto ki per ripeterlo e deve usare il secondo risultato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/timeless-body"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 15,
					SortOrder = 19,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/timeless-body", "en"), Language = LanguageCode.En, Name = "Timeless Body", Description = "At 15th level, your ki sustains you so that you suffer none of the frailty of old age, and you can't be aged magically. You can still die of old age, however. In addition, you no longer need food or water." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/timeless-body", "it"), Language = LanguageCode.It, Name = "Corpo Senza Tempo", Description = "Al 15° livello il ki sostiene il monaco al punto che non soffre più degli acciacchi della vecchiaia e non può essere invecchiato magicamente. Può comunque morire di vecchiaia. Inoltre, non ha più bisogno di cibo né di acqua." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/empty-body"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 18,
					SortOrder = 20,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/empty-body", "en"), Language = LanguageCode.En, Name = "Empty Body", Description = "Beginning at 18th level, you can use your action to spend 4 ki points to become invisible for 1 minute. During that time, you also have resistance to all damage but force damage.\n\nAdditionally, you can spend 8 ki points to cast the *astral projection* spell, without needing material components. When you do so, you can't take any other creatures with you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/empty-body", "it"), Language = LanguageCode.It, Name = "Corpo Vuoto", Description = "A partire dal 18° livello, il monaco può usare la sua azione per spendere 4 punti ki e diventare invisibile per 1 minuto. Durante quel periodo ha anche resistenza a tutti i danni tranne quelli da forza.\n\nInoltre, può spendere 8 punti ki per lanciare l'incantesimo *proiezione astrale* senza bisogno delle componenti materiali. Quando lo fa, non può portare con sé altre creature." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/perfect-self"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 20,
					SortOrder = 21,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/perfect-self", "en"), Language = LanguageCode.En, Name = "Perfect Self", Description = "At 20th level, when you roll for initiative and have no ki points remaining, you regain 4 ki points." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "monk/perfect-self", "it"), Language = LanguageCode.It, Name = "Perfezione Interiore", Description = "Al 20° livello, quando tira per l'iniziativa e non gli resta alcun punto ki, il monaco recupera 4 punti ki." }
					}
				}
			}
		};
	}
}
