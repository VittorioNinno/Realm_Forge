using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Criminal (2014 ruleset), with the Spy variant. Not part of SRD 5.1: English and Italian texts are written
///	for RealmForge, keeping the official game terms and mechanics. The specialty table uses the same order in
///	both languages, so a roll gives the same result whatever the language.
///	</summary>
public static class Criminal2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "criminal");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.Deception, Skill.Stealth },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "criminal", "en"),
					Language = LanguageCode.En,
					Name = "Criminal",
					Description = "You have broken the law more times than you care to count. You have spent years among thieves, cutthroats, and smugglers, and you still know people in that hidden world of murder, theft, and violence that lurks beneath every civilized town. You have survived so far by ignoring the rules that bind everyone else.\n\n### Criminal Specialty\nEvery criminal has a line of work. Members of a thieves' guild or a similar organization usually specialize, and even those who work alone prefer some crimes to others. Choose the role you played in your criminal life, or roll on the table.\n\n| d8 | Specialty |\n|---|---|\n| 1 | Blackmailer |\n| 2 | Burglar |\n| 3 | Enforcer |\n| 4 | Fence |\n| 5 | Highway robber |\n| 6 | Hired killer |\n| 7 | Pickpocket |\n| 8 | Smuggler |\n\n### Variant: Spy\nYour skills are much like those of a burglar or a smuggler, but you learned and used them as an espionage agent. You may have served the crown in secret, or sold what you discovered to whoever paid the most.",
					ToolProficiencies = "One type of gaming set, thieves' tools",
					Equipment = "A crowbar\nA set of dark common clothes, including a hood\nA belt pouch containing 15 gp",
					FeatureName = "Criminal Contact",
					FeatureDescription = "You have a reliable, trustworthy contact who links you to a network of other criminals. You know how to send messages to this contact and receive answers, even across great distances: you know which local messengers, corrupt caravan masters, and shady sailors will carry your messages.",
					CharacteristicsIntro = "At first sight criminals may look like villains, and many of them truly are. Yet some have qualities that make them likable, if not redeemable. There may be honor among thieves, but criminals rarely respect the law or those who enforce it.",
					PersonalityTraits = new List<string>
					{
						"I always have a backup plan for when things go wrong.",
						"I stay calm whatever happens. I never raise my voice or let my feelings take over.",
						"The first thing I do in a new place is spot everything valuable, and every place where something valuable could be hidden.",
						"I would rather make a new friend than a new enemy.",
						"I am very slow to trust anyone. Those who look the most honest usually have the most to hide.",
						"I pay no attention to the risks. Don't bother telling me the odds.",
						"The surest way to get me to do something is to tell me I can't.",
						"The smallest insult makes me lose my temper."
					},
					Ideals = new List<string>
					{
						"Honor. I never steal from others in the trade. (Lawful)",
						"Freedom. Chains are made to be broken, and so are those who forge them. (Chaotic)",
						"Charity. I rob the rich to help those in need. (Good)",
						"Greed. I will do whatever it takes to get rich. (Evil)",
						"People. I am loyal to my friends, not to ideals, and everyone else can take a trip down the Styx for all I care. (Neutral)",
						"Redemption. There is a spark of good in everyone. (Good)"
					},
					Bonds = new List<string>
					{
						"I am trying to repay an old debt to a generous benefactor.",
						"What I earn outside the law keeps my family fed.",
						"Something important was taken from me, and I mean to steal it back.",
						"I will become the greatest thief who ever lived.",
						"I am guilty of a terrible crime, and I hope to make up for it.",
						"Someone I loved died because of a mistake I made. It will never happen again."
					},
					Flaws = new List<string>
					{
						"When I see something valuable, I can think of nothing but how to steal it.",
						"When I must choose between money and my friends, I usually choose the money.",
						"If there is a plan, I forget it. If I don't forget it, I ignore it.",
						"Something in my manner gives me away when I lie.",
						"When things look bad, I turn tail and run.",
						"An innocent person is in prison for a crime I committed, and I can live with that."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "criminal", "it"),
					Language = LanguageCode.It,
					Name = "Criminale",
					Description = "Il criminale ha infranto la legge più volte di quante voglia ricordare. Ha passato anni tra ladri, tagliagole e contrabbandieri, e conosce ancora qualcuno in quel mondo nascosto di omicidi, furti e violenze che si annida sotto ogni città civile. Finora è sopravvissuto ignorando le regole a cui tutti gli altri devono sottostare.\n\n### Specializzazione criminale\nOgni criminale ha il suo mestiere. I membri di una gilda dei ladri o di un'organizzazione simile di solito si specializzano, e persino chi agisce da solo preferisce certi crimini ad altri. Il giocatore sceglie il ruolo che il personaggio ha avuto nella sua vita criminale, oppure tira sulla tabella.\n\n| d8 | Specializzazione |\n|---|---|\n| 1 | Ricattatore |\n| 2 | Scassinatore |\n| 3 | Picchiatore |\n| 4 | Ricettatore |\n| 5 | Brigante |\n| 6 | Assassino |\n| 7 | Borseggiatore |\n| 8 | Contrabbandiere |\n\n### Variante: Spia\nLe capacità della spia sono molto simili a quelle di uno scassinatore o di un contrabbandiere, ma le ha apprese e messe in pratica come agente segreto. Potrebbe aver servito la corona in segreto, oppure aver venduto ciò che scopriva al migliore offerente.",
					ToolProficiencies = "Arnesi da scasso, un tipo di set da gioco",
					Equipment = "Un piede di porco\nUn abito comune scuro con cappuccio\nUna borsa con 15 mo",
					FeatureName = "Contatto Criminale",
					FeatureDescription = "Il criminale ha un contatto affidabile che lo collega a una rete di altri criminali. Sa come fargli arrivare messaggi e come riceverne le risposte, anche a grandi distanze: conosce i messaggeri locali, i mastri carovanieri corrotti e i marinai poco raccomandabili disposti a recapitarli per lui.",
					CharacteristicsIntro = "A prima vista i criminali possono sembrare dei furfanti, e molti lo sono davvero. Alcuni, però, hanno qualità che li rendono simpatici, se non degni di riscatto. Forse esiste un onore tra i ladri, ma i criminali rispettano di rado la legge e chi la fa rispettare.",
					PersonalityTraits = new List<string>
					{
						"Ha sempre un piano di riserva per quando le cose si mettono male.",
						"Resta calmo qualunque cosa accada. Non alza mai la voce e non si lascia mai dominare dalle emozioni.",
						"La prima cosa che fa in un posto nuovo è individuare tutto ciò che ha valore e ogni luogo in cui qualcosa di prezioso potrebbe essere nascosto.",
						"Preferisce farsi un nuovo amico piuttosto che un nuovo nemico.",
						"Si fida di qualcuno solo dopo molto tempo. Chi sembra più onesto, di solito, ha più cose da nascondere.",
						"Non bada ai rischi. Inutile parlargli di probabilità.",
						"Il modo più sicuro per fargli fare qualcosa è dirgli che non può farla.",
						"Perde le staffe alla minima offesa."
					},
					Ideals = new List<string>
					{
						"Onore. Non deruba mai chi fa il suo stesso mestiere. (Legale)",
						"Libertà. Le catene sono fatte per essere spezzate, e così chi le forgia. (Caotico)",
						"Carità. Deruba i ricchi per aiutare chi è nel bisogno. (Buono)",
						"Avidità. Farà qualunque cosa pur di arricchirsi. (Malvagio)",
						"Persone. È leale ai suoi amici, non agli ideali, e per quanto lo riguarda tutti gli altri possono andare a farsi un giro nello Stige. (Neutrale)",
						"Redenzione. In ognuno c'è una scintilla di bontà. (Buono)"
					},
					Bonds = new List<string>
					{
						"Cerca di ripagare un vecchio debito con un generoso benefattore.",
						"Ciò che guadagna fuori dalla legge sostiene la sua famiglia.",
						"Gli è stato sottratto qualcosa di importante, e intende rubarlo di nuovo.",
						"Diventerà il più grande ladro mai esistito.",
						"Si è macchiato di un crimine terribile e spera di poter rimediare.",
						"Una persona che amava è morta per un suo errore. Non succederà mai più."
					},
					Flaws = new List<string>
					{
						"Quando vede qualcosa di valore, non riesce a pensare ad altro che a come rubarlo.",
						"Quando deve scegliere tra il denaro e gli amici, di solito sceglie il denaro.",
						"Se c'è un piano, lo dimentica. Se non lo dimentica, lo ignora.",
						"Qualcosa nei suoi modi lo tradisce quando mente.",
						"Quando le cose si mettono male, se la dà a gambe.",
						"Un innocente è in prigione per un crimine che ha commesso lui, e la cosa non gli pesa."
					}
				}
			}
		};
	}
}
