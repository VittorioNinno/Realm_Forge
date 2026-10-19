using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Rogue (2014 ruleset): class features of the SRD 5.1 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Rogue2014Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "rogue");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			HitDie = 8,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Dexterity },
			SavingThrows = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Intelligence },
			SkillChoiceCount = 4,
			SkillOptions = new List<Skill> { Skill.Acrobatics, Skill.Athletics, Skill.Deception, Skill.Insight, Skill.Intimidation, Skill.Investigation, Skill.Perception, Skill.Performance, Skill.Persuasion, Skill.SleightOfHand, Skill.Stealth },
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "rogue", "en"),
					Language = LanguageCode.En,
					Name = "Rogue",
					Description = "A skilled expert in stealth, finesse and trickery. Rogues pick locks, disarm traps and slip through shadows, and in a fight they wait for an opening to land a precise, devastating sneak attack.",
					SubclassTitle = "Roguish Archetype",
					ArmorProficiencies = "Light armor",
					WeaponProficiencies = "Simple weapons, hand crossbows, longswords, rapiers, shortswords",
					ToolProficiencies = "Thieves' tools",
					StartingEquipment = "- (a) a rapier or (b) a shortsword\n- (a) a shortbow and quiver of 20 arrows or (b) a shortsword\n- (a) a burglar’s pack, (b) a dungeoneer’s pack, or (c) an explorer’s pack\n- Leather armor, two daggers, and thieves' tools",
					ProgressionTable = "| Level | Proficiency Bonus | Features | Sneak Attack |\n|---|---|---|---|\n| 1st | +2 | Expertise, Sneak Attack, Thieves' Cant | 1d6 |\n| 2nd | +2 | Cunning Action | 1d6 |\n| 3rd | +2 | Roguish Archetype | 2d6 |\n| 4th | +2 | Ability Score Improvement | 2d6 |\n| 5th | +3 | Uncanny Dodge | 3d6 |\n| 6th | +3 | Expertise | 3d6 |\n| 7th | +3 | Evasion | 4d6 |\n| 8th | +3 | Ability Score Improvement | 4d6 |\n| 9th | +4 | Roguish Archetype feature | 5d6 |\n| 10th | +4 | Ability Score Improvement | 5d6 |\n| 11th | +4 | Reliable Talent | 6d6 |\n| 12th | +4 | Ability Score Improvement | 6d6 |\n| 13th | +5 | Roguish Archetype feature | 7d6 |\n| 14th | +5 | Blindsense | 7d6 |\n| 15th | +5 | Slippery Mind | 8d6 |\n| 16th | +5 | Ability Score Improvement | 8d6 |\n| 17th | +6 | Roguish Archetype feature | 9d6 |\n| 18th | +6 | Elusive | 9d6 |\n| 19th | +6 | Ability Score Improvement | 10d6 |\n| 20th | +6 | Stroke of Luck | 10d6 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "rogue", "it"),
					Language = LanguageCode.It,
					Name = "Ladro",
					Description = "Un esperto di furtività, destrezza e inganno. Il ladro scassina serrature, disattiva trappole e scivola tra le ombre, e in combattimento attende il momento giusto per sferrare un attacco furtivo preciso e devastante.",
					SubclassTitle = "Archetipo Ladresco",
					ArmorProficiencies = "Armature leggere",
					WeaponProficiencies = "Armi semplici, balestre a mano, spade corte, spade lunghe, stocchi",
					ToolProficiencies = "Arnesi da scasso",
					StartingEquipment = "- (a) uno stocco o (b) una spada corta\n- (a) un arco corto e una faretra con 20 frecce o (b) una spada corta\n- (a) una dotazione da scassinatore, (b) una dotazione da avventuriero o (c) una dotazione da esploratore\n- Un'armatura di cuoio, due pugnali e arnesi da scasso",
					ProgressionTable = "| Livello | Bonus di competenza | Privilegi | Attacco furtivo |\n|---|---|---|---|\n| 1° | +2 | Maestria, Attacco Furtivo, Gergo Ladresco | 1d6 |\n| 2° | +2 | Azione Scaltra | 1d6 |\n| 3° | +2 | Archetipo Ladresco | 2d6 |\n| 4° | +2 | Aumento dei Punteggi di Caratteristica | 2d6 |\n| 5° | +3 | Schivata Prodigiosa | 3d6 |\n| 6° | +3 | Maestria | 3d6 |\n| 7° | +3 | Elusione | 4d6 |\n| 8° | +3 | Aumento dei Punteggi di Caratteristica | 4d6 |\n| 9° | +4 | Privilegio dell'Archetipo Ladresco | 5d6 |\n| 10° | +4 | Aumento dei Punteggi di Caratteristica | 5d6 |\n| 11° | +4 | Dote Affidabile | 6d6 |\n| 12° | +4 | Aumento dei Punteggi di Caratteristica | 6d6 |\n| 13° | +5 | Privilegio dell'Archetipo Ladresco | 7d6 |\n| 14° | +5 | Percezione Cieca | 7d6 |\n| 15° | +5 | Mente Sfuggente | 8d6 |\n| 16° | +5 | Aumento dei Punteggi di Caratteristica | 8d6 |\n| 17° | +6 | Privilegio dell'Archetipo Ladresco | 9d6 |\n| 18° | +6 | Inafferrabile | 9d6 |\n| 19° | +6 | Aumento dei Punteggi di Caratteristica | 10d6 |\n| 20° | +6 | Colpo di Fortuna | 10d6 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/expertise"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/expertise", "en"), Language = LanguageCode.En, Name = "Expertise", Description = "At 1st level, choose two of your skill proficiencies, or one of your skill proficiencies and your proficiency with thieves' tools. Your proficiency bonus is doubled for any ability check you make that uses either of the chosen proficiencies.\n\nAt 6th level, you can choose two more of your proficiencies (in skills or with thieves' tools) to gain this benefit." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/expertise", "it"), Language = LanguageCode.It, Name = "Maestria", Description = "Al 1° livello il ladro sceglie due delle sue competenze nelle abilità, oppure una delle sue competenze nelle abilità e la sua competenza negli arnesi da scasso. Il suo bonus di competenza raddoppia per qualsiasi prova di caratteristica che effettua usando una delle competenze scelte.\n\nAl 6° livello può scegliere altre due delle sue competenze (nelle abilità o negli arnesi da scasso) che ottengono questo beneficio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/sneak-attack"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/sneak-attack", "en"), Language = LanguageCode.En, Name = "Sneak Attack", Description = "Beginning at 1st level, you know how to strike subtly and exploit a foe's distraction. Once per turn, you can deal an extra 1d6 damage to one creature you hit with an attack if you have advantage on the attack roll. The attack must use a finesse or a ranged weapon.\n\nYou don't need advantage on the attack roll if another enemy of the target is within 5 feet of it, that enemy isn't incapacitated, and you don't have disadvantage on the attack roll.\n\nThe amount of the extra damage increases as you gain levels in this class, as shown in the Sneak Attack column of the Rogue table." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/sneak-attack", "it"), Language = LanguageCode.It, Name = "Attacco Furtivo", Description = "A partire dal 1° livello, il ladro sa come colpire con astuzia e sfruttare la distrazione di un nemico. Una volta per turno, può infliggere 1d6 danni extra a una creatura che colpisce con un attacco, se dispone di vantaggio al tiro per colpire. L'attacco deve essere effettuato con un'arma accurata o con un'arma a distanza.\n\nIl ladro non ha bisogno di vantaggio al tiro per colpire se un altro nemico del bersaglio si trova entro 1,5 metri da esso, se quel nemico non è incapacitato e se il ladro non subisce svantaggio al tiro per colpire.\n\nL'ammontare dei danni extra aumenta man mano che il ladro sale di livello in questa classe, come indicato nella colonna \"Attacco furtivo\" della tabella del Ladro." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/thieves-cant"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/thieves-cant", "en"), Language = LanguageCode.En, Name = "Thieves' Cant", Description = "During your rogue training you learned thieves' cant, a secret mix of dialect, jargon, and code that allows you to hide messages in seemingly normal conversation. Only another creature that knows thieves' cant understands such messages. It takes four times longer to convey such a message than it does to speak the same idea plainly.\n\nIn addition, you understand a set of secret signs and symbols used to convey short, simple messages, such as whether an area is dangerous or the territory of a thieves' guild, whether loot is nearby, or whether the people in an area are easy marks or will provide a safe house for thieves on the run." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/thieves-cant", "it"), Language = LanguageCode.It, Name = "Gergo Ladresco", Description = "Durante il suo addestramento il ladro ha imparato il gergo ladresco, un miscuglio segreto di dialetto, termini specialistici e codici che permette di nascondere messaggi all'interno di conversazioni apparentemente normali. Soltanto un'altra creatura che conosce il gergo ladresco comprende questi messaggi. Trasmettere un messaggio del genere richiede quattro volte più tempo che esprimere lo stesso concetto in modo esplicito.\n\nInoltre il ladro comprende un insieme di segni e simboli segreti usati per trasmettere messaggi brevi e semplici, come se una zona è pericolosa o è territorio di una gilda dei ladri, se c'è un bottino nelle vicinanze, o se gli abitanti di una zona sono facili da raggirare o offrono un rifugio sicuro ai ladri in fuga." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/cunning-action"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/cunning-action", "en"), Language = LanguageCode.En, Name = "Cunning Action", Description = "Starting at 2nd level, your quick thinking and agility allow you to move and act quickly. You can take a bonus action on each of your turns in combat. This action can be used only to take the Dash, Disengage, or Hide action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/cunning-action", "it"), Language = LanguageCode.It, Name = "Azione Scaltra", Description = "A partire dal 2° livello, la rapidità di pensiero e l'agilità del ladro gli permettono di muoversi e agire in fretta. Può effettuare un'azione bonus in ognuno dei suoi turni in combattimento. Questa azione può essere usata soltanto per effettuare l'azione di Scatto, Disimpegno o Nascondersi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/roguish-archetype"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/roguish-archetype", "en"), Language = LanguageCode.En, Name = "Roguish Archetype", Description = "At 3rd level, you choose an archetype that you emulate in the exercise of your rogue abilities, such as Thief. Your archetype choice grants you features at 3rd level and then again at 9th, 13th, and 17th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/roguish-archetype", "it"), Language = LanguageCode.It, Name = "Archetipo Ladresco", Description = "Al 3° livello il ladro sceglie un archetipo da emulare nell'esercizio delle sue capacità, come il Furfante. La scelta gli conferisce privilegi al 3° livello e poi al 9°, al 13° e al 17° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "When you reach 4th level, and again at 8th, 10th, 12th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Quando arriva al 4° livello, e poi all'8°, al 10°, al 12°, al 16° e al 19° livello, il personaggio può aumentare di 2 un punteggio di caratteristica a sua scelta, oppure aumentare di 1 due punteggi di caratteristica a sua scelta. Come di consueto, questo privilegio non consente di aumentare un punteggio di caratteristica oltre 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/uncanny-dodge"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 5,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/uncanny-dodge", "en"), Language = LanguageCode.En, Name = "Uncanny Dodge", Description = "Starting at 5th level, when an attacker that you can see hits you with an attack, you can use your reaction to halve the attack's damage against you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/uncanny-dodge", "it"), Language = LanguageCode.It, Name = "Schivata Prodigiosa", Description = "A partire dal 5° livello, quando un attaccante che il ladro è in grado di vedere lo colpisce con un attacco, il ladro può usare la sua reazione per dimezzare i danni dell'attacco contro di lui." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/evasion"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/evasion", "en"), Language = LanguageCode.En, Name = "Evasion", Description = "At 7th level, your instinctive agility lets you dodge out of the way of certain area effects, such as a blue dragon's lightning breath or a *fireball* spell. When you are subjected to an effect that allows you to make a Dexterity saving throw to take only half damage, you instead take no damage if you succeed on the saving throw, and only half damage if you fail." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/evasion", "it"), Language = LanguageCode.It, Name = "Elusione", Description = "Al 7° livello l'agilità istintiva del ladro gli permette di sottrarsi ad alcuni effetti ad area, come il soffio fulminante di un drago blu o un incantesimo *palla di fuoco*. Quando è soggetto a un effetto che gli consente di effettuare un tiro salvezza su Destrezza per subire soltanto la metà dei danni, non subisce invece alcun danno se supera il tiro salvezza, e soltanto la metà dei danni se lo fallisce." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/reliable-talent"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 11,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/reliable-talent", "en"), Language = LanguageCode.En, Name = "Reliable Talent", Description = "By 11th level, you have refined your chosen skills until they approach perfection. Whenever you make an ability check that lets you add your proficiency bonus, you can treat a d20 roll of 9 or lower as a 10." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/reliable-talent", "it"), Language = LanguageCode.It, Name = "Dote Affidabile", Description = "All'11° livello il ladro ha affinato le abilità scelte fino a sfiorare la perfezione. Ogni volta che effettua una prova di caratteristica che gli consente di aggiungere il suo bonus di competenza, può considerare un risultato di 9 o inferiore al d20 come un 10." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/blindsense"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/blindsense", "en"), Language = LanguageCode.En, Name = "Blindsense", Description = "Starting at 14th level, if you are able to hear, you are aware of the location of any hidden or invisible creature within 10 feet of you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/blindsense", "it"), Language = LanguageCode.It, Name = "Percezione Cieca", Description = "A partire dal 14° livello, se è in grado di sentire, il ladro è consapevole della posizione di qualsiasi creatura nascosta o invisibile entro 3 metri da lui." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/slippery-mind"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 15,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/slippery-mind", "en"), Language = LanguageCode.En, Name = "Slippery Mind", Description = "By 15th level, you have acquired greater mental strength. You gain proficiency in Wisdom saving throws." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/slippery-mind", "it"), Language = LanguageCode.It, Name = "Mente Sfuggente", Description = "Al 15° livello il ladro ha acquisito una maggiore forza mentale. Ottiene competenza nei tiri salvezza su Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/elusive"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 18,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/elusive", "en"), Language = LanguageCode.En, Name = "Elusive", Description = "Beginning at 18th level, you are so evasive that attackers rarely gain the upper hand against you. No attack roll has advantage against you while you aren't incapacitated." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/elusive", "it"), Language = LanguageCode.It, Name = "Inafferrabile", Description = "A partire dal 18° livello, il ladro è così sfuggente che raramente un attaccante riesce ad avere la meglio su di lui. Nessun tiro per colpire contro di lui ha vantaggio finché non è incapacitato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/stroke-of-luck"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 20,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/stroke-of-luck", "en"), Language = LanguageCode.En, Name = "Stroke of Luck", Description = "At 20th level, you have an uncanny knack for succeeding when you need to. If your attack misses a target within range, you can turn the miss into a hit. Alternatively, if you fail an ability check, you can treat the d20 roll as a 20.\n\nOnce you use this feature, you can't use it again until you finish a short or long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "rogue/stroke-of-luck", "it"), Language = LanguageCode.It, Name = "Colpo di Fortuna", Description = "Al 20° livello il ladro ha un talento prodigioso per riuscire quando ne ha bisogno. Se un suo attacco manca un bersaglio entro gittata, può trasformare il mancato colpo in un colpo andato a segno. In alternativa, se fallisce una prova di caratteristica, può considerare il risultato del d20 come un 20.\n\nUna volta usato questo privilegio, non può usarlo di nuovo finché non completa un riposo breve o lungo." }
					}
				}
			}
		};
	}
}
