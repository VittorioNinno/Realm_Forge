using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	School of Transmutation (wizard, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class SchoolOfTransmutation2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-transmutation");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Wizard2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-transmutation", "en"), Language = LanguageCode.En, Name = "School of Transmutation", Description = "Transmuters study spells that reshape energy and matter. To them the world is never fixed but endlessly changeable, and they enjoy being agents of that change, working the raw stuff of creation and learning to alter both bodies and minds. Some are pranksters and wild experimenters who turn people into toads or copper into silver for fun or profit; others pursue their craft with deep seriousness, seeking a god's power to make and unmake worlds." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-transmutation", "it"), Language = LanguageCode.It, Name = "Scuola di Trasmutazione", Description = "I trasmutatori studiano gli incantesimi che rimodellano l'energia e la materia. Per loro il mondo non è mai fisso ma infinitamente mutevole, e amano essere gli artefici di quel cambiamento, lavorando la materia grezza del creato e imparando ad alterare sia i corpi sia le menti. Alcuni sono burloni e sperimentatori sfrenati che trasformano le persone in rospi o il rame in argento per divertimento o profitto; altri perseguono la loro arte con grande serietà, aspirando al potere divino di creare e disfare i mondi." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/transmutation-savant"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/transmutation-savant", "en"), Language = LanguageCode.En, Name = "Transmutation Savant", Description = "From the moment you choose this school at 2nd level, the gold and time you need to copy a transmutation spell into your spellbook are halved." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/transmutation-savant", "it"), Language = LanguageCode.It, Name = "Trasmutatore Sapiente", Description = "Dal momento in cui sceglie questa scuola al 2° livello, l'oro e il tempo necessari al mago per copiare un incantesimo di trasmutazione nel suo libro degli incantesimi sono dimezzati." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/minor-alchemy"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/minor-alchemy", "en"), Language = LanguageCode.En, Name = "Minor Alchemy", Description = "From 2nd level, you can temporarily change the physical properties of a nonmagical object, turning one substance into another. You perform a special alchemical procedure on an object made entirely of wood, stone (but not a gemstone), iron, copper, or silver, transforming it into a different one of those materials. Every 10 minutes spent on the procedure transforms up to 1 cubic foot of material. After 1 hour, or if you lose your concentration (as if you were concentrating on a spell), the material reverts to its original substance." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/minor-alchemy", "it"), Language = LanguageCode.It, Name = "Alchimia Minore", Description = "Dal 2° livello il mago può modificare temporaneamente le proprietà fisiche di un oggetto non magico, trasformando una sostanza in un'altra. Applica una speciale procedura alchemica a un oggetto fatto interamente di legno, pietra (ma non gemme), ferro, rame o argento, trasformandolo in un altro di quei materiali. Ogni 10 minuti dedicati alla procedura trasformano fino a un cubo di 30 cm di lato di materiale. Dopo 1 ora, o se il mago perde la concentrazione (come se si stesse concentrando su un incantesimo), il materiale torna alla sua sostanza originale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/transmuter-s-stone"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/transmuter-s-stone", "en"), Language = LanguageCode.En, Name = "Transmuter's Stone", Description = "From 6th level, you can spend 8 hours crafting a transmuter's stone that stores transmutation magic. You can keep it for yourself or give it to another creature. The creature carrying it gains one benefit of your choice, chosen when you craft the stone:\n- darkvision out to 60 feet;\n- a 10-foot increase to its speed while it is unencumbered;\n- proficiency in Constitution saving throws;\n- resistance to acid, cold, fire, lightning, or thunder damage (your choice when you choose this benefit).\n\nEach time you cast a transmutation spell of 1st level or higher, you can change the stone's effect if it is on your person. If you craft a new transmuter's stone, the previous one stops working." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/transmuter-s-stone", "it"), Language = LanguageCode.It, Name = "Pietra del Trasmutatore", Description = "Dal 6° livello il mago può passare 8 ore a creare una pietra del trasmutatore che accumula magia di trasmutazione. Può tenerla per sé o darla a un'altra creatura. La creatura che la porta con sé ottiene un beneficio a scelta del mago, deciso al momento della creazione della pietra:\n- scurovisione entro 18 metri;\n- un aumento di 3 metri della sua velocità finché non è ingombrata;\n- competenza nei tiri salvezza su Costituzione;\n- resistenza ai danni da acido, freddo, fuoco, fulmine o tuono (a scelta del mago quando sceglie questo beneficio).\n\nOgni volta che lancia un incantesimo di trasmutazione di 1° livello o superiore, il mago può cambiare l'effetto della pietra, se la porta con sé. Se crea una nuova pietra del trasmutatore, quella precedente smette di funzionare." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/shapechanger"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/shapechanger", "en"), Language = LanguageCode.En, Name = "Shapechanger", Description = "At 10th level, you add *polymorph* to your spellbook if it isn't there already. You can cast *polymorph* without expending a spell slot; when you do, you can target only yourself, and you must turn into a beast with a challenge rating of 1 or lower.\n\nOnce you cast *polymorph* this way, you can't do so again until you finish a short or long rest, though you can still cast it normally using a spell slot." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/shapechanger", "it"), Language = LanguageCode.It, Name = "Mutaforma", Description = "Al 10° livello il mago aggiunge *metamorfosi* al suo libro degli incantesimi, se non è già presente. Può lanciare *metamorfosi* senza spendere uno slot incantesimo; quando lo fa, può bersagliare soltanto se stesso e deve trasformarsi in una bestia con grado di sfida pari o inferiore a 1.\n\nUna volta lanciato *metamorfosi* in questo modo, non può farlo di nuovo finché non completa un riposo breve o lungo, ma può comunque lanciarlo normalmente usando uno slot incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/master-transmuter"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/master-transmuter", "en"), Language = LanguageCode.En, Name = "Master Transmuter", Description = "From 14th level, you can use your action to release all the transmutation magic stored in your transmuter's stone in a single burst. Choose one of the following effects. Your stone is then destroyed and can't be remade until you finish a long rest.\n\n**Major Transformation.** You transmute a nonmagical object no larger than a 5-foot cube into another nonmagical object of similar size and mass and of equal or lesser value. You must spend 10 minutes handling the object to transform it.\n\n**Panacea.** One creature you touch with the stone is cured of all curses, diseases, and poisons affecting it, and regains all its hit points.\n\n**Restore Life.** You cast *raise dead* on a creature you touch with the stone, without expending a spell slot or needing the spell in your spellbook.\n\n**Restore Youth.** You touch a willing creature with the stone, and its apparent age is reduced by 3d10 years, to a minimum of 13 years. This doesn't extend its lifespan." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-transmutation/master-transmuter", "it"), Language = LanguageCode.It, Name = "Maestro Trasmutatore", Description = "Dal 14° livello il mago può usare la sua azione per liberare in un'unica scarica tutta la magia di trasmutazione accumulata nella sua pietra del trasmutatore. Sceglie uno degli effetti seguenti. La pietra viene poi distrutta e non può essere ricreata finché il mago non completa un riposo lungo.\n\n**Panacea.** Una creatura che il mago tocca con la pietra viene liberata da tutte le maledizioni, le malattie e i veleni che la affliggono e recupera tutti i suoi punti ferita.\n\n**Ripristinare giovinezza.** Il mago tocca una creatura consenziente con la pietra e l'età apparente della creatura si riduce di 3d10 anni, fino a un minimo di 13 anni. Questo effetto non ne prolunga la durata della vita.\n\n**Ripristinare vita.** Il mago lancia *rianimare morti* su una creatura che tocca con la pietra, senza spendere uno slot incantesimo e senza bisogno di avere l'incantesimo nel suo libro.\n\n**Trasformazione maggiore.** Il mago trasmuta un oggetto non magico non più grande di un cubo di 1,5 metri di lato in un altro oggetto non magico di dimensioni e massa simili e di valore pari o inferiore. Deve passare 10 minuti a maneggiare l'oggetto per trasformarlo." }
					}
				}
			}
		};
	}
}
