using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Cleric (2014 ruleset): class features of the SRD 5.1 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Cleric2014Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "cleric");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			HitDie = 8,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Wisdom },
			SavingThrows = new List<AbilityScore> { AbilityScore.Wisdom, AbilityScore.Charisma },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.History, Skill.Insight, Skill.Medicine, Skill.Persuasion, Skill.Religion },
			CasterProgression = CasterProgression.Full,
			SpellcastingAbility = AbilityScore.Wisdom,
			SubclassLevel = 1,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "cleric", "en"),
					Language = LanguageCode.En,
					Name = "Cleric",
					Description = "A priest who channels the power of a deity. Clerics heal and protect their companions, turn back the undead and wield divine magic shaped by the domain of their god, from life and light to war and storms.",
					SubclassTitle = "Divine Domain",
					ArmorProficiencies = "Light armor, medium armor, shields",
					WeaponProficiencies = "Simple weapons",
					ToolProficiencies = "None",
					StartingEquipment = "- (a) a mace or (b) a warhammer (if proficient)\n- (a) scale mail, (b) leather armor, or (c) chain mail (if proficient)\n- (a) a light crossbow and 20 bolts or (b) any simple weapon\n- (a) a priest’s pack or (b) an explorer’s pack\n- A shield and a holy symbol",
					ProgressionTable = "The 1st–9th columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Features | Cantrips Known | 1st | 2nd | 3rd | 4th | 5th | 6th | 7th | 8th | 9th |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1st | +2 | Spellcasting, Divine Domain | 3 | 2 | — | — | — | — | — | — | — | — |\n| 2nd | +2 | Channel Divinity (1/rest), Divine Domain feature | 3 | 3 | — | — | — | — | — | — | — | — |\n| 3rd | +2 | — | 3 | 4 | 2 | — | — | — | — | — | — | — |\n| 4th | +2 | Ability Score Improvement | 4 | 4 | 3 | — | — | — | — | — | — | — |\n| 5th | +3 | Destroy Undead (CR 1/2) | 4 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6th | +3 | Channel Divinity (2/rest), Divine Domain feature | 4 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7th | +3 | — | 4 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8th | +3 | Ability Score Improvement, Destroy Undead (CR 1), Divine Domain feature | 4 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9th | +4 | — | 4 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10th | +4 | Divine Intervention | 5 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11th | +4 | Destroy Undead (CR 2) | 5 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12th | +4 | Ability Score Improvement | 5 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13th | +5 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14th | +5 | Destroy Undead (CR 3) | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15th | +5 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16th | +5 | Ability Score Improvement | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17th | +6 | Destroy Undead (CR 4), Divine Domain feature | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18th | +6 | Channel Divinity (3/rest) | 5 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19th | +6 | Ability Score Improvement | 5 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20th | +6 | Divine Intervention improvement | 5 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "cleric", "it"),
					Language = LanguageCode.It,
					Name = "Chierico",
					Description = "Un sacerdote che incanala il potere di una divinità. Il chierico guarisce e protegge i compagni, respinge i non morti e impugna una magia divina plasmata dal dominio del suo dio, dalla vita e dalla luce fino alla guerra e alle tempeste.",
					SubclassTitle = "Dominio Divino",
					ArmorProficiencies = "Armature leggere, armature medie, scudi",
					WeaponProficiencies = "Armi semplici",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "- (a) una mazza o (b) un martello da guerra (se competente)\n- (a) una corazza di scaglie, (b) un'armatura di cuoio o (c) una cotta di maglia (se competente)\n- (a) una balestra leggera e 20 quadrelli o (b) una qualsiasi arma semplice\n- (a) una dotazione da sacerdote o (b) una dotazione da esploratore\n- Uno scudo e un simbolo sacro",
					ProgressionTable = "Le colonne 1°–9° indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi | Trucchetti conosciuti | 1° | 2° | 3° | 4° | 5° | 6° | 7° | 8° | 9° |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1° | +2 | Incantesimi, Dominio Divino | 3 | 2 | — | — | — | — | — | — | — | — |\n| 2° | +2 | Incanalare Divinità (1/riposo), Privilegio del Dominio Divino | 3 | 3 | — | — | — | — | — | — | — | — |\n| 3° | +2 | — | 3 | 4 | 2 | — | — | — | — | — | — | — |\n| 4° | +2 | Aumento dei Punteggi di Caratteristica | 4 | 4 | 3 | — | — | — | — | — | — | — |\n| 5° | +3 | Distruggere Non Morti (GS 1/2) | 4 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6° | +3 | Incanalare Divinità (2/riposo), Privilegio del Dominio Divino | 4 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7° | +3 | — | 4 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8° | +3 | Aumento dei Punteggi di Caratteristica, Distruggere Non Morti (GS 1), Privilegio del Dominio Divino | 4 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9° | +4 | — | 4 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10° | +4 | Intervento Divino | 5 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11° | +4 | Distruggere Non Morti (GS 2) | 5 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12° | +4 | Aumento dei Punteggi di Caratteristica | 5 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13° | +5 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14° | +5 | Distruggere Non Morti (GS 3) | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15° | +5 | — | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16° | +5 | Aumento dei Punteggi di Caratteristica | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17° | +6 | Distruggere Non Morti (GS 4), Privilegio del Dominio Divino | 5 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18° | +6 | Incanalare Divinità (3/riposo) | 5 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19° | +6 | Aumento dei Punteggi di Caratteristica | 5 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20° | +6 | Intervento Divino migliorato | 5 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "As a conduit for divine power, you can cast cleric spells.\n\n**Cantrips**\n\nAt 1st level, you know three cantrips of your choice from the cleric spell list. You learn additional cleric cantrips of your choice at higher levels, as shown in the Cantrips Known column of the Cleric table.\n\n**Preparing and Casting Spells**\n\nThe Cleric table shows how many spell slots you have to cast your spells of 1st level and higher. To cast one of these spells, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest.\n\nYou prepare the list of cleric spells that are available for you to cast, choosing from the cleric spell list. When you do so, choose a number of cleric spells equal to your Wisdom modifier + your cleric level (minimum of one spell). The spells must be of a level for which you have spell slots.\n\nFor example, if you are a 3rd-level cleric, you have four 1st-level and two 2nd-level spell slots. With a Wisdom of 16, your list of prepared spells can include six spells of 1st or 2nd level, in any combination. If you prepare the 1st-level spell cure wounds, you can cast it using a 1st-level or 2nd-level slot. Casting the spell doesn't remove it from your list of prepared spells.\n\nYou can change your list of prepared spells when you finish a long rest. Preparing a new list of cleric spells requires time spent in prayer and meditation: at least 1 minute per spell level for each spell on your list.\n\n**Spellcasting Ability**\n\nWisdom is your spellcasting ability for your cleric spells. The power of your spells comes from your devotion to your deity. You use your Wisdom whenever a cleric spell refers to your spellcasting ability. In addition, you use your Wisdom modifier when setting the saving throw DC for a cleric spell you cast and when making an attack roll with one.\n\n**Spell save DC** = 8 + your proficiency bonus + your Wisdom modifier\n\n**Spell attack modifier** = your proficiency bonus + your Wisdom modifier\n\n**Ritual Casting**\n\nYou can cast a cleric spell as a ritual if that spell has the ritual tag and you have the spell prepared.\n\n**Spellcasting Focus**\n\nYou can use a holy symbol as a spellcasting focus for your cleric spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "In quanto tramite del potere divino, il chierico può lanciare incantesimi da chierico.\n\n**Trucchetti**\n\nAl 1° livello il chierico conosce tre trucchetti a sua scelta dalla lista degli incantesimi del chierico. Apprende altri trucchetti da chierico a sua scelta ai livelli più alti, come indicato nella colonna \"Trucchetti conosciuti\" della tabella del Chierico.\n\n**Preparare e lanciare incantesimi**\n\nLa tabella del Chierico indica quanti slot incantesimo possiede il chierico per lanciare i suoi incantesimi di 1° livello e superiore. Per lanciare uno di questi incantesimi deve spendere uno slot di livello pari o superiore a quello dell'incantesimo. Recupera tutti gli slot incantesimo spesi quando completa un riposo lungo.\n\nIl chierico prepara la lista degli incantesimi da chierico che può lanciare, scegliendoli dalla lista degli incantesimi del chierico. Quando lo fa, sceglie un numero di incantesimi da chierico pari al suo modificatore di Saggezza + il suo livello da chierico (minimo un incantesimo). Gli incantesimi devono essere di un livello per cui possiede slot incantesimo.\n\nPer esempio, un chierico di 3° livello ha quattro slot incantesimo di 1° livello e due di 2° livello. Con Saggezza 16, la sua lista di incantesimi preparati può includere sei incantesimi di 1° o di 2° livello, in qualsiasi combinazione. Se prepara l'incantesimo di 1° livello *cura ferite*, può lanciarlo usando uno slot di 1° o di 2° livello. Lanciare l'incantesimo non lo rimuove dalla lista degli incantesimi preparati.\n\nIl chierico può cambiare la sua lista di incantesimi preparati quando completa un riposo lungo. Preparare una nuova lista di incantesimi da chierico richiede tempo dedicato alla preghiera e alla meditazione: almeno 1 minuto per livello di incantesimo per ogni incantesimo della lista.\n\n**Caratteristica da incantatore**\n\nLa Saggezza è la caratteristica da incantatore del chierico per i suoi incantesimi da chierico: il potere dei suoi incantesimi deriva dalla devozione verso la sua divinità. Il chierico usa la Saggezza ogni volta che un incantesimo da chierico fa riferimento alla sua caratteristica da incantatore. Usa inoltre il modificatore di Saggezza per stabilire la CD dei tiri salvezza di un incantesimo da chierico che lancia e quando effettua un tiro per colpire con uno di essi.\n\n**CD del tiro salvezza degli incantesimi** = 8 + bonus di competenza + modificatore di Saggezza\n\n**Modificatore di attacco degli incantesimi** = bonus di competenza + modificatore di Saggezza\n\n**Celebrare rituali**\n\nIl chierico può lanciare un incantesimo da chierico come rituale se quell'incantesimo ha il descrittore rituale e se lo ha preparato.\n\n**Focus da incantatore**\n\nIl chierico può usare un simbolo sacro come focus da incantatore per i suoi incantesimi da chierico." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/divine-domain"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/divine-domain", "en"), Language = LanguageCode.En, Name = "Divine Domain", Description = "Choose one domain related to your deity, such as Life. Your choice grants you domain spells and other features when you choose it at 1st level. It also grants you additional ways to use Channel Divinity when you gain that feature at 2nd level, and additional benefits at 6th, 8th, and 17th levels.\n\n**Domain Spells**\n\nEach domain has a list of spells—its domain spells—that you gain at the cleric levels noted in the domain description. Once you gain a domain spell, you always have it prepared, and it doesn't count against the number of spells you can prepare each day.\n\nIf you have a domain spell that doesn't appear on the cleric spell list, the spell is nonetheless a cleric spell for you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/divine-domain", "it"), Language = LanguageCode.It, Name = "Dominio Divino", Description = "Il chierico sceglie un dominio legato alla sua divinità, come la Vita. La scelta gli conferisce incantesimi di dominio e altri privilegi al 1° livello. Gli conferisce inoltre nuovi modi di usare Incanalare Divinità quando ottiene quel privilegio al 2° livello, e ulteriori benefici al 6°, all'8° e al 17° livello.\n\n**Incantesimi di dominio**\n\nOgni dominio ha una lista di incantesimi, i suoi incantesimi di dominio, che il chierico ottiene ai livelli da chierico indicati nella descrizione del dominio. Una volta ottenuto un incantesimo di dominio, il chierico lo considera sempre preparato e non lo conta nel numero di incantesimi che può preparare ogni giorno.\n\nSe un incantesimo di dominio non compare nella lista degli incantesimi del chierico, per lui è comunque un incantesimo da chierico." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/channel-divinity"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/channel-divinity", "en"), Language = LanguageCode.En, Name = "Channel Divinity", Description = "At 2nd level, you gain the ability to channel divine energy directly from your deity, using that energy to fuel magical effects. You start with two such effects: Turn Undead and an effect determined by your domain. Some domains grant you additional effects as you advance in levels, as noted in the domain description.\n\nWhen you use your Channel Divinity, you choose which effect to create. You must then finish a short or long rest to use your Channel Divinity again. Some Channel Divinity effects require saving throws. When you use such an effect from this class, the DC equals your cleric spell save DC.\n\nBeginning at 6th level, you can use your Channel Divinity twice between rests, and beginning at 18th level, you can use it three times between rests. When you finish a short or long rest, you regain your expended uses." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/channel-divinity", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità", Description = "Al 2° livello il chierico ottiene la capacità di incanalare energia divina direttamente dalla sua divinità, usandola per alimentare effetti magici. Inizia con due effetti di questo tipo: Scacciare Non Morti e un effetto determinato dal suo dominio. Alcuni domini conferiscono effetti aggiuntivi man mano che il chierico sale di livello, come indicato nella descrizione del dominio.\n\nQuando usa Incanalare Divinità, il chierico sceglie quale effetto creare. Deve poi completare un riposo breve o lungo per poter usare di nuovo Incanalare Divinità. Alcuni effetti di Incanalare Divinità richiedono tiri salvezza: quando il chierico usa un effetto di questo tipo concesso da questa classe, la CD è pari alla CD del tiro salvezza dei suoi incantesimi da chierico.\n\nA partire dal 6° livello il chierico può usare Incanalare Divinità due volte tra un riposo e l'altro, e a partire dal 18° livello tre volte. Quando completa un riposo breve o lungo, recupera gli utilizzi spesi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/channel-divinity-turn-undead"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/channel-divinity-turn-undead", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Turn Undead", Description = "As an action, you present your holy symbol and speak a prayer censuring the undead.\n\nEach undead that can see or hear you within 30 feet of you must make a Wisdom saving throw. If the creature fails its saving throw, it is turned for 1 minute or until it takes any damage.\n\nA turned creature must spend its turns trying to move as far away from you as it can, and it can't willingly move to a space within 30 feet of you. It also can't take reactions.\n\nFor its action, it can use only the Dash action or try to escape from an effect that prevents it from moving. If there's nowhere to move, the creature can use the Dodge action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/channel-divinity-turn-undead", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Scacciare Non Morti", Description = "Come azione, il chierico presenta il suo simbolo sacro e pronuncia una preghiera di condanna contro i non morti.\n\nOgni non morto entro 9 metri dal chierico che è in grado di vederlo o di sentirlo deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, la creatura è scacciata per 1 minuto o finché non subisce danni.\n\nUna creatura scacciata deve passare i suoi turni cercando di allontanarsi il più possibile dal chierico e non può spostarsi volontariamente in uno spazio entro 9 metri da lui. Inoltre non può effettuare reazioni.\n\nCome azione può usare soltanto l'azione di Scatto o cercare di liberarsi da un effetto che le impedisce di muoversi. Se non ha alcun posto in cui muoversi, la creatura può usare l'azione di Schivata." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Quando arriva al 4° livello, e poi all'8°, al 12°, al 16° e al 19° livello, il personaggio può aumentare di 2 un punteggio di caratteristica a sua scelta, oppure aumentare di 1 due punteggi di caratteristica a sua scelta. Come di consueto, questo privilegio non consente di aumentare un punteggio di caratteristica oltre 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/destroy-undead"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 5,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/destroy-undead", "en"), Language = LanguageCode.En, Name = "Destroy Undead", Description = "Starting at 5th level, when an undead fails its saving throw against your Turn Undead feature, the creature is instantly destroyed if its challenge rating is at or below a certain threshold, as shown in the table below.\n\n| Cleric Level | Destroys Undead of CR... |\n|---|---|\n| 5th | 1/2 or lower |\n| 8th | 1 or lower |\n| 11th | 2 or lower |\n| 14th | 3 or lower |\n| 17th | 4 or lower |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/destroy-undead", "it"), Language = LanguageCode.It, Name = "Distruggere Non Morti", Description = "A partire dal 5° livello, quando un non morto fallisce il tiro salvezza contro il privilegio Scacciare Non Morti del chierico, la creatura viene distrutta all'istante se il suo grado di sfida è pari o inferiore a una certa soglia, come indicato nella tabella seguente.\n\n| Livello da chierico | Distrugge i non morti di GS... |\n|---|---|\n| 5° | 1/2 o inferiore |\n| 8° | 1 o inferiore |\n| 11° | 2 o inferiore |\n| 14° | 3 o inferiore |\n| 17° | 4 o inferiore |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/divine-intervention"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/divine-intervention", "en"), Language = LanguageCode.En, Name = "Divine Intervention", Description = "Beginning at 10th level, you can call on your deity to intervene on your behalf when your need is great.\n\nImploring your deity's aid requires you to use your action. Describe the assistance you seek, and roll percentile dice. If you roll a number equal to or lower than your cleric level, your deity intervenes. The GM chooses the nature of the intervention; the effect of any cleric spell or cleric domain spell would be appropriate.\n\nIf your deity intervenes, you can't use this feature again for 7 days. Otherwise, you can use it again after you finish a long rest.\n\nAt 20th level, your call for intervention succeeds automatically, no roll required." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "cleric/divine-intervention", "it"), Language = LanguageCode.It, Name = "Intervento Divino", Description = "A partire dal 10° livello, il chierico può invocare l'intervento della sua divinità quando ne ha più bisogno.\n\nImplorare l'aiuto della divinità richiede di usare la propria azione. Il chierico descrive l'assistenza che cerca e tira dadi percentuali. Se ottiene un risultato pari o inferiore al suo livello da chierico, la divinità interviene. Il DM sceglie la natura dell'intervento; l'effetto di qualsiasi incantesimo da chierico o incantesimo di dominio del chierico sarebbe appropriato.\n\nSe la divinità interviene, il chierico non può usare di nuovo questo privilegio per 7 giorni. Altrimenti, può usarlo di nuovo dopo aver completato un riposo lungo.\n\nAl 20° livello la richiesta di intervento ha successo automaticamente, senza bisogno di tirare." }
					}
				}
			}
		};
	}
}
