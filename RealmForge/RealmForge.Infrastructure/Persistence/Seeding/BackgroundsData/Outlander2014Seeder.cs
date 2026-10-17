using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Outlander (2014 ruleset). Not part of SRD 5.1: English and Italian texts are written for RealmForge, keeping
///	the official game terms and mechanics. The origin table uses the same order in both languages, so a roll gives
///	the same result whatever the language.
///	</summary>
public static class Outlander2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "outlander");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.Athletics, Skill.Survival },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "outlander", "en"),
					Language = LanguageCode.En,
					Name = "Outlander",
					Description = "You grew up in the wilds, far from civilization and the comforts of towns and technology. You have watched herds bigger than forests migrate across the land, endured weather harsher than any city dweller could imagine, and savored the solitude of being the only thinking creature for miles around. Whether you were a nomad, an explorer, a recluse, a hunter-gatherer, or even a raider, the wild is in your blood: even where you don't know the lay of the land, you know how the wilderness works.\n\n### Origin\nYou have traveled to strange places and seen things others can hardly imagine. Think about the distant lands you visited and how they changed you. Choose the occupation that best fits your time in the wild, or roll on the table.\n\n| d10 | Origin |\n|---|---|\n| 1 | Forester |\n| 2 | Trapper |\n| 3 | Homesteader |\n| 4 | Guide |\n| 5 | Exile or outcast |\n| 6 | Bounty hunter |\n| 7 | Pilgrim |\n| 8 | Tribal nomad |\n| 9 | Hunter-gatherer |\n| 10 | Tribal marauder |",
					ToolProficiencies = "One type of musical instrument",
					Languages = "One of your choice",
					Equipment = "A staff\nA hunting trap\nA trophy from an animal you killed\nA set of traveler's clothes\nA belt pouch containing 10 gp",
					FeatureName = "Wanderer",
					FeatureDescription = "You have an excellent memory for maps and geography, and you can always recall the general layout of the terrain, settlements, and other features around you. In addition, each day you can find food and fresh water for yourself and up to five other people, as long as the land offers berries, small game, water, and the like.",
					CharacteristicsIntro = "Civilized folk often find outlanders rude and coarse, and outlanders have little patience for the refinements of city life. For most of them, the bonds that matter are those of tribe, clan, and family, and of the natural world they belong to.",
					PersonalityTraits = new List<string>
					{
						"A restless wanderlust drove me far from home.",
						"I watch over my friends as if they were a litter of newborn pups.",
						"I once ran twenty-five miles without stopping to warn my clan of an approaching orc horde. I would do it again if I had to.",
						"I have a lesson drawn from nature for every situation.",
						"I put no stock in the rich or the well-mannered. Money and manners won't save you from a hungry owlbear.",
						"I am always picking things up and fiddling with them absent-mindedly, and sometimes I break them by accident.",
						"I feel much more at ease among animals than among people.",
						"I was, in fact, raised by wolves."
					},
					Ideals = new List<string>
					{
						"Change. Life is like the seasons, always changing, and we must change with it. (Chaotic)",
						"Greater Good. Everyone must do their part to bring the greatest happiness to the whole tribe. (Good)",
						"Honor. If I dishonor myself, I dishonor my whole clan. (Lawful)",
						"Might. The strongest are meant to rule. (Evil)",
						"Nature. The natural world matters more than all the works of civilization. (Neutral)",
						"Glory. I must win glory in battle, for myself and for my clan. (Any)"
					},
					Bonds = new List<string>
					{
						"My family, clan, or tribe is the most important thing in my life, even when they are far away.",
						"Any harm done to the untouched wilderness of my homeland is harm done to me.",
						"I will bring terrible wrath upon the evildoers who destroyed my homeland.",
						"I am the last of my tribe, and it falls to me to make sure their names become legend.",
						"I am haunted by visions of a coming disaster, and I will do anything to stop it.",
						"It is my duty to have children so that my tribe endures."
					},
					Flaws = new List<string>
					{
						"I am far too fond of ale, wine, and other intoxicants.",
						"A life lived to the fullest leaves no room for caution.",
						"I remember every insult I have ever received and quietly resent anyone who has wronged me.",
						"I am slow to trust members of other races, tribes, and societies.",
						"Violence is my answer to almost every challenge.",
						"Don't expect me to save those who can't save themselves. In nature the strong thrive and the weak perish."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "outlander", "it"),
					Language = LanguageCode.It,
					Name = "Forestiero",
					Description = "Il forestiero è cresciuto nelle terre selvagge, lontano dalla civiltà e dalle comodità dei centri abitati e della tecnologia. Ha visto migrare mandrie più vaste delle foreste, ha resistito a intemperie più dure di quanto qualsiasi cittadino possa immaginare e ha assaporato la solitudine di essere l'unica creatura pensante per chilometri e chilometri. Che fosse un nomade, un esploratore, un solitario, un cacciatore-raccoglitore o perfino un predone, la natura selvaggia gli scorre nel sangue: anche dove non conosce la conformazione del territorio, sa come funzionano le terre selvagge.\n\n### Origini\nIl forestiero ha viaggiato in luoghi strani e ha visto cose che gli altri faticano persino a immaginare. Il giocatore riflette sulle terre lontane che il personaggio ha visitato e su come lo hanno cambiato, poi sceglie l'occupazione più adatta al periodo trascorso nelle terre selvagge, oppure tira sulla tabella.\n\n| d10 | Origini |\n|---|---|\n| 1 | Forestale |\n| 2 | Cacciatore con trappole |\n| 3 | Colono |\n| 4 | Guida |\n| 5 | Esule o reietto |\n| 6 | Cacciatore di taglie |\n| 7 | Pellegrino |\n| 8 | Nomade tribale |\n| 9 | Cacciatore-raccoglitore |\n| 10 | Predone tribale |",
					ToolProficiencies = "Un tipo di strumento musicale",
					Languages = "Uno a scelta",
					Equipment = "Un bastone\nUna tagliola\nUn trofeo di un animale che ha ucciso\nUn abito da viaggiatore\nUna borsa con 10 mo",
					FeatureName = "Viandante",
					FeatureDescription = "Il forestiero ha un'ottima memoria per le mappe e la geografia, e ricorda sempre la disposizione generale del territorio, degli insediamenti e degli altri punti di riferimento intorno a lui. Inoltre, ogni giorno può trovare cibo e acqua fresca per sé e per un massimo di altre cinque persone, purché il territorio offra bacche, piccola selvaggina, acqua e simili.",
					CharacteristicsIntro = "La gente civilizzata considera spesso i forestieri rozzi e incivili, e i forestieri hanno poca pazienza per le raffinatezze della vita cittadina. Per la maggior parte di loro, i legami che contano sono quelli della tribù, del clan e della famiglia, e del mondo naturale di cui fanno parte.",
					PersonalityTraits = new List<string>
					{
						"Un'irrequieta voglia di viaggiare lo ha portato lontano da casa.",
						"Veglia sui suoi amici come se fossero una cucciolata appena nata.",
						"Una volta ha corso per quaranta chilometri senza fermarsi per avvertire il suo clan dell'arrivo di un'orda di orchi. Se fosse necessario, lo rifarebbe.",
						"Per ogni situazione ha una lezione tratta dall'osservazione della natura.",
						"Non dà alcun peso ai ricchi o alle persone raffinate. Soldi e buone maniere non salvano nessuno da un orsogufo affamato.",
						"Raccoglie continuamente oggetti, ci giocherella distrattamente e a volte li rompe senza volerlo.",
						"Si trova molto più a suo agio tra gli animali che tra le persone.",
						"In effetti, è stato allevato dai lupi."
					},
					Ideals = new List<string>
					{
						"Cambiamento. La vita è come le stagioni, in continuo mutamento, e noi dobbiamo cambiare con lei. (Caotico)",
						"Bene superiore. Ognuno deve fare la sua parte per portare la massima felicità a tutta la tribù. (Buono)",
						"Onore. Se disonora se stesso, disonora l'intero clan. (Legale)",
						"Potere. I più forti sono fatti per comandare. (Malvagio)",
						"Natura. Il mondo naturale conta più di tutte le opere della civiltà. (Neutrale)",
						"Gloria. Deve conquistare la gloria in battaglia, per sé e per il suo clan. (Qualsiasi)"
					},
					Bonds = new List<string>
					{
						"La sua famiglia, il suo clan o la sua tribù sono la cosa più importante della sua vita, anche quando sono lontani.",
						"Ogni danno inflitto alla natura incontaminata della sua terra è un danno inflitto a lui.",
						"Scatenerà un'ira terribile sui malvagi che hanno distrutto la sua terra.",
						"È l'ultimo della sua tribù, e tocca a lui fare in modo che i loro nomi entrino nella leggenda.",
						"È tormentato da visioni di un disastro imminente e farà qualunque cosa per impedirlo.",
						"È suo dovere avere figli perché la sua tribù sopravviva."
					},
					Flaws = new List<string>
					{
						"Ama fin troppo la birra, il vino e le altre bevande inebrianti.",
						"In una vita vissuta fino in fondo non c'è posto per la prudenza.",
						"Ricorda ogni insulto ricevuto e cova un rancore silenzioso verso chiunque gli abbia fatto un torto.",
						"Fatica a fidarsi dei membri di altre razze, tribù e società.",
						"La violenza è la sua risposta a quasi ogni sfida.",
						"Non aspettatevi che salvi chi non sa salvarsi da solo. In natura il forte prospera e il debole perisce."
					}
				}
			}
		};
	}
}
