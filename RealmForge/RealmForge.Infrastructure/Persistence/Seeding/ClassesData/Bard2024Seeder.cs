using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Bard (2024 ruleset): class features of the SRD 5.2 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Bard2024Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "bard");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			HitDie = 8,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Charisma },
			SavingThrows = new List<AbilityScore> { AbilityScore.Dexterity, AbilityScore.Charisma },
			SkillChoiceCount = 3,
			SkillOptions = new List<Skill> {  },
			CasterProgression = CasterProgression.Full,
			SpellcastingAbility = AbilityScore.Charisma,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "bard", "en"),
					Language = LanguageCode.En,
					Name = "Bard",
					Description = "A performer whose music, dance and verse carry real magic. Bards inspire their allies, unsettle their enemies, heal wounds and weave illusions, drawing on echoes of the Words of Creation that still resound across the planes.",
					SubclassTitle = "Bard Subclass",
					ArmorProficiencies = "Light armor",
					WeaponProficiencies = "Simple weapons",
					ToolProficiencies = "Choose 3 Musical Instruments",
					StartingEquipment = "Choose A or B:\n- (A) Leather Armor, 2 Daggers, Musical Instrument of your choice, Entertainer's Pack and 19 GP\n- (B) 90 GP",
					ProgressionTable = "The 1–9 columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Class Features | Bardic Die | Cantrips | Prepared Spells | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Bardic Inspiration, Spellcasting | d6 | 2 | 4 | 2 | — | — | — | — | — | — | — | — |\n| 2 | +2 | Expertise, Jack of All Trades | d6 | 2 | 5 | 3 | — | — | — | — | — | — | — | — |\n| 3 | +2 | Bard Subclass | d6 | 2 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4 | +2 | Ability Score Improvement | d6 | 3 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5 | +3 | Font of Inspiration | d8 | 3 | 9 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6 | +3 | Subclass feature | d8 | 3 | 10 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7 | +3 | Countercharm | d8 | 3 | 11 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8 | +3 | Ability Score Improvement | d8 | 3 | 12 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9 | +4 | Expertise | d8 | 3 | 14 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10 | +4 | Magical Secrets | d10 | 4 | 15 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11 | +4 | — | d10 | 4 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12 | +4 | Ability Score Improvement | d10 | 4 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13 | +5 | — | d10 | 4 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14 | +5 | Subclass feature | d10 | 4 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15 | +5 | — | d12 | 4 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16 | +5 | Ability Score Improvement | d12 | 4 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17 | +6 | — | d12 | 4 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18 | +6 | Superior Inspiration | d12 | 4 | 20 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19 | +6 | Epic Boon | d12 | 4 | 21 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20 | +6 | Words of Creation | d12 | 4 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "bard", "it"),
					Language = LanguageCode.It,
					Name = "Bardo",
					Description = "Un artista la cui musica, la cui danza e i cui versi racchiudono una magia autentica. Il bardo ispira gli alleati, turba i nemici, cura le ferite e tesse illusioni, attingendo agli echi delle Parole della Creazione che ancora risuonano attraverso i piani.",
					SubclassTitle = "Sottoclasse del bardo",
					ArmorProficiencies = "Armature leggere",
					WeaponProficiencies = "Armi semplici",
					ToolProficiencies = "Tre strumenti musicali a scelta",
					StartingEquipment = "A scelta tra A e B:\n- (A) un'armatura di cuoio, 2 pugnali, uno strumento musicale a scelta, una dotazione da intrattenitore e 19 mo\n- (B) 90 mo",
					ProgressionTable = "Le colonne 1–9 indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi di classe | Dado bardico | Trucchetti | Incantesimi preparati | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Ispirazione Bardica, Incantesimi | d6 | 2 | 4 | 2 | — | — | — | — | — | — | — | — |\n| 2 | +2 | Maestria, Factotum | d6 | 2 | 5 | 3 | — | — | — | — | — | — | — | — |\n| 3 | +2 | Sottoclasse del Bardo | d6 | 2 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4 | +2 | Aumento dei Punteggi di Caratteristica | d6 | 3 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5 | +3 | Fonte di Ispirazione | d8 | 3 | 9 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6 | +3 | Privilegio della sottoclasse | d8 | 3 | 10 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7 | +3 | Controfascino | d8 | 3 | 11 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8 | +3 | Aumento dei Punteggi di Caratteristica | d8 | 3 | 12 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9 | +4 | Maestria | d8 | 3 | 14 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10 | +4 | Segreti Magici | d10 | 4 | 15 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11 | +4 | — | d10 | 4 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12 | +4 | Aumento dei Punteggi di Caratteristica | d10 | 4 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13 | +5 | — | d10 | 4 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14 | +5 | Privilegio della sottoclasse | d10 | 4 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15 | +5 | — | d12 | 4 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16 | +5 | Aumento dei Punteggi di Caratteristica | d12 | 4 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17 | +6 | — | d12 | 4 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18 | +6 | Ispirazione Superiore | d12 | 4 | 20 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19 | +6 | Dono Epico | d12 | 4 | 21 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20 | +6 | Parole della Creazione | d12 | 4 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/bardic-inspiration"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/bardic-inspiration", "en"), Language = LanguageCode.En, Name = "Bardic Inspiration", Description = "You can supernaturally inspire others through words, music, or dance. This inspiration is represented by your Bardic Inspiration die, which is a d6.\n\n**Using Bardic Inspiration.** As a Bonus Action, you can inspire another creature within 60 feet of yourself who can see or hear you. That creature gains one of your Bardic Inspiration dice. A creature can have only one Bardic Inspiration die at a time.\n\nOnce within the next hour when the creature fails a D20 Test, the creature can roll the Bardic Inspiration die and add the number rolled to the d20, potentially turning the failure into a success. A Bardic Inspiration die is expended when it’s rolled.\n\n**Number of Uses.** You can confer a Bardic Inspiration die a number of times equal to your Charisma modifier (minimum of once), and you regain all expended uses when you finish a Long Rest.\n\n**At Higher Levels.** Your Bardic Inspiration die changes when you reach certain Bard levels, as shown in the Bardic Die column of the Bard Features table. The die becomes a d8 at level 5, a d10 at level 10, and a d12 at level 15." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/bardic-inspiration", "it"), Language = LanguageCode.It, Name = "Ispirazione Bardica", Description = "Il bardo è in grado di ispirare gli altri in modo soprannaturale con le parole, la musica o la danza. Questa ispirazione è rappresentata dal suo dado di Ispirazione bardica, che è un d6.\n\n**Usare l'Ispirazione bardica.** Come azione bonus, il bardo può ispirare un'altra creatura che si trova entro 18 metri da lui e che è in grado di vederlo o sentirlo. Quella creatura riceve uno dei suoi dadi di Ispirazione bardica; una creatura non può avere più di un dado di Ispirazione bardica alla volta.\n\nEntro l'ora successiva, una sola volta, quando la creatura fallisce una prova del d20 può tirare il dado di Ispirazione bardica e sommare il risultato al d20, con la possibilità di trasformare il fallimento in un successo. Il dado viene speso nel momento in cui lo si tira.\n\n**Numero di utilizzi.** Il bardo può conferire un dado di Ispirazione bardica un numero di volte pari al suo modificatore di Carisma (minimo una volta) e recupera tutti gli utilizzi spesi quando completa un riposo lungo.\n\n**Ai livelli superiori.** Il dado di Ispirazione bardica cambia a determinati livelli da bardo, come indicato nella colonna Dado bardico della tabella dei privilegi del bardo: diventa un d8 al 5° livello, un d10 al 10° livello e un d12 al 15° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "You have learned to cast spells through your bardic arts. See chapter 7 for the rules on spellcasting. The information below details how you use those rules with Bard spells, which appear in the Bard spell list later in the class's description.\n\n**Cantrips.** You know two cantrips of your choice from the Bard spell list. Dancing Lights and Vicious Mockery are recommended. Whenever you gain a Bard level, you can replace one of your cantrips with another cantrip of your choice from the Bard spell list. When you reach Bard levels 4 and 10, you learn another cantrip of your choice from the Bard spell list, as shown in the Cantrips column of the Bard Features table.\n\n**Spell Slots.** The Bard Features table shows how many spell slots you have to cast your level 1+ spells. You regain all expended slots when you finish a Long Rest.\n\n**Prepared Spells of Level 1+.** You prepare the list of level 1+ spells that are available for you to cast with this feature. To start, choose four level 1 spells from the Bard spell list. Charm Person, Color Spray, Dissonant Whispers, and Healing Word are recommended. The number of spells on your list increases as you gain Bard levels, as shown in the Prepared Spells column of the Bard Features table. Whenever that number increases, choose additional spells from the Bard spell list until the number of spells on your list matches the number on the table. The chosen spells must be of a level for which you have spell slots. For example, if you're a level 3 Bard, your list of prepared spells can include six spells of levels 1 and 2 in any combination.\n\nIf another Bard feature gives you spells that you always have prepared, those spells don't count against the number of spells you can prepare with this feature, but those spells otherwise count as Bard spells for you.\n\n**Changing Your Prepared Spells.** Whenever you gain a Bard level, you can replace one spell on your list with another Bard spell for which you have spell slots.\n\n**Spellcasting Ability.** Charisma is your spellcasting ability for your Bard spells.\n\n**Spellcasting Focus.** You can use a Musical Instrument as a Spellcasting Focus for your Bard spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Grazie alle sue arti bardiche, il bardo ha imparato a lanciare incantesimi (le regole per lanciarli si trovano nel capitolo sugli incantesimi). Di seguito è spiegato come il bardo applica quelle regole agli incantesimi da bardo, che compaiono nella lista degli incantesimi da bardo.\n\n**Trucchetti.** Il bardo conosce due trucchetti a sua scelta dalla lista degli incantesimi da bardo; sono consigliati *luci danzanti* e *beffa crudele*. Ogni volta che sale di livello come bardo, può sostituire uno dei suoi trucchetti con un altro trucchetto a sua scelta dalla stessa lista. Al 4° e al 10° livello da bardo impara un altro trucchetto a sua scelta dalla lista, come indicato nella colonna Trucchetti della tabella dei privilegi del bardo.\n\n**Slot incantesimo.** La tabella dei privilegi del bardo indica quanti slot incantesimo possiede il bardo per lanciare i suoi incantesimi di 1° livello o superiore. Recupera tutti gli slot spesi quando completa un riposo lungo.\n\n**Incantesimi preparati di 1° livello o superiore.** Il bardo prepara l'elenco degli incantesimi di 1° livello o superiore che può lanciare con questo privilegio. Per cominciare, sceglie quattro incantesimi di 1° livello dalla lista degli incantesimi da bardo; sono consigliati *charme su persone*, *spruzzo colorato*, *sussurri dissonanti* e *parola guaritrice*. Il numero di incantesimi del suo elenco aumenta man mano che sale di livello come bardo, come indicato nella colonna Incantesimi preparati della tabella dei privilegi del bardo. Ogni volta che quel numero aumenta, sceglie altri incantesimi dalla lista degli incantesimi da bardo finché il numero di incantesimi nel suo elenco non coincide con quello della tabella. Gli incantesimi scelti devono essere di un livello per cui il bardo possiede slot incantesimo. Per esempio, un bardo di 3° livello può avere nel suo elenco sei incantesimi di 1° e 2° livello in qualsiasi combinazione.\n\nSe un altro privilegio da bardo gli fa avere incantesimi sempre preparati, quegli incantesimi non contano nel numero di incantesimi che può preparare con questo privilegio, ma per il resto contano come incantesimi da bardo per lui.\n\n**Cambiare gli incantesimi preparati.** Ogni volta che sale di livello come bardo, può sostituire un incantesimo del suo elenco con un altro incantesimo da bardo per cui possiede slot incantesimo.\n\n**Caratteristica da incantatore.** Il Carisma è la caratteristica da incantatore del bardo per i suoi incantesimi da bardo.\n\n**Focus da incantatore.** Il bardo può usare uno strumento musicale come focus da incantatore per i suoi incantesimi da bardo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/expertise"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/expertise", "en"), Language = LanguageCode.En, Name = "Expertise", Description = "You gain Expertise (see the rules glossary) in two of your skill proficiencies of your choice. Performance and Persuasion are recommended if you have proficiency in them.\n\nAt Bard level 9, you gain Expertise in two more of your skill proficiencies of your choice." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/expertise", "it"), Language = LanguageCode.It, Name = "Maestria", Description = "Il bardo ottiene Maestria in due abilità a sua scelta in cui ha competenza; se le possiede, sono consigliate Intrattenere e Persuasione.\n\nAl 9° livello da bardo ottiene Maestria in altre due abilità a sua scelta in cui ha competenza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/jack-of-all-trades"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/jack-of-all-trades", "en"), Language = LanguageCode.En, Name = "Jack of All Trades", Description = "You can add half your Proficiency Bonus (round down) to any ability check you make that uses a skill proficiency you lack and that doesn’t otherwise use your Proficiency Bonus.\n\nFor example, if you make a Strength (Athletics) check and lack Athletics proficiency, you can add half your Proficiency Bonus to the check." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/jack-of-all-trades", "it"), Language = LanguageCode.It, Name = "Factotum", Description = "Il bardo può aggiungere la metà del suo bonus di competenza (arrotondata per difetto) a qualsiasi prova di caratteristica che usa un'abilità in cui non ha competenza e che non beneficia già del suo bonus di competenza.\n\nPer esempio, se effettua una prova di Forza (Atletica) senza avere competenza in Atletica, può aggiungere alla prova la metà del suo bonus di competenza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/bard-subclass"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/bard-subclass", "en"), Language = LanguageCode.En, Name = "Bard Subclass", Description = "You gain a Bard subclass of your choice. The College of Dance, College of Glamour, College of Lore, and College of Valor subclasses are detailed after this class’s description. A subclass is a specialization that grants you features at certain Bard levels. For the rest of your career, you gain each of your subclass’s features that are of your Bard level or lower." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/bard-subclass", "it"), Language = LanguageCode.It, Name = "Sottoclasse del Bardo", Description = "Il bardo ottiene una sottoclasse del bardo a sua scelta: Collegio della Danza, Collegio del Fascino, Collegio della Sapienza o Collegio del Valore. Una sottoclasse è una specializzazione che conferisce privilegi a determinati livelli da bardo. Per il resto della sua carriera, il bardo ottiene ogni privilegio della sottoclasse di livello pari o inferiore al suo livello da bardo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "You gain the Ability Score Improvement feat (see chapter 5) or another feat of your choice for which you qualify. You gain this feature again at Bard levels 8, 12, and 16." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Il bardo ottiene il talento Aumento dei punteggi di caratteristica o un altro talento a sua scelta di cui soddisfa i prerequisiti. Ottiene di nuovo questo privilegio all'8°, al 12° e al 16° livello da bardo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/font-of-inspiration"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/font-of-inspiration", "en"), Language = LanguageCode.En, Name = "Font of Inspiration", Description = "You now regain all your expended uses of Bardic Inspiration when you finish a Short or Long Rest. In addition, you can expend a spell slot (no action required) to regain one expended use of Bardic Inspiration." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/font-of-inspiration", "it"), Language = LanguageCode.It, Name = "Fonte di Ispirazione", Description = "D'ora in poi gli utilizzi spesi di Ispirazione bardica tornano tutti disponibili alla fine di ogni riposo, breve o lungo che sia. In più, spendendo uno slot incantesimo (senza bisogno di azioni), il bardo riottiene subito un utilizzo di Ispirazione bardica." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/countercharm"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/countercharm", "en"), Language = LanguageCode.En, Name = "Countercharm", Description = "You can use musical notes or words of power to disrupt mind-influencing effects. If you or a creature within 30 feet of you fails a saving throw against an effect that applies the Charmed or Frightened condition, you can take a Reaction to cause the save to be rerolled, and the new roll has Advantage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/countercharm", "it"), Language = LanguageCode.It, Name = "Controfascino", Description = "Con note musicali o parole di potere, il bardo sa spezzare gli effetti che influenzano la mente. Quando lui o una creatura entro 9 metri da lui fallisce un tiro salvezza contro un effetto che impone la condizione di affascinato o di spaventato, il bardo può usare una reazione per far ripetere il tiro salvezza, e il nuovo tiro dispone di vantaggio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/magical-secrets"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/magical-secrets", "en"), Language = LanguageCode.En, Name = "Magical Secrets", Description = "You’ve learned secrets from various magical traditions. Whenever you reach a Bard level (including this level) and the Prepared Spells number in the Bard Features table increases, you can choose any of your new prepared spells from the Bard, Cleric, Druid, and Wizard spell lists, and the chosen spells count as Bard spells for you (see a class’s section for its spell list). In addition, whenever you replace a spell prepared for this class, you can replace it with a spell from those lists." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/magical-secrets", "it"), Language = LanguageCode.It, Name = "Segreti Magici", Description = "Il bardo ha appreso segreti da diverse tradizioni magiche. Ogni volta che raggiunge un livello da bardo (incluso questo) in cui il numero della colonna Incantesimi preparati aumenta, può scegliere qualsiasi nuovo incantesimo preparato dalle liste degli incantesimi da bardo, chierico, druido e mago; gli incantesimi scelti contano come incantesimi da bardo per lui. Inoltre, ogni volta che sostituisce un incantesimo preparato per questa classe, può sostituirlo con un incantesimo di quelle liste." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/superior-inspiration"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/superior-inspiration", "en"), Language = LanguageCode.En, Name = "Superior Inspiration", Description = "When you roll Initiative, you regain expended uses of Bardic Inspiration until you have two if you have fewer than that." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/superior-inspiration", "it"), Language = LanguageCode.It, Name = "Ispirazione Superiore", Description = "All'inizio di un combattimento, nel momento in cui tira l'iniziativa, il bardo riporta a due i suoi utilizzi di Ispirazione bardica se in quel momento gliene resta meno di due." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/epic-boon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 19,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/epic-boon", "en"), Language = LanguageCode.En, Name = "Epic Boon", Description = "You gain an Epic Boon feat (see chapter 5) or another feat of your choice for which you qualify. Boon of Spell Recall is recommended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/epic-boon", "it"), Language = LanguageCode.It, Name = "Dono Epico", Description = "Il bardo ottiene un talento Dono epico o un altro talento a sua scelta di cui soddisfa i prerequisiti. È consigliato il Dono del richiamo degli incantesimi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/words-of-creation"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/words-of-creation", "en"), Language = LanguageCode.En, Name = "Words of Creation", Description = "You have mastered two of the Words of Creation: the words of life and death. You therefore always have the Power Word Heal and Power Word Kill spells prepared. When you cast either spell, you can target a second creature with it if that creature is within 10 feet of the first target." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "bard/words-of-creation", "it"), Language = LanguageCode.It, Name = "Parole della Creazione", Description = "Il bardo padroneggia due delle Parole della Creazione: le parole della vita e della morte. Ha quindi sempre preparati gli incantesimi *parola del potere guarire* e *parola del potere uccidere*. Quando lancia uno dei due, può prendere come bersaglio una seconda creatura, purché si trovi entro 3 metri dal primo bersaglio." }
					}
				}
			}
		};
	}
}
