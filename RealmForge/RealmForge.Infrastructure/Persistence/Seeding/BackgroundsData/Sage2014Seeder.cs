using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Sage (2014 ruleset). Not part of SRD 5.1: English and Italian texts are written for RealmForge, keeping the
///	official game terms and mechanics. The specialty table uses the same order in both languages, so a roll gives
///	the same result whatever the language. The sage has no tool proficiencies.
///	</summary>
public static class Sage2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "sage");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.Arcana, Skill.History },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "sage", "en"),
					Language = LanguageCode.En,
					Name = "Sage",
					Description = "You spent years studying the lore of the multiverse. You pored over manuscripts, examined scrolls, and listened to the greatest experts in the subjects that fascinate you. Your dedication has made you a master of your chosen fields.\n\n### Specialty\nChoose the nature of your scholarly training, or roll on the table.\n\n| d8 | Specialty |\n|---|---|\n| 1 | Alchemist |\n| 2 | Astronomer |\n| 3 | Discredited academic |\n| 4 | Librarian |\n| 5 | Professor |\n| 6 | Researcher |\n| 7 | Wizard's apprentice |\n| 8 | Scribe |",
					Languages = "Two of your choice",
					Equipment = "A bottle of black ink\nA quill\nA small knife\nA letter from a dead colleague posing a question you have not yet been able to answer\nA set of common clothes\nA belt pouch containing 10 gp",
					FeatureName = "Researcher",
					FeatureDescription = "When you try to learn or recall a piece of lore you don't know, you often know where and from whom you can get it. Usually the information comes from a library, a scriptorium, a university, or a sage or other learned person or creature. Your DM might rule that the knowledge you seek is hidden away in an almost unreachable place, or that it simply can't be found. Uncovering the deepest secrets of the multiverse can take an adventure, or even a whole campaign.",
					CharacteristicsIntro = "Sages are defined by their long years of study, and their characteristics reflect a life devoted to learning. Committed to scholarly pursuits, a sage prizes knowledge above all, sometimes for its own sake, sometimes as a means to other ideals.",
					PersonalityTraits = new List<string>
					{
						"I use long, elaborate words to give the impression of great learning.",
						"I have read every book in the world's greatest libraries, or so I like to boast.",
						"I am used to helping people less clever than I am, and I patiently explain anything and everything.",
						"Nothing pleases me more than a good mystery.",
						"I listen to every side of an argument before I make up my own mind.",
						"I... speak... slowly... when talking... to idiots... which... almost... everyone... is... compared... to me.",
						"I am terribly, terribly awkward in social situations.",
						"I am convinced that people are always trying to steal my secrets."
					},
					Ideals = new List<string>
					{
						"Knowledge. Knowledge is the path to power and self-improvement. (Neutral)",
						"Beauty. What is beautiful points beyond itself, toward what is true. (Good)",
						"Logic. Emotions must not cloud our logical thinking. (Lawful)",
						"No Limits. Nothing should constrain the infinite possibilities within all existence. (Chaotic)",
						"Power. Knowledge is the road to power and domination. (Evil)",
						"Self-Improvement. The purpose of a life of study is to better oneself. (Any)"
					},
					Bonds = new List<string>
					{
						"It is my duty to protect my students.",
						"I own an ancient text full of terrible secrets that must not fall into the wrong hands.",
						"I work to preserve a library, a university, a scriptorium, or a monastery.",
						"My life's work is a series of volumes on a particular field of knowledge.",
						"All my life I have been looking for the answer to one particular question.",
						"I sold my soul for knowledge. I hope to accomplish great deeds and win it back."
					},
					Flaws = new List<string>
					{
						"The promise of new information easily distracts me.",
						"Most people scream and run when they see a demon. I stop and take notes on its anatomy.",
						"Unlocking an ancient mystery is worth the price of a civilization.",
						"I overlook obvious solutions in favor of complicated ones.",
						"I speak without thinking my words through, and I end up offending people every time.",
						"I can't keep a secret to save my life, or anyone else's."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "sage", "it"),
					Language = LanguageCode.It,
					Name = "Sapiente",
					Description = "Il sapiente ha passato anni a studiare i segreti del multiverso. Ha esaminato manoscritti, studiato pergamene e ascoltato i più grandi esperti delle materie che lo appassionano. La sua dedizione lo ha reso un maestro nei suoi campi di studio.\n\n### Specializzazione\nIl giocatore sceglie la natura della formazione accademica del personaggio, oppure tira sulla tabella.\n\n| d8 | Specializzazione |\n|---|---|\n| 1 | Alchimista |\n| 2 | Astronomo |\n| 3 | Accademico in disgrazia |\n| 4 | Bibliotecario |\n| 5 | Professore |\n| 6 | Ricercatore |\n| 7 | Apprendista mago |\n| 8 | Scriba |",
					Languages = "Due a scelta",
					Equipment = "Una boccetta di inchiostro nero\nUna penna d'oca\nUn coltellino\nUna lettera di un collega defunto che pone una domanda a cui il sapiente non ha ancora trovato risposta\nUn abito comune\nUna borsa con 10 mo",
					FeatureName = "Ricercatore",
					FeatureDescription = "Quando il sapiente cerca di apprendere o ricordare un'informazione che non conosce, spesso sa dove e da chi può ottenerla. Di solito l'informazione si trova in una biblioteca, uno scriptorium o un'università, oppure la possiede un altro sapiente o una persona o creatura istruita. Il DM potrebbe stabilire che la conoscenza cercata sia custodita in un luogo quasi irraggiungibile, o che semplicemente non sia possibile trovarla. Svelare i segreti più profondi del multiverso può richiedere un'avventura, o perfino un'intera campagna.",
					CharacteristicsIntro = "I sapienti sono definiti dai loro lunghi anni di studio, e le loro caratteristiche riflettono una vita dedicata all'apprendimento. Votato alla ricerca accademica, il sapiente tiene la conoscenza in grandissima considerazione, a volte fine a se stessa, a volte come mezzo per perseguire altri ideali.",
					PersonalityTraits = new List<string>
					{
						"Usa parole lunghe e ricercate per dare l'impressione di una grande erudizione.",
						"Ha letto ogni libro delle più grandi biblioteche del mondo, o almeno ama vantarsene.",
						"È abituato ad aiutare chi è meno intelligente di lui e spiega con pazienza qualunque cosa a chiunque.",
						"Niente gli piace di più di un bel mistero.",
						"Ascolta ogni parte di una disputa prima di formarsi un giudizio.",
						"Parla... lentamente... quando si rivolge... agli idioti... cioè... quasi... tutti... rispetto... a lui.",
						"È terribilmente, terribilmente goffo nelle situazioni sociali.",
						"È convinto che gli altri cerchino sempre di rubargli i suoi segreti."
					},
					Ideals = new List<string>
					{
						"Conoscenza. La conoscenza è la via verso il potere e il miglioramento di sé. (Neutrale)",
						"Bellezza. Ciò che è bello rimanda oltre se stesso, verso ciò che è vero. (Buono)",
						"Logica. Le emozioni non devono offuscare il pensiero logico. (Legale)",
						"Nessun limite. Niente dovrebbe porre freni alle infinite possibilità insite in ogni esistenza. (Caotico)",
						"Potere. Il sapere è la strada verso il potere e il dominio. (Malvagio)",
						"Miglioramento. Lo scopo di una vita di studio è migliorare se stessi. (Qualsiasi)"
					},
					Bonds = new List<string>
					{
						"È suo dovere proteggere i suoi studenti.",
						"Possiede un testo antico pieno di terribili segreti che non devono cadere nelle mani sbagliate.",
						"Si adopera per preservare una biblioteca, un'università, uno scriptorium o un monastero.",
						"L'opera della sua vita è una serie di volumi su un campo specifico del sapere.",
						"Per tutta la vita ha cercato la risposta a una domanda precisa.",
						"Ha venduto l'anima in cambio della conoscenza. Spera di compiere grandi imprese per riconquistarla."
					},
					Flaws = new List<string>
					{
						"La promessa di nuove informazioni lo distrae facilmente.",
						"Quasi tutti urlano e scappano quando vedono un demone. Lui si ferma a prendere appunti sulla sua anatomia.",
						"Svelare un antico mistero vale il prezzo di un'intera civiltà.",
						"Trascura le soluzioni ovvie a favore di quelle complicate.",
						"Parla senza riflettere sulle parole che usa, e finisce immancabilmente per offendere qualcuno.",
						"Non riuscirebbe a mantenere un segreto nemmeno per salvarsi la vita, o per salvarla a qualcun altro."
					}
				}
			}
		};
	}
}
