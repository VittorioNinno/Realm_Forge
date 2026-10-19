using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Barbarian (2024 ruleset): class features of the SRD 5.2 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Barbarian2024Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "barbarian");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "barbarian", "en"),
					Language = LanguageCode.En,
					Name = "Barbarian",
					Description = "A fierce warrior driven by a primal Rage. Barbarians shrug off blows that would fell others, strike with reckless power and trust their instincts and senses to carry them through danger.",
					SubclassTitle = "Barbarian Subclass",
					ArmorProficiencies = "Light and Medium armor; Shields",
					WeaponProficiencies = "Simple and Martial weapons",
					ToolProficiencies = "None",
					StartingEquipment = "Choose A or B:\n- (A) Greataxe, 4 Handaxes, Explorer's Pack and 15 GP\n- (B) 75 GP",
					ProgressionTable = "| Level | Proficiency Bonus | Class Features | Rages | Rage Damage | Weapon Mastery |\n|---|---|---|---|---|---|\n| 1 | +2 | Rage, Unarmored Defense, Weapon Mastery | 2 | +2 | 2 |\n| 2 | +2 | Danger Sense, Reckless Attack | 2 | +2 | 2 |\n| 3 | +2 | Barbarian Subclass, Primal Knowledge | 3 | +2 | 2 |\n| 4 | +2 | Ability Score Improvement | 3 | +2 | 3 |\n| 5 | +3 | Extra Attack, Fast Movement | 3 | +2 | 3 |\n| 6 | +3 | Subclass feature | 4 | +2 | 3 |\n| 7 | +3 | Feral Instinct, Instinctive Pounce | 4 | +2 | 3 |\n| 8 | +3 | Ability Score Improvement | 4 | +2 | 3 |\n| 9 | +4 | Brutal Strike | 4 | +3 | 3 |\n| 10 | +4 | Subclass feature | 4 | +3 | 4 |\n| 11 | +4 | Relentless Rage | 4 | +3 | 4 |\n| 12 | +4 | Ability Score Improvement | 5 | +3 | 4 |\n| 13 | +5 | Improved Brutal Strike | 5 | +3 | 4 |\n| 14 | +5 | Subclass feature | 5 | +3 | 4 |\n| 15 | +5 | Persistent Rage | 5 | +3 | 4 |\n| 16 | +5 | Ability Score Improvement | 5 | +4 | 4 |\n| 17 | +6 | Improved Brutal Strike | 6 | +4 | 4 |\n| 18 | +6 | Indomitable Might | 6 | +4 | 4 |\n| 19 | +6 | Epic Boon | 6 | +4 | 4 |\n| 20 | +6 | Primal Champion | 6 | +4 | 4 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "barbarian", "it"),
					Language = LanguageCode.It,
					Name = "Barbaro",
					Description = "Un guerriero feroce mosso da un'ira primordiale. Il barbaro incassa colpi che abbatterebbero chiunque altro, colpisce con una forza sconsiderata e si affida all'istinto e ai sensi per superare i pericoli.",
					SubclassTitle = "Sottoclasse del barbaro",
					ArmorProficiencies = "Armature leggere e medie; scudi",
					WeaponProficiencies = "Armi semplici e da guerra",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "A scelta tra A e B:\n- (A) un'ascia bipenne, 4 asce, una dotazione da esploratore e 15 mo\n- (B) 75 mo",
					ProgressionTable = "| Livello | Bonus di competenza | Privilegi di classe | Ire | Danni dell'ira | Padronanza delle armi |\n|---|---|---|---|---|---|\n| 1 | +2 | Ira, Difesa Senza Armatura, Padronanza delle Armi | 2 | +2 | 2 |\n| 2 | +2 | Percezione del Pericolo, Attacco Irruento | 2 | +2 | 2 |\n| 3 | +2 | Sottoclasse del Barbaro, Conoscenza Primordiale | 3 | +2 | 2 |\n| 4 | +2 | Aumento dei Punteggi di Caratteristica | 3 | +2 | 3 |\n| 5 | +3 | Attacco Extra, Movimento Veloce | 3 | +2 | 3 |\n| 6 | +3 | Privilegio della sottoclasse | 4 | +2 | 3 |\n| 7 | +3 | Istinto Ferino, Balzo Istintivo | 4 | +2 | 3 |\n| 8 | +3 | Aumento dei Punteggi di Caratteristica | 4 | +2 | 3 |\n| 9 | +4 | Colpo Brutale | 4 | +3 | 3 |\n| 10 | +4 | Privilegio della sottoclasse | 4 | +3 | 4 |\n| 11 | +4 | Ira Implacabile | 4 | +3 | 4 |\n| 12 | +4 | Aumento dei Punteggi di Caratteristica | 5 | +3 | 4 |\n| 13 | +5 | Colpo Brutale Migliorato | 5 | +3 | 4 |\n| 14 | +5 | Privilegio della sottoclasse | 5 | +3 | 4 |\n| 15 | +5 | Ira Persistente | 5 | +3 | 4 |\n| 16 | +5 | Aumento dei Punteggi di Caratteristica | 5 | +4 | 4 |\n| 17 | +6 | Colpo Brutale Migliorato | 6 | +4 | 4 |\n| 18 | +6 | Potenza Indomabile | 6 | +4 | 4 |\n| 19 | +6 | Dono Epico | 6 | +4 | 4 |\n| 20 | +6 | Campione Primordiale | 6 | +4 | 4 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/rage"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/rage", "en"), Language = LanguageCode.En, Name = "Rage", Description = "You can imbue yourself with a primal power called Rage, a force that grants you extraordinary might and resilience. You can enter it as a Bonus Action if you aren’t wearing Heavy armor.\n\nYou can enter your Rage the number of times shown for your Barbarian level in the Rages column of the Barbarian Features table. You regain one expended use when you finish a Short Rest, and you regain all expended uses when you finish a Long Rest.\n\nWhile active, your Rage follows the rules below.\n\n**Damage Resistance.** You have Resistance to Bludgeoning, Piercing, and Slashing damage.\n\n**Rage Damage.** When you make an attack using Strength—with either a weapon or an Unarmed Strike—and deal damage to the target, you gain a bonus to the damage that increases as you gain levels as a Barbarian, as shown in the Rage Damage column of the Barbarian Features table.\n\n**Strength Advantage.** You have Advantage on Strength checks and Strength saving throws.\n\n**No Concentration or Spells.** You can’t maintain Concentration, and you can’t cast spells.\n\n**Duration.** The Rage lasts until the end of your next turn, and it ends early if you don Heavy armor or have the Incapacitated condition. If your Rage is still active on your next turn, you can extend the Rage for another round by doing one of the following:\n\n- Make an attack roll against an enemy.\n- Force an enemy to make a saving throw.\n- Take a Bonus Action to extend your Rage.\n\nEach time the Rage is extended, it lasts until the end of your next turn. You can maintain a Rage for up to 10 minutes." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/rage", "it"), Language = LanguageCode.It, Name = "Ira", Description = "Il barbaro può infondere in se stesso un potere primordiale chiamato ira, una forza che gli conferisce una potenza e una tenacia straordinarie. Può entrare in ira come azione bonus, purché non indossi un'armatura pesante.\n\nIl barbaro può entrare in ira il numero di volte indicato per il suo livello da barbaro nella colonna Ire della tabella dei privilegi del barbaro. Recupera un utilizzo speso quando completa un riposo breve e tutti gli utilizzi spesi quando completa un riposo lungo.\n\nFinché è attiva, l'ira segue le regole seguenti.\n\n**Resistenza ai danni.** Il barbaro ha resistenza ai danni contundenti, perforanti e taglienti.\n\n**Danni dell'ira.** Quando effettua un attacco usando la Forza (con un'arma o con un colpo senz'armi) e infligge danni al bersaglio, il barbaro ottiene un bonus ai danni che aumenta man mano che sale di livello come barbaro, come indicato nella colonna Danni dell'ira della tabella dei privilegi del barbaro.\n\n**Vantaggio in Forza.** Il barbaro dispone di vantaggio alle prove di Forza e ai tiri salvezza su Forza.\n\n**Niente concentrazione né incantesimi.** Il barbaro non può mantenere la concentrazione e non può lanciare incantesimi.\n\n**Durata.** L'ira dura fino alla fine del turno successivo del barbaro e termina prima se il barbaro indossa un'armatura pesante o subisce la condizione di incapacitato. Se l'ira è ancora attiva nel suo turno successivo, il barbaro può prolungarla per un altro round compiendo una delle azioni seguenti:\n\n- Effettuare un tiro per colpire contro un nemico.\n- Costringere un nemico a effettuare un tiro salvezza.\n- Usare un'azione bonus per prolungare l'ira.\n\nOgni volta che viene prolungata, l'ira dura fino alla fine del turno successivo del barbaro. Un'ira può essere mantenuta per un massimo di 10 minuti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/unarmored-defense"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/unarmored-defense", "en"), Language = LanguageCode.En, Name = "Unarmored Defense", Description = "While you aren’t wearing any armor, your base Armor Class equals 10 plus your Dexterity and Constitution modifiers. You can use a Shield and still gain this benefit." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/unarmored-defense", "it"), Language = LanguageCode.It, Name = "Difesa Senza Armatura", Description = "Se il barbaro non indossa alcuna armatura, la sua Classe Armatura base è pari a 10 + il suo modificatore di Destrezza + il suo modificatore di Costituzione. Il barbaro può usare uno scudo e ottenere comunque questo beneficio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/weapon-mastery"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/weapon-mastery", "en"), Language = LanguageCode.En, Name = "Weapon Mastery", Description = "Your training with weapons allows you to use the mastery properties of two kinds of Simple or Martial Melee weapons of your choice, such as Greataxes and Handaxes. Whenever you finish a Long Rest, you can practice weapon drills and change one of those weapon choices. When you reach certain Barbarian levels, you gain the ability to use the mastery properties of more kinds of weapons, as shown in the Weapon Mastery column of the Barbarian Features table." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/weapon-mastery", "it"), Language = LanguageCode.It, Name = "Padronanza delle Armi", Description = "L'addestramento con le armi permette al barbaro di usare le proprietà di padronanza di due tipi di armi da mischia semplici o da guerra a sua scelta, come le asce bipenni e le asce. Ogni volta che completa un riposo lungo, può esercitarsi con le armi e sostituire una di quelle scelte.\n\nQuando raggiunge determinati livelli da barbaro, ottiene la capacità di usare le proprietà di padronanza di altri tipi di armi, come indicato nella colonna Padronanza delle armi della tabella dei privilegi del barbaro." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/danger-sense"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/danger-sense", "en"), Language = LanguageCode.En, Name = "Danger Sense", Description = "You gain an uncanny sense of when things aren’t as they should be, giving you an edge when you dodge perils. You have Advantage on Dexterity saving throws unless you have the Incapacitated condition." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/danger-sense", "it"), Language = LanguageCode.It, Name = "Percezione del Pericolo", Description = "Il barbaro sviluppa un sesto senso che gli fa capire quando qualcosa non va come dovrebbe, e questo lo aiuta a sottrarsi ai pericoli. Dispone di vantaggio ai tiri salvezza su Destrezza, a meno che non sia incapacitato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/reckless-attack"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/reckless-attack", "en"), Language = LanguageCode.En, Name = "Reckless Attack", Description = "You can throw aside all concern for defense to attack with increased ferocity. When you make your first attack roll on your turn, you can decide to attack recklessly. Doing so gives you Advantage on attack rolls using Strength until the start of your next turn, but attack rolls against you have Advantage during that time." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/reckless-attack", "it"), Language = LanguageCode.It, Name = "Attacco Irruento", Description = "Il barbaro può mettere da parte ogni preoccupazione per la propria difesa e attaccare con una ferocia ancora maggiore. Quando effettua il primo tiro per colpire nel suo turno, può decidere di attaccare in modo irruento. In tal caso, fino all'inizio del suo turno successivo dispone di vantaggio ai tiri per colpire che usano la Forza, ma anche i tiri per colpire contro di lui dispongono di vantaggio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/barbarian-subclass"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/barbarian-subclass", "en"), Language = LanguageCode.En, Name = "Barbarian Subclass", Description = "You gain a Barbarian subclass of your choice. The Path of the Berserker, Path of the Wild Heart, Path of the World Tree, and Path of the Zealot subclasses are detailed after this class’s description. A subclass is a specialization that grants you features at certain Barbarian levels. For the rest of your career, you gain each of your subclass’s features that are of your Barbarian level or lower." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/barbarian-subclass", "it"), Language = LanguageCode.It, Name = "Sottoclasse del Barbaro", Description = "Il barbaro ottiene una sottoclasse del barbaro a sua scelta: Cammino del Berserker, Cammino del Cuore Selvaggio, Cammino dell'Albero del Mondo o Cammino dello Zelota. Una sottoclasse è una specializzazione che conferisce privilegi a determinati livelli da barbaro. Per il resto della sua carriera, il barbaro ottiene ogni privilegio della sottoclasse di livello pari o inferiore al suo livello da barbaro." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/primal-knowledge"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/primal-knowledge", "en"), Language = LanguageCode.En, Name = "Primal Knowledge", Description = "You gain proficiency in another skill of your choice from the skill list available to Barbarians at level 1.\n\nIn addition, while your Rage is active, you can channel primal power when you attempt certain tasks; whenever you make an ability check using one of the following skills, you can make it as a Strength check even if it normally uses a different ability: Acrobatics, Intimidation, Perception, Stealth, or Survival. When you use this ability, your Strength represents primal power coursing through you, honing your agility, bearing, and senses." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/primal-knowledge", "it"), Language = LanguageCode.It, Name = "Conoscenza Primordiale", Description = "Il barbaro ottiene competenza in un'altra abilità a sua scelta tra quelle disponibili per i barbari al 1° livello.\n\nInoltre, finché l'ira è attiva, il barbaro può incanalare il potere primordiale quando tenta determinate imprese: ogni volta che effettua una prova di caratteristica con una delle abilità seguenti, può effettuarla come prova di Forza anche se normalmente usa un'altra caratteristica: Acrobazia, Furtività, Intimidire, Percezione o Sopravvivenza. In questi casi la Forza rappresenta il potere primordiale che scorre in lui e affina la sua agilità, il suo portamento e i suoi sensi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "You gain the Ability Score Improvement feat (see chapter 5) or another feat of your choice for which you qualify. You gain this feature again at Barbarian levels 8, 12, and 16." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Il barbaro ottiene il talento Aumento dei punteggi di caratteristica o un altro talento a sua scelta di cui soddisfa i prerequisiti. Ottiene di nuovo questo privilegio all'8°, al 12° e al 16° livello da barbaro." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "You can attack twice instead of once whenever you take the Attack action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Quando effettua l'azione di Attacco nel suo turno, il barbaro può attaccare due volte anziché una." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/fast-movement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/fast-movement", "en"), Language = LanguageCode.En, Name = "Fast Movement", Description = "Your speed increases by 10 feet while you aren’t wearing Heavy armor." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/fast-movement", "it"), Language = LanguageCode.It, Name = "Movimento Veloce", Description = "La velocità del barbaro aumenta di 3 metri finché non indossa un'armatura pesante." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/feral-instinct"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/feral-instinct", "en"), Language = LanguageCode.En, Name = "Feral Instinct", Description = "Your instincts are so honed that you have Advantage on Initiative rolls." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/feral-instinct", "it"), Language = LanguageCode.It, Name = "Istinto Ferino", Description = "L'istinto del barbaro è così affinato che dispone di vantaggio ai tiri di iniziativa." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/instinctive-pounce"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/instinctive-pounce", "en"), Language = LanguageCode.En, Name = "Instinctive Pounce", Description = "As part of the Bonus Action you take to enter your Rage, you can move up to half your Speed." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/instinctive-pounce", "it"), Language = LanguageCode.It, Name = "Balzo Istintivo", Description = "Come parte dell'azione bonus che usa per entrare in ira, il barbaro può muoversi fino a metà della sua velocità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/brutal-strike"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 9,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/brutal-strike", "en"), Language = LanguageCode.En, Name = "Brutal Strike", Description = "If you use Reckless Attack, you can forgo any Advantage on one Strength-based attack roll of your choice on your turn. The chosen attack roll mustn’t have Disadvantage. If the chosen attack roll hits, the target takes an extra 1d10 damage of the same type dealt by the weapon or Unarmed Strike, and you can cause one Brutal Strike effect of your choice. You have the following effect options.\n\n**Forceful Blow.** The target is pushed 15 feet straight away from you. You can then move up to half your Speed straight toward the target without provoking Opportunity Attacks.\n\n**Hamstring Blow.** The target’s Speed is reduced by 15 feet until the start of your next turn. A target can be affected by only one Hamstring Blow at a time—the most recent one." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/brutal-strike", "it"), Language = LanguageCode.It, Name = "Colpo Brutale", Description = "Se usa Attacco irruento, il barbaro può rinunciare al vantaggio su un tiro per colpire basato sulla Forza a sua scelta nel suo turno. Il tiro scelto non deve subire svantaggio. Se l'attacco colpisce, il bersaglio subisce 1d10 danni extra dello stesso tipo inflitto dall'arma o dal colpo senz'armi, e il barbaro può causare un effetto di Colpo brutale a sua scelta tra quelli seguenti.\n\n**Colpo poderoso.** Il bersaglio viene spinto di 4,5 metri in linea retta lontano dal barbaro. Il barbaro può poi muoversi fino a metà della sua velocità in linea retta verso il bersaglio senza provocare attacchi di opportunità.\n\n**Colpo ai garretti.** La velocità del bersaglio si riduce di 4,5 metri fino all'inizio del turno successivo del barbaro. Un bersaglio può essere influenzato da un solo Colpo ai garretti alla volta, il più recente." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/relentless-rage"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 13,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/relentless-rage", "en"), Language = LanguageCode.En, Name = "Relentless Rage", Description = "Your Rage can keep you fighting despite grievous wounds. If you drop to 0 Hit Points while your Rage is active and don’t die outright, you can make a DC 10 Constitution saving throw. If you succeed, your Hit Points instead change to a number equal to twice your Barbarian level. Each time you use this feature after the first, the DC increases by 5. When you finish a Short or Long Rest, the DC resets to 10." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/relentless-rage", "it"), Language = LanguageCode.It, Name = "Ira Implacabile", Description = "L'ira può tenere in piedi il barbaro nonostante ferite gravissime. Se scende a 0 punti ferita mentre l'ira è attiva e non muore sul colpo, il barbaro può effettuare un tiro salvezza su Costituzione con CD 10. Se lo supera, i suoi punti ferita diventano invece pari al doppio del suo livello da barbaro.\n\nOgni volta che usa questo privilegio dopo la prima, la CD aumenta di 5. Quando il barbaro completa un riposo breve o lungo, la CD torna a 10." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/improved-brutal-strike-13"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 13,
					SortOrder = 14,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/improved-brutal-strike-13", "en"), Language = LanguageCode.En, Name = "Improved Brutal Strike", Description = "You have honed new ways to attack furiously. The following effects are now among your Brutal Strike options.\n\n**Staggering Blow.** The target has Disadvantage on the next saving throw it makes, and it can’t make Opportunity Attacks until the start of your next turn.\n\n**Sundering Blow.** Before the start of your next turn, the next attack roll made by another creature against the target gains a +5 bonus to the roll. An attack roll can gain only one Sundering Blow bonus." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/improved-brutal-strike-13", "it"), Language = LanguageCode.It, Name = "Colpo Brutale Migliorato", Description = "Il barbaro ha affinato nuovi modi di attaccare con furia. Gli effetti seguenti si aggiungono alle opzioni del suo Colpo brutale.\n\n**Colpo sbilanciante.** Il bersaglio subisce svantaggio al successivo tiro salvezza che effettua e non può effettuare attacchi di opportunità fino all'inizio del turno successivo del barbaro.\n\n**Colpo dirompente.** Prima dell'inizio del turno successivo del barbaro, il successivo tiro per colpire effettuato da un'altra creatura contro il bersaglio ottiene un bonus di +5. Un tiro per colpire può beneficiare di un solo bonus di Colpo dirompente." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/persistent-rage"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 15,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/persistent-rage", "en"), Language = LanguageCode.En, Name = "Persistent Rage", Description = "When you roll Initiative, you can regain all expended uses of Rage. After you regain uses of Rage in this way, you can’t do so again until you finish a Long Rest.\n\nIn addition, your Rage is so fierce that it now lasts for 10 minutes without you needing to do anything to extend it from round to round. Your Rage ends early if you have the Unconscious condition (not just the Incapacitated condition) or don Heavy armor." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/persistent-rage", "it"), Language = LanguageCode.It, Name = "Ira Persistente", Description = "Quando tira per l'iniziativa, il barbaro può recuperare tutti gli utilizzi spesi di Ira. Dopo averli recuperati in questo modo, non può farlo di nuovo finché non completa un riposo lungo.\n\nInoltre, l'ira del barbaro è così feroce che ora dura 10 minuti senza che debba fare nulla per prolungarla di round in round. L'ira termina prima se il barbaro subisce la condizione di privo di sensi (non solo quella di incapacitato) o indossa un'armatura pesante." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/improved-brutal-strike-17"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 16,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/improved-brutal-strike-17", "en"), Language = LanguageCode.En, Name = "Improved Brutal Strike", Description = "The extra damage of your Brutal Strike increases to 2d10. In addition, you can use two different Brutal Strike effects whenever you use your Brutal Strike feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/improved-brutal-strike-17", "it"), Language = LanguageCode.It, Name = "Colpo Brutale Migliorato", Description = "I danni extra del Colpo brutale aumentano a 2d10. Inoltre, ogni volta che usa il privilegio Colpo brutale, il barbaro può applicare due diversi effetti di Colpo brutale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/indomitable-might"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 17,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/indomitable-might", "en"), Language = LanguageCode.En, Name = "Indomitable Might", Description = "If your total for a Strength check or Strength saving throw is less than your Strength score, you can use that score in place of the total." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/indomitable-might", "it"), Language = LanguageCode.It, Name = "Potenza Indomabile", Description = "Se il totale di una prova di Forza o di un tiro salvezza su Forza del barbaro è inferiore al suo punteggio di Forza, il barbaro può usare quel punteggio al posto del totale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/epic-boon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 19,
					SortOrder = 18,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/epic-boon", "en"), Language = LanguageCode.En, Name = "Epic Boon", Description = "You gain an Epic Boon feat (see chapter 5) or another feat of your choice for which you qualify. Boon of Irresistible Offense is recommended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/epic-boon", "it"), Language = LanguageCode.It, Name = "Dono Epico", Description = "Il barbaro ottiene un talento Dono epico o un altro talento a sua scelta di cui soddisfa i prerequisiti. È consigliato il Dono dell'attacco irresistibile." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/primal-champion"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 19,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/primal-champion", "en"), Language = LanguageCode.En, Name = "Primal Champion", Description = "You embody primal power. Your Strength and Constitution scores increase by 4, to a maximum of 25." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "barbarian/primal-champion", "it"), Language = LanguageCode.It, Name = "Campione Primordiale", Description = "Il barbaro incarna il potere primordiale. I suoi punteggi di Forza e di Costituzione aumentano di 4, fino a un massimo di 25." }
					}
				}
			}
		};
	}
}
