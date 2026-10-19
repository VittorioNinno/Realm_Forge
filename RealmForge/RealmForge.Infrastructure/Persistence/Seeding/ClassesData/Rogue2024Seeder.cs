using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Rogue (2024 ruleset): class features of the SRD 5.2 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Rogue2024Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "rogue");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			HitDie = 8,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Dexterity },
			SavingThrows = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Intelligence },
			SkillChoiceCount = 4,
			SkillOptions = new List<Skill> { Skill.Acrobatics, Skill.Athletics, Skill.Deception, Skill.Insight, Skill.Intimidation, Skill.Investigation, Skill.Perception, Skill.Persuasion, Skill.SleightOfHand, Skill.Stealth },
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "rogue", "en"),
					Language = LanguageCode.En,
					Name = "Rogue",
					Description = "A cunning expert in stealth and subterfuge. Rogues rely on wits, agility and a sharp eye for an enemy's weak spot, slipping past danger, opening locks and traps and striking with precision when a foe lets their guard down.",
					SubclassTitle = "Rogue Subclass",
					ArmorProficiencies = "Light armor",
					WeaponProficiencies = "Simple weapons and Martial weapons that have the Finesse or Light property",
					ToolProficiencies = "Thieves' Tools",
					StartingEquipment = "Choose A or B:\n- (A) Leather Armor, 2 Daggers, Shortsword, Shortbow, 20 Arrows, Quiver, Thieves' Tools, Burglar's Pack and 8 GP\n- (B) 100 GP",
					ProgressionTable = "| Level | Proficiency Bonus | Class Features | Sneak Attack |\n|---|---|---|---|\n| 1 | +2 | Expertise, Sneak Attack, Thieves' Cant, Weapon Mastery | 1d6 |\n| 2 | +2 | Cunning Action | 1d6 |\n| 3 | +2 | Rogue Subclass, Steady Aim | 2d6 |\n| 4 | +2 | Ability Score Improvement | 2d6 |\n| 5 | +3 | Cunning Strike, Uncanny Dodge | 3d6 |\n| 6 | +3 | Expertise | 3d6 |\n| 7 | +3 | Evasion, Reliable Talent | 4d6 |\n| 8 | +3 | Ability Score Improvement | 4d6 |\n| 9 | +4 | Subclass feature | 5d6 |\n| 10 | +4 | Ability Score Improvement | 5d6 |\n| 11 | +4 | Improved Cunning Strike | 6d6 |\n| 12 | +4 | Ability Score Improvement | 6d6 |\n| 13 | +5 | Subclass feature | 7d6 |\n| 14 | +5 | Devious Strikes | 7d6 |\n| 15 | +5 | Slippery Mind | 8d6 |\n| 16 | +5 | Ability Score Improvement | 8d6 |\n| 17 | +6 | Subclass feature | 9d6 |\n| 18 | +6 | Elusive | 9d6 |\n| 19 | +6 | Epic Boon | 10d6 |\n| 20 | +6 | Stroke of Luck | 10d6 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "rogue", "it"),
					Language = LanguageCode.It,
					Name = "Ladro",
					Description = "Uno scaltro esperto di furtività e sotterfugi. Il ladro si affida all'ingegno, all'agilità e a un occhio acuto per i punti deboli del nemico: sguscia oltre i pericoli, apre serrature e disattiva trappole, e colpisce con precisione quando un avversario abbassa la guardia.",
					SubclassTitle = "Sottoclasse del ladro",
					ArmorProficiencies = "Armature leggere",
					WeaponProficiencies = "Armi semplici e armi da guerra con la proprietà accurata o leggera",
					ToolProficiencies = "Arnesi da scasso",
					StartingEquipment = "A scelta tra A e B:\n- (A) un'armatura di cuoio, 2 pugnali, una spada corta, un arco corto, 20 frecce, una faretra, degli arnesi da scasso, una dotazione da scassinatore e 8 mo\n- (B) 100 mo",
					ProgressionTable = "| Livello | Bonus di competenza | Privilegi di classe | Attacco furtivo |\n|---|---|---|---|\n| 1 | +2 | Maestria, Attacco Furtivo, Gergo Ladresco, Padronanza nelle Armi | 1d6 |\n| 2 | +2 | Azione Scaltra | 1d6 |\n| 3 | +2 | Sottoclasse del Ladro, Mira Ferma | 2d6 |\n| 4 | +2 | Aumento dei Punteggi di Caratteristica | 2d6 |\n| 5 | +3 | Colpo Astuto, Schivata Prodigiosa | 3d6 |\n| 6 | +3 | Maestria | 3d6 |\n| 7 | +3 | Elusione, Dote Affidabile | 4d6 |\n| 8 | +3 | Aumento dei Punteggi di Caratteristica | 4d6 |\n| 9 | +4 | Privilegio della sottoclasse | 5d6 |\n| 10 | +4 | Aumento dei Punteggi di Caratteristica | 5d6 |\n| 11 | +4 | Colpo Astuto Migliorato | 6d6 |\n| 12 | +4 | Aumento dei Punteggi di Caratteristica | 6d6 |\n| 13 | +5 | Privilegio della sottoclasse | 7d6 |\n| 14 | +5 | Colpi Infidi | 7d6 |\n| 15 | +5 | Mente Sfuggente | 8d6 |\n| 16 | +5 | Aumento dei Punteggi di Caratteristica | 8d6 |\n| 17 | +6 | Privilegio della sottoclasse | 9d6 |\n| 18 | +6 | Inafferrabile | 9d6 |\n| 19 | +6 | Dono Epico | 10d6 |\n| 20 | +6 | Colpo di Fortuna | 10d6 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/expertise"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/expertise", "en"), Language = LanguageCode.En, Name = "Expertise", Description = "You gain Expertise in two of your skill proficiencies of your choice. Sleight of Hand and Stealth are recommended if you have proficiency in them.\n\nAt Rogue level 6, you gain Expertise in two more of your skill proficiencies of your choice." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/expertise", "it"), Language = LanguageCode.It, Name = "Maestria", Description = "Il ladro ottiene Maestria in due abilità a sua scelta in cui ha competenza; se le possiede, sono consigliate Furtività e Rapidità di mano.\n\nAl 6° livello da ladro ottiene Maestria in altre due abilità a sua scelta in cui ha competenza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/sneak-attack"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/sneak-attack", "en"), Language = LanguageCode.En, Name = "Sneak Attack", Description = "You know how to strike subtly and exploit a foe’s distraction. Once per turn, you can deal an extra 1d6 damage to one creature you hit with an attack roll if you have Advantage on the roll and the attack uses a Finesse or a Ranged weapon. The extra damage’s type is the same as the weapon’s type.\n\nYou don’t need Advantage on the attack roll if at least one of your allies is within 5 feet of the target, the ally doesn’t have the Incapacitated condition, and you don’t have Disadvantage on the attack roll.\n\nThe extra damage increases as you gain Rogue levels, as shown in the Sneak Attack column of the Rogue Features table." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/sneak-attack", "it"), Language = LanguageCode.It, Name = "Attacco Furtivo", Description = "Il ladro sa come colpire con discrezione e sfruttare la distrazione di un avversario. Una volta per turno, può infliggere 1d6 danni extra a una creatura che colpisce con un tiro per colpire, se dispone di vantaggio a quel tiro e l'attacco usa un'arma accurata o a distanza. I danni extra sono dello stesso tipo dei danni dell'arma.\n\nIl ladro non ha bisogno del vantaggio al tiro per colpire se almeno un suo alleato si trova entro 1,5 metri dal bersaglio, quell'alleato non è incapacitato e il ladro non subisce svantaggio al tiro per colpire.\n\nI danni extra aumentano man mano che il ladro sale di livello, come indicato nella colonna Attacco furtivo della tabella dei privilegi del ladro." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/thieves-cant"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/thieves-cant", "en"), Language = LanguageCode.En, Name = "Thieves' Cant", Description = "You picked up various languages in the communities where you plied your roguish talents. You know Thieves’ Cant and one other language of your choice, which you choose from the language tables in chapter 2." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/thieves-cant", "it"), Language = LanguageCode.It, Name = "Gergo Ladresco", Description = "Il ladro ha appreso varie lingue nelle comunità in cui ha esercitato i suoi talenti furfanteschi. Conosce il gergo ladresco e un'altra lingua a sua scelta tra quelle delle tabelle delle lingue." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/weapon-mastery"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/weapon-mastery", "en"), Language = LanguageCode.En, Name = "Weapon Mastery", Description = "Your training with weapons allows you to use the mastery properties of two kinds of weapons of your choice with which you have proficiency, such as Daggers and Shortbows.\n\nWhenever you finish a Long Rest, you can change the kinds of weapons you chose. For example, you could switch to using the mastery properties of Scimitars and Shortswords." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/weapon-mastery", "it"), Language = LanguageCode.It, Name = "Padronanza nelle Armi", Description = "Il suo addestramento con le armi permette al ladro di usare le proprietà di padronanza di due tipi di armi a sua scelta in cui ha competenza, come i pugnali e gli archi corti.\n\nOgni volta che completa un riposo lungo, può cambiare i tipi di armi scelti; per esempio, potrebbe passare alle proprietà di padronanza delle scimitarre e delle spade corte." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/cunning-action"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/cunning-action", "en"), Language = LanguageCode.En, Name = "Cunning Action", Description = "Your quick thinking and agility allow you to move and act quickly. On your turn, you can take one of the following actions as a Bonus Action: Dash, Disengage, or Hide." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/cunning-action", "it"), Language = LanguageCode.It, Name = "Azione Scaltra", Description = "La prontezza di spirito e l'agilità permettono al ladro di muoversi e agire rapidamente. Nel suo turno può effettuare una delle azioni seguenti come azione bonus: Disimpegno, Nascondersi o Scatto." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/rogue-subclass"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/rogue-subclass", "en"), Language = LanguageCode.En, Name = "Rogue Subclass", Description = "You gain a Rogue subclass of your choice. The Arcane Trickster, Assassin, Soulknife, and Thief subclasses are detailed after this class’s description. A subclass is a specialization that grants you features at certain Rogue levels. For the rest of your career, you gain each of your subclass’s features that are of your Rogue level or lower." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/rogue-subclass", "it"), Language = LanguageCode.It, Name = "Sottoclasse del Ladro", Description = "Il ladro ottiene una sottoclasse del ladro a sua scelta: Assassino, Furfante, Lama Spirituale o Mistificatore Arcano. Una sottoclasse è una specializzazione che conferisce privilegi a determinati livelli da ladro. Per il resto della sua carriera, il ladro ottiene ogni privilegio della sottoclasse di livello pari o inferiore al suo livello da ladro." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/steady-aim"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/steady-aim", "en"), Language = LanguageCode.En, Name = "Steady Aim", Description = "As a Bonus Action, you give yourself Advantage on your next attack roll on the current turn. You can use this feature only if you haven’t moved during this turn, and after you use it, your Speed is 0 until the end of the current turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/steady-aim", "it"), Language = LanguageCode.It, Name = "Mira Ferma", Description = "Come azione bonus, il ladro si conferisce vantaggio al suo successivo tiro per colpire nel turno in corso. Può usare questo privilegio solo se non si è mosso durante il turno e, dopo averlo usato, la sua velocità è 0 fino alla fine del turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "You gain the Ability Score Improvement feat (see chapter 5) or another feat of your choice for which you qualify. You gain this feature again at Rogue levels 8, 10, 12, and 16." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Il ladro ottiene il talento Aumento dei punteggi di caratteristica o un altro talento a sua scelta di cui soddisfa i prerequisiti. Ottiene di nuovo questo privilegio all'8°, al 10°, al 12° e al 16° livello da ladro." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/cunning-strike"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/cunning-strike", "en"), Language = LanguageCode.En, Name = "Cunning Strike", Description = "You've developed cunning ways to use your Sneak Attack. When you deal Sneak Attack damage, you can add one of the following Cunning Strike effects. Each effect has a die cost, which is the number of Sneak Attack damage dice you must forgo to add the effect. You remove the die before rolling, and the effect occurs immediately after the attack's damage is dealt. For example, if you add the Poison effect, remove 1d6 from the Sneak Attack's damage before rolling.\n\nIf a Cunning Strike effect requires a saving throw, the DC equals 8 plus your Dexterity modifier and Proficiency Bonus.\n\n**Poison (Cost: 1d6).** You add a toxin to your strike, forcing the target to make a Constitution saving throw. On a failed save, the target has the Poisoned condition for 1 minute. At the end of each of its turns, the Poisoned target repeats the save, ending the effect on itself on a success. To use this effect, you must have a Poisoner's Kit on your person.\n\n**Trip (Cost: 1d6).** If the target is Large or smaller, it must succeed on a Dexterity saving throw or have the Prone condition.\n\n**Withdraw (Cost: 1d6).** Immediately after the attack, you move up to half your Speed without provoking Opportunity Attacks." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/cunning-strike", "it"), Language = LanguageCode.It, Name = "Colpo Astuto", Description = "Il ladro ha sviluppato modi astuti di usare il suo Attacco furtivo. Quando infligge danni con Attacco furtivo, può aggiungere uno degli effetti di Colpo astuto seguenti. Ogni effetto ha un costo in dadi, cioè il numero di dadi di danni di Attacco furtivo a cui deve rinunciare per aggiungerlo. Il ladro toglie i dadi prima di tirare, e l'effetto si verifica subito dopo che i danni dell'attacco sono stati inflitti. Per esempio, per aggiungere l'effetto Veleno toglie 1d6 dai danni dell'Attacco furtivo prima di tirare.\n\nSe un effetto di Colpo astuto richiede un tiro salvezza, la CD è pari a 8 + il modificatore di Destrezza del ladro + il suo bonus di competenza.\n\n**Veleno (costo: 1d6).** Il ladro aggiunge una tossina al colpo, costringendo il bersaglio a effettuare un tiro salvezza su Costituzione. Se lo fallisce, il bersaglio subisce la condizione di avvelenato per 1 minuto; alla fine di ognuno dei suoi turni ripete il tiro salvezza e, se lo supera, l'effetto su di lui termina. Per usare questo effetto, il ladro deve avere con sé delle sostanze da avvelenatore.\n\n**Inciampo (costo: 1d6).** Se il bersaglio è di taglia Grande o inferiore, deve superare un tiro salvezza su Destrezza, altrimenti subisce la condizione di prono.\n\n**Ritirata (costo: 1d6).** Subito dopo l'attacco, il ladro si muove fino a metà della sua velocità senza provocare attacchi di opportunità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/uncanny-dodge"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/uncanny-dodge", "en"), Language = LanguageCode.En, Name = "Uncanny Dodge", Description = "When an attacker that you can see hits you with an attack roll, you can take a Reaction to halve the attack’s damage against you (round down)." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/uncanny-dodge", "it"), Language = LanguageCode.It, Name = "Schivata Prodigiosa", Description = "Quando un attaccante che il ladro è in grado di vedere lo colpisce con un tiro per colpire, il ladro può usare una reazione per dimezzare i danni dell'attacco subiti (arrotondati per difetto)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/evasion"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/evasion", "en"), Language = LanguageCode.En, Name = "Evasion", Description = "You can nimbly dodge out of the way of certain dangers. When you’re subjected to an effect that allows you to make a Dexterity saving throw to take only half damage, you instead take no damage if you succeed on the saving throw and only half damage if you fail. You can’t use this feature if you have the Incapacitated condition." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/evasion", "it"), Language = LanguageCode.It, Name = "Elusione", Description = "Il ladro sa schivare agilmente certi pericoli. Quando è soggetto a un effetto che gli permette di effettuare un tiro salvezza su Destrezza per subire solo la metà dei danni, non subisce alcun danno se supera il tiro salvezza e subisce solo la metà dei danni se lo fallisce. Non può usare questo privilegio se è incapacitato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/reliable-talent"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/reliable-talent", "en"), Language = LanguageCode.En, Name = "Reliable Talent", Description = "Whenever you make an ability check that uses one of your skill or tool proficiencies, you can treat a d20 roll of 9 or lower as a 10." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/reliable-talent", "it"), Language = LanguageCode.It, Name = "Dote Affidabile", Description = "Ogni volta che effettua una prova di caratteristica che usa una delle sue competenze nelle abilità o negli strumenti, il ladro può considerare come un 10 qualsiasi risultato di 9 o meno sul d20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/improved-cunning-strike"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/improved-cunning-strike", "en"), Language = LanguageCode.En, Name = "Improved Cunning Strike", Description = "You can use up to two Cunning Strike effects when you deal Sneak Attack damage, paying the die cost for each effect." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/improved-cunning-strike", "it"), Language = LanguageCode.It, Name = "Colpo Astuto Migliorato", Description = "Quando infligge danni con Attacco furtivo, il ladro può usare fino a due effetti di Colpo astuto, pagando il costo in dadi di ciascuno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/devious-strikes"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 13,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/devious-strikes", "en"), Language = LanguageCode.En, Name = "Devious Strikes", Description = "You've practiced new ways to use your Sneak Attack deviously. The following effects are now among your Cunning Strike options.\n\n**Daze (Cost: 2d6).** The target must succeed on a Constitution saving throw, or on its next turn, it can do only one of the following: move or take an action or a Bonus Action.\n\n**Knock Out (Cost: 6d6).** The target must succeed on a Constitution saving throw, or it has the Unconscious condition for 1 minute or until it takes any damage. The Unconscious target repeats the save at the end of each of its turns, ending the effect on itself on a success.\n\n**Obscure (Cost: 3d6).** The target must succeed on a Dexterity saving throw, or it has the Blinded condition until the end of its next turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/devious-strikes", "it"), Language = LanguageCode.It, Name = "Colpi Infidi", Description = "Il ladro ha messo a punto nuovi modi subdoli di usare il suo Attacco furtivo. Gli effetti seguenti si aggiungono alle sue opzioni di Colpo astuto.\n\n**Confusione (costo: 2d6).** Il bersaglio deve superare un tiro salvezza su Costituzione, altrimenti nel suo turno successivo può fare soltanto una delle cose seguenti: muoversi, effettuare un'azione o effettuare un'azione bonus.\n\n**Atterramento (costo: 6d6).** Il bersaglio deve superare un tiro salvezza su Costituzione, altrimenti subisce la condizione di privo di sensi per 1 minuto o finché non subisce danni. Il bersaglio privo di sensi ripete il tiro salvezza alla fine di ognuno dei suoi turni e, se lo supera, l'effetto su di lui termina.\n\n**Rabbuio (costo: 3d6).** Il bersaglio deve superare un tiro salvezza su Destrezza, altrimenti subisce la condizione di accecato fino alla fine del suo turno successivo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/slippery-mind"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 14,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/slippery-mind", "en"), Language = LanguageCode.En, Name = "Slippery Mind", Description = "Your cunning mind is exceptionally difficult to control. You gain proficiency in Wisdom and Charisma saving throws." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/slippery-mind", "it"), Language = LanguageCode.It, Name = "Mente Sfuggente", Description = "La mente astuta del ladro è straordinariamente difficile da controllare: ottiene competenza nei tiri salvezza su Saggezza e su Carisma." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/elusive"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 15,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/elusive", "en"), Language = LanguageCode.En, Name = "Elusive", Description = "You’re so evasive that attackers rarely gain the upper hand against you. No attack roll can have Advantage against you unless you have the Incapacitated condition." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/elusive", "it"), Language = LanguageCode.It, Name = "Inafferrabile", Description = "Il ladro è così sfuggente che raramente gli attaccanti riescono ad avere la meglio su di lui: nessun tiro per colpire contro di lui può disporre di vantaggio, a meno che non sia incapacitato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/epic-boon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 19,
					SortOrder = 16,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/epic-boon", "en"), Language = LanguageCode.En, Name = "Epic Boon", Description = "You gain an Epic Boon feat (see chapter 5) or another feat of your choice for which you qualify. Boon of the Night Spirit is recommended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/epic-boon", "it"), Language = LanguageCode.It, Name = "Dono Epico", Description = "Il ladro ottiene un talento Dono epico o un altro talento a sua scelta di cui soddisfa i prerequisiti. È consigliato il Dono dello spirito notturno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/stroke-of-luck"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 17,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/stroke-of-luck", "en"), Language = LanguageCode.En, Name = "Stroke of Luck", Description = "You have a marvelous knack for succeeding when you need to. If you fail a D20 Test, you can turn the roll into a 20. Once you use this feature, you can’t use it again until you finish a Short or Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "rogue/stroke-of-luck", "it"), Language = LanguageCode.It, Name = "Colpo di Fortuna", Description = "Il ladro ha un talento straordinario per riuscire quando ne ha bisogno. Se fallisce una prova del d20, può trasformare il risultato del tiro in un 20. Dopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo breve o lungo." }
					}
				}
			}
		};
	}
}
