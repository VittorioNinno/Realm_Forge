using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Sailor (2014 ruleset), with the Pirate variant and the Bad Reputation variant feature. Not part of SRD 5.1:
///	English and Italian texts are written for RealmForge, keeping the official game terms and mechanics. The
///	sailor gains no languages.
///	</summary>
public static class Sailor2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "sailor");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.Athletics, Skill.Perception },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "sailor", "en"),
					Language = LanguageCode.En,
					Name = "Sailor",
					Description = "For years you served aboard a seagoing ship. You weathered fierce storms, faced monsters of the deep, and fought off those who wanted to send your vessel to the bottom of the sea. The far line of the horizon was your first love, but now the time has come to try something new.\n\n### Your Ship\nWork out with your Dungeon Master what kind of ship you sailed on.\n\n- Was it a merchant ship, a navy vessel, an exploration ship, or a pirate ship? How famous (or infamous) is it? Has it traveled far and wide? Is it still sailing, or has it gone missing, presumed lost with all hands?\n- What was your job on board: boatswain, captain, navigator, cook, or something else? Who were the captain and the first mate? Did you leave on good terms with your crewmates, or on the run?\n\n### Variant: Pirate\nYou spent your youth under the command of a dreaded pirate, a ruthless cutthroat who taught you how to survive in a world of sharks and savages. You have plundered on the high seas and sent more than one soul who deserved it to a watery grave. Fear and bloodshed are old acquaintances, and you have earned a rather unsavory reputation in many port towns.\n\nIf your seafaring career included piracy, you can take the Bad Reputation feature instead of Ship's Passage.\n\n### Variant Feature: Bad Reputation\nA character with the sailor background can choose this feature instead of Ship's Passage.\n\nWherever you go, people fear you because of your reputation. In a civilized settlement you can get away with minor crimes, such as refusing to pay for a meal at a tavern or breaking down the door of a local shop, because most people won't report you to the authorities.",
					ToolProficiencies = "Navigator's tools, vehicles (water)",
					Equipment = "A belaying pin (club)\n50 feet of silk rope\nA lucky charm, such as a rabbit's foot or a small stone with a hole in the middle (or a random trinket rolled on the Trinkets table)\nA set of common clothes\nA belt pouch containing 10 gp",
					FeatureName = "Ship's Passage",
					FeatureDescription = "When you need to, you can secure free passage on a sailing ship for yourself and your adventuring companions. It might be the ship you served on, or another ship you are on good terms with (perhaps one captained by a former crewmate). Because you are calling in a favor, you can't count on a schedule or a route that suits your every need: your Dungeon Master decides how long it takes to reach your destination. In exchange for the free passage, you and your companions are expected to help the crew during the voyage.",
					CharacteristicsIntro = "Sailors can be a rough crowd, but the responsibilities of shipboard life usually make them reliable too. Life aboard a ship shapes their outlook and forms their most important ties.",
					PersonalityTraits = new List<string>
					{
						"My friends know they can count on me, no matter what.",
						"I work hard so that I can play hard once the work is done.",
						"I love sailing into new ports and making new friends over a tankard of ale.",
						"I stretch the truth for the sake of a good story.",
						"To me, a tavern brawl is a fine way to get to know a new city.",
						"I never turn down a friendly wager.",
						"My language is as foul as an otyugh nest.",
						"I like a job well done, especially if I can talk someone else into doing it."
					},
					Ideals = new List<string>
					{
						"Respect. What holds a ship together is mutual respect between captain and crew. (Good)",
						"Fairness. We all do the work, so we all share the rewards. (Lawful)",
						"Freedom. The sea is freedom: the freedom to go anywhere and do anything. (Chaotic)",
						"Mastery. I am a predator, and the other ships at sea are my prey. (Evil)",
						"People. I am devoted to my crewmates, not to ideals. (Neutral)",
						"Aspiration. One day I will own a ship and chart my own destiny. (Any)"
					},
					Bonds = new List<string>
					{
						"My loyalty goes to my captain first, and to everything else second.",
						"The ship is what matters most: crewmates and captains come and go.",
						"I will always remember my first ship.",
						"In a harbor town I have a lover whose eyes almost stole me away from the sea.",
						"I was cheated out of my fair share of the profits, and I want what I am owed.",
						"Ruthless pirates murdered my captain and crewmates, plundered our ship, and left me to die. I will have my revenge."
					},
					Flaws = new List<string>
					{
						"I follow orders even when I think they are wrong.",
						"I will say anything to get out of extra work.",
						"Once someone questions my courage, I never back down, however dangerous things get.",
						"Once I start drinking, it is hard for me to stop.",
						"I can't help pocketing loose coins and other trinkets I come across.",
						"My pride will probably be my downfall."
					}
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "sailor", "it"),
					Language = LanguageCode.It,
					Name = "Marinaio",
					Description = "Per anni il marinaio ha prestato servizio a bordo di una nave d'alto mare. Ha affrontato tempeste violente, mostri degli abissi e nemici decisi a mandare la sua nave in fondo al mare. La linea lontana dell'orizzonte è stata il suo primo amore, ma ora è arrivato il momento di provare qualcosa di nuovo.\n\n### La nave\nIl giocatore definisce con il Dungeon Master il tipo di nave su cui il personaggio ha navigato.\n\n- Era una nave mercantile, una nave militare, un vascello da esplorazione o una nave pirata? Quanto è famosa (o famigerata)? Ha viaggiato in lungo e in largo? Naviga ancora, o è scomparsa e la si crede perduta con tutto l'equipaggio?\n- Qual era il suo compito a bordo: nostromo, capitano, navigatore, cuoco o altro ancora? Chi erano il capitano e il primo ufficiale? Ha lasciato la nave in buoni rapporti con i compagni, o è fuggito?\n\n### Variante: Pirata\nIl marinaio ha passato la giovinezza agli ordini di un temuto pirata, uno spietato tagliagole che gli ha insegnato a sopravvivere in un mondo di squali e selvaggi. Ha saccheggiato in alto mare e mandato più di un'anima che se lo meritava in una tomba d'acqua salata. Paura e spargimenti di sangue sono vecchie conoscenze, e in molte città portuali si è fatto una reputazione piuttosto losca.\n\nSe la carriera in mare del personaggio ha incluso la pirateria, il giocatore può scegliere il privilegio Pessima Fama al posto di Passaggio via Nave.\n\n### Privilegio Alternativo: Pessima Fama\nUn personaggio con il background del marinaio può scegliere questo privilegio al posto di Passaggio via Nave.\n\nOvunque vada, la gente lo teme per via della sua reputazione. In un insediamento civilizzato può farla franca con reati minori, come rifiutarsi di pagare un pasto in taverna o sfondare la porta di una bottega, perché la maggior parte delle persone non lo denuncerà alle autorità.",
					ToolProficiencies = "Strumenti da navigatore, veicoli (acquatici)",
					Equipment = "Una caviglia da marinaio (randello)\nUna corda di seta di 15 metri\nUn portafortuna, come una zampa di coniglio o un sassolino forato al centro (oppure un oggetto casuale tirato sulla tabella degli Oggetti Insoliti)\nUn abito comune\nUna borsa con 10 mo",
					FeatureName = "Passaggio via Nave",
					FeatureDescription = "Quando ne ha bisogno, il marinaio può ottenere un passaggio gratuito su un veliero per sé e per i suoi compagni d'avventura. Può trattarsi della nave su cui ha prestato servizio o di un'altra nave con cui ha buoni rapporti (magari comandata da un suo ex compagno di ciurma). Poiché sta chiedendo un favore, non può contare su orari o rotte che soddisfino ogni sua esigenza: è il Dungeon Master a stabilire quanto tempo serve per arrivare a destinazione. In cambio del passaggio gratuito, il marinaio e i suoi compagni devono aiutare l'equipaggio durante il viaggio.",
					CharacteristicsIntro = "I marinai possono essere gente rude, ma le responsabilità della vita di bordo di solito li rendono anche affidabili. La vita su una nave ne plasma la visione del mondo e ne forma i legami più importanti.",
					PersonalityTraits = new List<string>
					{
						"I suoi amici sanno di poter contare su di lui, qualunque cosa accada.",
						"Lavora sodo per potersi divertire senza freni a lavoro finito.",
						"Adora approdare in porti nuovi e farsi nuovi amici davanti a un boccale di birra.",
						"Gonfia un po' la verità pur di raccontare una bella storia.",
						"Per lui una rissa in taverna è un ottimo modo per conoscere una città nuova.",
						"Non rifiuta mai una scommessa tra amici.",
						"Il suo linguaggio è sporco come il nido di un otyugh.",
						"Gli piace un lavoro ben fatto, soprattutto se riesce a convincere qualcun altro a farlo."
					},
					Ideals = new List<string>
					{
						"Rispetto. Ciò che tiene unita una nave è il rispetto reciproco tra capitano ed equipaggio. (Buono)",
						"Equità. Tutti fanno il lavoro, quindi tutti dividono le ricompense. (Legale)",
						"Libertà. Il mare è libertà: la libertà di andare ovunque e fare qualsiasi cosa. (Caotico)",
						"Dominio. È un predatore, e le altre navi in mare sono le sue prede. (Malvagio)",
						"Persone. È devoto ai suoi compagni di ciurma, non agli ideali. (Neutrale)",
						"Aspirazione. Un giorno avrà una nave tutta sua e traccerà da sé la rotta del suo destino. (Qualsiasi)"
					},
					Bonds = new List<string>
					{
						"La sua lealtà va prima al suo capitano, e solo dopo a tutto il resto.",
						"La nave è ciò che conta di più: compagni e capitani vanno e vengono.",
						"Ricorderà sempre la sua prima nave.",
						"In una città portuale ha un amante i cui occhi per poco non lo hanno strappato al mare.",
						"È stato derubato della sua giusta parte dei profitti, e vuole ciò che gli spetta.",
						"Pirati spietati hanno ucciso il suo capitano e i suoi compagni, saccheggiato la nave e lo hanno lasciato a morire. Avrà la sua vendetta."
					},
					Flaws = new List<string>
					{
						"Esegue gli ordini anche quando li ritiene sbagliati.",
						"Direbbe qualsiasi cosa pur di evitare lavoro in più.",
						"Quando qualcuno mette in dubbio il suo coraggio, non si tira mai indietro, per quanto pericolosa sia la situazione.",
						"Quando comincia a bere, fa fatica a fermarsi.",
						"Non resiste alla tentazione di intascare le monete e i ninnoli che trova in giro.",
						"Probabilmente l'orgoglio sarà la sua rovina."
					}
				}
			}
		};
	}
}
