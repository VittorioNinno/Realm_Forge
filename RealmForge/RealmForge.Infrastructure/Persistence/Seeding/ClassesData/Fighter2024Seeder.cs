using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Fighter (2024 ruleset): class features of the SRD 5.2 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Fighter2024Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "fighter");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			HitDie = 10,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Dexterity },
			SavingThrows = new List<AbilityScore> { AbilityScore.Strength, AbilityScore.Constitution },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.Acrobatics, Skill.Animal Handling, Skill.Athletics, Skill.History, Skill.Insight, Skill.Intimidation, Skill.Persuasion, Skill.Perception, Skill.Survival },
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "fighter", "en"),
					Language = LanguageCode.En,
					Name = "Fighter",
					Description = "A master of every weapon and every kind of armor. Knights, champions, soldiers and sellswords all share the Fighter's unmatched skill at arms, a broad training honed into a personal style of combat that lets them face any threat on the battlefield.",
					SubclassTitle = "Fighter Subclass",
					ArmorProficiencies = "Light, Medium and Heavy armor; Shields",
					WeaponProficiencies = "Simple and Martial weapons",
					ToolProficiencies = "None",
					StartingEquipment = "Choose A, B or C:\n- (A) Chain Mail, Greatsword, Flail, 8 Javelins, Dungeoneer's Pack and 4 GP\n- (B) Studded Leather Armor, Scimitar, Shortsword, Longbow, 20 Arrows, Quiver, Dungeoneer's Pack and 11 GP\n- (C) 155 GP",
					ProgressionTable = "| Level | Proficiency Bonus | Class Features | Second Wind | Weapon Mastery |\n|---|---|---|---|---|\n| 1 | +2 | Fighting Style, Second Wind, Weapon Mastery | 2 | 3 |\n| 2 | +2 | Action Surge, Tactical Mind | 2 | 3 |\n| 3 | +2 | Fighter Subclass | 2 | 3 |\n| 4 | +2 | Ability Score Improvement | 3 | 4 |\n| 5 | +3 | Extra Attack, Tactical Shift | 3 | 4 |\n| 6 | +3 | Ability Score Improvement | 3 | 4 |\n| 7 | +3 | Subclass feature | 3 | 4 |\n| 8 | +3 | Ability Score Improvement | 3 | 4 |\n| 9 | +4 | Indomitable, Tactical Master | 3 | 4 |\n| 10 | +4 | Subclass feature | 4 | 5 |\n| 11 | +4 | Two Extra Attacks | 4 | 5 |\n| 12 | +4 | Ability Score Improvement | 4 | 5 |\n| 13 | +5 | Studied Attacks, Indomitable | 4 | 5 |\n| 14 | +5 | Ability Score Improvement | 4 | 5 |\n| 15 | +5 | Subclass feature | 4 | 5 |\n| 16 | +5 | Ability Score Improvement | 4 | 6 |\n| 17 | +6 | Action Surge, Indomitable | 4 | 6 |\n| 18 | +6 | Subclass feature | 4 | 6 |\n| 19 | +6 | Epic Boon | 4 | 6 |\n| 20 | +6 | Three Extra Attacks | 4 | 6 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "fighter", "it"),
					Language = LanguageCode.It,
					Name = "Guerriero",
					Description = "Un maestro di ogni arma e di ogni tipo di armatura. Cavalieri, campioni, soldati e mercenari condividono l'abilità ineguagliata del guerriero nell'uso delle armi: un addestramento ad ampio raggio affinato in uno stile di combattimento personale che gli permette di affrontare qualsiasi minaccia sul campo di battaglia.",
					SubclassTitle = "Sottoclasse del guerriero",
					ArmorProficiencies = "Armature leggere, medie e pesanti; scudi",
					WeaponProficiencies = "Armi semplici e da guerra",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "A scelta tra A, B e C:\n- (A) una cotta di maglia, uno spadone, un mazzafrusto, 8 giavellotti, una dotazione da avventuriero e 4 mo\n- (B) un'armatura di cuoio borchiato, una scimitarra, una spada corta, un arco lungo, 20 frecce, una faretra, una dotazione da avventuriero e 11 mo\n- (C) 155 mo",
					ProgressionTable = "| Livello | Bonus di competenza | Privilegi di classe | Recuperare Energie | Padronanza nelle armi |\n|---|---|---|---|---|\n| 1 | +2 | Stile di Combattimento, Recuperare Energie, Padronanza nelle Armi | 2 | 3 |\n| 2 | +2 | Azione Impetuosa, Mente Tattica | 2 | 3 |\n| 3 | +2 | Sottoclasse del Guerriero | 2 | 3 |\n| 4 | +2 | Aumento dei Punteggi di Caratteristica | 3 | 4 |\n| 5 | +3 | Attacco Extra, Spostamento Tattico | 3 | 4 |\n| 6 | +3 | Aumento dei Punteggi di Caratteristica | 3 | 4 |\n| 7 | +3 | Privilegio della sottoclasse | 3 | 4 |\n| 8 | +3 | Aumento dei Punteggi di Caratteristica | 3 | 4 |\n| 9 | +4 | Indomabile, Signore delle Tattiche | 3 | 4 |\n| 10 | +4 | Privilegio della sottoclasse | 4 | 5 |\n| 11 | +4 | Due Attacchi Extra | 4 | 5 |\n| 12 | +4 | Aumento dei Punteggi di Caratteristica | 4 | 5 |\n| 13 | +5 | Attacchi Studiati, Indomabile | 4 | 5 |\n| 14 | +5 | Aumento dei Punteggi di Caratteristica | 4 | 5 |\n| 15 | +5 | Privilegio della sottoclasse | 4 | 5 |\n| 16 | +5 | Aumento dei Punteggi di Caratteristica | 4 | 6 |\n| 17 | +6 | Azione Impetuosa, Indomabile | 4 | 6 |\n| 18 | +6 | Privilegio della sottoclasse | 4 | 6 |\n| 19 | +6 | Dono Epico | 4 | 6 |\n| 20 | +6 | Tre Attacchi Extra | 4 | 6 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/fighting-style"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/fighting-style", "en"), Language = LanguageCode.En, Name = "Fighting Style", Description = "You have honed your martial prowess and gain a Fighting Style feat of your choice (see chapter 5). Defense is recommended. Whenever you gain a Fighter level, you can replace the feat you chose with a different Fighting Style feat." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/fighting-style", "it"), Language = LanguageCode.It, Name = "Stile di Combattimento", Description = "Il guerriero ha affinato la sua abilità marziale e ottiene un talento Stile di combattimento a sua scelta; è consigliato Difesa. Ogni volta che sale di livello come guerriero, può sostituire il talento scelto con un altro talento Stile di combattimento." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/second-wind"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/second-wind", "en"), Language = LanguageCode.En, Name = "Second Wind", Description = "You have a limited well of physical and mental stamina that you can draw on. As a Bonus Action, you can use it to regain Hit Points equal to 1d10 plus your Fighter level.\n\nYou can use this feature twice. You regain one expended use when you finish a Short Rest, and you regain all expended uses when you finish a Long Rest.\n\nWhen you reach certain Fighter levels, you gain more uses of this feature, as shown in the Second Wind column of the Fighter Features table." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/second-wind", "it"), Language = LanguageCode.It, Name = "Recuperare Energie", Description = "Il guerriero dispone di una riserva limitata di resistenza fisica e mentale a cui può attingere. Come azione bonus, può usarla per recuperare un numero di punti ferita pari a 1d10 + il suo livello da guerriero.\n\nIl guerriero può usare questo privilegio due volte. Recupera un utilizzo speso quando completa un riposo breve e tutti gli utilizzi spesi quando completa un riposo lungo.\n\nA determinati livelli da guerriero ottiene ulteriori utilizzi di questo privilegio, come indicato nella colonna Recuperare Energie della tabella dei privilegi del guerriero." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/weapon-mastery"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/weapon-mastery", "en"), Language = LanguageCode.En, Name = "Weapon Mastery", Description = "Your training with weapons allows you to use the mastery properties of three kinds of Simple or Martial weapons of your choice. Whenever you finish a Long Rest, you can practice weapon drills and change one of those weapon choices.\n\nWhen you reach certain Fighter levels, you gain the ability to use the mastery properties of more kinds of weapons, as shown in the Weapon Mastery column of the Fighter Features table." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/weapon-mastery", "it"), Language = LanguageCode.It, Name = "Padronanza nelle Armi", Description = "Il suo addestramento con le armi permette al guerriero di usare le proprietà di padronanza di tre tipi di armi semplici o da guerra a sua scelta. Ogni volta che completa un riposo lungo, può esercitarsi con le armi e cambiare una di quelle scelte.\n\nA determinati livelli da guerriero può usare le proprietà di padronanza di altri tipi di armi, come indicato nella colonna Padronanza nelle armi della tabella dei privilegi del guerriero." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/action-surge"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/action-surge", "en"), Language = LanguageCode.En, Name = "Action Surge", Description = "You can push yourself beyond your normal limits for a moment. On your turn, you can take one additional action, except the Magic action. Once you use this feature, you can’t do so again until you finish a Short or Long Rest. Starting at level 17, you can use it twice before a rest but only once on a turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/action-surge", "it"), Language = LanguageCode.It, Name = "Azione Impetuosa", Description = "Il guerriero può spingersi per un momento oltre i suoi limiti normali. Nel suo turno può effettuare un'azione aggiuntiva, a eccezione dell'azione di Magia. Dopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo breve o lungo. A partire dal 17° livello, può usarlo due volte prima di un riposo, ma solo una volta per turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/tactical-mind"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/tactical-mind", "en"), Language = LanguageCode.En, Name = "Tactical Mind", Description = "You have a mind for tactics on and off the battlefield. When you fail an ability check, you can expend a use of your Second Wind to push yourself toward success. Rather than regaining Hit Points, you roll 1d10 and add the number rolled to the ability check, potentially turning it into a success. If the check still fails, this use of Second Wind isn’t expended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/tactical-mind", "it"), Language = LanguageCode.It, Name = "Mente Tattica", Description = "Il guerriero ha una mente portata per la tattica, sul campo di battaglia e fuori. Quando fallisce una prova di caratteristica, può spendere un utilizzo di Recuperare energie per spingersi verso il successo: anziché recuperare punti ferita, tira 1d10 e somma il risultato alla prova, con la possibilità di trasformarla in un successo. Se la prova fallisce comunque, l'utilizzo di Recuperare energie non viene speso." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/fighter-subclass"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/fighter-subclass", "en"), Language = LanguageCode.En, Name = "Fighter Subclass", Description = "You gain a Fighter subclass of your choice. The Battle Master, Champion, Eldritch Knight, and Psi Warrior subclasses are detailed after this class’s description. A subclass is a specialization that grants you features at certain Fighter levels. For the rest of your career, you gain each of your subclass’s features that are of your Fighter level or lower." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/fighter-subclass", "it"), Language = LanguageCode.It, Name = "Sottoclasse del Guerriero", Description = "Il guerriero ottiene una sottoclasse del guerriero a sua scelta: Campione, Cavaliere Mistico, Guerriero Psionico o Maestro di Battaglia. Una sottoclasse è una specializzazione che conferisce privilegi a determinati livelli da guerriero. Per il resto della sua carriera, il guerriero ottiene ogni privilegio della sottoclasse di livello pari o inferiore al suo livello da guerriero." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "You gain the Ability Score Improvement feat (see chapter 5) or another feat of your choice for which you qualify. You gain this feature again at Fighter levels 6, 8, 12, 14, and 16." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Il guerriero ottiene il talento Aumento dei punteggi di caratteristica o un altro talento a sua scelta di cui soddisfa i prerequisiti. Ottiene di nuovo questo privilegio al 6°, all'8°, al 12°, al 14° e al 16° livello da guerriero." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "You can attack twice instead of once whenever you take the Attack action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Ogni volta che sceglie l'azione di Attacco durante il proprio turno, il guerriero effettua due attacchi invece di uno solo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/tactical-shift"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/tactical-shift", "en"), Language = LanguageCode.En, Name = "Tactical Shift", Description = "Whenever you activate your Second Wind with a Bonus Action, you can move up to half your Speed without provoking Opportunity Attacks." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/tactical-shift", "it"), Language = LanguageCode.It, Name = "Spostamento Tattico", Description = "Quando usa l'azione bonus per attivare Recuperare energie, il guerriero può anche spostarsi di un massimo pari a metà della propria velocità, e questo movimento non provoca attacchi di opportunità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/indomitable"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 9,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/indomitable", "en"), Language = LanguageCode.En, Name = "Indomitable", Description = "If you fail a saving throw, you can reroll it with a bonus equal to your Fighter level. You must use the new roll, and you can’t use this feature again until you finish a Long Rest.\n\nYou can use this feature twice before a Long Rest starting at level 13 and three times before a Long Rest starting at level 17." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/indomitable", "it"), Language = LanguageCode.It, Name = "Indomabile", Description = "Se fallisce un tiro salvezza, il guerriero può ripeterlo con un bonus pari al suo livello da guerriero. Deve usare il nuovo risultato e non può usare di nuovo questo privilegio finché non completa un riposo lungo.\n\nA partire dal 13° livello può usare questo privilegio due volte tra un riposo lungo e l'altro, e a partire dal 17° livello tre volte." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/tactical-master"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 9,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/tactical-master", "en"), Language = LanguageCode.En, Name = "Tactical Master", Description = "When you attack with a weapon whose mastery property you can use, you can replace that property with the Push, Sap, or Slow property for that attack." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/tactical-master", "it"), Language = LanguageCode.It, Name = "Signore delle Tattiche", Description = "Quando attacca con un'arma di cui può usare la proprietà di padronanza, il guerriero può sostituirla, per quell'attacco, con la proprietà Spinta, Prosciugamento o Lentezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/two-extra-attacks"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/two-extra-attacks", "en"), Language = LanguageCode.En, Name = "Two Extra Attacks", Description = "You can attack three times instead of once whenever you take the Attack action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/two-extra-attacks", "it"), Language = LanguageCode.It, Name = "Due Attacchi Extra", Description = "Ogni volta che sceglie l'azione di Attacco durante il proprio turno, il guerriero effettua tre attacchi invece di uno solo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/studied-attacks"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 13,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/studied-attacks", "en"), Language = LanguageCode.En, Name = "Studied Attacks", Description = "You study your opponents and learn from each attack you make. If you make an attack roll against a creature and miss, you have Advantage on your next attack roll against that creature before the end of your next turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/studied-attacks", "it"), Language = LanguageCode.It, Name = "Attacchi Studiati", Description = "Il guerriero studia i suoi avversari e impara da ogni attacco. Se effettua un tiro per colpire contro una creatura e lo manca, dispone di vantaggio al successivo tiro per colpire contro quella creatura effettuato prima della fine del suo turno successivo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/epic-boon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 19,
					SortOrder = 13,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/epic-boon", "en"), Language = LanguageCode.En, Name = "Epic Boon", Description = "You gain an Epic Boon feat (see chapter 5) or another feat of your choice for which you qualify. Boon of Combat Prowess is recommended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/epic-boon", "it"), Language = LanguageCode.It, Name = "Dono Epico", Description = "Il guerriero ottiene un talento Dono epico o un altro talento a sua scelta di cui soddisfa i prerequisiti. È consigliato il Dono delle abilità di combattimento." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/three-extra-attacks"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 14,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/three-extra-attacks", "en"), Language = LanguageCode.En, Name = "Three Extra Attacks", Description = "You can attack four times instead of once whenever you take the Attack action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fighter/three-extra-attacks", "it"), Language = LanguageCode.It, Name = "Tre Attacchi Extra", Description = "Ogni volta che sceglie l'azione di Attacco durante il proprio turno, il guerriero effettua quattro attacchi invece di uno solo." }
					}
				}
			}
		};
	}
}
