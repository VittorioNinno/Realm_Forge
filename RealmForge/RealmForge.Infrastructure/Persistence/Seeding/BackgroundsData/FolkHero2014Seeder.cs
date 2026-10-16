using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Folk Hero (2014 ruleset). Not part of SRD 5.1: English and Italian texts are written for RealmForge,
///	keeping the official game terms and mechanics.
///	</summary>
public static class FolkHero2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "folk-hero");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.AnimalHandling, Skill.Survival },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "folk-hero", "en"),
					Language = LanguageCode.En,
					Name = "Folk Hero",
					Description = "You were born among humble folk, but you are meant for far more. The people of your home village already see you as their champion, and fate is calling you to stand against the tyrants and monsters that threaten ordinary people everywhere.\n\n### Defining Event\nYou once lived by a simple trade among the common people: farmer, miner, servant, shepherd, woodcutter, or gravedigger. Then something happened that set you on a different road and marked you for greater things. Choose the defining event that made you a hero of the people, or roll on the table.\n\n| d10 | Defining Event |\n|---|---|\n| 1 | I stood up to a tyrant's agents. |\n| 2 | I saved people during a natural disaster. |\n| 3 | I faced a terrible monster alone. |\n| 4 | I robbed a corrupt merchant to help the poor. |\n| 5 | I led a militia against an invading army. |\n| 6 | I broke into a tyrant's castle and stole weapons to arm the people. |\n| 7 | I taught the peasants to turn their farm tools into weapons against a tyrant's soldiers. |\n| 8 | A lord withdrew an unpopular decree after I led a symbolic protest against it. |\n| 9 | A celestial, a fey, or a similar creature blessed me or revealed my secret origin. |\n| 10 | Drafted into a lord's army, I rose to command and was honored for my heroism. |",
					ToolProficiencies = "One type of artisan's tools, vehicles (land)",
					Equipment = "A set of artisan's tools of your choice\nA shovel\nAn iron pot\nA set of common clothes\nA belt pouch containing 10 gp",
					FeatureName = "Rustic Hospitality",
					FeatureDescription = "You come from the common folk and you fit in among them with ease. Ordinary people will give you a place to hide, rest, or recover, unless you have shown that you are a danger to them. They will shield you from the law or from anyone else searching for you, but they will not risk their lives for you.",
					CharacteristicsIntro = "A folk hero is one of the common people, for better or worse. Most folk heroes see their humble origins as a strength rather than a weakness, and the community they come from stays dear to them.",
					PersonalityTraits = new List<string>
					{
						"I judge people by what they do, not by what they say.",
						"If someone is in trouble, I am always ready to help.",
						"Once I set my mind on something, I see it through, whatever stands in my way.",
						"I have a strong sense of fair play and always look for the fairest way to settle a dispute.",
						"I trust my own abilities and do what I can to give others confidence too.",
						"Thinking is for other people. I prefer action.",
						"I misuse big words to sound smarter.",
						"I get bored easily. When will my destiny finally begin?"
					},
					Ideals = new List<string>
					{
						"Respect. Everyone deserves to be treated with dignity and respect. (Good)",
						"Fairness. Nobody deserves special treatment before the law, and nobody is above it. (Lawful)",
						"Freedom. Tyrants must not be allowed to oppress the people. (Chaotic)",
						"Might. If I become strong, I can take what I want, which is what I deserve. (Evil)",
						"Sincerity. There is nothing to gain by pretending to be what I am not. (Neutral)",
						"Destiny. Nothing and nobody can turn me away from my higher calling. (Any)"
					},
					Bonds = new List<string>
					{
						"I have a family, but I don't know where they are. I hope to see them again one day.",
						"I worked the land, I love the land, and I will protect the land.",
						"A proud noble once had me beaten badly, and now I take revenge on every bully I meet.",
						"My tools remind me of my old life; I carry them so I never forget where I come from.",
						"I protect those who cannot protect themselves.",
						"I wish my childhood sweetheart had come with me to follow my destiny."
					},
					Flaws = new List<string>
					{
						"The tyrant who rules my homeland will stop at nothing to see me dead.",
						"I am so sure of my great destiny that I can't see my own weaknesses or the risk of failure.",
						"The people who knew me as a child know my shameful secret, so I can never go home.",
						"I have a weakness for the vices of the city, strong drink most of all.",
						"Deep down, I think things would be better if I were the tyrant ruling the land.",
						"I find it hard to trust my allies."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "folk-hero", "it"),
					Language = LanguageCode.It,
					Name = "Eroe Popolare",
					Description = "L'eroe popolare è nato tra la gente umile, ma è destinato a molto di più. Gli abitanti del suo villaggio lo considerano già il loro campione, e il destino lo chiama a opporsi ai tiranni e ai mostri che minacciano la gente comune in ogni terra.\n\n### Evento segnante\nUn tempo viveva di un mestiere semplice tra la gente di campagna: contadino, minatore, servitore, pastore, taglialegna o becchino. Poi è accaduto qualcosa che lo ha spinto su un'altra strada e lo ha destinato a cose più grandi. Il giocatore sceglie l'evento segnante che ha reso il personaggio un eroe del popolo, oppure tira sulla tabella.\n\n| d10 | Evento segnante |\n|---|---|\n| 1 | Ha tenuto testa agli sgherri di un tiranno. |\n| 2 | Ha salvato delle persone durante una catastrofe naturale. |\n| 3 | Ha affrontato da solo un mostro terribile. |\n| 4 | Ha derubato un mercante corrotto per aiutare i poveri. |\n| 5 | Ha guidato una milizia contro un esercito invasore. |\n| 6 | Si è introdotto nel castello di un tiranno e ha rubato le armi per armare il popolo. |\n| 7 | Ha insegnato ai contadini a trasformare gli attrezzi agricoli in armi contro i soldati di un tiranno. |\n| 8 | Un signore ha ritirato un decreto impopolare dopo che lui ha guidato una protesta simbolica. |\n| 9 | Un celestiale, un folletto o una creatura simile lo ha benedetto o gli ha rivelato le sue origini segrete. |\n| 10 | Arruolato nell'esercito di un signore, è salito al comando ed è stato onorato per il suo eroismo. |",
					ToolProficiencies = "Un tipo di strumenti da artigiano, veicoli (terrestri)",
					Equipment = "Un set di strumenti da artigiano a scelta\nUna pala\nUna pentola di ferro\nUn abito comune\nUna borsa con 10 mo",
					FeatureName = "Ospitalità Rurale",
					FeatureDescription = "L'eroe popolare viene dalla gente comune e si trova perfettamente a suo agio in mezzo a lei. I popolani gli offrono un posto dove nascondersi, riposare o rimettersi in forze, a meno che non si sia dimostrato un pericolo per loro. Lo proteggeranno dalla legge o da chiunque lo stia cercando, ma non rischieranno la vita per lui.",
					CharacteristicsIntro = "Un eroe popolare è uno della gente comune, nel bene e nel male. Quasi tutti gli eroi popolari considerano le loro umili origini un pregio e non un limite, e la comunità da cui provengono resta loro molto cara.",
					PersonalityTraits = new List<string>
					{
						"Giudica le persone da ciò che fanno, non da ciò che dicono.",
						"Se qualcuno è nei guai, è sempre pronto ad aiutarlo.",
						"Quando si mette in testa qualcosa, la porta a termine, qualunque ostacolo incontri.",
						"Ha un forte senso della correttezza e cerca sempre il modo più equo per risolvere una disputa.",
						"Ha fiducia nelle proprie capacità e fa il possibile per infondere fiducia anche negli altri.",
						"Pensare è roba per gli altri. Lui preferisce agire.",
						"Usa paroloni a sproposito per sembrare più intelligente.",
						"Si annoia facilmente. Quando comincerà davvero il suo destino?"
					},
					Ideals = new List<string>
					{
						"Rispetto. Tutti meritano di essere trattati con dignità e rispetto. (Buono)",
						"Giustizia. Nessuno merita un trattamento di favore davanti alla legge, e nessuno è al di sopra di essa. (Legale)",
						"Libertà. Ai tiranni non deve essere permesso di opprimere il popolo. (Caotico)",
						"Potenza. Se diventerà forte, potrà prendersi ciò che vuole, cioè ciò che merita. (Malvagio)",
						"Sincerità. Non si guadagna nulla a fingersi ciò che non si è. (Neutrale)",
						"Destino. Niente e nessuno può allontanarlo dalla sua vocazione più alta. (Qualsiasi)"
					},
					Bonds = new List<string>
					{
						"Ha una famiglia, ma non sa dove si trovi. Spera di rivederla un giorno.",
						"Ha lavorato la terra, ama la terra e proteggerà la terra.",
						"Un nobile superbo una volta lo ha fatto picchiare brutalmente, e ora si vendica di ogni prepotente che incontra.",
						"I suoi attrezzi gli ricordano la vita di un tempo; li porta con sé per non dimenticare mai da dove viene.",
						"Protegge chi non è in grado di proteggersi da solo.",
						"Vorrebbe che il suo amore di gioventù lo avesse seguito per inseguire il suo destino."
					},
					Flaws = new List<string>
					{
						"Il tiranno che governa la sua terra non si fermerà davanti a nulla pur di vederlo morto.",
						"È così sicuro del suo grande destino da non vedere i propri limiti né il rischio di fallire.",
						"Chi lo ha conosciuto da bambino conosce il suo segreto vergognoso, perciò non può più tornare a casa.",
						"Ha un debole per i vizi della città, soprattutto per le bevande forti.",
						"In fondo pensa che le cose andrebbero meglio se fosse lui il tiranno a governare la terra.",
						"Fa fatica a fidarsi dei suoi alleati."
					}
				}
			}
		};
	}
}
