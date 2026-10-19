using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Fighter (2014 ruleset): class features of the SRD 5.1 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Fighter2014Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "fighter");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			HitDie = 10,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity },
			SavingThrows = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Constitution },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.Acrobatics, Skill.AnimalHandling, Skill.Athletics, Skill.History, Skill.Insight, Skill.Intimidation, Skill.Perception, Skill.Survival },
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "fighter", "en"),
					Language = LanguageCode.En,
					Name = "Fighter",
					Description = "A master of weapons and armor. Fighters learn every combat style, recover quickly in the middle of a fight and attack more often than anyone else, whether they rely on raw strength, tactics or a touch of magic.",
					SubclassTitle = "Martial Archetype",
					ArmorProficiencies = "All armor, shields",
					WeaponProficiencies = "Simple weapons, martial weapons",
					ToolProficiencies = "None",
					StartingEquipment = "- (a) chain mail or (b) leather armor, longbow, and 20 arrows\n- (a) a martial weapon and a shield or (b) two martial weapons\n- (a) a light crossbow and 20 bolts or (b) two handaxes\n- (a) a dungeoneer’s pack or (b) an explorer’s pack",
					ProgressionTable = "| Level | Proficiency Bonus | Features |\n|---|---|---|\n| 1st | +2 | Fighting Style, Second Wind |\n| 2nd | +2 | Action Surge (one use) |\n| 3rd | +2 | Martial Archetype |\n| 4th | +2 | Ability Score Improvement |\n| 5th | +3 | Extra Attack |\n| 6th | +3 | Ability Score Improvement |\n| 7th | +3 | Martial Archetype feature |\n| 8th | +3 | Ability Score Improvement |\n| 9th | +4 | Indomitable (one use) |\n| 10th | +4 | Martial Archetype feature |\n| 11th | +4 | Extra Attack (2) |\n| 12th | +4 | Ability Score Improvement |\n| 13th | +5 | Indomitable (two uses) |\n| 14th | +5 | Ability Score Improvement |\n| 15th | +5 | Martial Archetype feature |\n| 16th | +5 | Ability Score Improvement |\n| 17th | +6 | Action Surge (two uses), Indomitable (three uses) |\n| 18th | +6 | Martial Archetype feature |\n| 19th | +6 | Ability Score Improvement |\n| 20th | +6 | Extra Attack (3) |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "fighter", "it"),
					Language = LanguageCode.It,
					Name = "Guerriero",
					Description = "Un maestro delle armi e delle armature. Il guerriero conosce ogni stile di combattimento, si riprende in fretta nel mezzo di uno scontro e attacca più spesso di chiunque altro, che si affidi alla forza bruta, alla tattica o a un pizzico di magia.",
					SubclassTitle = "Archetipo Marziale",
					ArmorProficiencies = "Tutte le armature, scudi",
					WeaponProficiencies = "Armi semplici, armi da guerra",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "- (a) una cotta di maglia o (b) un'armatura di cuoio, un arco lungo e 20 frecce\n- (a) un'arma da guerra e uno scudo o (b) due armi da guerra\n- (a) una balestra leggera e 20 quadrelli o (b) due asce\n- (a) una dotazione da avventuriero o (b) una dotazione da esploratore",
					ProgressionTable = "| Livello | Bonus di competenza | Privilegi |\n|---|---|---|\n| 1° | +2 | Stile di Combattimento, Recuperare Energie |\n| 2° | +2 | Azione Impetuosa (un utilizzo) |\n| 3° | +2 | Archetipo Marziale |\n| 4° | +2 | Aumento dei Punteggi di Caratteristica |\n| 5° | +3 | Attacco Extra |\n| 6° | +3 | Aumento dei Punteggi di Caratteristica |\n| 7° | +3 | Privilegio dell'Archetipo Marziale |\n| 8° | +3 | Aumento dei Punteggi di Caratteristica |\n| 9° | +4 | Indomito (un utilizzo) |\n| 10° | +4 | Privilegio dell'Archetipo Marziale |\n| 11° | +4 | Attacco Extra (2) |\n| 12° | +4 | Aumento dei Punteggi di Caratteristica |\n| 13° | +5 | Indomito (due utilizzi) |\n| 14° | +5 | Aumento dei Punteggi di Caratteristica |\n| 15° | +5 | Privilegio dell'Archetipo Marziale |\n| 16° | +5 | Aumento dei Punteggi di Caratteristica |\n| 17° | +6 | Azione Impetuosa (due utilizzi), Indomito (tre utilizzi) |\n| 18° | +6 | Privilegio dell'Archetipo Marziale |\n| 19° | +6 | Aumento dei Punteggi di Caratteristica |\n| 20° | +6 | Attacco Extra (3) |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/fighting-style"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/fighting-style", "en"), Language = LanguageCode.En, Name = "Fighting Style", Description = "You adopt a particular style of fighting as your specialty. Choose one of the following options. You can't take a Fighting Style option more than once, even if you later get to choose again.\n\n***Archery.*** You gain a +2 bonus to attack rolls you make with ranged weapons.\n\n***Defense.*** While you are wearing armor, you gain a +1 bonus to AC.\n\n***Dueling.*** When you are wielding a melee weapon in one hand and no other weapons, you gain a +2 bonus to damage rolls with that weapon.\n\n***Great Weapon Fighting.*** When you roll a 1 or 2 on a damage die for an attack you make with a melee weapon that you are wielding with two hands, you can reroll the die and must use the new roll, even if the new roll is a 1 or a 2. The weapon must have the two-handed or versatile property for you to gain this benefit.\n\n***Protection.*** When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your reaction to impose disadvantage on the attack roll. You must be wielding a shield.\n\n***Two-Weapon Fighting.*** When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second attack." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/fighting-style", "it"), Language = LanguageCode.It, Name = "Stile di Combattimento", Description = "Il guerriero adotta come specialità un particolare stile di combattimento. Sceglie una delle opzioni seguenti. Non può scegliere più di una volta la stessa opzione di Stile di Combattimento, anche se in seguito ha la possibilità di sceglierne un'altra.\n\n***Tiro.*** Il personaggio ottiene un bonus di +2 ai tiri per colpire effettuati con le armi a distanza.\n\n***Difesa.*** Finché indossa un'armatura, il personaggio ottiene un bonus di +1 alla CA.\n\n***Duellare.*** Quando impugna un'arma da mischia in una mano e nessun'altra arma, il personaggio ottiene un bonus di +2 ai tiri per i danni effettuati con quell'arma.\n\n***Combattere con Armi Possenti.*** Quando ottiene 1 o 2 a un dado di danno per un attacco effettuato con un'arma da mischia impugnata a due mani, il personaggio può ripetere il tiro di quel dado e deve usare il nuovo risultato, anche se è di nuovo 1 o 2. Per ottenere questo beneficio, l'arma deve avere la proprietà a due mani o versatile.\n\n***Protezione.*** Quando una creatura che il personaggio è in grado di vedere attacca un bersaglio diverso da lui che si trova entro 1,5 metri da lui, il personaggio può usare la sua reazione per imporre svantaggio al tiro per colpire. Deve impugnare uno scudo.\n\n***Combattere con Due Armi.*** Quando combatte con due armi, il personaggio può aggiungere il suo modificatore di caratteristica ai danni del secondo attacco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/second-wind"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/second-wind", "en"), Language = LanguageCode.En, Name = "Second Wind", Description = "You have a limited well of stamina that you can draw on to protect yourself from harm. On your turn, you can use a bonus action to regain hit points equal to 1d10 + your fighter level.\n\nOnce you use this feature, you must finish a short or long rest before you can use it again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/second-wind", "it"), Language = LanguageCode.It, Name = "Recuperare Energie", Description = "Il guerriero dispone di una riserva limitata di resistenza a cui può attingere per proteggersi. Nel suo turno, può usare un'azione bonus per recuperare punti ferita pari a 1d10 + il suo livello da guerriero.\n\nUna volta usato questo privilegio, deve completare un riposo breve o lungo prima di poterlo usare di nuovo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/action-surge"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/action-surge", "en"), Language = LanguageCode.En, Name = "Action Surge", Description = "Starting at 2nd level, you can push yourself beyond your normal limits for a moment. On your turn, you can take one additional action on top of your regular action and a possible bonus action.\n\nOnce you use this feature, you must finish a short or long rest before you can use it again. Starting at 17th level, you can use it twice before a rest, but only once on the same turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/action-surge", "it"), Language = LanguageCode.It, Name = "Azione Impetuosa", Description = "A partire dal 2° livello, il guerriero può spingersi oltre i propri normali limiti per un momento. Nel suo turno, può effettuare un'azione aggiuntiva oltre alla sua normale azione e a un'eventuale azione bonus.\n\nUna volta usato questo privilegio, deve completare un riposo breve o lungo prima di poterlo usare di nuovo. A partire dal 17° livello può usarlo due volte prima di un riposo, ma soltanto una volta nello stesso turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/martial-archetype"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/martial-archetype", "en"), Language = LanguageCode.En, Name = "Martial Archetype", Description = "At 3rd level, you choose an archetype that you strive to emulate in your combat styles and techniques, such as Champion. The archetype you choose grants you features at 3rd level and again at 7th, 10th, 15th, and 18th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/martial-archetype", "it"), Language = LanguageCode.It, Name = "Archetipo Marziale", Description = "Al 3° livello il guerriero sceglie un archetipo che si sforza di emulare nel suo stile e nelle sue tecniche di combattimento, come il Campione. L'archetipo scelto gli conferisce privilegi al 3° livello e poi al 7°, al 10°, al 15° e al 18° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "When you reach 4th level, and again at 6th, 8th, 12th, 14th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Quando arriva al 4° livello, e poi al 6°, all'8°, al 12°, al 14°, al 16° e al 19° livello, il personaggio può aumentare di 2 un punteggio di caratteristica a sua scelta, oppure aumentare di 1 due punteggi di caratteristica a sua scelta. Come di consueto, questo privilegio non consente di aumentare un punteggio di caratteristica oltre 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 5,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "You can attack twice, instead of once, whenever you take the Attack action on your turn.\n\nThe number of attacks increases to three when you reach 11th level in this class and to four when you reach 20th level in this class." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Il guerriero può attaccare due volte, anziché una, ogni volta che effettua l'azione di Attacco nel proprio turno.\n\nIl numero di attacchi sale a tre quando raggiunge l'11° livello in questa classe e a quattro quando raggiunge il 20° livello in questa classe." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/indomitable"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 9,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/indomitable", "en"), Language = LanguageCode.En, Name = "Indomitable", Description = "You can reroll a saving throw that you fail. If you do so, you must use the new roll, and you can't use this feature again until you finish a long rest.\n\nYou can use this feature twice between long rests starting at 13th level and three times between long rests starting at 17th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "fighter/indomitable", "it"), Language = LanguageCode.It, Name = "Indomito", Description = "Il guerriero può ripetere un tiro salvezza fallito. Se lo fa, deve usare il nuovo risultato e non può usare di nuovo questo privilegio finché non completa un riposo lungo.\n\nA partire dal 13° livello può usare questo privilegio due volte tra un riposo lungo e l'altro, e a partire dal 17° livello tre volte." }
					}
				}
			}
		};
	}
}
