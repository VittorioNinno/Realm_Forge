using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Guild Artisan (2014 ruleset), with the Guild Merchant variant. Not part of SRD 5.1: English and Italian texts
///	are written for RealmForge, keeping the official game terms and mechanics. The guild business table uses the
///	same order in both languages, so a roll gives the same result whatever the language.
///	</summary>
public static class GuildArtisan2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "guild-artisan");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.Insight, Skill.Persuasion },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "guild-artisan", "en"),
					Language = LanguageCode.En,
					Name = "Guild Artisan",
					Description = "You belong to an artisans' guild, a master of your craft working side by side with others of your trade. Talent and wealth have made you a solid part of the mercantile world and freed you from the bonds of the feudal order. You learned your skills as an apprentice to a master artisan, sponsored by the guild, until you earned the title of master yourself.\n\n### Guild Business\nGuilds usually thrive in cities large enough to support several artisans of the same trade, but yours might instead be a loose network of craftsfolk, each working in a different village of a wider realm. Decide the nature of your guild with your DM, then choose its business or roll on the table.\n\n| d20 | Guild Business |\n|---|---|\n| 1 | Alchemists and apothecaries |\n| 2 | Armorers, locksmiths, and finesmiths |\n| 3 | Brewers, distillers, and vintners |\n| 4 | Calligraphers, scribes, and scriveners |\n| 5 | Carpenters, roofers, and plasterers |\n| 6 | Cartographers, surveyors, and chart-makers |\n| 7 | Cobblers and shoemakers |\n| 8 | Cooks and bakers |\n| 9 | Glassblowers and glaziers |\n| 10 | Jewelers and gemcutters |\n| 11 | Leatherworkers, skinners, and tanners |\n| 12 | Masons and stonecutters |\n| 13 | Painters, limners, and sign-makers |\n| 14 | Potters and tile-makers |\n| 15 | Shipwrights and sailmakers |\n| 16 | Smiths and metal-forgers |\n| 17 | Tinkers, pewterers, and casters |\n| 18 | Wagon-makers and wheelwrights |\n| 19 | Weavers and dyers |\n| 20 | Woodcarvers, coopers, and bowyers |\n\nAs a guild member you know how to turn raw materials into finished goods (your proficiency with a type of artisan's tools), and you understand trade and sound business practice. What remains to be seen is whether you leave your craft behind for adventure, or work twice as hard to keep both careers going.\n\n### Variant: Guild Merchant\nInstead of an artisans' guild, you might belong to a guild of traders, caravan masters, or shopkeepers. You don't make goods yourself: you earn your living by buying and selling the work of others, or the raw materials artisans need. Your guild could be a large merchant consortium, or a family, with interests across the whole region. Perhaps you carried goods from place to place by ship, wagon, or caravan, or bought them from traveling traders to sell in your own small shop. In many ways, the life of a traveling merchant leads to adventure far more readily than an artisan's.\n\nInstead of proficiency with artisan's tools, you can be proficient with navigator's tools or learn an additional language. Instead of artisan's tools, you can start with a mule and a cart.",
					ToolProficiencies = "One type of artisan's tools",
					Languages = "One of your choice",
					Equipment = "A set of artisan's tools of your choice\nA letter of introduction from your guild\nA set of traveler's clothes\nA belt pouch containing 15 gp",
					FeatureName = "Guild Membership",
					FeatureDescription = "As an established and respected member of a guild, you enjoy the benefits that membership brings. Your fellow members will give you food and lodging when you need them and will pay for your funeral if it comes to that. In some cities and towns the guild has a guildhall, a central meeting place for members of your profession and a good spot to find patrons, allies, or hirelings.\n\nGuilds often hold great political power. If you are accused of a crime, your guild will stand by you as long as your innocence can be reasonably argued or the crime can be justified. As long as you are a member in good standing, the guild can also open doors to powerful political figures, although such connections may call for a donation of money or magic items to the guild's coffers.\n\nYou must pay the guild dues of 5 gp per month. If you miss payments, you must settle the arrears to stay in the guild's good graces.",
					CharacteristicsIntro = "Guild artisans are among the most ordinary people in the world, until they put down their tools and take up a life of adventure. They know the worth of hard work and the importance of community, but they are prone to greed and envy.",
					PersonalityTraits = new List<string>
					{
						"If something is worth doing, it is worth doing right. I can't help it: I'm a perfectionist.",
						"I am a snob who looks down on anyone who can't appreciate fine art.",
						"I always want to know how things work and what drives people.",
						"I have a witty saying or a proverb for every occasion.",
						"I am rude to anyone who doesn't share my devotion to hard work and fair dealing.",
						"I love talking at length about my profession.",
						"I don't part with my money easily, and I haggle tirelessly to get the best deal.",
						"My work is well known and I want everyone to appreciate it. It always surprises me when someone hasn't heard of me."
					},
					Ideals = new List<string>
					{
						"Community. Every civilized person has a duty to strengthen the bonds of the community and the safety of civilization. (Lawful)",
						"Generosity. My talents were given to me so that I could use them for the good of the world. (Good)",
						"Freedom. Everyone should be free to earn a living as they choose. (Chaotic)",
						"Greed. I'm only in it for the money. (Evil)",
						"People. I am devoted to the people I care about, not to ideals. (Neutral)",
						"Aspiration. I work hard to be the very best at my craft. (Any)"
					},
					Bonds = new List<string>
					{
						"The workshop where I learned my trade is the most important place in the world to me.",
						"I made a great work for someone who then proved unworthy of it. I am still looking for someone who deserves it.",
						"I owe a great debt to my guild for making me who I am today.",
						"I chase wealth to win someone's love.",
						"One day I will return to my guild and prove that I am the greatest artisan of them all.",
						"I will take revenge on the evil forces that destroyed my workshop and ruined my livelihood."
					},
					Flaws = new List<string>
					{
						"I will do anything to get my hands on something rare or priceless.",
						"I am quick to assume that someone is trying to cheat me.",
						"Nobody must ever find out that I once stole money from the guild's coffers.",
						"I am never satisfied with what I have: I always want more.",
						"I would kill to gain a noble title.",
						"I am terribly jealous of anyone whose work outshines mine. Wherever I go, I see rivals all around me."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "guild-artisan", "it"),
					Language = LanguageCode.It,
					Name = "Artigiano di Gilda",
					Description = "L'artigiano di gilda fa parte di una gilda di artigiani: è un maestro nel suo mestiere e lavora fianco a fianco con altri del suo settore. Il talento e la ricchezza ne hanno fatto una presenza stabile nel mondo mercantile, libera dai vincoli dell'ordine feudale. Ha imparato il mestiere come apprendista di un mastro artigiano, con il patrocinio della gilda, finché non è diventato a sua volta un maestro.\n\n### Attività della Gilda\nLe gilde prosperano di solito nelle città abbastanza grandi da ospitare più artigiani dello stesso mestiere, ma la sua potrebbe anche essere una rete informale di artigiani sparsi nei villaggi di un reame più vasto. Il giocatore definisce con il DM la natura della gilda, poi ne sceglie l'attività oppure tira sulla tabella.\n\n| d20 | Attività della Gilda |\n|---|---|\n| 1 | Alchimisti e speziali |\n| 2 | Fabbricanti di armature, di serrature e cesellatori |\n| 3 | Birrai, distillatori e vinificatori |\n| 4 | Calligrafi, scribi e scrivani |\n| 5 | Falegnami, copritetti e stuccatori |\n| 6 | Cartografi, agrimensori e disegnatori di mappe |\n| 7 | Ciabattini e calzolai |\n| 8 | Cuochi e panettieri |\n| 9 | Soffiatori di vetro e vetrai |\n| 10 | Gioiellieri e intagliatori di gemme |\n| 11 | Pellai, scuoiatori e conciatori |\n| 12 | Muratori e scalpellini |\n| 13 | Pittori, miniaturisti e pittori di insegne |\n| 14 | Vasai e piastrellai |\n| 15 | Carpentieri navali e velai |\n| 16 | Fabbri e forgiatori |\n| 17 | Stagnini, peltrai e fonditori |\n| 18 | Carrozzai e carradori |\n| 19 | Tessitori e tintori |\n| 20 | Intagliatori, bottai e costruttori di archi |\n\nCome membro della gilda sa trasformare le materie prime in oggetti finiti (la sua competenza in un tipo di strumenti da artigiano) e conosce i principi del commercio e delle buone pratiche d'affari. Resta da vedere se abbandonerà il mestiere per l'avventura o se si impegnerà il doppio per portare avanti entrambe le carriere.\n\n### Variante: Mercante di Gilda\nInvece che a una gilda di artigiani, il personaggio potrebbe appartenere a una gilda di commercianti, mastri carovanieri o bottegai. Non produce merci da sé: si guadagna da vivere comprando e vendendo il lavoro altrui, o le materie prime di cui gli artigiani hanno bisogno. La sua gilda potrebbe essere un grande consorzio mercantile, o una famiglia, con interessi in tutta la regione. Forse trasportava merci da un luogo all'altro per nave, su carro o in carovana, oppure le comprava da mercanti itineranti per rivenderle nella sua piccola bottega. Per molti versi, la vita del mercante itinerante porta all'avventura molto più facilmente di quella dell'artigiano.\n\nAl posto della competenza negli strumenti da artigiano, il personaggio può essere competente negli strumenti da navigatore o conoscere un linguaggio aggiuntivo. Al posto degli strumenti da artigiano, può iniziare con un mulo e un carretto.",
					ToolProficiencies = "Un tipo di strumenti da artigiano",
					Languages = "Uno a scelta",
					Equipment = "Un set di strumenti da artigiano a scelta\nUna lettera di presentazione della gilda\nUn abito da viaggiatore\nUna borsa con 15 mo",
					FeatureName = "Appartenenza alla Gilda",
					FeatureDescription = "In quanto membro rispettato e di lunga data di una gilda, l'artigiano gode dei vantaggi che l'appartenenza comporta. Quando ne ha bisogno, i compagni di gilda gli offrono vitto e alloggio e, se necessario, pagano il suo funerale. In alcune città e paesi la gilda dispone di una sede, un punto d'incontro per chi esercita la sua professione e un buon posto dove trovare committenti, alleati o gregari.\n\nLe gilde detengono spesso un grande potere politico. Se l'artigiano viene accusato di un crimine, la gilda lo sostiene purché la sua innocenza sia ragionevolmente difendibile o il crimine sia giustificabile. Finché resta un membro stimato, la gilda può anche aprirgli le porte di figure politiche potenti, anche se contatti simili potrebbero richiedere una donazione in denaro o in oggetti magici alle casse della gilda.\n\nL'artigiano deve versare alla gilda una quota di 5 mo al mese. Se salta dei pagamenti, deve saldare gli arretrati per restare nelle grazie della gilda.",
					CharacteristicsIntro = "Gli artigiani di gilda sono tra le persone più comuni del mondo, finché non posano gli attrezzi per intraprendere una vita d'avventura. Conoscono il valore del lavoro duro e l'importanza della comunità, ma sono inclini all'avidità e all'invidia.",
					PersonalityTraits = new List<string>
					{
						"Se una cosa vale la pena di farla, va fatta bene. Non può farci niente: è un perfezionista.",
						"È uno snob che guarda dall'alto in basso chi non sa apprezzare l'arte raffinata.",
						"Vuole sempre sapere come funzionano le cose e che cosa spinge le persone ad agire.",
						"Ha un motto arguto o un proverbio per ogni occasione.",
						"È sgarbato con chi non condivide la sua dedizione al lavoro duro e all'onestà.",
						"Adora parlare a lungo della sua professione.",
						"Non si separa facilmente dal suo denaro e contratta senza sosta per ottenere l'affare migliore.",
						"Il suo lavoro è famoso e vuole che tutti lo apprezzino. Resta sempre sorpreso quando qualcuno non ha mai sentito parlare di lui."
					},
					Ideals = new List<string>
					{
						"Comunità. Ogni persona civile ha il dovere di rafforzare i legami della comunità e la sicurezza della civiltà. (Legale)",
						"Generosità. I suoi talenti gli sono stati donati perché li usasse per il bene del mondo. (Buono)",
						"Libertà. Ognuno dovrebbe essere libero di guadagnarsi da vivere come preferisce. (Caotico)",
						"Avidità. Lo fa solo per il denaro. (Malvagio)",
						"Persone. È devoto alle persone a cui tiene, non agli ideali. (Neutrale)",
						"Aspirazione. Lavora sodo per essere il migliore in assoluto nel suo mestiere. (Qualsiasi)"
					},
					Bonds = new List<string>
					{
						"La bottega in cui ha imparato il mestiere è il luogo più importante del mondo per lui.",
						"Ha realizzato un capolavoro per qualcuno che poi si è dimostrato indegno di riceverlo. Cerca ancora qualcuno che lo meriti.",
						"Ha un grande debito con la sua gilda, che ha fatto di lui ciò che è oggi.",
						"Insegue la ricchezza per conquistare l'amore di qualcuno.",
						"Un giorno tornerà alla sua gilda e dimostrerà di essere il più grande artigiano di tutti.",
						"Si vendicherà delle forze malvagie che hanno distrutto la sua bottega e rovinato i suoi mezzi di sostentamento."
					},
					Flaws = new List<string>
					{
						"Farà qualunque cosa pur di mettere le mani su qualcosa di raro o di inestimabile valore.",
						"Sospetta subito che qualcuno stia cercando di imbrogliarlo.",
						"Nessuno deve mai scoprire che una volta ha sottratto denaro dalle casse della gilda.",
						"Non è mai soddisfatto di ciò che ha: vuole sempre di più.",
						"Ucciderebbe per ottenere un titolo nobiliare.",
						"È terribilmente geloso di chiunque produca opere migliori delle sue. Ovunque vada, vede rivali tutt'intorno."
					}
				}
			}
		};
	}
}
