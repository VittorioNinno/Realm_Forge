using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Barbarian (2014 ruleset): class features of the SRD 5.1 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Barbarian2014Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "barbarian");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			HitDie = 12,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Strength },
			SavingThrows = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Constitution },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.AnimalHandling, Skill.Athletics, Skill.Intimidation, Skill.Nature, Skill.Perception, Skill.Survival },
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "barbarian", "en"),
					Language = LanguageCode.En,
					Name = "Barbarian",
					Description = "A fierce warrior who taps into a primal fury to shrug off blows and hit harder. Barbarians rely on raw toughness, heavy weapons and instinct rather than armor and training.",
					SubclassTitle = "Primal Path",
					ArmorProficiencies = "Light armor, medium armor, shields",
					WeaponProficiencies = "Simple weapons, martial weapons",
					ToolProficiencies = "None",
					StartingEquipment = "- (a) a greataxe or (b) any martial melee weapon\n- (a) two handaxes or (b) any simple weapon\n- An explorer's pack and four javelins",
					ProgressionTable = "| Level | Proficiency Bonus | Features | Rages | Rage Damage |\n|---|---|---|---|---|\n| 1st | +2 | Rage, Unarmored Defense | 2 | +2 |\n| 2nd | +2 | Reckless Attack, Danger Sense | 2 | +2 |\n| 3rd | +2 | Primal Path | 3 | +2 |\n| 4th | +2 | Ability Score Improvement | 3 | +2 |\n| 5th | +3 | Extra Attack, Fast Movement | 3 | +2 |\n| 6th | +3 | Path feature | 4 | +2 |\n| 7th | +3 | Feral Instinct | 4 | +2 |\n| 8th | +3 | Ability Score Improvement | 4 | +2 |\n| 9th | +4 | Brutal Critical (1 die) | 4 | +3 |\n| 10th | +4 | Path feature | 4 | +3 |\n| 11th | +4 | Relentless Rage | 4 | +3 |\n| 12th | +4 | Ability Score Improvement | 5 | +3 |\n| 13th | +5 | Brutal Critical (2 dice) | 5 | +3 |\n| 14th | +5 | Path feature | 5 | +3 |\n| 15th | +5 | Persistent Rage | 5 | +3 |\n| 16th | +5 | Ability Score Improvement | 5 | +4 |\n| 17th | +6 | Brutal Critical (3 dice) | 6 | +4 |\n| 18th | +6 | Indomitable Might | 6 | +4 |\n| 19th | +6 | Ability Score Improvement | 6 | +4 |\n| 20th | +6 | Primal Champion | Unlimited | +4 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "barbarian", "it"),
					Language = LanguageCode.It,
					Name = "Barbaro",
					Description = "Un guerriero feroce che attinge a una furia primordiale per incassare i colpi e colpire più forte. Il barbaro si affida alla tempra, alle armi pesanti e all'istinto più che all'armatura e all'addestramento.",
					SubclassTitle = "Cammino Primordiale",
					ArmorProficiencies = "Armature leggere, armature medie, scudi",
					WeaponProficiencies = "Armi semplici, armi da guerra",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "- (a) un'ascia bipenne o (b) una qualsiasi arma da guerra da mischia\n- (a) due asce o (b) una qualsiasi arma semplice\n- Una dotazione da esploratore e quattro giavellotti",
					ProgressionTable = "| Livello | Bonus di competenza | Privilegi | Ire | Danni da ira |\n|---|---|---|---|---|\n| 1° | +2 | Ira, Difesa Senza Armatura | 2 | +2 |\n| 2° | +2 | Attacco Irruento, Percezione del Pericolo | 2 | +2 |\n| 3° | +2 | Cammino Primordiale | 3 | +2 |\n| 4° | +2 | Aumento dei Punteggi di Caratteristica | 3 | +2 |\n| 5° | +3 | Attacco Extra, Movimento Veloce | 3 | +2 |\n| 6° | +3 | Privilegio del Cammino | 4 | +2 |\n| 7° | +3 | Istinto Ferino | 4 | +2 |\n| 8° | +3 | Aumento dei Punteggi di Caratteristica | 4 | +2 |\n| 9° | +4 | Critico Brutale (1 dado) | 4 | +3 |\n| 10° | +4 | Privilegio del Cammino | 4 | +3 |\n| 11° | +4 | Ira Implacabile | 4 | +3 |\n| 12° | +4 | Aumento dei Punteggi di Caratteristica | 5 | +3 |\n| 13° | +5 | Critico Brutale (2 dadi) | 5 | +3 |\n| 14° | +5 | Privilegio del Cammino | 5 | +3 |\n| 15° | +5 | Ira Persistente | 5 | +3 |\n| 16° | +5 | Aumento dei Punteggi di Caratteristica | 5 | +4 |\n| 17° | +6 | Critico Brutale (3 dadi) | 6 | +4 |\n| 18° | +6 | Potenza Indomabile | 6 | +4 |\n| 19° | +6 | Aumento dei Punteggi di Caratteristica | 6 | +4 |\n| 20° | +6 | Campione Primordiale | Illimitate | +4 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/rage"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/rage", "en"), Language = LanguageCode.En, Name = "Rage", Description = "In battle, you fight with primal ferocity. On your turn, you can enter a rage as a bonus action. While raging, you gain the following benefits if you aren't wearing heavy armor:\n- You have advantage on Strength checks and Strength saving throws.\n- When you make a melee weapon attack using Strength, you gain a bonus to the damage roll that increases as you gain levels as a barbarian, as shown in the Rage Damage column of the Barbarian table.\n- You have resistance to bludgeoning, piercing, and slashing damage.\n\nIf you are able to cast spells, you can't cast them or concentrate on them while raging. \n\nYour rage lasts for 1 minute. It ends early if you are knocked unconscious or if your turn ends and you haven't attacked a hostile creature since your last turn or taken damage since then. You can also end your rage on your turn as a bonus action. \n\nOnce you have raged the number of times shown for your barbarian level in the Rages column of the Barbarian table, you must finish a long rest before you can rage again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/rage", "it"), Language = LanguageCode.It, Name = "Ira", Description = "In battaglia il barbaro combatte con una ferocia primordiale. Nel suo turno può entrare in ira come azione bonus. Finché è in ira, se non indossa un'armatura pesante, ottiene i benefici seguenti:\n- Dispone di vantaggio alle prove di Forza e ai tiri salvezza su Forza.\n- Quando effettua un attacco con un'arma da mischia usando la Forza, ottiene un bonus al tiro per i danni che aumenta man mano che sale di livello come barbaro, come indicato nella colonna \"Danni da ira\" della tabella del Barbaro.\n- Ha resistenza ai danni contundenti, perforanti e taglienti.\n\nSe è in grado di lanciare incantesimi, non può lanciarli né mantenere la concentrazione su di essi mentre è in ira.\n\nL'ira dura 1 minuto. Termina prima se il barbaro perde i sensi o se il suo turno termina senza che, dal turno precedente, abbia attaccato una creatura ostile o subito danni. Il barbaro può anche porre fine all'ira nel proprio turno come azione bonus.\n\nUna volta entrato in ira il numero di volte indicato per il suo livello nella colonna \"Ire\" della tabella del Barbaro, deve completare un riposo lungo prima di poter entrare di nuovo in ira." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/unarmored-defense"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/unarmored-defense", "en"), Language = LanguageCode.En, Name = "Unarmored Defense", Description = "While you are not wearing any armor, your Armor Class equals 10 + your Dexterity modifier + your Constitution modifier. You can use a shield and still gain this benefit." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/unarmored-defense", "it"), Language = LanguageCode.It, Name = "Difesa Senza Armatura", Description = "Finché non indossa alcuna armatura, la Classe Armatura del barbaro è pari a 10 + il suo modificatore di Destrezza + il suo modificatore di Costituzione. Può usare uno scudo e continuare a beneficiare di questo privilegio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/reckless-attack"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/reckless-attack", "en"), Language = LanguageCode.En, Name = "Reckless Attack", Description = "Starting at 2nd level, you can throw aside all concern for defense to attack with fierce desperation.\n\nWhen you make your first attack on your turn, you can decide to attack recklessly. Doing so gives you advantage on melee weapon attack rolls using Strength during this turn, but attack rolls against you have advantage until your next turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/reckless-attack", "it"), Language = LanguageCode.It, Name = "Attacco Irruento", Description = "A partire dal 2° livello, il barbaro può mettere da parte ogni prudenza difensiva e attaccare con feroce disperazione.\n\nQuando effettua il primo attacco nel suo turno, può decidere di attaccare in modo irruento. In questo caso dispone di vantaggio ai tiri per colpire con le armi da mischia che usano la Forza durante quel turno, ma i tiri per colpire contro di lui hanno vantaggio fino al suo turno successivo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/danger-sense"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/danger-sense", "en"), Language = LanguageCode.En, Name = "Danger Sense", Description = "At 2nd level, you gain an uncanny sense of when things nearby aren't as they should be, giving you an edge when you dodge away from danger.\n\nYou have advantage on Dexterity saving throws against effects that you can see, such as traps and spells. To gain this benefit, you can't be blinded, deafened, or incapacitated." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/danger-sense", "it"), Language = LanguageCode.It, Name = "Percezione del Pericolo", Description = "Al 2° livello il barbaro sviluppa un sesto senso che lo avverte quando qualcosa nelle vicinanze non è come dovrebbe essere, e questo gli dà un vantaggio quando deve sottrarsi a un pericolo.\n\nIl barbaro dispone di vantaggio ai tiri salvezza su Destrezza contro gli effetti che è in grado di vedere, come trappole e incantesimi. Per ottenere questo beneficio non deve essere accecato, assordato o incapacitato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/primal-path"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/primal-path", "en"), Language = LanguageCode.En, Name = "Primal Path", Description = "At 3rd level, you choose a path that shapes the nature of your rage, such as the Path of the Berserker. Your choice grants you features at 3rd level and again at 6th, 10th, and 14th levels." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/primal-path", "it"), Language = LanguageCode.It, Name = "Cammino Primordiale", Description = "Al 3° livello il barbaro sceglie un cammino che plasma la natura della sua ira, come il Cammino del Berserker. La scelta gli conferisce privilegi al 3° livello e poi al 6°, al 10° e al 14° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Quando arriva al 4° livello, e poi all'8°, al 12°, al 16° e al 19° livello, il personaggio può aumentare di 2 un punteggio di caratteristica a sua scelta, oppure aumentare di 1 due punteggi di caratteristica a sua scelta. Come di consueto, questo privilegio non consente di aumentare un punteggio di caratteristica oltre 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 5,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "You can attack twice, instead of once, whenever you take the Attack action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Il barbaro può attaccare due volte, anziché una, ogni volta che effettua l'azione di Attacco nel proprio turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/fast-movement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 5,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/fast-movement", "en"), Language = LanguageCode.En, Name = "Fast Movement", Description = "Your speed increases by 10 feet while you aren't wearing heavy armor." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/fast-movement", "it"), Language = LanguageCode.It, Name = "Movimento Veloce", Description = "La velocità del barbaro aumenta di 3 metri finché non indossa un'armatura pesante." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/feral-instinct"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/feral-instinct", "en"), Language = LanguageCode.En, Name = "Feral Instinct", Description = "By 7th level, your instincts are so honed that you have advantage on initiative rolls.\n\nAdditionally, if you are surprised at the beginning of combat and aren't incapacitated, you can act normally on your first turn, but only if you enter your rage before doing anything else on that turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/feral-instinct", "it"), Language = LanguageCode.It, Name = "Istinto Ferino", Description = "Al 7° livello l'istinto del barbaro è così affinato che dispone di vantaggio ai tiri per l'iniziativa.\n\nInoltre, se è sorpreso all'inizio di un combattimento e non è incapacitato, può agire normalmente nel suo primo turno, ma solo se entra in ira prima di fare qualsiasi altra cosa in quel turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/brutal-critical"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 9,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/brutal-critical", "en"), Language = LanguageCode.En, Name = "Brutal Critical", Description = "Beginning at 9th level, you can roll one additional weapon damage die when determining the extra damage for a critical hit with a melee attack. This increases to two additional dice at 13th level and three additional dice at 17th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/brutal-critical", "it"), Language = LanguageCode.It, Name = "Critico Brutale", Description = "A partire dal 9° livello, quando determina i danni extra di un colpo critico con un attacco in mischia, il barbaro può tirare un dado di danno dell'arma aggiuntivo. Il numero di dadi aggiuntivi sale a due al 13° livello e a tre al 17° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/relentless-rage"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 11,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/relentless-rage", "en"), Language = LanguageCode.En, Name = "Relentless Rage", Description = "Starting at 11th level, your rage can keep you fighting despite grievous wounds.\n\nIf you drop to 0 hit points while you're raging and don't die outright, you can make a DC 10 Constitution saving throw. If you succeed, you drop to 1 hit point instead.\n\nEach time you use this feature after the first, the DC increases by 5. When you finish a short or long rest, the DC resets to 10." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/relentless-rage", "it"), Language = LanguageCode.It, Name = "Ira Implacabile", Description = "A partire dall'11° livello, l'ira consente al barbaro di continuare a combattere nonostante le ferite più gravi.\n\nSe scende a 0 punti ferita mentre è in ira e non muore sul colpo, può effettuare un tiro salvezza su Costituzione con CD 10. Se lo supera, scende invece a 1 punto ferita.\n\nOgni volta che usa questo privilegio dopo la prima, la CD aumenta di 5. Quando completa un riposo breve o lungo, la CD torna a 10." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/persistent-rage"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 15,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/persistent-rage", "en"), Language = LanguageCode.En, Name = "Persistent Rage", Description = "Beginning at 15th level, your Rage is so fierce that it ends early only if you fall unconscious or if you choose to end it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/persistent-rage", "it"), Language = LanguageCode.It, Name = "Ira Persistente", Description = "A partire dal 15° livello, l'ira del barbaro è così intensa che termina prima del tempo soltanto se perde i sensi o se decide lui stesso di porvi fine." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/indomitable-might"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 18,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/indomitable-might", "en"), Language = LanguageCode.En, Name = "Indomitable Might", Description = "Beginning at 18th level, if your total for a Strength check is less than your Strength score, you can use that score in place of the total." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/indomitable-might", "it"), Language = LanguageCode.It, Name = "Potenza Indomabile", Description = "A partire dal 18° livello, se il totale di una prova di Forza del barbaro è inferiore al suo punteggio di Forza, può usare quel punteggio al posto del totale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/primal-champion"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 20,
					SortOrder = 13,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/primal-champion", "en"), Language = LanguageCode.En, Name = "Primal Champion", Description = "At 20th level, you embody the power of the wilds. Your Strength and Constitution scores increase by 4. Your maximum for those scores is now 24." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "barbarian/primal-champion", "it"), Language = LanguageCode.It, Name = "Campione Primordiale", Description = "Al 20° livello il barbaro incarna il potere delle terre selvagge. I suoi punteggi di Forza e di Costituzione aumentano di 4, e il massimo per quei punteggi diventa 24." }
					}
				}
			}
		};
	}
}
