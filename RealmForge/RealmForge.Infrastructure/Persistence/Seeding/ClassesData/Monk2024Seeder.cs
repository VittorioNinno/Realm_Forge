using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Monk (2024 ruleset): class features of the SRD 5.2 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Monk2024Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "monk");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "monk", "en"),
					Language = LanguageCode.En,
					Name = "Monk",
					Description = "A martial artist who turns body and mind into weapons. Through rigorous discipline Monks channel an inner energy that lets them strike with blinding speed, turn aside blows and arrows, run along walls and shrug off harm, fighting best without armor or heavy weapons.",
					SubclassTitle = "Monk Subclass",
					ArmorProficiencies = "None",
					WeaponProficiencies = "Simple weapons and Martial weapons that have the Light property",
					ToolProficiencies = "Choose one type of Artisan's Tools or Musical Instrument",
					StartingEquipment = "Choose A or B:\n- (A) Spear, 5 Daggers, Artisan's Tools or Musical Instrument chosen for the tool proficiency above, Explorer's Pack and 11 GP\n- (B) 50 GP",
					ProgressionTable = "| Level | Proficiency Bonus | Class Features | Martial Arts | Focus Points | Unarmored Movement |\n|---|---|---|---|---|---|\n| 1 | +2 | Martial Arts, Unarmored Defense | 1d6 | — | — |\n| 2 | +2 | Monk's Focus, Unarmored Movement, Uncanny Metabolism | 1d6 | 2 | +10 ft. |\n| 3 | +2 | Deflect Attacks, Monk Subclass | 1d6 | 3 | +10 ft. |\n| 4 | +2 | Ability Score Improvement, Slow Fall | 1d6 | 4 | +10 ft. |\n| 5 | +3 | Extra Attack, Stunning Strike | 1d8 | 5 | +10 ft. |\n| 6 | +3 | Empowered Strikes, Subclass feature | 1d8 | 6 | +15 ft. |\n| 7 | +3 | Evasion | 1d8 | 7 | +15 ft. |\n| 8 | +3 | Ability Score Improvement | 1d8 | 8 | +15 ft. |\n| 9 | +4 | Acrobatic Movement | 1d8 | 9 | +15 ft. |\n| 10 | +4 | Heightened Focus, Self-Restoration | 1d8 | 10 | +20 ft. |\n| 11 | +4 | Subclass feature | 1d10 | 11 | +20 ft. |\n| 12 | +4 | Ability Score Improvement | 1d10 | 12 | +20 ft. |\n| 13 | +5 | Deflect Energy | 1d10 | 13 | +20 ft. |\n| 14 | +5 | Disciplined Survivor | 1d10 | 14 | +25 ft. |\n| 15 | +5 | Perfect Focus | 1d10 | 15 | +25 ft. |\n| 16 | +5 | Ability Score Improvement | 1d10 | 16 | +25 ft. |\n| 17 | +6 | Subclass feature | 1d12 | 17 | +25 ft. |\n| 18 | +6 | Superior Defense | 1d12 | 18 | +30 ft. |\n| 19 | +6 | Epic Boon | 1d12 | 19 | +30 ft. |\n| 20 | +6 | Body and Mind | 1d12 | 20 | +30 ft. |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "monk", "it"),
					Language = LanguageCode.It,
					Name = "Monaco",
					Description = "Un artista marziale che trasforma corpo e mente in armi. Grazie a una disciplina rigorosa, il monaco incanala un'energia interiore che gli permette di colpire con una rapidità accecante, deviare colpi e frecce, correre lungo le pareti e ignorare il dolore, dando il meglio di sé senza armatura né armi pesanti.",
					SubclassTitle = "Sottoclasse del monaco",
					ArmorProficiencies = "Nessuna",
					WeaponProficiencies = "Armi semplici e armi da guerra con la proprietà leggera",
					ToolProficiencies = "Un tipo di strumenti da artigiano o uno strumento musicale a scelta",
					StartingEquipment = "A scelta tra A e B:\n- (A) una lancia, 5 pugnali, gli strumenti da artigiano o lo strumento musicale scelti per la competenza negli strumenti, una dotazione da esploratore e 11 mo\n- (B) 50 mo",
					ProgressionTable = "| Livello | Bonus di competenza | Privilegi di classe | Arti marziali | Punti concentrazione | Movimento senza armatura |\n|---|---|---|---|---|---|\n| 1 | +2 | Arti Marziali, Difesa Senza Armatura | 1d6 | — | — |\n| 2 | +2 | Concentrazione da Monaco, Movimento Senza Armatura, Metabolismo Straordinario | 1d6 | 2 | +3 m |\n| 3 | +2 | Deviare Attacchi, Sottoclasse del Monaco | 1d6 | 3 | +3 m |\n| 4 | +2 | Aumento dei Punteggi di Caratteristica, Caduta Lenta | 1d6 | 4 | +3 m |\n| 5 | +3 | Attacco Extra, Colpo Stordente | 1d8 | 5 | +3 m |\n| 6 | +3 | Colpi Potenziati, Privilegio della sottoclasse | 1d8 | 6 | +4,5 m |\n| 7 | +3 | Elusione | 1d8 | 7 | +4,5 m |\n| 8 | +3 | Aumento dei Punteggi di Caratteristica | 1d8 | 8 | +4,5 m |\n| 9 | +4 | Movimento Acrobatico | 1d8 | 9 | +4,5 m |\n| 10 | +4 | Concentrazione Superiore, Autorigenerazione | 1d8 | 10 | +6 m |\n| 11 | +4 | Privilegio della sottoclasse | 1d10 | 11 | +6 m |\n| 12 | +4 | Aumento dei Punteggi di Caratteristica | 1d10 | 12 | +6 m |\n| 13 | +5 | Deviare Energia | 1d10 | 13 | +6 m |\n| 14 | +5 | Sopravvissuto Disciplinato | 1d10 | 14 | +7,5 m |\n| 15 | +5 | Concentrazione Perfetta | 1d10 | 15 | +7,5 m |\n| 16 | +5 | Aumento dei Punteggi di Caratteristica | 1d10 | 16 | +7,5 m |\n| 17 | +6 | Privilegio della sottoclasse | 1d12 | 17 | +7,5 m |\n| 18 | +6 | Difesa Superiore | 1d12 | 18 | +9 m |\n| 19 | +6 | Dono Epico | 1d12 | 19 | +9 m |\n| 20 | +6 | Corpo e Mente | 1d12 | 20 | +9 m |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/martial-arts"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/martial-arts", "en"), Language = LanguageCode.En, Name = "Martial Arts", Description = "Your practice of martial arts gives you mastery of combat styles that use your Unarmed Strike and Monk weapons, which are the following:\n\n- Simple Melee weapons;\n- Martial Melee weapons that have the Light property.\n\nYou gain the following benefits while you are unarmed or wielding only Monk weapons and you aren't wearing armor or wielding a Shield.\n\n**Bonus Unarmed Strike.** You can make an Unarmed Strike as a Bonus Action.\n\n**Martial Arts Die.** You can roll 1d6 in place of the normal damage of your Unarmed Strike or Monk weapons. This die changes as you gain Monk levels, as shown in the Martial Arts column of the Monk Features table.\n\n**Dexterous Attacks.** You can use your Dexterity modifier instead of your Strength modifier for the attack and damage rolls of your Unarmed Strikes and Monk weapons. In addition, when you use the Grapple or Shove option of your Unarmed Strike, you can use your Dexterity modifier instead of your Strength modifier to determine the save DC." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/martial-arts", "it"), Language = LanguageCode.It, Name = "Arti Marziali", Description = "La pratica delle arti marziali conferisce al monaco la padronanza di stili di combattimento che sfruttano i colpi senz'armi e le armi da monaco, ovvero:\n\n- le armi semplici da mischia;\n- le armi da guerra da mischia con la proprietà leggera.\n\nIl monaco ottiene i benefici seguenti finché è disarmato o impugna soltanto armi da monaco, e non indossa armature né impugna uno scudo.\n\n**Colpo senz'armi bonus.** Il monaco può effettuare un colpo senz'armi come azione bonus.\n\n**Dado di arti marziali.** Il monaco può tirare 1d6 al posto dei danni normali dei suoi colpi senz'armi o delle sue armi da monaco. Questo dado cambia man mano che sale di livello come monaco, come indicato nella colonna Arti marziali della tabella dei privilegi del monaco.\n\n**Attacchi destri.** Il monaco può usare il modificatore di Destrezza anziché quello di Forza per i tiri per colpire e per i danni dei colpi senz'armi e delle armi da monaco. Inoltre, quando usa l'opzione Lottare o Spingere del colpo senz'armi, può usare il modificatore di Destrezza anziché quello di Forza per determinare la CD del tiro salvezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/unarmored-defense"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/unarmored-defense", "en"), Language = LanguageCode.En, Name = "Unarmored Defense", Description = "While you aren’t wearing armor or wielding a Shield, your base Armor Class equals 10 plus your Dexterity and Wisdom modifiers." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/unarmored-defense", "it"), Language = LanguageCode.It, Name = "Difesa Senza Armatura", Description = "Finché non indossa armature e non impugna uno scudo, la Classe Armatura base del monaco è pari a 10 + il suo modificatore di Destrezza + il suo modificatore di Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/monks-focus"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/monks-focus", "en"), Language = LanguageCode.En, Name = "Monk's Focus", Description = "Your focus and martial training allow you to harness a well of extraordinary energy within yourself. This energy is represented by Focus Points. Your Monk level determines the number of points you have, as shown in the Focus Points column of the Monk Features table. You can expend these points to enhance or fuel certain Monk features. You start knowing three such features: Flurry of Blows, Patient Defense, and Step of the Wind, each of which is detailed below.\n\nWhen you expend a Focus Point, it is unavailable until you finish a Short or Long Rest, at the end of which you regain all your expended points.\n\nSome features that use Focus Points require your target to make a saving throw. The save DC equals 8 plus your Wisdom modifier and Proficiency Bonus.\n\n**Flurry of Blows.** You can expend 1 Focus Point to make two Unarmed Strikes as a Bonus Action.\n\n**Patient Defense.** You can take the Disengage action as a Bonus Action. Alternatively, you can expend 1 Focus Point to take both the Disengage and the Dodge actions as a Bonus Action.\n\n**Step of the Wind.** You can take the Dash action as a Bonus Action. Alternatively, you can expend 1 Focus Point to take both the Disengage and Dash actions as a Bonus Action, and your jump distance is doubled for the turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/monks-focus", "it"), Language = LanguageCode.It, Name = "Concentrazione da Monaco", Description = "La concentrazione e l'addestramento marziale permettono al monaco di attingere a una riserva di energia straordinaria dentro di sé, rappresentata dai punti concentrazione. Il numero di punti posseduti dipende dal suo livello da monaco, come indicato nella colonna Punti concentrazione della tabella dei privilegi del monaco. Il monaco può spendere questi punti per potenziare o alimentare determinati privilegi da monaco; inizialmente ne conosce tre, Raffica di colpi, Difesa paziente e Passo del vento, descritti di seguito.\n\nUn punto concentrazione speso non è più disponibile finché il monaco non completa un riposo breve o lungo, al termine del quale recupera tutti i punti spesi.\n\nAlcuni privilegi che usano i punti concentrazione richiedono al bersaglio un tiro salvezza; la CD è pari a 8 + il modificatore di Saggezza del monaco + il suo bonus di competenza.\n\n**Raffica di colpi.** Il monaco può spendere 1 punto concentrazione per effettuare due colpi senz'armi come azione bonus.\n\n**Difesa paziente.** Il monaco può effettuare l'azione di Disimpegno come azione bonus. In alternativa, può spendere 1 punto concentrazione per effettuare sia l'azione di Disimpegno sia quella di Schivata come azione bonus.\n\n**Passo del vento.** Il monaco può effettuare l'azione di Scatto come azione bonus. In alternativa, può spendere 1 punto concentrazione per effettuare sia l'azione di Disimpegno sia quella di Scatto come azione bonus; in tal caso, la distanza dei suoi salti raddoppia per quel turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/unarmored-movement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/unarmored-movement", "en"), Language = LanguageCode.En, Name = "Unarmored Movement", Description = "Your speed increases by 10 feet while you aren’t wearing armor or wielding a Shield. This bonus increases when you reach certain Monk levels, as shown on the Monk Features table." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/unarmored-movement", "it"), Language = LanguageCode.It, Name = "Movimento Senza Armatura", Description = "Finché non indossa armature e non impugna uno scudo, la velocità del monaco aumenta di 3 metri. Questo bonus aumenta a determinati livelli da monaco, come indicato nella tabella dei privilegi del monaco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/uncanny-metabolism"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/uncanny-metabolism", "en"), Language = LanguageCode.En, Name = "Uncanny Metabolism", Description = "When you roll Initiative, you can regain all expended Focus Points. When you do so, roll your Martial Arts die, and regain a number of Hit Points equal to your Monk level plus the number rolled.\n\nOnce you use this feature, you can’t use it again until you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/uncanny-metabolism", "it"), Language = LanguageCode.It, Name = "Metabolismo Straordinario", Description = "Nel momento in cui tira l'iniziativa, il monaco può riprendersi ogni punto concentrazione speso; se lo fa, tira anche il dado di Arti marziali e recupera punti ferita pari al risultato più il suo livello da monaco.\n\nDopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/deflect-attacks"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/deflect-attacks", "en"), Language = LanguageCode.En, Name = "Deflect Attacks", Description = "When an attack roll hits you and its damage includes Bludgeoning, Piercing, or Slashing damage, you can take a Reaction to reduce the attack’s total damage against you. The reduction equals 1d10 plus your Dexterity modifier and Monk level.\n\nIf you reduce the damage to 0, you can expend 1 Focus Point to redirect some of the attack’s force. If you do so, choose a creature you can see within 5 feet of yourself if the attack was a melee attack or a creature you can see within 60 feet of yourself that isn’t behind Total Cover if the attack was a ranged attack. That creature must succeed on a Dexterity saving throw or take damage equal to two rolls of your Martial Arts die plus your Dexterity modifier. The damage is the same type dealt by the attack." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/deflect-attacks", "it"), Language = LanguageCode.It, Name = "Deviare Attacchi", Description = "Quando viene colpito da un tiro per colpire i cui danni includono danni contundenti, perforanti o taglienti, il monaco può usare una reazione per ridurre i danni totali dell'attacco subiti. La riduzione è pari a 1d10 + il suo modificatore di Destrezza + il suo livello da monaco.\n\nSe riduce i danni a 0, può spendere 1 punto concentrazione per reindirizzare parte della forza dell'attacco. In tal caso sceglie una creatura che è in grado di vedere: entro 1,5 metri da lui se l'attacco era in mischia, oppure entro 18 metri e non dietro copertura totale se l'attacco era a distanza. Quella creatura deve superare un tiro salvezza su Destrezza, altrimenti subisce danni pari a due tiri del dado di Arti marziali + il modificatore di Destrezza del monaco, dello stesso tipo dell'attacco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/monk-subclass"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/monk-subclass", "en"), Language = LanguageCode.En, Name = "Monk Subclass", Description = "You gain a Monk subclass of your choice. The Warrior of Mercy, Warrior of Shadow, Warrior of the Elements, and Warrior of the Open Hand subclasses are detailed after this class’s description. A subclass is a specialization that grants you features at certain Monk levels. For the rest of your career, you gain each of your subclass’s features that are of your Monk level or lower." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/monk-subclass", "it"), Language = LanguageCode.It, Name = "Sottoclasse del Monaco", Description = "Il monaco ottiene una sottoclasse del monaco a sua scelta: Guerriero degli Elementi, Guerriero della Mano Aperta, Guerriero della Misericordia o Guerriero dell'Ombra. Una sottoclasse è una specializzazione che conferisce privilegi a determinati livelli da monaco. Per il resto della sua carriera, il monaco ottiene ogni privilegio della sottoclasse di livello pari o inferiore al suo livello da monaco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "You gain the Ability Score Improvement feat (see chapter 5) or another feat of your choice for which you qualify. You gain this feature again at Monk levels 8, 12, and 16." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Il monaco ottiene il talento Aumento dei punteggi di caratteristica o un altro talento a sua scelta di cui soddisfa i prerequisiti. Ottiene di nuovo questo privilegio all'8°, al 12° e al 16° livello da monaco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/slow-fall"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/slow-fall", "en"), Language = LanguageCode.En, Name = "Slow Fall", Description = "You can take a Reaction when you fall to reduce any damage you take from the fall by an amount equal to five times your Monk level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/slow-fall", "it"), Language = LanguageCode.It, Name = "Caduta Lenta", Description = "Quando cade, il monaco può usare una reazione per ridurre i danni da caduta che subisce di un ammontare pari a cinque volte il suo livello da monaco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "You can attack twice instead of once whenever you take the Attack action on your turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Ogni volta che sceglie l'azione di Attacco durante il proprio turno, il monaco effettua due attacchi invece di uno solo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/stunning-strike"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/stunning-strike", "en"), Language = LanguageCode.En, Name = "Stunning Strike", Description = "Once per turn when you hit a creature with a Monk weapon or an Unarmed Strike, you can expend 1 Focus Point to attempt a stunning strike. The target must make a Constitution saving throw. On a failed save, the target has the Stunned condition until the start of your next turn. On a successful save, the target’s Speed is halved until the start of your next turn, and the next attack roll made against the target before then has Advantage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/stunning-strike", "it"), Language = LanguageCode.It, Name = "Colpo Stordente", Description = "Una sola volta per turno, dopo aver colpito una creatura con un colpo senz'armi o con un'arma da monaco, il monaco può spendere 1 punto concentrazione per tentare di stordirla. La creatura tira un tiro salvezza su Costituzione. Fallendo, resta stordita fino a quando non comincia il prossimo turno del monaco. Riuscendo, fino a quel momento si muove a velocità dimezzata e il primo tiro per colpire diretto contro di essa ha vantaggio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/empowered-strikes"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/empowered-strikes", "en"), Language = LanguageCode.En, Name = "Empowered Strikes", Description = "Whenever you deal damage with your Unarmed Strike, it can deal your choice of Force damage or its normal damage type." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/empowered-strikes", "it"), Language = LanguageCode.It, Name = "Colpi Potenziati", Description = "Ogni volta che infligge danni con un colpo senz'armi, il monaco può scegliere se infliggere danni da forza o il tipo di danni normale del colpo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/evasion"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/evasion", "en"), Language = LanguageCode.En, Name = "Evasion", Description = "When you’re subjected to an effect that allows you to make a Dexterity saving throw to take only half damage, you instead take no damage if you succeed on the saving throw and only half damage if you fail.\n\nYou don’t benefit from this feature if you have the Incapacitated condition." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/evasion", "it"), Language = LanguageCode.It, Name = "Elusione", Description = "Quando è soggetto a un effetto che gli permette di effettuare un tiro salvezza su Destrezza per subire solo la metà dei danni, il monaco non subisce alcun danno se supera il tiro salvezza e subisce solo la metà dei danni se lo fallisce.\n\nIl monaco non beneficia di questo privilegio se è incapacitato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/acrobatic-movement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 9,
					SortOrder = 13,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/acrobatic-movement", "en"), Language = LanguageCode.En, Name = "Acrobatic Movement", Description = "While you aren’t wearing armor or wielding a Shield, you gain the ability to move along vertical surfaces and across liquids on your turn without falling during the movement." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/acrobatic-movement", "it"), Language = LanguageCode.It, Name = "Movimento Acrobatico", Description = "Finché non indossa armature e non impugna uno scudo, durante il suo turno il monaco può muoversi lungo superfici verticali e sopra i liquidi senza cadere durante il movimento." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/heightened-focus"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 14,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/heightened-focus", "en"), Language = LanguageCode.En, Name = "Heightened Focus", Description = "Your Flurry of Blows, Patient Defense, and Step of the Wind gain the following benefits.\n\n**Flurry of Blows.** You can expend 1 Focus Point to use Flurry of Blows and make three Unarmed Strikes with it instead of two.\n\n**Patient Defense.** When you expend a Focus Point to use Patient Defense, you gain a number of Temporary Hit Points equal to two rolls of your Martial Arts die.\n\n**Step of the Wind.** When you expend a Focus Point to use Step of the Wind, you can choose a willing creature within 5 feet of yourself that is Large or smaller. You move the creature with you until the end of your turn. The creature’s movement doesn’t provoke Opportunity Attacks." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/heightened-focus", "it"), Language = LanguageCode.It, Name = "Concentrazione Superiore", Description = "Raffica di colpi, Difesa paziente e Passo del vento ottengono i benefici seguenti.\n\n**Raffica di colpi.** Il monaco può spendere 1 punto concentrazione per usare Raffica di colpi ed effettuare tre colpi senz'armi anziché due.\n\n**Difesa paziente.** Quando spende un punto concentrazione per usare Difesa paziente, il monaco ottiene un numero di punti ferita temporanei pari a due tiri del dado di Arti marziali.\n\n**Passo del vento.** Quando spende un punto concentrazione per usare Passo del vento, il monaco può scegliere una creatura consenziente di taglia Grande o inferiore entro 1,5 metri da lui: la porta con sé fino alla fine del turno, e il movimento di quella creatura non provoca attacchi di opportunità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/self-restoration"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 15,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/self-restoration", "en"), Language = LanguageCode.En, Name = "Self-Restoration", Description = "Through sheer force of will, you can remove one of the following conditions from yourself at the end of each of your turns: Charmed, Frightened, or Poisoned.\n\nIn addition, forgoing food and drink doesn’t give you levels of Exhaustion." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/self-restoration", "it"), Language = LanguageCode.It, Name = "Autorigenerazione", Description = "Con la sola forza di volontà, alla fine di ognuno dei suoi turni il monaco può liberarsi di una delle condizioni seguenti: affascinato, avvelenato o spaventato.\n\nInoltre, rinunciare al cibo e all'acqua non gli fa subire livelli di indebolimento." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/deflect-energy"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 13,
					SortOrder = 16,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/deflect-energy", "en"), Language = LanguageCode.En, Name = "Deflect Energy", Description = "You can now use your Deflect Attacks feature against attacks that deal any damage type, not just Bludgeoning, Piercing, or Slashing." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/deflect-energy", "it"), Language = LanguageCode.It, Name = "Deviare Energia", Description = "Il monaco può ora usare Deviare attacchi contro attacchi che infliggono danni di qualsiasi tipo, non solo contundenti, perforanti o taglienti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/disciplined-survivor"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 17,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/disciplined-survivor", "en"), Language = LanguageCode.En, Name = "Disciplined Survivor", Description = "Your physical and mental discipline grant you proficiency in all saving throws.\n\nAdditionally, whenever you make a saving throw and fail, you can expend 1 Focus Point to reroll it, and you must use the new roll." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/disciplined-survivor", "it"), Language = LanguageCode.It, Name = "Sopravvissuto Disciplinato", Description = "La disciplina fisica e mentale del monaco gli conferisce competenza in tutti i tiri salvezza.\n\nInoltre, ogni volta che fallisce un tiro salvezza, può spendere 1 punto concentrazione per ripeterlo, e deve usare il nuovo risultato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/perfect-focus"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 18,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/perfect-focus", "en"), Language = LanguageCode.En, Name = "Perfect Focus", Description = "When you roll Initiative and don’t use Uncanny Metabolism, you regain expended Focus Points until you have 4 if you have 3 or fewer." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/perfect-focus", "it"), Language = LanguageCode.It, Name = "Concentrazione Perfetta", Description = "Quando tira per l'iniziativa e non usa Metabolismo straordinario, se gli restano 3 punti concentrazione o meno, il monaco ne recupera fino ad averne 4." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/superior-defense"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 19,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/superior-defense", "en"), Language = LanguageCode.En, Name = "Superior Defense", Description = "At the start of your turn, you can expend 3 Focus Points to bolster yourself against harm for 1 minute or until you have the Incapacitated condition. During that time, you have Resistance to all damage except Force damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/superior-defense", "it"), Language = LanguageCode.It, Name = "Difesa Superiore", Description = "All'inizio del suo turno, il monaco può spendere 3 punti concentrazione per proteggersi dai danni per 1 minuto o finché non subisce la condizione di incapacitato. Per quella durata ha resistenza a tutti i danni tranne quelli da forza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/epic-boon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 19,
					SortOrder = 20,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/epic-boon", "en"), Language = LanguageCode.En, Name = "Epic Boon", Description = "You gain an Epic Boon feat (see chapter 5) or another feat of your choice for which you qualify. Boon of Irresistible Offense is recommended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/epic-boon", "it"), Language = LanguageCode.It, Name = "Dono Epico", Description = "Il monaco ottiene un talento Dono epico o un altro talento a sua scelta di cui soddisfa i prerequisiti. È consigliato il Dono dell'offensiva irresistibile." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/body-and-mind"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 21,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/body-and-mind", "en"), Language = LanguageCode.En, Name = "Body and Mind", Description = "You have developed your body and mind to new heights. Your Dexterity and Wisdom scores increase by 4, to a maximum of 25." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "monk/body-and-mind", "it"), Language = LanguageCode.It, Name = "Corpo e Mente", Description = "Il monaco ha portato il corpo e la mente a nuove vette: i suoi punteggi di Destrezza e di Saggezza aumentano di 4, fino a un massimo di 25." }
					}
				}
			}
		};
	}
}
