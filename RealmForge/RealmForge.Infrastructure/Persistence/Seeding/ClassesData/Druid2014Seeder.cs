using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Druid (2014 ruleset): class features of the SRD 5.1 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Druid2014Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "druid");

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
			SavingThrows = new List<AbilityScore> { AbilityScore.Intelligence, AbilityScore.Wisdom },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.Arcana, Skill.AnimalHandling, Skill.Insight, Skill.Medicine, Skill.Nature, Skill.Perception, Skill.Religion, Skill.Survival },
			CasterProgression = CasterProgression.Full,
			SpellcastingAbility = AbilityScore.Wisdom,
			SubclassLevel = 2,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "druid", "en"),
					Language = LanguageCode.En,
					Name = "Druid",
					Description = "A priest of the natural world who draws power from the wilds themselves. Druids heal, call down storms, command plants and beasts, and can take the shape of animals to scout or fight.",
					SubclassTitle = "Druid Circle",
					ArmorProficiencies = "Light armor, medium armor, shields (druids will not wear armor or use shields made of metal)",
					WeaponProficiencies = "Clubs, daggers, darts, javelins, maces, quarterstaffs, scimitars, sickles, slings, spears",
					ToolProficiencies = "Herbalism kit",
					StartingEquipment = "- (a) a wooden shield or (b) any simple weapon\n- (a) a scimitar or (b) any simple melee weapon\n- Leather armor, an explorer's pack, and a druidic focus",
					ProgressionTable = "The 1st–9th columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Features | Cantrips Known | 1st | 2nd | 3rd | 4th | 5th | 6th | 7th | 8th | 9th |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1st | +2 | Druidic, Spellcasting | 2 | 2 | — | — | — | — | — | — | — | — |\n| 2nd | +2 | Wild Shape, Druid Circle | 2 | 3 | — | — | — | — | — | — | — | — |\n| 3rd | +2 | — | 2 | 4 | 2 | — | — | — | — | — | — | — |\n| 4th | +2 | Wild Shape improvement, Ability Score Improvement | 3 | 4 | 3 | — | — | — | — | — | — | — |\n| 5th | +3 | — | 3 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6th | +3 | Druid Circle feature | 3 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7th | +3 | — | 3 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8th | +3 | Wild Shape improvement, Ability Score Improvement | 3 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9th | +4 | — | 3 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10th | +4 | Druid Circle feature | 4 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11th | +4 | — | 4 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12th | +4 | Ability Score Improvement | 4 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13th | +5 | — | 4 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14th | +5 | Druid Circle feature | 4 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15th | +5 | — | 4 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16th | +5 | Ability Score Improvement | 4 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17th | +6 | — | 4 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18th | +6 | Timeless Body, Beast Spells | 4 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19th | +6 | Ability Score Improvement | 4 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20th | +6 | Archdruid | 4 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class", "druid", "it"),
					Language = LanguageCode.It,
					Name = "Druido",
					Description = "Un sacerdote del mondo naturale che trae il suo potere dalle terre selvagge. Il druido guarisce, evoca tempeste, comanda piante e bestie e può assumere la forma di un animale per esplorare o combattere.",
					SubclassTitle = "Circolo Druidico",
					ArmorProficiencies = "Armature leggere, armature medie, scudi (i druidi non indossano armature né usano scudi di metallo)",
					WeaponProficiencies = "Bastoni ferrati, dardi, falcetti, fionde, giavellotti, lance, mazze, pugnali, randelli, scimitarre",
					ToolProficiencies = "Borsa da erborista",
					StartingEquipment = "- (a) uno scudo di legno o (b) una qualsiasi arma semplice\n- (a) una scimitarra o (b) una qualsiasi arma semplice da mischia\n- Un'armatura di cuoio, una dotazione da esploratore e un focus druidico",
					ProgressionTable = "Le colonne 1°–9° indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi | Trucchetti conosciuti | 1° | 2° | 3° | 4° | 5° | 6° | 7° | 8° | 9° |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1° | +2 | Druidico, Incantesimi | 2 | 2 | — | — | — | — | — | — | — | — |\n| 2° | +2 | Forma Selvatica, Circolo Druidico | 2 | 3 | — | — | — | — | — | — | — | — |\n| 3° | +2 | — | 2 | 4 | 2 | — | — | — | — | — | — | — |\n| 4° | +2 | Forma Selvatica migliorata, Aumento dei Punteggi di Caratteristica | 3 | 4 | 3 | — | — | — | — | — | — | — |\n| 5° | +3 | — | 3 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6° | +3 | Privilegio del Circolo Druidico | 3 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7° | +3 | — | 3 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8° | +3 | Forma Selvatica migliorata, Aumento dei Punteggi di Caratteristica | 3 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9° | +4 | — | 3 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10° | +4 | Privilegio del Circolo Druidico | 4 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11° | +4 | — | 4 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12° | +4 | Aumento dei Punteggi di Caratteristica | 4 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13° | +5 | — | 4 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14° | +5 | Privilegio del Circolo Druidico | 4 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15° | +5 | — | 4 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16° | +5 | Aumento dei Punteggi di Caratteristica | 4 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17° | +6 | — | 4 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18° | +6 | Corpo Senza Tempo, Incantesimi Bestiali | 4 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19° | +6 | Aumento dei Punteggi di Caratteristica | 4 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20° | +6 | Arcidruido | 4 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/druidic"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/druidic", "en"), Language = LanguageCode.En, Name = "Druidic", Description = "You know Druidic, the secret language of druids. You can speak the language and use it to leave hidden messages. You and others who know this language automatically spot such a message. Others spot the message's presence with a successful DC 15 Wisdom (Perception) check but can't decipher it without magic." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/druidic", "it"), Language = LanguageCode.It, Name = "Druidico", Description = "Il druido conosce il druidico, la lingua segreta dei druidi. Sa parlarla e usarla per lasciare messaggi nascosti. Lui e chiunque altro conosca questa lingua individuano automaticamente un messaggio del genere. Gli altri notano la presenza del messaggio superando una prova di Saggezza (Percezione) con CD 15, ma non possono decifrarlo senza ricorrere alla magia." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "Drawing on the divine essence of nature itself, you can cast spells to shape that essence to your will.\n\n**Cantrips**\n\nAt 1st level, you know two cantrips of your choice from the druid spell list. You learn additional druid cantrips of your choice at higher levels, as shown in the Cantrips Known column of the Druid table.\n\n**Preparing and Casting Spells**\n\nThe Druid table shows how many spell slots you have to cast your spells of 1st level and higher. To cast one of these druid spells, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest.\n\nYou prepare the list of druid spells that are available for you to cast, choosing from the druid spell list. When you do so, choose a number of druid spells equal to your Wisdom modifier + your druid level (minimum of one spell). The spells must be of a level for which you have spell slots.\n\nFor example, if you are a 3rd-level druid, you have four 1st-level and two 2nd-level spell slots. With a Wisdom of 16, your list of prepared spells can include six spells of 1st or 2nd level, in any combination. If you prepare the 1st-level spell cure wounds, you can cast it using a 1st-level or 2nd-level slot. Casting the spell doesn't remove it from your list of prepared spells.\n\nYou can also change your list of prepared spells when you finish a long rest. Preparing a new list of druid spells requires time spent in prayer and meditation: at least 1 minute per spell level for each spell on your list.\n\n**Spellcasting Ability**\n\nWisdom is your spellcasting ability for your druid spells, since your magic draws upon your devotion and attunement to nature. You use your Wisdom whenever a spell refers to your spellcasting ability. In addition, you use your Wisdom modifier when setting the saving throw DC for a druid spell you cast and when making an attack roll with one.\n\n**Spell save DC** = 8 + your proficiency bonus + your Wisdom modifier\n\n**Spell attack modifier** = your proficiency bonus + your Wisdom modifier\n\n**Ritual Casting**\n\nYou can cast a druid spell as a ritual if that spell has the ritual tag and you have the spell prepared.\n\n**Spellcasting Focus**\n\nYou can use a druidic focus as a spellcasting focus for your druid spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Attingendo all'essenza divina della natura stessa, il druido può lanciare incantesimi per piegare quell'essenza alla sua volontà.\n\n**Trucchetti**\n\nAl 1° livello il druido conosce due trucchetti a sua scelta dalla lista degli incantesimi del druido. Apprende altri trucchetti da druido a sua scelta ai livelli più alti, come indicato nella colonna \"Trucchetti conosciuti\" della tabella del Druido.\n\n**Preparare e lanciare incantesimi**\n\nLa tabella del Druido indica quanti slot incantesimo possiede il druido per lanciare i suoi incantesimi di 1° livello e superiore. Per lanciare uno di questi incantesimi da druido deve spendere uno slot di livello pari o superiore a quello dell'incantesimo. Recupera tutti gli slot incantesimo spesi quando completa un riposo lungo.\n\nIl druido prepara la lista degli incantesimi da druido che può lanciare, scegliendoli dalla lista degli incantesimi del druido. Quando lo fa, sceglie un numero di incantesimi da druido pari al suo modificatore di Saggezza + il suo livello da druido (minimo un incantesimo). Gli incantesimi devono essere di un livello per cui possiede slot incantesimo.\n\nPer esempio, un druido di 3° livello ha quattro slot incantesimo di 1° livello e due di 2° livello. Con Saggezza 16, la sua lista di incantesimi preparati può includere sei incantesimi di 1° o di 2° livello, in qualsiasi combinazione. Se prepara l'incantesimo di 1° livello *cura ferite*, può lanciarlo usando uno slot di 1° o di 2° livello. Lanciare l'incantesimo non lo rimuove dalla lista degli incantesimi preparati.\n\nIl druido può cambiare la sua lista di incantesimi preparati quando completa un riposo lungo. Preparare una nuova lista di incantesimi da druido richiede tempo dedicato alla preghiera e alla meditazione: almeno 1 minuto per livello di incantesimo per ogni incantesimo della lista.\n\n**Caratteristica da incantatore**\n\nLa Saggezza è la caratteristica da incantatore del druido per i suoi incantesimi da druido, dato che la sua magia deriva dalla devozione e dalla sintonia con la natura. Il druido usa la Saggezza ogni volta che un incantesimo fa riferimento alla sua caratteristica da incantatore. Usa inoltre il modificatore di Saggezza per stabilire la CD dei tiri salvezza di un incantesimo da druido che lancia e quando effettua un tiro per colpire con uno di essi.\n\n**CD del tiro salvezza degli incantesimi** = 8 + bonus di competenza + modificatore di Saggezza\n\n**Modificatore di attacco degli incantesimi** = bonus di competenza + modificatore di Saggezza\n\n**Celebrare rituali**\n\nIl druido può lanciare un incantesimo da druido come rituale se quell'incantesimo ha il descrittore rituale e se lo ha preparato.\n\n**Focus da incantatore**\n\nIl druido può usare un focus druidico come focus da incantatore per i suoi incantesimi da druido." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/wild-shape"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/wild-shape", "en"), Language = LanguageCode.En, Name = "Wild Shape", Description = "Starting at 2nd level, you can use your action to magically assume the shape of a beast that you have seen before. You can use this feature twice. You regain expended uses when you finish a short or long rest.\n\nYour druid level determines the beasts you can transform into, as shown in the Beast Shapes table. At 2nd level, for example, you can transform into any beast that has a challenge rating of 1/4 or lower that doesn't have a flying or swimming speed.\n\n**Beast Shapes**\n\n| Level | Max. CR | Limitations | Example |\n|---|---|---|---|\n| 2nd | 1/4 | No flying or swimming speed | Wolf |\n| 4th | 1/2 | No flying speed | Crocodile |\n| 8th | 1 | — | Giant Eagle |\n\nYou can stay in a beast shape for a number of hours equal to half your druid level (rounded down). You then revert to your normal form unless you expend another use of this feature. You can revert to your normal form earlier by using a bonus action on your turn. You automatically revert if you fall unconscious, drop to 0 hit points, or die.\n\nWhile you are transformed, the following rules apply:\n- Your game statistics are replaced by the statistics of the beast, but you retain your alignment, personality, and Intelligence, Wisdom, and Charisma scores. You also retain all of your skill and saving throw proficiencies, in addition to gaining those of the creature. If the creature has the same proficiency as you and the bonus in its stat block is higher than yours, use the creature's bonus instead of yours. If the creature has any legendary or lair actions, you can't use them.\n- When you transform, you assume the beast's hit points and Hit Dice. When you revert to your normal form, you return to the number of hit points you had before you transformed. However, if you revert as a result of dropping to 0 hit points, any excess damage carries over to your normal form. For example, if you take 10 damage in animal form and have only 1 hit point left, you revert and take 9 damage. As long as the excess damage doesn't reduce your normal form to 0 hit points, you aren't knocked unconscious.\n- You can't cast spells, and your ability to speak or take any action that requires hands is limited to the capabilities of your beast form. Transforming doesn't break your concentration on a spell you've already cast, however, or prevent you from taking actions that are part of a spell, such as call lightning, that you've already cast.\n- You retain the benefit of any features from your class, race, or other source and can use them if the new form is physically capable of doing so. However, you can't use any of your special senses, such as darkvision, unless your new form also has that sense.\n- You choose whether your equipment falls to the ground in your space, merges into your new form, or is worn by it. Worn equipment functions as normal, but the GM decides whether it is practical for the new form to wear a piece of equipment, based on the creature's shape and size. Your equipment doesn't change size or shape to match the new form, and any equipment that the new form can't wear must either fall to the ground or merge with it. Equipment that merges with the form has no effect until you leave the form." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/wild-shape", "it"), Language = LanguageCode.It, Name = "Forma Selvatica", Description = "A partire dal 2° livello, il druido può usare la sua azione per assumere magicamente la forma di una bestia che ha già visto in precedenza. Può usare questo privilegio due volte e recupera gli utilizzi spesi quando completa un riposo breve o lungo.\n\nIl livello da druido determina in quali bestie può trasformarsi, come indicato nella tabella delle Forme bestiali. Al 2° livello, per esempio, può trasformarsi in qualsiasi bestia con grado di sfida pari o inferiore a 1/4 che non abbia velocità di volare o di nuotare.\n\n**Forme bestiali**\n\n| Livello | GS massimo | Limitazioni | Esempio |\n|---|---|---|---|\n| 2° | 1/4 | Nessuna velocità di volare o di nuotare | Lupo |\n| 4° | 1/2 | Nessuna velocità di volare | Coccodrillo |\n| 8° | 1 | — | Aquila gigante |\n\nIl druido può restare in forma di bestia per un numero di ore pari alla metà del suo livello da druido (arrotondata per difetto). Poi riprende la sua forma normale, a meno che non spenda un altro utilizzo di questo privilegio. Può tornare alla forma normale prima usando un'azione bonus nel suo turno. Torna automaticamente alla forma normale se perde i sensi, scende a 0 punti ferita o muore.\n\nFinché è trasformato, si applicano le regole seguenti:\n- Le statistiche di gioco del druido sono sostituite da quelle della bestia, ma il druido mantiene il suo allineamento, la sua personalità e i suoi punteggi di Intelligenza, Saggezza e Carisma. Mantiene anche tutte le sue competenze nelle abilità e nei tiri salvezza, oltre a ottenere quelle della creatura. Se la creatura ha la sua stessa competenza e il bonus indicato nella sua scheda è più alto, usa il bonus della creatura anziché il proprio. Se la creatura ha azioni leggendarie o azioni di tana, il druido non può usarle.\n- Quando si trasforma, il druido assume i punti ferita e i Dadi Vita della bestia. Quando torna alla forma normale, ritorna al numero di punti ferita che aveva prima di trasformarsi. Tuttavia, se torna alla forma normale perché è sceso a 0 punti ferita, i danni in eccesso si trasferiscono alla sua forma normale. Per esempio, se subisce 10 danni in forma animale e gli resta soltanto 1 punto ferita, torna alla forma normale e subisce 9 danni. Finché i danni in eccesso non riducono la forma normale a 0 punti ferita, il druido non perde i sensi.\n- Il druido non può lanciare incantesimi, e la sua capacità di parlare o di compiere qualsiasi azione che richieda le mani è limitata alle capacità della sua forma bestiale. Trasformarsi, però, non interrompe la concentrazione su un incantesimo già lanciato e non gli impedisce di compiere le azioni che fanno parte di un incantesimo già lanciato, come *invocare il fulmine*.\n- Il druido mantiene i benefici di tutti i privilegi della sua classe, della sua razza o di altre fonti e può usarli se la nuova forma ne è fisicamente capace. Non può però usare nessuno dei suoi sensi speciali, come la scurovisione, a meno che anche la nuova forma non possieda quel senso.\n- Il druido sceglie se il suo equipaggiamento cade a terra nel suo spazio, si fonde con la nuova forma o viene indossato da essa. L'equipaggiamento indossato funziona normalmente, ma è il DM a decidere se per la nuova forma sia pratico indossare un oggetto, in base alla forma e alla taglia della creatura. L'equipaggiamento non cambia dimensioni o forma per adattarsi alla nuova forma, e qualsiasi oggetto che la nuova forma non può indossare deve cadere a terra o fondersi con essa. L'equipaggiamento fuso con la forma non ha alcun effetto finché il druido non abbandona quella forma." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/druid-circle"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/druid-circle", "en"), Language = LanguageCode.En, Name = "Druid Circle", Description = "At 2nd level, you choose to identify with a circle of druids, such as the Circle of the Land.\n\nYour choice grants you features at 2nd level and again at 6th, 10th, and 14th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/druid-circle", "it"), Language = LanguageCode.It, Name = "Circolo Druidico", Description = "Al 2° livello il druido sceglie di identificarsi con un circolo di druidi, come il Circolo della Terra.\n\nLa scelta gli conferisce privilegi al 2° livello e poi al 6°, al 10° e al 14° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 4,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you can't increase an ability score above 20 using this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Quando arriva al 4° livello, e poi all'8°, al 12°, al 16° e al 19° livello, il personaggio può aumentare di 2 un punteggio di caratteristica a sua scelta, oppure aumentare di 1 due punteggi di caratteristica a sua scelta. Come di consueto, questo privilegio non consente di aumentare un punteggio di caratteristica oltre 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/timeless-body"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 18,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/timeless-body", "en"), Language = LanguageCode.En, Name = "Timeless Body", Description = "Starting at 18th level, the primal magic that you wield causes you to age more slowly. For every 10 years that pass, your body ages only 1 year." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/timeless-body", "it"), Language = LanguageCode.It, Name = "Corpo Senza Tempo", Description = "A partire dal 18° livello, la magia primordiale che il druido padroneggia lo fa invecchiare più lentamente. Per ogni 10 anni che passano, il suo corpo invecchia soltanto di 1 anno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/beast-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 18,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/beast-spells", "en"), Language = LanguageCode.En, Name = "Beast Spells", Description = "Beginning at 18th level, you can cast many of your druid spells in any shape you assume using Wild Shape. You can perform the somatic and verbal components of a druid spell while in a beast shape, but you aren't able to provide material components." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/beast-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi Bestiali", Description = "A partire dal 18° livello, il druido può lanciare molti dei suoi incantesimi da druido in qualsiasi forma assunta tramite Forma Selvatica. Può eseguire le componenti somatiche e verbali di un incantesimo da druido mentre è in forma di bestia, ma non può fornire le componenti materiali." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/archdruid"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 20,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/archdruid", "en"), Language = LanguageCode.En, Name = "Archdruid", Description = "At 20th level, you can use your Wild Shape an unlimited number of times.\n\nAdditionally, you can ignore the verbal and somatic components of your druid spells, as well as any material components that lack a cost and aren't consumed by a spell.\n\nYou gain this benefit in both your normal shape and your beast shape from Wild Shape." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "druid/archdruid", "it"), Language = LanguageCode.It, Name = "Arcidruido", Description = "Al 20° livello il druido può usare Forma Selvatica un numero illimitato di volte.\n\nInoltre può ignorare le componenti verbali e somatiche dei suoi incantesimi da druido, oltre alle componenti materiali che non hanno un costo e non vengono consumate dall'incantesimo.\n\nOttiene questo beneficio sia nella forma normale sia nelle forme bestiali di Forma Selvatica." }
					}
				}
			}
		};
	}
}
