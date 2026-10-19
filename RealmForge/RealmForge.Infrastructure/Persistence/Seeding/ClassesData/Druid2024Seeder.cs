using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Druid (2024 ruleset): class features of the SRD 5.2 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Druid2024Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "druid");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			HitDie = 8,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Wisdom },
			SavingThrows = new List<AbilityScore> { AbilityScore.Intelligence, AbilityScore.Wisdom },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.Animal Handling, Skill.Arcana, Skill.Insight, Skill.Medicine, Skill.Nature, Skill.Perception, Skill.Religion, Skill.Survival },
			CasterProgression = CasterProgression.Full,
			SpellcastingAbility = AbilityScore.Wisdom,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "druid", "en"),
					Language = LanguageCode.En,
					Name = "Druid",
					Description = "A priest of the Old Faith who calls on the forces of nature. Druids harness the magic of animals, plants and the four elements to heal, take the shape of beasts and unleash the fury of the wild, guarding the balance between civilization and the natural world.",
					SubclassTitle = "Druid Subclass",
					ArmorProficiencies = "Light armor; Shields",
					WeaponProficiencies = "Simple weapons",
					ToolProficiencies = "Herbalism Kit",
					StartingEquipment = "Choose A or B:\n- (A) Leather Armor, Shield, Sickle, Druidic Focus (Quarterstaff), Explorer's Pack, Herbalism Kit and 9 GP\n- (B) 50 GP",
					ProgressionTable = "The 1–9 columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Class Features | Wild Shape | Cantrips | Prepared Spells | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Spellcasting, Druidic, Primal Order | — | 2 | 4 | 2 | — | — | — | — | — | — | — | — |\n| 2 | +2 | Wild Shape, Wild Companion | 2 | 2 | 5 | 3 | — | — | — | — | — | — | — | — |\n| 3 | +2 | Druid Subclass | 2 | 2 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4 | +2 | Ability Score Improvement | 2 | 3 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5 | +3 | Wild Resurgence | 2 | 3 | 9 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6 | +3 | Subclass feature | 3 | 3 | 10 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7 | +3 | Elemental Fury | 3 | 4 | 11 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8 | +3 | Ability Score Improvement | 3 | 3 | 12 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9 | +4 | — | 3 | 3 | 14 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10 | +4 | Subclass feature | 3 | 4 | 15 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11 | +4 | — | 3 | 4 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12 | +4 | Ability Score Improvement | 3 | 4 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13 | +5 | — | 3 | 4 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14 | +5 | Subclass feature | 3 | 4 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15 | +5 | Improved Elemental Fury | 3 | 4 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16 | +5 | Ability Score Improvement | 3 | 5 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17 | +6 | — | 4 | 4 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18 | +6 | Beast Spells | 4 | 4 | 20 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19 | +6 | Epic Boon | 4 | 4 | 21 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20 | +6 | Archdruid | 4 | 4 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "druid", "it"),
					Language = LanguageCode.It,
					Name = "Druido",
					Description = "Un sacerdote dell'Antica Fede che invoca le forze della natura. Il druido imbriglia la magia degli animali, delle piante e dei quattro elementi per guarire, assumere la forma delle bestie e scatenare la furia della natura selvaggia, vegliando sull'equilibrio tra la civiltà e il mondo naturale.",
					SubclassTitle = "Sottoclasse del druido",
					ArmorProficiencies = "Armature leggere; scudi",
					WeaponProficiencies = "Armi semplici",
					ToolProficiencies = "Borsa da erborista",
					StartingEquipment = "A scelta tra A e B:\n- (A) un'armatura di cuoio, uno scudo, un falcetto, un focus druidico (bastone ferrato), una dotazione da esploratore, una borsa da erborista e 9 mo\n- (B) 50 mo",
					ProgressionTable = "Le colonne 1–9 indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi di classe | Forma Selvatica | Trucchetti | Incantesimi preparati | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Incantesimi, Druidico, Ordine Primordiale | — | 2 | 4 | 2 | — | — | — | — | — | — | — | — |\n| 2 | +2 | Forma Selvatica, Compagno Selvatico | 2 | 2 | 5 | 3 | — | — | — | — | — | — | — | — |\n| 3 | +2 | Sottoclasse del Druido | 2 | 2 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4 | +2 | Aumento dei Punteggi di Caratteristica | 2 | 3 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5 | +3 | Rinascita Selvatica | 2 | 3 | 9 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6 | +3 | Privilegio della sottoclasse | 3 | 3 | 10 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7 | +3 | Furia Elementale | 3 | 4 | 11 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8 | +3 | Aumento dei Punteggi di Caratteristica | 3 | 3 | 12 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9 | +4 | — | 3 | 3 | 14 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10 | +4 | Privilegio della sottoclasse | 3 | 4 | 15 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11 | +4 | — | 3 | 4 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12 | +4 | Aumento dei Punteggi di Caratteristica | 3 | 4 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13 | +5 | — | 3 | 4 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14 | +5 | Privilegio della sottoclasse | 3 | 4 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15 | +5 | Furia Elementale Migliorata | 3 | 4 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16 | +5 | Aumento dei Punteggi di Caratteristica | 3 | 5 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17 | +6 | — | 4 | 4 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18 | +6 | Incantesimi Bestiali | 4 | 4 | 20 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19 | +6 | Dono Epico | 4 | 4 | 21 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20 | +6 | Arcidruido | 4 | 4 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "You have learned to cast spells through studying the mystical forces of nature. See chapter 7 for the rules on spellcasting. The information below details how you use those rules with Druid spells, which appear on the Druid spell list later in the class’s description.\n\n**Cantrips.** You know two cantrips of your choice from the Druid spell list. Druidcraft and Produce Flame are recommended. Whenever you gain a Druid level, you can replace one of your cantrips with another cantrip of your choice from the Druid spell list. When you reach Druid levels 4 and 10, you learn another cantrip of your choice from the Druid spell list, as shown in the Cantrips column of the Druid Features table.\n\n**Spell Slots.** The Druid Features table shows how many spell slots you have to cast your level 1+ spells. You regain all expended slots when you finish a Long Rest.\n\n**Prepared Spells of Level 1+.** You prepare the list of level 1+ spells that are available for you to cast with this feature. To start, choose four level 1 spells from the Druid spell list. Animal Friendship, Cure Wounds, Faerie Fire, and Thunderwave are recommended. The number of spells on your list increases as you gain Druid levels, as shown in the Prepared Spells column of the Druid Features table. Whenever that number increases, choose additional spells from the Druid spell list until the number of spells on your list matches the number on the table. The chosen spells must be of a level for which you have spell slots. For example, if you’re a level 3 Druid, your list of prepared spells can include six spells of levels 1 and 2 in any combination.\n\nIf another Druid feature gives you spells that you always have prepared, those spells don’t count against the number of spells you can prepare with this feature, but those spells otherwise count as Druid spells for you.\n\n**Changing Your Prepared Spells.** Whenever you finish a Long Rest, you can change your list of prepared spells, replacing any of the spells with other Druid spells for which you have spell slots.\n\n**Spellcasting Ability.** Wisdom is your spellcasting ability for your Druid spells.\n\n**Spellcasting Focus.** You can use a Druidic Focus as a Spellcasting Focus for your Druid spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Grazie allo studio delle forze mistiche della natura, il druido ha imparato a lanciare incantesimi (le regole per lanciarli si trovano nel capitolo sugli incantesimi). Di seguito è spiegato come il druido applica quelle regole agli incantesimi da druido, che compaiono nella lista degli incantesimi da druido.\n\n**Trucchetti.** Il druido conosce due trucchetti a sua scelta dalla lista degli incantesimi da druido; sono consigliati *artificio druidico* e *produrre fiamma*. Ogni volta che sale di livello come druido, può sostituire uno dei suoi trucchetti con un altro trucchetto a sua scelta dalla stessa lista. Al 4° e al 10° livello da druido impara un altro trucchetto a sua scelta dalla lista, come indicato nella colonna Trucchetti della tabella dei privilegi del druido.\n\n**Slot incantesimo.** La tabella dei privilegi del druido indica quanti slot incantesimo possiede il druido per lanciare i suoi incantesimi di 1° livello o superiore. Recupera tutti gli slot spesi quando completa un riposo lungo.\n\n**Incantesimi preparati di 1° livello o superiore.** Il druido prepara l'elenco degli incantesimi di 1° livello o superiore che può lanciare con questo privilegio. Per cominciare, sceglie quattro incantesimi di 1° livello dalla lista degli incantesimi da druido; sono consigliati *amicizia con gli animali*, *cura ferite*, *luminescenza* e *onda tonante*. Il numero di incantesimi del suo elenco aumenta man mano che sale di livello come druido, come indicato nella colonna Incantesimi preparati della tabella dei privilegi del druido. Ogni volta che quel numero aumenta, sceglie altri incantesimi dalla lista degli incantesimi da druido finché il numero di incantesimi nel suo elenco non coincide con quello della tabella. Gli incantesimi scelti devono essere di un livello per cui il druido possiede slot incantesimo. Per esempio, un druido di 3° livello può avere nel suo elenco sei incantesimi di 1° e 2° livello in qualsiasi combinazione.\n\nSe un altro privilegio da druido gli fa avere incantesimi sempre preparati, quegli incantesimi non contano nel numero di incantesimi che può preparare con questo privilegio, ma per il resto contano come incantesimi da druido per lui.\n\n**Cambiare gli incantesimi preparati.** Ogni volta che completa un riposo lungo, il druido può modificare il suo elenco di incantesimi preparati, sostituendone uno qualsiasi con altri incantesimi da druido per cui possiede slot incantesimo.\n\n**Caratteristica da incantatore.** La Saggezza è la caratteristica da incantatore del druido per i suoi incantesimi da druido.\n\n**Focus da incantatore.** Il druido può usare un focus druidico come focus da incantatore per i suoi incantesimi da druido." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/druidic"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/druidic", "en"), Language = LanguageCode.En, Name = "Druidic", Description = "You know Druidic, the secret language of Druids. While learning this ancient tongue, you also unlocked the magic of communicating with animals; you always have the Speak with Animals spell prepared.\n\nYou can use Druidic to leave hidden messages. You and others who know Druidic automatically spot such a message. Others spot the message’s presence with a successful DC 15 Intelligence (Investigation) check but can’t decipher it without magic." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/druidic", "it"), Language = LanguageCode.It, Name = "Druidico", Description = "Il druido conosce il druidico, la lingua segreta dei druidi. Imparando questa lingua antica ha anche scoperto la magia che permette di comunicare con gli animali: ha sempre preparato l'incantesimo *parlare con gli animali*.\n\nIl druido può usare il druidico per lasciare messaggi nascosti. Lui e chiunque altro conosca il druidico notano automaticamente un messaggio di questo tipo. Gli altri ne notano la presenza superando una prova di Intelligenza (Indagare) con CD 15, ma non possono decifrarlo senza ricorrere alla magia." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/primal-order"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/primal-order", "en"), Language = LanguageCode.En, Name = "Primal Order", Description = "You have dedicated yourself to one of the following sacred roles of your choice.\n\n**Magician.** You know one extra cantrip from the Druid spell list. In addition, your mystical connection to nature gives you a bonus to your Intelligence (Arcana or Nature) checks. The bonus equals your Wisdom modifier (minimum bonus of +1).\n\n**Warden.** Trained for battle, you gain proficiency with Martial weapons and training with Medium armor." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/primal-order", "it"), Language = LanguageCode.It, Name = "Ordine Primordiale", Description = "Il druido si è consacrato a uno dei ruoli sacri seguenti, a sua scelta.\n\n**Mago.** Il druido conosce un trucchetto aggiuntivo dalla lista degli incantesimi da druido. Inoltre, il suo legame mistico con la natura gli conferisce un bonus alle prove di Intelligenza (Arcano o Natura) pari al suo modificatore di Saggezza (bonus minimo +1).\n\n**Custode.** Addestrato alla battaglia, il druido ottiene competenza nelle armi da guerra e addestramento nelle armature medie." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/wild-shape"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/wild-shape", "en"), Language = LanguageCode.En, Name = "Wild Shape", Description = "The power of nature lets you take the shape of an animal. As a Bonus Action, you shape-shift into a Beast form that you have learned for this feature (see \"Known Forms\" below). You stay in that form for a number of hours equal to half your Druid level or until you use Wild Shape again, have the Incapacitated condition, or die. You can also leave the form early as a Bonus Action.\n\n**Number of Uses.** You can use Wild Shape twice. You regain one expended use when you finish a Short Rest, and you regain all expended uses when you finish a Long Rest. You gain additional uses when you reach certain Druid levels, as shown in the Wild Shape column of the Druid Features table.\n\n**Known Forms.** You know four Beast forms for this feature, chosen from among Beast stat blocks that have a maximum Challenge Rating of 1/4 and that lack a Fly Speed. The Rat, Riding Horse, Spider, and Wolf are recommended. Whenever you finish a Long Rest, you can replace one of your known forms with another eligible form.\n\nWhen you reach certain Druid levels, your number of known forms and the maximum Challenge Rating for those forms increases, as shown in the table below. In addition, starting at level 8, you can adopt a form that has a Fly Speed.\n\n| Druid Level | Known Forms | Max CR | Fly Speed |\n|---|---|---|---|\n| 2 | 4 | 1/4 | No |\n| 4 | 6 | 1/2 | No |\n| 8 | 8 | 1 | Yes |\n\nWhen choosing known forms, you may look in the Monster Manual or elsewhere for eligible Beasts if the Dungeon Master permits you to do so.\n\n**Rules While Shape-Shifted.** While in a form, you retain your personality, memories, and ability to speak, and the following rules apply.\n\n**Temporary Hit Points.** When you assume a Wild Shape form, you gain a number of Temporary Hit Points equal to your Druid level.\n\n**Game Statistics.** Your game statistics are replaced by the Beast's stat block, but you retain your creature type; Hit Points; Hit Point Dice; Intelligence, Wisdom, and Charisma scores; class features; languages; and feats. You also retain your skill and saving throw proficiencies and use your Proficiency Bonus for them, in addition to gaining the proficiencies of the creature. If a skill or saving throw modifier in the Beast's stat block is higher than yours, use the one in the stat block.\n\n**No Spellcasting.** You can't cast spells, but shape-shifting doesn't break your Concentration or otherwise interfere with a spell you've already cast.\n\n**Objects.** Your ability to handle objects is determined by the form's limbs rather than your own. In addition, you choose whether your equipment falls in your space, merges into your new form, or is worn by it. Worn equipment functions as normal, but the DM decides whether it's practical for the new form to wear a piece of equipment based on the creature's size and shape. Your equipment doesn't change size or shape to match the new form, and any equipment that the new form can't wear must either fall to the ground or merge with the form. Equipment that merges with the form has no effect while you're in that form." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/wild-shape", "it"), Language = LanguageCode.It, Name = "Forma Selvatica", Description = "Il potere della natura permette al druido di assumere la forma di un animale. Come azione bonus, si trasforma in una forma bestiale che ha appreso per questo privilegio (vedi \"Forme conosciute\" più avanti). Rimane in quella forma per un numero di ore pari alla metà del suo livello da druido, oppure finché non usa di nuovo Forma Selvatica, non subisce la condizione di incapacitato o non muore. Può anche abbandonare la forma prima del tempo come azione bonus.\n\n**Numero di utilizzi.** Il druido può usare Forma Selvatica due volte. Recupera un utilizzo speso quando completa un riposo breve e tutti gli utilizzi spesi quando completa un riposo lungo. Ottiene utilizzi aggiuntivi a determinati livelli da druido, come indicato nella colonna Forma Selvatica della tabella dei privilegi del druido.\n\n**Forme conosciute.** Il druido conosce quattro forme bestiali per questo privilegio, scelte tra le schede delle statistiche delle bestie con grado di sfida massimo di 1/4 e prive di velocità di volo. Sono consigliati il cavallo da galoppo, il lupo, il ragno e il ratto. Ogni volta che completa un riposo lungo, può sostituire una delle forme conosciute con un'altra forma idonea.\n\nA determinati livelli da druido, il numero di forme conosciute e il grado di sfida massimo di quelle forme aumentano, come indicato nella tabella seguente. Inoltre, a partire dall'8° livello, il druido può assumere una forma dotata di velocità di volo.\n\n| Livello da druido | Forme conosciute | GS max | Velocità di volo |\n|---|---|---|---|\n| 2 | 4 | 1/4 | No |\n| 4 | 6 | 1/2 | No |\n| 8 | 8 | 1 | Sì |\n\nCon il permesso del Dungeon Master, il druido può cercare bestie idonee anche in altri manuali, come il manuale dei mostri.\n\n**Regole durante il mutamento della forma.** Mentre si trova in una forma, il druido conserva la propria personalità, i propri ricordi e la capacità di parlare, e si applicano le regole seguenti.\n\n**Punti ferita temporanei.** Quando assume una forma di Forma Selvatica, il druido ottiene un numero di punti ferita temporanei pari al suo livello da druido.\n\n**Statistiche di gioco.** Le statistiche di gioco del druido sono sostituite da quelle della scheda della bestia, ma il druido conserva il suo tipo di creatura, i suoi punti ferita, i suoi Dadi Vita, i suoi punteggi di Intelligenza, Saggezza e Carisma, i suoi privilegi di classe, le sue lingue e i suoi talenti. Conserva inoltre le sue competenze nelle abilità e nei tiri salvezza, usando per esse il suo bonus di competenza, oltre ad acquisire le competenze della creatura. Se un modificatore di abilità o di tiro salvezza nella scheda della bestia è più alto del suo, usa quello della scheda.\n\n**Niente incantesimi.** Il druido non può lanciare incantesimi, ma trasformarsi non interrompe la sua concentrazione né interferisce in altro modo con un incantesimo che ha già lanciato.\n\n**Oggetti.** La capacità del druido di maneggiare oggetti dipende dagli arti della forma, non dai suoi. Inoltre, il druido decide se il suo equipaggiamento cade nel suo spazio, si fonde con la nuova forma o viene indossato da essa. L'equipaggiamento indossato funziona normalmente, ma è il DM a stabilire se la nuova forma può indossarlo in modo pratico, in base alla taglia e alla conformazione della creatura. L'equipaggiamento non cambia taglia né forma per adattarsi alla nuova forma, e quello che la nuova forma non può indossare deve cadere a terra o fondersi con essa. L'equipaggiamento fuso con la forma non ha alcun effetto finché il druido rimane in quella forma." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/wild-companion"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/wild-companion", "en"), Language = LanguageCode.En, Name = "Wild Companion", Description = "You can summon a nature spirit that assumes an animal form to aid you. As a Magic action, you can expend a spell slot or a use of Wild Shape to cast the Find Familiar spell without Material components.\n\nWhen you cast the spell in this way, the familiar is Fey and disappears when you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/wild-companion", "it"), Language = LanguageCode.It, Name = "Compagno Selvatico", Description = "Il druido può evocare uno spirito della natura che assume forma animale per aiutarlo. Con un'azione di Magia, può spendere uno slot incantesimo o un utilizzo di Forma Selvatica per lanciare l'incantesimo *trova famiglio* senza componenti materiali.\n\nQuando lancia l'incantesimo in questo modo, il famiglio è un folletto e scompare quando il druido completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/druid-subclass"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/druid-subclass", "en"), Language = LanguageCode.En, Name = "Druid Subclass", Description = "You gain a Druid subclass of your choice. The Circle of the Land, Circle of the Moon, Circle of the Sea, and Circle of the Stars subclasses are detailed after this class’s description. A subclass is a specialization that grants you features at certain Druid levels. For the rest of your career, you gain each of your subclass’s features that are of your Druid level or lower." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/druid-subclass", "it"), Language = LanguageCode.It, Name = "Sottoclasse del Druido", Description = "Il druido ottiene una sottoclasse del druido a sua scelta: Circolo della Luna, Circolo del Mare, Circolo delle Stelle o Circolo della Terra. Una sottoclasse è una specializzazione che conferisce privilegi a determinati livelli da druido. Per il resto della sua carriera, il druido ottiene ogni privilegio della sottoclasse di livello pari o inferiore al suo livello da druido." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "You gain the Ability Score Improvement feat (see chapter 5) or another feat of your choice for which you qualify. You gain this feature again at Druid levels 8, 12, and 16." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Il druido ottiene il talento Aumento dei punteggi di caratteristica o un altro talento a sua scelta di cui soddisfa i prerequisiti. Ottiene di nuovo questo privilegio all'8°, al 12° e al 16° livello da druido." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/wild-resurgence"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/wild-resurgence", "en"), Language = LanguageCode.En, Name = "Wild Resurgence", Description = "Once on each of your turns, if you have no uses of Wild Shape left, you can give yourself one use by expending a spell slot (no action required).\n\nIn addition, you can expend one use of Wild Shape (no action required) to give yourself a level 1 spell slot, but you can’t do so again until you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/wild-resurgence", "it"), Language = LanguageCode.It, Name = "Rinascita Selvatica", Description = "Una volta in ognuno dei suoi turni, se non gli restano utilizzi di Forma Selvatica, il druido può riottenerne uno spendendo uno slot incantesimo (nessuna azione richiesta).\n\nPuò inoltre spendere un utilizzo di Forma Selvatica (nessuna azione richiesta) per ottenere uno slot incantesimo di 1° livello, ma non può farlo di nuovo finché non completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/elemental-fury"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/elemental-fury", "en"), Language = LanguageCode.En, Name = "Elemental Fury", Description = "The might of the elements flows through you. You gain one of the following options of your choice.\n\n**Potent Spellcasting.** Add your Wisdom modifier to the damage you deal with any Druid cantrip.\n\n**Primal Strike.** Once on each of your turns when you hit a creature with an attack roll using a weapon or a Beast form’s attack in Wild Shape, you can cause the target to take an extra 1d8 Cold, Fire, Lightning, or Thunder damage (choose when you hit)." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/elemental-fury", "it"), Language = LanguageCode.It, Name = "Furia Elementale", Description = "La potenza degli elementi scorre nel druido, che ottiene una delle opzioni seguenti, a sua scelta.\n\n**Incantesimi potenti.** Il druido somma il suo modificatore di Saggezza ai danni che infligge con qualsiasi trucchetto da druido.\n\n**Colpo primordiale.** Una volta in ognuno dei suoi turni, quando colpisce una creatura con un tiro per colpire effettuato con un'arma o con un attacco di una forma bestiale di Forma Selvatica, il druido può infliggere al bersaglio 1d8 danni extra da freddo, da fuoco, da fulmine o da tuono (a sua scelta quando colpisce)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/improved-elemental-fury"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/improved-elemental-fury", "en"), Language = LanguageCode.En, Name = "Improved Elemental Fury", Description = "The option you chose for Elemental Fury grows more powerful, as detailed below.\n\n**Potent Spellcasting.** When you cast a Druid cantrip with a range of 10 feet or greater, the spell’s range increases by 300 feet.\n\n**Primal Strike.** The extra damage of your Primal Strike increases to 2d8." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/improved-elemental-fury", "it"), Language = LanguageCode.It, Name = "Furia Elementale Migliorata", Description = "L'opzione scelta per Furia elementale diventa più potente.\n\n**Incantesimi potenti.** Quando il druido lancia un trucchetto da druido con una gittata pari o superiore a 3 metri, la gittata dell'incantesimo aumenta di 90 metri.\n\n**Colpo primordiale.** I danni extra del Colpo primordiale aumentano a 2d8." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/beast-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 10,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/beast-spells", "en"), Language = LanguageCode.En, Name = "Beast Spells", Description = "While using Wild Shape, you can cast spells in Beast form, except for any spell that has a Material component with a cost specified or that consumes its Material component." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/beast-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi Bestiali", Description = "Mentre usa Forma Selvatica, il druido può lanciare incantesimi in forma bestiale, a eccezione di quelli con una componente materiale di cui è specificato il costo o che viene consumata." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/epic-boon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 19,
					SortOrder = 11,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/epic-boon", "en"), Language = LanguageCode.En, Name = "Epic Boon", Description = "You gain an Epic Boon feat (see chapter 5) or another feat of your choice for which you qualify. Boon of Dimensional Travel is recommended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/epic-boon", "it"), Language = LanguageCode.It, Name = "Dono Epico", Description = "Il druido ottiene un talento Dono epico o un altro talento a sua scelta di cui soddisfa i prerequisiti. È consigliato il Dono del viaggio dimensionale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/archdruid"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 12,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/archdruid", "en"), Language = LanguageCode.En, Name = "Archdruid", Description = "The vitality of nature constantly blooms within you, granting you the following benefits.\n\n**Evergreen Wild Shape.** Whenever you roll Initiative and have no uses of Wild Shape left, you regain one expended use of it.\n\n**Nature Magician.** You can convert uses of Wild Shape into a spell slot (no action required). Choose a number of your unexpended uses of Wild Shape and convert them into a single spell slot, with each use contributing 2 spell levels. For example, if you convert two uses of Wild Shape, you produce a level 4 spell slot. Once you use this benefit, you can’t do so again until you finish a Long Rest.\n\n**Longevity.** The primal magic that you wield causes you to age more slowly. For every ten years that pass, your body ages only one year." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "druid/archdruid", "it"), Language = LanguageCode.It, Name = "Arcidruido", Description = "La vitalità della natura fiorisce costantemente nel druido, conferendogli i benefici seguenti.\n\n**Forma selvatica sempreverde.** Ogni volta che tira per l'iniziativa e non gli restano utilizzi di Forma Selvatica, il druido ne recupera uno.\n\n**Mago della natura.** Il druido può convertire utilizzi di Forma Selvatica in uno slot incantesimo (nessuna azione richiesta). Sceglie un certo numero di utilizzi non spesi di Forma Selvatica e li converte in un singolo slot incantesimo, in cui ogni utilizzo vale 2 livelli di incantesimo. Per esempio, convertendo due utilizzi di Forma Selvatica ottiene uno slot incantesimo di 4° livello. Dopo aver usato questo beneficio, non può farlo di nuovo finché non completa un riposo lungo.\n\n**Corpo senza tempo.** La magia primordiale che il druido impugna lo fa invecchiare più lentamente: per ogni dieci anni che passano, il suo corpo invecchia di un solo anno." }
					}
				}
			}
		};
	}
}
