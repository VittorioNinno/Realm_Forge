using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Entertainer (2014 ruleset), with the Gladiator variant. Not part of SRD 5.1: English and Italian texts are
///	written for RealmForge, keeping the official game terms and mechanics. The routine table uses the same order
///	in both languages, so a roll gives the same result whatever the language.
///	</summary>
public static class Entertainer2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "entertainer");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.Acrobatics, Skill.Performance },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "entertainer", "en"),
					Language = LanguageCode.En,
					Name = "Entertainer",
					Description = "You come alive in front of an audience. You know how to enchant a crowd, amuse it, and even inspire it. Your verses can move listeners to tears or to joy, to laughter or to anger; your music lifts their spirits or gives voice to their sorrow; your dancing holds every eye and your wit strikes right where it should. Whatever your craft, your art is your life.\n\n### Entertainer Routines\nGood entertainers are versatile and season every show with several kinds of acts. Choose one to three routines, or roll on the table, to define what you do best.\n\n| d10 | Routine |\n|---|---|\n| 1 | Actor |\n| 2 | Dancer |\n| 3 | Fire-eater |\n| 4 | Jester |\n| 5 | Juggler |\n| 6 | Instrumentalist |\n| 7 | Poet |\n| 8 | Singer |\n| 9 | Storyteller |\n| 10 | Tumbler |\n\n### Variant: Gladiator\nA gladiator is as much an entertainer as any minstrel or circus artist, trained to turn the art of combat into a show the crowd will cheer. Spectacular fighting is your routine, though you may also have some talent as a tumbler or an actor. With the By Popular Demand feature you can find a place to perform wherever fighting is a form of entertainment, such as a gladiatorial arena or a secret fighting pit. You can replace the musical instrument in your equipment with a cheap but unusual weapon, such as a trident or a net.",
					ToolProficiencies = "Disguise kit, one type of musical instrument",
					Equipment = "A musical instrument of your choice\nThe favor of an admirer (a love letter, a lock of hair, or a trinket)\nA costume\nA belt pouch containing 15 gp",
					FeatureName = "By Popular Demand",
					FeatureDescription = "You can always find somewhere to perform: usually an inn or a tavern, but also a circus, a theater, or even a noble's court. In such a place you get free lodging and food of a modest or comfortable standard, depending on the quality of the establishment, as long as you perform every night. Your shows also make you something of a local celebrity: when strangers recognize you in a town where you have performed, they usually take a liking to you.",
					CharacteristicsIntro = "Successful entertainers must be able to catch and hold an audience's attention, so they tend to have flamboyant or forceful personalities. Many are romantics at heart and cling to lofty ideals about art and beauty.",
					PersonalityTraits = new List<string>
					{
						"I know a story that fits almost any situation.",
						"Whenever I arrive somewhere new, I gather the local rumors and spread some gossip of my own.",
						"I am a hopeless romantic, always looking for that \"special someone\".",
						"Nobody stays angry at me, or near me, for long: I can ease any tension.",
						"I enjoy a well-crafted insult, even when it is aimed at me.",
						"I turn sour when I am not the center of attention.",
						"I will accept nothing short of perfection.",
						"I change my mood or my mind as quickly as I change key in a song."
					},
					Ideals = new List<string>
					{
						"Beauty. When I perform, I leave the world better than I found it. (Good)",
						"Tradition. The stories, legends, and songs of the past must never be forgotten, because they tell us who we are. (Lawful)",
						"Creativity. The world needs new ideas and bold deeds. (Chaotic)",
						"Greed. I do it only for money and fame. (Evil)",
						"People. I love seeing people smile while I perform. Nothing else matters. (Neutral)",
						"Honesty. Art should mirror the soul; it should come from within and show who we really are. (Any)"
					},
					Bonds = new List<string>
					{
						"My instrument is my most precious possession, and it reminds me of someone I love.",
						"Someone stole my beloved instrument, and one day I will get it back.",
						"I want to be famous, whatever the cost.",
						"I worship a hero of the old tales and measure my deeds against theirs.",
						"I will do anything to prove I am better than my hated rival.",
						"I would do anything for the members of my old troupe."
					},
					Flaws = new List<string>
					{
						"I will do anything to win fame and renown.",
						"A pretty face makes a fool of me.",
						"A scandal keeps me from ever going home, and that kind of trouble seems to follow me everywhere.",
						"I once mocked a noble who still wants my head. It was a mistake, and I will probably make it again.",
						"I can't hide what I really feel, and my sharp tongue gets me into trouble.",
						"However hard I try, my friends can't count on me."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "entertainer", "it"),
					Language = LanguageCode.It,
					Name = "Intrattenitore",
					Description = "L'intrattenitore prende vita davanti a un pubblico. Sa come incantare una folla, divertirla e perfino ispirarla. I suoi versi commuovono fino alle lacrime o alla gioia, alla risata o alla collera; la sua musica solleva gli animi o dà voce al loro dolore; la sua danza cattura ogni sguardo e la sua ironia colpisce sempre nel segno. Qualunque sia la sua specialità, l'arte è la sua vita.\n\n### Discipline artistiche\nI buoni intrattenitori sono versatili e arricchiscono ogni spettacolo con numeri diversi. Il giocatore sceglie da una a tre discipline, oppure tira sulla tabella, per definire ciò in cui il personaggio eccelle.\n\n| d10 | Disciplina |\n|---|---|\n| 1 | Attore |\n| 2 | Danzatore |\n| 3 | Mangiatore di fuoco |\n| 4 | Giullare |\n| 5 | Giocoliere |\n| 6 | Strumentista |\n| 7 | Poeta |\n| 8 | Cantore |\n| 9 | Narratore |\n| 10 | Acrobata |\n\n### Variante: Gladiatore\nUn gladiatore è un intrattenitore tanto quanto un menestrello o un artista circense: è addestrato a trasformare l'arte del combattimento in uno spettacolo che la folla acclama. Il combattimento spettacolare è il suo numero, anche se potrebbe avere qualche talento come acrobata o attore. Grazie al privilegio A Grande Richiesta trova un luogo dove esibirsi ovunque il combattimento sia una forma di intrattenimento, come un'arena per gladiatori o una fossa segreta per combattimenti clandestini. Può sostituire lo strumento musicale del suo equipaggiamento con un'arma economica ma insolita, come un tridente o una rete.",
					ToolProficiencies = "Trucchi per il camuffamento, un tipo di strumento musicale",
					Equipment = "Uno strumento musicale a scelta\nIl pegno di un ammiratore (una lettera d'amore, una ciocca di capelli o un monile)\nUn costume\nUna borsa con 15 mo",
					FeatureName = "A Grande Richiesta",
					FeatureDescription = "L'intrattenitore trova sempre un luogo in cui esibirsi: di solito una locanda o una taverna, ma anche un circo, un teatro o perfino una corte nobiliare. In questi luoghi riceve gratuitamente vitto e alloggio di tenore modesto o agiato, a seconda della qualità del locale, purché si esibisca ogni sera. I suoi spettacoli lo rendono inoltre una piccola celebrità locale: quando degli sconosciuti lo riconoscono in una città in cui si è esibito, di solito lo trovano simpatico.",
					CharacteristicsIntro = "Gli intrattenitori di successo devono saper catturare e mantenere l'attenzione del pubblico, perciò tendono ad avere personalità vistose o energiche. Molti sono romantici nell'animo e restano legati a ideali elevati sull'arte e sulla bellezza.",
					PersonalityTraits = new List<string>
					{
						"Conosce una storia adatta a quasi ogni situazione.",
						"Ogni volta che arriva in un posto nuovo raccoglie le voci locali e mette in giro qualche pettegolezzo.",
						"È un inguaribile romantico, sempre alla ricerca di quella \"persona speciale\".",
						"Nessuno resta arrabbiato a lungo con lui, o vicino a lui: sa sciogliere qualsiasi tensione.",
						"Apprezza un insulto ben congegnato, anche quando è rivolto a lui.",
						"Si inasprisce quando non è al centro dell'attenzione.",
						"Non accetta niente di meno della perfezione.",
						"Cambia umore o idea con la stessa rapidità con cui cambia tonalità in una canzone."
					},
					Ideals = new List<string>
					{
						"Bellezza. Quando si esibisce, lascia il mondo migliore di come lo ha trovato. (Buono)",
						"Tradizione. Le storie, le leggende e le canzoni del passato non devono mai essere dimenticate, perché ci dicono chi siamo. (Legale)",
						"Creatività. Il mondo ha bisogno di idee nuove e di gesta audaci. (Caotico)",
						"Avidità. Lo fa solo per il denaro e la fama. (Malvagio)",
						"Persone. Ama vedere la gente sorridere mentre si esibisce. Nient'altro conta. (Neutrale)",
						"Onestà. L'arte dovrebbe rispecchiare l'anima: deve nascere da dentro e mostrare chi siamo davvero. (Qualsiasi)"
					},
					Bonds = new List<string>
					{
						"Il suo strumento è il suo bene più prezioso e gli ricorda una persona che ama.",
						"Qualcuno gli ha rubato l'amato strumento, e un giorno se lo riprenderà.",
						"Vuole diventare famoso, a qualunque costo.",
						"Venera un eroe delle antiche storie e misura le proprie imprese con le sue.",
						"Farà qualunque cosa per dimostrare di essere migliore del suo odiato rivale.",
						"Farebbe qualunque cosa per i membri della sua vecchia compagnia."
					},
					Flaws = new List<string>
					{
						"Farà qualunque cosa per conquistare fama e gloria.",
						"Davanti a un bel viso perde la testa.",
						"Uno scandalo gli impedisce di tornare a casa, e guai di quel genere sembrano seguirlo ovunque.",
						"Una volta ha deriso un nobile che vuole ancora la sua testa. È stato un errore, e probabilmente lo rifarà.",
						"Non riesce a nascondere ciò che prova davvero, e la sua lingua tagliente lo mette nei guai.",
						"Per quanto ci provi, i suoi amici non possono contare su di lui."
					}
				}
			}
		};
	}
}
