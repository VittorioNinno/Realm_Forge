using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Knowledge Domain (cleric, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class KnowledgeDomain2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "knowledge-domain");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Cleric2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "knowledge-domain", "en"), Language = LanguageCode.En, Name = "Knowledge Domain", Description = "Deities of knowledge prize learning, understanding and invention above everything else. Some want knowledge shared in libraries and schools, some guard secrets jealously, others promise power to those who unlock the hidden truths of the multiverse; gods of smiths and crafters also belong here. Their clerics collect lore, study forgotten tomes and seek out places where secrets lie buried." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "knowledge-domain", "it"), Language = LanguageCode.It, Name = "Dominio della Conoscenza", Description = "Le divinità della conoscenza apprezzano più di ogni altra cosa l'apprendimento, la comprensione e l'invenzione. Alcune vogliono che il sapere sia condiviso in biblioteche e scuole, altre custodiscono gelosamente i segreti, altre ancora promettono potere a chi svela le verità nascoste del multiverso; a questo dominio appartengono anche gli dèi dei fabbri e degli artigiani. I loro chierici raccolgono conoscenze, studiano tomi dimenticati e cercano i luoghi in cui giacciono sepolti i segreti." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/knowledge-domain-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/knowledge-domain-spells", "en"), Language = LanguageCode.En, Name = "Knowledge Domain Spells", Description = "You gain these domain spells at the cleric levels shown. See the Divine Domain class feature for how domain spells work.\n\n| Cleric Level | Spells |\n|---|---|\n| 1st | command, identify |\n| 3rd | augury, suggestion |\n| 5th | nondetection, speak with dead |\n| 7th | arcane eye, confusion |\n| 9th | legend lore, scrying |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/knowledge-domain-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Dominio della Conoscenza", Description = "Il chierico ottiene questi incantesimi di dominio ai livelli da chierico indicati. Il funzionamento degli incantesimi di dominio è descritto nel privilegio di classe Dominio Divino.\n\n| Livello da chierico | Incantesimi |\n|---|---|\n| 1° | comando, identificare |\n| 3° | presagio, suggestione |\n| 5° | anti-individuazione, parlare con i morti |\n| 7° | confusione, occhio arcano |\n| 9° | conoscenza delle leggende, scrutare |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/blessings-of-knowledge"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/blessings-of-knowledge", "en"), Language = LanguageCode.En, Name = "Blessings of Knowledge", Description = "At 1st level, your god opens your mind. You learn two languages of your choice, and you become proficient in two of these skills of your choice: Arcana, History, Nature, or Religion. For ability checks using either of those two skills, your proficiency bonus is doubled." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/blessings-of-knowledge", "it"), Language = LanguageCode.It, Name = "Benedizioni della Conoscenza", Description = "Al 1° livello la divinità del chierico gli apre la mente. Il chierico impara due linguaggi a sua scelta e ottiene competenza in due tra queste abilità a sua scelta: Arcano, Storia, Natura o Religione. Per le prove di caratteristica che usano una di queste due abilità, il suo bonus di competenza raddoppia." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/channel-divinity-knowledge-of-the-ages"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/channel-divinity-knowledge-of-the-ages", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Knowledge of the Ages", Description = "From 2nd level, you can draw on a deep well of divine lore. As an action, you use your Channel Divinity and pick one skill or tool: you are proficient with it for the next 10 minutes." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/channel-divinity-knowledge-of-the-ages", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Conoscenze Secolari", Description = "Dal 2° livello il chierico può attingere a una profonda fonte di sapere divino. Come azione, usa Incanalare Divinità e sceglie un'abilità o uno strumento: ne ha competenza per i 10 minuti successivi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/channel-divinity-read-thoughts"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/channel-divinity-read-thoughts", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Read Thoughts", Description = "At 6th level, your Channel Divinity can open another creature's mind to you. As an action, pick a creature you can see within 60 feet of you; it makes a Wisdom saving throw.\n- **Success.** Nothing happens, and you can't use this feature on that creature again until you finish a long rest.\n- **Failure.** For 1 minute, while the creature is within 60 feet of you, you hear its surface thoughts: whatever is foremost in its mind, including its current emotions and what it is actively thinking about. During that minute, you can use your action to end the effect and cast *suggestion* on the creature without spending a spell slot; it automatically fails the saving throw against that spell." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/channel-divinity-read-thoughts", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Lettura del Pensiero", Description = "Al 6° livello Incanalare Divinità può aprire al chierico la mente di un'altra creatura. Come azione, il chierico sceglie una creatura entro 18 metri che è in grado di vedere; la creatura effettua un tiro salvezza su Saggezza.\n- **Successo.** Non accade nulla, e il chierico non può usare di nuovo questo privilegio su quella creatura finché non completa un riposo lungo.\n- **Fallimento.** Per 1 minuto, finché la creatura si trova entro 18 metri da lui, il chierico ne sente i pensieri superficiali: ciò che le occupa la mente in quel momento, incluse le emozioni che prova e ciò a cui sta pensando attivamente. Durante quel minuto, il chierico può usare la sua azione per porre fine all'effetto e lanciare *suggestione* sulla creatura senza spendere uno slot incantesimo; la creatura fallisce automaticamente il tiro salvezza contro quell'incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/potent-spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 8,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/potent-spellcasting", "en"), Language = LanguageCode.En, Name = "Potent Spellcasting", Description = "From 8th level, the damage you deal with any cleric cantrip increases by your Wisdom modifier." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/potent-spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi Potenti", Description = "Dall'8° livello, i danni che il chierico infligge con qualsiasi trucchetto da chierico aumentano di un ammontare pari al suo modificatore di Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/visions-of-the-past"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/visions-of-the-past", "en"), Language = LanguageCode.En, Name = "Visions of the Past", Description = "At 17th level, you can glimpse recent events tied to an object or a place. You meditate and pray for at least 1 minute, receiving dreamlike, shadowy images; you can keep meditating for a number of minutes up to your Wisdom score, maintaining concentration as if on a spell. After using this feature, you must finish a short or long rest before using it again. Choose one of these readings:\n- **Object Reading.** While holding an object, after 1 minute you learn how its previous owner obtained and lost it, and the most recent significant event involving that object and owner. If other creatures owned it recently (within a number of days equal to your Wisdom score), each additional minute of meditation gives you the same information about one of them.\n- **Area Reading.** You perceive recent events in your immediate surroundings (a room, street, tunnel, clearing or similar, up to a 50-foot cube), going back a number of days equal to your Wisdom score. Each minute of meditation reveals one significant event, starting from the most recent. Significant events usually carry strong emotions, such as battles and betrayals, marriages and murders, births and funerals, but they can also be ordinary events that matter in your current situation." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "knowledge-domain/visions-of-the-past", "it"), Language = LanguageCode.It, Name = "Visioni del Passato", Description = "Al 17° livello il chierico può scorgere gli eventi recenti legati a un oggetto o a un luogo. Medita e prega per almeno 1 minuto, ricevendo immagini indistinte e simili a sogni; può continuare a meditare per un numero di minuti non superiore al suo punteggio di Saggezza, mantenendo la concentrazione come se si trattasse di un incantesimo. Dopo aver usato questo privilegio, deve completare un riposo breve o lungo prima di poterlo usare di nuovo. Sceglie una di queste letture:\n- **Lettura di un oggetto.** Tenendo in mano un oggetto, dopo 1 minuto il chierico scopre come il suo precedente proprietario lo ha ottenuto e perduto, e l'evento significativo più recente che ha coinvolto quell'oggetto e quel proprietario. Se l'oggetto è appartenuto di recente ad altre creature (entro un numero di giorni pari al punteggio di Saggezza del chierico), ogni minuto di meditazione aggiuntivo gli fornisce le stesse informazioni su una di esse.\n- **Lettura di un luogo.** Il chierico percepisce gli eventi recenti accaduti nelle sue immediate vicinanze (una stanza, una strada, una galleria, una radura o simili, fino a un cubo di 15 metri di spigolo), risalendo indietro di un numero di giorni pari al suo punteggio di Saggezza. Ogni minuto di meditazione rivela un evento significativo, a partire dal più recente. Gli eventi significativi sono di solito carichi di emozioni intense, come battaglie e tradimenti, matrimoni e omicidi, nascite e funerali, ma possono anche essere fatti ordinari che contano nella situazione attuale." }
					}
				}
			}
		};
	}
}
